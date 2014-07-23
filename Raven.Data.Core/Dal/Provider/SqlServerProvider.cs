using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Data;

namespace Raven.Data.Core.Dal
{
    internal class SqlServerProvider : IDbConfig
    {
        private readonly SqlConnection _cn;

        private SqlServerProvider(string cnstring)
        {
            _cn = new SqlConnection(cnstring);
            _cn.Open();
        }

        public static IDbConfig Configure(string cnstring)
        {
            return new SqlServerProvider(cnstring);
        }

        public IDbConnection GetConnection()
        {
            return _cn;
        }

        public IDataAdapter GetDataAdapter(IDbCommand command)
        {
            return new SqlDataAdapter((SqlCommand)command);
        }

        public IDataParameter GetDataParameter()
        {
            return new SqlParameter();
        }

        public string GetParameterName(string name)
        {
            return name;
        }
    }
}
