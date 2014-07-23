using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Data.Core.Dal;

namespace Raven.OPTIMUS.Data.Service
{
    #region spPharmacyItemBalanceByWarehouseByLocation
    [Serializable]
    public partial class spPharmacyItemBalanceByWarehouseByLocation
    {
        private DateTime _SelectedDate;
        private String _ItemCode;
        private String _ItemName;
        private String _ProductLine;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private Decimal _QtyBalance;
        private String _Unit;
        private Decimal _StockPrice;

        [Column(Name = "SelectedDate", DataType = "DateTime")]
        public DateTime SelectedDate
        {
            get { return _SelectedDate; }
            set { _SelectedDate = value; }
        }

        [Column(Name = "ItemCode", DataType = "String")]
        public String ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; }
        }

        [Column(Name = "ItemName", DataType = "String")]
        public String ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }

        [Column(Name = "ProductLine", DataType = "String")]
        public String ProductLine
        {
            get { return _ProductLine; }
            set { _ProductLine = value; }
        }

        [Column(Name = "WarehouseCode", DataType = "String")]
        public String WarehouseCode
        {
            get { return _WarehouseCode; }
            set { _WarehouseCode = value; }
        }

        [Column(Name = "WarehouseName", DataType = "String")]
        public String WarehouseName
        {
            get { return _WarehouseName; }
            set { _WarehouseName = value; }
        }

        [Column(Name = "LocationCode", DataType = "String")]
        public String LocationCode
        {
            get { return _LocationCode; }
            set { _LocationCode = value; }
        }

        [Column(Name = "LocationName", DataType = "String")]
        public String LocationName
        {
            get { return _LocationName; }
            set { _LocationName = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "QtyBalance", DataType = "Double")]
        public Decimal QtyBalance
        {
            get { return _QtyBalance; }
            set { _QtyBalance = value; }
        }

        [Column(Name = "StockPrice", DataType = "Decimal")]
        public Decimal StockPrice
        {
            get { return _StockPrice; }
            set { _StockPrice = value; }
        }
    }
    #endregion
    #region spPharmacyStockCard
    [Serializable]
    public partial class spPharmacyStockCard
    {
        private DateTime _StartDate;
        private DateTime _EndDate;
        private String _WarehouseFilter;
        private String _LocationFilter;
        private String _ItemCode;
        private String _ItemName;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private String _TransactionDescription;
        private String _Unit;
        private Decimal _QtyStart;
        private Decimal _QtyIn;
        private Decimal _QtyOut;
        private Decimal _QtyEnd;
        private String _DetailDesc;
        private Decimal _StockPrice;
        private DateTime _ApprovalDate;
        private String _ApprovalUser;
        private String _TransactionNo;
        private DateTime _TransactionDate;

        [Column(Name = "StartDate", DataType = "DateTime")]
        public DateTime StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }

        [Column(Name = "EndDate", DataType = "DateTime")]
        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }

        [Column(Name = "WarehouseFilter", DataType = "String")]
        public String WarehouseFilter
        {
            get { return _WarehouseFilter; }
            set { _WarehouseFilter = value; }
        }

        [Column(Name = "LocationFilter", DataType = "String")]
        public String LocationFilter
        {
            get { return _LocationFilter; }
            set { _LocationFilter = value; }
        }

        [Column(Name = "ItemCode", DataType = "String")]
        public String ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; }
        }

        [Column(Name = "ItemName", DataType = "String")]
        public String ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }

        [Column(Name = "WarehouseCode", DataType = "String")]
        public String WarehouseCode
        {
            get { return _WarehouseCode; }
            set { _WarehouseCode = value; }
        }

        [Column(Name = "WarehouseName", DataType = "String")]
        public String WarehouseName
        {
            get { return _WarehouseName; }
            set { _WarehouseName = value; }
        }

        [Column(Name = "LocationCode", DataType = "String")]
        public String LocationCode
        {
            get { return _LocationCode; }
            set { _LocationCode = value; }
        }

        [Column(Name = "LocationName", DataType = "String")]
        public String LocationName
        {
            get { return _LocationName; }
            set { _LocationName = value; }
        }

        [Column(Name = "TransactionDescription", DataType = "String")]
        public String TransactionDescription
        {
            get { return _TransactionDescription; }
            set { _TransactionDescription = value; }
        }

        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }

        [Column(Name = "QtyStart", DataType = "Decimal")]
        public Decimal QtyStart
        {
            get { return _QtyStart; }
            set { _QtyStart = value; }
        }

        [Column(Name = "QtyIn", DataType = "Decimal")]
        public Decimal QtyIn
        {
            get { return _QtyIn; }
            set { _QtyIn = value; }
        }

        [Column(Name = "QtyOut", DataType = "Decimal")]
        public Decimal QtyOut
        {
            get { return _QtyOut; }
            set { _QtyOut = value; }
        }

        [Column(Name = "QtyEnd", DataType = "Decimal")]
        public Decimal QtyEnd
        {
            get { return _QtyEnd; }
            set { _QtyEnd = value; }
        }

        [Column(Name = "DetailDesc", DataType = "String")]
        public String DetailDesc
        {
            get { return _DetailDesc; }
            set { _DetailDesc = value; }
        }

        [Column(Name = "StockPrice", DataType = "Decimal")]
        public Decimal StockPrice
        {
            get { return _StockPrice; }
            set { _StockPrice = value; }
        }

        [Column(Name = "ApprovalDate", DataType = "DateTime")]
        public DateTime ApprovalDate
        {
            get { return _ApprovalDate; }
            set { _ApprovalDate = value; }
        }

        [Column(Name = "ApprovalUser", DataType = "String")]
        public String ApprovalUser
        {
            get { return _ApprovalUser; }
            set { _ApprovalUser = value; }
        }

        [Column(Name = "TransactionNo", DataType = "String")]
        public String TransactionNo
        {
            get { return _TransactionNo; }
            set { _TransactionNo = value; }
        }

        [Column(Name = "TransactionDate", DataType = "DateTime")]
        public DateTime TransactionDate
        {
            get { return _TransactionDate; }
            set { _TransactionDate = value; }
        }
    }
    #endregion
    #region spSensusRIPerBulanPerKelas
    [Serializable]
    public partial class spSensusRIPerBulanPerKelas
    {
        private String _Year;
        private String _Month;
        private String _ClassCode;
        private String _ClassName;
        private Int32 _NumberOfBed;
        private Int32 _NumberOfPatient;
        private Int32 _NumberOfPatientOutAlive;
        private Int32 _NumberOfLessThan48HourDeath;
        private Int32 _NumberOfMoreThan48HourDeath;
        private Int32 _NumberOfDayCare;
        private Int32 _LengthOfStay;
        private Int32 _DaysOfMonth;

        [Column(Name = "Year", DataType = "String")]
        public String Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        [Column(Name = "Month", DataType = "String")]
        public String Month
        {
            get { return _Month; }
            set { _Month = value; }
        }
        [Column(Name = "ClassCode", DataType = "String")]
        public String ClassCode
        {
            get { return _ClassCode; }
            set { _ClassCode = value; }
        }
        [Column(Name = "ClassName", DataType = "String")]
        public String ClassName
        {
            get { return _ClassName; }
            set { _ClassName = value; }
        }
        [Column(Name = "NumberOfBed", DataType = "Int32")]
        public Int32 NumberOfBed
        {
            get { return _NumberOfBed; }
            set { _NumberOfBed = value; }
        }
        [Column(Name = "NumberOfPatient", DataType = "Int32")]
        public Int32 NumberOfPatient
        {
            get { return _NumberOfPatient; }
            set { _NumberOfPatient = value; }
        }
        [Column(Name = "NumberOfPatientOutAlive", DataType = "Int32")]
        public Int32 NumberOfPatientOutAlive
        {
            get { return _NumberOfPatientOutAlive; }
            set { _NumberOfPatientOutAlive = value; }
        }
        [Column(Name = "NumberOfLessThan48HourDeath", DataType = "Int32")]
        public Int32 NumberOfLessThan48HourDeath
        {
            get { return _NumberOfLessThan48HourDeath; }
            set { _NumberOfLessThan48HourDeath = value; }
        }
        [Column(Name = "NumberOfMoreThan48HourDeath", DataType = "Int32")]
        public Int32 NumberOfMoreThan48HourDeath
        {
            get { return _NumberOfMoreThan48HourDeath; }
            set { _NumberOfMoreThan48HourDeath = value; }
        }
        [Column(Name = "NumberOfDayCare", DataType = "Int32")]
        public Int32 NumberOfDayCare
        {
            get { return _NumberOfDayCare; }
            set { _NumberOfDayCare = value; }
        }
        [Column(Name = "LengthOfStay", DataType = "Int32")]
        public Int32 LengthOfStay
        {
            get { return _LengthOfStay; }
            set { _LengthOfStay = value; }
        }
        [Column(Name = "DaysOfMonth", DataType = "Int32")]
        public Int32 DaysOfMonth
        {
            get { return _DaysOfMonth; }
            set { _DaysOfMonth = value; }
        }
    }
    #endregion
    #region spSensusRIPerBulanPerRuang
    [Serializable]
    public partial class spSensusRIPerBulanPerRuang
    {
        private String _Year;
        private String _Month;
        private String _RoomCode;
        private String _RoomName;
        private Int32 _NumberOfBed;
        private Int32 _NumberOfPatient;
        private Int32 _NumberOfPatientOutAlive;
        private Int32 _NumberOfLessThan48HourDeath;
        private Int32 _NumberOfMoreThan48HourDeath;
        private Int32 _NumberOfDayCare;
        private Int32 _LengthOfStay;
        private Int32 _DaysOfMonth;

        [Column(Name = "Year", DataType = "String")]
        public String Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        [Column(Name = "Month", DataType = "String")]
        public String Month
        {
            get { return _Month; }
            set { _Month = value; }
        }
        [Column(Name = "RoomCode", DataType = "String")]
        public String RoomCode
        {
            get { return _RoomCode; }
            set { _RoomCode = value; }
        }
        [Column(Name = "RoomName", DataType = "String")]
        public String RoomName
        {
            get { return _RoomName; }
            set { _RoomName = value; }
        }
        [Column(Name = "NumberOfBed", DataType = "Int32")]
        public Int32 NumberOfBed
        {
            get { return _NumberOfBed; }
            set { _NumberOfBed = value; }
        }
        [Column(Name = "NumberOfPatient", DataType = "Int32")]
        public Int32 NumberOfPatient
        {
            get { return _NumberOfPatient; }
            set { _NumberOfPatient = value; }
        }
        [Column(Name = "NumberOfPatientOutAlive", DataType = "Int32")]
        public Int32 NumberOfPatientOutAlive
        {
            get { return _NumberOfPatientOutAlive; }
            set { _NumberOfPatientOutAlive = value; }
        }
        [Column(Name = "NumberOfLessThan48HourDeath", DataType = "Int32")]
        public Int32 NumberOfLessThan48HourDeath
        {
            get { return _NumberOfLessThan48HourDeath; }
            set { _NumberOfLessThan48HourDeath = value; }
        }
        [Column(Name = "NumberOfMoreThan48HourDeath", DataType = "Int32")]
        public Int32 NumberOfMoreThan48HourDeath
        {
            get { return _NumberOfMoreThan48HourDeath; }
            set { _NumberOfMoreThan48HourDeath = value; }
        }
        [Column(Name = "NumberOfDayCare", DataType = "Int32")]
        public Int32 NumberOfDayCare
        {
            get { return _NumberOfDayCare; }
            set { _NumberOfDayCare = value; }
        }
        [Column(Name = "LengthOfStay", DataType = "Int32")]
        public Int32 LengthOfStay
        {
            get { return _LengthOfStay; }
            set { _LengthOfStay = value; }
        }
        [Column(Name = "DaysOfMonth", DataType = "Int32")]
        public Int32 DaysOfMonth
        {
            get { return _DaysOfMonth; }
            set { _DaysOfMonth = value; }
        }
    }
    #endregion
    #region spSensusRIPerTahunPerKelas
    [Serializable]
    public partial class spSensusRIPerTahunPerKelas
    {
        private String _Year;
        private String _ClassCode;
        private String _ClassName;
        private Decimal _January;
        private Decimal _February;
        private Decimal _March;
        private Decimal _April;
        private Decimal _May;
        private Decimal _June;
        private Decimal _July;
        private Decimal _August;
        private Decimal _September;
        private Decimal _October;
        private Decimal _November;
        private Decimal _December;

        [Column(Name = "Year", DataType = "String")]
        public String Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        [Column(Name = "ClassCode", DataType = "String")]
        public String ClassCode
        {
            get { return _ClassCode; }
            set { _ClassCode = value; }
        }
        [Column(Name = "ClassName", DataType = "String")]
        public String ClassName
        {
            get { return _ClassName; }
            set { _ClassName = value; }
        }
        [Column(Name = "January", DataType = "Decimal")]
        public Decimal January
        {
            get { return _January; }
            set { _January = value; }
        }
        [Column(Name = "February", DataType = "Decimal")]
        public Decimal February
        {
            get { return _February; }
            set { _February = value; }
        }
        [Column(Name = "March", DataType = "Decimal")]
        public Decimal March
        {
            get { return _March; }
            set { _March = value; }
        }
        [Column(Name = "April", DataType = "Decimal")]
        public Decimal April
        {
            get { return _April; }
            set { _April = value; }
        }
        [Column(Name = "May", DataType = "Decimal")]
        public Decimal May
        {
            get { return _May; }
            set { _May = value; }
        }
        [Column(Name = "June", DataType = "Decimal")]
        public Decimal June
        {
            get { return _June; }
            set { _June = value; }
        }
        [Column(Name = "July", DataType = "Decimal")]
        public Decimal July
        {
            get { return _July; }
            set { _July = value; }
        }
        [Column(Name = "August", DataType = "Decimal")]
        public Decimal August
        {
            get { return _August; }
            set { _August = value; }
        }
        [Column(Name = "September", DataType = "Decimal")]
        public Decimal September
        {
            get { return _September; }
            set { _September = value; }
        }
        [Column(Name = "October", DataType = "Decimal")]
        public Decimal October
        {
            get { return _October; }
            set { _October = value; }
        }
        [Column(Name = "November", DataType = "Decimal")]
        public Decimal November
        {
            get { return _November; }
            set { _November = value; }
        }
        [Column(Name = "December", DataType = "Decimal")]
        public Decimal December
        {
            get { return _December; }
            set { _December = value; }
        }
    }
    #endregion
    #region spSensusRIPerTahunPerRuang
    [Serializable]
    public partial class spSensusRIPerTahunPerRuang
    {
        private String _Year;
        private String _RoomCode;
        private String _RoomName;
        private Decimal _January;
        private Decimal _February;
        private Decimal _March;
        private Decimal _April;
        private Decimal _May;
        private Decimal _June;
        private Decimal _July;
        private Decimal _August;
        private Decimal _September;
        private Decimal _October;
        private Decimal _November;
        private Decimal _December;

        [Column(Name = "Year", DataType = "String")]
        public String Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        [Column(Name = "RoomCode", DataType = "String")]
        public String RoomCode
        {
            get { return _RoomCode; }
            set { _RoomCode = value; }
        }
        [Column(Name = "RoomName", DataType = "String")]
        public String RoomName
        {
            get { return _RoomName; }
            set { _RoomName = value; }
        }
        [Column(Name = "January", DataType = "Decimal")]
        public Decimal January
        {
            get { return _January; }
            set { _January = value; }
        }
        [Column(Name = "February", DataType = "Decimal")]
        public Decimal February
        {
            get { return _February; }
            set { _February = value; }
        }
        [Column(Name = "March", DataType = "Decimal")]
        public Decimal March
        {
            get { return _March; }
            set { _March = value; }
        }
        [Column(Name = "April", DataType = "Decimal")]
        public Decimal April
        {
            get { return _April; }
            set { _April = value; }
        }
        [Column(Name = "May", DataType = "Decimal")]
        public Decimal May
        {
            get { return _May; }
            set { _May = value; }
        }
        [Column(Name = "June", DataType = "Decimal")]
        public Decimal June
        {
            get { return _June; }
            set { _June = value; }
        }
        [Column(Name = "July", DataType = "Decimal")]
        public Decimal July
        {
            get { return _July; }
            set { _July = value; }
        }
        [Column(Name = "August", DataType = "Decimal")]
        public Decimal August
        {
            get { return _August; }
            set { _August = value; }
        }
        [Column(Name = "September", DataType = "Decimal")]
        public Decimal September
        {
            get { return _September; }
            set { _September = value; }
        }
        [Column(Name = "October", DataType = "Decimal")]
        public Decimal October
        {
            get { return _October; }
            set { _October = value; }
        }
        [Column(Name = "November", DataType = "Decimal")]
        public Decimal November
        {
            get { return _November; }
            set { _November = value; }
        }
        [Column(Name = "December", DataType = "Decimal")]
        public Decimal December
        {
            get { return _December; }
            set { _December = value; }
        }
    }
    #endregion

}
