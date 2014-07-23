using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Common;

namespace Raven.OPTIMUS.Data.Service
{
    #region vInpatientDetailRegistration
    public partial class vInpatientDetailRegistration
    {
        public String DischargeDateForReport
        {
            get
            {
                if (_DischargeDate.ToString(Constant.ConstantDate.DEFAULT_FORMAT) != Constant.ConstantDate.DEFAULT_NULL)
                    return _DischargeDate.ToString("dd-MMM-yy");
                else
                    return String.Empty;
            }
        }

        public Int32 AgeInDaysByRegistrationDate
        {
            get
            {
                int aintNoOfDays = RegistrationDate.Day - DateOfBirth.Day;
                int aintNoOfMonths = RegistrationDate.Month - DateOfBirth.Month;
                int aintNoOfYears = RegistrationDate.Year - DateOfBirth.Year;

                if (aintNoOfDays < 0)
                {
                    if (DateOfBirth.Day < RegistrationDate.AddDays(-RegistrationDate.Day).Day)
                        aintNoOfDays += RegistrationDate.AddDays(-RegistrationDate.Day).Day;
                    else
                        aintNoOfDays += DateOfBirth.Day;
                }
                return aintNoOfDays;
            }
        }

        public Int32 AgeInMonthsByRegistrationDate
        {
            get
            {
                int aintNoOfDays = RegistrationDate.Day - DateOfBirth.Day;
                int aintNoOfMonths = RegistrationDate.Month - DateOfBirth.Month;
                int aintNoOfYears = RegistrationDate.Year - DateOfBirth.Year;

                if (aintNoOfDays < 0)
                {
                    if (DateOfBirth.Day < RegistrationDate.AddDays(-RegistrationDate.Day).Day)
                        aintNoOfDays += RegistrationDate.AddDays(-RegistrationDate.Day).Day;
                    else
                        aintNoOfDays += DateOfBirth.Day;
                    aintNoOfMonths--;
                }

                if (aintNoOfMonths < 0)
                {
                    aintNoOfMonths += 12;
                    aintNoOfYears--;
                }
                return aintNoOfMonths;
            }
        }

        public Int32 AgeInYearsByRegistrationDate
        {
            get
            {
                int aintNoOfDays = RegistrationDate.Day - DateOfBirth.Day;
                int aintNoOfMonths = RegistrationDate.Month - DateOfBirth.Month;
                int aintNoOfYears = RegistrationDate.Year - DateOfBirth.Year;

                if (aintNoOfDays < 0)
                {
                    if (DateOfBirth.Day < RegistrationDate.AddDays(-RegistrationDate.Day).Day)
                        aintNoOfDays += RegistrationDate.AddDays(-RegistrationDate.Day).Day;
                    else
                        aintNoOfDays += DateOfBirth.Day;
                    aintNoOfMonths--;
                }

                if (aintNoOfMonths < 0)
                {
                    aintNoOfMonths += 12;
                    aintNoOfYears--;
                }
                return aintNoOfYears;
            }
        }
    }
    #endregion
    #region vPatientBase
    public partial class vPatientBase
    {
        //public String GenderLabel
        //{
        //    get
        //    {
        //        return _Gender == "L" ? "Laki-Laki" : "Perempuan";
        //    }
        //}

        public Int32 AgeInDays
        {
            get
            {
                int aintNoOfDays = DateTime.Now.Day - DateOfBirth.Day;
                int aintNoOfMonths = DateTime.Now.Month - DateOfBirth.Month;
                int aintNoOfYears = DateTime.Now.Year - DateOfBirth.Year;

                if (aintNoOfDays < 0)
                {
                    if (DateOfBirth.Day < DateTime.Now.AddDays(-DateTime.Now.Day).Day)
                        aintNoOfDays += DateTime.Now.AddDays(-DateTime.Now.Day).Day;
                    else
                        aintNoOfDays += DateOfBirth.Day;
                }
                return aintNoOfDays;
            }
        }

        public Int32 AgeInMonths
        {
            get
            {
                int aintNoOfDays = DateTime.Now.Day - DateOfBirth.Day;
                int aintNoOfMonths = DateTime.Now.Month - DateOfBirth.Month;
                int aintNoOfYears = DateTime.Now.Year - DateOfBirth.Year;

                if (aintNoOfDays < 0)
                {
                    if (DateOfBirth.Day < DateTime.Now.AddDays(-DateTime.Now.Day).Day)
                        aintNoOfDays += DateTime.Now.AddDays(-DateTime.Now.Day).Day;
                    else
                        aintNoOfDays += DateOfBirth.Day;
                    aintNoOfMonths--;
                }

                if (aintNoOfMonths < 0)
                {
                    aintNoOfMonths += 12;
                    aintNoOfYears--;
                }
                return aintNoOfMonths;
            }
        }

        public Int32 AgeInYears
        {
            get
            {
                int aintNoOfDays = DateTime.Now.Day - DateOfBirth.Day;
                int aintNoOfMonths = DateTime.Now.Month - DateOfBirth.Month;
                int aintNoOfYears = DateTime.Now.Year - DateOfBirth.Year;

                if (aintNoOfDays < 0)
                {
                    if (DateOfBirth.Day < DateTime.Now.AddDays(-DateTime.Now.Day).Day)
                        aintNoOfDays += DateTime.Now.AddDays(-DateTime.Now.Day).Day;
                    else
                        aintNoOfDays += DateOfBirth.Day;
                    aintNoOfMonths--;
                }

                if (aintNoOfMonths < 0)
                {
                    aintNoOfMonths += 12;
                    aintNoOfYears--;
                }
                return aintNoOfYears;
            }
        }


    }
    #endregion
    #region vPharmacyDirectPurchase
    public partial class vPharmacyDirectPurchase
    {
        public Decimal ItemTotalValue
        {
            get
            {
                Decimal subTot = (Convert.ToDecimal(Qty) * Convert.ToDecimal(Price)) - DiscAmount;
                Decimal ppnPc;
                if (IsVAT)
                    ppnPc = Convert.ToDecimal(HeaderVAT);
                else
                    ppnPc = 0;
                subTot -= (ppnPc * subTot) / 100;
                return subTot;
            }
        }

        public Decimal DiscAmount
        {
            get { return Convert.ToDecimal(DiscountPerc) * (Convert.ToDecimal(Qty) * Convert.ToDecimal(Price)) / 100; }
        }
    }
    #endregion
    #region vPharmacyGoodsRequest
    public partial class vPharmacyGoodsRequest
    {
        public String ApprovalDateForReport
        {
            get
            {
                if (_GoodsRequestApprovalDate.ToString(Constant.ConstantDate.DEFAULT_FORMAT) != Constant.ConstantDate.DEFAULT_NULL)
                    return _GoodsRequestApprovalDate.ToString("dd-MMM-yyyy");
                else
                    return String.Empty;
            }
        }
    }
    #endregion
    #region vPharmacyItem
    public partial class vPharmacyItem
    {
        public Decimal HNAPPN
        {
            get { return (100 + Convert.ToDecimal(VAT)) / 100 * BasePrice; }
        }
        public String UnitForReport
        {
            get 
            {
                if (SmallUnit == BigUnit)
                    return SmallUnit;
                else 
                {
                    return BigUnit + " / " + FactorBs + " " + SmallUnit;
                }
            }
        }
    }
    #endregion
    #region vPharmacyItemPriceAdjustment
    public partial class vPharmacyItemPriceAdjustment
    {
        public Decimal AveragePriceDiff
        { get { return Math.Abs(NewAveragePrice - AveragePrice); } }

        public Decimal BaseUnitPriceDiff
        { get { return Math.Abs(NewBaseUnitPrice - BaseUnitPrice); } }

        public Decimal AlternateUnitPriceDiff
        { get { return Math.Abs(NewAlternateUnitPrice - AlternateUnitPrice); } }

        public String AveragePriceDiffPercentage
        {
            get
            {
                if (AveragePrice > 0)
                    return (AveragePriceDiff / AveragePrice * 100).ToString("0.##");
                else
                    return 0.ToString("0.##");
            }
        }

        public String BaseUnitPriceDiffPercentage
        {
            get
            {
                if (BaseUnitPrice > 0)
                    return (BaseUnitPriceDiff / BaseUnitPrice * 100).ToString("0.##");
                else
                    return 0.ToString("0.##");
            }
        }

        public String AlternateUnitPriceDiffPercentage
        {
            get
            {
                if (AlternateUnitPrice > 0)
                    return (AlternateUnitPriceDiff / AlternateUnitPrice * 100).ToString("0.##");
                else
                    return 0.ToString("0.##");
            }
        }
    }
    #endregion
    #region vPharmacyPurchaseOrder
    public partial class vPharmacyPurchaseOrder
    {
        public Decimal TotalPrice
        {
            get
            {
                Decimal prc = Convert.ToDecimal(OrderQty) * Price;
                Decimal disc1 = Convert.ToDecimal(Discount1) * prc / 100;
                Decimal disc2 = Convert.ToDecimal(Discount2) * (prc - disc1) / 100;
                return Math.Round(prc - disc1 - disc2);
            }
        }
    }
    #endregion
    #region vPharmacyPurchaseReceive
    public partial class vPharmacyPurchaseReceive
    {
        public Decimal TotalItemPrice
        {
            get
            {
                return (Convert.ToDecimal(ReceiveQty) * ItemPrice) - ItemDiscount - ItemDiscount2;
            }
        }
    }
    #endregion
    #region vPharmacyPurcaseRequest
    public partial class vPharmacyPurchaseRequest
    {
        public String ItemNameCatalog
        {
            get { return String.Format("{0} / {1}", ItemName, CatalogNo); }
        }

        public String ItemUnitFactor
        {
            get { return String.Format("{0} / {1}", Unit, UnitFactor); }
        }

        public String RequestStatus
        {
            get
            {
                if (IsProcessed)
                    return "Realisasi PO";
                else
                    return "Belum Realisasi";
            }
        }
    }
    #endregion
    #region vPharmacyStockOpnameResult
    public partial class vPharmacyStockOpnameResult
    {
        public Double DifferenceQty
        {
            get { return Math.Abs(Qty - ResultQty); }
        }

        public Decimal DifferenceValue
        {
            get { return Convert.ToDecimal(DifferenceQty * StockPrice); }
        }

        public Decimal StockValue
        {
            get { return Convert.ToDecimal(ResultQty * StockPrice); }
        }
    }
    #endregion
    #region vRegistrationIGD
    public partial class vRegistrationIGD
    {
        public Int32 AgeInDaysByRegistrationDate
        {
            get
            {
                int aintNoOfDays = RegistrationDate.Day - DateOfBirth.Day;
                int aintNoOfMonths = RegistrationDate.Month - DateOfBirth.Month;
                int aintNoOfYears = RegistrationDate.Year - DateOfBirth.Year;

                if (aintNoOfDays < 0)
                {
                    if (DateOfBirth.Day < RegistrationDate.AddDays(-RegistrationDate.Day).Day)
                        aintNoOfDays += RegistrationDate.AddDays(-RegistrationDate.Day).Day;
                    else
                        aintNoOfDays += DateOfBirth.Day;
                }
                return aintNoOfDays;
            }
        }

        public Int32 AgeInMonthsByRegistrationDate
        {
            get
            {
                int aintNoOfDays = RegistrationDate.Day - DateOfBirth.Day;
                int aintNoOfMonths = RegistrationDate.Month - DateOfBirth.Month;
                int aintNoOfYears = RegistrationDate.Year - DateOfBirth.Year;

                if (aintNoOfDays < 0)
                {
                    if (DateOfBirth.Day < RegistrationDate.AddDays(-RegistrationDate.Day).Day)
                        aintNoOfDays += RegistrationDate.AddDays(-RegistrationDate.Day).Day;
                    else
                        aintNoOfDays += DateOfBirth.Day;
                    aintNoOfMonths--;
                }

                if (aintNoOfMonths < 0)
                {
                    aintNoOfMonths += 12;
                    aintNoOfYears--;
                }
                return aintNoOfMonths;
            }
        }

        public Int32 AgeInYearsByRegistrationDate
        {
            get
            {
                int aintNoOfDays = RegistrationDate.Day - DateOfBirth.Day;
                int aintNoOfMonths = RegistrationDate.Month - DateOfBirth.Month;
                int aintNoOfYears = RegistrationDate.Year - DateOfBirth.Year;

                if (aintNoOfDays < 0)
                {
                    if (DateOfBirth.Day < RegistrationDate.AddDays(-RegistrationDate.Day).Day)
                        aintNoOfDays += RegistrationDate.AddDays(-RegistrationDate.Day).Day;
                    else
                        aintNoOfDays += DateOfBirth.Day;
                    aintNoOfMonths--;
                }

                if (aintNoOfMonths < 0)
                {
                    aintNoOfMonths += 12;
                    aintNoOfYears--;
                }
                return aintNoOfYears;
            }
        }

        public String GenderLabel
        {
            get 
            {
                return Gender == "L" ? "Laki-Laki" : "Perempuan";
            }
        }
    }
    #endregion
    #region vRegistrationRI
    public partial class vRegistrationRI
    {   
        public String DischargeDateForReport
        {
            get
            {
                if (_DischargeDate.ToString(Constant.ConstantDate.DEFAULT_FORMAT) != Constant.ConstantDate.DEFAULT_NULL)
                    return _DischargeDate.ToString("dd-MMM-yy");
                else
                    return String.Empty;
            }
        }

        public Int32 AgeInDaysByRegistrationDate
        {
            get
            {
                int aintNoOfDays = RegistrationDate.Day - DateOfBirth.Day;
                int aintNoOfMonths = RegistrationDate.Month - DateOfBirth.Month;
                int aintNoOfYears = RegistrationDate.Year - DateOfBirth.Year;

                if (aintNoOfDays < 0)
                {
                    if (DateOfBirth.Day < RegistrationDate.AddDays(-RegistrationDate.Day).Day)
                        aintNoOfDays += RegistrationDate.AddDays(-RegistrationDate.Day).Day;
                    else
                        aintNoOfDays += DateOfBirth.Day;
                }
                return aintNoOfDays;
            }
        }

        public Int32 AgeInMonthsByRegistrationDate
        {
            get
            {
                int aintNoOfDays = RegistrationDate.Day - DateOfBirth.Day;
                int aintNoOfMonths = RegistrationDate.Month - DateOfBirth.Month;
                int aintNoOfYears = RegistrationDate.Year - DateOfBirth.Year;

                if (aintNoOfDays < 0)
                {
                    if (DateOfBirth.Day < RegistrationDate.AddDays(-RegistrationDate.Day).Day)
                        aintNoOfDays += RegistrationDate.AddDays(-RegistrationDate.Day).Day;
                    else
                        aintNoOfDays += DateOfBirth.Day;
                    aintNoOfMonths--;
                }

                if (aintNoOfMonths < 0)
                {
                    aintNoOfMonths += 12;
                    aintNoOfYears--;
                }
                return aintNoOfMonths;
            }
        }

        public Int32 AgeInYearsByRegistrationDate
        {
            get
            {
                int aintNoOfDays = RegistrationDate.Day - DateOfBirth.Day;
                int aintNoOfMonths = RegistrationDate.Month - DateOfBirth.Month;
                int aintNoOfYears = RegistrationDate.Year - DateOfBirth.Year;

                if (aintNoOfDays < 0)
                {
                    if (DateOfBirth.Day < RegistrationDate.AddDays(-RegistrationDate.Day).Day)
                        aintNoOfDays += RegistrationDate.AddDays(-RegistrationDate.Day).Day;
                    else
                        aintNoOfDays += DateOfBirth.Day;
                    aintNoOfMonths--;
                }

                if (aintNoOfMonths < 0)
                {
                    aintNoOfMonths += 12;
                    aintNoOfYears--;
                }
                return aintNoOfYears;
            }
        }
    }
    #endregion
    #region vRegistrationRJ
    public partial class vRegistrationRJ : vPatientBase
    {
        public Boolean IsNewVisit
        {
            get { return VisitCount == 0; }
        }
    }
    #endregion
    #region vRekapAnestesiIGD
    public partial class vRekapAnestesiIGD
    {
        public Int32 LocalTotal
        { get { return LocalReferenced + LocalNotReferenced; } }

        public Int32 GeneralTotal
        { get { return GeneralReferenced + GeneralNotReferenced; } }

        public Int32 SpinalTotal
        { get { return SpinalReferenced + SpinalNotReferenced; } }
    }
    #endregion
    #region vRekapKunjunganIGD
    public partial class vRekapKunjunganIGD
    {
        public Int32 SurgicalTotal
        { get { return SurgicalReferenced + SurgicalNotReferenced; } }

        public Int32 NonSurgicalTotal
        { get { return NonSurgicalReferenced + NonSurgicalNotReferenced; } }

        public Int32 ObGynTotal
        { get { return ObGynReferenced + ObGynNotReferenced; } }
    }
    #endregion
    #region vTestAndResultMD
    public partial class vTestAndResultMD
    {
        public Decimal Amount
        {
            get
            {
                return PatientAmount + PayerAmount;
            }
        }
        public String AmountText
        {
            get
            {
                return Methods.FormatCurrency(Amount);
            }
        }
        public Decimal TotalAmount
        {
            get
            {
                return Convert.ToDecimal(Quantity) * Amount;
            }
        }
        public String TotalAmountText
        {
            get { return Methods.FormatCurrency(TotalAmount); }
        }
        public String CitoText
        {
            get { return Methods.FormatCurrency(Cito); }
        }
        public String PatientName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }
        public Int16 DebetCount
        {
            get
            {
                if (PayerCode == String.Empty)
                    return 1;
                else
                    return 0;
            }
        }
        public Int16 CreditCount
        {
            get
            {
                if (PayerCode != String.Empty)
                    return 1;
                else
                    return 0;
            }
        }
        public Int16 CitoCount
        {
            get
            {
                if (Cito > 0)
                    return 1;
                else
                    return 0;
            }
        }
        public Int16 ComplicationCount
        {
            get
            {
                if (Complication > 0)
                    return 1;
                else
                    return 0;
            }
        }
        public Int16 MaleCount
        {
            get
            {
                if (Gender == "L")
                    return 1;
                else
                    return 0;
            }
        }
        public Int16 FemaleCount
        {
            get
            {
                if (Gender == "P")
                    return 1;
                else
                    return 0;
            }
        }
    }
    #endregion

}
