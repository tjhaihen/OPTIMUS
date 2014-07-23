using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raven.OPTIMUS.Data.Service
{
    #region spPharmacyStockCard
    public partial class spPharmacyStockCard
    {
        public Decimal TransactionValue
        {
            get
            {
                if (QtyIn > 0)
                    return StockPrice * QtyIn;
                else
                    return StockPrice * QtyOut;
            }
        }
    }
    #endregion
    #region spSensusRIPerBulanPerKelas
    public partial class spSensusRIPerBulanPerKelas
    {
        public Int32 NumberOfDeathPatient
        { get { return NumberOfLessThan48HourDeath + NumberOfMoreThan48HourDeath; } }

        public Int32 NumberOfPatientOut
        { get { return NumberOfDeathPatient + NumberOfPatientOutAlive; } }

        public Int32 BedTimesDaysOfMonth
        { get { return NumberOfBed * DaysOfMonth; } }

        public String BedOccupancyRate
        {
            get 
            {
                try
                {
                    return (Convert.ToDecimal(NumberOfDayCare) * 100 / Convert.ToDecimal(BedTimesDaysOfMonth)).ToString("0.##");
                }
                catch
                {
                    return 0.ToString("0.##");
                }
            } 
        }

        public String AverageLengthOfStay
        { 
            get 
            {
                try
                {
                    return (Convert.ToDecimal(LengthOfStay) / Convert.ToDecimal(NumberOfPatientOut)).ToString("0.##"); 
                    }
                catch
                {
                    return 0.ToString("0.##");
                }
            } 
        }

        public String BedTurnOver
        { 
            get 
            {
                try
                {
                    return (Convert.ToDecimal(NumberOfPatientOut) / Convert.ToDecimal(NumberOfBed)).ToString("0.##"); 
                    }
                catch
                {
                    return 0.ToString("0.##");
                }
            } 
        }

        public String TurnOverInterval
        { 
            get 
            {
                try
                {
                    return (Convert.ToDecimal(BedTimesDaysOfMonth - NumberOfDayCare) / Convert.ToDecimal(NumberOfPatientOut)).ToString("0.##");
                    }
                catch
                {
                    return 0.ToString("0.##");
                }
            } 
        }

        public String NetDeathRate
        { 
            get 
            {
                try
                {
                    return (Convert.ToDecimal(NumberOfMoreThan48HourDeath) * 1000 / Convert.ToDecimal(NumberOfPatientOut)).ToString("0.##");
                    }
                catch
                {
                    return 0.ToString("0.##");
                }
            } 
        }

        public String GrossDeathRate
        { 
            get 
            {
                try
                {
                    return (Convert.ToDecimal(NumberOfDeathPatient) * 1000 / Convert.ToDecimal(NumberOfPatientOut)).ToString("0.##");
                    }
                catch
                {
                    return 0.ToString("0.##");
                }
            } 
        }
    }
    #endregion
    #region spSensusRIPerBulanPerRuang
    public partial class spSensusRIPerBulanPerRuang
    {
        public Int32 NumberOfDeathPatient
        { get { return NumberOfLessThan48HourDeath + NumberOfMoreThan48HourDeath; } }

        public Int32 NumberOfPatientOut
        { get { return NumberOfDeathPatient + NumberOfPatientOutAlive; } }

        public Int32 BedTimesDaysOfMonth
        { get { return NumberOfBed * DaysOfMonth; } }

        public String BedOccupancyRate
        { 
            get 
            {
                try
                {
                    return (Convert.ToDecimal(NumberOfDayCare) * 100 / Convert.ToDecimal(BedTimesDaysOfMonth)).ToString("0.##");
                    }
                catch
                {
                    return 0.ToString("0.##");
                }
            } 
        }

        public String AverageLengthOfStay
        {
            get 
            {
                try
                {
                    return (Convert.ToDecimal(LengthOfStay) / Convert.ToDecimal(NumberOfPatientOut)).ToString("0.##"); 
                    }
                catch
                {
                    return 0.ToString("0.##");
                }
            } 
        }

        public String BedTurnOver
        {
            get 
            {
                try
                {
                    return (Convert.ToDecimal(NumberOfPatientOut) / Convert.ToDecimal(NumberOfBed)).ToString("0.##"); 
                    }
                catch
                {
                    return 0.ToString("0.##");
                }
            } 
        }

        public String TurnOverInterval
        {
            get 
            {
                try
                {
                    return (Convert.ToDecimal(BedTimesDaysOfMonth - NumberOfDayCare) / Convert.ToDecimal(NumberOfPatientOut)).ToString("0.##");
                    }
                catch
                {
                    return 0.ToString("0.##");
                }
            } 
        }

        public String NetDeathRate
        {
            get 
            {
                try
                {
                    return (Convert.ToDecimal(NumberOfMoreThan48HourDeath) * 1000 / Convert.ToDecimal(NumberOfPatientOut)).ToString("0.##");
                    }
                catch
                {
                    return 0.ToString("0.##");
                }
            } 
        }

        public String GrossDeathRate
        {
            get 
            {
                try
                {
                    return (Convert.ToDecimal(NumberOfDeathPatient) * 1000 / Convert.ToDecimal(NumberOfPatientOut)).ToString("0.##");
                }
                catch
                {
                    return 0.ToString("0.##");
                }
            }
        }
    }
    #endregion
    #region spSensusRIPerTahunPerKelas
    public partial class spSensusRIPerTahunPerKelas
    {
        public String AvgBOR
        {
            get
            {
                return ((January + February + March + April + May + June + July + August + September + October + November + December) / 12).ToString("0.##");
            }
        }
    }
    #endregion
    #region spSensusRIPerTahunPerRuang
    public partial class spSensusRIPerTahunPerRuang
    {
        public String AvgBOR
        {
            get
            {
                return ((January + February + March + April + May + June + July + August + September + October + November + December) / 12).ToString("0.##");
            }
        }
    }
    #endregion

}
