using System;
using System.Collections.Generic;
using System.Text;

namespace Raven.Data.Core.Dal
{
    public class DbFieldValue
    {
        private readonly string fieldName;
        private readonly object original;
        private readonly object current;
        private readonly bool isKey;
        private readonly bool isGenerated;

        public DbFieldValue(string fieldName, object current)
            : this(fieldName, null, current, false, false)
        {
        }

        public DbFieldValue(string fieldName, object current, bool isKey)
            : this(fieldName, null, current, isKey, false)
        {
        }

        public DbFieldValue(string fieldName, object current, bool isKey, bool isGenerated)
            : this(fieldName, null, current, isKey, isGenerated)
        {
        }

        public DbFieldValue(string fieldName, object original, object current)
            : this(fieldName, original, current, false, false)
        {
        }

        public DbFieldValue(string fieldName, object original, object current, bool isKey, bool isGenerated)
        {
            this.fieldName = fieldName;
            this.original = original;
            this.current = current;
            this.isKey = isKey;
            this.isGenerated = isGenerated;
        }

        public string FieldName
        {
            get { return fieldName; }
        }

        public object Original
        {
            get { return original; }
        }

        public object Current
        {
            get { return current; }
        }

        public bool IsKey
        {
            get { return isKey; }
        }

        public bool IsGenerated
        {
            get { return isGenerated; }
        }
    }
}
