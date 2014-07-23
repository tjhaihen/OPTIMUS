using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Data.Core.Dal;
using System.Data;

namespace Raven.OPTIMUS.Data.Service
{
    public static partial class BusinessLayer
    {
        #region vAppointmentMCU
        public static List<vAppointmentMCU> GetvAppointmentMCUList(string filterExpression)
        {
            List<vAppointmentMCU> result = new List<vAppointmentMCU>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vAppointmentMCU));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vAppointmentMCU)helper.IDataReaderToObject(reader, new vAppointmentMCU()));
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
        #region vAppointmentMD
        public static List<vAppointmentMD> GetvAppointmentMDList(string filterExpression)
        {
            List<vAppointmentMD> result = new List<vAppointmentMD>(); 
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vAppointmentMD));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vAppointmentMD)helper.IDataReaderToObject(reader, new vAppointmentMD()));
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
        #region vAppointmentRJ
        public static List<vAppointmentRJ> GetvAppointmentRJList(string filterExpression)
        {
            List<vAppointmentRJ> result = new List<vAppointmentRJ>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vAppointmentRJ));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vAppointmentRJ)helper.IDataReaderToObject(reader, new vAppointmentRJ()));
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
        #region vBadItem
        public static List<vBadItem> GetvBadItemList(string filterExpression)
        {
            List<vBadItem> result = new List<vBadItem>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vBadItem));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vBadItem)helper.IDataReaderToObject(reader, new vBadItem()));
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
        #region vBedInformationRI
        public static List<vBedInformationRI> GetvBedInformationRIList(string filterExpression)
        {
            List<vBedInformationRI> result = new List<vBedInformationRI>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vBedInformationRI));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vBedInformationRI)helper.IDataReaderToObject(reader, new vBedInformationRI()));
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
        #region vBusinessPartner
        public static List<vBusinessPartner> GetvBusinessPartnerList(string filterExpression)
        {
            List<vBusinessPartner> result = new List<vBusinessPartner>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vBusinessPartner));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vBusinessPartner)helper.IDataReaderToObject(reader, new vBusinessPartner()));
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
        #region vBuyRequest
        public static List<vBuyRequest> GetvBuyRequestList(string filterExpression)
        {
            List<vBuyRequest> result = new List<vBuyRequest>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vBuyRequest));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vBuyRequest)helper.IDataReaderToObject(reader, new vBuyRequest()));
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
        #region vClass
        public static List<vClass> GetvClassList(string filterExpression)
        {
            List<vClass> result = new List<vClass>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vClass));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vClass)helper.IDataReaderToObject(reader, new vClass()));
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
        #region vClinic
        public static List<vClinic> GetvClinicList(string filterExpression)
        {
            List<vClinic> result = new List<vClinic>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vClinic));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vClinic)helper.IDataReaderToObject(reader, new vClinic()));
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
        #region vEmergencyCarePatientExamination
        public static List<vEmergencyCarePatientExamination> GetvEmergencyCarePatientExaminationList(string filterExpression)
        {
            List<vEmergencyCarePatientExamination> result = new List<vEmergencyCarePatientExamination>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vEmergencyCarePatientExamination));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vEmergencyCarePatientExamination)helper.IDataReaderToObject(reader, new vEmergencyCarePatientExamination()));
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
        #region vEmergencyCareRevenue
        public static List<vEmergencyCareRevenue> GetvEmergencyCareRevenueList(string filterExpression)
        {
            List<vEmergencyCareRevenue> result = new List<vEmergencyCareRevenue>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vEmergencyCareRevenue));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vEmergencyCareRevenue)helper.IDataReaderToObject(reader, new vEmergencyCareRevenue()));
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
        #region vEmergencyCareTransaction
        public static List<vEmergencyCareTransaction> GetvEmergencyCareTransactionList(string filterExpression)
        {
            List<vEmergencyCareTransaction> result = new List<vEmergencyCareTransaction>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vEmergencyCareTransaction));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vEmergencyCareTransaction)helper.IDataReaderToObject(reader, new vEmergencyCareTransaction()));
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
        #region vFormulaProd
        public static List<vFormulaProd> GetvFormulaProdList(string filterExpression)
        {
            List<vFormulaProd> result = new List<vFormulaProd>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vFormulaProd));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vFormulaProd)helper.IDataReaderToObject(reader, new vFormulaProd()));
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
        #region vFormularium
        public static List<vFormularium> GetvFormulariumList(string filterExpression)
        {
            List<vFormularium> result = new List<vFormularium>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vFormularium));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vFormularium)helper.IDataReaderToObject(reader, new vFormularium()));
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
        #region vGeneralLogisticDirectPurchase
        public static List<vGeneralLogisticDirectPurchase> GetvGeneralLogisticDirectPurchaseList(string filterExpression)
        {
            List<vGeneralLogisticDirectPurchase> result = new List<vGeneralLogisticDirectPurchase>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vGeneralLogisticDirectPurchase));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vGeneralLogisticDirectPurchase)helper.IDataReaderToObject(reader, new vGeneralLogisticDirectPurchase()));
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
        #region vGeneralLogisticDirectPurchaseReturn
        public static List<vGeneralLogisticDirectPurchaseReturn> GetvGeneralLogisticDirectPurchaseReturnList(string filterExpression)
        {
            List<vGeneralLogisticDirectPurchaseReturn> result = new List<vGeneralLogisticDirectPurchaseReturn>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vGeneralLogisticDirectPurchaseReturn));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vGeneralLogisticDirectPurchaseReturn)helper.IDataReaderToObject(reader, new vGeneralLogisticDirectPurchaseReturn()));
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
        #region vGeneralLogisticGoodsRequest
        public static List<vGeneralLogisticGoodsRequest> GetvGeneralLogisticGoodsRequestList(string filterExpression)
        {
            List<vGeneralLogisticGoodsRequest> result = new List<vGeneralLogisticGoodsRequest>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vGeneralLogisticGoodsRequest));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vGeneralLogisticGoodsRequest)helper.IDataReaderToObject(reader, new vGeneralLogisticGoodsRequest()));
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
        #region vGeneralLogisticItem
        public static List<vGeneralLogisticItem> GetvGeneralLogisticItemList(string filterExpression)
        {
            List<vGeneralLogisticItem> result = new List<vGeneralLogisticItem>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vGeneralLogisticItem));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vGeneralLogisticItem)helper.IDataReaderToObject(reader, new vGeneralLogisticItem()));
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
        #region vGeneralLogisticItemAdjustment
        public static List<vGeneralLogisticItemAdjustment> GetvGeneralLogisticItemAdjustmentList(string filterExpression)
        {
            List<vGeneralLogisticItemAdjustment> result = new List<vGeneralLogisticItemAdjustment>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vGeneralLogisticItemAdjustment));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vGeneralLogisticItemAdjustment)helper.IDataReaderToObject(reader, new vGeneralLogisticItemAdjustment()));
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
        #region vGeneralLogisticItemConsumption
        public static List<vGeneralLogisticItemConsumption> GetvGeneralLogisticItemConsumptionList(string filterExpression)
        {
            List<vGeneralLogisticItemConsumption> result = new List<vGeneralLogisticItemConsumption>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vGeneralLogisticItemConsumption));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vGeneralLogisticItemConsumption)helper.IDataReaderToObject(reader, new vGeneralLogisticItemConsumption()));
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
        #region vGeneralLogisticItemDistribution
        public static List<vGeneralLogisticItemDistribution> GetvGeneralLogisticItemDistributionList(string filterExpression)
        {
            List<vGeneralLogisticItemDistribution> result = new List<vGeneralLogisticItemDistribution>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vGeneralLogisticItemDistribution));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vGeneralLogisticItemDistribution)helper.IDataReaderToObject(reader, new vGeneralLogisticItemDistribution()));
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
        #region vGeneralLogisticItemPriceAdjustment
        public static List<vGeneralLogisticItemPriceAdjustment> GetvGeneralLogisticItemPriceAdjustmentList(string filterExpression)
        {
            List<vGeneralLogisticItemPriceAdjustment> result = new List<vGeneralLogisticItemPriceAdjustment>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vGeneralLogisticItemPriceAdjustment));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vGeneralLogisticItemPriceAdjustment)helper.IDataReaderToObject(reader, new vGeneralLogisticItemPriceAdjustment()));
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
        #region vGeneralLogisticItemProduction
        public static List<vGeneralLogisticItemProduction> GetvGeneralLogisticItemProductionList(string filterExpression)
        {
            List<vGeneralLogisticItemProduction> result = new List<vGeneralLogisticItemProduction>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vGeneralLogisticItemProduction));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vGeneralLogisticItemProduction)helper.IDataReaderToObject(reader, new vGeneralLogisticItemProduction()));
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
        #region vGeneralLogisticPurchaseOrder
        public static List<vGeneralLogisticPurchaseOrder> GetvGeneralLogisticPurchaseOrderList(string filterExpression)
        {
            List<vGeneralLogisticPurchaseOrder> result = new List<vGeneralLogisticPurchaseOrder>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vGeneralLogisticPurchaseOrder));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vGeneralLogisticPurchaseOrder)helper.IDataReaderToObject(reader, new vGeneralLogisticPurchaseOrder()));
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
        #region vGeneralLogisticPurchaseOrderReceived
        public static List<vGeneralLogisticPurchaseOrderReceived> GetvGeneralLogisticPurchaseOrderReceivedList(string filterExpression)
        {
            List<vGeneralLogisticPurchaseOrderReceived> result = new List<vGeneralLogisticPurchaseOrderReceived>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vGeneralLogisticPurchaseOrderReceived));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vGeneralLogisticPurchaseOrderReceived)helper.IDataReaderToObject(reader, new vGeneralLogisticPurchaseOrderReceived()));
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
        #region vGeneralLogisticPurchaseReceive
        public static List<vGeneralLogisticPurchaseReceive> GetvGeneralLogisticPurchaseReceiveList(string filterExpression)
        {
            List<vGeneralLogisticPurchaseReceive> result = new List<vGeneralLogisticPurchaseReceive>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vGeneralLogisticPurchaseReceive));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vGeneralLogisticPurchaseReceive)helper.IDataReaderToObject(reader, new vGeneralLogisticPurchaseReceive()));
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
        #region vGeneralLogisticPurchaseRequest
        public static List<vGeneralLogisticPurchaseRequest> GetvGeneralLogisticPurchaseRequestList(string filterExpression)
        {
            List<vGeneralLogisticPurchaseRequest> result = new List<vGeneralLogisticPurchaseRequest>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vGeneralLogisticPurchaseRequest));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vGeneralLogisticPurchaseRequest)helper.IDataReaderToObject(reader, new vGeneralLogisticPurchaseRequest()));
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
        #region vGeneralLogisticPurchaseReturn
        public static List<vGeneralLogisticPurchaseReturn> GetvGeneralLogisticPurchaseReturnList(string filterExpression)
        {
            List<vGeneralLogisticPurchaseReturn> result = new List<vGeneralLogisticPurchaseReturn>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vGeneralLogisticPurchaseReturn));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vGeneralLogisticPurchaseReturn)helper.IDataReaderToObject(reader, new vGeneralLogisticPurchaseReturn()));
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
        #region vGeneralLogisticStockInitialization
        public static List<vGeneralLogisticStockInitialization> GetvGeneralLogisticStockInitializationList(string filterExpression)
        {
            List<vGeneralLogisticStockInitialization> result = new List<vGeneralLogisticStockInitialization>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vGeneralLogisticStockInitialization));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vGeneralLogisticStockInitialization)helper.IDataReaderToObject(reader, new vGeneralLogisticStockInitialization()));
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
        #region vGeneralLogisticStockOpnameResult
        public static List<vGeneralLogisticStockOpnameResult> GetvGeneralLogisticStockOpnameResultList(string filterExpression)
        {
            List<vGeneralLogisticStockOpnameResult> result = new List<vGeneralLogisticStockOpnameResult>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vGeneralLogisticStockOpnameResult));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vGeneralLogisticStockOpnameResult)helper.IDataReaderToObject(reader, new vGeneralLogisticStockOpnameResult()));
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
        #region vHealthcare
        public static List<vHealthcare> GetvHealthcareList(string filterExpression)
        {
            List<vHealthcare> result = new List<vHealthcare>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vHealthcare));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vHealthcare)helper.IDataReaderToObject(reader, new vHealthcare()));
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
        #region vHealthcareProfessional
        public static List<vHealthcareProfessional> GetvHealthcareProfessionalList(string filterExpression)
        {
            List<vHealthcareProfessional> result = new List<vHealthcareProfessional>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vHealthcareProfessional));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vHealthcareProfessional)helper.IDataReaderToObject(reader, new vHealthcareProfessional()));
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
        #region vInpatientDetailRegistration
        public static List<vInpatientDetailRegistration> GetvInpatientDetailRegistrationList(string filterExpression)
        {
            List<vInpatientDetailRegistration> result = new List<vInpatientDetailRegistration>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vInpatientDetailRegistration));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vInpatientDetailRegistration)helper.IDataReaderToObject(reader, new vInpatientDetailRegistration()));
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
        #region vInpatientRevenue
        public static List<vInpatientRevenue> GetvInpatientRevenueList(string filterExpression)
        {
            List<vInpatientRevenue> result = new List<vInpatientRevenue>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vInpatientRevenue));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vInpatientRevenue)helper.IDataReaderToObject(reader, new vInpatientRevenue()));
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
        #region vInpatientTransaction
        public static List<vInpatientTransaction> GetvInpatientTransactionList(string filterExpression)
        {
            List<vInpatientTransaction> result = new List<vInpatientTransaction>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vInpatientTransaction));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vInpatientTransaction)helper.IDataReaderToObject(reader, new vInpatientTransaction()));
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
        #region vLaboratoryTariff
        public static List<vLaboratoryTariff> GetvLaboratoryTariffList(string filterExpression)
        {
            List<vLaboratoryTariff> result = new List<vLaboratoryTariff>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vLaboratoryTariff));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vLaboratoryTariff)helper.IDataReaderToObject(reader, new vLaboratoryTariff()));
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
        #region vLogisticWarehouseLocation
        public static List<vLogisticWarehouseLocation> GetvLogisticWarehouseLocationList(string filterExpression)
        {
            List<vLogisticWarehouseLocation> result = new List<vLogisticWarehouseLocation>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vLogisticWarehouseLocation));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vLogisticWarehouseLocation)helper.IDataReaderToObject(reader, new vLogisticWarehouseLocation()));
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
        #region vMedicalCheckUpTariff
        public static List<vMedicalCheckUpTariff> GetvMedicalCheckUpTariffList(string filterExpression)
        {
            List<vMedicalCheckUpTariff> result = new List<vMedicalCheckUpTariff>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vMedicalCheckUpTariff));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vMedicalCheckUpTariff)helper.IDataReaderToObject(reader, new vMedicalCheckUpTariff()));
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
        #region vMedicalCheckUpTransaction
        public static List<vMedicalCheckUpTransaction> GetvMedicalCheckUpTransactionList(string filterExpression)
        {
            List<vMedicalCheckUpTransaction> result = new List<vMedicalCheckUpTransaction>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vMedicalCheckUpTransaction));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vMedicalCheckUpTransaction)helper.IDataReaderToObject(reader, new vMedicalCheckUpTransaction()));
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
        #region vMedicalDiagnosticTransaction
        public static List<vMedicalDiagnosticTransaction> GetvMedicalDiagnosticTransactionList(string filterExpression)
        {
            List<vMedicalDiagnosticTransaction> result = new List<vMedicalDiagnosticTransaction>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vMedicalDiagnosticTransaction));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vMedicalDiagnosticTransaction)helper.IDataReaderToObject(reader, new vMedicalDiagnosticTransaction()));
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
        #region vMedicalDiagnosticUnit
        public static List<vMedicalDiagnosticUnit> GetvMedicalDiagnosticUnitList(string filterExpression)
        {
            List<vMedicalDiagnosticUnit> result = new List<vMedicalDiagnosticUnit>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vMedicalDiagnosticUnit));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vMedicalDiagnosticUnit)helper.IDataReaderToObject(reader, new vMedicalDiagnosticUnit()));
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
        #region vNeoNatalRI
        public static List<vNeoNatalRI> GetvNeoNatalRIList(string filterExpression)
        {
            List<vNeoNatalRI> result = new List<vNeoNatalRI>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vNeoNatalRI));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vNeoNatalRI)helper.IDataReaderToObject(reader, new vNeoNatalRI()));
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
        #region vOutpatientRevenue
        public static List<vOutpatientRevenue> GetvOutpatientRevenueList(string filterExpression)
        {
            List<vOutpatientRevenue> result = new List<vOutpatientRevenue>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vOutpatientRevenue));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vOutpatientRevenue)helper.IDataReaderToObject(reader, new vOutpatientRevenue()));
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
        #region vOutpatientTransaction
        public static List<vOutpatientTransaction> GetvOutpatientTransactionList(string filterExpression)
        {
            List<vOutpatientTransaction> result = new List<vOutpatientTransaction>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vOutpatientTransaction));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vOutpatientTransaction)helper.IDataReaderToObject(reader, new vOutpatientTransaction()));
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
        #region vPatient
        public static List<vPatient> GetvPatientList(string filterExpression)
        {
            List<vPatient> result = new List<vPatient>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPatient));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPatient)helper.IDataReaderToObject(reader, new vPatient()));
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
        #region vPatientConsultVisit
        public static List<vPatientConsultVisit> GetvPatientConsultVisitList(string filterExpression)
        {
            List<vPatientConsultVisit> result = new List<vPatientConsultVisit>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPatientConsultVisit));
                string commandText = string.Format("{0} {1}", helper.Select(filterExpression), " ORDER BY ServiceUnitCode,RegistrationDate,RegistrationTime");
                ctx.CommandText = commandText;
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPatientConsultVisit)helper.IDataReaderToObject(reader, new vPatientConsultVisit()));
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
        #region vPharmacyConsignmentOrder
        public static List<vPharmacyConsignmentOrder> GetvPharmacyConsignmentOrderList(string filterExpression)
        {
            List<vPharmacyConsignmentOrder> result = new List<vPharmacyConsignmentOrder>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyConsignmentOrder));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyConsignmentOrder)helper.IDataReaderToObject(reader, new vPharmacyConsignmentOrder()));
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
        #region vPharmacyConsignmentReceive
        public static List<vPharmacyConsignmentReceive> GetvPharmacyConsignmentReceiveList(string filterExpression)
        {
            List<vPharmacyConsignmentReceive> result = new List<vPharmacyConsignmentReceive>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyConsignmentReceive));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyConsignmentReceive)helper.IDataReaderToObject(reader, new vPharmacyConsignmentReceive()));
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
        #region vPharmacyConsignmentReturn
        public static List<vPharmacyConsignmentReturn> GetvPharmacyConsignmentReturnList(string filterExpression)
        {
            List<vPharmacyConsignmentReturn> result = new List<vPharmacyConsignmentReturn>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyConsignmentReturn));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyConsignmentReturn)helper.IDataReaderToObject(reader, new vPharmacyConsignmentReturn()));
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
        #region vPharmacyCreditNote
        public static List<vPharmacyCreditNote> GetvPharmacyCreditNoteList(string filterExpression)
        {
            List<vPharmacyCreditNote> result = new List<vPharmacyCreditNote>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyCreditNote));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyCreditNote)helper.IDataReaderToObject(reader, new vPharmacyCreditNote()));
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
        #region vPharmacyDirectPurchase
        public static List<vPharmacyDirectPurchase> GetvPharmacyDirectPurchaseList(string filterExpression)
        {
            List<vPharmacyDirectPurchase> result = new List<vPharmacyDirectPurchase>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyDirectPurchase));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyDirectPurchase)helper.IDataReaderToObject(reader, new vPharmacyDirectPurchase()));
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
        #region vPharmacyDirectPurchaseReturn
        public static List<vPharmacyDirectPurchaseReturn> GetvPharmacyDirectPurchaseReturnList(string filterExpression)
        {
            List<vPharmacyDirectPurchaseReturn> result = new List<vPharmacyDirectPurchaseReturn>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyDirectPurchaseReturn));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyDirectPurchaseReturn)helper.IDataReaderToObject(reader, new vPharmacyDirectPurchaseReturn()));
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
        #region vPharmacyGoodsRequest
        public static List<vPharmacyGoodsRequest> GetvPharmacyGoodsRequestList(string filterExpression)
        {
            List<vPharmacyGoodsRequest> result = new List<vPharmacyGoodsRequest>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyGoodsRequest));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyGoodsRequest)helper.IDataReaderToObject(reader, new vPharmacyGoodsRequest()));
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
        #region vPharmacyItem
        public static List<vPharmacyItem> GetvPharmacyItemList(string filterExpression)
        {
            List<vPharmacyItem> result = new List<vPharmacyItem>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyItem));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyItem)helper.IDataReaderToObject(reader, new vPharmacyItem()));
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
        #region vPharmacyItemAdjustment
        public static List<vPharmacyItemAdjustment> GetvPharmacyItemAdjustmentList(string filterExpression)
        {
            List<vPharmacyItemAdjustment> result = new List<vPharmacyItemAdjustment>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyItemAdjustment));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyItemAdjustment)helper.IDataReaderToObject(reader, new vPharmacyItemAdjustment()));
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
        #region vPharmacyItemConsumption
        public static List<vPharmacyItemConsumption> GetvPharmacyItemConsumptionList(string filterExpression)
        {
            List<vPharmacyItemConsumption> result = new List<vPharmacyItemConsumption>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyItemConsumption));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyItemConsumption)helper.IDataReaderToObject(reader, new vPharmacyItemConsumption()));
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
        #region vPharmacyItemDistribution
        public static List<vPharmacyItemDistribution> GetvPharmacyItemDistributionList(string filterExpression)
        {
            List<vPharmacyItemDistribution> result = new List<vPharmacyItemDistribution>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyItemDistribution));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyItemDistribution)helper.IDataReaderToObject(reader, new vPharmacyItemDistribution()));
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
        #region vPharmacyItemPriceAdjustment
        public static List<vPharmacyItemPriceAdjustment> GetvPharmacyItemPriceAdjustmentList(string filterExpression)
        {
            List<vPharmacyItemPriceAdjustment> result = new List<vPharmacyItemPriceAdjustment>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyItemPriceAdjustment));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyItemPriceAdjustment)helper.IDataReaderToObject(reader, new vPharmacyItemPriceAdjustment()));
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
        #region vPharmacyItemProduction
        public static List<vPharmacyItemProduction> GetvPharmacyItemProductionList(string filterExpression)
        {
            List<vPharmacyItemProduction> result = new List<vPharmacyItemProduction>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyItemProduction));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyItemProduction)helper.IDataReaderToObject(reader, new vPharmacyItemProduction()));
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
        #region vPharmacyItemReorderPoint
        public static List<vPharmacyItemReorderPoint> GetvPharmacyItemReorderPointList(string filterExpression)
        {
            List<vPharmacyItemReorderPoint> result = new List<vPharmacyItemReorderPoint>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyItemReorderPoint));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyItemReorderPoint)helper.IDataReaderToObject(reader, new vPharmacyItemReorderPoint()));
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
        #region vPharmacyPrescriptionReturn
        public static List<vPharmacyPrescriptionReturn> GetvPharmacyPrescriptionReturnList(string filterExpression)
        {
            List<vPharmacyPrescriptionReturn> result = new List<vPharmacyPrescriptionReturn>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyPrescriptionReturn));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyPrescriptionReturn)helper.IDataReaderToObject(reader, new vPharmacyPrescriptionReturn()));
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
        #region vPharmacyPrescriptionSales
        public static List<vPharmacyPrescriptionSales> GetvPharmacyPrescriptionSalesList(string filterExpression)
        {
            List<vPharmacyPrescriptionSales> result = new List<vPharmacyPrescriptionSales>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyPrescriptionSales));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyPrescriptionSales)helper.IDataReaderToObject(reader, new vPharmacyPrescriptionSales()));
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
        #region vPharmacyPurchaseOrder
        public static List<vPharmacyPurchaseOrder> GetvPharmacyPurchaseOrderList(string filterExpression)
        {
            List<vPharmacyPurchaseOrder> result = new List<vPharmacyPurchaseOrder>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyPurchaseOrder));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyPurchaseOrder)helper.IDataReaderToObject(reader, new vPharmacyPurchaseOrder()));
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
        #region vPharmacyPurchaseOrderReceived
        public static List<vPharmacyPurchaseOrderReceived> GetvPharmacyPurchaseOrderReceivedList(string filterExpression)
        {
            List<vPharmacyPurchaseOrderReceived> result = new List<vPharmacyPurchaseOrderReceived>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyPurchaseOrderReceived));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyPurchaseOrderReceived)helper.IDataReaderToObject(reader, new vPharmacyPurchaseOrderReceived()));
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
        #region vPharmacyPurchaseReceive
        public static List<vPharmacyPurchaseReceive> GetvPharmacyPurchaseReceiveList(string filterExpression)
        {
            List<vPharmacyPurchaseReceive> result = new List<vPharmacyPurchaseReceive>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyPurchaseReceive));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyPurchaseReceive)helper.IDataReaderToObject(reader, new vPharmacyPurchaseReceive()));
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
        #region vPharmacyPurchaseRequest
        public static List<vPharmacyPurchaseRequest> GetvPharmacyPurchaseRequestList(string filterExpression)
        {
            List<vPharmacyPurchaseRequest> result = new List<vPharmacyPurchaseRequest>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyPurchaseRequest));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyPurchaseRequest)helper.IDataReaderToObject(reader, new vPharmacyPurchaseRequest()));
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
        #region vPharmacyPurchaseReturn
        public static List<vPharmacyPurchaseReturn> GetvPharmacyPurchaseReturnList(string filterExpression)
        {
            List<vPharmacyPurchaseReturn> result = new List<vPharmacyPurchaseReturn>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyPurchaseReturn));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyPurchaseReturn)helper.IDataReaderToObject(reader, new vPharmacyPurchaseReturn()));
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
        #region vPharmacyRevenue
        public static List<vPharmacyRevenue> GetvPharmacyRevenueList(string filterExpression)
        {
            List<vPharmacyRevenue> result = new List<vPharmacyRevenue>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyRevenue));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyRevenue)helper.IDataReaderToObject(reader, new vPharmacyRevenue()));
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
        #region vPharmacyStockInitialization
        public static List<vPharmacyStockInitialization> GetvPharmacyStockInitializationList(string filterExpression)
        {
            List<vPharmacyStockInitialization> result = new List<vPharmacyStockInitialization>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyStockInitialization));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyStockInitialization)helper.IDataReaderToObject(reader, new vPharmacyStockInitialization()));
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
        #region vPharmacyStockOpnameResult
        public static List<vPharmacyStockOpnameResult> GetvPharmacyStockOpnameResultList(string filterExpression)
        {
            List<vPharmacyStockOpnameResult> result = new List<vPharmacyStockOpnameResult>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPharmacyStockOpnameResult));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPharmacyStockOpnameResult)helper.IDataReaderToObject(reader, new vPharmacyStockOpnameResult()));
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
        #region vPhysicianSchedule
        public static List<vPhysicianSchedule> GetvPhysicianScheduleList(string filterExpression)
        {
            List<vPhysicianSchedule> result = new List<vPhysicianSchedule>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vPhysicianSchedule));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vPhysicianSchedule)helper.IDataReaderToObject(reader, new vPhysicianSchedule()));
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
        #region vReferral
        public static List<vReferral> GetvReferralList(string filterExpression)
        {
            List<vReferral> result = new List<vReferral>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vReferral));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vReferral)helper.IDataReaderToObject(reader, new vReferral()));
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
        #region vRegistrationIGD
        public static List<vRegistrationIGD> GetvRegistrationIGDList(string filterExpression)
        {
            List<vRegistrationIGD> result = new List<vRegistrationIGD>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vRegistrationIGD));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vRegistrationIGD)helper.IDataReaderToObject(reader, new vRegistrationIGD()));
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
        #region vRegistrationMCU
        public static List<vRegistrationMCU> GetvRegistrationMCUList(string filterExpression)
        {
            List<vRegistrationMCU> result = new List<vRegistrationMCU>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vRegistrationMCU));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vRegistrationMCU)helper.IDataReaderToObject(reader, new vRegistrationMCU()));
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
        #region vRegistrationMD
        public static List<vRegistrationMD> GetvRegistrationMDList(string filterExpression)
        {
            List<vRegistrationMD> result = new List<vRegistrationMD>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vRegistrationMD));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vRegistrationMD)helper.IDataReaderToObject(reader, new vRegistrationMD()));
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
        #region vRegistrationPatientAll
        public static List<vRegistrationPatientAll> GetvRegistrationPatientAllList(string filterExpression)
        {
            List<vRegistrationPatientAll> result = new List<vRegistrationPatientAll>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vRegistrationPatientAll));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vRegistrationPatientAll)helper.IDataReaderToObject(reader, new vRegistrationPatientAll()));
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
        #region vRegistrationRI
        public static List<vRegistrationRI> GetvRegistrationRIList(string filterExpression)
        {
            List<vRegistrationRI> result = new List<vRegistrationRI>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vRegistrationRI));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vRegistrationRI)helper.IDataReaderToObject(reader, new vRegistrationRI()));
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
        #region vRegistrationRJ
        public static List<vRegistrationRJ> GetvRegistrationRJList(string filterExpression)
        {
            List<vRegistrationRJ> result = new List<vRegistrationRJ>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vRegistrationRJ));
                string commandText = string.Format("{0} {1}", helper.Select(filterExpression), " ORDER BY ServiceUnitCode,RegistrationDate,RegistrationTime");
                ctx.CommandText = commandText;
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vRegistrationRJ)helper.IDataReaderToObject(reader, new vRegistrationRJ()));
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
        #region vRekapAnestesiIGD
        public static List<vRekapAnestesiIGD> GetvRekapAnestesiIGDList(string filterExpression)
        {
            List<vRekapAnestesiIGD> result = new List<vRekapAnestesiIGD>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vRekapAnestesiIGD));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vRekapAnestesiIGD)helper.IDataReaderToObject(reader, new vRekapAnestesiIGD()));
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
        #region vRekapKunjunganIGD
        public static List<vRekapKunjunganIGD> GetvRekapKunjunganIGDList(string filterExpression)
        {
            List<vRekapKunjunganIGD> result = new List<vRekapKunjunganIGD>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vRekapKunjunganIGD));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vRekapKunjunganIGD)helper.IDataReaderToObject(reader, new vRekapKunjunganIGD()));
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
        #region vSupplier
        public static List<vSupplier> GetvSupplierList(string filterExpression)
        {
            List<vSupplier> result = new List<vSupplier>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vSupplier));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vSupplier)helper.IDataReaderToObject(reader, new vSupplier()));
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
        #region vSupplierItemMatrix
        public static List<vSupplierItemMatrix> GetvSupplierItemMatrixList(string filterExpression)
        {
            List<vSupplierItemMatrix> result = new List<vSupplierItemMatrix>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vSupplierItemMatrix));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vSupplierItemMatrix)helper.IDataReaderToObject(reader, new vSupplierItemMatrix()));
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
        #region vTariff
        public static List<vTariff> GetvTariffList(string filterExpression)
        {
            List<vTariff> result = new List<vTariff>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vTariff));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vTariff)helper.IDataReaderToObject(reader, new vTariff()));
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
        #region vTestAndResultMD
        public static List<vTestAndResultMD> GetvTestAndResultMDList(string filterExpression)
        {
            List<vTestAndResultMD> result = new List<vTestAndResultMD>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vTestAndResultMD));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vTestAndResultMD)helper.IDataReaderToObject(reader, new vTestAndResultMD()));
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
        #region vUser
        public static List<vUser> GetvUserList(string filterExpression)
        {
            List<vUser> result = new List<vUser>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vUser));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vUser)helper.IDataReaderToObject(reader, new vUser()));
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
        #region vWaitingListRI
        public static List<vWaitingListRI> GetvWaitingListRIList(string filterExpression)
        {
            List<vWaitingListRI> result = new List<vWaitingListRI>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vWaitingListRI));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vWaitingListRI)helper.IDataReaderToObject(reader, new vWaitingListRI()));
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
        #region vWard
        public static List<vWard> GetvWardList(string filterExpression)
        {
            List<vWard> result = new List<vWard>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vWard));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vWard)helper.IDataReaderToObject(reader, new vWard()));
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
        #region vWarehouseLocation
        public static List<vWarehouseLocation> GetvWarehouseLocationList(string filterExpression)
        {
            List<vWarehouseLocation> result = new List<vWarehouseLocation>();
            IDbContext ctx = DbFactory.Configure();
            try
            {
                DbHelper helper = new DbHelper(typeof(vWarehouseLocation));
                ctx.CommandText = helper.Select(filterExpression);
                using (IDataReader reader = DaoBase.GetDataReader(ctx))
                    while (reader.Read())
                        result.Add((vWarehouseLocation)helper.IDataReaderToObject(reader, new vWarehouseLocation()));
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
    }
}
