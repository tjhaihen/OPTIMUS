using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

namespace OPTIMUSReport
{
    public class BaseRpt : XtraReport
    {
        public virtual void InitReport(string reportID, string[] param, string showCriteria) { }
    }
}
