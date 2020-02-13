using MvcSample21.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace MvcSample21
{
    public class DbXmlKeysRepository : DbConnectionRepository, IXmlKeysRepository
    {
        private const string TableName = "\"DataProtectionKeys\"";

        public DbXmlKeysRepository(Func<IDbConnection> connectionFactory) : base(connectionFactory)
        {
        }

        public int Add(XmlKey key)
        {
            using (var conn = Connection)
            {
                var result = conn.ExecuteScalar<int>($"INSERT into {TableName}(Xml) values (@Xml)", key);
                return result;
            }
        }

        public IEnumerable<XmlKey> FindAll()
        {
            using (var conn = Connection)
            {
                return conn.Query<XmlKey>($"select * from {TableName}");
            }
        }
    }
}
