using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raven.OPTIMUS.Web.CustomControl
{
    public class RavenIntellisenseHint
    {
        #region DataMembers

        string _Text = string.Empty;
        string _FieldName = string.Empty;
        string _Description = string.Empty;

        #endregion

        #region Public Propeties

        [NotifyParentProperty(true)]
        [Description("Name of the FieldName")]
        public string Text
        {
            get { return (_Text != null) ? _Text : string.Empty; }
            set { _Text = value; }
        }

        [NotifyParentProperty(true)]
        [Description("Name of the FieldName")]
        public string FieldName
        {
            get { return (_FieldName != null) ? _FieldName : string.Empty; }
            set { _FieldName = value; }
        }

        [NotifyParentProperty(true)]
        [Description("Name of the FieldName")]
        public string Description
        {
            get { return (_Description != null) ? _Description : string.Empty; }
            set { _Description = value; }
        }

        #endregion
    }
}