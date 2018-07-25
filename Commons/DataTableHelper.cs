using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace Commons
{
    public static class DataTableHelper
    {
        public static DataTable TableDataToString( this DataTable table )
        {
            DataTable clonedDT = table.Clone();
            for (int i = 0; i < clonedDT.Columns.Count; i++)
            {
                if (clonedDT.Columns[i].DataType != typeof(string))
                    clonedDT.Columns[i].DataType = typeof(string);
            }

            foreach (DataRow row in table.Rows)
            {
                clonedDT.ImportRow(row);
            }
            return clonedDT;
        }

        public static DataTable BuildDataTable<T>( IList<T> lst )
        {
            DataTable tbl = CreateTable<T>();
            Type entType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entType);

            foreach (T item in lst)
            {
                DataRow row = tbl.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }
                tbl.Rows.Add(row);
            }
            return tbl;
        }

        private static DataTable CreateTable<T>()
        {
            Type entType = typeof(T);
            DataTable tbl = new DataTable(entType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entType);

            foreach (PropertyDescriptor prop in properties)
            {
                tbl.Columns.Add(prop.Name, prop.PropertyType);
            }
            return tbl;
        }
    }
}
