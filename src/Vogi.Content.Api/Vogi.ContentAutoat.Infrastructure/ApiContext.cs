using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Vogi.ContentAutoat.Infrastructure
{
    public class ApiContext
    {
      
        private readonly string _baseUrl = string.Empty;
        private readonly int _failThreshold = 3;
        private readonly int _retryThreshold = 3;
        private readonly TimeSpan _retryInterval = TimeSpan.FromSeconds(30);

        private DateTime lastTry;
        private int failedAttempts;
        private int failedRetriesAttempts;

        public ApiState State { get; private set; } = ApiState.Open;

        public ApiContext(string BaseUrl)
        {
            _baseUrl = BaseUrl;
        }


        public async Task<T> PostAsync<T>(string uri, object ob)
        {
            switch (State)
            {
                case ApiState.Open:
                    Console.WriteLine("Open");
                    return await ExecuteRequestAsync<T>(uri, ob);
                case ApiState.HalfOpen:
                    Console.WriteLine("HalfOpen");
                    return await AttemptResetAsync<T>(uri, ob);
                case ApiState.Closed:
                default:
                    Console.WriteLine("Closed");
                    throw new InvalidOperationException("API access is currently closed.");
            }
        }

        private async Task<T> ExecuteRequestAsync<T>(string uri, object ob)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(ob), Encoding.UTF8, "application/json");
                try
                {
                    HttpResponseMessage response = await client.PostAsync(_baseUrl + uri, content);
                    Reset();
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                }
                catch
                {
                    TrackFailure();
                    throw new Exception("ApiCallFailed");
                }
            }
        }

        private async Task<T> AttemptResetAsync<T>(string uri, object ob)
        {
            if ((DateTime.UtcNow - lastTry) > _retryInterval)
            {
                return await ExecuteRequestAsync<T>(uri, ob);
            }
            else
            {
                failedRetriesAttempts++;
                if(failedRetriesAttempts >= _retryThreshold)
                {
                    State = ApiState.Closed;
                }
                throw new InvalidOperationException("API state is HalfOpen and retry interval has not elapsed.");
            }
        }

        private void TrackFailure()
        {
            failedAttempts++;
            lastTry = DateTime.UtcNow;
            if (failedAttempts >= _failThreshold)
            {
                State = ApiState.HalfOpen;
            }
        }

        private void Reset()
        {
            failedAttempts = 0;
            failedRetriesAttempts = 0;
            State = ApiState.Open;
        }
    }

    public enum ApiState
    {
        Closed,
        Open,
        HalfOpen
    }
}