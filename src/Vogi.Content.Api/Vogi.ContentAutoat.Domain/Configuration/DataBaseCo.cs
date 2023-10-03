using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vogi.ContentAutoat.Domain.Configuration
{
    public class DataBaseCo
    {
        public string ConnectionString { get; init; }
        public string DataBaseName { get; init; }

        public DataBaseCo(string connectionString, string dataBaseName)
        {
            ConnectionString = connectionString;
            DataBaseName = dataBaseName;
        }
    }
}
