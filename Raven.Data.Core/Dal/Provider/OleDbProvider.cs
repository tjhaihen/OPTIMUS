using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace Raven.Data.Core.Dal
{
    internal class OleDbProvider : IDbConfig
    {
        private readonly OleDbConnection _cn;

        private OleDbProvider(string cnstring)
        {
            _cn = new OleDbConnection(cnstring);
            _cn.Open();
        }

        public static IDbConfig Configure(string cnstring)
        {
            return new OleDbProvider(cnstring);
        }

        #region IDbConfig Members

        public IDbConnection GetConnection()
        {
            return _cn;
        }

        public IDataAdapter GetDataAdapter(IDbCommand command)
        {
            return new OleDbDataAdapter((OleDbCommand) command);
        }

        public IDataParameter GetDataParameter()
        {
            return new OleDbParameter();
        }

        public string GetParameterName(string name)
        {
            return name;
        }

        #endregion
    }
}