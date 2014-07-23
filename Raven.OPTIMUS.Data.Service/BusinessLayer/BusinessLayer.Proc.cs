using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Data.Core.Dal;
using System.Data;

namespace Raven.OPTIMUS.Data.Service
{
    public static partial class BusinessLayer
    {
        #region spPharmacyItemBalanceByWarehouseByLocation
        public static List<spPharmacyItemBalanceByWarehouseByLocation> GetspPharmacyItemBalanceByWarehouseByLocationList(String[] parameterField, String[] param)
        {
            List<spPharmacyItemBalanceByWarehouseByLocation> result = new List<spPharmacyItemBalanceByWarehouseByLocation>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(spPharmacyItemBalanceByWarehouseByLocation));
                ctx.CommandText = "spfmrpt_PersediaanBarang_PerGudang_PerLokasi";
                ctx.CommandType = System.Data.CommandType.StoredProcedure;
                //Add Parameter
                int count = parameterField.Length;
                for (int i = 0; i < count; i++)
                {
                    ctx.Add(parameterField[i], param[i]);
                }
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((spPharmacyItemBalanceByWarehouseByLocation)helper.IDataReaderToObject(reader, new spPharmacyItemBalanceByWarehouseByLocation()));
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
        #region spPharmacyStockCard
        public static List<spPharmacyStockCard> GetspPharmacyStockCardList(String[] parameterField, String[] param)
        {
            List<spPharmacyStockCard> result = new List<spPharmacyStockCard>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(spPharmacyStockCard));
                ctx.CommandText = "spfmrpt_KartuPersediaanFarmasi";
                ctx.CommandType = System.Data.CommandType.StoredProcedure;
                //Add Parameter
                int count = parameterField.Length;
                for (int i = 0; i < count; i++)
                {
                    ctx.Add(parameterField[i], param[i]);
                }
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((spPharmacyStockCard)helper.IDataReaderToObject(reader, new spPharmacyStockCard()));
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
        #region spSensusRIPerBulanPerKelas
        public static List<spSensusRIPerBulanPerKelas> GetspSensusRIPerBulanPerKelasList(String[] parameterField, String[] param)
        {
            List<spSensusRIPerBulanPerKelas> result = new List<spSensusRIPerBulanPerKelas>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(spSensusRIPerBulanPerKelas));
                ctx.CommandText = "sprirpt_SensusRI_perBulan_perKelas";
                ctx.CommandType = System.Data.CommandType.StoredProcedure;
                //Add Parameter
                int count = parameterField.Length;
                for (int i = 0; i < count; i++)
                {
                    ctx.Add(parameterField[i], param[i]);
                }
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((spSensusRIPerBulanPerKelas)helper.IDataReaderToObject(reader, new spSensusRIPerBulanPerKelas()));
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
        #region spSensusRIPerBulanPerRuang
        public static List<spSensusRIPerBulanPerRuang> GetspSensusRIPerBulanPerRuangList(String[] parameterField, String[] param)
        {
            List<spSensusRIPerBulanPerRuang> result = new List<spSensusRIPerBulanPerRuang>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(spSensusRIPerBulanPerKelas));
                ctx.CommandText = "sprirpt_SensusRI_perBulan_perRuang";
                ctx.CommandType = System.Data.CommandType.StoredProcedure;
                //Add Parameter
                int count = parameterField.Length;
                for (int i = 0; i < count; i++)
                {
                    ctx.Add(parameterField[i], param[i]);
                }
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((spSensusRIPerBulanPerRuang)helper.IDataReaderToObject(reader, new spSensusRIPerBulanPerRuang()));
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
        #region spSensusRIPerTahunPerKelas
        public static List<spSensusRIPerTahunPerKelas> GetspSensusRIPerTahunPerKelasList(String[] parameterField, String[] param)
        {
            List<spSensusRIPerTahunPerKelas> result = new List<spSensusRIPerTahunPerKelas>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(spSensusRIPerTahunPerKelas));
                ctx.CommandText = "sprirpt_SensusRI_perTahun_perKelas";
                ctx.CommandType = System.Data.CommandType.StoredProcedure;
                //Add Parameter
                int count = parameterField.Length;
                for (int i = 0; i < count; i++)
                {
                    ctx.Add(parameterField[i], param[i]);
                }
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((spSensusRIPerTahunPerKelas)helper.IDataReaderToObject(reader, new spSensusRIPerTahunPerKelas()));
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
        #region spSensusRIPerTahunPerRuang
        public static List<spSensusRIPerTahunPerRuang> GetspSensusRIPerTahunPerRuangList(String[] parameterField, String[] param)
        {
            List<spSensusRIPerTahunPerRuang> result = new List<spSensusRIPerTahunPerRuang>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(spSensusRIPerTahunPerRuang));
                ctx.CommandText = "sprirpt_SensusRI_perTahun_perRuang";
                ctx.CommandType = System.Data.CommandType.StoredProcedure;
                //Add Parameter
                int count = parameterField.Length;
                for (int i = 0; i < count; i++)
                {
                    ctx.Add(parameterField[i], param[i]);
                }
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((spSensusRIPerTahunPerRuang)helper.IDataReaderToObject(reader, new spSensusRIPerTahunPerRuang()));
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



        public static DataTable GetDataReport(string procedureName, string[] parameterField, string[] param)
        {
            DataTable result;
            IDbContext ctx = DbFactory.Configure();

            try
            {
                ctx.CommandText = procedureName;
                ctx.CommandType = CommandType.StoredProcedure;
                ctx.Clear();
                //Add Parameter
                int count = parameterField.Length;
                for (int i = 0; i < count; i++)
                {
                    ctx.Add(parameterField[i], param[i]);
                }

                //Get DataReader
                result = DaoBase.GetDataTable(ctx);
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
    }
}
