using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Raven.Data.Core.Dal
{
    public abstract class DbDataModel
    {
        private Hashtable hash;

        public Hashtable OriginalValue
        {
            get { return hash; }
            set { hash = value; }
        }
    }
}
