using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Raven.OPTIMUS.Web.CustomControl
{
    public class RavenIntellisenseTextBoxClientSideEvent
    {
        private String _SearchClick;
        private String _Init;

        [Category("Layout")]
        [NotifyParentProperty(true)]
        [Description("TableItem_HorizontalAlign")]
        public String SearchClick
        {
            get { return _SearchClick; }
            set { _SearchClick = value; }
        }

        [Category("Layout")]
        [NotifyParentProperty(true)]
        [Description("TableItem_HorizontalAlign")]
        public String Init
        {
            get { return _Init; }
            set { _Init = value; }
        }
    }
}
