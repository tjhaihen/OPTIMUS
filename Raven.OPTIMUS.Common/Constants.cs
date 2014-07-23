using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raven.OPTIMUS.Common
{
    public static class Constants
    {
        public static class ModuleID
        {
            public const string SYSTEM_SETUP = "RS_";
            public const string EMERGENCY_CARE = "RD_";
        }

        public static class ModuleName
        {
            public const string SYSTEM_SETUP = "systemsetup";
            public const string EMERGENCY_CARE = "emergencycare";
            public const string OUTPATIENT = "outpatient";
            public const string INPATIENT = "inpatient";
            public const string pharmacy = "pharmacy";
        }

        public static class TransactionCode
        {
            public const string REGISTRASI_RAWAT_DARURAT = "102";
            public const string TRANSAKSI_RAWAT_DARURAT = "103";
            public const string ORDER_PENUNJANG_MEDIS_PASIEN_RD = "104";
            public const string PEMBAYARAN_PASIEN_TUNAI_RD = "105";
            public const string PEMBAYARAN_PASIEN_PIUTANG_PRIBADI_RD = "106";
            public const string PEMBAYARAN_PASIEN_PIUTANG_INSTANSI_RD = "107";
            public const string PEMBAYARAN_PASIEN_HONOR_DOKTER_RD = "108";

            public const string APPOINTMENT_RAWAT_JALAN = "201";
            public const string REGISTRASI_RAWAT_JALAN = "202";
            public const string TRANSAKSI_RAWAT_JALAN = "203";
            public const string ORDER_PENUNJANG_MEDIS_PASIEN_RJ = "204";
            public const string PEMBAYARAN_PASIEN_TUNAI_RJ = "205";
            public const string PEMBAYARAN_PASIEN_PIUTANG_PRIBADI_RJ = "206";
            public const string PEMBAYARAN_PASIEN_PIUTANG_INSTANSI_RJ = "207";
            public const string PEMBAYARAN_PASIEN_HONOR_DOKTER_RJ = "208";

            public const string RESERVASI_TEMPAT_TIDUR = "301";
            public const string REGISTRASI_RAWAT_INAP = "302";
            public const string TRANSAKSI_RAWAT_INAP = "303";
            public const string ORDER_PENUNJANG_MEDIS_PASIEN_RI = "304";
            public const string PEMBAYARAN_PASIEN_TUNAI_RI = "305";
            public const string PEMBAYARAN_PASIEN_PIUTANG_PRIBADI_RI = "306";
            public const string PEMBAYARAN_PASIEN_PIUTANG_INSTANSI_RI = "307";

            public const string PENDAFTARAN_PASIEN_LANGSUNG_PENUNJANG_MEDIS = "401";
            public const string TRANSAKSI_PENUNJANG_MEDIS_PASIEN_RAWAT_DARURAT = "402";
            public const string TRANSAKSI_PENUNJANG_MEDIS_PASIEN_RAWAT_JALAN = "403";
            public const string TRANSAKSI_PENUNJANG_MEDIS_PASIEN_RAWAT_INAP = "404";
            public const string TRANSAKSI_PENUNJANG_MEDIS_PASIEN_LANGSUNG = "405";
            public const string PENERIMAAN_PEMBAYARAN_PASIEN_LANGSUNG = "406";

            public const string PENDAFTARAN_PASIEN_LANGSUNG_LABORATORIUM = "501";
            public const string TRANSAKSI_LABORATORIUM_PASIEN_RAWAT_DARURAT = "502";
            public const string TRANSAKSI_LABORATORIUM_PASIEN_RAWAT_JALAN = "503";
            public const string TRANSAKSI_LABORATORIUM_PASIEN_RAWAT_INAP = "504";
            public const string TRANSAKSI_LABORATORIUM_PASIEN_LANGSUNG = "505";
            public const string PENERIMAAN_PEMBAYARAN_PASIEN_LANGSUNG_LABORATORIUM = "506";

            public const string PERJANJIAN_PASIEN_MEDICAL_CHECKUP = "601";
            public const string PENDAFTARAN_PASIEN_MCU = "602";
            public const string TRANSAKSI_MEDICAL_CHECKUP = "603";
            public const string PENERIMAAN_PEMBAYARAN_MEDICAL_CHECKUP = "604";

            public const string PENJUALAN_RESEP_PASIEN_LANGSUNG = "701";
            public const string PENJUALAN_RESEP_RAWAT_DARURAT = "702";
            public const string PENJUALAN_RESEP_RAWAT_JALAN = "703";
            public const string PENJUALAN_RESEP_RAWAT_INAP = "704";
            public const string RETUR_PENJUALAN_RESEP_PASIEN_LANGSUNG = "705";
            public const string RETUR_PENJUALAN_RESEP_RAWAT_DARURAT = "706";
            public const string RETUR_PENJUALAN_RESEP_RAWAT_JALAN = "707";
            public const string RETUR_PENJUALAN_RESEP_RAWAT_INAP = "708";
            public const string PENERIMAAN_PEMBAYARAN_RESEP_PASIEN_LANGSUNG = "709";

        }

        public static class StandardCode
        { 
        }
        public static class SettingParameter
        {
            public const string PEMBULATAN = "pbulat";
            public const string TARIF_CITO = "trfcito";
            public const string TARIF_PENYULIT = "trfsulit";
            public const string JENIS_PENGIRIM_SENDIRI = "jnpgrmsndr";
            public const string KODE_INSTANSI_RS = "kdinstansi";

            public const string RS_Kode_Penjamin_Instansi = "kdjmbayarins";
            public const string KODE_PENJAMIN_PRIBADI = "kdjmbayarpbd";

            public const string RD_Adm = "Adm";
            public const string RD_Kode_Kelas = "kdkelasrd";
            public const string RD_Kode_Pelayanan = "kdlayan";
            public const string RD_Kode_Pelayanan_Adm = "kdlayanAdm";
            public const string RD_Kode_Pelayanan_Kartu = "kdlayankartu";

        }
        public static class ConstantDate
        {
            public const String DEFAULT_NULL= "01-01-1900";
            public const String DEFAULT_FORMAT = "dd-MM-yyyy";
            public const string DATE_FORMAT_1 = "dd-MMM-yyyy";
            public const string DATE_FORMAT_2 = "yyyyMMdd";
        }

        public static class MaskFormat
        {
            public const string TIME_MASK = "99:99";
        }
    }
}
