using System;

namespace XApp.Commons.DataAccess.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DbColumnAttribute : Attribute
    {
        public enum ColumnConversionHints
        {
            None,
            ToListByPipe
        }

        public string ColumnName { get; set; }

        public ColumnConversionHints ColumnConversionHint { get; set; }

        public DbColumnAttribute(string columnName, ColumnConversionHints columnConversionHint = ColumnConversionHints.None)
        {
            ColumnName = columnName;
            ColumnConversionHint = columnConversionHint;
        }
    }
}
