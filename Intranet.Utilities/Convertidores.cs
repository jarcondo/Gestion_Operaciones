using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Intranet.Utils.Convertidores
{


    public static class Converter<T> where T : new()
    {
        public static DataTable Convert(List<T> items)
        {

            DataTable returnValue = new DataTable();
            Type itemsType = typeof(T);
            foreach (PropertyInfo prop in itemsType.GetProperties())
            {
                DataColumn column = new DataColumn(prop.Name);
                column.DataType = prop.PropertyType;
                returnValue.Columns.Add(column);
            }

            int j;
            foreach (T item in items)
            {
                j = 0;
                object[] newRow = new object[returnValue.Columns.Count];
                foreach (PropertyInfo prop in itemsType.GetProperties())
                {
                    newRow[j] = prop.GetValue(item, null);
                    j++;
                }
                returnValue.Rows.Add(newRow);
            }
            return returnValue;
        }
    }
}
