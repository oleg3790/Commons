using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace XApp.Commons
{
    public static class DataTableHelper
    {
        public static DataTable TableDataToString(this DataTable table)
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

        /// <summary>
        /// Determines if 2 DataTables contain differences in rows and adds an additional column to both DataTables, denoting the row difference
        /// </summary>
        /// <returns></returns>
        public static bool GetTableRowDeltas(ref DataTable source1, ref DataTable source2, bool addDifferenceColumn)
        {
            string differenceColumnName = "IN_SISTER_TABLE";

            if (addDifferenceColumn)
            {
                source1.Columns.Add(differenceColumnName);
                source1 = source1.SetColumnToSingleValue(differenceColumnName, 1);                                
                source2.Columns.Add(differenceColumnName);
                source2 = source2.SetColumnToSingleValue(differenceColumnName, 1);
            }

            bool doesTable1ContainDeltas = false;

            foreach (DataRow item1Row in source1.Rows)
            {
                if (source2.AsEnumerable().Select(y => y.ItemArray).Any(x => Enumerable.SequenceEqual(x, item1Row.ItemArray)))
                {
                    continue;
                }
                else
                {
                    doesTable1ContainDeltas = true;

                    if (addDifferenceColumn)
                    {
                        item1Row[differenceColumnName] = 0;
                    }
                }
            }

            bool doesTable2ContainDeltas = false;

            foreach (DataRow item2Row in source2.Rows)
            {
                if (source1.AsEnumerable().Select(y => y.ItemArray).Any(x => Enumerable.SequenceEqual(x, item2Row.ItemArray)))
                {
                    continue;
                }
                else
                {
                    doesTable2ContainDeltas = true;

                    if (addDifferenceColumn)
                    {
                        item2Row[differenceColumnName] = 0;
                    }
                }
            }

            return new[] { doesTable1ContainDeltas, doesTable2ContainDeltas }.Any(x => x.Equals(true))
                ? true
                : false;
        }

        public static DataTable SetColumnToSingleValue(this DataTable source, string columnName, object value)
        {
            foreach (DataRow row in source.Rows)
            {
                row[columnName] = value;
            }
            return source;
        }

        public static DataTable BuildDataTable<T>(IList<T> lst)
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
