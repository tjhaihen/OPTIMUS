using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace Raven.Data.Core.Dal
{
    public sealed class DbFactory
    {
        public static IDbContext Configure()
        {
            return Configure(false);
        }

        public static IDbContext Configure(bool transaction)
        {
            return Configure(transaction, IsolationLevel.Unspecified);
        }

        public static IDbContext Configure(bool transaction, IsolationLevel il)
        {
            return Configure(DbConst.MAIN_CN_SETTING, transaction, il);
        }

        public static IDbContext Configure(string cnsconfig)
        {
            return Configure(cnsconfig, false);
        }

        public static IDbContext Configure(string cnsconfig, bool transaction)
        {
            return Configure(cnsconfig, transaction, IsolationLevel.Unspecified);
        }

        public static IDbContext Configure(string cnsconfig, bool transaction, IsolationLevel il)
        {
            return new DbContext(cnsconfig, transaction, il);
        }
    }
}
