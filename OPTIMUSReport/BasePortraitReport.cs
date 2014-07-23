using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using Raven.OPTIMUS.Data.Service;
using System.Collections.Generic;
using System.Reflection;
using DevExpress.XtraReports.UI;
using System.Text;
using System.Linq;

namespace OPTIMUSReport
{
    public partial class BasePortraitReport : BaseRpt
    {
        public BasePortraitReport()
        {
            InitializeComponent();
        }

        public override void InitReport(string reportID, string[] param, string showCriteria)
        {
            Report oReport = BusinessLayer.GetReport(reportID);

            if (oReport != null)
            {
                string[] parameterField = oReport.ReportParameter.Split('|');
                string[] reportMethod = oReport.ReportSPName.Split('|'); // element 0 : method name ; element 1 : additional filterExpression

                this.BeginUpdate();
                //Report Information
                string[] description = oReport.Description.Split('|');
                lblTitle.Text = description[0].ToUpper();
                lblSubTitle.Text = description[1];
                lblReportProperties.Text = string.Format("OPTIMUS - {0}, Print Date/Time:{1}, User ID:{2}", oReport.ReportID, DateTime.Now.ToString("dd-MMM-yyyy/HH:mm:ss"), "admin");

                //Healthcare Information
                vHealthcare oHealthcare = BusinessLayer.GetvHealthcareList(string.Empty)[0];
                if (oHealthcare != null)
                {
                    lblHealthcareName.Text = oHealthcare.HealthcareName;
                    lblAddressLine1.Text = oHealthcare.AddressLine1;
                    lblAddressLine2.Text = oHealthcare.AddressLine2;
                    lblPhoneFaxNo.Text = string.Format("Phone/Fax : {0}", string.IsNullOrEmpty(oHealthcare.FaxNo1) ? oHealthcare.PhoneNo1 : string.Format("{0}/{1}", oHealthcare.PhoneNo1, oHealthcare.FaxNo1));
                }

                string filterExpression;
                if (param.Length == 1 && string.IsNullOrEmpty(param[0].Trim()))
                    filterExpression = string.Empty;
                else
                    filterExpression = BuildFilterExpression(parameterField, param, reportMethod[1]);

                if (oReport.ReportAsp != "SP")
                    RefreshDataBindings(reportMethod[0], filterExpression);
                else
                    RefreshDataBindings(reportMethod[0], parameterField, param);


                //Display Report Criteria Option
                this.ReportFooter.Visible = showCriteria == "1";
                if (this.ReportFooter.Visible)
                {
                    SetReportParameter(parameterField, param);
                }
                this.EndUpdate();
            }
        }

        private void RefreshDataBindings(string methodName, string[] parameterField, string[] param)
        {
            MethodInfo method = typeof(BusinessLayer).GetMethod(methodName, new[] { typeof(string[]),typeof(string[]) });
            object obj = method.Invoke(null,  new string[][] {parameterField,param} );
            this.odsDataSource.DataSource = obj;
            this.Report.DataSource = odsDataSource;

            //DataTable dtbReport = BusinessLayer.GetDataReport(procedureName, parameterField, param);
            //this.odsDataSource.DataSource = dtbReport;
            //this.Report.DataSource = odsDataSource;
        }

        private string BuildFilterExpression(string[] parameterField, string[] param, string additionalExpression)
        {
            string result = string.Empty;
            int count = parameterField.Length;
            string expression;

            for (int i = 0; i < count; i++)
            {
                string fieldPrefix = parameterField[i].Substring(0, 1);
                string fieldOperator = GenerateParameterOperator(fieldPrefix);
                if (fieldPrefix == "i")
                {
                    string[] splitParam = param[i].Split(',');
                    StringBuilder strbuild = new StringBuilder();
                    foreach (string str in splitParam)
                    {
                        if (strbuild.ToString() != string.Empty)
                            strbuild.Append(",");
                        strbuild.Append(string.Format("'{0}'", str));
                    }
                    expression = string.Format("{0} {1} ({2}) ", parameterField[i].Substring(1), fieldOperator, strbuild.ToString());
                }
                else
                    expression = string.Format("{0} {1} '{2}' ", parameterField[i].Substring(1), fieldOperator, param[i]);
                result = string.IsNullOrEmpty(result) ? string.Format("{0}", expression) : string.Format(" {0} AND {1}", result, expression);
            }
            if (!string.IsNullOrEmpty(additionalExpression))
            {
                result = string.IsNullOrEmpty(result) ? string.Format("{0}", additionalExpression) : string.Format("{0} AND {1}", result, additionalExpression);
            }
            return result;            
        }

        private void RefreshDataBindings(string methodName, string filterExpression = "")
        {
            MethodInfo method = typeof(BusinessLayer).GetMethod(methodName, new[] { typeof(string) });
            object obj = method.Invoke(null, new string[] { filterExpression });
            this.odsDataSource.DataSource = obj;
            this.Report.DataSource = odsDataSource;
        }

        private void SetReportParameter(string[] parameterField, string[] param)
        {
            if (parameterField.Length == 1 && string.IsNullOrEmpty(parameterField[0].Trim()))
                return;

            if (parameterField.Length > 0)
            {
                StringBuilder filterExpression = new StringBuilder();
                filterExpression.Append("ParameterName IN (");
                for (int i = 0; i < parameterField.Length; i++)
                {
                    filterExpression.AppendLine(string.Format("'{0}',", parameterField[i]));
                }
                filterExpression.AppendLine(string.Format("'{0}')", parameterField[parameterField.Length - 1]));
                IEnumerable<ReportParameterLabel> listReportParam = BusinessLayer.GetReportParameterLabelList(filterExpression.ToString()).AsEnumerable<ReportParameterLabel>();

                lblReportCriteria.Visible = true;
                for (int i = 0; i < parameterField.Length; i++)
                {
                    FormatReportParameter((i + 1).ToString(), parameterField[i], param[i], listReportParam);
                }
            }
        }

        private void FormatReportParameter(string parameterNo, string parameterField, string parameterValue, IEnumerable<ReportParameterLabel> lstParamLabel)
        {
            XRControl lblParameter = this.ReportFooter.FindControl(string.Format("lblParameter{0}", parameterNo), true);
            string parameterCaption = parameterField.Substring(1);
            string fieldPrefix = parameterField.Substring(0, 1);
            ReportParameterLabel paramLabel = lstParamLabel.Where(lst => lst.ParameterName.Equals(parameterField)).FirstOrDefault();
            if (paramLabel != null)
                parameterCaption = paramLabel.ParameterLabel;

            if (lblParameter != null)
            {
                lblParameter.Visible = true;
                if (fieldPrefix == "i")
                    lblParameter.Text = string.Format("{0} {1} ({2})", parameterCaption, GenerateParameterOperator(fieldPrefix), DisplayFormat(paramLabel, parameterValue));
                else
                    lblParameter.Text = string.Format("{0} {1} {2}", parameterCaption, GenerateParameterOperator(fieldPrefix), DisplayFormat(paramLabel, parameterValue));
            }
        }

        private string DisplayFormat(ReportParameterLabel paramLabel, string parameterValue)
        {
            if (paramLabel.IsDate)
            {
                return DateTime.ParseExact(parameterValue, Constant.ConstantDate.DATE_FORMAT_2, null).ToString(Constant.ConstantDate.DATE_FORMAT_1);
            }
            else
                return parameterValue;
        }

        private string GenerateParameterOperator(string fieldPrefix)
        {
            switch (fieldPrefix)
            {
                case "s":
                    return ">=";
                case "e":
                    return "<=";
                case "i":
                    return "IN";
                case "l":
                    return "LIKE";
                default:
                    return "=";
            }
        }
    }
}
