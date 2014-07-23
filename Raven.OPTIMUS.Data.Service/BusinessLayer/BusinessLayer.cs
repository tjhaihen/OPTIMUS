using System;
using System.Collections.Generic;
using System.Text;
using Raven.Data.Core.Dal;
using System.Data;

namespace Raven.OPTIMUS.Data.Service
{
    public static partial class BusinessLayer
    {
        #region Report
        public static Report GetReport(String reportID)
        {
            return new ReportDao().Get(reportID);
        }
        public static int InsertReport(Report record)
        {
            return new ReportDao().Insert(record);
        }
        public static int UpdateReport(Report record)
        {
            return new ReportDao().Update(record);
        }
        public static int DeleteReport(String reportID)
        {
            return new ReportDao().Delete(reportID);
        }
        public static List<Report> GetReportList(string filterExpression)
        {
            List<Report> result = new List<Report>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(Report));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((Report)helper.IDataReaderToObject(reader, new Report()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                ctx.Close();
            }
            return result;
        }
        #endregion

        #region ReportParameterLabel
        public static ReportParameterLabel GetReportParameterLabel(Int32 id)
        {
            return new ReportParameterLabelDao().Get(id);
        }
        public static int InsertReportParameterLabel(ReportParameterLabel record)
        {
            return new ReportParameterLabelDao().Insert(record);
        }
        public static int UpdateReportParameterLabel(ReportParameterLabel record)
        {
            return new ReportParameterLabelDao().Update(record);
        }
        public static int DeleteReportParameterLabel(Int32 id)
        {
            return new ReportParameterLabelDao().Delete(id);
        }
        public static List<ReportParameterLabel> GetReportParameterLabelList(string filterExpression)
        {
            List<ReportParameterLabel> result = new List<ReportParameterLabel>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(ReportParameterLabel));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((ReportParameterLabel)helper.IDataReaderToObject(reader, new ReportParameterLabel()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                ctx.Close();
            }
            return result;
        }
        #endregion

        #region setvar
        public static SetVar GetSetVar(String app,String kode)
        {
            return new SetVarDao().Get(app,kode);
        }
        public static int InsertSetVar(SetVar record)
        {
            return new SetVarDao().Insert(record);
        }
        public static int UpdateSetVar(SetVar record)
        {
            return new SetVarDao().Update(record);
        }
        public static int DeleteSetVar(String AppId,string kode)
        {
            return new SetVarDao().Delete(AppId,kode);
        }
        public static List<SetVar> GetSetVarList(string filterExpression)
        {
            List<SetVar> result = new List<SetVar>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(SetVar));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((SetVar)helper.IDataReaderToObject(reader, new SetVar()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                ctx.Close();
            }
            return result;
        }
        #endregion


        #region Tools
        #region SysColumns
        public static List<SysColumns> GetSysColumnsList(string filterExpression)
        {
            List<SysColumns> result = new List<SysColumns>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(SysColumns));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((SysColumns)helper.IDataReaderToObject(reader, new SysColumns()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                ctx.Close();
            }
            return result;
        }
        public static List<String> GetSysColumnsPKList(string tableName)
        {
            List<String> result = new List<String>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(SysColumns));
                ctx.CommandText = string.Format("SELECT column_name FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1 AND table_name = '{0}'", tableName);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add(reader[0].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                ctx.Close();
            }
            return result;
        }

        #endregion
        #region SysObjects
        public static List<SysObjects> GetSysObjectsList(string filterExpression)
        {
            List<SysObjects> result = new List<SysObjects>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(SysObjects));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((SysObjects)helper.IDataReaderToObject(reader, new SysObjects()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                ctx.Close();
            }
            return result;
        }

        #endregion
        #endregion

    }
}
