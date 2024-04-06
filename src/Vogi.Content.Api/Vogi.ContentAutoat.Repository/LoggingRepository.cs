using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;
using Vogi.ContentAutoat.Infrastructure;

namespace Vogi.ContentAutoat.Repository
{
    public interface ILoggingRepository
    {
        bool LogData(LoggingDto loggingData);
    }

    public class LoggingRepository : ILoggingRepository
    {
        private readonly ApiContext _apiContext;

        public LoggingRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }
        public bool LogData(LoggingDto loggingData)
        {
            return _apiContext.PostAsync<LogResult>("Logger", loggingData).Result.Result;
        }
    }

    public class LogResult
    {
        public bool Result { get; set; }
    }
}
