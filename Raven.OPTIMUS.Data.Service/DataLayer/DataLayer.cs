using System;
using System.Collections.Generic;
using System.Text;
using Raven.Data.Core.Dal;
using System.Data;

namespace Raven.OPTIMUS.Data.Service
{   
    #region app
    [Serializable]
    [Table(Name = "app")]
    public class App : DbDataModel
    {
        private String _AppId;
        private String _AppName;
        private String _url;
        private String _AppRow;
        private Decimal _counter;
        private String _description;
        private Boolean _isActive;
        private String _AppImg;
        private String _AppImgHover;
        private String _AppImgClick;
        private String _AppImgDisabled;

        [Column(Name = "AppId", DataType = "String", IsPrimaryKey = true)]
        public String AppId
        {
            get { return _AppId; }
            set { _AppId = value; }
        }
        [Column(Name = "AppName", DataType = "String")]
        public String AppName
        {
            get { return _AppName; }
            set { _AppName = value; }
        }
        [Column(Name = "url", DataType = "String")]
        public String url
        {
            get { return _url; }
            set { _url = value; }
        }
        [Column(Name = "AppRow", DataType = "String", IsNullable = true)]
        public String AppRow
        {
            get { return _AppRow; }
            set { _AppRow = value; }
        }
        [Column(Name = "counter", DataType = "Decimal")]
        public Decimal counter
        {
            get { return _counter; }
            set { _counter = value; }
        }
        [Column(Name = "description", DataType = "String", IsNullable = true)]
        public String description
        {
            get { return _description; }
            set { _description = value; }
        }
        [Column(Name = "isActive", DataType = "Boolean")]
        public Boolean isActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        [Column(Name = "AppImg", DataType = "String", IsNullable = true)]
        public String AppImg
        {
            get { return _AppImg; }
            set { _AppImg = value; }
        }
        [Column(Name = "AppImgHover", DataType = "String", IsNullable = true)]
        public String AppImgHover
        {
            get { return _AppImgHover; }
            set { _AppImgHover = value; }
        }
        [Column(Name = "AppImgClick", DataType = "String", IsNullable = true)]
        public String AppImgClick
        {
            get { return _AppImgClick; }
            set { _AppImgClick = value; }
        }
        [Column(Name = "AppImgDisabled", DataType = "String", IsNullable = true)]
        public String AppImgDisabled
        {
            get { return _AppImgDisabled; }
            set { _AppImgDisabled = value; }
        }
    }

    public class AppDao
    {
        private readonly IDbContext _ctx = DbFactory.Configure();
        private readonly DbHelper _helper = new DbHelper(typeof(App));
        private bool _isAuditLog = false;
        private const string p_AppId = "@p_AppId";
        public AppDao() { }
        public AppDao(IDbContext ctx)
        {
            _ctx = ctx;
        }
        public App Get(String AppId)
        {
            _ctx.CommandText = _helper.GetRecord();
            _ctx.Add(p_AppId, AppId);
            DataRow row = DaoBase.GetDataRow(_ctx);
            return (row == null) ? null : (App)_helper.DataRowToObject(row, new App());
        }
        public int Insert(App record)
        {
            _helper.Insert(_ctx, record, _isAuditLog);
            return DaoBase.ExecuteNonQuery(_ctx);
        }
        public int Update(App record)
        {
            _helper.Update(_ctx, record, _isAuditLog);
            return DaoBase.ExecuteNonQuery(_ctx, true);
        }
        public int Delete(String AppId)
        {
            App record;
            if (_ctx.Transaction == null)
                record = new AppDao().Get(AppId);
            else
                record = Get(AppId);
            _helper.Delete(_ctx, record, _isAuditLog);
            return DaoBase.ExecuteNonQuery(_ctx);
        }
    }
    #endregion

    #region Pasien
    [Serializable]
    [Table(Name = "pasien")]
    public class Pasien : DbDataModel
    {
        private String _norm;
        private String _title;
        private String _nama;
        private String _marga;
        private String _kdseks;
        private String _tmplahir;
        private DateTime _tgllahir;
        private Int16 _umurtahun;
        private Int16 _umurbulan;
        private Int16 _umurhari;
        private String _jalan;
        private String _gang;
        private String _rt;
        private String _rw;
        private String _notelepon;
        private String _nohp;
        private String _kota;
        private String _kdpos;
        private String _kdpropinsi;
        private String _kdagama;
        private String _kdstkawin;
        private String _kdpendidikan;
        private String _kdpekerjaan;
        private String _descpekerjaan;
        private String _kdwarganegara;
        private String _alergi;
        private String _catatan;
        private Decimal _kunjunganRJke;
        private DateTime _tglakhkunjunganRJ;
        private String _noktpsim;
        private DateTime _tglexpired;
        private String _nopasport;
        private Boolean _aktif;
        private String _nomember;
        private Boolean _blacklist;
        private DateTime _lupdate;
        private String _updater;
        private Boolean _Member;
        private String _NamaKantor;
        private String _AlamatKantor1;
        private String _AlamatKantor2;
        private String _KantorKota;
        private String _KantorNoTelp;
        private String _golongandarah;
        private String _email;
        private Boolean _pasien;
        private Boolean _statfilerj;
        private Boolean _statfileri;
        private String _kdinstansi;
        private Decimal _rawatRIke;
        private DateTime _tglakhrawatRI;
        private String _kdrakstatusRJ;
        private String _kdrakstatusRI;
        private String _kdsuku;
        private String _namaayah;
        private String _kdpekerjaanayah;
        private String _descpekerjaanayah;
        private Int16 _umurayah;
        private String _namaibu;
        private String _kdpekerjaanibu;
        private String _descpekerjaanibu;
        private Int16 _umuribu;
        private String _nofoto;
        private String _kdrakstatusRD;
        private Boolean _statfileRD;
        private Boolean _PSE;
        private String _alasan;
        private Decimal _kunjunganRDke;
        private DateTime _tglakhkunjunganRD;
        private String _Status;
        private String _Photo;
        private String _DiagnoseAwal;
        private String _nmEmergencyContact;
        private String _almtEmergencyContact;
        private String _hubEmergencyContact;
        private String _telpEmergencyContact;
        private String _gelar;
        private DateTime _tglinsert;
        private String _PatientPhoto;
        private String _OldNoRM;

        [Column(Name = "norm", DataType = "String", IsPrimaryKey = true)]
        public String norm
        {
            get { return _norm; }
            set { _norm = value; }
        }
        [Column(Name = "title", DataType = "String")]
        public String title
        {
            get { return _title; }
            set { _title = value; }
        }
        [Column(Name = "nama", DataType = "String")]
        public String nama
        {
            get { return _nama; }
            set { _nama = value; }
        }
        [Column(Name = "marga", DataType = "String")]
        public String marga
        {
            get { return _marga; }
            set { _marga = value; }
        }
        [Column(Name = "kdseks", DataType = "String")]
        public String kdseks
        {
            get { return _kdseks; }
            set { _kdseks = value; }
        }
        [Column(Name = "tmplahir", DataType = "String")]
        public String tmplahir
        {
            get { return _tmplahir; }
            set { _tmplahir = value; }
        }
        [Column(Name = "tgllahir", DataType = "DateTime")]
        public DateTime tgllahir
        {
            get { return _tgllahir; }
            set { _tgllahir = value; }
        }
        [Column(Name = "umurtahun", DataType = "Int16")]
        public Int16 umurtahun
        {
            get { return _umurtahun; }
            set { _umurtahun = value; }
        }
        [Column(Name = "umurbulan", DataType = "Int16")]
        public Int16 umurbulan
        {
            get { return _umurbulan; }
            set { _umurbulan = value; }
        }
        [Column(Name = "umurhari", DataType = "Int16")]
        public Int16 umurhari
        {
            get { return _umurhari; }
            set { _umurhari = value; }
        }
        [Column(Name = "jalan", DataType = "String")]
        public String jalan
        {
            get { return _jalan; }
            set { _jalan = value; }
        }
        [Column(Name = "gang", DataType = "String")]
        public String gang
        {
            get { return _gang; }
            set { _gang = value; }
        }
        [Column(Name = "rt", DataType = "String")]
        public String rt
        {
            get { return _rt; }
            set { _rt = value; }
        }
        [Column(Name = "rw", DataType = "String")]
        public String rw
        {
            get { return _rw; }
            set { _rw = value; }
        }
        [Column(Name = "notelepon", DataType = "String")]
        public String notelepon
        {
            get { return _notelepon; }
            set { _notelepon = value; }
        }
        [Column(Name = "nohp", DataType = "String")]
        public String nohp
        {
            get { return _nohp; }
            set { _nohp = value; }
        }
        [Column(Name = "kota", DataType = "String")]
        public String kota
        {
            get { return _kota; }
            set { _kota = value; }
        }
        [Column(Name = "kdpos", DataType = "String")]
        public String kdpos
        {
            get { return _kdpos; }
            set { _kdpos = value; }
        }
        [Column(Name = "kdpropinsi", DataType = "String")]
        public String kdpropinsi
        {
            get { return _kdpropinsi; }
            set { _kdpropinsi = value; }
        }
        [Column(Name = "kdagama", DataType = "String")]
        public String kdagama
        {
            get { return _kdagama; }
            set { _kdagama = value; }
        }
        [Column(Name = "kdstkawin", DataType = "String")]
        public String kdstkawin
        {
            get { return _kdstkawin; }
            set { _kdstkawin = value; }
        }
        [Column(Name = "kdpendidikan", DataType = "String")]
        public String kdpendidikan
        {
            get { return _kdpendidikan; }
            set { _kdpendidikan = value; }
        }
        [Column(Name = "kdpekerjaan", DataType = "String")]
        public String kdpekerjaan
        {
            get { return _kdpekerjaan; }
            set { _kdpekerjaan = value; }
        }
        [Column(Name = "descpekerjaan", DataType = "String")]
        public String descpekerjaan
        {
            get { return _descpekerjaan; }
            set { _descpekerjaan = value; }
        }
        [Column(Name = "kdwarganegara", DataType = "String")]
        public String kdwarganegara
        {
            get { return _kdwarganegara; }
            set { _kdwarganegara = value; }
        }
        [Column(Name = "alergi", DataType = "String")]
        public String alergi
        {
            get { return _alergi; }
            set { _alergi = value; }
        }
        [Column(Name = "catatan", DataType = "String")]
        public String catatan
        {
            get { return _catatan; }
            set { _catatan = value; }
        }
        [Column(Name = "kunjunganRJke", DataType = "Decimal", IsNullable = true)]
        public Decimal kunjunganRJke
        {
            get { return _kunjunganRJke; }
            set { _kunjunganRJke = value; }
        }
        [Column(Name = "tglakhkunjunganRJ", DataType = "DateTime", IsNullable = true)]
        public DateTime tglakhkunjunganRJ
        {
            get { return _tglakhkunjunganRJ; }
            set { _tglakhkunjunganRJ = value; }
        }
        [Column(Name = "noktpsim", DataType = "String")]
        public String noktpsim
        {
            get { return _noktpsim; }
            set { _noktpsim = value; }
        }
        [Column(Name = "tglexpired", DataType = "DateTime")]
        public DateTime tglexpired
        {
            get { return _tglexpired; }
            set { _tglexpired = value; }
        }
        [Column(Name = "nopasport", DataType = "String")]
        public String nopasport
        {
            get { return _nopasport; }
            set { _nopasport = value; }
        }
        [Column(Name = "aktif", DataType = "Boolean")]
        public Boolean aktif
        {
            get { return _aktif; }
            set { _aktif = value; }
        }
        [Column(Name = "nomember", DataType = "String")]
        public String nomember
        {
            get { return _nomember; }
            set { _nomember = value; }
        }
        [Column(Name = "blacklist", DataType = "Boolean")]
        public Boolean blacklist
        {
            get { return _blacklist; }
            set { _blacklist = value; }
        }
        [Column(Name = "lupdate", DataType = "DateTime")]
        public DateTime lupdate
        {
            get { return _lupdate; }
            set { _lupdate = value; }
        }
        [Column(Name = "updater", DataType = "String")]
        public String updater
        {
            get { return _updater; }
            set { _updater = value; }
        }
        [Column(Name = "Member", DataType = "Boolean")]
        public Boolean Member
        {
            get { return _Member; }
            set { _Member = value; }
        }
        [Column(Name = "NamaKantor", DataType = "String")]
        public String NamaKantor
        {
            get { return _NamaKantor; }
            set { _NamaKantor = value; }
        }
        [Column(Name = "AlamatKantor1", DataType = "String")]
        public String AlamatKantor1
        {
            get { return _AlamatKantor1; }
            set { _AlamatKantor1 = value; }
        }
        [Column(Name = "AlamatKantor2", DataType = "String")]
        public String AlamatKantor2
        {
            get { return _AlamatKantor2; }
            set { _AlamatKantor2 = value; }
        }
        [Column(Name = "KantorKota", DataType = "String")]
        public String KantorKota
        {
            get { return _KantorKota; }
            set { _KantorKota = value; }
        }
        [Column(Name = "KantorNoTelp", DataType = "String")]
        public String KantorNoTelp
        {
            get { return _KantorNoTelp; }
            set { _KantorNoTelp = value; }
        }
        [Column(Name = "golongandarah", DataType = "String")]
        public String golongandarah
        {
            get { return _golongandarah; }
            set { _golongandarah = value; }
        }
        [Column(Name = "email", DataType = "String")]
        public String email
        {
            get { return _email; }
            set { _email = value; }
        }
        [Column(Name = "pasien", DataType = "Boolean")]
        public Boolean pasien
        {
            get { return _pasien; }
            set { _pasien = value; }
        }
        [Column(Name = "statfilerj", DataType = "Boolean")]
        public Boolean statfilerj
        {
            get { return _statfilerj; }
            set { _statfilerj = value; }
        }
        [Column(Name = "statfileri", DataType = "Boolean")]
        public Boolean statfileri
        {
            get { return _statfileri; }
            set { _statfileri = value; }
        }
        [Column(Name = "kdinstansi", DataType = "String")]
        public String kdinstansi
        {
            get { return _kdinstansi; }
            set { _kdinstansi = value; }
        }
        [Column(Name = "rawatRIke", DataType = "Decimal", IsNullable = true)]
        public Decimal rawatRIke
        {
            get { return _rawatRIke; }
            set { _rawatRIke = value; }
        }
        [Column(Name = "tglakhrawatRI", DataType = "DateTime", IsNullable = true)]
        public DateTime tglakhrawatRI
        {
            get { return _tglakhrawatRI; }
            set { _tglakhrawatRI = value; }
        }
        [Column(Name = "kdrakstatusRJ", DataType = "String")]
        public String kdrakstatusRJ
        {
            get { return _kdrakstatusRJ; }
            set { _kdrakstatusRJ = value; }
        }
        [Column(Name = "kdrakstatusRI", DataType = "String")]
        public String kdrakstatusRI
        {
            get { return _kdrakstatusRI; }
            set { _kdrakstatusRI = value; }
        }
        [Column(Name = "kdsuku", DataType = "String")]
        public String kdsuku
        {
            get { return _kdsuku; }
            set { _kdsuku = value; }
        }
        [Column(Name = "namaayah", DataType = "String")]
        public String namaayah
        {
            get { return _namaayah; }
            set { _namaayah = value; }
        }
        [Column(Name = "kdpekerjaanayah", DataType = "String")]
        public String kdpekerjaanayah
        {
            get { return _kdpekerjaanayah; }
            set { _kdpekerjaanayah = value; }
        }
        [Column(Name = "descpekerjaanayah", DataType = "String")]
        public String descpekerjaanayah
        {
            get { return _descpekerjaanayah; }
            set { _descpekerjaanayah = value; }
        }
        [Column(Name = "umurayah", DataType = "Int16")]
        public Int16 umurayah
        {
            get { return _umurayah; }
            set { _umurayah = value; }
        }
        [Column(Name = "namaibu", DataType = "String")]
        public String namaibu
        {
            get { return _namaibu; }
            set { _namaibu = value; }
        }
        [Column(Name = "kdpekerjaanibu", DataType = "String")]
        public String kdpekerjaanibu
        {
            get { return _kdpekerjaanibu; }
            set { _kdpekerjaanibu = value; }
        }
        [Column(Name = "descpekerjaanibu", DataType = "String")]
        public String descpekerjaanibu
        {
            get { return _descpekerjaanibu; }
            set { _descpekerjaanibu = value; }
        }
        [Column(Name = "umuribu", DataType = "Int16")]
        public Int16 umuribu
        {
            get { return _umuribu; }
            set { _umuribu = value; }
        }
        [Column(Name = "nofoto", DataType = "String")]
        public String nofoto
        {
            get { return _nofoto; }
            set { _nofoto = value; }
        }
        [Column(Name = "kdrakstatusRD", DataType = "String")]
        public String kdrakstatusRD
        {
            get { return _kdrakstatusRD; }
            set { _kdrakstatusRD = value; }
        }
        [Column(Name = "statfileRD", DataType = "Boolean")]
        public Boolean statfileRD
        {
            get { return _statfileRD; }
            set { _statfileRD = value; }
        }
        [Column(Name = "PSE", DataType = "Boolean")]
        public Boolean PSE
        {
            get { return _PSE; }
            set { _PSE = value; }
        }
        [Column(Name = "alasan", DataType = "String")]
        public String alasan
        {
            get { return _alasan; }
            set { _alasan = value; }
        }
        [Column(Name = "kunjunganRDke", DataType = "Decimal", IsNullable = true)]
        public Decimal kunjunganRDke
        {
            get { return _kunjunganRDke; }
            set { _kunjunganRDke = value; }
        }
        [Column(Name = "tglakhkunjunganRD", DataType = "DateTime", IsNullable = true)]
        public DateTime tglakhkunjunganRD
        {
            get { return _tglakhkunjunganRD; }
            set { _tglakhkunjunganRD = value; }
        }
        [Column(Name = "Status", DataType = "String")]
        public String Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        [Column(Name = "Photo", DataType = "String")]
        public String Photo
        {
            get { return _Photo; }
            set { _Photo = value; }
        }
        [Column(Name = "DiagnoseAwal", DataType = "String")]
        public String DiagnoseAwal
        {
            get { return _DiagnoseAwal; }
            set { _DiagnoseAwal = value; }
        }
        [Column(Name = "nmEmergencyContact", DataType = "String")]
        public String nmEmergencyContact
        {
            get { return _nmEmergencyContact; }
            set { _nmEmergencyContact = value; }
        }
        [Column(Name = "almtEmergencyContact", DataType = "String")]
        public String almtEmergencyContact
        {
            get { return _almtEmergencyContact; }
            set { _almtEmergencyContact = value; }
        }
        [Column(Name = "hubEmergencyContact", DataType = "String")]
        public String hubEmergencyContact
        {
            get { return _hubEmergencyContact; }
            set { _hubEmergencyContact = value; }
        }
        [Column(Name = "telpEmergencyContact", DataType = "String")]
        public String telpEmergencyContact
        {
            get { return _telpEmergencyContact; }
            set { _telpEmergencyContact = value; }
        }
        [Column(Name = "gelar", DataType = "String")]
        public String gelar
        {
            get { return _gelar; }
            set { _gelar = value; }
        }
        [Column(Name = "tglinsert", DataType = "DateTime")]
        public DateTime tglinsert
        {
            get { return _tglinsert; }
            set { _tglinsert = value; }
        }
        [Column(Name = "PatientPhoto", DataType = "String", IsNullable = true)]
        public String PatientPhoto
        {
            get { return _PatientPhoto; }
            set { _PatientPhoto = value; }
        }
        [Column(Name = "OldNoRM", DataType = "String")]
        public String OldNoRM
        {
            get { return _OldNoRM; }
            set { _OldNoRM = value; }
        }
    }


    public class PasienDao
    {
        private readonly IDbContext _ctx = DbFactory.Configure();
        private readonly DbHelper _helper = new DbHelper(typeof(Pasien));
        private bool _isAuditLog = false;
        private const string p_norm = "@p_norm";

        public PasienDao()
        {
        }

        public PasienDao(IDbContext ctx)
        {
            _ctx = ctx;
        }

        public Pasien Get(String NoRM)
        {
            _ctx.CommandText = _helper.GetRecord();
            _ctx.Add(p_norm, NoRM);
            DataRow row = DaoBase.GetDataRow(_ctx);
            return (row == null) ? null : (Pasien)_helper.DataRowToObject(row, new Pasien());
        }

        public int Insert(Pasien record)
        {
            _helper.Insert(_ctx, record, _isAuditLog);
            return DaoBase.ExecuteNonQuery(_ctx);
        }

        public int Update(Pasien record)
        {
            _helper.Update(_ctx, record, _isAuditLog);
            return DaoBase.ExecuteNonQuery(_ctx, true);
        }

        public int Delete(String NoRM)
        {
            Pasien record;
            if (_ctx.Transaction == null)
                record = new PasienDao().Get(NoRM);
            else
                record = Get(NoRM);
            _helper.Delete(_ctx, record, _isAuditLog);
            return DaoBase.ExecuteNonQuery(_ctx);
        }
    }
    #endregion

    #region setvar
    [Serializable]
    [Table(Name = "setvar")]
    public class SetVar : DbDataModel
    {
        private String _App;
        private String _kode;
        private String _nama;
        private String _nilai;
        private String _ket;
        private Decimal _nourut;
        private Boolean _visible;

        [Column(Name = "APP", DataType = "String", IsPrimaryKey = true)]
        public String App
        {
            get { return _App; }
            set { _App = value; }
        }
        [Column(Name = "kode", DataType = "String", IsPrimaryKey = true)]
        public String Kode
        {
            get { return _kode; }
            set { _kode = value; }
        }
        [Column(Name = "nama", DataType = "String")]
        public String Nama
        {
            get { return _nama; }
            set { _nama = value; }
        }
        [Column(Name = "nilai", DataType = "String")]
        public String Nilai
        {
            get { return _nilai; }
            set { _nilai = value; }
        }
        [Column(Name = "ket", DataType = "String")]
        public String Ket
        {
            get { return _ket; }
            set { _ket = value; }
        }
        [Column(Name = "nourut", DataType = "Decimal")]
        public Decimal NoUrut
        {
            get { return _nourut; }
            set { _nourut = value; }
        }
        [Column(Name = "visible", DataType = "Boolean")]
        public Boolean visible
        {
            get { return _visible; }
            set { _visible = value; }
        }
    }

    public class SetVarDao
    {
        private readonly IDbContext _ctx = DbFactory.Configure();
        private readonly DbHelper _helper = new DbHelper(typeof(SetVar));
        private bool _isAuditLog = false;
        private const string p_AppId = "@p_APP";
        private const string p_Kode = "@p_kode";
        public SetVarDao() { }
        public SetVarDao(IDbContext ctx)
        {
            _ctx = ctx;
        }
        public SetVar Get(String app,String kode)
        {
            _ctx.CommandText = _helper.GetRecord();
            _ctx.Add(p_AppId, app);
            _ctx.Add(p_Kode, kode);
            DataRow row = DaoBase.GetDataRow(_ctx);
            return (row == null) ? null : (SetVar)_helper.DataRowToObject(row, new SetVar());
        }
        public int Insert(SetVar record)
        {
            _helper.Insert(_ctx, record, _isAuditLog);
            return DaoBase.ExecuteNonQuery(_ctx);
        }
        public int Update(SetVar record)
        {
            _helper.Update(_ctx, record, _isAuditLog);
            return DaoBase.ExecuteNonQuery(_ctx, true);
        }
        public int Delete(String app, String kode)
        {
            SetVar record;
            if (_ctx.Transaction == null)
                record = new SetVarDao().Get(app,kode);
            else
                record = Get(app,kode);
            _helper.Delete(_ctx, record, _isAuditLog);
            return DaoBase.ExecuteNonQuery(_ctx);
        }
    }
    #endregion

    #region Report
    [Serializable]
    [Table(Name = "Report")]
    public class Report : DbDataModel
    {
        private String _ReportID;
        private String _ParentReportID;
        private String _ReportCaption;
        private String _Url;
        private String _ReportParameter;
        private String _AppID;
        private String _ReportAsp;
        private String _ReportFIleName;
        private String _ReportSPName;
        private String _ReportFormat;
        private Boolean _isHeader;
        private Boolean _isActive;
        private String _Description;
        private DateTime _PublishDate;

        [Column(Name = "ReportId", DataType = "String", IsPrimaryKey = true)]
        public String ReportID
        {
            get { return _ReportID; }
            set { _ReportID = value; }
        }
        [Column(Name = "ParentReportID", DataType = "String", IsNullable = true)]
        public String ParentReportID
        {
            get { return _ParentReportID; }
            set { _ParentReportID = value; }
        }
        [Column(Name = "ReportCaption", DataType = "String")]
        public String ReportCaption
        {
            get { return _ReportCaption; }
            set { _ReportCaption = value; }
        }
        [Column(Name = "Url", DataType = "String")]
        public String Url
        {
            get { return _Url; }
            set { _Url = value; }
        }

        [Column(Name = "ReportParameter", DataType = "String")]
        public String ReportParameter
        {
            get { return _ReportParameter; }
            set { _ReportParameter = value; }
        }

        [Column(Name = "AppID", DataType = "String")]
        public String AppID
        {
            get { return _AppID; }
            set { _AppID = value; }
        }
        [Column(Name = "ReportAsp", DataType = "String")]
        public String ReportAsp
        {
            get { return _ReportAsp; }
            set { _ReportAsp = value; }
        }

        [Column(Name = "ReportFIleName", DataType = "String")]
        public String ReportFIleName
        {
            get { return _ReportFIleName; }
            set { _ReportFIleName = value; }
        }

        [Column(Name = "ReportSPName", DataType = "String")]
        public String ReportSPName
        {
            get { return _ReportSPName; }
            set { _ReportSPName = value; }
        }

        [Column(Name = "ReportFormat", DataType = "String")]
        public String ReportFormat
        {
            get { return _ReportFormat; }
            set { _ReportFormat = value; }
        }

        [Column(Name = "isHeader", DataType = "Boolean")]
        public Boolean IsHeader
        {
            get { return _isHeader; }
            set { _isHeader = value; }
        }

        [Column(Name = "isActive", DataType = "Boolean")]
        public Boolean IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        [Column(Name = "Description", DataType = "String", IsNullable = true)]
        public String Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        [Column(Name = "PublishDate", DataType = "DateTime")]
        public DateTime PublishDate
        {
            get { return _PublishDate; }
            set { _PublishDate = value; }
        }
    }

    public class ReportDao
    {
        private readonly IDbContext _ctx = DbFactory.Configure();
        private readonly DbHelper _helper = new DbHelper(typeof(Report));
        private bool _isAuditLog = false;
        private const string p_ReportID = "@p_ReportID";
        public ReportDao() { }
        public ReportDao(IDbContext ctx)
        {
            _ctx = ctx;
        }
        public Report Get(String reportID)
        {
            _ctx.CommandText = _helper.GetRecord();
            _ctx.Add(p_ReportID, reportID);
            DataRow row = DaoBase.GetDataRow(_ctx);
            return (row == null) ? null : (Report)_helper.DataRowToObject(row, new Report());
        }
        public int Insert(Report record)
        {
            _helper.Insert(_ctx, record, _isAuditLog);
            return DaoBase.ExecuteNonQuery(_ctx);
        }
        public int Update(Report record)
        {
            _helper.Update(_ctx, record, _isAuditLog);
            return DaoBase.ExecuteNonQuery(_ctx, true);
        }
        public int Delete(String reportID)
        {
            Report record;
            if (_ctx.Transaction == null)
                record = new ReportDao().Get(reportID);
            else
                record = Get(reportID);
            _helper.Delete(_ctx, record, _isAuditLog);
            return DaoBase.ExecuteNonQuery(_ctx);
        }
    }
    #endregion

    #region ReportParameterLabel
    [Serializable]
    [Table(Name = "ReportParameterLabel")]
    public class ReportParameterLabel : DbDataModel
    {
        private Int32 _ID;
        private String _ParameterName;
        private String _ParameterLabel;
        private Boolean _IsDate;

        [Column(Name = "ID", DataType = "Int32", IsIdentity=true, IsPrimaryKey = true)]
        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        [Column(Name = "ParameterName", DataType = "String")]
        public String ParameterName
        {
            get { return _ParameterName; }
            set { _ParameterName = value; }
        }
        [Column(Name = "ParameterLabel", DataType = "String")]
        public String ParameterLabel
        {
            get { return _ParameterLabel; }
            set { _ParameterLabel = value; }
        }
        [Column(Name = "IsDate", DataType = "Boolean")]
        public Boolean IsDate
        {
            get { return _IsDate; }
            set { _IsDate = value; }
        }
    }

    public class ReportParameterLabelDao
    {
        private readonly IDbContext _ctx = DbFactory.Configure();
        private readonly DbHelper _helper = new DbHelper(typeof(ReportParameterLabel));
        private bool _isAuditLog = false;
        private const string p_Id = "@p_ID";
        public ReportParameterLabelDao() { }
        public ReportParameterLabelDao(IDbContext ctx)
        {
            _ctx = ctx;
        }
        public ReportParameterLabel Get(Int32 id)
        {
            _ctx.CommandText = _helper.GetRecord();
            _ctx.Add(p_Id, id);
            DataRow row = DaoBase.GetDataRow(_ctx);
            return (row == null) ? null : (ReportParameterLabel)_helper.DataRowToObject(row, new ReportParameterLabel());
        }
        public int Insert(ReportParameterLabel record)
        {
            _helper.Insert(_ctx, record, _isAuditLog);
            return DaoBase.ExecuteNonQuery(_ctx);
        }
        public int Update(ReportParameterLabel record)
        {
            _helper.Update(_ctx, record, _isAuditLog);
            return DaoBase.ExecuteNonQuery(_ctx, true);
        }
        public int Delete(Int32 id)
        {
            ReportParameterLabel record;
            if (_ctx.Transaction == null)
                record = new ReportParameterLabelDao().Get(id);
            else
                record = Get(id);
            _helper.Delete(_ctx, record, _isAuditLog);
            return DaoBase.ExecuteNonQuery(_ctx);
        }
    }
    #endregion

    #region Tools
    #region SysColumns
    [Serializable]
    [Table(Name = "Sys.columns")]
    public class SysColumns : DbDataModel
    {
        private String _Name;
        private Int32 _UserTypeID;
        private Boolean _IsNullable;
        private Boolean _IsIdentity;

        [Column(Name = "name", DataType = "String")]
        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        [Column(Name = "user_type_id", DataType = "String")]
        public Int32 UserTypeID
        {
            get { return _UserTypeID; }
            set { _UserTypeID = value; }
        }

        [Column(Name = "is_nullable", DataType = "Boolean")]
        public Boolean IsNullable
        {
            get { return _IsNullable; }
            set { _IsNullable = value; }
        }

        [Column(Name = "is_identity", DataType = "Boolean")]
        public Boolean IsIdentity
        {
            get { return _IsIdentity; }
            set { _IsIdentity = value; }
        }

        public String Type
        {
            get
            {
                switch (_UserTypeID)
                {
                    case 48: return "Int16";
                    case 56: return "Int32";
                    case 104: return "Boolean";
                    case 61:
                    case 40: return "DateTime";
                    case 62: return "Double";
                    case 108:
                    case 60: return "Decimal";
                    case 52: return "Int16";
                    case 127: return "Int64";
                }
                return "String";
            }
        }
    }
    #endregion
    #region SysObjects
    [Serializable]
    [Table(Name = "Sys.objects")]
    public class SysObjects : DbDataModel
    {
        private String _Name;
        private Double _ObjectID;

        [Column(Name = "name", DataType = "String")]
        public String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        [Column(Name = "object_id", DataType = "Double")]
        public Double ObjectID
        {
            get { return _ObjectID; }
            set { _ObjectID = value; }
        }
    }
    #endregion
    #endregion
}
