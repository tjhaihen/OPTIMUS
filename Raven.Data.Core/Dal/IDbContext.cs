using System.Data;

namespace Raven.Data.Core.Dal
{
    public interface IDbContext
    {
        string CommandText { get; set; }
        CommandType CommandType { get; set; }
        IDbCommand Command { get; set;}
        IDataAdapter DataAdapter { get; }
        IDbTransaction Transaction { get; set;} 
        void Add(string name, object value);

        void Close();
        void Clear();

        void CommitTransaction();
        void RollBackTransaction();
    }
}