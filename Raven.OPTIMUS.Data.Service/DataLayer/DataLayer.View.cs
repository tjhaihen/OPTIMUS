using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Data.Core.Dal;

namespace Raven.OPTIMUS.Data.Service
{
    #region vAppointmentMCU
    [Serializable]
    [Table(Name = "vAppointmentMCU")]
    public class vAppointmentMCU
    {
        private String _AppointmentNo;
        private DateTime _AppointmentDate;
        private String _AppointmentDateText;
        private String _MedicalNo;
        private String _FirstName;
        private String _LastName;
        private String _Gender;
        private DateTime _DateOfBirth;
        private String _Telephone;
        private String _MobilePhone;
        private Boolean _IsVoid;

        [Column(Name = "AppointmentNo", DataType = "String")]
        public String AppointmentNo
        {
            get { return _AppointmentNo; }
            set { _AppointmentNo = value; }
        }
        [Column(Name = "AppointmentDate", DataType = "DateTime")]
        public DateTime AppointmentDate
        {
            get { return _AppointmentDate; }
            set { _AppointmentDate = value; }
        }
        [Column(Name = "AppointmentDateText", DataType = "String")]
        public String AppointmentDateText
        {
            get { return _AppointmentDateText; }
            set { _AppointmentDateText = value; }
        }
        [Column(Name = "MedicalNo", DataType = "String")]
        public String MedicalNo
        {
            get { return _MedicalNo; }
            set { _MedicalNo = value; }
        }
        [Column(Name = "FirstName", DataType = "String")]
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        [Column(Name = "LastName", DataType = "String")]
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        [Column(Name = "Gender", DataType = "String")]
        public String Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        [Column(Name = "DateOfBirth", DataType = "DateTime")]
        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }
        [Column(Name = "Telephone", DataType = "String")]
        public String Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }
        [Column(Name = "MobilePhone", DataType = "String")]
        public String MobilePhone
        {
            get { return _MobilePhone; }
            set { _MobilePhone = value; }
        }
        [Column(Name = "IsVoid", DataType = "Boolean")]
        public Boolean IsVoid
        {
            get { return _IsVoid; }
            set { _IsVoid = value; }
        }
    }
    #endregion
    #region vAppointmentMD
    [Serializable]
    [Table(Name = "vAppointmentMD")]
    public class vAppointmentMD
    {
        private String _AppointmentNo;
        private DateTime _AppointmentDate;
        private String _AppointmentDateText;
        private String _AppointmentTime;
        private String _MedicalNo;
        private String _FirstName;
        private String _LastName;
        private String _Gender;
        private DateTime _DateOfBirth;
        private String _Telephone;
        private String _MobilePhone;
        private String _MedicalDiagnosticUnit;
        private Boolean _IsVoid;

        [Column(Name = "AppointmentNo", DataType = "String")]
        public String AppointmentNo
        {
            get { return _AppointmentNo; }
            set { _AppointmentNo = value; }
        }
        [Column(Name = "AppointmentDate", DataType = "DateTime")]
        public DateTime AppointmentDate
        {
            get { return _AppointmentDate; }
            set { _AppointmentDate = value; }
        }
        [Column(Name = "AppointmentDateText", DataType = "String")]
        public String AppointmentDateText
        {
            get { return _AppointmentDateText; }
            set { _AppointmentDateText = value; }
        }
        [Column(Name = "AppointmentTime", DataType = "String")]
        public String AppointmentTime
        {
            get { return _AppointmentTime; }
            set { _AppointmentTime = value; }
        }
        [Column(Name = "MedicalNo", DataType = "String")]
        public String MedicalNo
        {
            get { return _MedicalNo; }
            set { _MedicalNo = value; }
        }
        [Column(Name = "FirstName", DataType = "String")]
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        [Column(Name = "LastName", DataType = "String")]
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        [Column(Name = "Gender", DataType = "String")]
        public String Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        [Column(Name = "DateOfBirth", DataType = "DateTime")]
        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }
        [Column(Name = "Telephone", DataType = "String")]
        public String Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }
        [Column(Name = "MobilePhone", DataType = "String")]
        public String MobilePhone
        {
            get { return _MobilePhone; }
            set { _MobilePhone = value; }
        }
        [Column(Name = "MedicalDiagnosticUnit", DataType = "String")]
        public String MedicalDiagnosticUnit
        {
            get { return _MedicalDiagnosticUnit; }
            set { _MedicalDiagnosticUnit = value; }
        }
        [Column(Name = "IsVoid", DataType = "Boolean")]
        public Boolean IsVoid
        {
            get { return _IsVoid; }
            set { _IsVoid = value; }
        }
    }
    #endregion
    #region vAppointmentRJ
    [Serializable]
    [Table(Name = "vAppointmentRJ")]
    public class vAppointmentRJ
    {
        private String _AppointmentNo;
        private DateTime _AppointmentDate;
        private String _AppointmentDateText;
        private String _AppointmentTime;
        private String _VisitType;
        private String _MedicalNo;
        private String _FirstName;
        private String _LastName;
        private String _Gender;
        private DateTime _DateOfBirth;
        private String _Telephone;
        private String _MobilePhone;
        private String _DoctorCode;
        private String _DoctorName;
        private String _ServiceUnitCode;
        private String _ServiceUnitName;
        private Boolean _IsVoid;

        [Column(Name = "AppointmentNo", DataType = "String")]
        public String AppointmentNo
        {
            get { return _AppointmentNo; }
            set { _AppointmentNo = value; }
        }
        [Column(Name = "AppointmentDate", DataType = "DateTime")]
        public DateTime AppointmentDate
        {
            get { return _AppointmentDate; }
            set { _AppointmentDate = value; }
        }
        [Column(Name = "AppointmentDateText", DataType = "String")]
        public String AppointmentDateText
        {
            get { return _AppointmentDateText; }
            set { _AppointmentDateText = value; }
        }
        [Column(Name = "AppointmentTime", DataType = "String")]
        public String AppointmentTime
        {
            get { return _AppointmentTime; }
            set { _AppointmentTime = value; }
        }
        [Column(Name = "VisitType", DataType = "String")]
        public String VisitType
        {
            get { return _VisitType; }
            set { _VisitType = value; }
        }
        [Column(Name = "MedicalNo", DataType = "String")]
        public String MedicalNo
        {
            get { return _MedicalNo; }
            set { _MedicalNo = value; }
        }
        [Column(Name = "FirstName", DataType = "String")]
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        [Column(Name = "LastName", DataType = "String")]
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        [Column(Name = "Gender", DataType = "String")]
        public String Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        [Column(Name = "DateOfBirth", DataType = "DateTime")]
        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }
        [Column(Name = "Telephone", DataType = "String")]
        public String Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }
        [Column(Name = "MobilePhone", DataType = "String")]
        public String MobilePhone
        {
            get { return _MobilePhone; }
            set { _MobilePhone = value; }
        }
        [Column(Name = "DoctorCode", DataType = "String")]
        public String DoctorCode
        {
            get { return _DoctorCode; }
            set { _DoctorCode = value; }
        }
        [Column(Name = "DoctorName", DataType = "String")]
        public String DoctorName
        {
            get { return _DoctorName; }
            set { _DoctorName = value; }
        }
        [Column(Name = "ServiceUnitCode", DataType = "String")]
        public String ServiceUnitCode
        {
            get { return _ServiceUnitCode; }
            set { _ServiceUnitCode = value; }
        }
        [Column(Name = "ServiceUnitName", DataType = "String")]
        public String ServiceUnitName
        {
            get { return _ServiceUnitName; }
            set { _ServiceUnitName = value; }
        }
        [Column(Name = "IsVoid", DataType = "Boolean")]
        public Boolean IsVoid
        {
            get { return _IsVoid; }
            set { _IsVoid = value; }
        }
    }
    #endregion
    #region vBadItem
    [Serializable]
    [Table(Name = "vBadItem")]
    public class vBadItem
    {
        private String _ItemCode;
        private String _ItemName;
        private String _SmallUnit;
        private Double _FaktorKc;
        private String _BigUnit;
        private Double _FaktorBs;
        private Decimal _StockPrice;
        private Decimal _BasePrice;
        private Decimal _DistributorPrice;

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
        [Column(Name = "SmallUnit", DataType = "String")]
        public String SmallUnit
        {
            get { return _SmallUnit; }
            set { _SmallUnit = value; }
        }
        [Column(Name = "FaktorKc", DataType = "Double")]
        public Double FaktorKc
        {
            get { return _FaktorKc; }
            set { _FaktorKc = value; }
        }
        [Column(Name = "BigUnit", DataType = "String")]
        public String BigUnit
        {
            get { return _BigUnit; }
            set { _BigUnit = value; }
        }
        [Column(Name = "FaktorBs", DataType = "Double")]
        public Double FaktorBs
        {
            get { return _FaktorBs; }
            set { _FaktorBs = value; }
        }
        [Column(Name = "StockPrice", DataType = "Decimal")]
        public Decimal StockPrice
        {
            get { return _StockPrice; }
            set { _StockPrice = value; }
        }
        [Column(Name = "BasePrice", DataType = "Decimal")]
        public Decimal BasePrice
        {
            get { return _BasePrice; }
            set { _BasePrice = value; }
        }
        [Column(Name = "DistributorPrice", DataType = "Decimal")]
        public Decimal DistributorPrice
        {
            get { return _DistributorPrice; }
            set { _DistributorPrice = value; }
        }
    }
    #endregion
    #region vBedInformationRI
    [Serializable]
    [Table(Name = "vBedInformationRI")]
    public class vBedInformationRI
    {
        private String _BedNumber;
        private String _Name;
        private String _Gender;
        private String _MedicalNo;
        private String _Payer;
        private String _Doctor;
        private String _BedStatus;
        private String _RoomName;
        private String _RoomClass;

        [Column(Name = "BedNumber", DataType = "String")]
        public String BedNumber
        {
            get { return _BedNumber; }
            set { _BedNumber = value; }
        }
        [Column(Name = "Name", DataType = "String")]
        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        [Column(Name = "Gender", DataType = "String")]
        public String Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        [Column(Name = "MedicalNo", DataType = "String")]
        public String MedicalNo
        {
            get { return _MedicalNo; }
            set { _MedicalNo = value; }
        }
        [Column(Name = "Payer", DataType = "String")]
        public String Payer
        {
            get { return _Payer; }
            set { _Payer = value; }
        }
        [Column(Name = "Doctor", DataType = "String")]
        public String Doctor
        {
            get { return _Doctor; }
            set { _Doctor = value; }
        }
        [Column(Name = "BedStatus", DataType = "String")]
        public String BedStatus
        {
            get { return _BedStatus; }
            set { _BedStatus = value; }
        }
        [Column(Name = "RoomName", DataType = "String")]
        public String RoomName
        {
            get { return _RoomName; }
            set { _RoomName = value; }
        }
        [Column(Name = "RoomClass", DataType = "String")]
        public String RoomClass
        {
            get { return _RoomClass; }
            set { _RoomClass = value; }
        }
    }
    #endregion
    #region vBusinessPartner
    [Serializable]
    [Table(Name = "vBusinessPartner")]
    public class vBusinessPartner
    {
        private String _BusinessPartnerCode;
        private String _BusinessPartnerName;
        private String _ContactPersonName;
        private String _ContactPersonPosition;
        private String _ContactPersonPhone;
        private String _AddressLine1;
        private String _AddressLine2;
        private String _TelephoneNo;
        private String _FaxNo;
        private Boolean _IsActive;

        [Column(Name = "BusinessPartnerCode", DataType = "String")]
        public String BusinessPartnerCode
        {
            get { return _BusinessPartnerCode; }
            set { _BusinessPartnerCode = value; }
        }
        [Column(Name = "BusinessPartnerName", DataType = "String")]
        public String BusinessPartnerName
        {
            get { return _BusinessPartnerName; }
            set { _BusinessPartnerName = value; }
        }
        [Column(Name = "ContactPersonName", DataType = "String")]
        public String ContactPersonName
        {
            get { return _ContactPersonName; }
            set { _ContactPersonName = value; }
        }
        [Column(Name = "ContactPersonPosition", DataType = "String")]
        public String ContactPersonPosition
        {
            get { return _ContactPersonPosition; }
            set { _ContactPersonPosition = value; }
        }
        [Column(Name = "ContactPersonPhone", DataType = "String")]
        public String ContactPersonPhone
        {
            get { return _ContactPersonPhone; }
            set { _ContactPersonPhone = value; }
        }
        [Column(Name = "AddressLine1", DataType = "String")]
        public String AddressLine1
        {
            get { return _AddressLine1; }
            set { _AddressLine1 = value; }
        }
        [Column(Name = "AddressLine2", DataType = "String")]
        public String AddressLine2
        {
            get { return _AddressLine2; }
            set { _AddressLine2 = value; }
        }
        [Column(Name = "TelephoneNo", DataType = "String")]
        public String TelephoneNo
        {
            get { return _TelephoneNo; }
            set { _TelephoneNo = value; }
        }
        [Column(Name = "FaxNo", DataType = "String")]
        public String FaxNo
        {
            get { return _FaxNo; }
            set { _FaxNo = value; }
        }
        [Column(Name = "IsActive", DataType = "Boolean")]
        public Boolean IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
    }
    #endregion
    #region vBuyRequest
    [Serializable]
    [Table(Name = "vBuyRequest")]
    public class vBuyRequest
    {
        private String _NoMinta;
        private String _WarehouseCode;
        private String _LocationCode;
        private DateTime _TglMinta;
        private String _TglMintaText;
        private String _ItemCode;
        private Double _QtyMinta;
        private Double _Factor;
        private String _Unit;
        private String _SmallUnitCode;
        private String _SupplierCode;
        private String _SupplierName;
        private String _Tender;
        private String _WarehouseName;
        private String _LocationName;
        private String _ItemName;
        private String _ItemName2;
        private Decimal _ItemPrice;
        private Double _ItemDiscount;
        private String _BigUnit;
        private String _SmallUnit;
        private String _TenderName;
        private String _GroupCode;
        private String _GroupName;

        [Column(Name = "NoMinta", DataType = "String")]
        public String NoMinta
        {
            get { return _NoMinta; }
            set { _NoMinta = value; }
        }
        [Column(Name = "WarehouseCode", DataType = "String")]
        public String WarehouseCode
        {
            get { return _WarehouseCode; }
            set { _WarehouseCode = value; }
        }
        [Column(Name = "LocationCode", DataType = "String")]
        public String LocationCode
        {
            get { return _LocationCode; }
            set { _LocationCode = value; }
        }
        [Column(Name = "TglMinta", DataType = "DateTime")]
        public DateTime TglMinta
        {
            get { return _TglMinta; }
            set { _TglMinta = value; }
        }
        [Column(Name = "TglMintaText", DataType = "String")]
        public String TglMintaText
        {
            get { return _TglMintaText; }
            set { _TglMintaText = value; }
        }
        [Column(Name = "ItemCode", DataType = "String")]
        public String ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; }
        }
        [Column(Name = "QtyMinta", DataType = "Double")]
        public Double QtyMinta
        {
            get { return _QtyMinta; }
            set { _QtyMinta = value; }
        }
        [Column(Name = "Factor", DataType = "Double")]
        public Double Factor
        {
            get { return _Factor; }
            set { _Factor = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "SmallUnitCode", DataType = "String")]
        public String SmallUnitCode
        {
            get { return _SmallUnitCode; }
            set { _SmallUnitCode = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }
        [Column(Name = "Tender", DataType = "String")]
        public String Tender
        {
            get { return _Tender; }
            set { _Tender = value; }
        }
        [Column(Name = "WarehouseName", DataType = "String")]
        public String WarehouseName
        {
            get { return _WarehouseName; }
            set { _WarehouseName = value; }
        }
        [Column(Name = "LocationName", DataType = "String")]
        public String LocationName
        {
            get { return _LocationName; }
            set { _LocationName = value; }
        }
        [Column(Name = "ItemName", DataType = "String")]
        public String ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }
        [Column(Name = "ItemName2", DataType = "String")]
        public String ItemName2
        {
            get { return _ItemName2; }
            set { _ItemName2 = value; }
        }
        [Column(Name = "ItemPrice", DataType = "Decimal")]
        public Decimal ItemPrice
        {
            get { return _ItemPrice; }
            set { _ItemPrice = value; }
        }
        [Column(Name = "ItemDiscount", DataType = "Double")]
        public Double ItemDiscount
        {
            get { return _ItemDiscount; }
            set { _ItemDiscount = value; }
        }
        [Column(Name = "BigUnit", DataType = "String")]
        public String BigUnit
        {
            get { return _BigUnit; }
            set { _BigUnit = value; }
        }
        [Column(Name = "SmallUnit", DataType = "String")]
        public String SmallUnit
        {
            get { return _SmallUnit; }
            set { _SmallUnit = value; }
        }
        [Column(Name = "TenderName", DataType = "String")]
        public String TenderName
        {
            get { return _TenderName; }
            set { _TenderName = value; }
        }
        [Column(Name = "GroupCode", DataType = "String")]
        public String GroupCode
        {
            get { return _GroupCode; }
            set { _GroupCode = value; }
        }
        [Column(Name = "GroupName", DataType = "String")]
        public String GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }
    }
    #endregion
    #region vClass
    [Serializable]
    [Table(Name = "vClass")]
    public class vClass
    {
        private String _ClassCode;
        private String _ClassName;
        private Boolean _IsActive;

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
        [Column(Name = "IsActive", DataType = "Boolean")]
        public Boolean IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
    }
    #endregion
    #region vClinic
    [Serializable]
    [Table(Name = "vClinic")]
    public class vClinic
    {
        private String _ClinicCode;
        private String _ClinicName;
        private String _ClinicTypeCode;
        private String _ClinicTypeName;
        private String _PharmacyWarehouseCode;
        private String _PharmacyWarehouseName;
        private String _PharmacyLocationCode;
        private String _PharmacyLocationName;
        private String _LogisticWarehouseCode;
        private String _LogisticWarehouseName;
        private String _LogisticLocationCode;
        private String _LogisticLocationName;
        private Boolean _IsActive;

        [Column(Name = "ClinicCode", DataType = "String")]
        public String ClinicCode
        {
            get { return _ClinicCode; }
            set { _ClinicCode = value; }
        }
        [Column(Name = "ClinicName", DataType = "String")]
        public String ClinicName
        {
            get { return _ClinicName; }
            set { _ClinicName = value; }
        }
        [Column(Name = "ClinicTypeCode", DataType = "String")]
        public String ClinicTypeCode
        {
            get { return _ClinicTypeCode; }
            set { _ClinicTypeCode = value; }
        }
        [Column(Name = "ClinicTypeName", DataType = "String")]
        public String ClinicTypeName
        {
            get { return _ClinicTypeName; }
            set { _ClinicTypeName = value; }
        }
        [Column(Name = "PharmacyWarehouseCode", DataType = "String")]
        public String PharmacyWarehouseCode
        {
            get { return _PharmacyWarehouseCode; }
            set { _PharmacyWarehouseCode = value; }
        }
        [Column(Name = "PharmacyWarehouseName", DataType = "String")]
        public String PharmacyWarehouseName
        {
            get { return _PharmacyWarehouseName; }
            set { _PharmacyWarehouseName = value; }
        }
        [Column(Name = "PharmacyLocationCode", DataType = "String")]
        public String PharmacyLocationCode
        {
            get { return _PharmacyLocationCode; }
            set { _PharmacyLocationCode = value; }
        }
        [Column(Name = "PharmacyLocationName", DataType = "String")]
        public String PharmacyLocationName
        {
            get { return _PharmacyLocationName; }
            set { _PharmacyLocationName = value; }
        }
        [Column(Name = "LogisticWarehouseCode", DataType = "String")]
        public String LogisticWarehouseCode
        {
            get { return _LogisticWarehouseCode; }
            set { _LogisticWarehouseCode = value; }
        }
        [Column(Name = "LogisticWarehouseName", DataType = "String")]
        public String LogisticWarehouseName
        {
            get { return _LogisticWarehouseName; }
            set { _LogisticWarehouseName = value; }
        }
        [Column(Name = "LogisticLocationCode", DataType = "String")]
        public String LogisticLocationCode
        {
            get { return _LogisticLocationCode; }
            set { _LogisticLocationCode = value; }
        }
        [Column(Name = "LogisticLocationName", DataType = "String")]
        public String LogisticLocationName
        {
            get { return _LogisticLocationName; }
            set { _LogisticLocationName = value; }
        }
        [Column(Name = "IsActive", DataType = "Boolean")]
        public Boolean IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
    }
    #endregion
    #region vEmergencyCarePatientExamination
    [Serializable]
    [Table(Name = "vEmergencyCarePatientExamination")]
    public class vEmergencyCarePatientExamination : vRegistrationIGD
    {
        private Boolean _IsSimpleInstruction;
        private String _Anamnesis;
        private Boolean _Allergy;
        private String _GCSEye;
        private String _GCSMotor;
        private String _GCSVerbal;
        private Decimal _Systole;
        private Decimal _Diastole;
        private Decimal _PulseCount;
        private String _PulseQuality;
        private String _CapillaryRefill;
        private Boolean _IsBreathing;
        private String _RespirationMovement;
        private String _RespirationCondition;
        private String _RespirationMethod;
        private Boolean _IsChestRetraction;
        private String _RespirationRate;
        private Decimal _AxillaryTemperature;
        private Decimal _RectalTemperature;
        private Decimal _AuricularTemperature;
        private String _OxygenSaturation;
        private String _GDSScore;
        private Decimal _Height;
        private Decimal _Weight;
        private String _LastMedicationNote;
        private String _GeneralCondition;
        private String _LeftPupilDiameter;
        private String _RightPupilDiameter;
        private String _LeftPupilRetraction;
        private String _RightPupilRetraction;
        private String _ThoracalNote;
        private String _AbdomenNote;
        private String _ExtremityNote;
        private String _DiagnoseNote;
        private String _TherapyNote;
        private Decimal _BloodVolumeLoss;
        private Boolean _IsAllergy;
        private String _Chronology;
        private Boolean _IsAsthma;
        private Boolean _IsDiabetes;
        private Boolean _IsHipertency;
        private Boolean _IsHeartAttack;
        private Boolean _IsStroke;
        private Boolean _IsKidneyDisease;
        private Boolean _IsLiverDisease;
        private Boolean _SurgeryHistory;
        private String _SurgeryType;
        private Boolean _IsFalseTeeth;
        private Boolean _IsProsthesis;
        private Boolean _IsContactLense;
        private String _LastMealsTime;
        private DateTime _DispositionDate;
        private String _DispositionTime;
        private String _DispositionPhysician;

       
        [Column(Name = "IsSimpleInstruction", DataType = "Boolean")]
        public Boolean IsSimpleInstruction
        {
            get { return _IsSimpleInstruction; }
            set { _IsSimpleInstruction = value; }
        }
        [Column(Name = "Anamnesis", DataType = "String")]
        public String Anamnesis
        {
            get { return _Anamnesis; }
            set { _Anamnesis = value; }
        }
        [Column(Name = "Allergy", DataType = "Boolean")]
        public Boolean Allergy
        {
            get { return _Allergy; }
            set { _Allergy = value; }
        }
        [Column(Name = "GCSEye", DataType = "String")]
        public String GCSEye
        {
            get { return _GCSEye; }
            set { _GCSEye = value; }
        }
        [Column(Name = "GCSMotor", DataType = "String")]
        public String GCSMotor
        {
            get { return _GCSMotor; }
            set { _GCSMotor = value; }
        }
        [Column(Name = "GCSVerbal", DataType = "String")]
        public String GCSVerbal
        {
            get { return _GCSVerbal; }
            set { _GCSVerbal = value; }
        }
        [Column(Name = "Systole", DataType = "Decimal")]
        public Decimal Systole
        {
            get { return _Systole; }
            set { _Systole = value; }
        }
        [Column(Name = "Diastole", DataType = "Decimal")]
        public Decimal Diastole
        {
            get { return _Diastole; }
            set { _Diastole = value; }
        }
        [Column(Name = "PulseCount", DataType = "Decimal")]
        public Decimal PulseCount
        {
            get { return _PulseCount; }
            set { _PulseCount = value; }
        }
        [Column(Name = "PulseQuality", DataType = "String")]
        public String PulseQuality
        {
            get { return _PulseQuality; }
            set { _PulseQuality = value; }
        }
        [Column(Name = "CapillaryRefill", DataType = "String")]
        public String CapillaryRefill
        {
            get { return _CapillaryRefill; }
            set { _CapillaryRefill = value; }
        }
        [Column(Name = "IsBreathing", DataType = "Boolean")]
        public Boolean IsBreathing
        {
            get { return _IsBreathing; }
            set { _IsBreathing = value; }
        }
        [Column(Name = "RespirationMovement", DataType = "String")]
        public String RespirationMovement
        {
            get { return _RespirationMovement; }
            set { _RespirationMovement = value; }
        }
        [Column(Name = "RespirationCondition", DataType = "String")]
        public String RespirationCondition
        {
            get { return _RespirationCondition; }
            set { _RespirationCondition = value; }
        }
        [Column(Name = "RespirationMethod", DataType = "String")]
        public String RespirationMethod
        {
            get { return _RespirationMethod; }
            set { _RespirationMethod = value; }
        }
        [Column(Name = "IsChestRetraction", DataType = "Boolean")]
        public Boolean IsChestRetraction
        {
            get { return _IsChestRetraction; }
            set { _IsChestRetraction = value; }
        }
        [Column(Name = "RespirationRate", DataType = "String")]
        public String RespirationRate
        {
            get { return _RespirationRate; }
            set { _RespirationRate = value; }
        }
        [Column(Name = "AxillaryTemperature", DataType = "Decimal")]
        public Decimal AxillaryTemperature
        {
            get { return _AxillaryTemperature; }
            set { _AxillaryTemperature = value; }
        }
        [Column(Name = "RectalTemperature", DataType = "Decimal")]
        public Decimal RectalTemperature
        {
            get { return _RectalTemperature; }
            set { _RectalTemperature = value; }
        }
        [Column(Name = "AuricularTemperature", DataType = "Decimal")]
        public Decimal AuricularTemperature
        {
            get { return _AuricularTemperature; }
            set { _AuricularTemperature = value; }
        }
        [Column(Name = "OxygenSaturation", DataType = "String")]
        public String OxygenSaturation
        {
            get { return _OxygenSaturation; }
            set { _OxygenSaturation = value; }
        }
        [Column(Name = "GDSScore", DataType = "String")]
        public String GDSScore
        {
            get { return _GDSScore; }
            set { _GDSScore = value; }
        }
        [Column(Name = "Height", DataType = "Decimal")]
        public Decimal Height
        {
            get { return _Height; }
            set { _Height = value; }
        }
        [Column(Name = "Weight", DataType = "Decimal")]
        public Decimal Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
        [Column(Name = "LastMedicationNote", DataType = "String")]
        public String LastMedicationNote
        {
            get { return _LastMedicationNote; }
            set { _LastMedicationNote = value; }
        }
        [Column(Name = "GeneralCondition", DataType = "String")]
        public String GeneralCondition
        {
            get { return _GeneralCondition; }
            set { _GeneralCondition = value; }
        }
        [Column(Name = "LeftPupilDiameter", DataType = "String")]
        public String LeftPupilDiameter
        {
            get { return _LeftPupilDiameter; }
            set { _LeftPupilDiameter = value; }
        }
        [Column(Name = "RightPupilDiameter", DataType = "String")]
        public String RightPupilDiameter
        {
            get { return _RightPupilDiameter; }
            set { _RightPupilDiameter = value; }
        }
        [Column(Name = "LeftPupilRetraction", DataType = "String")]
        public String LeftPupilRetraction
        {
            get { return _LeftPupilRetraction; }
            set { _LeftPupilRetraction = value; }
        }
        [Column(Name = "RightPupilRetraction", DataType = "String")]
        public String RightPupilRetraction
        {
            get { return _RightPupilRetraction; }
            set { _RightPupilRetraction= value; }
        }
        [Column(Name = "ThoracalNote", DataType = "String")]
        public String ThoracalNote
        {
            get { return _ThoracalNote; }
            set { _ThoracalNote = value; }
        }
        [Column(Name = "AbdomenNote", DataType = "String")]
        public String AbdomenNote
        {
            get { return _AbdomenNote; }
            set { _AbdomenNote = value; }
        }
        [Column(Name = "ExtremityNote", DataType = "String")]
        public String ExtremityNote
        {
            get { return _ExtremityNote; }
            set { _ExtremityNote = value; }
        }
        [Column(Name = "DiagnoseNote", DataType = "String")]
        public String DiagnoseNote
        {
            get { return _DiagnoseNote; }
            set { _DiagnoseNote = value; }
        }
        [Column(Name = "TherapyNote", DataType = "String")]
        public String TherapyNote
        {
            get { return _TherapyNote; }
            set { _TherapyNote = value; }
        }
        [Column(Name = "BloodVolumeLoss", DataType = "Decimal")]
        public Decimal BloodVolumeLoss
        {
            get { return _BloodVolumeLoss; }
            set { _BloodVolumeLoss = value; }
        }
        [Column(Name = "IsAllergy", DataType = "Boolean")]
        public Boolean IsAllergy
        {
            get { return _IsAllergy; }
            set { _IsAllergy = value; }
        }
        [Column(Name = "Chronology", DataType = "String")]
        public String Chronology
        {
            get { return _Chronology; }
            set { _Chronology = value; }
        }
        [Column(Name = "IsAsthma", DataType = "Boolean")]
        public Boolean IsAsthma
        {
            get { return _IsAsthma; }
            set { _IsAsthma = value; }
        }
        [Column(Name = "IsDiabetes", DataType = "Boolean")]
        public Boolean IsDiabetes
        {
            get { return _IsDiabetes; }
            set { _IsDiabetes = value; }
        }
        [Column(Name = "IsHipertency", DataType = "Boolean")]
        public Boolean IsHipertency
        {
            get { return _IsHipertency; }
            set { _IsHipertency = value; }
        }
        [Column(Name = "IsHeartAttack", DataType = "Boolean")]
        public Boolean IsHeartAttack
        {
            get { return _IsHeartAttack; }
            set { _IsHeartAttack = value; }
        }
        [Column(Name = "IsStroke", DataType = "Boolean")]
        public Boolean IsStroke
        {
            get { return _IsStroke; }
            set { _IsStroke = value; }
        }
        [Column(Name = "IsKidneyDisease", DataType = "Boolean")]
        public Boolean IsKidneyDisease
        {
            get { return _IsKidneyDisease; }
            set { _IsKidneyDisease = value; }
        }
        [Column(Name = "IsLiverDisease", DataType = "Boolean")]
        public Boolean IsLiverDisease
        {
            get { return _IsLiverDisease; }
            set { _IsLiverDisease = value; }
        }
        [Column(Name = "SurgeryHistory", DataType = "Boolean")]
        public Boolean SurgeryHistory
        {
            get { return _SurgeryHistory; }
            set { _SurgeryHistory = value; }
        }
        [Column(Name = "SurgeryType", DataType = "String")]
        public String SurgeryType
        {
            get { return _SurgeryType; }
            set { _SurgeryType = value; }
        }
        [Column(Name = "IsFalseTeeth", DataType = "Boolean")]
        public Boolean IsFalseTeeth
        {
            get { return _IsFalseTeeth; }
            set { _IsFalseTeeth = value; }
        }
        [Column(Name = "IsProsthesis", DataType = "Boolean")]
        public Boolean IsProsthesis
        {
            get { return _IsProsthesis; }
            set { _IsProsthesis = value; }
        }
        [Column(Name = "IsContactLense", DataType = "Boolean")]
        public Boolean IsContactLense
        {
            get { return _IsContactLense; }
            set { _IsContactLense = value; }
        }
        [Column(Name = "LastMealsTime", DataType = "String")]
        public String LastMealsTime
        {
            get { return _LastMealsTime; }
            set { _LastMealsTime = value; }
        }
        [Column(Name = "DispositionDate", DataType = "DateTime")]
        public DateTime DispositionDate
        {
            get { return _DispositionDate; }
            set { _DispositionDate = value; }
        }
        [Column(Name = "DispositionTime", DataType = "String")]
        public String DispositionTime
        {
            get { return _DispositionTime; }
            set { _DispositionTime = value; }
        }
        [Column(Name = "DispositionPhysician", DataType = "String")]
        public String DispositionPhysician
        {
            get { return _DispositionPhysician; }
            set { _DispositionPhysician = value; }
        }

    }
    #endregion
    #region vEmergencyCareRevenue
    [Serializable]
    [Table(Name = "vEmergencyCareRevenue")]
    public class vEmergencyCareRevenue
    {
        private String _PaymentNo;
        private DateTime _PaymentDate;
        private String _PaymentDateText;
        private String _PaymentStatusCode;
        private String _PyamentStatusName;
        private String _RegistrationNo;
        private DateTime _RegistrationDate;
        private String _MedicalNo;
        private String _PatientFirstName;
        private String _PatientLastName;
        private String _PatientGender;
        private Decimal _BillAmount;
        private Decimal _PaymentAmount1;
        private Decimal _PaymentAmount2;
        private Decimal _PaymentAmount3;
        private Decimal _PaymentAmount4;
        private Decimal _PaymentAmount5;
        private String _CreditCardType1;
        private String _CreditCardNo1;
        private String _BankName1;
        private String _CreditCardType2;
        private String _CreditCardNo2;
        private String _BankName2;
        private String _CreditCardType3;
        private String _CreditCardNo3;
        private String _BankName3;
        private String _DebitCardNo;
        private String _BankName4;
        private Decimal _Discount;
        private Decimal _OtherBillAmount;
        private String _PaymentName;
        private String _Payer;
        private Boolean _IsVoid;
        private DateTime _UpdatedDate;
        private String _UpdatedBy;
        private String _Doctor;
        private Int32 _DisplayOrder;
        private String _TransactionType;
        private DateTime _TransactionDate;
        private String _ItemCode;
        private String _ItemName;
        private String _TransactionPhysician;
        private Double _ItemQty;
        private Double _PatientBillAmount;
        private Double _PayerBillAmount;

        [Column(Name = "PaymentNo", DataType = "String")]
        public String PaymentNo
        {
            get { return _PaymentNo; }
            set { _PaymentNo = value; }
        }
        [Column(Name = "PaymentDate", DataType = "DateTime")]
        public DateTime PaymentDate
        {
            get { return _PaymentDate; }
            set { _PaymentDate = value; }
        }
        [Column(Name = "PaymentDateText", DataType = "String")]
        public String PaymentDateText
        {
            get { return _PaymentDateText; }
            set { _PaymentDateText = value; }
        }
        [Column(Name = "PaymentStatusCode", DataType = "String")]
        public String PaymentStatusCode
        {
            get { return _PaymentStatusCode; }
            set { _PaymentStatusCode = value; }
        }
        [Column(Name = "PyamentStatusName", DataType = "String")]
        public String PyamentStatusName
        {
            get { return _PyamentStatusName; }
            set { _PyamentStatusName = value; }
        }
        [Column(Name = "RegistrationNo", DataType = "String")]
        public String RegistrationNo
        {
            get { return _RegistrationNo; }
            set { _RegistrationNo = value; }
        }
        [Column(Name = "RegistrationDate", DataType = "DateTime")]
        public DateTime RegistrationDate
        {
            get { return _RegistrationDate; }
            set { _RegistrationDate = value; }
        }
        [Column(Name = "MedicalNo", DataType = "String")]
        public String MedicalNo
        {
            get { return _MedicalNo; }
            set { _MedicalNo = value; }
        }
        [Column(Name = "PatientFirstName", DataType = "String")]
        public String PatientFirstName
        {
            get { return _PatientFirstName; }
            set { _PatientFirstName = value; }
        }
        [Column(Name = "PatientLastName", DataType = "String")]
        public String PatientLastName
        {
            get { return _PatientLastName; }
            set { _PatientLastName = value; }
        }
        [Column(Name = "PatientGender", DataType = "String")]
        public String PatientGender
        {
            get { return _PatientGender; }
            set { _PatientGender = value; }
        }
        [Column(Name = "BillAmount", DataType = "Decimal")]
        public Decimal BillAmount
        {
            get { return _BillAmount; }
            set { _BillAmount = value; }
        }
        [Column(Name = "PaymentAmount1", DataType = "Decimal")]
        public Decimal PaymentAmount1
        {
            get { return _PaymentAmount1; }
            set { _PaymentAmount1 = value; }
        }
        [Column(Name = "PaymentAmount2", DataType = "Decimal")]
        public Decimal PaymentAmount2
        {
            get { return _PaymentAmount2; }
            set { _PaymentAmount2 = value; }
        }
        [Column(Name = "PaymentAmount3", DataType = "Decimal")]
        public Decimal PaymentAmount3
        {
            get { return _PaymentAmount3; }
            set { _PaymentAmount3 = value; }
        }
        [Column(Name = "PaymentAmount4", DataType = "Decimal")]
        public Decimal PaymentAmount4
        {
            get { return _PaymentAmount4; }
            set { _PaymentAmount4 = value; }
        }
        [Column(Name = "PaymentAmount5", DataType = "Decimal")]
        public Decimal PaymentAmount5
        {
            get { return _PaymentAmount5; }
            set { _PaymentAmount5 = value; }
        }
        [Column(Name = "CreditCardType1", DataType = "String")]
        public String CreditCardType1
        {
            get { return _CreditCardType1; }
            set { _CreditCardType1 = value; }
        }
        [Column(Name = "CreditCardNo1", DataType = "String")]
        public String CreditCardNo1
        {
            get { return _CreditCardNo1; }
            set { _CreditCardNo1 = value; }
        }
        [Column(Name = "BankName1", DataType = "String")]
        public String BankName1
        {
            get { return _BankName1; }
            set { _BankName1 = value; }
        }
        [Column(Name = "CreditCardType2", DataType = "String")]
        public String CreditCardType2
        {
            get { return _CreditCardType2; }
            set { _CreditCardType2 = value; }
        }
        [Column(Name = "CreditCardNo2", DataType = "String")]
        public String CreditCardNo2
        {
            get { return _CreditCardNo2; }
            set { _CreditCardNo2 = value; }
        }
        [Column(Name = "BankName2", DataType = "String")]
        public String BankName2
        {
            get { return _BankName2; }
            set { _BankName2 = value; }
        }
        [Column(Name = "CreditCardType3", DataType = "String")]
        public String CreditCardType3
        {
            get { return _CreditCardType3; }
            set { _CreditCardType3 = value; }
        }
        [Column(Name = "CreditCardNo3", DataType = "String")]
        public String CreditCardNo3
        {
            get { return _CreditCardNo3; }
            set { _CreditCardNo3 = value; }
        }
        [Column(Name = "BankName3", DataType = "String")]
        public String BankName3
        {
            get { return _BankName3; }
            set { _BankName3 = value; }
        }
        [Column(Name = "DebitCardNo", DataType = "String")]
        public String DebitCardNo
        {
            get { return _DebitCardNo; }
            set { _DebitCardNo = value; }
        }
        [Column(Name = "BankName4", DataType = "String")]
        public String BankName4
        {
            get { return _BankName4; }
            set { _BankName4 = value; }
        }
        [Column(Name = "Discount", DataType = "Decimal")]
        public Decimal Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        [Column(Name = "OtherBillAmount", DataType = "Decimal")]
        public Decimal OtherBillAmount
        {
            get { return _OtherBillAmount; }
            set { _OtherBillAmount = value; }
        }
        [Column(Name = "PaymentName", DataType = "String")]
        public String PaymentName
        {
            get { return _PaymentName; }
            set { _PaymentName = value; }
        }
        [Column(Name = "Payer", DataType = "String")]
        public String Payer
        {
            get { return _Payer; }
            set { _Payer = value; }
        }
        [Column(Name = "IsVoid", DataType = "Boolean")]
        public Boolean IsVoid
        {
            get { return _IsVoid; }
            set { _IsVoid = value; }
        }
        [Column(Name = "UpdatedDate", DataType = "DateTime")]
        public DateTime UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }
        [Column(Name = "UpdatedBy", DataType = "String")]
        public String UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
        [Column(Name = "Doctor", DataType = "String")]
        public String Doctor
        {
            get { return _Doctor; }
            set { _Doctor = value; }
        }
        [Column(Name = "DisplayOrder", DataType = "Int32")]
        public Int32 DisplayOrder
        {
            get { return _DisplayOrder; }
            set { _DisplayOrder = value; }
        }
        [Column(Name = "TransactionType", DataType = "String")]
        public String TransactionType
        {
            get { return _TransactionType; }
            set { _TransactionType = value; }
        }
        [Column(Name = "TransactionDate", DataType = "DateTime")]
        public DateTime TransactionDate
        {
            get { return _TransactionDate; }
            set { _TransactionDate = value; }
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
        [Column(Name = "TransactionPhysician", DataType = "String")]
        public String TransactionPhysician
        {
            get { return _TransactionPhysician; }
            set { _TransactionPhysician = value; }
        }
        [Column(Name = "ItemQty", DataType = "Double")]
        public Double ItemQty
        {
            get { return _ItemQty; }
            set { _ItemQty = value; }
        }
        [Column(Name = "PatientBillAmount", DataType = "Double")]
        public Double PatientBillAmount
        {
            get { return _PatientBillAmount; }
            set { _PatientBillAmount = value; }
        }
        [Column(Name = "PayerBillAmount", DataType = "Double")]
        public Double PayerBillAmount
        {
            get { return _PayerBillAmount; }
            set { _PayerBillAmount = value; }
        }
    }
    #endregion
    #region vEmergencyCareTransaction
    [Serializable]
    [Table(Name = "vEmergencyCareTransaction")]
    public class vEmergencyCareTransaction : vRegistrationIGD
    {
        private Int32 _DisplayOrder;
        private String _TransactionType;
        private String _TransactionNo;
        private DateTime _TransactionDate;
        private String _TransactionTime;
        private String _TransactionPhysician;
        private String _ItemCode;
        private String _ItemName;
        private Double _ItemQty;
        private String _ItemUnit;
        private Double _CompTrf1;
        private Decimal _CompTrf2;
        private Decimal _CompTrf3;
        private Decimal _CompTrf4;
        private Decimal _Deductible1;
        private Decimal _Deductible2;
        private Decimal _Deductible3;
        private Decimal _Deductible4;
        private Double _Discount1;
        private Decimal _Discount2;
        private Decimal _Discount3;
        private Decimal _Discount4;
        private Decimal _BasePrice1;
        private Decimal _BasePrice2;
        private Decimal _BasePrice3;
        private Decimal _BasePrice4;
        private Decimal _CitoAmount;
        private Decimal _CitoDiscAmount;
        private Decimal _CitoDeductAmount;
        private Decimal _ComplicationAmount;
        private Decimal _ComplicationDiscAmount;
        private Decimal _ComplicationDeducAmount;
        private Double _PatientBillAmount;
        private Double _PayerBillAmount;
        private Int32 _IsVariablePrice;
        private Int32 _IsFreeOfCharge;
        private Int32 _IsApproved;
        private DateTime _UpdatedDate;
        private String _UpdatedBy;
        private String _MedicalDiagnostic;

        [Column(Name = "DisplayOrder", DataType = "Int32")]
        public Int32 DisplayOrder
        {
            get { return _DisplayOrder; }
            set { _DisplayOrder = value; }
        }
        [Column(Name = "TransactionType", DataType = "String")]
        public String TransactionType
        {
            get { return _TransactionType; }
            set { _TransactionType = value; }
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
        [Column(Name = "TransactionTime", DataType = "String")]
        public String TransactionTime
        {
            get { return _TransactionTime; }
            set { _TransactionTime = value; }
        }
        [Column(Name = "TransactionPhysician", DataType = "String")]
        public String TransactionPhysician
        {
            get { return _TransactionPhysician; }
            set { _TransactionPhysician = value; }
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
        [Column(Name = "ItemQty", DataType = "Double")]
        public Double ItemQty
        {
            get { return _ItemQty; }
            set { _ItemQty = value; }
        }
        [Column(Name = "ItemUnit", DataType = "String")]
        public String ItemUnit
        {
            get { return _ItemUnit; }
            set { _ItemUnit = value; }
        }
        [Column(Name = "CompTrf1", DataType = "Double")]
        public Double CompTrf1
        {
            get { return _CompTrf1; }
            set { _CompTrf1 = value; }
        }
        [Column(Name = "CompTrf2", DataType = "Decimal")]
        public Decimal CompTrf2
        {
            get { return _CompTrf2; }
            set { _CompTrf2 = value; }
        }
        [Column(Name = "CompTrf3", DataType = "Decimal")]
        public Decimal CompTrf3
        {
            get { return _CompTrf3; }
            set { _CompTrf3 = value; }
        }
        [Column(Name = "CompTrf4", DataType = "Decimal")]
        public Decimal CompTrf4
        {
            get { return _CompTrf4; }
            set { _CompTrf4 = value; }
        }
        [Column(Name = "Deductible1", DataType = "Decimal")]
        public Decimal Deductible1
        {
            get { return _Deductible1; }
            set { _Deductible1 = value; }
        }
        [Column(Name = "Deductible2", DataType = "Decimal")]
        public Decimal Deductible2
        {
            get { return _Deductible2; }
            set { _Deductible2 = value; }
        }
        [Column(Name = "Deductible3", DataType = "Decimal")]
        public Decimal Deductible3
        {
            get { return _Deductible3; }
            set { _Deductible3 = value; }
        }
        [Column(Name = "Deductible4", DataType = "Decimal")]
        public Decimal Deductible4
        {
            get { return _Deductible4; }
            set { _Deductible4 = value; }
        }
        [Column(Name = "Discount1", DataType = "Double")]
        public Double Discount1
        {
            get { return _Discount1; }
            set { _Discount1 = value; }
        }
        [Column(Name = "Discount2", DataType = "Decimal")]
        public Decimal Discount2
        {
            get { return _Discount2; }
            set { _Discount2 = value; }
        }
        [Column(Name = "Discount3", DataType = "Decimal")]
        public Decimal Discount3
        {
            get { return _Discount3; }
            set { _Discount3 = value; }
        }
        [Column(Name = "Discount4", DataType = "Decimal")]
        public Decimal Discount4
        {
            get { return _Discount4; }
            set { _Discount4 = value; }
        }
        [Column(Name = "BasePrice1", DataType = "Decimal")]
        public Decimal BasePrice1
        {
            get { return _BasePrice1; }
            set { _BasePrice1 = value; }
        }
        [Column(Name = "BasePrice2", DataType = "Decimal")]
        public Decimal BasePrice2
        {
            get { return _BasePrice2; }
            set { _BasePrice2 = value; }
        }
        [Column(Name = "BasePrice3", DataType = "Decimal")]
        public Decimal BasePrice3
        {
            get { return _BasePrice3; }
            set { _BasePrice3 = value; }
        }
        [Column(Name = "BasePrice4", DataType = "Decimal")]
        public Decimal BasePrice4
        {
            get { return _BasePrice4; }
            set { _BasePrice4 = value; }
        }
        [Column(Name = "CitoAmount", DataType = "Decimal")]
        public Decimal CitoAmount
        {
            get { return _CitoAmount; }
            set { _CitoAmount = value; }
        }
        [Column(Name = "CitoDiscAmount", DataType = "Decimal")]
        public Decimal CitoDiscAmount
        {
            get { return _CitoDiscAmount; }
            set { _CitoDiscAmount = value; }
        }
        [Column(Name = "CitoDeductAmount", DataType = "Decimal")]
        public Decimal CitoDeductAmount
        {
            get { return _CitoDeductAmount; }
            set { _CitoDeductAmount = value; }
        }
        [Column(Name = "ComplicationAmount", DataType = "Decimal")]
        public Decimal ComplicationAmount
        {
            get { return _ComplicationAmount; }
            set { _ComplicationAmount = value; }
        }
        [Column(Name = "ComplicationDiscAmount", DataType = "Decimal")]
        public Decimal ComplicationDiscAmount
        {
            get { return _ComplicationDiscAmount; }
            set { _ComplicationDiscAmount = value; }
        }
        [Column(Name = "ComplicationDeducAmount", DataType = "Decimal")]
        public Decimal ComplicationDeducAmount
        {
            get { return _ComplicationDeducAmount; }
            set { _ComplicationDeducAmount = value; }
        }
        [Column(Name = "PatientBillAmount", DataType = "Double")]
        public Double PatientBillAmount
        {
            get { return _PatientBillAmount; }
            set { _PatientBillAmount = value; }
        }
        [Column(Name = "PayerBillAmount", DataType = "Double")]
        public Double PayerBillAmount
        {
            get { return _PayerBillAmount; }
            set { _PayerBillAmount = value; }
        }
        [Column(Name = "IsVariablePrice", DataType = "Int32")]
        public Int32 IsVariablePrice
        {
            get { return _IsVariablePrice; }
            set { _IsVariablePrice = value; }
        }
        [Column(Name = "IsFreeOfCharge", DataType = "Int32")]
        public Int32 IsFreeOfCharge
        {
            get { return _IsFreeOfCharge; }
            set { _IsFreeOfCharge = value; }
        }
        [Column(Name = "IsApproved", DataType = "Int32")]
        public Int32 IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
        [Column(Name = "UpdatedDate", DataType = "DateTime")]
        public DateTime UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }
        [Column(Name = "UpdatedBy", DataType = "String")]
        public String UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
        [Column(Name = "MedicalDiagnostic", DataType = "String")]
        public String MedicalDiagnostic
        {
            get { return _MedicalDiagnostic; }
            set { _MedicalDiagnostic = value; }
        }
    }
    #endregion
    #region vFormulaProd
    [Serializable]
    [Table(Name = "vFormulaProd")]
    public class vFormulaProd
    {
        private String _ProdCode;
        private String _ProdName;
        private String _ProdName2;
        private String _UnitCode;
        private String _SmallUnit;
        private Double _Cost;
        private Boolean _Persen;
        private String _ItemCode;
        private String _ItemName;
        private String _ItemName2;
        private Double _Quantity;
        private String _ItemUnitCode;

        [Column(Name = "ProdCode", DataType = "String")]
        public String ProdCode
        {
            get { return _ProdCode; }
            set { _ProdCode = value; }
        }
        [Column(Name = "ProdName", DataType = "String")]
        public String ProdName
        {
            get { return _ProdName; }
            set { _ProdName = value; }
        }
        [Column(Name = "ProdName2", DataType = "String")]
        public String ProdName2
        {
            get { return _ProdName2; }
            set { _ProdName2 = value; }
        }
        [Column(Name = "UnitCode", DataType = "String")]
        public String UnitCode
        {
            get { return _UnitCode; }
            set { _UnitCode = value; }
        }
        [Column(Name = "SmallUnit", DataType = "String")]
        public String SmallUnit
        {
            get { return _SmallUnit; }
            set { _SmallUnit = value; }
        }
        [Column(Name = "Cost", DataType = "Double")]
        public Double Cost
        {
            get { return _Cost; }
            set { _Cost = value; }
        }
        [Column(Name = "Persen", DataType = "Boolean")]
        public Boolean Persen
        {
            get { return _Persen; }
            set { _Persen = value; }
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
        [Column(Name = "ItemName2", DataType = "String")]
        public String ItemName2
        {
            get { return _ItemName2; }
            set { _ItemName2 = value; }
        }
        [Column(Name = "Quantity", DataType = "Double")]
        public Double Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        [Column(Name = "ItemUnitCode", DataType = "String")]
        public String ItemUnitCode
        {
            get { return _ItemUnitCode; }
            set { _ItemUnitCode = value; }
        }
    }
    #endregion
    #region vFormularium
    [Serializable]
    [Table(Name = "vFormularium")]
    public class vFormularium
    {
        private String _DTTherapyCode;
        private String _TherapyName;
        private String _DTTherapyName;
        private String _ItemName;

        [Column(Name = "DTTherapyCode", DataType = "String")]
        public String DTTherapyCode
        {
            get { return _DTTherapyCode; }
            set { _DTTherapyCode = value; }
        }
        [Column(Name = "TherapyName", DataType = "String")]
        public String TherapyName
        {
            get { return _TherapyName; }
            set { _TherapyName = value; }
        }
        [Column(Name = "DTTherapyName", DataType = "String")]
        public String DTTherapyName
        {
            get { return _DTTherapyName; }
            set { _DTTherapyName = value; }
        }
        [Column(Name = "ItemName", DataType = "String")]
        public String ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }
    }
    #endregion
    #region vGeneralLogisticDirectPurchase
    [Serializable]
    [Table(Name = "vGeneralLogisticDirectPurchase")]
    public class vGeneralLogisticDirectPurchase
    {
        private String _DirectPurchaseNo;
        private DateTime _DirectPurchaseDate;
        private String _DirectPurchaseDateText;
        private String _SupplierCode;
        private String _SupplierName;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private Double _HeaderVAT;
        private String _Updater;
        private String _ItemCode;
        private String _ItemName;
        private Double _Price;
        private String _Unit;
        private Double _Qty;
        private Double _DiscountPerc;
        private Boolean _IsVAT;

        [Column(Name = "DirectPurchaseNo", DataType = "String")]
        public String DirectPurchaseNo
        {
            get { return _DirectPurchaseNo; }
            set { _DirectPurchaseNo = value; }
        }
        [Column(Name = "DirectPurchaseDate", DataType = "DateTime")]
        public DateTime DirectPurchaseDate
        {
            get { return _DirectPurchaseDate; }
            set { _DirectPurchaseDate = value; }
        }
        [Column(Name = "DirectPurchaseDateText", DataType = "String")]
        public String DirectPurchaseDateText
        {
            get { return _DirectPurchaseDateText; }
            set { _DirectPurchaseDateText = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
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
        [Column(Name = "HeaderVAT", DataType = "Double")]
        public Double HeaderVAT
        {
            get { return _HeaderVAT; }
            set { _HeaderVAT = value; }
        }
        [Column(Name = "Updater", DataType = "String")]
        public String Updater
        {
            get { return _Updater; }
            set { _Updater = value; }
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
        [Column(Name = "Price", DataType = "Double")]
        public Double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Qty", DataType = "Double")]
        public Double Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        [Column(Name = "DiscountPerc", DataType = "Double")]
        public Double DiscountPerc
        {
            get { return _DiscountPerc; }
            set { _DiscountPerc = value; }
        }
        [Column(Name = "IsVAT", DataType = "Boolean")]
        public Boolean IsVAT
        {
            get { return _IsVAT; }
            set { _IsVAT = value; }
        }
    }
    #endregion
    #region vGeneralLogisticDirectPurchaseReturn
    [Serializable]
    [Table(Name = "vGeneralLogisticDirectPurchaseReturn")]
    public class vGeneralLogisticDirectPurchaseReturn
    {
        private String _PurchaseReturnNo;
        private String _SupplierCode;
        private String _SupplierName;
        private DateTime _PurchaseReturnDate;
        private String _PurchaseReturnDateText;
        private String _DirectPurchaseNo;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private String _Remark;
        private String _ItemCode;
        private String _ItemName;
        private Double _ReturnQty;
        private String _Unit;
        private Decimal _Price;
        private Double _Discount;
        private Boolean _IsApproved;

        [Column(Name = "PurchaseReturnNo", DataType = "String")]
        public String PurchaseReturnNo
        {
            get { return _PurchaseReturnNo; }
            set { _PurchaseReturnNo = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }
        [Column(Name = "PurchaseReturnDate", DataType = "DateTime")]
        public DateTime PurchaseReturnDate
        {
            get { return _PurchaseReturnDate; }
            set { _PurchaseReturnDate = value; }
        }
        [Column(Name = "PurchaseReturnDateText", DataType = "String")]
        public String PurchaseReturnDateText
        {
            get { return _PurchaseReturnDateText; }
            set { _PurchaseReturnDateText = value; }
        }
        [Column(Name = "DirectPurchaseNo", DataType = "String")]
        public String DirectPurchaseNo
        {
            get { return _DirectPurchaseNo; }
            set { _DirectPurchaseNo = value; }
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
        [Column(Name = "Remark", DataType = "String")]
        public String Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
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
        [Column(Name = "ReturnQty", DataType = "Double")]
        public Double ReturnQty
        {
            get { return _ReturnQty; }
            set { _ReturnQty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Price", DataType = "Decimal")]
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Column(Name = "Discount", DataType = "Double")]
        public Double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
    }
    #endregion
    #region vGeneralLogisticGoodsRequest
    [Serializable]
    [Table(Name = "vGeneralLogisticGoodsRequest")]
    public class vGeneralLogisticGoodsRequest
    {
        private String _GoodsRequestNo;
        private DateTime _GoodsRequestDate;
        private String _GoodsRequestDateText;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private String _DepartmentCode;
        private String _DepartmentName;
        private String _RequestDescription;
        private String _ProductLineCode;
        private String _ProductLine;
        private String _ItemCode;
        private String _ItemName;
        private Double _Qty;
        private String _Unit;
        private Boolean _IsApproved;
        private String _UserApproval;
        private DateTime _GoodsRequestApprovalDate;
        private String _GoodsRequestApprovalDateText;

        [Column(Name = "GoodsRequestNo", DataType = "String")]
        public String GoodsRequestNo
        {
            get { return _GoodsRequestNo; }
            set { _GoodsRequestNo = value; }
        }
        [Column(Name = "GoodsRequestDate", DataType = "DateTime")]
        public DateTime GoodsRequestDate
        {
            get { return _GoodsRequestDate; }
            set { _GoodsRequestDate = value; }
        }
        [Column(Name = "GoodsRequestDateText", DataType = "String")]
        public String GoodsRequestDateText
        {
            get { return _GoodsRequestDateText; }
            set { _GoodsRequestDateText = value; }
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
        [Column(Name = "DepartmentCode", DataType = "String")]
        public String DepartmentCode
        {
            get { return _DepartmentCode; }
            set { _DepartmentCode = value; }
        }
        [Column(Name = "DepartmentName", DataType = "String")]
        public String DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
        }
        [Column(Name = "RequestDescription", DataType = "String")]
        public String RequestDescription
        {
            get { return _RequestDescription; }
            set { _RequestDescription = value; }
        }
        [Column(Name = "ProductLineCode", DataType = "String")]
        public String ProductLineCode
        {
            get { return _ProductLineCode; }
            set { _ProductLineCode = value; }
        }
        [Column(Name = "ProductLine", DataType = "String")]
        public String ProductLine
        {
            get { return _ProductLine; }
            set { _ProductLine = value; }
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
        [Column(Name = "Qty", DataType = "Double")]
        public Double Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
        [Column(Name = "UserApproval", DataType = "String")]
        public String UserApproval
        {
            get { return _UserApproval; }
            set { _UserApproval = value; }
        }
        [Column(Name = "GoodsRequestApprovalDate", DataType = "DateTime")]
        public DateTime GoodsRequestApprovalDate
        {
            get { return _GoodsRequestApprovalDate; }
            set { _GoodsRequestApprovalDate = value; }
        }
        [Column(Name = "GoodsRequestApprovalDateText", DataType = "String")]
        public String GoodsRequestApprovalDateText
        {
            get { return _GoodsRequestApprovalDateText; }
            set { _GoodsRequestApprovalDateText = value; }
        }
    }
    #endregion
    #region vGeneralLogisticItem
    [Serializable]
    [Table(Name = "vGeneralLogisticItem")]
    public class vGeneralLogisticItem
    {
        private String _ItemCode;
        private String _ProductLineCode;
        private String _ProductLineName;
        private String _ItemName;
        private String _CatalogNo;
        private String _SmallUnit;
        private String _BigUnit;
        private Double _Factor;
        private String _LastSupplierCode;
        private String _LastSupplierName;
        private String _ManufacturerCode;
        private String _ManufacturerName;
        private Decimal _OldPrice;
        private Decimal _LatestPrice;
        private Decimal _BasePrice;
        private Decimal _AveragePrice;
        private Double _SalesPrice;
        private Double _Discount;
        private Double _Discount2;
        private Double _VAT;

        [Column(Name = "ItemCode", DataType = "String")]
        public String ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; }
        }
        [Column(Name = "ProductLineCode", DataType = "String")]
        public String ProductLineCode
        {
            get { return _ProductLineCode; }
            set { _ProductLineCode = value; }
        }
        [Column(Name = "ProductLineName", DataType = "String")]
        public String ProductLineName
        {
            get { return _ProductLineName; }
            set { _ProductLineName = value; }
        }
        [Column(Name = "ItemName", DataType = "String")]
        public String ItemName
        {
            get { return _ItemName; }
            set { _ItemName = value; }
        }
        [Column(Name = "CatalogNo", DataType = "String")]
        public String CatalogNo
        {
            get { return _CatalogNo; }
            set { _CatalogNo = value; }
        }
        [Column(Name = "SmallUnit", DataType = "String")]
        public String SmallUnit
        {
            get { return _SmallUnit; }
            set { _SmallUnit = value; }
        }
        [Column(Name = "BigUnit", DataType = "String")]
        public String BigUnit
        {
            get { return _BigUnit; }
            set { _BigUnit = value; }
        }
        [Column(Name = "Factor", DataType = "Double")]
        public Double Factor
        {
            get { return _Factor; }
            set { _Factor = value; }
        }
        [Column(Name = "LastSupplierCode", DataType = "String")]
        public String LastSupplierCode
        {
            get { return _LastSupplierCode; }
            set { _LastSupplierCode = value; }
        }
        [Column(Name = "LastSupplierName", DataType = "String")]
        public String LastSupplierName
        {
            get { return _LastSupplierName; }
            set { _LastSupplierName = value; }
        }
        [Column(Name = "ManufacturerCode", DataType = "String")]
        public String ManufacturerCode
        {
            get { return _ManufacturerCode; }
            set { _ManufacturerCode = value; }
        }
        [Column(Name = "ManufacturerName", DataType = "String")]
        public String ManufacturerName
        {
            get { return _ManufacturerName; }
            set { _ManufacturerName = value; }
        }
        [Column(Name = "OldPrice", DataType = "Decimal")]
        public Decimal OldPrice
        {
            get { return _OldPrice; }
            set { _OldPrice = value; }
        }
        [Column(Name = "LatestPrice", DataType = "Decimal")]
        public Decimal LatestPrice
        {
            get { return _LatestPrice; }
            set { _LatestPrice = value; }
        }
        [Column(Name = "BasePrice", DataType = "Decimal")]
        public Decimal BasePrice
        {
            get { return _BasePrice; }
            set { _BasePrice = value; }
        }
        [Column(Name = "AveragePrice", DataType = "Decimal")]
        public Decimal AveragePrice
        {
            get { return _AveragePrice; }
            set { _AveragePrice = value; }
        }
        [Column(Name = "SalesPrice", DataType = "Double")]
        public Double SalesPrice
        {
            get { return _SalesPrice; }
            set { _SalesPrice = value; }
        }
        [Column(Name = "Discount", DataType = "Double")]
        public Double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        [Column(Name = "Discount2", DataType = "Double")]
        public Double Discount2
        {
            get { return _Discount2; }
            set { _Discount2 = value; }
        }
        [Column(Name = "VAT", DataType = "Double")]
        public Double VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }
    }
    #endregion
    #region vGeneralLogisticItemAdjustment
    [Serializable]
    [Table(Name = "vGeneralLogisticItemAdjustment")]
    public class vGeneralLogisticItemAdjustment
    {
        private String _AdjustmentNo;
        private DateTime _AdjustmentDate;
        private String _AdjustmentDateText;
        private String _WarehouseCode;
        private String _WarehouseName;
        private Boolean _IsApproved;
        private String _LocationCode;
        private String _LocationName;
        private String _ItemCode;
        private String _ItemName;
        private Double _Qty;
        private String _Unit;
        private String _Reason;
        private String _Updater;
        private Decimal _Price;

        [Column(Name = "AdjustmentNo", DataType = "String")]
        public String AdjustmentNo
        {
            get { return _AdjustmentNo; }
            set { _AdjustmentNo = value; }
        }
        [Column(Name = "AdjustmentDate", DataType = "DateTime")]
        public DateTime AdjustmentDate
        {
            get { return _AdjustmentDate; }
            set { _AdjustmentDate = value; }
        }
        [Column(Name = "AdjustmentDateText", DataType = "String")]
        public String AdjustmentDateText
        {
            get { return _AdjustmentDateText; }
            set { _AdjustmentDateText = value; }
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
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
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
        [Column(Name = "Qty", DataType = "Double")]
        public Double Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Reason", DataType = "String")]
        public String Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }
        [Column(Name = "Updater", DataType = "String")]
        public String Updater
        {
            get { return _Updater; }
            set { _Updater = value; }
        }
        [Column(Name = "Price", DataType = "Decimal")]
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
    }
    #endregion
    #region vGeneralLogisticItemConsumption
    [Serializable]
    [Table(Name = "vGeneralLogisticItemConsumption")]
    public class vGeneralLogisticItemConsumption
    {
        private String _ConsumptionNo;
        private DateTime _ConsumptionDate;
        private String _ConsumptionDateText;
        private String _DepartmentCode;
        private String _DepartmentName;
        private String _WarehouseCode;
        private String _WarehouseName;
        private Boolean _IsApproved;
        private String _LocationCode;
        private String _LocationName;
        private String _ItemCode;
        private String _ItemName;
        private Double _Qty;
        private String _Unit;
        private Decimal _Price;

        [Column(Name = "ConsumptionNo", DataType = "String")]
        public String ConsumptionNo
        {
            get { return _ConsumptionNo; }
            set { _ConsumptionNo = value; }
        }
        [Column(Name = "ConsumptionDate", DataType = "DateTime")]
        public DateTime ConsumptionDate
        {
            get { return _ConsumptionDate; }
            set { _ConsumptionDate = value; }
        }
        [Column(Name = "ConsumptionDateText", DataType = "String")]
        public String ConsumptionDateText
        {
            get { return _ConsumptionDateText; }
            set { _ConsumptionDateText = value; }
        }
        [Column(Name = "DepartmentCode", DataType = "String")]
        public String DepartmentCode
        {
            get { return _DepartmentCode; }
            set { _DepartmentCode = value; }
        }
        [Column(Name = "DepartmentName", DataType = "String")]
        public String DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
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
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
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
        [Column(Name = "Qty", DataType = "Double")]
        public Double Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Price", DataType = "Decimal")]
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
    }
    #endregion
    #region vGeneralLogisticItemDistribution
    [Serializable]
    [Table(Name = "vGeneralLogisticItemDistribution")]
    public class vGeneralLogisticItemDistribution
    {
        private String _DistributionNo;
        private DateTime _DistributionDate;
        private String _DistributionDateText;
        private String _DistributionType;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private String _OtherWarehouseCode;
        private String _OtherWarehouseName;
        private String _OtherLocationCode;
        private String _OtherLocationName;
        private String _ItemCode;
        private String _ItemName;
        private Decimal _Qty;
        private String _Unit;
        private String _Updater;

        [Column(Name = "DistributionNo", DataType = "String")]
        public String DistributionNo
        {
            get { return _DistributionNo; }
            set { _DistributionNo = value; }
        }
        [Column(Name = "DistributionDate", DataType = "DateTime")]
        public DateTime DistributionDate
        {
            get { return _DistributionDate; }
            set { _DistributionDate = value; }
        }
        [Column(Name = "DistributionDateText", DataType = "String")]
        public String DistributionDateText
        {
            get { return _DistributionDateText; }
            set { _DistributionDateText = value; }
        }
        [Column(Name = "DistributionType", DataType = "String")]
        public String DistributionType
        {
            get { return _DistributionType; }
            set { _DistributionType = value; }
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
        [Column(Name = "OtherWarehouseCode", DataType = "String")]
        public String OtherWarehouseCode
        {
            get { return _OtherWarehouseCode; }
            set { _OtherWarehouseCode = value; }
        }
        [Column(Name = "OtherWarehouseName", DataType = "String")]
        public String OtherWarehouseName
        {
            get { return _OtherWarehouseName; }
            set { _OtherWarehouseName = value; }
        }
        [Column(Name = "OtherLocationCode", DataType = "String")]
        public String OtherLocationCode
        {
            get { return _OtherLocationCode; }
            set { _OtherLocationCode = value; }
        }
        [Column(Name = "OtherLocationName", DataType = "String")]
        public String OtherLocationName
        {
            get { return _OtherLocationName; }
            set { _OtherLocationName = value; }
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
        [Column(Name = "Qty", DataType = "Decimal")]
        public Decimal Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Updater", DataType = "String")]
        public String Updater
        {
            get { return _Updater; }
            set { _Updater = value; }
        }
    }
    #endregion
    #region vGeneralLogisticItemPriceAdjustment
    [Serializable]
    [Table(Name = "vGeneralLogisticItemPriceAdjustment")]
    public class vGeneralLogisticItemPriceAdjustment
    {
        private String _ItemCode;
        private String _ItemName;
        private Decimal _AveragePrice;
        private Decimal _BaseUnitPrice;
        private Decimal _BaseAlternatePrice;
        private Decimal _AvgPriceAfterVAT;
        private Decimal _NewAveragePrice;
        private Decimal _NewBaseUnitPrice;
        private Decimal _NewAlternateUnitPrice;
        private Decimal _NewAvgPriceAfterVAT;
        private DateTime _UpdatedDate;
        private String _UpdatedDateText;
        private String _UpdatedUser;
        private Double _LastQuantity;

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
        [Column(Name = "AveragePrice", DataType = "Decimal")]
        public Decimal AveragePrice
        {
            get { return _AveragePrice; }
            set { _AveragePrice = value; }
        }
        [Column(Name = "BaseUnitPrice", DataType = "Decimal")]
        public Decimal BaseUnitPrice
        {
            get { return _BaseUnitPrice; }
            set { _BaseUnitPrice = value; }
        }
        [Column(Name = "BaseAlternatePrice", DataType = "Decimal")]
        public Decimal BaseAlternatePrice
        {
            get { return _BaseAlternatePrice; }
            set { _BaseAlternatePrice = value; }
        }
        [Column(Name = "AvgPriceAfterVAT", DataType = "Decimal")]
        public Decimal AvgPriceAfterVAT
        {
            get { return _AvgPriceAfterVAT; }
            set { _AvgPriceAfterVAT = value; }
        }
        [Column(Name = "NewAveragePrice", DataType = "Decimal")]
        public Decimal NewAveragePrice
        {
            get { return _NewAveragePrice; }
            set { _NewAveragePrice = value; }
        }
        [Column(Name = "NewBaseUnitPrice", DataType = "Decimal")]
        public Decimal NewBaseUnitPrice
        {
            get { return _NewBaseUnitPrice; }
            set { _NewBaseUnitPrice = value; }
        }
        [Column(Name = "NewAlternateUnitPrice", DataType = "Decimal")]
        public Decimal NewAlternateUnitPrice
        {
            get { return _NewAlternateUnitPrice; }
            set { _NewAlternateUnitPrice = value; }
        }
        [Column(Name = "NewAvgPriceAfterVAT", DataType = "Decimal")]
        public Decimal NewAvgPriceAfterVAT
        {
            get { return _NewAvgPriceAfterVAT; }
            set { _NewAvgPriceAfterVAT = value; }
        }
        [Column(Name = "UpdatedDate", DataType = "DateTime")]
        public DateTime UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }
        [Column(Name = "UpdatedDateText", DataType = "String")]
        public String UpdatedDateText
        {
            get { return _UpdatedDateText; }
            set { _UpdatedDateText = value; }
        }
        [Column(Name = "UpdatedUser", DataType = "String")]
        public String UpdatedUser
        {
            get { return _UpdatedUser; }
            set { _UpdatedUser = value; }
        }
        [Column(Name = "LastQuantity", DataType = "Double")]
        public Double LastQuantity
        {
            get { return _LastQuantity; }
            set { _LastQuantity = value; }
        }
    }
    #endregion
    #region vGeneralLogisticItemProduction
    [Serializable]
    [Table(Name = "vGeneralLogisticItemProduction")]
    public class vGeneralLogisticItemProduction
    {
        private String _ProductionNo;
        private DateTime _ProductionDate;
        private String _ProductionDateText;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private String _ItemCode;
        private String _ItemName;
        private Double _Qty;
        private String _Unit;
        private Double _Price;
        private Double _ProductionCost;
        private Boolean _IsApproved;
        private String _ComponentItemCode;
        private String _ComponentItemName;
        private Double _ComponentQty;
        private String _ComponentUnit;

        [Column(Name = "ProductionNo", DataType = "String")]
        public String ProductionNo
        {
            get { return _ProductionNo; }
            set { _ProductionNo = value; }
        }
        [Column(Name = "ProductionDate", DataType = "DateTime")]
        public DateTime ProductionDate
        {
            get { return _ProductionDate; }
            set { _ProductionDate = value; }
        }
        [Column(Name = "ProductionDateText", DataType = "String")]
        public String ProductionDateText
        {
            get { return _ProductionDateText; }
            set { _ProductionDateText = value; }
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
        [Column(Name = "Qty", DataType = "Double")]
        public Double Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Price", DataType = "Double")]
        public Double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Column(Name = "ProductionCost", DataType = "Double")]
        public Double ProductionCost
        {
            get { return _ProductionCost; }
            set { _ProductionCost = value; }
        }
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
        [Column(Name = "ComponentItemCode", DataType = "String")]
        public String ComponentItemCode
        {
            get { return _ComponentItemCode; }
            set { _ComponentItemCode = value; }
        }
        [Column(Name = "ComponentItemName", DataType = "String")]
        public String ComponentItemName
        {
            get { return _ComponentItemName; }
            set { _ComponentItemName = value; }
        }
        [Column(Name = "ComponentQty", DataType = "Double")]
        public Double ComponentQty
        {
            get { return _ComponentQty; }
            set { _ComponentQty = value; }
        }
        [Column(Name = "ComponentUnit", DataType = "String")]
        public String ComponentUnit
        {
            get { return _ComponentUnit; }
            set { _ComponentUnit = value; }
        }
    }
    #endregion
    #region vGeneralLogisticPurchaseOrder
    [Serializable]
    [Table(Name = "vGeneralLogisticPurchaseOrder")]
    public class vGeneralLogisticPurchaseOrder
    {
        private String _PurchaseOrderNo;
        private String _SupplierCode;
        private String _SupplierName;
        private DateTime _PurchaseOrderDate;
        private String _PurchaseOrderDateText;
        private DateTime _OrderDeliveryDate;
        private String _OrderDeliveryDateText;
        private String _PurchaseRequestNo;
        private String _ItemCode;
        private String _ItemName;
        private Double _OrderQty;
        private String _Unit;
        private Decimal _Price;
        private Double _Discount1;
        private Double _Discount2;
        private String _PurchaseOrderStatusCode;
        private String _PurchaseOrderStatus;
        private Decimal _DownPayment;
        private String _VoucherNo;

        [Column(Name = "PurchaseOrderNo", DataType = "String")]
        public String PurchaseOrderNo
        {
            get { return _PurchaseOrderNo; }
            set { _PurchaseOrderNo = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }
        [Column(Name = "PurchaseOrderDate", DataType = "DateTime")]
        public DateTime PurchaseOrderDate
        {
            get { return _PurchaseOrderDate; }
            set { _PurchaseOrderDate = value; }
        }
        [Column(Name = "PurchaseOrderDateText", DataType = "String")]
        public String PurchaseOrderDateText
        {
            get { return _PurchaseOrderDateText; }
            set { _PurchaseOrderDateText = value; }
        }
        [Column(Name = "OrderDeliveryDate", DataType = "DateTime")]
        public DateTime OrderDeliveryDate
        {
            get { return _OrderDeliveryDate; }
            set { _OrderDeliveryDate = value; }
        }
        [Column(Name = "OrderDeliveryDateText", DataType = "String")]
        public String OrderDeliveryDateText
        {
            get { return _OrderDeliveryDateText; }
            set { _OrderDeliveryDateText = value; }
        }
        [Column(Name = "PurchaseRequestNo", DataType = "String")]
        public String PurchaseRequestNo
        {
            get { return _PurchaseRequestNo; }
            set { _PurchaseRequestNo = value; }
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
        [Column(Name = "OrderQty", DataType = "Double")]
        public Double OrderQty
        {
            get { return _OrderQty; }
            set { _OrderQty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Price", DataType = "Decimal")]
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Column(Name = "Discount1", DataType = "Double")]
        public Double Discount1
        {
            get { return _Discount1; }
            set { _Discount1 = value; }
        }
        [Column(Name = "Discount2", DataType = "Double")]
        public Double Discount2
        {
            get { return _Discount2; }
            set { _Discount2 = value; }
        }
        [Column(Name = "PurchaseOrderStatusCode", DataType = "String")]
        public String PurchaseOrderStatusCode
        {
            get { return _PurchaseOrderStatusCode; }
            set { _PurchaseOrderStatusCode = value; }
        }
        [Column(Name = "PurchaseOrderStatus", DataType = "String")]
        public String PurchaseOrderStatus
        {
            get { return _PurchaseOrderStatus; }
            set { _PurchaseOrderStatus = value; }
        }
        [Column(Name = "DownPayment", DataType = "Decimal")]
        public Decimal DownPayment
        {
            get { return _DownPayment; }
            set { _DownPayment = value; }
        }
        [Column(Name = "VoucherNo", DataType = "String")]
        public String VoucherNo
        {
            get { return _VoucherNo; }
            set { _VoucherNo = value; }
        }
    }
    #endregion
    #region vGeneralLogisticPurchaseOrderReceived
    [Serializable]
    [Table(Name = "vGeneralLogisticPurchaseOrderReceived")]
    public class vGeneralLogisticPurchaseOrderReceived
    {
        private String _PurchaseOrderNo;
        private DateTime _PurchaseOrderDate;
        private String _PurchaseOrderDateText;
        private DateTime _PurchaseOrderDeliveryDate;
        private String _PurchaseOrderDeliveryDateText;
        private String _SupplierCode;
        private String _SupplierName;
        private String _ItemCode;
        private String _ItemName;
        private Double _PurchaseOrderQty;
        private String _PurchaseOrderUnit;
        private String _PurchaseReceiveNo;
        private DateTime _PurchaseReceiveDate;
        private String _PurchaseReceiveDateText;
        private Double _PurchaseReceiveQty;
        private String _PurchaseReceiveUnit;
        private Int32 _DurationByOrderDate;
        private Int32 _DurationByDeliveryDate;
        private Boolean _IsOutstanding;

        [Column(Name = "PurchaseOrderNo", DataType = "String")]
        public String PurchaseOrderNo
        {
            get { return _PurchaseOrderNo; }
            set { _PurchaseOrderNo = value; }
        }
        [Column(Name = "PurchaseOrderDate", DataType = "DateTime")]
        public DateTime PurchaseOrderDate
        {
            get { return _PurchaseOrderDate; }
            set { _PurchaseOrderDate = value; }
        }
        [Column(Name = "PurchaseOrderDateText", DataType = "String")]
        public String PurchaseOrderDateText
        {
            get { return _PurchaseOrderDateText; }
            set { _PurchaseOrderDateText = value; }
        }
        [Column(Name = "PurchaseOrderDeliveryDate", DataType = "DateTime")]
        public DateTime PurchaseOrderDeliveryDate
        {
            get { return _PurchaseOrderDeliveryDate; }
            set { _PurchaseOrderDeliveryDate = value; }
        }
        [Column(Name = "PurchaseOrderDeliveryDateText", DataType = "String")]
        public String PurchaseOrderDeliveryDateText
        {
            get { return _PurchaseOrderDeliveryDateText; }
            set { _PurchaseOrderDeliveryDateText = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
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
        [Column(Name = "PurchaseOrderQty", DataType = "Double")]
        public Double PurchaseOrderQty
        {
            get { return _PurchaseOrderQty; }
            set { _PurchaseOrderQty = value; }
        }
        [Column(Name = "PurchaseOrderUnit", DataType = "String")]
        public String PurchaseOrderUnit
        {
            get { return _PurchaseOrderUnit; }
            set { _PurchaseOrderUnit = value; }
        }
        [Column(Name = "PurchaseReceiveNo", DataType = "String")]
        public String PurchaseReceiveNo
        {
            get { return _PurchaseReceiveNo; }
            set { _PurchaseReceiveNo = value; }
        }
        [Column(Name = "PurchaseReceiveDate", DataType = "DateTime")]
        public DateTime PurchaseReceiveDate
        {
            get { return _PurchaseReceiveDate; }
            set { _PurchaseReceiveDate = value; }
        }
        [Column(Name = "PurchaseReceiveDateText", DataType = "String")]
        public String PurchaseReceiveDateText
        {
            get { return _PurchaseReceiveDateText; }
            set { _PurchaseReceiveDateText = value; }
        }
        [Column(Name = "PurchaseReceiveQty", DataType = "Double")]
        public Double PurchaseReceiveQty
        {
            get { return _PurchaseReceiveQty; }
            set { _PurchaseReceiveQty = value; }
        }
        [Column(Name = "PurchaseReceiveUnit", DataType = "String")]
        public String PurchaseReceiveUnit
        {
            get { return _PurchaseReceiveUnit; }
            set { _PurchaseReceiveUnit = value; }
        }
        [Column(Name = "DurationByOrderDate", DataType = "Int32")]
        public Int32 DurationByOrderDate
        {
            get { return _DurationByOrderDate; }
            set { _DurationByOrderDate = value; }
        }
        [Column(Name = "DurationByDeliveryDate", DataType = "Int32")]
        public Int32 DurationByDeliveryDate
        {
            get { return _DurationByDeliveryDate; }
            set { _DurationByDeliveryDate = value; }
        }
        [Column(Name = "IsOutstanding", DataType = "Boolean")]
        public Boolean IsOutstanding
        {
            get { return _IsOutstanding; }
            set { _IsOutstanding = value; }
        }
    }
    #endregion
    #region vGeneralLogisticPurchaseReceive
    [Serializable]
    [Table(Name = "vGeneralLogisticPurchaseReceive")]
    public class vGeneralLogisticPurchaseReceive
    {
        private String _PurchaseReceiveNo;
        private String _DeliveryNo;
        private String _SupplierCode;
        private String _SupplierName;
        private DateTime _PurchaseReceiveDate;
        private String _PurchaseReceiveDateText;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private Decimal _HeaderDiscount;
        private Double _HeaderVAT;
        private Decimal _HeaderDeliveryFee;
        private Decimal _HeaderSealFee;
        private String _ItemCode;
        private String _ItemName;
        private String _Unit;
        private Double _ReceiveQty;
        private Decimal _ItemPrice;
        private Decimal _ItemDiscount;
        private Decimal _ItemDiscount2;
        private String _PurchaseOrderNo;
        private Boolean _IsBonus;
        private String _ManufacturerCode;
        private String _ManufacturerName;

        [Column(Name = "PurchaseReceiveNo", DataType = "String")]
        public String PurchaseReceiveNo
        {
            get { return _PurchaseReceiveNo; }
            set { _PurchaseReceiveNo = value; }
        }
        [Column(Name = "DeliveryNo", DataType = "String")]
        public String DeliveryNo
        {
            get { return _DeliveryNo; }
            set { _DeliveryNo = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }
        [Column(Name = "PurchaseReceiveDate", DataType = "DateTime")]
        public DateTime PurchaseReceiveDate
        {
            get { return _PurchaseReceiveDate; }
            set { _PurchaseReceiveDate = value; }
        }
        [Column(Name = "PurchaseReceiveDateText", DataType = "String")]
        public String PurchaseReceiveDateText
        {
            get { return _PurchaseReceiveDateText; }
            set { _PurchaseReceiveDateText = value; }
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
        [Column(Name = "HeaderDiscount", DataType = "Decimal")]
        public Decimal HeaderDiscount
        {
            get { return _HeaderDiscount; }
            set { _HeaderDiscount = value; }
        }
        [Column(Name = "HeaderVAT", DataType = "Double")]
        public Double HeaderVAT
        {
            get { return _HeaderVAT; }
            set { _HeaderVAT = value; }
        }
        [Column(Name = "HeaderDeliveryFee", DataType = "Decimal")]
        public Decimal HeaderDeliveryFee
        {
            get { return _HeaderDeliveryFee; }
            set { _HeaderDeliveryFee = value; }
        }
        [Column(Name = "HeaderSealFee", DataType = "Decimal")]
        public Decimal HeaderSealFee
        {
            get { return _HeaderSealFee; }
            set { _HeaderSealFee = value; }
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
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "ReceiveQty", DataType = "Double")]
        public Double ReceiveQty
        {
            get { return _ReceiveQty; }
            set { _ReceiveQty = value; }
        }
        [Column(Name = "ItemPrice", DataType = "Decimal")]
        public Decimal ItemPrice
        {
            get { return _ItemPrice; }
            set { _ItemPrice = value; }
        }
        [Column(Name = "ItemDiscount", DataType = "Decimal")]
        public Decimal ItemDiscount
        {
            get { return _ItemDiscount; }
            set { _ItemDiscount = value; }
        }
        [Column(Name = "ItemDiscount2", DataType = "Decimal")]
        public Decimal ItemDiscount2
        {
            get { return _ItemDiscount2; }
            set { _ItemDiscount2 = value; }
        }
        [Column(Name = "PurchaseOrderNo", DataType = "String")]
        public String PurchaseOrderNo
        {
            get { return _PurchaseOrderNo; }
            set { _PurchaseOrderNo = value; }
        }
        [Column(Name = "IsBonus", DataType = "Boolean")]
        public Boolean IsBonus
        {
            get { return _IsBonus; }
            set { _IsBonus = value; }
        }
        [Column(Name = "ManufacturerCode", DataType = "String")]
        public String ManufacturerCode
        {
            get { return _ManufacturerCode; }
            set { _ManufacturerCode = value; }
        }
        [Column(Name = "ManufacturerName", DataType = "String")]
        public String ManufacturerName
        {
            get { return _ManufacturerName; }
            set { _ManufacturerName = value; }
        }
    }
    #endregion
    #region vGeneralLogisticPurchaseRequest
    [Serializable]
    [Table(Name = "vGeneralLogisticPurchaseRequest")]
    public class vGeneralLogisticPurchaseRequest
    {
        private String _PurchaseRequestNo;
        private DateTime _PurchaseRequestDate;
        private String _PurchaseRequestDateText;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private Boolean _IsHeaderPosting;
        private String _HeaderUpdater;
        private String _SupplierCode;
        private String _SupplierName;
        private String _ItemCode;
        private String _ItemName;
        private String _CatalogNo;
        private String _ProductLineCode;
        private String _ProductLine;
        private String _Unit;
        private Double _UnitFactor;
        private Decimal _Price;
        private Double _RequestQty;
        private Double _ProcessedQty;
        private String _DetailUpdater;
        private DateTime _ApprovalDate;
        private String _ApprovalDateText;
        private Boolean _IsProcessed;
        private Boolean _IsApproved;
        private Double _Discount;

        [Column(Name = "PurchaseRequestNo", DataType = "String")]
        public String PurchaseRequestNo
        {
            get { return _PurchaseRequestNo; }
            set { _PurchaseRequestNo = value; }
        }
        [Column(Name = "PurchaseRequestDate", DataType = "DateTime")]
        public DateTime PurchaseRequestDate
        {
            get { return _PurchaseRequestDate; }
            set { _PurchaseRequestDate = value; }
        }
        [Column(Name = "PurchaseRequestDateText", DataType = "String")]
        public String PurchaseRequestDateText
        {
            get { return _PurchaseRequestDateText; }
            set { _PurchaseRequestDateText = value; }
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
        [Column(Name = "IsHeaderPosting", DataType = "Boolean")]
        public Boolean IsHeaderPosting
        {
            get { return _IsHeaderPosting; }
            set { _IsHeaderPosting = value; }
        }
        [Column(Name = "HeaderUpdater", DataType = "String")]
        public String HeaderUpdater
        {
            get { return _HeaderUpdater; }
            set { _HeaderUpdater = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
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
        [Column(Name = "CatalogNo", DataType = "String")]
        public String CatalogNo
        {
            get { return _CatalogNo; }
            set { _CatalogNo = value; }
        }
        [Column(Name = "ProductLineCode", DataType = "String")]
        public String ProductLineCode
        {
            get { return _ProductLineCode; }
            set { _ProductLineCode = value; }
        }
        [Column(Name = "ProductLine", DataType = "String")]
        public String ProductLine
        {
            get { return _ProductLine; }
            set { _ProductLine = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "UnitFactor", DataType = "Double")]
        public Double UnitFactor
        {
            get { return _UnitFactor; }
            set { _UnitFactor = value; }
        }
        [Column(Name = "Price", DataType = "Decimal")]
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Column(Name = "RequestQty", DataType = "Double")]
        public Double RequestQty
        {
            get { return _RequestQty; }
            set { _RequestQty = value; }
        }
        [Column(Name = "ProcessedQty", DataType = "Double")]
        public Double ProcessedQty
        {
            get { return _ProcessedQty; }
            set { _ProcessedQty = value; }
        }
        [Column(Name = "DetailUpdater", DataType = "String")]
        public String DetailUpdater
        {
            get { return _DetailUpdater; }
            set { _DetailUpdater = value; }
        }
        [Column(Name = "ApprovalDate", DataType = "DateTime")]
        public DateTime ApprovalDate
        {
            get { return _ApprovalDate; }
            set { _ApprovalDate = value; }
        }
        [Column(Name = "ApprovalDateText", DataType = "String")]
        public String ApprovalDateText
        {
            get { return _ApprovalDateText; }
            set { _ApprovalDateText = value; }
        }
        [Column(Name = "IsProcessed", DataType = "Boolean")]
        public Boolean IsProcessed
        {
            get { return _IsProcessed; }
            set { _IsProcessed = value; }
        }
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
        [Column(Name = "Discount", DataType = "Double")]
        public Double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
    }
    #endregion
    #region vGeneralLogisticPurchaseReturn
    [Serializable]
    [Table(Name = "vGeneralLogisticPurchaseReturn")]
    public class vGeneralLogisticPurchaseReturn
    {
        private String _PurchaseReturnNo;
        private DateTime _PurchaseReturnDate;
        private String _PurchaseReturnDateText;
        private String _SupplierCode;
        private String _SupplierName;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private String _ItemCode;
        private String _ItemName;
        private Double _ReturnQty;
        private String _Unit;
        private Decimal _Price;
        private Decimal _Discount;
        private Boolean _IsApproved;

        [Column(Name = "PurchaseReturnNo", DataType = "String")]
        public String PurchaseReturnNo
        {
            get { return _PurchaseReturnNo; }
            set { _PurchaseReturnNo = value; }
        }
        [Column(Name = "PurchaseReturnDate", DataType = "DateTime")]
        public DateTime PurchaseReturnDate
        {
            get { return _PurchaseReturnDate; }
            set { _PurchaseReturnDate = value; }
        }
        [Column(Name = "PurchaseReturnDateText", DataType = "String")]
        public String PurchaseReturnDateText
        {
            get { return _PurchaseReturnDateText; }
            set { _PurchaseReturnDateText = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
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
        [Column(Name = "ReturnQty", DataType = "Double")]
        public Double ReturnQty
        {
            get { return _ReturnQty; }
            set { _ReturnQty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Price", DataType = "Decimal")]
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Column(Name = "Discount", DataType = "Decimal")]
        public Decimal Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
    }
    #endregion
    #region vGeneralLogisticStockInitialization
    [Serializable]
    [Table(Name = "vGeneralLogisticStockInitialization")]
    public class vGeneralLogisticStockInitialization
    {
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private String _ItemCode;
        private String _ItemName;
        private Decimal _Price;
        private Double _Qty;
        private String _Unit;
        private Boolean _IsApproved;
        private DateTime _InitializationDate;
        private String _InitializationDateText;
        private String _Updater;

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
        [Column(Name = "Price", DataType = "Decimal")]
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Column(Name = "Qty", DataType = "Double")]
        public Double Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
        [Column(Name = "InitializationDate", DataType = "DateTime")]
        public DateTime InitializationDate
        {
            get { return _InitializationDate; }
            set { _InitializationDate = value; }
        }
        [Column(Name = "InitializationDateText", DataType = "String")]
        public String InitializationDateText
        {
            get { return _InitializationDateText; }
            set { _InitializationDateText = value; }
        }
        [Column(Name = "Updater", DataType = "String")]
        public String Updater
        {
            get { return _Updater; }
            set { _Updater = value; }
        }
    }
    #endregion
    #region vGeneralLogisticStockOpnameResult
    [Serializable]
    [Table(Name = "vGeneralLogisticStockOpnameResult")]
    public class vGeneralLogisticStockOpnameResult
    {
        private String _StockOpnameNo;
        private DateTime _StockOpnameDate;
        private String _StockOpnameDateText;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private String _ItemCode;
        private String _ItemName;
        private String _ProductLine;
        private Double _Qty;
        private String _Unit;
        private Double _ResultQty;
        private Boolean _IsDifference;
        private Double _StockPrice;

        [Column(Name = "StockOpnameNo", DataType = "String")]
        public String StockOpnameNo
        {
            get { return _StockOpnameNo; }
            set { _StockOpnameNo = value; }
        }
        [Column(Name = "StockOpnameDate", DataType = "DateTime")]
        public DateTime StockOpnameDate
        {
            get { return _StockOpnameDate; }
            set { _StockOpnameDate = value; }
        }
        [Column(Name = "StockOpnameDateText", DataType = "String")]
        public String StockOpnameDateText
        {
            get { return _StockOpnameDateText; }
            set { _StockOpnameDateText = value; }
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
        [Column(Name = "Qty", DataType = "Double")]
        public Double Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "ResultQty", DataType = "Double")]
        public Double ResultQty
        {
            get { return _ResultQty; }
            set { _ResultQty = value; }
        }
        [Column(Name = "IsDifference", DataType = "Boolean")]
        public Boolean IsDifference
        {
            get { return _IsDifference; }
            set { _IsDifference = value; }
        }
        [Column(Name = "StockPrice", DataType = "Double")]
        public Double StockPrice
        {
            get { return _StockPrice; }
            set { _StockPrice = value; }
        }
    }
    #endregion
    #region vHealthcare
    [Serializable]
    [Table(Name = "vHealthcare")]
    public class vHealthcare
    {
        private String _HealthcareID;
        private String _HealthcareName;
        private String _AddressLine1;
        private String _AddressLine2;
        private String _AddressLine3;
        private String _PhoneNo1;
        private String _PhoneNo2;
        private String _FaxNo1;

        [Column(Name = "HealthcareID", DataType = "String")]
        public String HealthcareID
        {
            get { return _HealthcareID; }
            set { _HealthcareID = value; }
        }

        [Column(Name = "HealthcareName", DataType = "String")]
        public String HealthcareName
        {
            get { return _HealthcareName; }
            set { _HealthcareName = value; }
        }

        [Column(Name = "AddressLine1", DataType = "String")]
        public String AddressLine1
        {
            get { return _AddressLine1; }
            set { _AddressLine1 = value; }
        }

        [Column(Name = "AddressLine2", DataType = "String")]
        public String AddressLine2
        {
            get { return _AddressLine2; }
            set { _AddressLine2 = value; }
        }

        [Column(Name = "AddressLine3", DataType = "String")]
        public String AddressLine3
        {
            get { return _AddressLine3; }
            set { _AddressLine3 = value; }
        }

        [Column(Name = "PhoneNo1", DataType = "String")]
        public String PhoneNo1
        {
            get { return _PhoneNo1; }
            set { _PhoneNo1 = value; }
        }

        [Column(Name = "PhoneNo2", DataType = "String")]
        public String PhoneNo2
        {
            get { return _PhoneNo2; }
            set { _PhoneNo2 = value; }
        }

        [Column(Name = "FaxNo1", DataType = "String")]
        public String FaxNo1
        {
            get { return _FaxNo1; }
            set { _FaxNo1 = value; }
        }
    }
    #endregion
    #region vHealthcareProfessional
    [Serializable]
    [Table(Name = "vHealthcareProfessional")]
    public class vHealthcareProfessional
    {
        private String _HealthcareProfessionalCode;
        private String _HealthcareProfessionalName;
        private String _HealhtcareProfessionalType;
        private DateTime _DateOfBirth;
        private String _SpecialtyCode;
        private String _SpecialtyName;
        private String _PhysicianType;
        private Boolean _IsActive;

        [Column(Name = "HealthcareProfessionalCode", DataType = "String")]
        public String HealthcareProfessionalCode
        {
            get { return _HealthcareProfessionalCode; }
            set { _HealthcareProfessionalCode = value; }
        }
        [Column(Name = "HealthcareProfessionalName", DataType = "String")]
        public String HealthcareProfessionalName
        {
            get { return _HealthcareProfessionalName; }
            set { _HealthcareProfessionalName = value; }
        }
        [Column(Name = "HealhtcareProfessionalType", DataType = "String")]
        public String HealhtcareProfessionalType
        {
            get { return _HealhtcareProfessionalType; }
            set { _HealhtcareProfessionalType = value; }
        }
        [Column(Name = "DateOfBirth", DataType = "DateTime")]
        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }
        [Column(Name = "SpecialtyCode", DataType = "String")]
        public String SpecialtyCode
        {
            get { return _SpecialtyCode; }
            set { _SpecialtyCode = value; }
        }
        [Column(Name = "SpecialtyName", DataType = "String")]
        public String SpecialtyName
        {
            get { return _SpecialtyName; }
            set { _SpecialtyName = value; }
        }
        [Column(Name = "PhysicianType", DataType = "String")]
        public String PhysicianType
        {
            get { return _PhysicianType; }
            set { _PhysicianType = value; }
        }
        [Column(Name = "IsActive", DataType = "Boolean")]
        public Boolean IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
    }
    #endregion
    #region vInpatientDetailRegistration
    [Serializable]
    [Table(Name = "vRegistrationRI")]
    public partial class vInpatientDetailRegistration : vPatient
    {
        private DateTime _RegistrationDate;
        private String _RegistrationDateText;
        private String _RegistrationTime;
        private String _RegistrationNo;
        private String _Doctor;
        private String _RefferalCode;
        private String _RefferalNo;
        private String _RefferalName;
        private String _Payer;
        private String _WardName;
        private String _BedNumber;
        private String _Class;
        private String _ChargeClass;
        private String _CreatedBy;
        private Decimal _HospitalizedCount;
        private Boolean _IsNewPatient;
        private DateTime _DischargeDate;
        private String _DischargeDateText;
        private String _DischargeTime;
        private String _DischargeMethod;
        private String _DischargeCondition;
        private String _FollowUp;
        private Boolean _IsVoid;
        private String _ClassCode;
        private String _WardCode;
        private Boolean _IsPoliceCase;

        [Column(Name = "RegistrationDate", DataType = "DateTime")]
        public DateTime RegistrationDate
        {
            get { return _RegistrationDate; }
            set { _RegistrationDate = value; }
        }
        [Column(Name = "RegistrationDateText", DataType = "String")]
        public String RegistrationDateText
        {
            get { return _RegistrationDateText; }
            set { _RegistrationDateText = value; }
        }
        [Column(Name = "RegistrationTime", DataType = "String")]
        public String RegistrationTime
        {
            get { return _RegistrationTime; }
            set { _RegistrationTime = value; }
        }
        [Column(Name = "RegistrationNo", DataType = "String")]
        public String RegistrationNo
        {
            get { return _RegistrationNo; }
            set { _RegistrationNo = value; }
        }
        [Column(Name = "Doctor", DataType = "String")]
        public String Doctor
        {
            get { return _Doctor; }
            set { _Doctor = value; }
        }
        [Column(Name = "RefferalCode", DataType = "String")]
        public String RefferalCode
        {
            get { return _RefferalCode; }
            set { _RefferalCode = value; }
        }
        [Column(Name = "RefferalNo", DataType = "String")]
        public String RefferalNo
        {
            get { return _RefferalNo; }
            set { _RefferalNo = value; }
        }
        [Column(Name = "RefferalName", DataType = "String")]
        public String RefferalName
        {
            get { return _RefferalName; }
            set { _RefferalName = value; }
        }
        [Column(Name = "Payer", DataType = "String")]
        public String Payer
        {
            get { return _Payer; }
            set { _Payer = value; }
        }
        [Column(Name = "WardName", DataType = "String")]
        public String WardName
        {
            get { return _WardName; }
            set { _WardName = value; }
        }
        [Column(Name = "BedNumber", DataType = "String")]
        public String BedNumber
        {
            get { return _BedNumber; }
            set { _BedNumber = value; }
        }
        [Column(Name = "Class", DataType = "String")]
        public String Class
        {
            get { return _Class; }
            set { _Class = value; }
        }
        [Column(Name = "ChargeClass", DataType = "String")]
        public String ChargeClass
        {
            get { return _ChargeClass; }
            set { _ChargeClass = value; }
        }
        [Column(Name = "CreatedBy", DataType = "String")]
        public String CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        [Column(Name = "HospitalizedCount", DataType = "Decimal")]
        public Decimal HospitalizedCount
        {
            get { return _HospitalizedCount; }
            set { _HospitalizedCount = value; }
        }
        [Column(Name = "IsNewPatient", DataType = "Boolean")]
        public Boolean IsNewPatient
        {
            get { return _IsNewPatient; }
            set { _IsNewPatient = value; }
        }
        [Column(Name = "DischargeDate", DataType = "DateTime")]
        public DateTime DischargeDate
        {
            get { return _DischargeDate; }
            set { _DischargeDate = value; }
        }
        [Column(Name = "DischargeDateText", DataType = "String")]
        public String DischargeDateText
        {
            get { return _DischargeDateText; }
            set { _DischargeDateText = value; }
        }
        [Column(Name = "DischargeTime", DataType = "String")]
        public String DischargeTime
        {
            get { return _DischargeTime; }
            set { _DischargeTime = value; }
        }
        [Column(Name = "DischargeMethod", DataType = "String")]
        public String DischargeMethod
        {
            get { return _DischargeMethod; }
            set { _DischargeMethod = value; }
        }
        [Column(Name = "DischargeCondition", DataType = "String")]
        public String DischargeCondition
        {
            get { return _DischargeCondition; }
            set { _DischargeCondition = value; }
        }
        [Column(Name = "FollowUp", DataType = "String")]
        public String FollowUp
        {
            get { return _FollowUp; }
            set { _FollowUp = value; }
        }
        [Column(Name = "IsVoid", DataType = "Boolean")]
        public Boolean IsVoid
        {
            get { return _IsVoid; }
            set { _IsVoid = value; }
        }
        [Column(Name = "ClassCode", DataType = "String")]
        public String ClassCode
        {
            get { return _ClassCode; }
            set { _ClassCode = value; }
        }
        [Column(Name = "WardCode", DataType = "String")]
        public String WardCode
        {
            get { return _WardCode; }
            set { _WardCode = value; }
        }
        [Column(Name = "IsPoliceCase", DataType = "Boolean")]
        public Boolean IsPoliceCase
        {
            get { return _IsPoliceCase; }
            set { _IsPoliceCase = value; }
        }
    }
    #endregion
    #region vInpatientRevenue
    [Serializable]
    [Table(Name = "vInpatientRevenue")]
    public class vInpatientRevenue
    {
        private String _PaymentNo;
        private DateTime _PaymentDate;
        private String _PaymentDateText;
        private String _PaymentStatusCode;
        private String _PyamentStatusName;
        private String _RegistrationNo;
        private String _PatientFirstName;
        private String _PatientLastName;
        private String _PatientGender;
        private Decimal _BillAmount;
        private Decimal _PaymentAmount1;
        private Decimal _PaymentAmount2;
        private Decimal _PaymentAmount3;
        private Decimal _PaymentAmount4;
        private Decimal _PaymentAmount5;
        private Decimal _Discount;
        private Decimal _OtherBillAmount;
        private String _PaymentName;
        private String _Payer;
        private Boolean _IsVoid;
        private DateTime _UpdatedDate;
        private String _UpdatedBy;
        private String _Doctor;
        private String _TransactionType;
        private DateTime _TransactionDate;
        private String _ItemCode;
        private String _ItemName;
        private String _TransactionPhysician;
        private Double _ItemQty;
        private Double _PatientBillAmount;
        private Double _PayerBillAmount;

        [Column(Name = "PaymentNo", DataType = "String")]
        public String PaymentNo
        {
            get { return _PaymentNo; }
            set { _PaymentNo = value; }
        }
        [Column(Name = "PaymentDate", DataType = "DateTime")]
        public DateTime PaymentDate
        {
            get { return _PaymentDate; }
            set { _PaymentDate = value; }
        }
        [Column(Name = "PaymentDateText", DataType = "String")]
        public String PaymentDateText
        {
            get { return _PaymentDateText; }
            set { _PaymentDateText = value; }
        }
        [Column(Name = "PaymentStatusCode", DataType = "String")]
        public String PaymentStatusCode
        {
            get { return _PaymentStatusCode; }
            set { _PaymentStatusCode = value; }
        }
        [Column(Name = "PyamentStatusName", DataType = "String")]
        public String PyamentStatusName
        {
            get { return _PyamentStatusName; }
            set { _PyamentStatusName = value; }
        }
        [Column(Name = "RegistrationNo", DataType = "String")]
        public String RegistrationNo
        {
            get { return _RegistrationNo; }
            set { _RegistrationNo = value; }
        }
        [Column(Name = "PatientFirstName", DataType = "String")]
        public String PatientFirstName
        {
            get { return _PatientFirstName; }
            set { _PatientFirstName = value; }
        }
        [Column(Name = "PatientLastName", DataType = "String")]
        public String PatientLastName
        {
            get { return _PatientLastName; }
            set { _PatientLastName = value; }
        }
        [Column(Name = "PatientGender", DataType = "String")]
        public String PatientGender
        {
            get { return _PatientGender; }
            set { _PatientGender = value; }
        }
        [Column(Name = "BillAmount", DataType = "Decimal")]
        public Decimal BillAmount
        {
            get { return _BillAmount; }
            set { _BillAmount = value; }
        }
        [Column(Name = "PaymentAmount1", DataType = "Decimal")]
        public Decimal PaymentAmount1
        {
            get { return _PaymentAmount1; }
            set { _PaymentAmount1 = value; }
        }
        [Column(Name = "PaymentAmount2", DataType = "Decimal")]
        public Decimal PaymentAmount2
        {
            get { return _PaymentAmount2; }
            set { _PaymentAmount2 = value; }
        }
        [Column(Name = "PaymentAmount3", DataType = "Decimal")]
        public Decimal PaymentAmount3
        {
            get { return _PaymentAmount3; }
            set { _PaymentAmount3 = value; }
        }
        [Column(Name = "PaymentAmount4", DataType = "Decimal")]
        public Decimal PaymentAmount4
        {
            get { return _PaymentAmount4; }
            set { _PaymentAmount4 = value; }
        }
        [Column(Name = "PaymentAmount5", DataType = "Decimal")]
        public Decimal PaymentAmount5
        {
            get { return _PaymentAmount5; }
            set { _PaymentAmount5 = value; }
        }
        [Column(Name = "Discount", DataType = "Decimal")]
        public Decimal Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        [Column(Name = "OtherBillAmount", DataType = "Decimal")]
        public Decimal OtherBillAmount
        {
            get { return _OtherBillAmount; }
            set { _OtherBillAmount = value; }
        }
        [Column(Name = "PaymentName", DataType = "String")]
        public String PaymentName
        {
            get { return _PaymentName; }
            set { _PaymentName = value; }
        }
        [Column(Name = "Payer", DataType = "String")]
        public String Payer
        {
            get { return _Payer; }
            set { _Payer = value; }
        }
        [Column(Name = "IsVoid", DataType = "Boolean")]
        public Boolean IsVoid
        {
            get { return _IsVoid; }
            set { _IsVoid = value; }
        }
        [Column(Name = "UpdatedDate", DataType = "DateTime")]
        public DateTime UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }
        [Column(Name = "UpdatedBy", DataType = "String")]
        public String UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
        [Column(Name = "Doctor", DataType = "String")]
        public String Doctor
        {
            get { return _Doctor; }
            set { _Doctor = value; }
        }
        [Column(Name = "TransactionType", DataType = "String")]
        public String TransactionType
        {
            get { return _TransactionType; }
            set { _TransactionType = value; }
        }
        [Column(Name = "TransactionDate", DataType = "DateTime")]
        public DateTime TransactionDate
        {
            get { return _TransactionDate; }
            set { _TransactionDate = value; }
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
        [Column(Name = "TransactionPhysician", DataType = "String")]
        public String TransactionPhysician
        {
            get { return _TransactionPhysician; }
            set { _TransactionPhysician = value; }
        }
        [Column(Name = "ItemQty", DataType = "Double")]
        public Double ItemQty
        {
            get { return _ItemQty; }
            set { _ItemQty = value; }
        }
        [Column(Name = "PatientBillAmount", DataType = "Double")]
        public Double PatientBillAmount
        {
            get { return _PatientBillAmount; }
            set { _PatientBillAmount = value; }
        }
        [Column(Name = "PayerBillAmount", DataType = "Double")]
        public Double PayerBillAmount
        {
            get { return _PayerBillAmount; }
            set { _PayerBillAmount = value; }
        }
    }
    #endregion
    #region vInpatientTransaction
    [Serializable]
    [Table(Name = "vInpatientTransaction")]
    public class vInpatientTransaction : vRegistrationRI
    {
        private String _TransactionType;
        private String _TransactionNo;
        private DateTime _TransactionDate;
        private String _TransactionTime;
        private String _TransactionPhysician;
        private String _TransactionRoomName;
        private String _ItemCode;
        private String _ItemName;
        private Double _ItemQty;
        private String _ItemUnit;
        private Double _CompTrf1;
        private Decimal _CompTrf2;
        private Decimal _CompTrf3;
        private Decimal _CompTrf4;
        private Decimal _Deductible1;
        private Decimal _Deductible2;
        private Decimal _Deductible3;
        private Decimal _Deductible4;
        private Double _Discount1;
        private Decimal _Discount2;
        private Decimal _Discount3;
        private Decimal _Discount4;
        private Decimal _BasePrice1;
        private Decimal _BasePrice2;
        private Decimal _BasePrice3;
        private Decimal _BasePrice4;
        private Decimal _CitoAmount;
        private Decimal _CitoDiscAmount;
        private Decimal _CitoDeductAmount;
        private Decimal _ComplicationAmount;
        private Decimal _ComplicationDiscAmount;
        private Decimal _ComplicationDeducAmount;
        private Double _PatientBillAmount;
        private Double _PayerBillAmount;
        private Int32 _IsVariablePrice;
        private Int32 _IsFreeOfCharge;
        private Int32 _IsApproved;
        private DateTime _UpdatedDate;
        private String _UpdatedBy;
        private String _MedicalDiagnostic;

        [Column(Name = "TransactionType", DataType = "String")]
        public String TransactionType
        {
            get { return _TransactionType; }
            set { _TransactionType = value; }
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
        [Column(Name = "TransactionTime", DataType = "String")]
        public String TransactionTime
        {
            get { return _TransactionTime; }
            set { _TransactionTime = value; }
        }
        [Column(Name = "TransactionPhysician", DataType = "String")]
        public String TransactionPhysician
        {
            get { return _TransactionPhysician; }
            set { _TransactionPhysician = value; }
        }
        [Column(Name = "TransactionRoomName", DataType = "String")]
        public String TransactionRoomName
        {
            get { return _TransactionRoomName; }
            set { _TransactionRoomName = value; }
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
        [Column(Name = "ItemQty", DataType = "Double")]
        public Double ItemQty
        {
            get { return _ItemQty; }
            set { _ItemQty = value; }
        }
        [Column(Name = "ItemUnit", DataType = "String")]
        public String ItemUnit
        {
            get { return _ItemUnit; }
            set { _ItemUnit = value; }
        }
        [Column(Name = "CompTrf1", DataType = "Double")]
        public Double CompTrf1
        {
            get { return _CompTrf1; }
            set { _CompTrf1 = value; }
        }
        [Column(Name = "CompTrf2", DataType = "Decimal")]
        public Decimal CompTrf2
        {
            get { return _CompTrf2; }
            set { _CompTrf2 = value; }
        }
        [Column(Name = "CompTrf3", DataType = "Decimal")]
        public Decimal CompTrf3
        {
            get { return _CompTrf3; }
            set { _CompTrf3 = value; }
        }
        [Column(Name = "CompTrf4", DataType = "Decimal")]
        public Decimal CompTrf4
        {
            get { return _CompTrf4; }
            set { _CompTrf4 = value; }
        }
        [Column(Name = "Deductible1", DataType = "Decimal")]
        public Decimal Deductible1
        {
            get { return _Deductible1; }
            set { _Deductible1 = value; }
        }
        [Column(Name = "Deductible2", DataType = "Decimal")]
        public Decimal Deductible2
        {
            get { return _Deductible2; }
            set { _Deductible2 = value; }
        }
        [Column(Name = "Deductible3", DataType = "Decimal")]
        public Decimal Deductible3
        {
            get { return _Deductible3; }
            set { _Deductible3 = value; }
        }
        [Column(Name = "Deductible4", DataType = "Decimal")]
        public Decimal Deductible4
        {
            get { return _Deductible4; }
            set { _Deductible4 = value; }
        }
        [Column(Name = "Discount1", DataType = "Double")]
        public Double Discount1
        {
            get { return _Discount1; }
            set { _Discount1 = value; }
        }
        [Column(Name = "Discount2", DataType = "Decimal")]
        public Decimal Discount2
        {
            get { return _Discount2; }
            set { _Discount2 = value; }
        }
        [Column(Name = "Discount3", DataType = "Decimal")]
        public Decimal Discount3
        {
            get { return _Discount3; }
            set { _Discount3 = value; }
        }
        [Column(Name = "Discount4", DataType = "Decimal")]
        public Decimal Discount4
        {
            get { return _Discount4; }
            set { _Discount4 = value; }
        }
        [Column(Name = "BasePrice1", DataType = "Decimal")]
        public Decimal BasePrice1
        {
            get { return _BasePrice1; }
            set { _BasePrice1 = value; }
        }
        [Column(Name = "BasePrice2", DataType = "Decimal")]
        public Decimal BasePrice2
        {
            get { return _BasePrice2; }
            set { _BasePrice2 = value; }
        }
        [Column(Name = "BasePrice3", DataType = "Decimal")]
        public Decimal BasePrice3
        {
            get { return _BasePrice3; }
            set { _BasePrice3 = value; }
        }
        [Column(Name = "BasePrice4", DataType = "Decimal")]
        public Decimal BasePrice4
        {
            get { return _BasePrice4; }
            set { _BasePrice4 = value; }
        }
        [Column(Name = "CitoAmount", DataType = "Decimal")]
        public Decimal CitoAmount
        {
            get { return _CitoAmount; }
            set { _CitoAmount = value; }
        }
        [Column(Name = "CitoDiscAmount", DataType = "Decimal")]
        public Decimal CitoDiscAmount
        {
            get { return _CitoDiscAmount; }
            set { _CitoDiscAmount = value; }
        }
        [Column(Name = "CitoDeductAmount", DataType = "Decimal")]
        public Decimal CitoDeductAmount
        {
            get { return _CitoDeductAmount; }
            set { _CitoDeductAmount = value; }
        }
        [Column(Name = "ComplicationAmount", DataType = "Decimal")]
        public Decimal ComplicationAmount
        {
            get { return _ComplicationAmount; }
            set { _ComplicationAmount = value; }
        }
        [Column(Name = "ComplicationDiscAmount", DataType = "Decimal")]
        public Decimal ComplicationDiscAmount
        {
            get { return _ComplicationDiscAmount; }
            set { _ComplicationDiscAmount = value; }
        }
        [Column(Name = "ComplicationDeducAmount", DataType = "Decimal")]
        public Decimal ComplicationDeducAmount
        {
            get { return _ComplicationDeducAmount; }
            set { _ComplicationDeducAmount = value; }
        }
        [Column(Name = "PatientBillAmount", DataType = "Double")]
        public Double PatientBillAmount
        {
            get { return _PatientBillAmount; }
            set { _PatientBillAmount = value; }
        }
        [Column(Name = "PayerBillAmount", DataType = "Double")]
        public Double PayerBillAmount
        {
            get { return _PayerBillAmount; }
            set { _PayerBillAmount = value; }
        }
        [Column(Name = "IsVariablePrice", DataType = "Int32")]
        public Int32 IsVariablePrice
        {
            get { return _IsVariablePrice; }
            set { _IsVariablePrice = value; }
        }
        [Column(Name = "IsFreeOfCharge", DataType = "Int32")]
        public Int32 IsFreeOfCharge
        {
            get { return _IsFreeOfCharge; }
            set { _IsFreeOfCharge = value; }
        }
        [Column(Name = "IsApproved", DataType = "Int32")]
        public Int32 IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
        [Column(Name = "UpdatedDate", DataType = "DateTime")]
        public DateTime UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }
        [Column(Name = "UpdatedBy", DataType = "String")]
        public String UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
        [Column(Name = "MedicalDiagnostic", DataType = "String")]
        public String MedicalDiagnostic
        {
            get { return _MedicalDiagnostic; }
            set { _MedicalDiagnostic = value; }
        }
    }
    #endregion
    #region vLaboratoryTariff
    [Serializable]
    [Table(Name = "vLaboratoryTariff")]
    public class vLaboratoryTariff
    {
        private String _ServiceTariffBookNo;
        private String _ServiceTariffBookSubject;
        private String _Description;
        private DateTime _AppliedDate;
        private String _AppliedDateText;
        private String _ServiceItemCode;
        private String _ServiceItemName;
        private String _ClassCode;
        private String _ClassName;
        private String _TariffTypeCode;
        private String _TariffTypeName;
        private Decimal _BasePrice;
        private Decimal _UnitPrice;
        private DateTime _CreatedDate;
        private String _CreatedBy;
        private String _UpdatedDate;
        private DateTime _UpdatedBy;

        [Column(Name = "ServiceTariffBookNo", DataType = "String")]
        public String ServiceTariffBookNo
        {
            get { return _ServiceTariffBookNo; }
            set { _ServiceTariffBookNo = value; }
        }
        [Column(Name = "ServiceTariffBookSubject", DataType = "String")]
        public String ServiceTariffBookSubject
        {
            get { return _ServiceTariffBookSubject; }
            set { _ServiceTariffBookSubject = value; }
        }
        [Column(Name = "Description", DataType = "String")]
        public String Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        [Column(Name = "AppliedDate", DataType = "DateTime")]
        public DateTime AppliedDate
        {
            get { return _AppliedDate; }
            set { _AppliedDate = value; }
        }
        [Column(Name = "AppliedDateText", DataType = "String")]
        public String AppliedDateText
        {
            get { return _AppliedDateText; }
            set { _AppliedDateText = value; }
        }
        [Column(Name = "ServiceItemCode", DataType = "String")]
        public String ServiceItemCode
        {
            get { return _ServiceItemCode; }
            set { _ServiceItemCode = value; }
        }
        [Column(Name = "ServiceItemName", DataType = "String")]
        public String ServiceItemName
        {
            get { return _ServiceItemName; }
            set { _ServiceItemName = value; }
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
        [Column(Name = "TariffTypeCode", DataType = "String")]
        public String TariffTypeCode
        {
            get { return _TariffTypeCode; }
            set { _TariffTypeCode = value; }
        }
        [Column(Name = "TariffTypeName", DataType = "String")]
        public String TariffTypeName
        {
            get { return _TariffTypeName; }
            set { _TariffTypeName = value; }
        }
        [Column(Name = "BasePrice", DataType = "Decimal")]
        public Decimal BasePrice
        {
            get { return _BasePrice; }
            set { _BasePrice = value; }
        }
        [Column(Name = "UnitPrice", DataType = "Decimal")]
        public Decimal UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
        [Column(Name = "CreatedDate", DataType = "DateTime")]
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        [Column(Name = "CreatedBy", DataType = "String")]
        public String CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        [Column(Name = "UpdatedDate", DataType = "String")]
        public String UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }
        [Column(Name = "UpdatedBy", DataType = "DateTime")]
        public DateTime UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
    }
    #endregion
    #region vLogisticWarehouseLocation
    [Serializable]
    [Table(Name = "vLogisticWarehouseLocation")]
    public class vLogisticWarehouseLocation
    {
        private String _warehouseCode;
        private String _warehouseName;
        private String _locationCode;
        private String _locationName;
        private DateTime _startDate;

        [Column(Name = "warehouseCode", DataType = "String")]
        public String warehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }
        [Column(Name = "warehouseName", DataType = "String")]
        public String warehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }
        [Column(Name = "locationCode", DataType = "String")]
        public String locationCode
        {
            get { return _locationCode; }
            set { _locationCode = value; }
        }
        [Column(Name = "locationName", DataType = "String")]
        public String locationName
        {
            get { return _locationName; }
            set { _locationName = value; }
        }
        [Column(Name = "startDate", DataType = "DateTime")]
        public DateTime startDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
    }
    #endregion
    #region vMedicalCheckUpTariff
    [Serializable]
    [Table(Name = "vMedicalCheckUpTariff")]
    public class vMedicalCheckUpTariff
    {
        private String _ServiceTariffBookNo;
        private String _ServiceTariffBookSubject;
        private String _Description;
        private DateTime _AppliedDate;
        private String _AppliedDateText;
        private String _PackageItemCode;
        private String _PackageItemName;
        private Decimal _PackageUnitPrice;
        private Boolean _IsAccumulative;
        private String _ServiceItemCode;
        private String _ServiceItemName;
        private Decimal _UnitPrice;
        private DateTime _CreatedDate;
        private String _CreatedBy;
        private String _UpdatedDate;
        private DateTime _UpdatedBy;

        [Column(Name = "ServiceTariffBookNo", DataType = "String")]
        public String ServiceTariffBookNo
        {
            get { return _ServiceTariffBookNo; }
            set { _ServiceTariffBookNo = value; }
        }
        [Column(Name = "ServiceTariffBookSubject", DataType = "String")]
        public String ServiceTariffBookSubject
        {
            get { return _ServiceTariffBookSubject; }
            set { _ServiceTariffBookSubject = value; }
        }
        [Column(Name = "Description", DataType = "String")]
        public String Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        [Column(Name = "AppliedDate", DataType = "DateTime")]
        public DateTime AppliedDate
        {
            get { return _AppliedDate; }
            set { _AppliedDate = value; }
        }
        [Column(Name = "AppliedDateText", DataType = "String")]
        public String AppliedDateText
        {
            get { return _AppliedDateText; }
            set { _AppliedDateText = value; }
        }
        [Column(Name = "PackageItemCode", DataType = "String")]
        public String PackageItemCode
        {
            get { return _PackageItemCode; }
            set { _PackageItemCode = value; }
        }
        [Column(Name = "PackageItemName", DataType = "String")]
        public String PackageItemName
        {
            get { return _PackageItemName; }
            set { _PackageItemName = value; }
        }
        [Column(Name = "PackageUnitPrice", DataType = "Decimal")]
        public Decimal PackageUnitPrice
        {
            get { return _PackageUnitPrice; }
            set { _PackageUnitPrice = value; }
        }
        [Column(Name = "IsAccumulative", DataType = "Boolean")]
        public Boolean IsAccumulative
        {
            get { return _IsAccumulative; }
            set { _IsAccumulative = value; }
        }
        [Column(Name = "ServiceItemCode", DataType = "String")]
        public String ServiceItemCode
        {
            get { return _ServiceItemCode; }
            set { _ServiceItemCode = value; }
        }
        [Column(Name = "ServiceItemName", DataType = "String")]
        public String ServiceItemName
        {
            get { return _ServiceItemName; }
            set { _ServiceItemName = value; }
        }
        [Column(Name = "UnitPrice", DataType = "Decimal")]
        public Decimal UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
        [Column(Name = "CreatedDate", DataType = "DateTime")]
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        [Column(Name = "CreatedBy", DataType = "String")]
        public String CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        [Column(Name = "UpdatedDate", DataType = "String")]
        public String UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }
        [Column(Name = "UpdatedBy", DataType = "DateTime")]
        public DateTime UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
    }
    #endregion
    #region vMedicalCheckUpTransaction
    [Serializable]
    [Table(Name = "vMedicalCheckUpTransaction")]
    public class vMedicalCheckUpTransaction : vRegistrationMCU
    {
        private String _TransactionNo;
        private DateTime _TransactionDate;
        private String _PackageCode;
        private String _PackageName;
        private String _PackagePhysicianCode;
        private String _PackagePhysicianName;
        private Int32 _PackageQty;
        private Decimal _PackageCompTrf1;
        private Decimal _PackageCompTrf2;
        private Decimal _PackageCompTrf3;
        private Decimal _PackageCompTrf4;
        private Decimal _PackageDeductible1;
        private Decimal _PackageDeductible2;
        private Decimal _PackageDeductible3;
        private Decimal _PackageDeductible4;
        private Decimal _PackageDiscount1;
        private Decimal _PackageDiscount2;
        private Decimal _PackageDiscount3;
        private Decimal _PackageDiscount4;
        private Decimal _PackageBasePrice1;
        private Decimal _PackageBasePrice2;
        private Decimal _PackageBasePrice3;
        private Decimal _PackageBasePrice4;
        private Boolean _IsVariablePrice;
        private Decimal _PatientBillAmount;
        private Decimal _PayerBillAmount;
        private String _PaymentNo1;
        private String _PaymentNo2;
        private String _PaymentNo3;
        private DateTime _PackageUpdatedDate;
        private String _PackageUpdatedBy;
        private Boolean _IsAccumulativeTariff;
        private String _RealizationUnitInitial;
        private String _RealizationUnitCode;
        private String _RealizationUnitName;
        private String _ItemCode;
        private String _ItemName;
        private Double _ItemQty;
        private DateTime _ItemTransactionDate;
        private String _PhysicianCode;
        private String _PhysicianName;
        private Decimal _CompTariff1;
        private Decimal _CompTariff2;
        private Decimal _CompTariff3;
        private Decimal _CompTariff4;
        private Decimal _Deductible1;
        private Decimal _Deductible2;
        private Decimal _Deductible3;
        private Decimal _Deductible4;
        private Decimal _Discount1;
        private Decimal _Discount2;
        private Decimal _Discount3;
        private Decimal _Discount4;
        private String _ItemUpdatedDate;
        private DateTime _ItemUpdatedBy;
        private Boolean _IsDefaultInPackage;
        private Boolean _IsSubstituteItem;

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
        [Column(Name = "PackageCode", DataType = "String")]
        public String PackageCode
        {
            get { return _PackageCode; }
            set { _PackageCode = value; }
        }
        [Column(Name = "PackageName", DataType = "String")]
        public String PackageName
        {
            get { return _PackageName; }
            set { _PackageName = value; }
        }
        [Column(Name = "PackagePhysicianCode", DataType = "String")]
        public String PackagePhysicianCode
        {
            get { return _PackagePhysicianCode; }
            set { _PackagePhysicianCode = value; }
        }
        [Column(Name = "PackagePhysicianName", DataType = "String")]
        public String PackagePhysicianName
        {
            get { return _PackagePhysicianName; }
            set { _PackagePhysicianName = value; }
        }
        [Column(Name = "PackageQty", DataType = "Int32")]
        public Int32 PackageQty
        {
            get { return _PackageQty; }
            set { _PackageQty = value; }
        }
        [Column(Name = "PackageCompTrf1", DataType = "Decimal")]
        public Decimal PackageCompTrf1
        {
            get { return _PackageCompTrf1; }
            set { _PackageCompTrf1 = value; }
        }
        [Column(Name = "PackageCompTrf2", DataType = "Decimal")]
        public Decimal PackageCompTrf2
        {
            get { return _PackageCompTrf2; }
            set { _PackageCompTrf2 = value; }
        }
        [Column(Name = "PackageCompTrf3", DataType = "Decimal")]
        public Decimal PackageCompTrf3
        {
            get { return _PackageCompTrf3; }
            set { _PackageCompTrf3 = value; }
        }
        [Column(Name = "PackageCompTrf4", DataType = "Decimal")]
        public Decimal PackageCompTrf4
        {
            get { return _PackageCompTrf4; }
            set { _PackageCompTrf4 = value; }
        }
        [Column(Name = "PackageDeductible1", DataType = "Decimal")]
        public Decimal PackageDeductible1
        {
            get { return _PackageDeductible1; }
            set { _PackageDeductible1 = value; }
        }
        [Column(Name = "PackageDeductible2", DataType = "Decimal")]
        public Decimal PackageDeductible2
        {
            get { return _PackageDeductible2; }
            set { _PackageDeductible2 = value; }
        }
        [Column(Name = "PackageDeductible3", DataType = "Decimal")]
        public Decimal PackageDeductible3
        {
            get { return _PackageDeductible3; }
            set { _PackageDeductible3 = value; }
        }
        [Column(Name = "PackageDeductible4", DataType = "Decimal")]
        public Decimal PackageDeductible4
        {
            get { return _PackageDeductible4; }
            set { _PackageDeductible4 = value; }
        }
        [Column(Name = "PackageDiscount1", DataType = "Decimal")]
        public Decimal PackageDiscount1
        {
            get { return _PackageDiscount1; }
            set { _PackageDiscount1 = value; }
        }
        [Column(Name = "PackageDiscount2", DataType = "Decimal")]
        public Decimal PackageDiscount2
        {
            get { return _PackageDiscount2; }
            set { _PackageDiscount2 = value; }
        }
        [Column(Name = "PackageDiscount3", DataType = "Decimal")]
        public Decimal PackageDiscount3
        {
            get { return _PackageDiscount3; }
            set { _PackageDiscount3 = value; }
        }
        [Column(Name = "PackageDiscount4", DataType = "Decimal")]
        public Decimal PackageDiscount4
        {
            get { return _PackageDiscount4; }
            set { _PackageDiscount4 = value; }
        }
        [Column(Name = "PackageBasePrice1", DataType = "Decimal")]
        public Decimal PackageBasePrice1
        {
            get { return _PackageBasePrice1; }
            set { _PackageBasePrice1 = value; }
        }
        [Column(Name = "PackageBasePrice2", DataType = "Decimal")]
        public Decimal PackageBasePrice2
        {
            get { return _PackageBasePrice2; }
            set { _PackageBasePrice2 = value; }
        }
        [Column(Name = "PackageBasePrice3", DataType = "Decimal")]
        public Decimal PackageBasePrice3
        {
            get { return _PackageBasePrice3; }
            set { _PackageBasePrice3 = value; }
        }
        [Column(Name = "PackageBasePrice4", DataType = "Decimal")]
        public Decimal PackageBasePrice4
        {
            get { return _PackageBasePrice4; }
            set { _PackageBasePrice4 = value; }
        }
        [Column(Name = "IsVariablePrice", DataType = "Boolean")]
        public Boolean IsVariablePrice
        {
            get { return _IsVariablePrice; }
            set { _IsVariablePrice = value; }
        }
        [Column(Name = "PatientBillAmount", DataType = "Decimal")]
        public Decimal PatientBillAmount
        {
            get { return _PatientBillAmount; }
            set { _PatientBillAmount = value; }
        }
        [Column(Name = "PayerBillAmount", DataType = "Decimal")]
        public Decimal PayerBillAmount
        {
            get { return _PayerBillAmount; }
            set { _PayerBillAmount = value; }
        }
        [Column(Name = "PaymentNo1", DataType = "String")]
        public String PaymentNo1
        {
            get { return _PaymentNo1; }
            set { _PaymentNo1 = value; }
        }
        [Column(Name = "PaymentNo2", DataType = "String")]
        public String PaymentNo2
        {
            get { return _PaymentNo2; }
            set { _PaymentNo2 = value; }
        }
        [Column(Name = "PaymentNo3", DataType = "String")]
        public String PaymentNo3
        {
            get { return _PaymentNo3; }
            set { _PaymentNo3 = value; }
        }
        [Column(Name = "PackageUpdatedDate", DataType = "DateTime")]
        public DateTime PackageUpdatedDate
        {
            get { return _PackageUpdatedDate; }
            set { _PackageUpdatedDate = value; }
        }
        [Column(Name = "PackageUpdatedBy", DataType = "String")]
        public String PackageUpdatedBy
        {
            get { return _PackageUpdatedBy; }
            set { _PackageUpdatedBy = value; }
        }
        [Column(Name = "IsAccumulativeTariff", DataType = "Boolean")]
        public Boolean IsAccumulativeTariff
        {
            get { return _IsAccumulativeTariff; }
            set { _IsAccumulativeTariff = value; }
        }
        [Column(Name = "RealizationUnitInitial", DataType = "String")]
        public String RealizationUnitInitial
        {
            get { return _RealizationUnitInitial; }
            set { _RealizationUnitInitial = value; }
        }
        [Column(Name = "RealizationUnitCode", DataType = "String")]
        public String RealizationUnitCode
        {
            get { return _RealizationUnitCode; }
            set { _RealizationUnitCode = value; }
        }
        [Column(Name = "RealizationUnitName", DataType = "String")]
        public String RealizationUnitName
        {
            get { return _RealizationUnitName; }
            set { _RealizationUnitName = value; }
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
        [Column(Name = "ItemQty", DataType = "Double")]
        public Double ItemQty
        {
            get { return _ItemQty; }
            set { _ItemQty = value; }
        }
        [Column(Name = "ItemTransactionDate", DataType = "DateTime")]
        public DateTime ItemTransactionDate
        {
            get { return _ItemTransactionDate; }
            set { _ItemTransactionDate = value; }
        }
        [Column(Name = "PhysicianCode", DataType = "String")]
        public String PhysicianCode
        {
            get { return _PhysicianCode; }
            set { _PhysicianCode = value; }
        }
        [Column(Name = "PhysicianName", DataType = "String")]
        public String PhysicianName
        {
            get { return _PhysicianName; }
            set { _PhysicianName = value; }
        }
        [Column(Name = "CompTariff1", DataType = "Decimal")]
        public Decimal CompTariff1
        {
            get { return _CompTariff1; }
            set { _CompTariff1 = value; }
        }
        [Column(Name = "CompTariff2", DataType = "Decimal")]
        public Decimal CompTariff2
        {
            get { return _CompTariff2; }
            set { _CompTariff2 = value; }
        }
        [Column(Name = "CompTariff3", DataType = "Decimal")]
        public Decimal CompTariff3
        {
            get { return _CompTariff3; }
            set { _CompTariff3 = value; }
        }
        [Column(Name = "CompTariff4", DataType = "Decimal")]
        public Decimal CompTariff4
        {
            get { return _CompTariff4; }
            set { _CompTariff4 = value; }
        }
        [Column(Name = "Deductible1", DataType = "Decimal")]
        public Decimal Deductible1
        {
            get { return _Deductible1; }
            set { _Deductible1 = value; }
        }
        [Column(Name = "Deductible2", DataType = "Decimal")]
        public Decimal Deductible2
        {
            get { return _Deductible2; }
            set { _Deductible2 = value; }
        }
        [Column(Name = "Deductible3", DataType = "Decimal")]
        public Decimal Deductible3
        {
            get { return _Deductible3; }
            set { _Deductible3 = value; }
        }
        [Column(Name = "Deductible4", DataType = "Decimal")]
        public Decimal Deductible4
        {
            get { return _Deductible4; }
            set { _Deductible4 = value; }
        }
        [Column(Name = "Discount1", DataType = "Decimal")]
        public Decimal Discount1
        {
            get { return _Discount1; }
            set { _Discount1 = value; }
        }
        [Column(Name = "Discount2", DataType = "Decimal")]
        public Decimal Discount2
        {
            get { return _Discount2; }
            set { _Discount2 = value; }
        }
        [Column(Name = "Discount3", DataType = "Decimal")]
        public Decimal Discount3
        {
            get { return _Discount3; }
            set { _Discount3 = value; }
        }
        [Column(Name = "Discount4", DataType = "Decimal")]
        public Decimal Discount4
        {
            get { return _Discount4; }
            set { _Discount4 = value; }
        }
        [Column(Name = "ItemUpdatedDate", DataType = "String")]
        public String ItemUpdatedDate
        {
            get { return _ItemUpdatedDate; }
            set { _ItemUpdatedDate = value; }
        }
        [Column(Name = "ItemUpdatedBy", DataType = "DateTime")]
        public DateTime ItemUpdatedBy
        {
            get { return _ItemUpdatedBy; }
            set { _ItemUpdatedBy = value; }
        }
        [Column(Name = "IsDefaultInPackage", DataType = "Boolean")]
        public Boolean IsDefaultInPackage
        {
            get { return _IsDefaultInPackage; }
            set { _IsDefaultInPackage = value; }
        }
        [Column(Name = "IsSubstituteItem", DataType = "Boolean")]
        public Boolean IsSubstituteItem
        {
            get { return _IsSubstituteItem; }
            set { _IsSubstituteItem = value; }
        }
    }
    #endregion
    #region vMedicalDiagnosticTransaction
    [Serializable]
    [Table(Name = "vMedicalDiagnosticTransaction")]
    public class vMedicalDiagnosticTransaction : vRegistrationMD
    {
        private Int32 _DisplayOrder;
        private String _AdmissionSourceCode;
        private String _AdmissionSource;
        private String _TransactionType;
        private String _TransactionNo;
        private DateTime _TransactionDate;
        private String _TransactionTime;
        private String _TransactionPhysician;
        private String _ItemCode;
        private String _ItemName;
        private Decimal _ItemQty;
        private String _ItemUnit;
        private Decimal _CompTrf1;
        private Decimal _CompTrf2;
        private Decimal _CompTrf3;
        private Decimal _CompTrf4;
        private Decimal _Deductible1;
        private Decimal _Deductible2;
        private Decimal _Deductible3;
        private Decimal _Deductible4;
        private Decimal _Discount1;
        private Decimal _Discount2;
        private Decimal _Discount3;
        private Decimal _Discount4;
        private Decimal _BasePrice1;
        private Decimal _BasePrice2;
        private Decimal _BasePrice3;
        private Decimal _BasePrice4;
        private Decimal _CitoAmount;
        private Decimal _CitoDiscAmount;
        private Decimal _CitoDeductAmount;
        private Decimal _ComplicationAmount;
        private Decimal _ComplicationDiscAmount;
        private Decimal _ComplicationDeducAmount;
        private Decimal _PatientBillAmount;
        private Decimal _PayerBillAmount;
        private Int32 _IsVariablePrice;
        private Int32 _IsFreeOfCharge;
        private Int32 _IsApproved;
        private DateTime _UpdatedDate;
        private String _UpdatedBy;
        private String _PaymentNo1;
        private String _PaymentNo2;
        private String _PaymentNo3;

        [Column(Name = "DisplayOrder", DataType = "Int32")]
        public Int32 DisplayOrder
        {
            get { return _DisplayOrder; }
            set { _DisplayOrder = value; }
        }
        [Column(Name = "AdmissionSourceCode", DataType = "String")]
        public String AdmissionSourceCode
        {
            get { return _AdmissionSourceCode; }
            set { _AdmissionSourceCode = value; }
        }
        [Column(Name = "AdmissionSource", DataType = "String")]
        public String AdmissionSource
        {
            get { return _AdmissionSource; }
            set { _AdmissionSource = value; }
        }
        [Column(Name = "TransactionType", DataType = "String")]
        public String TransactionType
        {
            get { return _TransactionType; }
            set { _TransactionType = value; }
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
        [Column(Name = "TransactionTime", DataType = "String")]
        public String TransactionTime
        {
            get { return _TransactionTime; }
            set { _TransactionTime = value; }
        }
        [Column(Name = "TransactionPhysician", DataType = "String")]
        public String TransactionPhysician
        {
            get { return _TransactionPhysician; }
            set { _TransactionPhysician = value; }
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
        [Column(Name = "ItemQty", DataType = "Decimal")]
        public Decimal ItemQty
        {
            get { return _ItemQty; }
            set { _ItemQty = value; }
        }
        [Column(Name = "ItemUnit", DataType = "String")]
        public String ItemUnit
        {
            get { return _ItemUnit; }
            set { _ItemUnit = value; }
        }
        [Column(Name = "CompTrf1", DataType = "Decimal")]
        public Decimal CompTrf1
        {
            get { return _CompTrf1; }
            set { _CompTrf1 = value; }
        }
        [Column(Name = "CompTrf2", DataType = "Decimal")]
        public Decimal CompTrf2
        {
            get { return _CompTrf2; }
            set { _CompTrf2 = value; }
        }
        [Column(Name = "CompTrf3", DataType = "Decimal")]
        public Decimal CompTrf3
        {
            get { return _CompTrf3; }
            set { _CompTrf3 = value; }
        }
        [Column(Name = "CompTrf4", DataType = "Decimal")]
        public Decimal CompTrf4
        {
            get { return _CompTrf4; }
            set { _CompTrf4 = value; }
        }
        [Column(Name = "Deductible1", DataType = "Decimal")]
        public Decimal Deductible1
        {
            get { return _Deductible1; }
            set { _Deductible1 = value; }
        }
        [Column(Name = "Deductible2", DataType = "Decimal")]
        public Decimal Deductible2
        {
            get { return _Deductible2; }
            set { _Deductible2 = value; }
        }
        [Column(Name = "Deductible3", DataType = "Decimal")]
        public Decimal Deductible3
        {
            get { return _Deductible3; }
            set { _Deductible3 = value; }
        }
        [Column(Name = "Deductible4", DataType = "Decimal")]
        public Decimal Deductible4
        {
            get { return _Deductible4; }
            set { _Deductible4 = value; }
        }
        [Column(Name = "Discount1", DataType = "Decimal")]
        public Decimal Discount1
        {
            get { return _Discount1; }
            set { _Discount1 = value; }
        }
        [Column(Name = "Discount2", DataType = "Decimal")]
        public Decimal Discount2
        {
            get { return _Discount2; }
            set { _Discount2 = value; }
        }
        [Column(Name = "Discount3", DataType = "Decimal")]
        public Decimal Discount3
        {
            get { return _Discount3; }
            set { _Discount3 = value; }
        }
        [Column(Name = "Discount4", DataType = "Decimal")]
        public Decimal Discount4
        {
            get { return _Discount4; }
            set { _Discount4 = value; }
        }
        [Column(Name = "BasePrice1", DataType = "Decimal")]
        public Decimal BasePrice1
        {
            get { return _BasePrice1; }
            set { _BasePrice1 = value; }
        }
        [Column(Name = "BasePrice2", DataType = "Decimal")]
        public Decimal BasePrice2
        {
            get { return _BasePrice2; }
            set { _BasePrice2 = value; }
        }
        [Column(Name = "BasePrice3", DataType = "Decimal")]
        public Decimal BasePrice3
        {
            get { return _BasePrice3; }
            set { _BasePrice3 = value; }
        }
        [Column(Name = "BasePrice4", DataType = "Decimal")]
        public Decimal BasePrice4
        {
            get { return _BasePrice4; }
            set { _BasePrice4 = value; }
        }
        [Column(Name = "CitoAmount", DataType = "Decimal")]
        public Decimal CitoAmount
        {
            get { return _CitoAmount; }
            set { _CitoAmount = value; }
        }
        [Column(Name = "CitoDiscAmount", DataType = "Decimal")]
        public Decimal CitoDiscAmount
        {
            get { return _CitoDiscAmount; }
            set { _CitoDiscAmount = value; }
        }
        [Column(Name = "CitoDeductAmount", DataType = "Decimal")]
        public Decimal CitoDeductAmount
        {
            get { return _CitoDeductAmount; }
            set { _CitoDeductAmount = value; }
        }
        [Column(Name = "ComplicationAmount", DataType = "Decimal")]
        public Decimal ComplicationAmount
        {
            get { return _ComplicationAmount; }
            set { _ComplicationAmount = value; }
        }
        [Column(Name = "ComplicationDiscAmount", DataType = "Decimal")]
        public Decimal ComplicationDiscAmount
        {
            get { return _ComplicationDiscAmount; }
            set { _ComplicationDiscAmount = value; }
        }
        [Column(Name = "ComplicationDeducAmount", DataType = "Decimal")]
        public Decimal ComplicationDeducAmount
        {
            get { return _ComplicationDeducAmount; }
            set { _ComplicationDeducAmount = value; }
        }
        [Column(Name = "PatientBillAmount", DataType = "Decimal")]
        public Decimal PatientBillAmount
        {
            get { return _PatientBillAmount; }
            set { _PatientBillAmount = value; }
        }
        [Column(Name = "PayerBillAmount", DataType = "Decimal")]
        public Decimal PayerBillAmount
        {
            get { return _PayerBillAmount; }
            set { _PayerBillAmount = value; }
        }
        [Column(Name = "IsVariablePrice", DataType = "Int32")]
        public Int32 IsVariablePrice
        {
            get { return _IsVariablePrice; }
            set { _IsVariablePrice = value; }
        }
        [Column(Name = "IsFreeOfCharge", DataType = "Int32")]
        public Int32 IsFreeOfCharge
        {
            get { return _IsFreeOfCharge; }
            set { _IsFreeOfCharge = value; }
        }
        [Column(Name = "IsApproved", DataType = "Int32")]
        public Int32 IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
        [Column(Name = "UpdatedDate", DataType = "DateTime")]
        public DateTime UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }
        [Column(Name = "UpdatedBy", DataType = "String")]
        public String UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
        [Column(Name = "PaymentNo1", DataType = "String")]
        public String PaymentNo1
        {
            get { return _PaymentNo1; }
            set { _PaymentNo1 = value; }
        }
        [Column(Name = "PaymentNo2", DataType = "String")]
        public String PaymentNo2
        {
            get { return _PaymentNo2; }
            set { _PaymentNo2 = value; }
        }
        [Column(Name = "PaymentNo3", DataType = "String")]
        public String PaymentNo3
        {
            get { return _PaymentNo3; }
            set { _PaymentNo3 = value; }
        }
    }
    #endregion
    #region vMedicalDiagnosticUnit
    [Serializable]
    [Table(Name = "vMedicalDiagnosticUnit")]
    public class vMedicalDiagnosticUnit
    {
        private String _MedicalDiagnosticUnitCode;
        private String _MedicalDiagnosticUnitName;
        private String _PharmacyWarehouseCode;
        private String _PharmacyWarehouseName;
        private String _PharmacyLocationCode;
        private String _PharmacyLocationName;
        private String _LogisticWarehouseCode;
        private String _LogisticWarehouseName;
        private String _LogisticLocationCode;
        private String _LogisticLocationName;
        private Boolean _IsActive;

        [Column(Name = "MedicalDiagnosticUnitCode", DataType = "String")]
        public String MedicalDiagnosticUnitCode
        {
            get { return _MedicalDiagnosticUnitCode; }
            set { _MedicalDiagnosticUnitCode = value; }
        }
        [Column(Name = "MedicalDiagnosticUnitName", DataType = "String")]
        public String MedicalDiagnosticUnitName
        {
            get { return _MedicalDiagnosticUnitName; }
            set { _MedicalDiagnosticUnitName = value; }
        }
        [Column(Name = "PharmacyWarehouseCode", DataType = "String")]
        public String PharmacyWarehouseCode
        {
            get { return _PharmacyWarehouseCode; }
            set { _PharmacyWarehouseCode = value; }
        }
        [Column(Name = "PharmacyWarehouseName", DataType = "String")]
        public String PharmacyWarehouseName
        {
            get { return _PharmacyWarehouseName; }
            set { _PharmacyWarehouseName = value; }
        }
        [Column(Name = "PharmacyLocationCode", DataType = "String")]
        public String PharmacyLocationCode
        {
            get { return _PharmacyLocationCode; }
            set { _PharmacyLocationCode = value; }
        }
        [Column(Name = "PharmacyLocationName", DataType = "String")]
        public String PharmacyLocationName
        {
            get { return _PharmacyLocationName; }
            set { _PharmacyLocationName = value; }
        }
        [Column(Name = "LogisticWarehouseCode", DataType = "String")]
        public String LogisticWarehouseCode
        {
            get { return _LogisticWarehouseCode; }
            set { _LogisticWarehouseCode = value; }
        }
        [Column(Name = "LogisticWarehouseName", DataType = "String")]
        public String LogisticWarehouseName
        {
            get { return _LogisticWarehouseName; }
            set { _LogisticWarehouseName = value; }
        }
        [Column(Name = "LogisticLocationCode", DataType = "String")]
        public String LogisticLocationCode
        {
            get { return _LogisticLocationCode; }
            set { _LogisticLocationCode = value; }
        }
        [Column(Name = "LogisticLocationName", DataType = "String")]
        public String LogisticLocationName
        {
            get { return _LogisticLocationName; }
            set { _LogisticLocationName = value; }
        }
        [Column(Name = "IsActive", DataType = "Boolean")]
        public Boolean IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
    }
    #endregion
    #region vNeoNatalRI
    [Serializable]
    [Table(Name = "vNeoNatalRI")]
    public class vNeoNatalRI
    {
        private String _MotherRegistrationNo;
        private String _MotherMedicalNo;
        private String _MotherName;
        private String _BabyRegistrationNo;
        private String _BabyMedicalNo;
        private String _BabyName;
        private DateTime _BabyDateOfBirth;
        private String _BabyDateOfBirthText;
        private String _BornTime;
        private String _BabyGender;
        private Decimal _BabyWeight;
        private Decimal _BabyLength;
        private String _BornCondition;

        [Column(Name = "MotherRegistrationNo", DataType = "String")]
        public String MotherRegistrationNo
        {
            get { return _MotherRegistrationNo; }
            set { _MotherRegistrationNo = value; }
        }
        [Column(Name = "MotherMedicalNo", DataType = "String")]
        public String MotherMedicalNo
        {
            get { return _MotherMedicalNo; }
            set { _MotherMedicalNo = value; }
        }
        [Column(Name = "MotherName", DataType = "String")]
        public String MotherName
        {
            get { return _MotherName; }
            set { _MotherName = value; }
        }
        [Column(Name = "BabyRegistrationNo", DataType = "String")]
        public String BabyRegistrationNo
        {
            get { return _BabyRegistrationNo; }
            set { _BabyRegistrationNo = value; }
        }
        [Column(Name = "BabyMedicalNo", DataType = "String")]
        public String BabyMedicalNo
        {
            get { return _BabyMedicalNo; }
            set { _BabyMedicalNo = value; }
        }
        [Column(Name = "BabyName", DataType = "String")]
        public String BabyName
        {
            get { return _BabyName; }
            set { _BabyName = value; }
        }
        [Column(Name = "BabyDateOfBirth", DataType = "DateTime")]
        public DateTime BabyDateOfBirth
        {
            get { return _BabyDateOfBirth; }
            set { _BabyDateOfBirth = value; }
        }
        [Column(Name = "BabyDateOfBirthText", DataType = "String")]
        public String BabyDateOfBirthText
        {
            get { return _BabyDateOfBirthText; }
            set { _BabyDateOfBirthText = value; }
        }
        [Column(Name = "BornTime", DataType = "String")]
        public String BornTime
        {
            get { return _BornTime; }
            set { _BornTime = value; }
        }
        [Column(Name = "BabyGender", DataType = "String")]
        public String BabyGender
        {
            get { return _BabyGender; }
            set { _BabyGender = value; }
        }
        [Column(Name = "BabyWeight", DataType = "Decimal")]
        public Decimal BabyWeight
        {
            get { return _BabyWeight; }
            set { _BabyWeight = value; }
        }
        [Column(Name = "BabyLength", DataType = "Decimal")]
        public Decimal BabyLength
        {
            get { return _BabyLength; }
            set { _BabyLength = value; }
        }
        [Column(Name = "BornCondition", DataType = "String")]
        public String BornCondition
        {
            get { return _BornCondition; }
            set { _BornCondition = value; }
        }
    }
    #endregion
    #region vOutpatientRevenue
    [Serializable]
    [Table(Name = "vOutpatientRevenue")]
    public class vOutpatientRevenue
    {
        private String _PaymentNo;
        private DateTime _PaymentDate;
        private String _PaymentDateText;
        private String _PaymentStatusCode;
        private String _PyamentStatusName;
        private String _RegistrationNo;
        private String _MedicalNo;
        private String _PatientFirstName;
        private String _PatientLastName;
        private String _PatientGender;
        private Decimal _BillAmount;
        private String _BillAmountText;
        private Decimal _PaymentAmount1;
        private Decimal _PaymentAmount2;
        private Decimal _PaymentAmount3;
        private Decimal _PaymentAmount4;
        private Decimal _PaymentAmount5;
        private Decimal _Discount;
        private Decimal _OtherBillAmount;
        private String _PaymentName;
        private String _Payer;
        private Boolean _IsVoid;
        private DateTime _UpdatedDate;
        private String _UpdatedBy;
        private String _ServiceUnitName;
        private String _Doctor;
        private String _TransactionType;
        private DateTime _TransactionDate;
        private String _ItemCode;
        private String _ItemName;
        private String _TransactionPhysician;
        private Double _ItemQty;
        private Double _PatientBillAmount;
        private Double _PayerBillAmount;
        private Double _totalBillAmount;

        [Column(Name = "PaymentNo", DataType = "String")]
        public String PaymentNo
        {
            get { return _PaymentNo; }
            set { _PaymentNo = value; }
        }
        [Column(Name = "PaymentDate", DataType = "DateTime")]
        public DateTime PaymentDate
        {
            get { return _PaymentDate; }
            set { _PaymentDate = value; }
        }
        [Column(Name = "PaymentDateText", DataType = "String")]
        public String PaymentDateText
        {
            get { return _PaymentDateText; }
            set { _PaymentDateText = value; }
        }
        [Column(Name = "PaymentStatusCode", DataType = "String")]
        public String PaymentStatusCode
        {
            get { return _PaymentStatusCode; }
            set { _PaymentStatusCode = value; }
        }
        [Column(Name = "PyamentStatusName", DataType = "String")]
        public String PyamentStatusName
        {
            get { return _PyamentStatusName; }
            set { _PyamentStatusName = value; }
        }
        [Column(Name = "RegistrationNo", DataType = "String")]
        public String RegistrationNo
        {
            get { return _RegistrationNo; }
            set { _RegistrationNo = value; }
        }
        [Column(Name = "MedicalNo", DataType = "String")]
        public String MedicalNo
        {
            get { return _MedicalNo; }
            set { _MedicalNo = value; }
        }
        [Column(Name = "PatientFirstName", DataType = "String")]
        public String PatientFirstName
        {
            get { return _PatientFirstName; }
            set { _PatientFirstName = value; }
        }
        [Column(Name = "PatientLastName", DataType = "String")]
        public String PatientLastName
        {
            get { return _PatientLastName; }
            set { _PatientLastName = value; }
        }
        [Column(Name = "PatientGender", DataType = "String")]
        public String PatientGender
        {
            get { return _PatientGender; }
            set { _PatientGender = value; }
        }
        [Column(Name = "BillAmount", DataType = "Decimal")]
        public Decimal BillAmount
        {
            get { return _BillAmount; }
            set { _BillAmount = value; }
        }
        [Column(Name = "BillAmountText", DataType = "String")]
        public String BillAmountText
        {
            get { return _BillAmountText; }
            set { _BillAmountText = value; }
        }
        [Column(Name = "PaymentAmount1", DataType = "Decimal")]
        public Decimal PaymentAmount1
        {
            get { return _PaymentAmount1; }
            set { _PaymentAmount1 = value; }
        }
        [Column(Name = "PaymentAmount2", DataType = "Decimal")]
        public Decimal PaymentAmount2
        {
            get { return _PaymentAmount2; }
            set { _PaymentAmount2 = value; }
        }
        [Column(Name = "PaymentAmount3", DataType = "Decimal")]
        public Decimal PaymentAmount3
        {
            get { return _PaymentAmount3; }
            set { _PaymentAmount3 = value; }
        }
        [Column(Name = "PaymentAmount4", DataType = "Decimal")]
        public Decimal PaymentAmount4
        {
            get { return _PaymentAmount4; }
            set { _PaymentAmount4 = value; }
        }
        [Column(Name = "PaymentAmount5", DataType = "Decimal")]
        public Decimal PaymentAmount5
        {
            get { return _PaymentAmount5; }
            set { _PaymentAmount5 = value; }
        }
        [Column(Name = "Discount", DataType = "Decimal")]
        public Decimal Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        [Column(Name = "OtherBillAmount", DataType = "Decimal")]
        public Decimal OtherBillAmount
        {
            get { return _OtherBillAmount; }
            set { _OtherBillAmount = value; }
        }
        [Column(Name = "PaymentName", DataType = "String")]
        public String PaymentName
        {
            get { return _PaymentName; }
            set { _PaymentName = value; }
        }
        [Column(Name = "Payer", DataType = "String")]
        public String Payer
        {
            get { return _Payer; }
            set { _Payer = value; }
        }
        [Column(Name = "IsVoid", DataType = "Boolean")]
        public Boolean IsVoid
        {
            get { return _IsVoid; }
            set { _IsVoid = value; }
        }
        [Column(Name = "UpdatedDate", DataType = "DateTime")]
        public DateTime UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }
        [Column(Name = "UpdatedBy", DataType = "String")]
        public String UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
        [Column(Name = "ServiceUnitName", DataType = "String")]
        public String ServiceUnitName
        {
            get { return _ServiceUnitName; }
            set { _ServiceUnitName = value; }
        }
        [Column(Name = "Doctor", DataType = "String")]
        public String Doctor
        {
            get { return _Doctor; }
            set { _Doctor = value; }
        }
        [Column(Name = "TransactionType", DataType = "String")]
        public String TransactionType
        {
            get { return _TransactionType; }
            set { _TransactionType = value; }
        }
        [Column(Name = "TransactionDate", DataType = "DateTime")]
        public DateTime TransactionDate
        {
            get { return _TransactionDate; }
            set { _TransactionDate = value; }
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
        [Column(Name = "TransactionPhysician", DataType = "String")]
        public String TransactionPhysician
        {
            get { return _TransactionPhysician; }
            set { _TransactionPhysician = value; }
        }
        [Column(Name = "ItemQty", DataType = "Double")]
        public Double ItemQty
        {
            get { return _ItemQty; }
            set { _ItemQty = value; }
        }
        [Column(Name = "PatientBillAmount", DataType = "Double")]
        public Double PatientBillAmount
        {
            get { return _PatientBillAmount; }
            set { _PatientBillAmount = value; }
        }
        [Column(Name = "PayerBillAmount", DataType = "Double")]
        public Double PayerBillAmount
        {
            get { return _PayerBillAmount; }
            set { _PayerBillAmount = value; }
        }
        [Column(Name = "totalBillAmount", DataType = "Double")]
        public Double totalBillAmount
        {
            get { return _totalBillAmount; }
            set { _totalBillAmount = value; }
        }
    }
    #endregion
    #region vOutpatientTransaction
    [Serializable]
    [Table(Name = "vOutpatientTransaction")]
    public class vOutpatientTransaction : vRegistrationRJ
    {
        private String _TransactionType;
        private String _TransactionNo;
        private DateTime _TransactionDate;
        private String _TransactionTime;
        private String _TransactionPhysician;
        private String _ItemCode;
        private String _ItemName;
        private Double _ItemQty;
        private String _ItemUnit;
        private Double _CompTrf1;
        private Decimal _CompTrf2;
        private Decimal _CompTrf3;
        private Decimal _CompTrf4;
        private Decimal _Deductible1;
        private Decimal _Deductible2;
        private Decimal _Deductible3;
        private Decimal _Deductible4;
        private Double _Discount1;
        private Decimal _Discount2;
        private Decimal _Discount3;
        private Decimal _Discount4;
        private Decimal _BasePrice1;
        private Decimal _BasePrice2;
        private Decimal _BasePrice3;
        private Decimal _BasePrice4;
        private Decimal _CitoAmount;
        private Decimal _CitoDiscAmount;
        private Decimal _CitoDeductAmount;
        private Decimal _ComplicationAmount;
        private Decimal _ComplicationDiscAmount;
        private Decimal _ComplicationDeducAmount;
        private Double _PatientBillAmount;
        private Double _PayerBillAmount;
        private Int32 _IsVariablePrice;
        private Int32 _IsFreeOfCharge;
        private Int32 _IsApproved;
        private DateTime _UpdatedDate;
        private String _UpdatedBy;
        private String _MedicalDiagnostic;
        private String _PaymentNo1;
        private String _PaymentNo2;
        private String _PaymentNo3;

        [Column(Name = "TransactionType", DataType = "String")]
        public String TransactionType
        {
            get { return _TransactionType; }
            set { _TransactionType = value; }
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
        [Column(Name = "TransactionTime", DataType = "String")]
        public String TransactionTime
        {
            get { return _TransactionTime; }
            set { _TransactionTime = value; }
        }
        [Column(Name = "TransactionPhysician", DataType = "String")]
        public String TransactionPhysician
        {
            get { return _TransactionPhysician; }
            set { _TransactionPhysician = value; }
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
        [Column(Name = "ItemQty", DataType = "Double")]
        public Double ItemQty
        {
            get { return _ItemQty; }
            set { _ItemQty = value; }
        }
        [Column(Name = "ItemUnit", DataType = "String")]
        public String ItemUnit
        {
            get { return _ItemUnit; }
            set { _ItemUnit = value; }
        }
        [Column(Name = "CompTrf1", DataType = "Double")]
        public Double CompTrf1
        {
            get { return _CompTrf1; }
            set { _CompTrf1 = value; }
        }
        [Column(Name = "CompTrf2", DataType = "Decimal")]
        public Decimal CompTrf2
        {
            get { return _CompTrf2; }
            set { _CompTrf2 = value; }
        }
        [Column(Name = "CompTrf3", DataType = "Decimal")]
        public Decimal CompTrf3
        {
            get { return _CompTrf3; }
            set { _CompTrf3 = value; }
        }
        [Column(Name = "CompTrf4", DataType = "Decimal")]
        public Decimal CompTrf4
        {
            get { return _CompTrf4; }
            set { _CompTrf4 = value; }
        }
        [Column(Name = "Deductible1", DataType = "Decimal")]
        public Decimal Deductible1
        {
            get { return _Deductible1; }
            set { _Deductible1 = value; }
        }
        [Column(Name = "Deductible2", DataType = "Decimal")]
        public Decimal Deductible2
        {
            get { return _Deductible2; }
            set { _Deductible2 = value; }
        }
        [Column(Name = "Deductible3", DataType = "Decimal")]
        public Decimal Deductible3
        {
            get { return _Deductible3; }
            set { _Deductible3 = value; }
        }
        [Column(Name = "Deductible4", DataType = "Decimal")]
        public Decimal Deductible4
        {
            get { return _Deductible4; }
            set { _Deductible4 = value; }
        }
        [Column(Name = "Discount1", DataType = "Double")]
        public Double Discount1
        {
            get { return _Discount1; }
            set { _Discount1 = value; }
        }
        [Column(Name = "Discount2", DataType = "Decimal")]
        public Decimal Discount2
        {
            get { return _Discount2; }
            set { _Discount2 = value; }
        }
        [Column(Name = "Discount3", DataType = "Decimal")]
        public Decimal Discount3
        {
            get { return _Discount3; }
            set { _Discount3 = value; }
        }
        [Column(Name = "Discount4", DataType = "Decimal")]
        public Decimal Discount4
        {
            get { return _Discount4; }
            set { _Discount4 = value; }
        }
        [Column(Name = "BasePrice1", DataType = "Decimal")]
        public Decimal BasePrice1
        {
            get { return _BasePrice1; }
            set { _BasePrice1 = value; }
        }
        [Column(Name = "BasePrice2", DataType = "Decimal")]
        public Decimal BasePrice2
        {
            get { return _BasePrice2; }
            set { _BasePrice2 = value; }
        }
        [Column(Name = "BasePrice3", DataType = "Decimal")]
        public Decimal BasePrice3
        {
            get { return _BasePrice3; }
            set { _BasePrice3 = value; }
        }
        [Column(Name = "BasePrice4", DataType = "Decimal")]
        public Decimal BasePrice4
        {
            get { return _BasePrice4; }
            set { _BasePrice4 = value; }
        }
        [Column(Name = "CitoAmount", DataType = "Decimal")]
        public Decimal CitoAmount
        {
            get { return _CitoAmount; }
            set { _CitoAmount = value; }
        }
        [Column(Name = "CitoDiscAmount", DataType = "Decimal")]
        public Decimal CitoDiscAmount
        {
            get { return _CitoDiscAmount; }
            set { _CitoDiscAmount = value; }
        }
        [Column(Name = "CitoDeductAmount", DataType = "Decimal")]
        public Decimal CitoDeductAmount
        {
            get { return _CitoDeductAmount; }
            set { _CitoDeductAmount = value; }
        }
        [Column(Name = "ComplicationAmount", DataType = "Decimal")]
        public Decimal ComplicationAmount
        {
            get { return _ComplicationAmount; }
            set { _ComplicationAmount = value; }
        }
        [Column(Name = "ComplicationDiscAmount", DataType = "Decimal")]
        public Decimal ComplicationDiscAmount
        {
            get { return _ComplicationDiscAmount; }
            set { _ComplicationDiscAmount = value; }
        }
        [Column(Name = "ComplicationDeducAmount", DataType = "Decimal")]
        public Decimal ComplicationDeducAmount
        {
            get { return _ComplicationDeducAmount; }
            set { _ComplicationDeducAmount = value; }
        }
        [Column(Name = "PatientBillAmount", DataType = "Double")]
        public Double PatientBillAmount
        {
            get { return _PatientBillAmount; }
            set { _PatientBillAmount = value; }
        }
        [Column(Name = "PayerBillAmount", DataType = "Double")]
        public Double PayerBillAmount
        {
            get { return _PayerBillAmount; }
            set { _PayerBillAmount = value; }
        }
        [Column(Name = "IsVariablePrice", DataType = "Int32")]
        public Int32 IsVariablePrice
        {
            get { return _IsVariablePrice; }
            set { _IsVariablePrice = value; }
        }
        [Column(Name = "IsFreeOfCharge", DataType = "Int32")]
        public Int32 IsFreeOfCharge
        {
            get { return _IsFreeOfCharge; }
            set { _IsFreeOfCharge = value; }
        }
        [Column(Name = "IsApproved", DataType = "Int32")]
        public Int32 IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
        [Column(Name = "UpdatedDate", DataType = "DateTime")]
        public DateTime UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }
        [Column(Name = "UpdatedBy", DataType = "String")]
        public String UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
        [Column(Name = "MedicalDiagnostic", DataType = "String")]
        public String MedicalDiagnostic
        {
            get { return _MedicalDiagnostic; }
            set { _MedicalDiagnostic = value; }
        }
        [Column(Name = "PaymentNo1", DataType = "String")]
        public String PaymentNo1
        {
            get { return _PaymentNo1; }
            set { _PaymentNo1 = value; }
        }
        [Column(Name = "PaymentNo2", DataType = "String")]
        public String PaymentNo2
        {
            get { return _PaymentNo2; }
            set { _PaymentNo2 = value; }
        }
        [Column(Name = "PaymentNo3", DataType = "String")]
        public String PaymentNo3
        {
            get { return _PaymentNo3; }
            set { _PaymentNo3 = value; }
        }
    }
    #endregion
    #region vPatient
    [Serializable]
    [Table(Name = "vPatientBase")]
    public partial class vPatient : vPatientBase
    {
        private String _GenderLabel;
        private String _PhoneNo;
        private String _MobileNo;
        private String _Photo;
        private String _PlaceOfBirth;
        private String _Email;
        private String _IDCard;
        private String _Education;
        private String _Job;
        private String _Religion;
        private String _MaritalStatus;
        private String _BloodType;
        private String _City;
        private String _PostalCode;
        private String _Nationality;
        private String _EmergencyContactName;
        private String _EmergencyContactRelation;
        private String _EmergencyContactAddr;
        private String _EmergencyContactPhone;
        private String _FatherOrHusband;
        private Int32 _FatherOrHusbandAge;
        private String _FatherOrHusbandJob;
        private String _MotherOrWife;
        private Int32 _MotherOrWifeAge;
        private String _MotherOrWifeJob;

        [Column(Name = "GenderLabel", DataType = "String")]
        public String GenderLabel
        {
            get { return _GenderLabel; }
            set { _GenderLabel = value; }
        }

        [Column(Name = "PhoneNo", DataType = "String")]
        public String PhoneNo
        {
            get { return _PhoneNo; }
            set { _PhoneNo = value; }
        }

        [Column(Name = "MobileNo", DataType = "String")]
        public String MobileNo
        {
            get { return _MobileNo; }
            set { _MobileNo = value; }
        }

        [Column(Name = "PlaceOfBirth", DataType = "String")]
        public String PlaceOfBirth
        {
            get { return _PlaceOfBirth; }
            set { _PlaceOfBirth = value; }
        }

        [Column(Name = "Photo", DataType = "String")]
        public String Photo
        {
            get { return _Photo; }
            set { _Photo = value; }
        }

        [Column(Name = "Email", DataType = "String")]
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        [Column(Name = "IDCard", DataType = "String")]
        public String IDCard
        {
            get { return _IDCard; }
            set { _IDCard = value; }
        }

        [Column(Name = "Education", DataType = "String")]
        public String Education
        {
            get { return _Education; }
            set { _Education = value; }
        }

        [Column(Name = "Job", DataType = "String")]
        public String Job
        {
            get { return _Job; }
            set { _Job = value; }
        }

        [Column(Name = "Religion", DataType = "String")]
        public String Religion
        {
            get { return _Religion; }
            set { _Religion = value; }
        }

        [Column(Name = "MaritalStatus", DataType = "String")]
        public String MaritalStatus
        {
            get { return _MaritalStatus; }
            set { _MaritalStatus = value; }
        }

        [Column(Name = "BloodType", DataType = "String")]
        public String BloodType
        {
            get { return _BloodType; }
            set { _BloodType = value; }
        }

        [Column(Name = "City", DataType = "String")]
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }

        [Column(Name = "PostalCode", DataType = "String")]
        public String PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }

        [Column(Name = "Nationality", DataType = "String")]
        public String Nationality
        {
            get { return _Nationality; }
            set { _Nationality = value; }
        }

        [Column(Name = "EmergencyContactName", DataType = "String")]
        public String EmergencyContactName
        {
            get { return _EmergencyContactName; }
            set { _EmergencyContactName = value; }
        }

        [Column(Name = "EmergencyContactRelation", DataType = "String")]
        public String EmergencyContactRelation
        {
            get { return _EmergencyContactRelation; }
            set { _EmergencyContactRelation = value; }
        }

        [Column(Name = "EmergencyContactAddr", DataType = "String")]
        public String EmergencyContactAddr
        {
            get { return _EmergencyContactAddr; }
            set { _EmergencyContactAddr = value; }
        }

        [Column(Name = "EmergencyContactPhone", DataType = "String")]
        public String EmergencyContactPhone
        {
            get { return _EmergencyContactPhone; }
            set { _EmergencyContactPhone = value; }
        }

        [Column(Name = "FatherOrHusband", DataType = "String")]
        public String FatherOrHusband
        {
            get { return _FatherOrHusband; }
            set { _FatherOrHusband = value; }
        }
        [Column(Name = "FatherOrHusbandAge", DataType = "Int32")]
        public Int32 FatherOrHusbandAge
        {
            get { return _FatherOrHusbandAge; }
            set { _FatherOrHusbandAge = value; }
        }
        [Column(Name = "FatherOrHusbandJob", DataType = "String")]
        public String FatherOrHusbandJob
        {
            get { return _FatherOrHusbandJob; }
            set { _FatherOrHusbandJob = value; }
        }
        [Column(Name = "MotherOrWife", DataType = "String")]
        public String MotherOrWife
        {
            get { return _MotherOrWife; }
            set { _MotherOrWife = value; }
        }
        [Column(Name = "MotherOrWifeAge", DataType = "Int32")]
        public Int32 MotherOrWifeAge
        {
            get { return _MotherOrWifeAge; }
            set { _MotherOrWifeAge = value; }
        }
        [Column(Name = "MotherOrWifeJob", DataType = "String")]
        public String MotherOrWifeJob
        {
            get { return _MotherOrWifeJob; }
            set { _MotherOrWifeJob = value; }
        }
        //[Column(Name = "Photo", DataType = "String")]
        //public String Photo
        //{
        //    get { return _Photo; }
        //    set { _Photo = value; }
        //}
    }
    #endregion
    #region vPatientBase
    [Serializable]
    [Table(Name = "vPatientBase")]
    public partial class vPatientBase
    {
        private String _MedicalNo;
        private String _FirstName;
        private String _LastName;
        private String _Gender;
        private DateTime _DateOfBirth;
        private String _HomeAddressLine1;
        private String _HomeAddressLine2;
        private String _Race;

        [Column(Name = "MedicalNo", DataType = "String")]
        public String MedicalNo
        {
            get { return _MedicalNo; }
            set { _MedicalNo = value; }
        }

        [Column(Name = "FirstName", DataType = "String")]
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        [Column(Name = "LastName", DataType = "String")]
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public String PatientName
        {
            get
            {
                return string.Format("{0} {1}", _FirstName, LastName);
            }
        }

        [Column(Name = "Gender", DataType = "String")]
        public String Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        [Column(Name = "DateOfBirth", DataType = "DateTime")]
        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }

        [Column(Name = "HomeAddressLine1", DataType = "String")]
        public String HomeAddressLine1
        {
            get { return _HomeAddressLine1; }
            set { _HomeAddressLine1 = value; }
        }

        [Column(Name = "HomeAddressLine2", DataType = "String")]
        public String HomeAddressLine2
        {
            get { return _HomeAddressLine2; }
            set { _HomeAddressLine2 = value; }
        }

        [Column(Name = "Race", DataType = "String")]
        public String Race
        {
            get { return _Race; }
            set { _Race = value; }
        }
    }
    #endregion
    #region vPatientConsultVisit
    [Serializable]
    [Table(Name = "vPatientConsultVisit")]
    public partial class vPatientConsultVisit : vPatient
    {
        private DateTime _RegistrationDate;
        private String _RegistrationTime;
        private String _RegistrationNo;
        private String _ServiceUnitCode;
        private String _ServiceUnitName;
        private String _ParamedicCode;
        private String _Doctor;
        private String _NoBukti;
        private String _NoPaket;
        private String _PayerCode;
        private String _Payer;
        private String _PhotoUrl;
        private Boolean _IsVoid;
        private Boolean _IsClosed;

        [Column(Name = "RegistrationDate", DataType = "DateTime")]
        public DateTime RegistrationDate
        {
            get { return _RegistrationDate; }
            set { _RegistrationDate = value; }
        }

        public String RegistrationDateInString
        {
            get { return _RegistrationDate.ToString("dd-MMM-yyyy"); }
        }

        [Column(Name = "RegistrationTime", DataType = "String")]
        public String RegistrationTime
        {
            get { return _RegistrationTime; }
            set { _RegistrationTime = value; }
        }

        [Column(Name = "RegistrationNo", DataType = "String")]
        public String RegistrationNo
        {
            get { return _RegistrationNo; }
            set { _RegistrationNo = value; }
        }

        [Column(Name = "ServiceUnitCode", DataType = "String")]
        public String ServiceUnitCode
        {
            get { return _ServiceUnitCode; }
            set { _ServiceUnitCode = value; }
        }

        [Column(Name = "ServiceUnitName", DataType = "String")]
        public String ServiceUnitName
        {
            get { return _ServiceUnitName; }
            set { _ServiceUnitName = value; }
        }

        [Column(Name = "NoBukti", DataType = "String")]
        public String NoBukti
        {
            get { return _NoBukti; }
            set { _NoBukti = value; }
        }

        [Column(Name = "NoPaket", DataType = "String")]
        public String NoPaket
        {
            get { return _NoPaket; }
            set { _NoPaket = value; }
        }

        [Column(Name = "ParamedicCode", DataType = "String")]
        public String ParamedicCode
        {
            get { return _ParamedicCode; }
            set { _ParamedicCode = value; }
        }

        [Column(Name = "Doctor", DataType = "String")]
        public String Doctor
        {
            get { return _Doctor; }
            set { _Doctor = value; }
        }

        [Column(Name = "PayerCode", DataType = "String")]
        public String PayerCode
        {
            get { return _PayerCode; }
            set { _PayerCode = value; }
        }

        [Column(Name = "Payer", DataType = "String")]
        public String Payer
        {
            get { return _Payer; }
            set { _Payer = value; }
        }

        [Column(Name = "PhotoUrl", DataType = "String")]
        public String PhotoUrl
        {
            get { return _PhotoUrl; }
            set { _PhotoUrl = value; }
        }

        [Column(Name = "IsVoid", DataType = "Boolean")]
        public Boolean IsVoid
        {
            get { return _IsVoid; }
            set { _IsVoid = value; }
        }

        [Column(Name = "IsClosed", DataType = "Boolean")]
        public Boolean IsClosed
        {
            get { return _IsClosed; }
            set { _IsClosed = value; }
        }
    }
    #endregion
    #region vPharmacyConsignmentOrder
    [Serializable]
    [Table(Name = "vPharmacyConsignmentOrder")]
    public class vPharmacyConsignmentOrder
    {
        private String _ConsignmentOrderNo;
        private DateTime _ConsignmentOrderDate;
        private String _ConsignmentOrderDateText;
        private DateTime _OrderDeliveryDate;
        private String _OrderDeliveryDateText;
        private String _SupplierCode;
        private String _SupplierName;
        private Boolean _IsApproved;
        private String _ItemCode;
        private String _ItemName;
        private Double _OrderQty;
        private String _Unit;
        private Decimal _Price;
        private Double _DiscountPc;

        [Column(Name = "ConsignmentOrderNo", DataType = "String")]
        public String ConsignmentOrderNo
        {
            get { return _ConsignmentOrderNo; }
            set { _ConsignmentOrderNo = value; }
        }
        [Column(Name = "ConsignmentOrderDate", DataType = "DateTime")]
        public DateTime ConsignmentOrderDate
        {
            get { return _ConsignmentOrderDate; }
            set { _ConsignmentOrderDate = value; }
        }
        [Column(Name = "ConsignmentOrderDateText", DataType = "String")]
        public String ConsignmentOrderDateText
        {
            get { return _ConsignmentOrderDateText; }
            set { _ConsignmentOrderDateText = value; }
        }
        [Column(Name = "OrderDeliveryDate", DataType = "DateTime")]
        public DateTime OrderDeliveryDate
        {
            get { return _OrderDeliveryDate; }
            set { _OrderDeliveryDate = value; }
        }
        [Column(Name = "OrderDeliveryDateText", DataType = "String")]
        public String OrderDeliveryDateText
        {
            get { return _OrderDeliveryDateText; }
            set { _OrderDeliveryDateText = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
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
        [Column(Name = "OrderQty", DataType = "Double")]
        public Double OrderQty
        {
            get { return _OrderQty; }
            set { _OrderQty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Price", DataType = "Decimal")]
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Column(Name = "DiscountPc", DataType = "Double")]
        public Double DiscountPc
        {
            get { return _DiscountPc; }
            set { _DiscountPc = value; }
        }
    }
    #endregion
    #region vPharmacyConsignmentReceive
    [Serializable]
    [Table(Name = "vPharmacyConsignmentReceive")]
    public class vPharmacyConsignmentReceive
    {
        private String _ConsignmentReceiveNo;
        private DateTime _ConsignmentReceiveDate;
        private String _ConsignmentReceiveDateText;
        private String _DeliveryNo;
        private String _SupplierCode;
        private String _SupplierName;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private Boolean _IsApproved;
        private String _ItemCode;
        private String _ItemName;
        private Double _ReceiveQty;
        private String _Unit;
        private Decimal _Price;
        private Decimal _Discount;
        private String _ConsignmentOrderNo;

        [Column(Name = "ConsignmentReceiveNo", DataType = "String")]
        public String ConsignmentReceiveNo
        {
            get { return _ConsignmentReceiveNo; }
            set { _ConsignmentReceiveNo = value; }
        }
        [Column(Name = "ConsignmentReceiveDate", DataType = "DateTime")]
        public DateTime ConsignmentReceiveDate
        {
            get { return _ConsignmentReceiveDate; }
            set { _ConsignmentReceiveDate = value; }
        }
        [Column(Name = "ConsignmentReceiveDateText", DataType = "String")]
        public String ConsignmentReceiveDateText
        {
            get { return _ConsignmentReceiveDateText; }
            set { _ConsignmentReceiveDateText = value; }
        }
        [Column(Name = "DeliveryNo", DataType = "String")]
        public String DeliveryNo
        {
            get { return _DeliveryNo; }
            set { _DeliveryNo = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
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
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
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
        [Column(Name = "ReceiveQty", DataType = "Double")]
        public Double ReceiveQty
        {
            get { return _ReceiveQty; }
            set { _ReceiveQty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Price", DataType = "Decimal")]
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Column(Name = "Discount", DataType = "Decimal")]
        public Decimal Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        [Column(Name = "ConsignmentOrderNo", DataType = "String")]
        public String ConsignmentOrderNo
        {
            get { return _ConsignmentOrderNo; }
            set { _ConsignmentOrderNo = value; }
        }
    }
    #endregion
    #region vPharmacyConsignmentReturn
    [Serializable]
    [Table(Name = "vPharmacyConsignmentReturn")]
    public class vPharmacyConsignmentReturn
    {
        private String _ConsignmentReturnNo;
        private DateTime _ConsignmentReturnDate;
        private String _ConsignmentReturnDateText;
        private String _SupplierCode;
        private String _SupplierName;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private Boolean _IsApproved;
        private String _ItemCode;
        private String _ItemName;
        private Double _ReturQty;
        private String _Unit;
        private Decimal _Price;
        private Decimal _Discount;

        [Column(Name = "ConsignmentReturnNo", DataType = "String")]
        public String ConsignmentReturnNo
        {
            get { return _ConsignmentReturnNo; }
            set { _ConsignmentReturnNo = value; }
        }
        [Column(Name = "ConsignmentReturnDate", DataType = "DateTime")]
        public DateTime ConsignmentReturnDate
        {
            get { return _ConsignmentReturnDate; }
            set { _ConsignmentReturnDate = value; }
        }
        [Column(Name = "ConsignmentReturnDateText", DataType = "String")]
        public String ConsignmentReturnDateText
        {
            get { return _ConsignmentReturnDateText; }
            set { _ConsignmentReturnDateText = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
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
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
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
        [Column(Name = "ReturQty", DataType = "Double")]
        public Double ReturQty
        {
            get { return _ReturQty; }
            set { _ReturQty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Price", DataType = "Decimal")]
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Column(Name = "Discount", DataType = "Decimal")]
        public Decimal Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
    }
    #endregion
    #region vPharmacyCreditNote
    [Serializable]
    [Table(Name = "vPharmacyCreditNote")]
    public class vPharmacyCreditNote
    {
        private String _CreditNoteNo;
        private String _PurchaseReturnNo;
        private DateTime _CreditNoteDate;
        private String _CreditNoteDateText;
        private String _SupplierCode;
        private String _SupplierName;
        private Double _CreditNoteValue;
        private Double _VATAmount;
        private String _VoucherNo;
        private String _Remark;
        private Boolean _IsApproved;

        [Column(Name = "CreditNoteNo", DataType = "String")]
        public String CreditNoteNo
        {
            get { return _CreditNoteNo; }
            set { _CreditNoteNo = value; }
        }
        [Column(Name = "PurchaseReturnNo", DataType = "String")]
        public String PurchaseReturnNo
        {
            get { return _PurchaseReturnNo; }
            set { _PurchaseReturnNo = value; }
        }
        [Column(Name = "CreditNoteDate", DataType = "DateTime")]
        public DateTime CreditNoteDate
        {
            get { return _CreditNoteDate; }
            set { _CreditNoteDate = value; }
        }
        [Column(Name = "CreditNoteDateText", DataType = "String")]
        public String CreditNoteDateText
        {
            get { return _CreditNoteDateText; }
            set { _CreditNoteDateText = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }
        [Column(Name = "CreditNoteValue", DataType = "Double")]
        public Double CreditNoteValue
        {
            get { return _CreditNoteValue; }
            set { _CreditNoteValue = value; }
        }
        [Column(Name = "VATAmount", DataType = "Double")]
        public Double VATAmount
        {
            get { return _VATAmount; }
            set { _VATAmount = value; }
        }
        [Column(Name = "VoucherNo", DataType = "String")]
        public String VoucherNo
        {
            get { return _VoucherNo; }
            set { _VoucherNo = value; }
        }
        [Column(Name = "Remark", DataType = "String")]
        public String Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
    }
    #endregion
    #region vPharmacyDirectPurchase
    [Serializable]
    [Table(Name = "vPharmacyDirectPurchase")]
    public partial class vPharmacyDirectPurchase
    {
        private String _DirectPurchaseNo;
        private DateTime _DirectPurchaseDate;
        private String _DirectPurchaseDateText;
        private String _SupplierCode;
        private String _SupplierName;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private Double _HeaderVAT;
        private String _Updater;
        private String _ItemCode;
        private String _ItemName;
        private Double _Price;
        private String _Unit;
        private Double _Qty;
        private Double _DiscountPerc;
        private Boolean _IsVAT;

        [Column(Name = "DirectPurchaseNo", DataType = "String")]
        public String DirectPurchaseNo
        {
            get { return _DirectPurchaseNo; }
            set { _DirectPurchaseNo = value; }
        }
        [Column(Name = "DirectPurchaseDate", DataType = "DateTime")]
        public DateTime DirectPurchaseDate
        {
            get { return _DirectPurchaseDate; }
            set { _DirectPurchaseDate = value; }
        }
        [Column(Name = "DirectPurchaseDateText", DataType = "String")]
        public String DirectPurchaseDateText
        {
            get { return _DirectPurchaseDateText; }
            set { _DirectPurchaseDateText = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
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
        [Column(Name = "HeaderVAT", DataType = "Double")]
        public Double HeaderVAT
        {
            get { return _HeaderVAT; }
            set { _HeaderVAT = value; }
        }
        [Column(Name = "Updater", DataType = "String")]
        public String Updater
        {
            get { return _Updater; }
            set { _Updater = value; }
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
        [Column(Name = "Price", DataType = "Double")]
        public Double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Qty", DataType = "Double")]
        public Double Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        [Column(Name = "DiscountPerc", DataType = "Double")]
        public Double DiscountPerc
        {
            get { return _DiscountPerc; }
            set { _DiscountPerc = value; }
        }
        [Column(Name = "IsVAT", DataType = "Boolean")]
        public Boolean IsVAT
        {
            get { return _IsVAT; }
            set { _IsVAT = value; }
        }
    }
    #endregion
    #region vPharmacyDirectPurchaseReturn
    [Serializable]
    [Table(Name = "vPharmacyDirectPurchaseReturn")]
    public class vPharmacyDirectPurchaseReturn
    {
        private String _PurchaseReturnNo;
        private String _SupplierCode;
        private String _SupplierName;
        private DateTime _PurchaseReturnDate;
        private String _PurchaseReturnDateText;
        private String _DirectPurchaseNo;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private String _Remark;
        private String _ItemCode;
        private String _ItemName;
        private Double _ReturnQty;
        private String _Unit;
        private Decimal _Price;
        private Double _Discount;
        private Boolean _IsApproved;

        [Column(Name = "PurchaseReturnNo", DataType = "String")]
        public String PurchaseReturnNo
        {
            get { return _PurchaseReturnNo; }
            set { _PurchaseReturnNo = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }
        [Column(Name = "PurchaseReturnDate", DataType = "DateTime")]
        public DateTime PurchaseReturnDate
        {
            get { return _PurchaseReturnDate; }
            set { _PurchaseReturnDate = value; }
        }
        [Column(Name = "PurchaseReturnDateText", DataType = "String")]
        public String PurchaseReturnDateText
        {
            get { return _PurchaseReturnDateText; }
            set { _PurchaseReturnDateText = value; }
        }
        [Column(Name = "DirectPurchaseNo", DataType = "String")]
        public String DirectPurchaseNo
        {
            get { return _DirectPurchaseNo; }
            set { _DirectPurchaseNo = value; }
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
        [Column(Name = "Remark", DataType = "String")]
        public String Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
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
        [Column(Name = "ReturnQty", DataType = "Double")]
        public Double ReturnQty
        {
            get { return _ReturnQty; }
            set { _ReturnQty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Price", DataType = "Decimal")]
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Column(Name = "Discount", DataType = "Double")]
        public Double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
    }
    #endregion
    #region vPharmacyGoodsRequest
    [Serializable]
    [Table(Name = "vPharmacyGoodsRequest")]
    public partial class vPharmacyGoodsRequest
    {
        private String _GoodsRequestNo;
        private DateTime _GoodsRequestDate;
        private String _GoodsRequestDateText;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private String _DepartmentCode;
        private String _DepartmentName;
        private String _RequestDescription;
        private String _ProductLineCode;
        private String _ProductLine;
        private String _ItemCode;
        private String _ItemName;
        private Double _Qty;
        private String _Unit;
        private Boolean _IsApproved;
        private String _UserApproval;
        private DateTime _GoodsRequestApprovalDate;
        private String _GoodsRequestApprovalDateText;

        [Column(Name = "GoodsRequestNo", DataType = "String")]
        public String GoodsRequestNo
        {
            get { return _GoodsRequestNo; }
            set { _GoodsRequestNo = value; }
        }
        [Column(Name = "GoodsRequestDate", DataType = "DateTime")]
        public DateTime GoodsRequestDate
        {
            get { return _GoodsRequestDate; }
            set { _GoodsRequestDate = value; }
        }
        [Column(Name = "GoodsRequestDateText", DataType = "String")]
        public String GoodsRequestDateText
        {
            get { return _GoodsRequestDateText; }
            set { _GoodsRequestDateText = value; }
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
        [Column(Name = "DepartmentCode", DataType = "String")]
        public String DepartmentCode
        {
            get { return _DepartmentCode; }
            set { _DepartmentCode = value; }
        }
        [Column(Name = "DepartmentName", DataType = "String")]
        public String DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
        }
        [Column(Name = "RequestDescription", DataType = "String")]
        public String RequestDescription
        {
            get { return _RequestDescription; }
            set { _RequestDescription = value; }
        }
        [Column(Name = "ProductLineCode", DataType = "String")]
        public String ProductLineCode
        {
            get { return _ProductLineCode; }
            set { _ProductLineCode = value; }
        }
        [Column(Name = "ProductLine", DataType = "String")]
        public String ProductLine
        {
            get { return _ProductLine; }
            set { _ProductLine = value; }
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
        [Column(Name = "Qty", DataType = "Double")]
        public Double Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
        [Column(Name = "UserApproval", DataType = "String")]
        public String UserApproval
        {
            get { return _UserApproval; }
            set { _UserApproval = value; }
        }
        [Column(Name = "GoodsRequestApprovalDate", DataType = "DateTime")]
        public DateTime GoodsRequestApprovalDate
        {
            get { return _GoodsRequestApprovalDate; }
            set { _GoodsRequestApprovalDate = value; }
        }
        [Column(Name = "GoodsRequestApprovalDateText", DataType = "String")]
        public String GoodsRequestApprovalDateText
        {
            get { return _GoodsRequestApprovalDateText; }
            set { _GoodsRequestApprovalDateText = value; }
        }
    }
    #endregion
    #region vPharmacyItem
    [Serializable]
    [Table(Name = "vPharmacyItem")]
    public partial class vPharmacyItem
    {
        private String _ItemCode;
        private String _ItemName;
        private String _TherapyGroup;
        private String _ProductLineCode;
        private String _ProductLine;
        private String _DKK;
        private String _GroupCode;
        private String _GroupName;
        private String _SubGroupName;
        private String _Type;
        private String _CatalogNo;
        private String _SmallUnit;
        private String _BigUnit;
        private Double _FactorBs;
        private Decimal _BasePrice;
        private Decimal _AveragePrice;
        private Boolean _Formularium;
        private DateTime _ProductionDate;
        private String _ProductionDateText;
        private String _LastSupplierCode;
        private String _LastSupplierName;
        private String _ManufacturerCode;
        private String _ManufacturerName;
        private Decimal _OldPrice;
        private Decimal _LatestPrice;
        private Double _SalesPrice;
        private Decimal _HET;
        private Double _Markup;
        private Double _GroupMarkup;
        private Double _Discount;
        private Double _Discount2;
        private Double _VAT;
        private String _ABCClass;

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
        [Column(Name = "TherapyGroup", DataType = "String")]
        public String TherapyGroup
        {
            get { return _TherapyGroup; }
            set { _TherapyGroup = value; }
        }
        [Column(Name = "ProductLineCode", DataType = "String")]
        public String ProductLineCode
        {
            get { return _ProductLineCode; }
            set { _ProductLineCode = value; }
        }
        [Column(Name = "ProductLine", DataType = "String")]
        public String ProductLine
        {
            get { return _ProductLine; }
            set { _ProductLine = value; }
        }
        [Column(Name = "DKK", DataType = "String")]
        public String DKK
        {
            get { return _DKK; }
            set { _DKK = value; }
        }
        [Column(Name = "GroupCode", DataType = "String")]
        public String GroupCode
        {
            get { return _GroupCode; }
            set { _GroupCode= value; }
        }
        [Column(Name = "GroupName", DataType = "String")]
        public String GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }
        [Column(Name = "SubGroupName", DataType = "String")]
        public String SubGroupName
        {
            get { return _SubGroupName; }
            set { _SubGroupName = value; }
        }
        [Column(Name = "Type", DataType = "String")]
        public String Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        [Column(Name = "CatalogNo", DataType = "String")]
        public String CatalogNo
        {
            get { return _CatalogNo; }
            set { _CatalogNo = value; }
        }
        [Column(Name = "SmallUnit", DataType = "String")]
        public String SmallUnit
        {
            get { return _SmallUnit; }
            set { _SmallUnit = value; }
        }
        [Column(Name = "BigUnit", DataType = "String")]
        public String BigUnit
        {
            get { return _BigUnit; }
            set { _BigUnit = value; }
        }
        [Column(Name = "FactorBs", DataType = "Double")]
        public Double FactorBs
        {
            get { return _FactorBs; }
            set { _FactorBs = value; }
        }
        [Column(Name = "BasePrice", DataType = "Decimal")]
        public Decimal BasePrice
        {
            get { return _BasePrice; }
            set { _BasePrice = value; }
        }
        [Column(Name = "AveragePrice", DataType = "Decimal")]
        public Decimal AveragePrice
        {
            get { return _AveragePrice; }
            set { _AveragePrice = value; }
        }
        [Column(Name = "Formularium", DataType = "Boolean")]
        public Boolean Formularium
        {
            get { return _Formularium; }
            set { _Formularium = value; }
        }
        [Column(Name = "ProductionDate", DataType = "DateTime")]
        public DateTime ProductionDate
        {
            get { return _ProductionDate; }
            set { _ProductionDate = value; }
        }
        [Column(Name = "ProductionDateText", DataType = "String")]
        public String ProductionDateText
        {
            get { return _ProductionDateText; }
            set { _ProductionDateText = value; }
        }
        [Column(Name = "LastSupplierCode", DataType = "String")]
        public String LastSupplierCode
        {
            get { return _LastSupplierCode; }
            set { _LastSupplierCode = value; }
        }
        [Column(Name = "LastSupplierName", DataType = "String")]
        public String LastSupplierName
        {
            get { return _LastSupplierName; }
            set { _LastSupplierName = value; }
        }
        [Column(Name = "ManufacturerCode", DataType = "String")]
        public String ManufacturerCode
        {
            get { return _ManufacturerCode; }
            set { _ManufacturerCode = value; }
        }
        [Column(Name = "ManufacturerName", DataType = "String")]
        public String ManufacturerName
        {
            get { return _ManufacturerName; }
            set { _ManufacturerName = value; }
        }
        [Column(Name = "OldPrice", DataType = "Decimal")]
        public Decimal OldPrice
        {
            get { return _OldPrice; }
            set { _OldPrice = value; }
        }
        [Column(Name = "LatestPrice", DataType = "Decimal")]
        public Decimal LatestPrice
        {
            get { return _LatestPrice; }
            set { _LatestPrice = value; }
        }
        [Column(Name = "SalesPrice", DataType = "Double")]
        public Double SalesPrice
        {
            get { return _SalesPrice; }
            set { _SalesPrice = value; }
        }
        [Column(Name = "HET", DataType = "Decimal")]
        public Decimal HET
        {
            get { return _HET; }
            set { _HET = value; }
        }
        [Column(Name = "Markup", DataType = "Double")]
        public Double Markup
        {
            get { return _Markup; }
            set { _Markup = value; }
        }
        [Column(Name = "GroupMarkup", DataType = "Double")]
        public Double GroupMarkup
        {
            get { return _GroupMarkup; }
            set { _GroupMarkup = value; }
        }
        [Column(Name = "Discount", DataType = "Double")]
        public Double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        [Column(Name = "Discount2", DataType = "Double")]
        public Double Discount2
        {
            get { return _Discount2; }
            set { _Discount2 = value; }
        }
        [Column(Name = "VAT", DataType = "Double")]
        public Double VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }
        [Column(Name = "ABCClass", DataType = "String")]
        public String ABCClass
        {
            get { return _ABCClass; }
            set { _ABCClass = value; }
        }
    }
    #endregion
    #region vPharmacyItemAdjustment
    [Serializable]
    [Table(Name = "vPharmacyItemAdjustment")]
    public class vPharmacyItemAdjustment
    {
        private String _AdjustmentNo;
        private DateTime _AdjustmentDate;
        private String _AdjustmentDateText;
        private String _WarehouseCode;
        private String _WarehouseName;
        private Boolean _IsApproved;
        private String _LocationCode;
        private String _LocationName;
        private String _ItemCode;
        private String _ItemName;
        private Double _Qty;
        private String _Unit;
        private String _Reason;
        private String _Updater;
        private Decimal _Price;

        [Column(Name = "AdjustmentNo", DataType = "String")]
        public String AdjustmentNo
        {
            get { return _AdjustmentNo; }
            set { _AdjustmentNo = value; }
        }
        [Column(Name = "AdjustmentDate", DataType = "DateTime")]
        public DateTime AdjustmentDate
        {
            get { return _AdjustmentDate; }
            set { _AdjustmentDate = value; }
        }
        [Column(Name = "AdjustmentDateText", DataType = "String")]
        public String AdjustmentDateText
        {
            get { return _AdjustmentDateText; }
            set { _AdjustmentDateText = value; }
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
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
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
        [Column(Name = "Qty", DataType = "Double")]
        public Double Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Reason", DataType = "String")]
        public String Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }
        [Column(Name = "Updater", DataType = "String")]
        public String Updater
        {
            get { return _Updater; }
            set { _Updater = value; }
        }
        [Column(Name = "Price", DataType = "Decimal")]
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
    }
    #endregion
    #region vPharmacyItemConsumption
    [Serializable]
    [Table(Name = "vPharmacyItemConsumption")]
    public class vPharmacyItemConsumption
    {
        private String _ConsumptionNo;
        private DateTime _ConsumptionDate;
        private String _ConsumptionDateText;
        private String _DepartmentCode;
        private String _DepartmentName;
        private String _WarehouseCode;
        private String _WarehouseName;
        private Boolean _IsApproved;
        private String _LocationCode;
        private String _LocationName;
        private String _ItemCode;
        private String _ItemName;
        private Double _Qty;
        private String _Unit;
        private Double _Price;

        [Column(Name = "ConsumptionNo", DataType = "String")]
        public String ConsumptionNo
        {
            get { return _ConsumptionNo; }
            set { _ConsumptionNo = value; }
        }
        [Column(Name = "ConsumptionDate", DataType = "DateTime")]
        public DateTime ConsumptionDate
        {
            get { return _ConsumptionDate; }
            set { _ConsumptionDate = value; }
        }
        [Column(Name = "ConsumptionDateText", DataType = "String")]
        public String ConsumptionDateText
        {
            get { return _ConsumptionDateText; }
            set { _ConsumptionDateText = value; }
        }
        [Column(Name = "DepartmentCode", DataType = "String")]
        public String DepartmentCode
        {
            get { return _DepartmentCode; }
            set { _DepartmentCode = value; }
        }
        [Column(Name = "DepartmentName", DataType = "String")]
        public String DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
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
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
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
        [Column(Name = "Qty", DataType = "Double")]
        public Double Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Price", DataType = "Double")]
        public Double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
    }
    #endregion
    #region vPharmacyItemDistribution
    [Serializable]
    [Table(Name = "vPharmacyItemDistribution")]
    public class vPharmacyItemDistribution
    {
        private String _DistributionNo;
        private DateTime _DistributionDate;
        private String _DistributionDateText;
        private String _DistributionType;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private String _OtherWarehouseCode;
        private String _OtherWarehouseName;
        private String _OtherLocationCode;
        private String _OtherLocationName;
        private String _ItemCode;
        private String _ItemName;
        private Decimal _Qty;
        private String _Unit;
        private String _Updater;

        [Column(Name = "DistributionNo", DataType = "String")]
        public String DistributionNo
        {
            get { return _DistributionNo; }
            set { _DistributionNo = value; }
        }
        [Column(Name = "DistributionDate", DataType = "DateTime")]
        public DateTime DistributionDate
        {
            get { return _DistributionDate; }
            set { _DistributionDate = value; }
        }
        [Column(Name = "DistributionDateText", DataType = "String")]
        public String DistributionDateText
        {
            get { return _DistributionDateText; }
            set { _DistributionDateText = value; }
        }
        [Column(Name = "DistributionType", DataType = "String")]
        public String DistributionType
        {
            get { return _DistributionType; }
            set { _DistributionType = value; }
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
        [Column(Name = "OtherWarehouseCode", DataType = "String")]
        public String OtherWarehouseCode
        {
            get { return _OtherWarehouseCode; }
            set { _OtherWarehouseCode = value; }
        }
        [Column(Name = "OtherWarehouseName", DataType = "String")]
        public String OtherWarehouseName
        {
            get { return _OtherWarehouseName; }
            set { _OtherWarehouseName = value; }
        }
        [Column(Name = "OtherLocationCode", DataType = "String")]
        public String OtherLocationCode
        {
            get { return _OtherLocationCode; }
            set { _OtherLocationCode = value; }
        }
        [Column(Name = "OtherLocationName", DataType = "String")]
        public String OtherLocationName
        {
            get { return _OtherLocationName; }
            set { _OtherLocationName = value; }
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
        [Column(Name = "Qty", DataType = "Decimal")]
        public Decimal Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Updater", DataType = "String")]
        public String Updater
        {
            get { return _Updater; }
            set { _Updater = value; }
        }
    }
    #endregion
    #region vPharmacyItemPriceAdjustment
    [Serializable]
    [Table(Name = "vPharmacyItemPriceAdjustment")]
    public partial class vPharmacyItemPriceAdjustment
    {
        private String _ItemCode;
        private String _ItemName;
        private Decimal _AveragePrice;
        private Decimal _BaseUnitPrice;
        private Decimal _AlternateUnitPrice;
        private Decimal _AvgPriceAfterVAT;
        private Decimal _NewAveragePrice;
        private Decimal _NewBaseUnitPrice;
        private Decimal _NewAlternateUnitPrice;
        private Decimal _NewAvgPriceAfterVAT;
        private DateTime _UpdatedDate;
        private String _UpdatedDateText;
        private String _UpdatedUser;
        private Double _LastQuantity;

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
        [Column(Name = "AveragePrice", DataType = "Decimal")]
        public Decimal AveragePrice
        {
            get { return Math.Round(_AveragePrice, 2); }
            set { _AveragePrice = value; }
        }
        [Column(Name = "BaseUnitPrice", DataType = "Decimal")]
        public Decimal BaseUnitPrice
        {
            get { return Math.Round(_BaseUnitPrice, 2); }
            set { _BaseUnitPrice = value; }
        }
        [Column(Name = "BaseAlternatePrice", DataType = "Decimal")]
        public Decimal AlternateUnitPrice
        {
            get { return Math.Round(_AlternateUnitPrice, 2); }
            set { _AlternateUnitPrice = value; }
        }
        [Column(Name = "AvgPriceAfterVAT", DataType = "Decimal")]
        public Decimal AvgPriceAfterVAT
        {
            get { return Math.Round(_AvgPriceAfterVAT, 2); }
            set { _AvgPriceAfterVAT = value; }
        }
        [Column(Name = "NewAveragePrice", DataType = "Decimal")]
        public Decimal NewAveragePrice
        {
            get { return Math.Round(_NewAveragePrice, 2); }
            set { _NewAveragePrice = value; }
        }
        [Column(Name = "NewBaseUnitPrice", DataType = "Decimal")]
        public Decimal NewBaseUnitPrice
        {
            get { return Math.Round(_NewBaseUnitPrice, 2); }
            set { _NewBaseUnitPrice = value; }
        }
        [Column(Name = "NewAlternateUnitPrice", DataType = "Decimal")]
        public Decimal NewAlternateUnitPrice
        {
            get { return Math.Round(_NewAlternateUnitPrice, 2); }
            set { _NewAlternateUnitPrice = value; }
        }
        [Column(Name = "NewAvgPriceAfterVAT", DataType = "Decimal")]
        public Decimal NewAvgPriceAfterVAT
        {
            get { return Math.Round(_NewAvgPriceAfterVAT, 2); }
            set { _NewAvgPriceAfterVAT = value; }
        }
        [Column(Name = "UpdatedDate", DataType = "DateTime")]
        public DateTime UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }
        [Column(Name = "UpdatedDateText", DataType = "String")]
        public String UpdatedDateText
        {
            get { return _UpdatedDateText; }
            set { _UpdatedDateText = value; }
        }
        [Column(Name = "UpdatedUser", DataType = "String")]
        public String UpdatedUser
        {
            get { return _UpdatedUser; }
            set { _UpdatedUser = value; }
        }
        [Column(Name = "LastQuantity", DataType = "Double")]
        public Double LastQuantity
        {
            get { return _LastQuantity; }
            set { _LastQuantity = value; }
        }
    }
    #endregion
    #region vPharmacyItemProduction
    [Serializable]
    [Table(Name = "vPharmacyItemProduction")]
    public class vPharmacyItemProduction
    {
        private String _ProductionNo;
        private DateTime _ProductionDate;
        private String _ProductionDateText;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private String _ItemCode;
        private String _ItemName;
        private Double _Qty;
        private String _Unit;
        private Double _Price;
        private Double _ProductionCost;
        private Boolean _IsApproved;
        private String _ComponentItemCode;
        private String _ComponentItemName;
        private Double _ComponentQty;
        private String _ComponentUnit;

        [Column(Name = "ProductionNo", DataType = "String")]
        public String ProductionNo
        {
            get { return _ProductionNo; }
            set { _ProductionNo = value; }
        }
        [Column(Name = "ProductionDate", DataType = "DateTime")]
        public DateTime ProductionDate
        {
            get { return _ProductionDate; }
            set { _ProductionDate = value; }
        }
        [Column(Name = "ProductionDateText", DataType = "String")]
        public String ProductionDateText
        {
            get { return _ProductionDateText; }
            set { _ProductionDateText = value; }
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
        [Column(Name = "Qty", DataType = "Double")]
        public Double Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Price", DataType = "Double")]
        public Double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Column(Name = "ProductionCost", DataType = "Double")]
        public Double ProductionCost
        {
            get { return _ProductionCost; }
            set { _ProductionCost = value; }
        }
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
        [Column(Name = "ComponentItemCode", DataType = "String")]
        public String ComponentItemCode
        {
            get { return _ComponentItemCode; }
            set { _ComponentItemCode = value; }
        }
        [Column(Name = "ComponentItemName", DataType = "String")]
        public String ComponentItemName
        {
            get { return _ComponentItemName; }
            set { _ComponentItemName = value; }
        }
        [Column(Name = "ComponentQty", DataType = "Double")]
        public Double ComponentQty
        {
            get { return _ComponentQty; }
            set { _ComponentQty = value; }
        }
        [Column(Name = "ComponentUnit", DataType = "String")]
        public String ComponentUnit
        {
            get { return _ComponentUnit; }
            set { _ComponentUnit = value; }
        }
    }
    #endregion
    #region vPharmacyItemReorderPoint
    [Serializable]
    [Table(Name = "vPharmacyItemReorderPoint")]
    public class vPharmacyItemReorderPoint
    {
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _Location;
        private String _ItemCode;
        private String _ItemName;
        private Double _MinStock;
        private Double _MaxStock;
        private String _SmallUnit;

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
        [Column(Name = "Location", DataType = "String")]
        public String Location
        {
            get { return _Location; }
            set { _Location = value; }
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
        [Column(Name = "MinStock", DataType = "Double")]
        public Double MinStock
        {
            get { return _MinStock; }
            set { _MinStock = value; }
        }
        [Column(Name = "MaxStock", DataType = "Double")]
        public Double MaxStock
        {
            get { return _MaxStock; }
            set { _MaxStock = value; }
        }
        [Column(Name = "SmallUnit", DataType = "String")]
        public String SmallUnit
        {
            get { return _SmallUnit; }
            set { _SmallUnit = value; }
        }
    }
    #endregion
    #region vPharmacyPrescriptionReturn
    [Serializable]
    [Table(Name = "vPharmacyPrescriptionReturn")]
    public class vPharmacyPrescriptionReturn
    {
        private String _FacilityCode;
        private String _Facility;
        private String _PrescriptionReturnNo;
        private DateTime _PrescriptionReturnDate;
        private String _PrescriptionReturnDateText;
        private Boolean _IsApproved;
        private String _PrescriptionNo;
        private String _ItemCode;
        private String _ItemName;
        private Double _ReturnQty;
        private String _ItemUnit;
        private Double _SalesPrice;
        private Double _Amount;

        [Column(Name = "FacilityCode", DataType = "String")]
        public String FacilityCode
        {
            get { return _FacilityCode; }
            set { _FacilityCode = value; }
        }
        [Column(Name = "Facility", DataType = "String")]
        public String Facility
        {
            get { return _Facility; }
            set { _Facility = value; }
        }
        [Column(Name = "PrescriptionReturnNo", DataType = "String")]
        public String PrescriptionReturnNo
        {
            get { return _PrescriptionReturnNo; }
            set { _PrescriptionReturnNo = value; }
        }
        [Column(Name = "PrescriptionReturnDate", DataType = "DateTime")]
        public DateTime PrescriptionReturnDate
        {
            get { return _PrescriptionReturnDate; }
            set { _PrescriptionReturnDate = value; }
        }
        [Column(Name = "PrescriptionReturnDateText", DataType = "String")]
        public String PrescriptionReturnDateText
        {
            get { return _PrescriptionReturnDateText; }
            set { _PrescriptionReturnDateText = value; }
        }
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
        [Column(Name = "PrescriptionNo", DataType = "String")]
        public String PrescriptionNo
        {
            get { return _PrescriptionNo; }
            set { _PrescriptionNo = value; }
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
        [Column(Name = "ReturnQty", DataType = "Double")]
        public Double ReturnQty
        {
            get { return _ReturnQty; }
            set { _ReturnQty = value; }
        }
        [Column(Name = "ItemUnit", DataType = "String")]
        public String ItemUnit
        {
            get { return _ItemUnit; }
            set { _ItemUnit = value; }
        }
        [Column(Name = "SalesPrice", DataType = "Double")]
        public Double SalesPrice
        {
            get { return _SalesPrice; }
            set { _SalesPrice = value; }
        }
        [Column(Name = "Amount", DataType = "Double")]
        public Double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
    }
    #endregion
    #region vPharmacyPrescriptionSales
    [Serializable]
    [Table(Name = "vPharmacyPrescriptionSales")]
    public class vPharmacyPrescriptionSales
    {
        private String _FacilityCode;
        private String _Facility;
        private String _PrescriptionNo;
        private DateTime _PrescriptionDate;
        private String _PrescriptionDateText;
        private String _OrderNo;
        private String _RegistrationNo;
        private String _MedicalNo;
        private String _FirstName;
        private String _LastName;
        private String _PhysicianCode;
        private String _PhysicianName;
        private String _PayerCode;
        private String _Payer;
        private Boolean _IsPrescription;
        private String _ItemCode;
        private String _ItemName;
        private String _UsedQty;
        private String _ItemUnit;
        private Double _SalesPrice;
        private Double _ChargeQty;
        private Double _Amount;
        private Double _Discount;
        private Boolean _IsFormularium;
        private Double _DrugClassificationCode;
        private String _DrugClassificationName;
        private String _TherapyCode;
        private String _TherapyName;
        private String _DetailTherapyCode;
        private String _DetailTherapyName;

        [Column(Name = "FacilityCode", DataType = "String")]
        public String FacilityCode
        {
            get { return _FacilityCode; }
            set { _FacilityCode = value; }
        }
        [Column(Name = "Facility", DataType = "String")]
        public String Facility
        {
            get { return _Facility; }
            set { _Facility = value; }
        }
        [Column(Name = "PrescriptionNo", DataType = "String")]
        public String PrescriptionNo
        {
            get { return _PrescriptionNo; }
            set { _PrescriptionNo = value; }
        }
        [Column(Name = "PrescriptionDate", DataType = "DateTime")]
        public DateTime PrescriptionDate
        {
            get { return _PrescriptionDate; }
            set { _PrescriptionDate = value; }
        }
        [Column(Name = "PrescriptionDateText", DataType = "String")]
        public String PrescriptionDateText
        {
            get { return _PrescriptionDateText; }
            set { _PrescriptionDateText = value; }
        }
        [Column(Name = "OrderNo", DataType = "String")]
        public String OrderNo
        {
            get { return _OrderNo; }
            set { _OrderNo = value; }
        }
        [Column(Name = "RegistrationNo", DataType = "String")]
        public String RegistrationNo
        {
            get { return _RegistrationNo; }
            set { _RegistrationNo = value; }
        }
        [Column(Name = "MedicalNo", DataType = "String")]
        public String MedicalNo
        {
            get { return _MedicalNo; }
            set { _MedicalNo = value; }
        }
        [Column(Name = "FirstName", DataType = "String")]
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        [Column(Name = "LastName", DataType = "String")]
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        [Column(Name = "PhysicianCode", DataType = "String")]
        public String PhysicianCode
        {
            get { return _PhysicianCode; }
            set { _PhysicianCode = value; }
        }
        [Column(Name = "PhysicianName", DataType = "String")]
        public String PhysicianName
        {
            get { return _PhysicianName; }
            set { _PhysicianName = value; }
        }
        [Column(Name = "PayerCode", DataType = "String")]
        public String PayerCode
        {
            get { return _PayerCode; }
            set { _PayerCode = value; }
        }
        [Column(Name = "Payer", DataType = "String")]
        public String Payer
        {
            get { return _Payer; }
            set { _Payer = value; }
        }
        [Column(Name = "IsPrescription", DataType = "Boolean")]
        public Boolean IsPrescription
        {
            get { return _IsPrescription; }
            set { _IsPrescription = value; }
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
        [Column(Name = "UsedQty", DataType = "String")]
        public String UsedQty
        {
            get { return _UsedQty; }
            set { _UsedQty = value; }
        }
        [Column(Name = "ItemUnit", DataType = "String")]
        public String ItemUnit
        {
            get { return _ItemUnit; }
            set { _ItemUnit = value; }
        }
        [Column(Name = "SalesPrice", DataType = "Double")]
        public Double SalesPrice
        {
            get { return _SalesPrice; }
            set { _SalesPrice = value; }
        }
        [Column(Name = "ChargeQty", DataType = "Double")]
        public Double ChargeQty
        {
            get { return _ChargeQty; }
            set { _ChargeQty = value; }
        }
        [Column(Name = "Amount", DataType = "Double")]
        public Double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        [Column(Name = "Discount", DataType = "Double")]
        public Double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        [Column(Name = "IsFormularium", DataType = "Boolean")]
        public Boolean IsFormularium
        {
            get { return _IsFormularium; }
            set { _IsFormularium = value; }
        }
        [Column(Name = "DrugClassificationCode", DataType = "Double")]
        public Double DrugClassificationCode
        {
            get { return _DrugClassificationCode; }
            set { _DrugClassificationCode = value; }
        }
        [Column(Name = "DrugClassificationName", DataType = "String")]
        public String DrugClassificationName
        {
            get { return _DrugClassificationName; }
            set { _DrugClassificationName = value; }
        }
        [Column(Name = "TherapyCode", DataType = "String")]
        public String TherapyCode
        {
            get { return _TherapyCode; }
            set { _TherapyCode = value; }
        }
        [Column(Name = "TherapyName", DataType = "String")]
        public String TherapyName
        {
            get { return _TherapyName; }
            set { _TherapyName = value; }
        }
        [Column(Name = "DetailTherapyCode", DataType = "String")]
        public String DetailTherapyCode
        {
            get { return _DetailTherapyCode; }
            set { _DetailTherapyCode = value; }
        }
        [Column(Name = "DetailTherapyName", DataType = "String")]
        public String DetailTherapyName
        {
            get { return _DetailTherapyName; }
            set { _DetailTherapyName = value; }
        }
    }
    #endregion
    #region vPharmacyPurchaseOrder
    [Serializable]
    [Table(Name = "vPharmacyPurchaseOrder")]
    public partial class vPharmacyPurchaseOrder
    {
        private String _PurchaseOrderNo;
        private String _SupplierCode;
        private String _SupplierName;
        private DateTime _PurchaseOrderDate;
        private String _PurchaseOrderDateText;
        private DateTime _OrderDeliveryDate;
        private String _OrderDeliveryDateText;
        private String _PurchaseRequestNo;
        private String _ItemCode;
        private String _ItemName;
        private Double _OrderQty;
        private String _Unit;
        private Decimal _Price;
        private Double _Discount1;
        private Double _Discount2;
        private String _PurchaseOrderStatusCode;
        private String _PurchaseOrderStatus;
        private Decimal _DownPayment;
        private String _VoucherNo;

        [Column(Name = "PurchaseOrderNo", DataType = "String")]
        public String PurchaseOrderNo
        {
            get { return _PurchaseOrderNo; }
            set { _PurchaseOrderNo = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }
        [Column(Name = "PurchaseOrderDate", DataType = "DateTime")]
        public DateTime PurchaseOrderDate
        {
            get { return _PurchaseOrderDate; }
            set { _PurchaseOrderDate = value; }
        }
        [Column(Name = "PurchaseOrderDateText", DataType = "String")]
        public String PurchaseOrderDateText
        {
            get { return _PurchaseOrderDateText; }
            set { _PurchaseOrderDateText = value; }
        }
        [Column(Name = "OrderDeliveryDate", DataType = "DateTime")]
        public DateTime OrderDeliveryDate
        {
            get { return _OrderDeliveryDate; }
            set { _OrderDeliveryDate = value; }
        }
        [Column(Name = "OrderDeliveryDateText", DataType = "String")]
        public String OrderDeliveryDateText
        {
            get { return _OrderDeliveryDateText; }
            set { _OrderDeliveryDateText = value; }
        }
        [Column(Name = "PurchaseRequestNo", DataType = "String")]
        public String PurchaseRequestNo
        {
            get { return _PurchaseRequestNo; }
            set { _PurchaseRequestNo = value; }
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
        [Column(Name = "OrderQty", DataType = "Double")]
        public Double OrderQty
        {
            get { return _OrderQty; }
            set { _OrderQty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Price", DataType = "Decimal")]
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Column(Name = "Discount1", DataType = "Double")]
        public Double Discount1
        {
            get { return _Discount1; }
            set { _Discount1 = value; }
        }
        [Column(Name = "Discount2", DataType = "Double")]
        public Double Discount2
        {
            get { return _Discount2; }
            set { _Discount2 = value; }
        }
        [Column(Name = "PurchaseOrderStatusCode", DataType = "String")]
        public String PurchaseOrderStatusCode
        {
            get { return _PurchaseOrderStatusCode; }
            set { _PurchaseOrderStatusCode = value; }
        }
        [Column(Name = "PurchaseOrderStatus", DataType = "String")]
        public String PurchaseOrderStatus
        {
            get { return _PurchaseOrderStatus; }
            set { _PurchaseOrderStatus = value; }
        }
        [Column(Name = "DownPayment", DataType = "Decimal")]
        public Decimal DownPayment
        {
            get { return _DownPayment; }
            set { _DownPayment = value; }
        }
        [Column(Name = "VoucherNo", DataType = "String")]
        public String VoucherNo
        {
            get { return _VoucherNo; }
            set { _VoucherNo = value; }
        }
    }
    #endregion
    #region vPharmacyPurchaseOrderReceived
    [Serializable]
    [Table(Name = "vPharmacyPurchaseOrderReceived")]
    public class vPharmacyPurchaseOrderReceived
    {
        private String _PurchaseOrderNo;
        private DateTime _PurchaseOrderDate;
        private String _PurchaseOrderDateText;
        private DateTime _PurchaseOrderDeliveryDate;
        private String _PurchaseOrderDeliveryDateText;
        private String _SupplierCode;
        private String _SupplierName;
        private String _ItemCode;
        private String _ItemName;
        private Double _PurchaseOrderQty;
        private String _PurchaseOrderUnit;
        private String _PurchaseReceiveNo;
        private DateTime _PurchaseReceiveDate;
        private String _PurchaseReceiveDateText;
        private Double _PurchaseReceiveQty;
        private String _PurchaseReceiveUnit;
        private Int32 _DurationByOrderDate;
        private Int32 _DurationByDeliveryDate;
        private Boolean _IsOutstanding;

        [Column(Name = "PurchaseOrderNo", DataType = "String")]
        public String PurchaseOrderNo
        {
            get { return _PurchaseOrderNo; }
            set { _PurchaseOrderNo = value; }
        }
        [Column(Name = "PurchaseOrderDate", DataType = "DateTime")]
        public DateTime PurchaseOrderDate
        {
            get { return _PurchaseOrderDate; }
            set { _PurchaseOrderDate = value; }
        }
        [Column(Name = "PurchaseOrderDateText", DataType = "String")]
        public String PurchaseOrderDateText
        {
            get { return _PurchaseOrderDateText; }
            set { _PurchaseOrderDateText = value; }
        }
        [Column(Name = "PurchaseOrderDeliveryDate", DataType = "DateTime")]
        public DateTime PurchaseOrderDeliveryDate
        {
            get { return _PurchaseOrderDeliveryDate; }
            set { _PurchaseOrderDeliveryDate = value; }
        }
        [Column(Name = "PurchaseOrderDeliveryDateText", DataType = "String")]
        public String PurchaseOrderDeliveryDateText
        {
            get { return _PurchaseOrderDeliveryDateText; }
            set { _PurchaseOrderDeliveryDateText = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
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
        [Column(Name = "PurchaseOrderQty", DataType = "Double")]
        public Double PurchaseOrderQty
        {
            get { return _PurchaseOrderQty; }
            set { _PurchaseOrderQty = value; }
        }
        [Column(Name = "PurchaseOrderUnit", DataType = "String")]
        public String PurchaseOrderUnit
        {
            get { return _PurchaseOrderUnit; }
            set { _PurchaseOrderUnit = value; }
        }
        [Column(Name = "PurchaseReceiveNo", DataType = "String")]
        public String PurchaseReceiveNo
        {
            get { return _PurchaseReceiveNo; }
            set { _PurchaseReceiveNo = value; }
        }
        [Column(Name = "PurchaseReceiveDate", DataType = "DateTime")]
        public DateTime PurchaseReceiveDate
        {
            get { return _PurchaseReceiveDate; }
            set { _PurchaseReceiveDate = value; }
        }
        [Column(Name = "PurchaseReceiveDateText", DataType = "String")]
        public String PurchaseReceiveDateText
        {
            get { return _PurchaseReceiveDateText; }
            set { _PurchaseReceiveDateText = value; }
        }
        [Column(Name = "PurchaseReceiveQty", DataType = "Double")]
        public Double PurchaseReceiveQty
        {
            get { return _PurchaseReceiveQty; }
            set { _PurchaseReceiveQty = value; }
        }
        [Column(Name = "PurchaseReceiveUnit", DataType = "String")]
        public String PurchaseReceiveUnit
        {
            get { return _PurchaseReceiveUnit; }
            set { _PurchaseReceiveUnit = value; }
        }
        [Column(Name = "DurationByOrderDate", DataType = "Int32")]
        public Int32 DurationByOrderDate
        {
            get { return _DurationByOrderDate; }
            set { _DurationByOrderDate = value; }
        }
        [Column(Name = "DurationByDeliveryDate", DataType = "Int32")]
        public Int32 DurationByDeliveryDate
        {
            get { return _DurationByDeliveryDate; }
            set { _DurationByDeliveryDate = value; }
        }
        [Column(Name = "IsOutstanding", DataType = "Boolean")]
        public Boolean IsOutstanding
        {
            get { return _IsOutstanding; }
            set { _IsOutstanding = value; }
        }
    }
    #endregion
    #region vPharmacyPurchaseReceive
    [Serializable]
    [Table(Name = "vPharmacyPurchaseReceive")]
    public partial class vPharmacyPurchaseReceive
    {
        private String _PurchaseReceiveNo;
        private String _DeliveryNo;
        private String _SupplierCode;
        private String _SupplierName;
        private DateTime _PurchaseReceiveDate;
        private String _PurchaseReceiveDateText;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private Decimal _HeaderDiscount;
        private Double _HeaderVAT;
        private Decimal _HeaderDeliveryFee;
        private Decimal _HeaderSealFee;
        private String _ItemCode;
        private String _ItemName;
        private String _Unit;
        private Double _ReceiveQty;
        private Decimal _ItemPrice;
        private Decimal _ItemDiscount;
        private Decimal _ItemDiscount2;
        private String _PurchaseOrderNo;
        private Boolean _IsBonus;
        private String _ManufacturerCode;
        private String _ManufacturerName;

        [Column(Name = "PurchaseReceiveNo", DataType = "String")]
        public String PurchaseReceiveNo
        {
            get { return _PurchaseReceiveNo; }
            set { _PurchaseReceiveNo = value; }
        }
        [Column(Name = "DeliveryNo", DataType = "String")]
        public String DeliveryNo
        {
            get { return _DeliveryNo; }
            set { _DeliveryNo = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }
        [Column(Name = "PurchaseReceiveDate", DataType = "DateTime")]
        public DateTime PurchaseReceiveDate
        {
            get { return _PurchaseReceiveDate; }
            set { _PurchaseReceiveDate = value; }
        }
        [Column(Name = "PurchaseReceiveDateText", DataType = "String")]
        public String PurchaseReceiveDateText
        {
            get { return _PurchaseReceiveDateText; }
            set { _PurchaseReceiveDateText = value; }
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
        [Column(Name = "HeaderDiscount", DataType = "Decimal")]
        public Decimal HeaderDiscount
        {
            get { return _HeaderDiscount; }
            set { _HeaderDiscount = value; }
        }
        [Column(Name = "HeaderVAT", DataType = "Double")]
        public Double HeaderVAT
        {
            get { return _HeaderVAT; }
            set { _HeaderVAT = value; }
        }
        [Column(Name = "HeaderDeliveryFee", DataType = "Decimal")]
        public Decimal HeaderDeliveryFee
        {
            get { return _HeaderDeliveryFee; }
            set { _HeaderDeliveryFee = value; }
        }
        [Column(Name = "HeaderSealFee", DataType = "Decimal")]
        public Decimal HeaderSealFee
        {
            get { return _HeaderSealFee; }
            set { _HeaderSealFee = value; }
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
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "ReceiveQty", DataType = "Double")]
        public Double ReceiveQty
        {
            get { return _ReceiveQty; }
            set { _ReceiveQty = value; }
        }
        [Column(Name = "ItemPrice", DataType = "Decimal")]
        public Decimal ItemPrice
        {
            get { return _ItemPrice; }
            set { _ItemPrice = value; }
        }
        [Column(Name = "ItemDiscount", DataType = "Decimal")]
        public Decimal ItemDiscount
        {
            get { return _ItemDiscount; }
            set { _ItemDiscount = value; }
        }
        [Column(Name = "ItemDiscount2", DataType = "Decimal")]
        public Decimal ItemDiscount2
        {
            get { return _ItemDiscount2; }
            set { _ItemDiscount2 = value; }
        }
        [Column(Name = "PurchaseOrderNo", DataType = "String")]
        public String PurchaseOrderNo
        {
            get { return _PurchaseOrderNo; }
            set { _PurchaseOrderNo = value; }
        }
        [Column(Name = "IsBonus", DataType = "Boolean")]
        public Boolean IsBonus
        {
            get { return _IsBonus; }
            set { _IsBonus = value; }
        }
        [Column(Name = "ManufacturerCode", DataType = "String")]
        public String ManufacturerCode
        {
            get { return _ManufacturerCode; }
            set { _ManufacturerCode = value; }
        }
        [Column(Name = "ManufacturerName", DataType = "String")]
        public String ManufacturerName
        {
            get { return _ManufacturerName; }
            set { _ManufacturerName = value; }
        }
    }
    #endregion
    #region vPharmacyPurchaseRequest
    [Serializable]
    [Table(Name = "vPharmacyPurchaseRequest")]
    public partial class vPharmacyPurchaseRequest
    {
        private String _PurchaseRequestNo;
        private DateTime _PurchaseRequestDate;
        private String _PurchaseRequestDateText;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private Boolean _IsHeaderPosting;
        private String _HeaderUpdater;
        private String _SupplierCode;
        private String _SupplierName;
        private String _ItemCode;
        private String _ItemName;
        private String _CatalogNo;
        private String _ProductLineCode;
        private String _ProductLine;
        private String _Unit;
        private Double _UnitFactor;
        private Decimal _Price;
        private Double _RequestQty;
        private Double _ProcessedQty;
        private String _DetailUpdater;
        private DateTime _ApprovalDate;
        private String _ApprovalDateText;
        private Boolean _IsProcessed;
        private Boolean _IsApproved;
        private Double _Discount;

        [Column(Name = "PurchaseRequestNo", DataType = "String")]
        public String PurchaseRequestNo
        {
            get { return _PurchaseRequestNo; }
            set { _PurchaseRequestNo = value; }
        }
        [Column(Name = "PurchaseRequestDate", DataType = "DateTime")]
        public DateTime PurchaseRequestDate
        {
            get { return _PurchaseRequestDate; }
            set { _PurchaseRequestDate = value; }
        }
        [Column(Name = "PurchaseRequestDateText", DataType = "String")]
        public String PurchaseRequestDateText
        {
            get { return _PurchaseRequestDateText; }
            set { _PurchaseRequestDateText = value; }
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
        [Column(Name = "IsHeaderPosting", DataType = "Boolean")]
        public Boolean IsHeaderPosting
        {
            get { return _IsHeaderPosting; }
            set { _IsHeaderPosting = value; }
        }
        [Column(Name = "HeaderUpdater", DataType = "String")]
        public String HeaderUpdater
        {
            get { return _HeaderUpdater; }
            set { _HeaderUpdater = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
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
        [Column(Name = "CatalogNo", DataType = "String")]
        public String CatalogNo
        {
            get { return _CatalogNo; }
            set { _CatalogNo = value; }
        }
        [Column(Name = "ProductLineCode", DataType = "String")]
        public String ProductLineCode
        {
            get { return _ProductLineCode; }
            set { _ProductLineCode = value; }
        }
        [Column(Name = "ProductLine", DataType = "String")]
        public String ProductLine
        {
            get { return _ProductLine; }
            set { _ProductLine = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "UnitFactor", DataType = "Double")]
        public Double UnitFactor
        {
            get { return _UnitFactor; }
            set { _UnitFactor = value; }
        }
        [Column(Name = "Price", DataType = "Decimal")]
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Column(Name = "RequestQty", DataType = "Double")]
        public Double RequestQty
        {
            get { return _RequestQty; }
            set { _RequestQty = value; }
        }
        [Column(Name = "ProcessedQty", DataType = "Double")]
        public Double ProcessedQty
        {
            get { return _ProcessedQty; }
            set { _ProcessedQty = value; }
        }
        [Column(Name = "DetailUpdater", DataType = "String")]
        public String DetailUpdater
        {
            get { return _DetailUpdater; }
            set { _DetailUpdater = value; }
        }
        [Column(Name = "ApprovalDate", DataType = "DateTime")]
        public DateTime ApprovalDate
        {
            get { return _ApprovalDate; }
            set { _ApprovalDate = value; }
        }
        [Column(Name = "ApprovalDateText", DataType = "String")]
        public String ApprovalDateText
        {
            get { return _ApprovalDateText; }
            set { _ApprovalDateText = value; }
        }
        [Column(Name = "IsProcessed", DataType = "Boolean")]
        public Boolean IsProcessed
        {
            get { return _IsProcessed; }
            set { _IsProcessed = value; }
        }
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
        [Column(Name = "Discount", DataType = "Double")]
        public Double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
    }
    #endregion
    #region vPharmacyPurchaseReturn
    [Serializable]
    [Table(Name = "vPharmacyPurchaseReturn")]
    public class vPharmacyPurchaseReturn
    {
        private String _PurchaseReturnNo;
        private DateTime _PurchaseReturnDate;
        private String _PurchaseReturnDateText;
        private String _SupplierCode;
        private String _SupplierName;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private String _ItemCode;
        private String _ItemName;
        private Double _ReturnQty;
        private String _Unit;
        private Decimal _Price;
        private Decimal _Discount;
        private Boolean _IsApproved;

        [Column(Name = "PurchaseReturnNo", DataType = "String")]
        public String PurchaseReturnNo
        {
            get { return _PurchaseReturnNo; }
            set { _PurchaseReturnNo = value; }
        }
        [Column(Name = "PurchaseReturnDate", DataType = "DateTime")]
        public DateTime PurchaseReturnDate
        {
            get { return _PurchaseReturnDate; }
            set { _PurchaseReturnDate = value; }
        }
        [Column(Name = "PurchaseReturnDateText", DataType = "String")]
        public String PurchaseReturnDateText
        {
            get { return _PurchaseReturnDateText; }
            set { _PurchaseReturnDateText = value; }
        }
        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
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
        [Column(Name = "ReturnQty", DataType = "Double")]
        public Double ReturnQty
        {
            get { return _ReturnQty; }
            set { _ReturnQty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "Price", DataType = "Decimal")]
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Column(Name = "Discount", DataType = "Decimal")]
        public Decimal Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
    }
    #endregion
    #region vPharmacyRevenue
    [Serializable]
    [Table(Name = "vPharmacyRevenue")]
    public class vPharmacyRevenue
    {
        private String _PaymentNo;
        private String _PresciptionNo;
        private DateTime _PaymentDate;
        private String _PaymentDateText;
        private Decimal _PaymentAmount1;
        private Decimal _PaymentAmount2;
        private Decimal _PaymentAmount3;
        private Decimal _PaymentAmount4;
        private Decimal _PaymentAmount5;
        private Decimal _Discount;
        private DateTime _UpdatedDate;
        private String _UpdatedBy;
        private Boolean _IsVoid;
        private String _RegistrationNo;
        private String _MedicalNo;
        private String _FirstName;
        private String _LastName;

        [Column(Name = "PaymentNo", DataType = "String")]
        public String PaymentNo
        {
            get { return _PaymentNo; }
            set { _PaymentNo = value; }
        }
        [Column(Name = "PresciptionNo", DataType = "String")]
        public String PresciptionNo
        {
            get { return _PresciptionNo; }
            set { _PresciptionNo = value; }
        }
        [Column(Name = "PaymentDate", DataType = "DateTime")]
        public DateTime PaymentDate
        {
            get { return _PaymentDate; }
            set { _PaymentDate = value; }
        }
        [Column(Name = "PaymentDateText", DataType = "String")]
        public String PaymentDateText
        {
            get { return _PaymentDateText; }
            set { _PaymentDateText = value; }
        }
        [Column(Name = "PaymentAmount1", DataType = "Decimal")]
        public Decimal PaymentAmount1
        {
            get { return _PaymentAmount1; }
            set { _PaymentAmount1 = value; }
        }
        [Column(Name = "PaymentAmount2", DataType = "Decimal")]
        public Decimal PaymentAmount2
        {
            get { return _PaymentAmount2; }
            set { _PaymentAmount2 = value; }
        }
        [Column(Name = "PaymentAmount3", DataType = "Decimal")]
        public Decimal PaymentAmount3
        {
            get { return _PaymentAmount3; }
            set { _PaymentAmount3 = value; }
        }
        [Column(Name = "PaymentAmount4", DataType = "Decimal")]
        public Decimal PaymentAmount4
        {
            get { return _PaymentAmount4; }
            set { _PaymentAmount4 = value; }
        }
        [Column(Name = "PaymentAmount5", DataType = "Decimal")]
        public Decimal PaymentAmount5
        {
            get { return _PaymentAmount5; }
            set { _PaymentAmount5 = value; }
        }
        [Column(Name = "Discount", DataType = "Decimal")]
        public Decimal Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        [Column(Name = "UpdatedDate", DataType = "DateTime")]
        public DateTime UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }
        [Column(Name = "UpdatedBy", DataType = "String")]
        public String UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
        [Column(Name = "IsVoid", DataType = "Boolean")]
        public Boolean IsVoid
        {
            get { return _IsVoid; }
            set { _IsVoid = value; }
        }
        [Column(Name = "RegistrationNo", DataType = "String")]
        public String RegistrationNo
        {
            get { return _RegistrationNo; }
            set { _RegistrationNo = value; }
        }
        [Column(Name = "MedicalNo", DataType = "String")]
        public String MedicalNo
        {
            get { return _MedicalNo; }
            set { _MedicalNo = value; }
        }
        [Column(Name = "FirstName", DataType = "String")]
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        [Column(Name = "LastName", DataType = "String")]
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
    }
    #endregion
    #region vPharmacyStockInitialization
    [Serializable]
    [Table(Name = "vPharmacyStockInitialization")]
    public class vPharmacyStockInitialization
    {
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private String _ItemCode;
        private String _ItemName;
        private Decimal _Price;
        private Double _Qty;
        private String _Unit;
        private Boolean _IsApproved;
        private DateTime _InitializationDate;
        private String _InitializationDateText;
        private String _Updater;

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
        [Column(Name = "Price", DataType = "Decimal")]
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Column(Name = "Qty", DataType = "Double")]
        public Double Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "IsApproved", DataType = "Boolean")]
        public Boolean IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
        [Column(Name = "InitializationDate", DataType = "DateTime")]
        public DateTime InitializationDate
        {
            get { return _InitializationDate; }
            set { _InitializationDate = value; }
        }
        [Column(Name = "InitializationDateText", DataType = "String")]
        public String InitializationDateText
        {
            get { return _InitializationDateText; }
            set { _InitializationDateText = value; }
        }
        [Column(Name = "Updater", DataType = "String")]
        public String Updater
        {
            get { return _Updater; }
            set { _Updater = value; }
        }
    }
    #endregion
    #region vPharmacyStockOpnameResult
    [Serializable]
    [Table(Name = "vPharmacyStockOpnameResult")]
    public partial class vPharmacyStockOpnameResult
    {
        private String _StockOpnameNo;
        private DateTime _StockOpnameDate;
        private String _StockOpnameDateText;
        private String _WarehouseCode;
        private String _WarehouseName;
        private String _LocationCode;
        private String _LocationName;
        private String _ItemCode;
        private String _ItemName;
        private String _ProductLine;
        private Double _Qty;
        private String _Unit;
        private Double _ResultQty;
        private Boolean _IsDifference;
        private Double _StockPrice;

        [Column(Name = "StockOpnameNo", DataType = "String")]
        public String StockOpnameNo
        {
            get { return _StockOpnameNo; }
            set { _StockOpnameNo = value; }
        }
        [Column(Name = "StockOpnameDate", DataType = "DateTime")]
        public DateTime StockOpnameDate
        {
            get { return _StockOpnameDate; }
            set { _StockOpnameDate = value; }
        }
        [Column(Name = "StockOpnameDateText", DataType = "String")]
        public String StockOpnameDateText
        {
            get { return _StockOpnameDateText; }
            set { _StockOpnameDateText = value; }
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
        [Column(Name = "ProductLine", DataType = "String")]
        public String ProductLine
        {
            get { return _ProductLine; }
            set { _ProductLine = value; }
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
        [Column(Name = "Qty", DataType = "Double")]
        public Double Qty
        {
            get { return _Qty; }
            set { _Qty = value; }
        }
        [Column(Name = "Unit", DataType = "String")]
        public String Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        [Column(Name = "ResultQty", DataType = "Double")]
        public Double ResultQty
        {
            get { return _ResultQty; }
            set { _ResultQty = value; }
        }
        [Column(Name = "IsDifference", DataType = "Boolean")]
        public Boolean IsDifference
        {
            get { return _IsDifference; }
            set { _IsDifference = value; }
        }
        [Column(Name = "StockPrice", DataType = "Double")]
        public Double StockPrice
        {
            get { return _StockPrice; }
            set { _StockPrice = value; }
        }
    }
    #endregion
    #region vPhysicianSchedule
    [Serializable]
    [Table(Name = "vPhysicianSchedule")]
    public class vPhysicianSchedule
    {
        private String _physicianID;
        private String _nama;
        private String _clinicID;
        private String _nmpoli;
        private String _sMon;
        private String _eMon;
        private String _sTue;
        private String _eTue;
        private String _sWed;
        private String _eWed;
        private String _sThu;
        private String _eThu;
        private String _sFri;
        private String _eFri;
        private String _sSat;
        private String _eSat;
        private String _sSun;
        private String _eSun;

        [Column(Name = "physicianID", DataType = "String")]
        public String physicianID
        {
            get { return _physicianID; }
            set { _physicianID = value; }
        }
        [Column(Name = "nama", DataType = "String")]
        public String nama
        {
            get { return _nama; }
            set { _nama = value; }
        }
        [Column(Name = "clinicID", DataType = "String")]
        public String clinicID
        {
            get { return _clinicID; }
            set { _clinicID = value; }
        }
        [Column(Name = "nmpoli", DataType = "String")]
        public String nmpoli
        {
            get { return _nmpoli; }
            set { _nmpoli = value; }
        }
        [Column(Name = "sMon", DataType = "String")]
        public String sMon
        {
            get { return _sMon; }
            set { _sMon = value; }
        }
        [Column(Name = "eMon", DataType = "String")]
        public String eMon
        {
            get { return _eMon; }
            set { _eMon = value; }
        }
        [Column(Name = "sTue", DataType = "String")]
        public String sTue
        {
            get { return _sTue; }
            set { _sTue = value; }
        }
        [Column(Name = "eTue", DataType = "String")]
        public String eTue
        {
            get { return _eTue; }
            set { _eTue = value; }
        }
        [Column(Name = "sWed", DataType = "String")]
        public String sWed
        {
            get { return _sWed; }
            set { _sWed = value; }
        }
        [Column(Name = "eWed", DataType = "String")]
        public String eWed
        {
            get { return _eWed; }
            set { _eWed = value; }
        }
        [Column(Name = "sThu", DataType = "String")]
        public String sThu
        {
            get { return _sThu; }
            set { _sThu = value; }
        }
        [Column(Name = "eThu", DataType = "String")]
        public String eThu
        {
            get { return _eThu; }
            set { _eThu = value; }
        }
        [Column(Name = "sFri", DataType = "String")]
        public String sFri
        {
            get { return _sFri; }
            set { _sFri = value; }
        }
        [Column(Name = "eFri", DataType = "String")]
        public String eFri
        {
            get { return _eFri; }
            set { _eFri = value; }
        }
        [Column(Name = "sSat", DataType = "String")]
        public String sSat
        {
            get { return _sSat; }
            set { _sSat = value; }
        }
        [Column(Name = "eSat", DataType = "String")]
        public String eSat
        {
            get { return _eSat; }
            set { _eSat = value; }
        }
        [Column(Name = "sSun", DataType = "String")]
        public String sSun
        {
            get { return _sSun; }
            set { _sSun = value; }
        }
        [Column(Name = "eSun", DataType = "String")]
        public String eSun
        {
            get { return _eSun; }
            set { _eSun = value; }
        }
    }
    #endregion
    #region vReferral
    [Serializable]
    [Table(Name = "vReferral")]
    public class vReferral
    {
        private String _ReferralTypeCode;
        private String _ReferralTypeName;
        private String _ReferralNo;
        private String _ReferralName;
        private String _ReferralAddress;
        private Boolean _IsActive;

        [Column(Name = "ReferralTypeCode", DataType = "String")]
        public String ReferralTypeCode
        {
            get { return _ReferralTypeCode; }
            set { _ReferralTypeCode = value; }
        }
        [Column(Name = "ReferralTypeName", DataType = "String")]
        public String ReferralTypeName
        {
            get { return _ReferralTypeName; }
            set { _ReferralTypeName = value; }
        }
        [Column(Name = "ReferralNo", DataType = "String")]
        public String ReferralNo
        {
            get { return _ReferralNo; }
            set { _ReferralNo = value; }
        }
        [Column(Name = "ReferralName", DataType = "String")]
        public String ReferralName
        {
            get { return _ReferralName; }
            set { _ReferralName = value; }
        }
        [Column(Name = "ReferralAddress", DataType = "String")]
        public String ReferralAddress
        {
            get { return _ReferralAddress; }
            set { _ReferralAddress = value; }
        }
        [Column(Name = "IsActive", DataType = "Boolean")]
        public Boolean IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
    }
    #endregion
    #region vRegistrationIGD
    [Serializable]
    [Table(Name = "vRegistrationIGD")]
    public partial class vRegistrationIGD : vPatientBase
    {
        private DateTime _RegistrationDate;
        private String _RegistrationDateText;
        private String _RegistrationTime;
        private String _RegistrationNo;
        private String _MedincationTime;
        private String _DOctor;
        private String _RefferalCode;
        private String _RefferalNo;
        private String _RefferalName;
        private String _Payer;
        private String _CreatedBy;
        private Boolean _IsNewVisit;
        private String _PatientTypeCode;
        private String _PatientType;
        private String _Triage;
        private String _ProgressNotes;
        private String _ArrivalConditionCode;
        private String _ArrivalCondition;
        private String _DischargeMethodCode;
        private String _DischargeMethod;
        private String _DischargeConditionCode;
        private String _DischargeCondition;
        private String _ReasonCode;
        private String _Reason;
        private String _DetailReason;
        private String _FollowUp;
        private String _Diagnosis;
        private String _InpatientRegistrationNo;
        private Boolean _IsVoid;

        [Column(Name = "RegistrationDate", DataType = "DateTime")]
        public DateTime RegistrationDate
        {
            get { return _RegistrationDate; }
            set { _RegistrationDate = value; }
        }
        [Column(Name = "RegistrationDateText", DataType = "String")]
        public String RegistrationDateText
        {
            get { return _RegistrationDateText; }
            set { _RegistrationDateText = value; }
        }
        [Column(Name = "RegistrationTime", DataType = "String")]
        public String RegistrationTime
        {
            get { return _RegistrationTime; }
            set { _RegistrationTime = value; }
        }
        [Column(Name = "RegistrationNo", DataType = "String")]
        public String RegistrationNo
        {
            get { return _RegistrationNo; }
            set { _RegistrationNo = value; }
        }
        [Column(Name = "MedincationTime", DataType = "String")]
        public String MedincationTime
        {
            get { return _MedincationTime; }
            set { _MedincationTime = value; }
        }
        [Column(Name = "DOctor", DataType = "String")]
        public String DOctor
        {
            get { return _DOctor; }
            set { _DOctor = value; }
        }
        [Column(Name = "RefferalCode", DataType = "String")]
        public String RefferalCode
        {
            get { return _RefferalCode; }
            set { _RefferalCode = value; }
        }
        [Column(Name = "RefferalNo", DataType = "String")]
        public String RefferalNo
        {
            get { return _RefferalNo; }
            set { _RefferalNo = value; }
        }
        [Column(Name = "RefferalName", DataType = "String")]
        public String RefferalName
        {
            get { return _RefferalName; }
            set { _RefferalName = value; }
        }
        [Column(Name = "Payer", DataType = "String")]
        public String Payer
        {
            get { return _Payer; }
            set { _Payer = value; }
        }
        [Column(Name = "CreatedBy", DataType = "String")]
        public String CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        [Column(Name = "IsNewVisit", DataType = "Boolean")]
        public Boolean IsNewVisit
        {
            get { return _IsNewVisit; }
            set { _IsNewVisit = value; }
        }
        [Column(Name = "PatientTypeCode", DataType = "String")]
        public String PatientTypeCode
        {
            get { return _PatientTypeCode; }
            set { _PatientTypeCode = value; }
        }
        [Column(Name = "PatientType", DataType = "String")]
        public String PatientType
        {
            get { return _PatientType; }
            set { _PatientType = value; }
        }
        [Column(Name = "Triage", DataType = "String")]
        public String Triage
        {
            get { return _Triage; }
            set { _Triage = value; }
        }
        [Column(Name = "ProgressNotes", DataType = "String")]
        public String ProgressNotes
        {
            get { return _ProgressNotes; }
            set { _ProgressNotes = value; }
        }
        [Column(Name = "ArrivalConditionCode", DataType = "String")]
        public String ArrivalConditionCode
        {
            get { return _ArrivalConditionCode; }
            set { _ArrivalConditionCode = value; }
        }
        [Column(Name = "ArrivalCondition", DataType = "String")]
        public String ArrivalCondition
        {
            get { return _ArrivalCondition; }
            set { _ArrivalCondition = value; }
        }
        [Column(Name = "DischargeMethodCode", DataType = "String")]
        public String DischargeMethodCode
        {
            get { return _DischargeMethodCode; }
            set { _DischargeMethodCode = value; }
        }
        [Column(Name = "DischargeMethod", DataType = "String")]
        public String DischargeMethod
        {
            get { return _DischargeMethod; }
            set { _DischargeMethod = value; }
        }
        [Column(Name = "DischargeConditionCode", DataType = "String")]
        public String DischargeConditionCode
        {
            get { return _DischargeConditionCode; }
            set { _DischargeConditionCode = value; }
        }
        [Column(Name = "DischargeCondition", DataType = "String")]
        public String DischargeCondition
        {
            get { return _DischargeCondition; }
            set { _DischargeCondition = value; }
        }
        [Column(Name = "ReasonCode", DataType = "String")]
        public String ReasonCode
        {
            get { return _ReasonCode; }
            set { _ReasonCode = value; }
        }
        [Column(Name = "Reason", DataType = "String")]
        public String Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }
        [Column(Name = "DetailReason", DataType = "String")]
        public String DetailReason
        {
            get { return _DetailReason; }
            set { _DetailReason = value; }
        }
        [Column(Name = "FollowUp", DataType = "String")]
        public String FollowUp
        {
            get { return _FollowUp; }
            set { _FollowUp = value; }
        }
        [Column(Name = "Diagnosis", DataType = "String")]
        public String Diagnosis
        {
            get { return _Diagnosis; }
            set { _Diagnosis = value; }
        }
        [Column(Name = "InpatientRegistrationNo", DataType = "String")]
        public String InpatientRegistrationNo
        {
            get { return _InpatientRegistrationNo; }
            set { _InpatientRegistrationNo = value; }
        }
        [Column(Name = "IsVoid", DataType = "Boolean")]
        public Boolean IsVoid
        {
            get { return _IsVoid; }
            set { _IsVoid = value; }
        }
    }
    #endregion
    #region vRegistrationMCU
    [Serializable]
    [Table(Name = "vRegistrationMCU")]
    public class vRegistrationMCU : vPatientBase
    {
        private DateTime _RegistrationDate;
        private String _RegistrationDateText;
        private String _RegistrationNo;
        private String _RegistrationTime;
        private String _RefferalCode;
        private String _RefferalNo;
        private String _RefferalName;
        private String _Payer;
        private String _Doctor;
        private String _CreatedBy;
        private DateTime _DischargeDate;
        private String _DischargeDateText;
        private Boolean _IsVoid;

        [Column(Name = "RegistrationDate", DataType = "DateTime")]
        public DateTime RegistrationDate
        {
            get { return _RegistrationDate; }
            set { _RegistrationDate = value; }
        }
        [Column(Name = "RegistrationDateText", DataType = "String")]
        public String RegistrationDateText
        {
            get { return _RegistrationDateText; }
            set { _RegistrationDateText = value; }
        }
        [Column(Name = "RegistrationNo", DataType = "String")]
        public String RegistrationNo
        {
            get { return _RegistrationNo; }
            set { _RegistrationNo = value; }
        }
        [Column(Name = "RegistrationTime", DataType = "String")]
        public String RegistrationTime
        {
            get { return _RegistrationTime; }
            set { _RegistrationTime = value; }
        }
        [Column(Name = "RefferalCode", DataType = "String")]
        public String RefferalCode
        {
            get { return _RefferalCode; }
            set { _RefferalCode = value; }
        }
        [Column(Name = "RefferalNo", DataType = "String")]
        public String RefferalNo
        {
            get { return _RefferalNo; }
            set { _RefferalNo = value; }
        }
        [Column(Name = "RefferalName", DataType = "String")]
        public String RefferalName
        {
            get { return _RefferalName; }
            set { _RefferalName = value; }
        }
        [Column(Name = "Payer", DataType = "String")]
        public String Payer
        {
            get { return _Payer; }
            set { _Payer = value; }
        }
        [Column(Name = "Doctor", DataType = "String")]
        public String Doctor
        {
            get { return _Doctor; }
            set { _Doctor = value; }
        }
        [Column(Name = "CreatedBy", DataType = "String")]
        public String CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        [Column(Name = "DischargeDate", DataType = "DateTime")]
        public DateTime DischargeDate
        {
            get { return _DischargeDate; }
            set { _DischargeDate = value; }
        }
        [Column(Name = "DischargeDateText", DataType = "String")]
        public String DischargeDateText
        {
            get { return _DischargeDateText; }
            set { _DischargeDateText = value; }
        }
        [Column(Name = "IsVoid", DataType = "Boolean")]
        public Boolean IsVoid
        {
            get { return _IsVoid; }
            set { _IsVoid = value; }
        }
    }
    #endregion
    #region vRegistrationMD
    [Serializable]
    [Table(Name = "vRegistrationMD")]
    public class vRegistrationMD : vPatientBase
    {
        private DateTime _RegistrationDate;
        private String _RegistrationDateText;
        private String _RegistrationNo;
        private String _RegistrationTime;
        private String _RefferalCode;
        private String _RefferalNo;
        private String _RefferalName;
        private String _Payer;
        private String _MedicalDiagnosticCode;
        private String _MedicalDiagnosticUnit;
        private String _CreatedBy;
        private DateTime _DischargeDate;
        private String _DischargeDateText;
        private Boolean _IsVoid;

        [Column(Name = "RegistrationDate", DataType = "DateTime")]
        public DateTime RegistrationDate
        {
            get { return _RegistrationDate; }
            set { _RegistrationDate = value; }
        }
        [Column(Name = "RegistrationDateText", DataType = "String")]
        public String RegistrationDateText
        {
            get { return _RegistrationDateText; }
            set { _RegistrationDateText = value; }
        }
        [Column(Name = "RegistrationNo", DataType = "String")]
        public String RegistrationNo
        {
            get { return _RegistrationNo; }
            set { _RegistrationNo = value; }
        }
        [Column(Name = "RegistrationTime", DataType = "String")]
        public String RegistrationTime
        {
            get { return _RegistrationTime; }
            set { _RegistrationTime = value; }
        }
        [Column(Name = "RefferalCode", DataType = "String")]
        public String RefferalCode
        {
            get { return _RefferalCode; }
            set { _RefferalCode = value; }
        }
        [Column(Name = "RefferalNo", DataType = "String")]
        public String RefferalNo
        {
            get { return _RefferalNo; }
            set { _RefferalNo = value; }
        }
        [Column(Name = "RefferalName", DataType = "String")]
        public String RefferalName
        {
            get { return _RefferalName; }
            set { _RefferalName = value; }
        }
        [Column(Name = "Payer", DataType = "String")]
        public String Payer
        {
            get { return _Payer; }
            set { _Payer = value; }
        }
        [Column(Name = "MedicalDiagnosticCode", DataType = "String")]
        public String MedicalDiagnosticCode
        {
            get { return _MedicalDiagnosticCode; }
            set { _MedicalDiagnosticCode = value; }
        }
        [Column(Name = "MedicalDiagnosticUnit", DataType = "String")]
        public String MedicalDiagnosticUnit
        {
            get { return _MedicalDiagnosticUnit; }
            set { _MedicalDiagnosticUnit = value; }
        }
        [Column(Name = "CreatedBy", DataType = "String")]
        public String CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        [Column(Name = "DischargeDate", DataType = "DateTime")]
        public DateTime DischargeDate
        {
            get { return _DischargeDate; }
            set { _DischargeDate = value; }
        }
        [Column(Name = "DischargeDateText", DataType = "String")]
        public String DischargeDateText
        {
            get { return _DischargeDateText; }
            set { _DischargeDateText = value; }
        }
        [Column(Name = "IsVoid", DataType = "Boolean")]
        public Boolean IsVoid
        {
            get { return _IsVoid; }
            set { _IsVoid = value; }
        }
    }
    #endregion
    #region vRegistrationPatientAll
    [Serializable]
    [Table(Name = "vRegistrationPatientAll")]
    public class vRegistrationPatientAll : vPatientBase
    {
        private String _UnitType;
        private DateTime _RegistrationDate;
        private String _RegistrationDateText;
        private String _RegistrationNo;
        private String _Doctor;
        private String _Payer;
        private String _ServiceUnit;
        private String _RefferalCode;
        private String _RefferalNo;
        private String _RefferalName;
        private String _CreatedBy;
        private DateTime _DischargeDate;
        private String _DischargeDateText;
        private String _DischargeMethod;
        private String _DischargeCondition;
        private String _FollowUp;
        private Boolean _IsVoid;

        [Column(Name = "UnitType", DataType = "String")]
        public String UnitType
        {
            get { return _UnitType; }
            set { _UnitType = value; }
        }
        [Column(Name = "RegistrationDate", DataType = "DateTime")]
        public DateTime RegistrationDate
        {
            get { return _RegistrationDate; }
            set { _RegistrationDate = value; }
        }
        [Column(Name = "RegistrationDateText", DataType = "String")]
        public String RegistrationDateText
        {
            get { return _RegistrationDateText; }
            set { _RegistrationDateText = value; }
        }
        [Column(Name = "RegistrationNo", DataType = "String")]
        public String RegistrationNo
        {
            get { return _RegistrationNo; }
            set { _RegistrationNo = value; }
        }
        [Column(Name = "Doctor", DataType = "String")]
        public String Doctor
        {
            get { return _Doctor; }
            set { _Doctor = value; }
        }
        [Column(Name = "Payer", DataType = "String")]
        public String Payer
        {
            get { return _Payer; }
            set { _Payer = value; }
        }
        [Column(Name = "ServiceUnit", DataType = "String")]
        public String ServiceUnit
        {
            get { return _ServiceUnit; }
            set { _ServiceUnit = value; }
        }
        [Column(Name = "RefferalCode", DataType = "String")]
        public String RefferalCode
        {
            get { return _RefferalCode; }
            set { _RefferalCode = value; }
        }
        [Column(Name = "RefferalNo", DataType = "String")]
        public String RefferalNo
        {
            get { return _RefferalNo; }
            set { _RefferalNo = value; }
        }
        [Column(Name = "RefferalName", DataType = "String")]
        public String RefferalName
        {
            get { return _RefferalName; }
            set { _RefferalName = value; }
        }
        [Column(Name = "CreatedBy", DataType = "String")]
        public String CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        [Column(Name = "DischargeDate", DataType = "DateTime")]
        public DateTime DischargeDate
        {
            get { return _DischargeDate; }
            set { _DischargeDate = value; }
        }
        [Column(Name = "DischargeDateText", DataType = "String")]
        public String DischargeDateText
        {
            get { return _DischargeDateText; }
            set { _DischargeDateText = value; }
        }
        [Column(Name = "DischargeMethod", DataType = "String")]
        public String DischargeMethod
        {
            get { return _DischargeMethod; }
            set { _DischargeMethod = value; }
        }
        [Column(Name = "DischargeCondition", DataType = "String")]
        public String DischargeCondition
        {
            get { return _DischargeCondition; }
            set { _DischargeCondition = value; }
        }
        [Column(Name = "FollowUp", DataType = "String")]
        public String FollowUp
        {
            get { return _FollowUp; }
            set { _FollowUp = value; }
        }
        [Column(Name = "IsVoid", DataType = "Boolean")]
        public Boolean IsVoid
        {
            get { return _IsVoid; }
            set { _IsVoid = value; }
        }
    }
    #endregion
    #region vRegistrationRI
    [Serializable]
    [Table(Name = "vRegistrationRI")]
    public partial class vRegistrationRI : vPatientBase
    {
        private DateTime _RegistrationDate;
        private String _RegistrationDateText;
        private String _RegistrationTime;
        private String _RegistrationNo;
        private String _Doctor;
        private String _RefferalCode;
        private String _RefferalNo;
        private String _RefferalName;
        private String _Payer;
        private String _WardName;
        private String _BedNumber;
        private String _Class;
        private String _ChargeClass;
        private String _CreatedBy;
        private Decimal _HospitalizedCount;
        private Boolean _IsNewPatient;
        private DateTime _DischargeDate;
        private String _DischargeDateText;
        private String _DischargeTime;
        private String _DischargeMethod;
        private String _DischargeCondition;
        private String _FollowUp;
        private Boolean _IsVoid;

        [Column(Name = "RegistrationDate", DataType = "DateTime")]
        public DateTime RegistrationDate
        {
            get { return _RegistrationDate; }
            set { _RegistrationDate = value; }
        }
        [Column(Name = "RegistrationDateText", DataType = "String")]
        public String RegistrationDateText
        {
            get { return _RegistrationDateText; }
            set { _RegistrationDateText = value; }
        }
        [Column(Name = "RegistrationTime", DataType = "String")]
        public String RegistrationTime
        {
            get { return _RegistrationTime; }
            set { _RegistrationTime = value; }
        }
        [Column(Name = "RegistrationNo", DataType = "String")]
        public String RegistrationNo
        {
            get { return _RegistrationNo; }
            set { _RegistrationNo = value; }
        }
        [Column(Name = "Doctor", DataType = "String")]
        public String Doctor
        {
            get { return _Doctor; }
            set { _Doctor = value; }
        }
        [Column(Name = "RefferalCode", DataType = "String")]
        public String RefferalCode
        {
            get { return _RefferalCode; }
            set { _RefferalCode = value; }
        }
        [Column(Name = "RefferalNo", DataType = "String")]
        public String RefferalNo
        {
            get { return _RefferalNo; }
            set { _RefferalNo = value; }
        }
        [Column(Name = "RefferalName", DataType = "String")]
        public String RefferalName
        {
            get { return _RefferalName; }
            set { _RefferalName = value; }
        }
        [Column(Name = "Payer", DataType = "String")]
        public String Payer
        {
            get { return _Payer; }
            set { _Payer = value; }
        }
        [Column(Name = "WardName", DataType = "String")]
        public String WardName
        {
            get { return _WardName; }
            set { _WardName = value; }
        }
        [Column(Name = "BedNumber", DataType = "String")]
        public String BedNumber
        {
            get { return _BedNumber; }
            set { _BedNumber = value; }
        }
        [Column(Name = "Class", DataType = "String")]
        public String Class
        {
            get { return _Class; }
            set { _Class = value; }
        }
        [Column(Name = "ChargeClass", DataType = "String")]
        public String ChargeClass
        {
            get { return _ChargeClass; }
            set { _ChargeClass = value; }
        }
        [Column(Name = "CreatedBy", DataType = "String")]
        public String CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        [Column(Name = "HospitalizedCount", DataType = "Decimal")]
        public Decimal HospitalizedCount
        {
            get { return _HospitalizedCount; }
            set { _HospitalizedCount = value; }
        }
        [Column(Name = "IsNewPatient", DataType = "Boolean")]
        public Boolean IsNewPatient
        {
            get { return _IsNewPatient; }
            set { _IsNewPatient = value; }
        }
        [Column(Name = "DischargeDate", DataType = "DateTime")]
        public DateTime DischargeDate
        {
            get { return _DischargeDate; }
            set { _DischargeDate = value; }
        }
        [Column(Name = "DischargeDateText", DataType = "String")]
        public String DischargeDateText
        {
            get { return _DischargeDateText; }
            set { _DischargeDateText = value; }
        }
        [Column(Name = "DischargeTime", DataType = "String")]
        public String DischargeTime
        {
            get { return _DischargeTime; }
            set { _DischargeTime = value; }
        }
        [Column(Name = "DischargeMethod", DataType = "String")]
        public String DischargeMethod
        {
            get { return _DischargeMethod; }
            set { _DischargeMethod = value; }
        }
        [Column(Name = "DischargeCondition", DataType = "String")]
        public String DischargeCondition
        {
            get { return _DischargeCondition; }
            set { _DischargeCondition = value; }
        }
        [Column(Name = "FollowUp", DataType = "String")]
        public String FollowUp
        {
            get { return _FollowUp; }
            set { _FollowUp = value; }
        }
        [Column(Name = "IsVoid", DataType = "Boolean")]
        public Boolean IsVoid
        {
            get { return _IsVoid; }
            set { _IsVoid = value; }
        }
    }
    #endregion
    #region vRegistrationRJ
    [Serializable]
    [Table(Name = "vRegistrationRJ")]
    public partial class vRegistrationRJ : vPatientBase
    {
        private DateTime _RegistrationDate;
        private String _RegistrationDateText;
        private String _RegistrationTime;
        private String _RegistrationNo;
        private String _Religion;
        private String _VisitNo;
        private String _ServiceUnitCode;
        private String _ServiceUnitName;
        private String _Doctor;
        private String _RefferalCode;
        private String _RefferalNo;
        private String _RefferalName;
        private String _Payer;
        private String _CreatedBy;
        private Boolean _IsNewPatient;
        private Int32 _VisitCount;
        private String _DischargeMethod;
        private String _DischargeCondition;
        private String _FollowUp;
        private String _Diagnosis;
        private String _Treatment;
        private Boolean _IsSurgery;
        private String _InpatientRegistrationNo;
        private Boolean _IsVoid;
        private String _Registrar;

        [Column(Name = "RegistrationDate", DataType = "DateTime")]
        public DateTime RegistrationDate
        {
            get { return _RegistrationDate; }
            set { _RegistrationDate = value; }
        }

        public String RegistrationDateInString
        {
            get { return _RegistrationDate.ToString("dd-MMM-yyyy"); }
        }

        [Column(Name = "RegistrationDateText", DataType = "String")]
        public String RegistrationDateText
        {
            get { return _RegistrationDateText; }
            set { _RegistrationDateText = value; }
        }

        [Column(Name = "RegistrationTime", DataType = "String")]
        public String RegistrationTime
        {
            get { return _RegistrationTime; }
            set { _RegistrationTime = value; }
        }

        [Column(Name = "RegistrationNo", DataType = "String")]
        public String RegistrationNo
        {
            get { return _RegistrationNo; }
            set { _RegistrationNo = value; }
        }

        [Column(Name = "Religion", DataType = "String")]
        public String Religion
        {
            get { return _Religion; }
            set { _Religion = value; }
        }

        [Column(Name = "VisitNo", DataType = "String")]
        public String VisitNo
        {
            get { return _VisitNo; }
            set { _VisitNo = value; }
        }

        [Column(Name = "ServiceUnitCode", DataType = "String")]
        public String ServiceUnitCode
        {
            get { return _ServiceUnitCode; }
            set { _ServiceUnitCode = value; }
        }

        [Column(Name = "ServiceUnitName", DataType = "String")]
        public String ServiceUnitName
        {
            get { return _ServiceUnitName; }
            set { _ServiceUnitName = value; }
        }
        [Column(Name = "Doctor", DataType = "String")]
        public String Doctor
        {
            get { return _Doctor; }
            set { _Doctor = value; }
        }

        [Column(Name = "RefferalCode", DataType = "String")]
        public String RefferalCode
        {
            get { return _RefferalCode; }
            set { _RefferalCode = value; }
        }

        [Column(Name = "RefferalNo", DataType = "String")]
        public String RefferalNo
        {
            get { return _RefferalNo; }
            set { _RefferalNo = value; }
        }

        [Column(Name = "RefferalName", DataType = "String")]
        public String RefferalName
        {
            get { return _RefferalName; }
            set { _RefferalName = value; }
        }

        [Column(Name = "Payer", DataType = "String")]
        public String Payer
        {
            get { return _Payer; }
            set { _Payer = value; }
        }

        [Column(Name = "CreatedBy", DataType = "String")]
        public String CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }

        [Column(Name = "IsNewPatient", DataType = "Boolean")]
        public Boolean IsNewPatient
        {
            get { return _IsNewPatient; }
            set { _IsNewPatient = value; }
        }

        [Column(Name = "VisitCount", DataType = "Int32")]
        public Int32 VisitCount
        {
            get { return _VisitCount; }
            set { _VisitCount = value; }
        }

        [Column(Name = "DischargeMethod", DataType = "String")]
        public String DischargeMethod
        {
            get { return _DischargeMethod; }
            set { _DischargeMethod = value; }
        }

        [Column(Name = "DischargeCondition", DataType = "String")]
        public String DischargeCondition
        {
            get { return _DischargeCondition; }
            set { _DischargeCondition = value; }
        }

        [Column(Name = "FollowUp", DataType = "String")]
        public String FollowUp
        {
            get { return _FollowUp; }
            set { _FollowUp = value; }
        }

        [Column(Name = "Diagnosis", DataType = "String")]
        public String Diagnosis
        {
            get { return _Diagnosis; }
            set { _Diagnosis = value; }
        }

        [Column(Name = "Treatment", DataType = "String")]
        public String Treatment
        {
            get { return _Treatment; }
            set { _Treatment = value; }
        }

        [Column(Name = "IsSurgery", DataType = "Boolean")]
        public Boolean IsSurgery
        {
            get { return _IsSurgery; }
            set { _IsSurgery = value; }
        }

        [Column(Name = "InpatientRegistrationNo", DataType = "String")]
        public String InpatientRegistrationNo
        {
            get { return _InpatientRegistrationNo; }
            set { _InpatientRegistrationNo = value; }
        }

        [Column(Name = "IsVoid", DataType = "Boolean")]
        public Boolean IsVoid
        {
            get { return _IsVoid; }
            set { _IsVoid = value; }
        }

        [Column(Name = "Registrar", DataType = "String")]
        public String Registrar
        {
            get { return _Registrar; }
            set { _Registrar = value; }
        }
    }
    #endregion
    #region vRekapAnestesiIGD
    [Serializable]
    [Table(Name = "vRekapAnestesiIGD")]
    public partial class vRekapAnestesiIGD
    {
        private DateTime _RegistrationDate;
        private String _RegistrationDateText;
        private String _PhysicianCode;
        private Int32 _LocalReferenced;
        private Int32 _LocalNotReferenced;
        private Int32 _LocalHospitalize;
        private Int32 _LocalRefer;
        private Int32 _LocalDischarge;
        private Int32 _LocalDOA;
        private Int32 _LocalDAC;
        private Int32 _GeneralReferenced;
        private Int32 _GeneralNotReferenced;
        private Int32 _GeneralHospitalize;
        private Int32 _GeneralRefer;
        private Int32 _GeneralDischarge;
        private Int32 _GeneralDOA;
        private Int32 _GeneralDAC;
        private Int32 _SpinalReferenced;
        private Int32 _SpinalNotReferenced;
        private Int32 _SpinalHospitalize;
        private Int32 _SpinalRefer;
        private Int32 _SpinalDischarge;
        private Int32 _SpinalDOA;
        private Int32 _SpinalDAC;
        private Int32 _DayCarePatient;

        [Column(Name = "RegistrationDate", DataType = "DateTime")]
        public DateTime RegistrationDate
        {
            get { return _RegistrationDate; }
            set { _RegistrationDate = value; }
        }
        [Column(Name = "RegistrationDateText", DataType = "String")]
        public String RegistrationDateText
        {
            get { return _RegistrationDateText; }
            set { _RegistrationDateText = value; }
        }
        [Column(Name = "PhysicianCode", DataType = "String")]
        public String PhysicianCode
        {
            get { return _PhysicianCode; }
            set { _PhysicianCode = value; }
        }
        [Column(Name = "LocalReferenced", DataType = "Int32")]
        public Int32 LocalReferenced
        {
            get { return _LocalReferenced; }
            set { _LocalReferenced = value; }
        }
        [Column(Name = "LocalNotReferenced", DataType = "Int32")]
        public Int32 LocalNotReferenced
        {
            get { return _LocalNotReferenced; }
            set { _LocalNotReferenced = value; }
        }
        [Column(Name = "LocalHospitalize", DataType = "Int32")]
        public Int32 LocalHospitalize
        {
            get { return _LocalHospitalize; }
            set { _LocalHospitalize = value; }
        }
        [Column(Name = "LocalRefer", DataType = "Int32")]
        public Int32 LocalRefer
        {
            get { return _LocalRefer; }
            set { _LocalRefer = value; }
        }
        [Column(Name = "LocalDischarge", DataType = "Int32")]
        public Int32 LocalDischarge
        {
            get { return _LocalDischarge; }
            set { _LocalDischarge = value; }
        }
        [Column(Name = "LocalDOA", DataType = "Int32")]
        public Int32 LocalDOA
        {
            get { return _LocalDOA; }
            set { _LocalDOA = value; }
        }
        [Column(Name = "LocalDAC", DataType = "Int32")]
        public Int32 LocalDAC
        {
            get { return _LocalDAC; }
            set { _LocalDAC = value; }
        }
        [Column(Name = "GeneralReferenced", DataType = "Int32")]
        public Int32 GeneralReferenced
        {
            get { return _GeneralReferenced; }
            set { _GeneralReferenced = value; }
        }
        [Column(Name = "GeneralNotReferenced", DataType = "Int32")]
        public Int32 GeneralNotReferenced
        {
            get { return _GeneralNotReferenced; }
            set { _GeneralNotReferenced = value; }
        }
        [Column(Name = "GeneralHospitalize", DataType = "Int32")]
        public Int32 GeneralHospitalize
        {
            get { return _GeneralHospitalize; }
            set { _GeneralHospitalize = value; }
        }
        [Column(Name = "GeneralRefer", DataType = "Int32")]
        public Int32 GeneralRefer
        {
            get { return _GeneralRefer; }
            set { _GeneralRefer = value; }
        }
        [Column(Name = "GeneralDischarge", DataType = "Int32")]
        public Int32 GeneralDischarge
        {
            get { return _GeneralDischarge; }
            set { _GeneralDischarge = value; }
        }
        [Column(Name = "GeneralDOA", DataType = "Int32")]
        public Int32 GeneralDOA
        {
            get { return _GeneralDOA; }
            set { _GeneralDOA = value; }
        }
        [Column(Name = "GeneralDAC", DataType = "Int32")]
        public Int32 GeneralDAC
        {
            get { return _GeneralDAC; }
            set { _GeneralDAC = value; }
        }
        [Column(Name = "SpinalReferenced", DataType = "Int32")]
        public Int32 SpinalReferenced
        {
            get { return _SpinalReferenced; }
            set { _SpinalReferenced = value; }
        }
        [Column(Name = "SpinalNotReferenced", DataType = "Int32")]
        public Int32 SpinalNotReferenced
        {
            get { return _SpinalNotReferenced; }
            set { _SpinalNotReferenced = value; }
        }
        [Column(Name = "SpinalHospitalize", DataType = "Int32")]
        public Int32 SpinalHospitalize
        {
            get { return _SpinalHospitalize; }
            set { _SpinalHospitalize = value; }
        }
        [Column(Name = "SpinalRefer", DataType = "Int32")]
        public Int32 SpinalRefer
        {
            get { return _SpinalRefer; }
            set { _SpinalRefer = value; }
        }
        [Column(Name = "SpinalDischarge", DataType = "Int32")]
        public Int32 SpinalDischarge
        {
            get { return _SpinalDischarge; }
            set { _SpinalDischarge = value; }
        }
        [Column(Name = "SpinalDOA", DataType = "Int32")]
        public Int32 SpinalDOA
        {
            get { return _SpinalDOA; }
            set { _SpinalDOA = value; }
        }
        [Column(Name = "SpinalDAC", DataType = "Int32")]
        public Int32 SpinalDAC
        {
            get { return _SpinalDAC; }
            set { _SpinalDAC = value; }
        }
        [Column(Name = "DayCarePatient", DataType = "Int32")]
        public Int32 DayCarePatient
        {
            get { return _DayCarePatient; }
            set { _DayCarePatient = value; }
        }
    }
    #endregion
    #region vRekapKunjunganIGD
    [Serializable]
    [Table(Name = "vRekapKunjunganIGD")]
    public partial class vRekapKunjunganIGD
    {
        private DateTime _RegistrationDate;
        private String _RegistrationDateText;
        private String _PhysicianCode;
        private Int32 _SurgicalReferenced;
        private Int32 _SurgicalNotReferenced;
        private Int32 _SurgicalHospitalize;
        private Int32 _SurgicalRefer;
        private Int32 _SurgicalDischarge;
        private Int32 _SurgicalDOA;
        private Int32 _SurgicalDAC;
        private Int32 _NonSurgicalReferenced;
        private Int32 _NonSurgicalNotReferenced;
        private Int32 _NonSurgicalHospitalize;
        private Int32 _NonSurgicalRefer;
        private Int32 _NonSurgicalDischarge;
        private Int32 _NonSurgicalDOA;
        private Int32 _NonSurgicalDAC;
        private Int32 _ObGynReferenced;
        private Int32 _ObGynNotReferenced;
        private Int32 _ObGynHospitalize;
        private Int32 _ObGynRefer;
        private Int32 _ObGynDischarge;
        private Int32 _ObGynDOA;
        private Int32 _ObGynDAC;
        private Int32 _DayCarePatient;
        private Int32 _LocalAnaesthesia;
        private Int32 _GeneralAnaesthesia;
        private Int32 _SpinalAnaesthesia;

        [Column(Name = "RegistrationDate", DataType = "DateTime")]
        public DateTime RegistrationDate
        {
            get { return _RegistrationDate; }
            set { _RegistrationDate = value; }
        }
        [Column(Name = "RegistrationDateText", DataType = "String")]
        public String RegistrationDateText
        {
            get { return _RegistrationDateText; }
            set { _RegistrationDateText = value; }
        }
        [Column(Name = "PhysicianCode", DataType = "String")]
        public String PhysicianCode
        {
            get { return _PhysicianCode; }
            set { _PhysicianCode = value; }
        }
        [Column(Name = "SurgicalReferenced", DataType = "Int32")]
        public Int32 SurgicalReferenced
        {
            get { return _SurgicalReferenced; }
            set { _SurgicalReferenced = value; }
        }
        [Column(Name = "SurgicalNotReferenced", DataType = "Int32")]
        public Int32 SurgicalNotReferenced
        {
            get { return _SurgicalNotReferenced; }
            set { _SurgicalNotReferenced = value; }
        }
        [Column(Name = "SurgicalHospitalize", DataType = "Int32")]
        public Int32 SurgicalHospitalize
        {
            get { return _SurgicalHospitalize; }
            set { _SurgicalHospitalize = value; }
        }
        [Column(Name = "SurgicalRefer", DataType = "Int32")]
        public Int32 SurgicalRefer
        {
            get { return _SurgicalRefer; }
            set { _SurgicalRefer = value; }
        }
        [Column(Name = "SurgicalDischarge", DataType = "Int32")]
        public Int32 SurgicalDischarge
        {
            get { return _SurgicalDischarge; }
            set { _SurgicalDischarge = value; }
        }
        [Column(Name = "SurgicalDOA", DataType = "Int32")]
        public Int32 SurgicalDOA
        {
            get { return _SurgicalDOA; }
            set { _SurgicalDOA = value; }
        }
        [Column(Name = "SurgicalDAC", DataType = "Int32")]
        public Int32 SurgicalDAC
        {
            get { return _SurgicalDAC; }
            set { _SurgicalDAC = value; }
        }
        [Column(Name = "NonSurgicalReferenced", DataType = "Int32")]
        public Int32 NonSurgicalReferenced
        {
            get { return _NonSurgicalReferenced; }
            set { _NonSurgicalReferenced = value; }
        }
        [Column(Name = "NonSurgicalNotReferenced", DataType = "Int32")]
        public Int32 NonSurgicalNotReferenced
        {
            get { return _NonSurgicalNotReferenced; }
            set { _NonSurgicalNotReferenced = value; }
        }
        [Column(Name = "NonSurgicalHospitalize", DataType = "Int32")]
        public Int32 NonSurgicalHospitalize
        {
            get { return _NonSurgicalHospitalize; }
            set { _NonSurgicalHospitalize = value; }
        }
        [Column(Name = "NonSurgicalRefer", DataType = "Int32")]
        public Int32 NonSurgicalRefer
        {
            get { return _NonSurgicalRefer; }
            set { _NonSurgicalRefer = value; }
        }
        [Column(Name = "NonSurgicalDischarge", DataType = "Int32")]
        public Int32 NonSurgicalDischarge
        {
            get { return _NonSurgicalDischarge; }
            set { _NonSurgicalDischarge = value; }
        }
        [Column(Name = "NonSurgicalDOA", DataType = "Int32")]
        public Int32 NonSurgicalDOA
        {
            get { return _NonSurgicalDOA; }
            set { _NonSurgicalDOA = value; }
        }
        [Column(Name = "NonSurgicalDAC", DataType = "Int32")]
        public Int32 NonSurgicalDAC
        {
            get { return _NonSurgicalDAC; }
            set { _NonSurgicalDAC = value; }
        }
        [Column(Name = "ObGynReferenced", DataType = "Int32")]
        public Int32 ObGynReferenced
        {
            get { return _ObGynReferenced; }
            set { _ObGynReferenced = value; }
        }
        [Column(Name = "ObGynNotReferenced", DataType = "Int32")]
        public Int32 ObGynNotReferenced
        {
            get { return _ObGynNotReferenced; }
            set { _ObGynNotReferenced = value; }
        }
        [Column(Name = "ObGynHospitalize", DataType = "Int32")]
        public Int32 ObGynHospitalize
        {
            get { return _ObGynHospitalize; }
            set { _ObGynHospitalize = value; }
        }
        [Column(Name = "ObGynRefer", DataType = "Int32")]
        public Int32 ObGynRefer
        {
            get { return _ObGynRefer; }
            set { _ObGynRefer = value; }
        }
        [Column(Name = "ObGynDischarge", DataType = "Int32")]
        public Int32 ObGynDischarge
        {
            get { return _ObGynDischarge; }
            set { _ObGynDischarge = value; }
        }
        [Column(Name = "ObGynDOA", DataType = "Int32")]
        public Int32 ObGynDOA
        {
            get { return _ObGynDOA; }
            set { _ObGynDOA = value; }
        }
        [Column(Name = "ObGynDAC", DataType = "Int32")]
        public Int32 ObGynDAC
        {
            get { return _ObGynDAC; }
            set { _ObGynDAC = value; }
        }
        [Column(Name = "DayCarePatient", DataType = "Int32")]
        public Int32 DayCarePatient
        {
            get { return _DayCarePatient; }
            set { _DayCarePatient = value; }
        }
        [Column(Name = "LocalAnaesthesia", DataType = "Int32")]
        public Int32 LocalAnaesthesia
        {
            get { return _LocalAnaesthesia; }
            set { _LocalAnaesthesia = value; }
        }
        [Column(Name = "GeneralAnaesthesia", DataType = "Int32")]
        public Int32 GeneralAnaesthesia
        {
            get { return _GeneralAnaesthesia; }
            set { _GeneralAnaesthesia = value; }
        }
        [Column(Name = "SpinalAnaesthesia", DataType = "Int32")]
        public Int32 SpinalAnaesthesia
        {
            get { return _SpinalAnaesthesia; }
            set { _SpinalAnaesthesia = value; }
        }
    }
    #endregion
    #region vSupplier
    [Serializable]
    [Table(Name = "vSupplier")]
    public class vSupplier
    {
        private String _SupplierCode;
        private String _SupplierName;
        private String _SupplierType;
        private String _ContactPersonName;
        private String _Address;
        private String _TelephoneNo;
        private String _FaxNo;
        private Boolean _IsPharmacySupplier;
        private Boolean _IsLogisticSupplier;

        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }
        [Column(Name = "SupplierType", DataType = "String")]
        public String SupplierType
        {
            get { return _SupplierType; }
            set { _SupplierType = value; }
        }
        [Column(Name = "ContactPersonName", DataType = "String")]
        public String ContactPersonName
        {
            get { return _ContactPersonName; }
            set { _ContactPersonName = value; }
        }
        [Column(Name = "Address", DataType = "String")]
        public String Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        [Column(Name = "TelephoneNo", DataType = "String")]
        public String TelephoneNo
        {
            get { return _TelephoneNo; }
            set { _TelephoneNo = value; }
        }
        [Column(Name = "FaxNo", DataType = "String")]
        public String FaxNo
        {
            get { return _FaxNo; }
            set { _FaxNo = value; }
        }
        [Column(Name = "IsPharmacySupplier", DataType = "Boolean")]
        public Boolean IsPharmacySupplier
        {
            get { return _IsPharmacySupplier; }
            set { _IsPharmacySupplier = value; }
        }
        [Column(Name = "IsLogisticSupplier", DataType = "Boolean")]
        public Boolean IsLogisticSupplier
        {
            get { return _IsLogisticSupplier; }
            set { _IsLogisticSupplier = value; }
        }
    }
    #endregion
    #region vSupplierItemMatrix
    [Serializable]
    [Table(Name = "vSupplierItemMatrix")]
    public class vSupplierItemMatrix
    {
        private String _SupplierCode;
        private String _SupplierName;
        private String _ItemCode;
        private String _ItemName;
        private String _ProductLine;
        private String _AlternateUnit;
        private Decimal _Price;
        private Double _Discount;
        private Boolean _VAT;
        private DateTime _UpdatedDate;
        private String _UpdatedUser;

        [Column(Name = "SupplierCode", DataType = "String")]
        public String SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        [Column(Name = "SupplierName", DataType = "String")]
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
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
        [Column(Name = "AlternateUnit", DataType = "String")]
        public String AlternateUnit
        {
            get { return _AlternateUnit; }
            set { _AlternateUnit = value; }
        }
        [Column(Name = "Price", DataType = "Decimal")]
        public Decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        [Column(Name = "Discount", DataType = "Double")]
        public Double Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
        [Column(Name = "VAT", DataType = "Boolean")]
        public Boolean VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }
        [Column(Name = "UpdatedDate", DataType = "DateTime")]
        public DateTime UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }
        [Column(Name = "UpdatedUser", DataType = "String")]
        public String UpdatedUser
        {
            get { return _UpdatedUser; }
            set { _UpdatedUser = value; }
        }
    }
    #endregion
    #region vTariff
    [Serializable]
    [Table(Name = "vTariff")]
    public class vTariff
    {
        private String _ServiceTariffBookNo;
        private String _Description;
        private String _ServiceItemCode;
        private String _ServiceItemName;
        private String _ClassCode;
        private String _ClassName;
        private String _TariffTypeCode;
        private String _TariffTypeName;
        private Decimal _BasePrice;
        private Decimal _UnitPrice;
        private DateTime _CreatedDate;
        private String _CreatedBy;
        private DateTime _UpdatedDate;
        private String _UpdatedBy;
        private DateTime _AppliedDate;
        private String _AppliedDateText;

        [Column(Name = "ServiceTariffBookNo", DataType = "String")]
        public String ServiceTariffBookNo
        {
            get { return _ServiceTariffBookNo; }
            set { _ServiceTariffBookNo = value; }
        }
        [Column(Name = "Description", DataType = "String")]
        public String Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        [Column(Name = "ServiceItemCode", DataType = "String")]
        public String ServiceItemCode
        {
            get { return _ServiceItemCode; }
            set { _ServiceItemCode = value; }
        }
        [Column(Name = "ServiceItemName", DataType = "String")]
        public String ServiceItemName
        {
            get { return _ServiceItemName; }
            set { _ServiceItemName = value; }
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
        [Column(Name = "TariffTypeCode", DataType = "String")]
        public String TariffTypeCode
        {
            get { return _TariffTypeCode; }
            set { _TariffTypeCode = value; }
        }
        [Column(Name = "TariffTypeName", DataType = "String")]
        public String TariffTypeName
        {
            get { return _TariffTypeName; }
            set { _TariffTypeName = value; }
        }
        [Column(Name = "BasePrice", DataType = "Decimal")]
        public Decimal BasePrice
        {
            get { return _BasePrice; }
            set { _BasePrice = value; }
        }
        [Column(Name = "UnitPrice", DataType = "Decimal")]
        public Decimal UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
        [Column(Name = "CreatedDate", DataType = "DateTime")]
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        [Column(Name = "CreatedBy", DataType = "String")]
        public String CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        [Column(Name = "UpdatedDate", DataType = "DateTime")]
        public DateTime UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }
        [Column(Name = "UpdatedBy", DataType = "String")]
        public String UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; }
        }
        [Column(Name = "AppliedDate", DataType = "DateTime")]
        public DateTime AppliedDate
        {
            get { return _AppliedDate; }
            set { _AppliedDate = value; }
        }
        [Column(Name = "AppliedDateText", DataType = "String")]
        public String AppliedDateText
        {
            get { return _AppliedDateText; }
            set { _AppliedDateText = value; }
        }
    }
    #endregion
    #region vTestAndResultMD
    [Serializable]
    [Table(Name = "vTestAndResultMD")]
    public partial class vTestAndResultMD
    {
        private String _UnitType;
        private String _TransactionNo;
        private DateTime _TransactionDate;
        private String _TransactionDateText;
        private String _TransactionTime;
        private String _RegistrationNo;
        private String _MedicalNo;
        private String _FirstName;
        private String _LastName;
        private String _Gender;
        private String _MedicalDiagnosticCode;
        private String _MedicalDiagnosticName;
        private String _ServiceCode;
        private String _ServiceName;
        private String _PhysicianCode;
        private String _PhysicianName;
        private Double _Quantity;
        private Decimal _PatientAmount;
        private Decimal _PayerAmount;
        private Decimal _Cito;
        private Decimal _Complication;
        private String _PayerCode;
        private String _Payer;

        [Column(Name = "UnitType", DataType = "String")]
        public String UnitType
        {
            get { return _UnitType; }
            set { _UnitType = value; }
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
        [Column(Name = "TransactionDateText", DataType = "String")]
        public String TransactionDateText
        {
            get { return _TransactionDateText; }
            set { _TransactionDateText = value; }
        }
        [Column(Name = "TransactionTime", DataType = "String")]
        public String TransactionTime
        {
            get { return _TransactionTime; }
            set { _TransactionTime = value; }
        }
        [Column(Name = "RegistrationNo", DataType = "String")]
        public String RegistrationNo
        {
            get { return _RegistrationNo; }
            set { _RegistrationNo = value; }
        }
        [Column(Name = "MedicalNo", DataType = "String")]
        public String MedicalNo
        {
            get { return _MedicalNo; }
            set { _MedicalNo = value; }
        }
        [Column(Name = "FirstName", DataType = "String")]
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        [Column(Name = "LastName", DataType = "String")]
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        [Column(Name = "Gender", DataType = "String")]
        public String Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        [Column(Name = "MedicalDiagnosticCode", DataType = "String")]
        public String MedicalDiagnosticCode
        {
            get { return _MedicalDiagnosticCode; }
            set { _MedicalDiagnosticCode = value; }
        }
        [Column(Name = "MedicalDiagnosticName", DataType = "String")]
        public String MedicalDiagnosticName
        {
            get { return _MedicalDiagnosticName; }
            set { _MedicalDiagnosticName = value; }
        }
        [Column(Name = "ServiceCode", DataType = "String")]
        public String ServiceCode
        {
            get { return _ServiceCode; }
            set { _ServiceCode = value; }
        }
        [Column(Name = "ServiceName", DataType = "String")]
        public String ServiceName
        {
            get { return _ServiceName; }
            set { _ServiceName = value; }
        }
        [Column(Name = "PhysicianCode", DataType = "String")]
        public String PhysicianCode
        {
            get { return _PhysicianCode; }
            set { _PhysicianCode = value; }
        }
        [Column(Name = "PhysicianName", DataType = "String")]
        public String PhysicianName
        {
            get { return _PhysicianName; }
            set { _PhysicianName = value; }
        }
        [Column(Name = "Quantity", DataType = "Double")]
        public Double Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        [Column(Name = "PatientAmount", DataType = "Decimal")]
        public Decimal PatientAmount
        {
            get { return _PatientAmount; }
            set { _PatientAmount = value; }
        }
        [Column(Name = "PayerAmount", DataType = "Decimal")]
        public Decimal PayerAmount
        {
            get { return _PayerAmount; }
            set { _PayerAmount = value; }
        }
        [Column(Name = "Cito", DataType = "Decimal")]
        public Decimal Cito
        {
            get { return _Cito; }
            set { _Cito = value; }
        }
        [Column(Name = "Complication", DataType = "Decimal")]
        public Decimal Complication
        {
            get { return _Complication; }
            set { _Complication = value; }
        }
        [Column(Name = "PayerCode", DataType = "String")]
        public String PayerCode
        {
            get { return _PayerCode; }
            set { _PayerCode = value; }
        }
        [Column(Name = "Payer", DataType = "String")]
        public String Payer
        {
            get { return _Payer; }
            set { _Payer = value; }
        }
    }
    #endregion
    #region vUser
    [Serializable]
    [Table(Name = "vUser")]
    public class vUser
    {
        private String _UserID;
        private String _UserName;
        private String _UserGroupID;
        private String _UserGroupName;
        private String _PrimaryPhoneNo;
        private String _Email;
        private Boolean _IsActive;

        [Column(Name = "UserID", DataType = "String")]
        public String UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        [Column(Name = "UserName", DataType = "String")]
        public String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        [Column(Name = "UserGroupID", DataType = "String")]
        public String UserGroupID
        {
            get { return _UserGroupID; }
            set { _UserGroupID = value; }
        }
        [Column(Name = "UserGroupName", DataType = "String")]
        public String UserGroupName
        {
            get { return _UserGroupName; }
            set { _UserGroupName = value; }
        }
        [Column(Name = "PrimaryPhoneNo", DataType = "String")]
        public String PrimaryPhoneNo
        {
            get { return _PrimaryPhoneNo; }
            set { _PrimaryPhoneNo = value; }
        }
        [Column(Name = "Email", DataType = "String")]
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        [Column(Name = "IsActive", DataType = "Boolean")]
        public Boolean IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
    }
    #endregion
    #region vWaitingListRI
    [Serializable]
    [Table(Name = "vWaitingListRI")]
    public class vWaitingListRI
    {
        private String _WaitingListNo;
        private DateTime _WaitingListDate;
        private String _WaitingListTime;
        private DateTime _RegistrationDate;
        private String _RegistrationTime;
        private String _MedicalNo;
        private String _FirstName;
        private String _LastName;
        private String _Gender;
        private DateTime _DateOfBirth;
        private String _Telephone;
        private String _MobilePhone;
        private String _DoctorCode;
        private String _DoctorName;
        private String _WardCode;
        private String _BedNumber;
        private Boolean _IsVoid;

        [Column(Name = "WaitingListNo", DataType = "String")]
        public String WaitingListNo
        {
            get { return _WaitingListNo; }
            set { _WaitingListNo = value; }
        }
        [Column(Name = "WaitingListDate", DataType = "DateTime")]
        public DateTime WaitingListDate
        {
            get { return _WaitingListDate; }
            set { _WaitingListDate = value; }
        }
        [Column(Name = "WaitingListTime", DataType = "String")]
        public String WaitingListTime
        {
            get { return _WaitingListTime; }
            set { _WaitingListTime = value; }
        }
        [Column(Name = "RegistrationDate", DataType = "DateTime")]
        public DateTime RegistrationDate
        {
            get { return _RegistrationDate; }
            set { _RegistrationDate = value; }
        }
        [Column(Name = "RegistrationTime", DataType = "String")]
        public String RegistrationTime
        {
            get { return _RegistrationTime; }
            set { _RegistrationTime = value; }
        }
        [Column(Name = "MedicalNo", DataType = "String")]
        public String MedicalNo
        {
            get { return _MedicalNo; }
            set { _MedicalNo = value; }
        }
        [Column(Name = "FirstName", DataType = "String")]
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        [Column(Name = "LastName", DataType = "String")]
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        [Column(Name = "Gender", DataType = "String")]
        public String Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        [Column(Name = "DateOfBirth", DataType = "DateTime")]
        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }
        [Column(Name = "Telephone", DataType = "String")]
        public String Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }
        [Column(Name = "MobilePhone", DataType = "String")]
        public String MobilePhone
        {
            get { return _MobilePhone; }
            set { _MobilePhone = value; }
        }
        [Column(Name = "DoctorCode", DataType = "String")]
        public String DoctorCode
        {
            get { return _DoctorCode; }
            set { _DoctorCode = value; }
        }
        [Column(Name = "DoctorName", DataType = "String")]
        public String DoctorName
        {
            get { return _DoctorName; }
            set { _DoctorName = value; }
        }
        [Column(Name = "WardCode", DataType = "String")]
        public String WardCode
        {
            get { return _WardCode; }
            set { _WardCode = value; }
        }
        [Column(Name = "BedNumber", DataType = "String")]
        public String BedNumber
        {
            get { return _BedNumber; }
            set { _BedNumber = value; }
        }
        [Column(Name = "IsVoid", DataType = "Boolean")]
        public Boolean IsVoid
        {
            get { return _IsVoid; }
            set { _IsVoid = value; }
        }
    }
    #endregion
    #region vWard
    [Serializable]
    [Table(Name = "vWard")]
    public class vWard
    {
        private String _WardCode;
        private String _WardName;
        private String _PharmacyWarehouseCode;
        private String _PharmacyWarehouseName;
        private String _PharmacyLocationCode;
        private String _PharmacyLocationName;
        private String _LogisticWarehouseCode;
        private String _LogisticWarehouseName;
        private String _LogisticLocationCode;
        private String _LogisticLocationName;
        private Boolean _IsActive;

        [Column(Name = "WardCode", DataType = "String")]
        public String WardCode
        {
            get { return _WardCode; }
            set { _WardCode = value; }
        }
        [Column(Name = "WardName", DataType = "String")]
        public String WardName
        {
            get { return _WardName; }
            set { _WardName = value; }
        }
        [Column(Name = "PharmacyWarehouseCode", DataType = "String")]
        public String PharmacyWarehouseCode
        {
            get { return _PharmacyWarehouseCode; }
            set { _PharmacyWarehouseCode = value; }
        }
        [Column(Name = "PharmacyWarehouseName", DataType = "String")]
        public String PharmacyWarehouseName
        {
            get { return _PharmacyWarehouseName; }
            set { _PharmacyWarehouseName = value; }
        }
        [Column(Name = "PharmacyLocationCode", DataType = "String")]
        public String PharmacyLocationCode
        {
            get { return _PharmacyLocationCode; }
            set { _PharmacyLocationCode = value; }
        }
        [Column(Name = "PharmacyLocationName", DataType = "String")]
        public String PharmacyLocationName
        {
            get { return _PharmacyLocationName; }
            set { _PharmacyLocationName = value; }
        }
        [Column(Name = "LogisticWarehouseCode", DataType = "String")]
        public String LogisticWarehouseCode
        {
            get { return _LogisticWarehouseCode; }
            set { _LogisticWarehouseCode = value; }
        }
        [Column(Name = "LogisticWarehouseName", DataType = "String")]
        public String LogisticWarehouseName
        {
            get { return _LogisticWarehouseName; }
            set { _LogisticWarehouseName = value; }
        }
        [Column(Name = "LogisticLocationCode", DataType = "String")]
        public String LogisticLocationCode
        {
            get { return _LogisticLocationCode; }
            set { _LogisticLocationCode = value; }
        }
        [Column(Name = "LogisticLocationName", DataType = "String")]
        public String LogisticLocationName
        {
            get { return _LogisticLocationName; }
            set { _LogisticLocationName = value; }
        }
        [Column(Name = "IsActive", DataType = "Boolean")]
        public Boolean IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
    }
    #endregion
    #region vWarehouseLocation
    [Serializable]
    [Table(Name = "vWarehouseLocation")]
    public class vWarehouseLocation
    {
        private String _warehouseCode;
        private String _warehouseName;
        private String _locationCode;
        private String _locationName;
        private DateTime _startDate;

        [Column(Name = "warehouseCode", DataType = "String")]
        public String warehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }
        [Column(Name = "warehouseName", DataType = "String")]
        public String warehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }
        [Column(Name = "locationCode", DataType = "String")]
        public String locationCode
        {
            get { return _locationCode; }
            set { _locationCode = value; }
        }
        [Column(Name = "locationName", DataType = "String")]
        public String locationName
        {
            get { return _locationName; }
            set { _locationName = value; }
        }
        [Column(Name = "startDate", DataType = "DateTime")]
        public DateTime startDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
    }
    #endregion
}
