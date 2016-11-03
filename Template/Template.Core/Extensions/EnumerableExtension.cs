using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Template.Core.FastReflection;

namespace Template.Core.Extensions
{
    public static class EnumerableExtension
    {
        public static DataTable GetDataTable<T>(this IEnumerable<T> collection, string tableName, params string[] preclusiveColumnNames)
        {
            DataTable dt = new DataTable();
            dt.TableName = tableName;
            PropertyInfo[] properties = typeof(T).GetProperties();
            if (preclusiveColumnNames.Any())
            {
                properties = properties.Where(o => !preclusiveColumnNames.Contains(o.Name)).ToArray();
            }
            foreach (PropertyInfo property in properties)
            {
                Type propertyType = property.PropertyType;
                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    dt.Columns.Add(property.Name, Nullable.GetUnderlyingType(propertyType));
                }
                else
                {
                    dt.Columns.Add(property.Name, propertyType);
                }
            }
            PropertyAccessor[] propertyAccessors = properties.Select(o => PropertyAccessor.Get(o)).ToArray();
            foreach (T data in collection)
            {
                DataRow dr = dt.NewRow();
                foreach (PropertyAccessor pa in propertyAccessors)
                {
                    dr[pa.PropertyInfo.Name] = pa.GetValue(data) ?? DBNull.Value;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
