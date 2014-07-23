using System;
using System.Collections.Generic;
using System.Text;

namespace Raven.Data.Core.Dal
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class TableAttribute : Attribute
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
