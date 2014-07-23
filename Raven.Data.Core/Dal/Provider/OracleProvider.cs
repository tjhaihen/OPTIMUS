using System;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;

namespace Raven.Data.Core.Dal
{
    internal class OracleProvider : IDbConfig
    {
        private readonly OracleConnection _cn;

        private OracleProvider(string cnsconfig)
        {
            _cn = new OracleConnection(cnsconfig);
            _cn.Open();
        }

        public static OracleProvider Configure(string cnstring)
        {
            return new OracleProvider(cnstring);
        }

        #region IDbConfig Members

        public IDbConnection GetConnection()
        {
            return _cn;
        }

        public IDataAdapter GetDataAdapter(IDbCommand command)
        {
            return new OracleDataAdapter((OracleCommand)command);
        }

        public IDataParameter GetDataParameter()
        {
            return new OracleParameter();
        }

        public string GetParameterName(string name)
        {
            return name;
        }

        #endregion
    }
}