using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vogi.ContentAutoat.Domain.Model
{
    public class ContentData
    {
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public string Titel { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
        public DateTime Posted { get; set; }



        public Guid Guid { get; set; } 
        public Guid User { get; set; }
    }
}
