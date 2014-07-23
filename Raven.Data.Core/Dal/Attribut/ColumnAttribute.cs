using System;

namespace Raven.Data.Core.Dal
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ColumnAttribute : Attribute
    {
        private string _name;
        private bool _isPrimaryKey;
        private bool _isIdentity;
        private bool _isTimeStamp; 
        private bool _isNullable;
        private bool _isComputed;
        private string _dataType;
        private int _gridColumWidth;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool IsPrimaryKey
        {
            get { return _isPrimaryKey; }
            set { _isPrimaryKey = value; }
        }

        public bool IsIdentity
        {
            get { return _isIdentity; }
            set { _isIdentity = value; }
        }
        public bool IsTimeStamp
        {
            get { return _isTimeStamp; }
            set { _isTimeStamp = value; }
        }

        public bool IsNullable
        {
            get { return _isNullable; }
            set { _isNullable = value; }
        }

        public bool IsComputed
        {
            get { return _isComputed; }
            set { _isComputed = value; }
        }

        public string DataType
        {
            get { return _dataType; }
            set { _dataType = value; }
        }

        public int GridColumnWidth
        {
            get { return _gridColumWidth; }
            set { _gridColumWidth = value; }
        }
    }
}
