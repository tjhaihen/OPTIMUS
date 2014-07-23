using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raven.OPTIMUS.Common
{
    public static class ApplicationSetting
    {
        private static double _tariffCITO;
        public static double TariffCITO
        {
            get { return _tariffCITO; }
            set { _tariffCITO = value; }
        }

        private static double _tariffPenyulit;
        public static double TariffPenyulit
        {
            get { return _tariffPenyulit; }
            set { _tariffPenyulit = value; }
        }

        private static double _pembulatan;
        public static double Pembulatan
        {
            get { return _pembulatan; }
            set { _pembulatan = value; }
        }

        private static string _kodeInstansiRS = string.Empty;
        public static string KodeInstansiRS
        {
            get { return ApplicationSetting._kodeInstansiRS; }
            set { ApplicationSetting._kodeInstansiRS = value; }
        }

        private static string _kodePenjaminPribadi = string.Empty;
        public static string KodePenjaminPribadi
        {
            get { return ApplicationSetting._kodePenjaminPribadi; }
            set { ApplicationSetting._kodePenjaminPribadi = value; }
        }

        private static string _kodePenjaminInstansi = string.Empty;
        public static string KodePenjaminInstansi
        {
            get { return ApplicationSetting._kodePenjaminInstansi; }
            set { ApplicationSetting._kodePenjaminInstansi = value; }
        }

        private static string _kodeLayanAdm = string.Empty;
        public static string KodeLayanAdm
        {
            get { return ApplicationSetting._kodeLayanAdm; }
            set { ApplicationSetting._kodeLayanAdm = value; }
        }

        private static string _jenisPengirimSendiri = string.Empty;
        public static string JenisPengirimSendiri
        {
            get { return ApplicationSetting._jenisPengirimSendiri; }
            set { ApplicationSetting._jenisPengirimSendiri = value; }
        }
    }
}
