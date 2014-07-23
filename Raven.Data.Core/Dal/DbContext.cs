using System;
using System.Configuration;
using System.Data;

namespace Raven.Data.Core.Dal
{
    internal class DbContext : IDbContext
    {
        private IDbConfig _cfg;
        private IDbConnection _cn;
        private IDbCommand _cmd;
        private IDataAdapter _da;
        private IDbTransaction _trans;

        public DbContext(string cnsconfig, bool transaction, IsolationLevel il)
        {
            _cfg = GetConfiguration(cnsconfig);
            _cn = _cfg.GetConnection();
            _cmd = _cn.CreateCommand();
            _da = _cfg.GetDataAdapter(_cmd);
            if (transaction)
            {
                _trans = _cn.BeginTransaction(il);
                _cmd.Transaction = _trans;
            }
            else
            {
                _trans = null;
            }
        }

        private IDbConfig GetConfiguration(string cnsconfig)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[cnsconfig];
            if (settings.ProviderName.Equals(DbConst.SQL_SERVER_CODENAME))
                return SqlServerProvider.Configure(settings.ConnectionString);
            if (settings.ProviderName.Equals(DbConst.OLEDB_CODENAME))
                return OleDbProvider.Configure(settings.ConnectionString);
            if (settings.ProviderName.Equals(DbConst.ORACLE_CODENAME))
                return OracleProvider.Configure(settings.ConnectionString);
            throw new Exception("Configuration Settings Not Ready");
        }

        #region IDbContext Members

        public void Add(string name, object value)
        {
            IDataParameter param = _cfg.GetDataParameter();
            param.ParameterName = _cfg.GetParameterName(name);
            param.Value = value;
            _cmd.Parameters.Add(param);
        }

        public void Close()
        {
            _cmd.Parameters.Clear();
            if (_trans == null)
            {
                _cn.Close();
                _cn.Dispose();
            }
        }

        public void Clear()
        {
            _cmd.Parameters.Clear();
        }

        public void CommitTransaction()
        {
            if (_trans != null)
            {
                _trans.Commit();
                _trans = null;
                _cmd.Parameters.Clear();
                if(_cn.State == ConnectionState.Open)
                {
                    _cn.Close();
                    _cn.Dispose();
                }
            }
        }

        public void RollBackTransaction()
        {
            if (_trans != null)
            {
                _trans.Rollback();
                _trans = null;
            }
        }

        public string CommandText
        {
            get { return _cmd.CommandText; }
            set { _cmd.CommandText = value; }
        }

        public CommandType CommandType
        {
            get { return _cmd.CommandType; }
            set { _cmd.CommandType = value; }
        }

        public IDbCommand Command
        {
            get { return _cmd; }
            set { _cmd = value; }
        }

        public IDataAdapter DataAdapter
        {
            get { return _da; }
        }

        public IDbTransaction Transaction
        {
            get { return _trans; }
            set { _trans = value; }
        }

        #endregion
    }
}