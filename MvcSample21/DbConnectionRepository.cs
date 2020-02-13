using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSample21
{
    public abstract class DbConnectionRepository
    {
        private readonly Func<IDbConnection> _connectionFactory;

        protected DbConnectionRepository(Func<IDbConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        protected IDbConnection Connection
        {
            get
            {
                var conn = _connectionFactory();
                conn.Open();
                return conn;
            }
        }
    }
}
