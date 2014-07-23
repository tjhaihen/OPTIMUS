using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace Raven.OPTIMUS.Web.CustomControl
{
    public class RavenIntellisenseTextBox : WebControl
    {
        HtmlGenericControl divIntellisense = new HtmlGenericControl("div");
        HtmlInputText txtSearch = new HtmlInputText();
        private List<RavenIntellisenseHint> _IntellisenseHints = new List<RavenIntellisenseHint>();
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<RavenIntellisenseHint> IntellisenseHints
        {
            get { return _IntellisenseHints; }
            set { _IntellisenseHints = value; }
        }

        public String GenerateFilterExpression()
        {
            String[] textValue = txtSearch.Value.Split(';');
            int i = 0;
            StringBuilder result = new StringBuilder();
            while (true)
            {
                if (i == textValue.Length || i == IntellisenseHints.Count)
                    break;
                if (textValue[i] != "*")
                {
                    if (result.ToString() != "")
                        result.Append(" AND ");
                    result.Append(IntellisenseHints[i].FieldName).Append(" LIKE '%").Append(textValue[i]).Append("%'");
                }
                i++;
            }
            return result.ToString();
        }

        public String Text
        {
            get { return txtSearch.Value; }
            set { txtSearch.Value = value; }
        }

        public String Value
        {
            get { return txtSearch.Value; }
            set { txtSearch.Value = value; }
        }

        //public Boolean AutoPostBack { get; set; }

        RavenIntellisenseTextBoxClientSideEvent _ClientSideEvents = new RavenIntellisenseTextBoxClientSideEvent();
        [DefaultValue("")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Category("Styles")]
        [Description("DataControlField_HeaderStyle")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RavenIntellisenseTextBoxClientSideEvent ClientSideEvents
        {
            get { return _ClientSideEvents; }
            set { _ClientSideEvents = value; }
        }

        public string ClientInstanceName { get; set; }
        public string Watermark { get; set; }


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            #region Create Control



            Control currControl = this;
            //string name = currControl.UniqueID;

            //string SaveState = Page.Request.Form[name + "_updPnlGridView$hdnSaveState"] ?? "";
            //if (SaveState != "")
            //{
            //    string[] param = SaveState.Split('|');
            //    DataSourceBusinessLayer.FilterExpression = param[0];
            //    DataSourceBusinessLayer.IsFilterExpressionChanged = (param[1] == "1");
            //}

            divIntellisense.ID = this.ID + "_divIntellisense";
            divIntellisense.Attributes.Add("class", "containerIntellisense");

            #region Text Search
            HtmlTable tbl = new HtmlTable();
            tbl.Attributes.Add("style", string.Format("height:24px;width:{0};border-collapse:collapse;", Width));
            tbl.Attributes.Add("class", "dxeTextBoxSys dxeTextBox_Metro");
            tbl.CellPadding = 0;
            tbl.CellSpacing = 0;

            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell cell = new HtmlTableCell();
            cell.Attributes.Add("style", "width: 100%");
            cell.Attributes.Add("class", "dxic");

            HtmlGenericControl divInput = new HtmlGenericControl("div");
            divInput.Attributes.Add("style", "position:relative;height:20px");

            txtSearch.Attributes.Add("autocomplete", "off");
            txtSearch.Attributes.Add("watermark", Watermark);
            txtSearch.Attributes.Add("class", "dxeEditArea_Metro dxeEditAreaSys txtIntellisense");
            txtSearch.Attributes.Add("style", "font-family:Calibri;font-size:9pt;margin-left:1px;margin-right:1px;margin-top:1px;margin-bottom:2px;color:Black;");

            HtmlImage imgSearch = new HtmlImage();
            imgSearch.Attributes.Add("style", "position:absolute;cursor:pointer;top:-2px;right:-2px;z-index:1100;");
            imgSearch.Alt = "S";
            imgSearch.Attributes.Add("class", "imgSearch");
            imgSearch.Src = "/PureravensLib/Images/QuickSearchIcon.png";
            //if (_ClientSideEvents.SearchClick != "")
            //    imgSearch.Attributes.Add("onclick", string.Format("{0}({1});", _ClientSideEvents.SearchClick, ClientInstanceName));

            divInput.Controls.Add(txtSearch);
            divInput.Controls.Add(imgSearch);
            cell.Controls.Add(divInput);
            row.Cells.Add(cell);
            tbl.Rows.Add(row);

            divIntellisense.Controls.Add(tbl);
            #endregion

            #region Intellisense Box
            HtmlGenericControl divIntellisenseBox = new HtmlGenericControl("div");
            divIntellisenseBox.Attributes.Add("class", "intellisenseBox");

            HtmlGenericControl divIntellisenseContent = new HtmlGenericControl("div");
            divIntellisenseContent.Attributes.Add("class", "intellisenseContent");

            HtmlGenericControl spanIntellisenseContentInfo = new HtmlGenericControl("span");
            spanIntellisenseContentInfo.Attributes.Add("class", "intellisenseContentInfo");

            HtmlImage imgUp = new HtmlImage();
            imgUp.Src = "/PureravensLib/Images/up-arrow.png";
            imgUp.Attributes.Add("class", "imgUp");

            HtmlGenericControl contentText = new HtmlGenericControl("span");
            contentText.Attributes.Add("class", "contentText");

            HtmlImage imgDown = new HtmlImage();
            imgDown.Src = "/PureravensLib/Images/down-arrow.png";
            imgDown.Attributes.Add("class", "imgDown");

            spanIntellisenseContentInfo.Controls.Add(imgUp);
            spanIntellisenseContentInfo.Controls.Add(contentText);
            spanIntellisenseContentInfo.Controls.Add(imgDown);

            HtmlGenericControl divIntellisenseContentText = new HtmlGenericControl("div");
            divIntellisenseContentText.Attributes.Add("class", "intellisenseContentText");

            HtmlGenericControl divIntellisenseDescription = new HtmlGenericControl("div");
            divIntellisenseDescription.Attributes.Add("class", "intellisenseDescription");

            divIntellisenseContent.Controls.Add(spanIntellisenseContentInfo);
            divIntellisenseContent.Controls.Add(divIntellisenseContentText);
            divIntellisenseContent.Controls.Add(divIntellisenseDescription);

            divIntellisenseBox.Controls.Add(divIntellisenseContent);
            divIntellisense.Controls.Add(divIntellisenseBox);
            #endregion

            currControl.Controls.Add(divIntellisense);
            #endregion

            //if (SaveState == "")
            RegisterJavaScript();
        }

        private void SaveDataSourceState()
        {
            //StringBuilder saveState = new StringBuilder();
            //saveState.Append(DataSourceBusinessLayer.FilterExpression).Append("|");
            //if (DataSourceBusinessLayer.IsFilterExpressionChanged)
            //    saveState.Append("1");
            //else
            //    saveState.Append("0");
            //hdnSaveState.Value = saveState.ToString();
        }

        private void RegisterJavaScript()
        {
            WebControl script = new WebControl(HtmlTextWriterTag.Script);
            divIntellisense.Controls.Add(script);
            script.Attributes["id"] = string.Format("dxss_{0}", this.ClientID);
            script.Attributes["type"] = "text/javascript";

            if (_ClientSideEvents.SearchClick == "")
                _ClientSideEvents.SearchClick = "function(s){}";
            script.Controls.Add(new LiteralControl("$(function () {"));
            script.Controls.Add(new LiteralControl(string.Format("var {0}_hints = [];", this.ClientID)));
            foreach (RavenIntellisenseHint hint in IntellisenseHints)
            {
                script.Controls.Add(new LiteralControl(string.Format("{0}_hints.push({{ 'text':'{1}','fieldName':'{2}','description':'{3}' }});", this.ClientID, hint.Text, hint.FieldName, hint.Description)));
            }

            script.Controls.Add(new LiteralControl(string.Format("window.{0} = new RavenClientIntellisenseTextBox();", ClientInstanceName)));
            script.Controls.Add(new LiteralControl(string.Format("{0}.init('{1}', {1}_hints);", ClientInstanceName, this.ClientID)));

            script.Controls.Add(new LiteralControl(string.Format("window.{0}Helper = new RavenClientIntellisenseTextBoxHelper();", this.ClientID)));
            script.Controls.Add(new LiteralControl(string.Format("{0}Helper.setParam({1},{2});", this.ClientID, ClientInstanceName, _ClientSideEvents.SearchClick)));
            script.Controls.Add(new LiteralControl(string.Format("{0}Helper.init('{0}', {0}_hints);", this.ClientID)));
            script.Controls.Add(new LiteralControl("});"));
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
        }
    }

}