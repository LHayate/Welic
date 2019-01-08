using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace UseFul.Uteis
{
    public class ConvertDataTableToList
    {
        public static List<T> ToDataTable<T>(DataTable dataTable)
        {
            List<T> list = new List<T>();
            foreach (DataRow row in dataTable.Rows)
            {
                T item = GetItem<T>(row);
                list.Add(item);
            }

            return list;
        }

        public static T GetItem<T>(DataRow dr)
        {            
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo property in temp.GetProperties())
                {
                    if(property.Name == column.ColumnName)
                        property.SetValue(obj,dr[column.ColumnName],null);
                    else
                    {
                        continue;
                    }
                }
            }

            return obj;
        }
       


        /// <summary>
        /// Verifica se o tipo especificado é nulo
        /// </summary>
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }
    }
}
