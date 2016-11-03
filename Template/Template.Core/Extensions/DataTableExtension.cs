using Common.Logging;
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
    public static class DataTableExtension
    {
        private static ILog logger;

        static DataTableExtension()
        {
            logger = LogManager.GetLogger("DataTableExtension");
        }

        /// <summary>
        /// 将DataTable转换为实体类集合
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns>实体类集合</returns>
        public static List<T> GetList<T>(this DataTable dt) where T : class, new()
        {
            PropertyInfo[] properties = typeof(T).GetProperties().Where(t => dt.Columns.Contains(t.Name)).ToArray();
            int count = dt.Rows.Count;
            T[] array = new T[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = new T();
            }
            foreach (PropertyInfo property in properties)
            {
                PropertyAccessor pa = PropertyAccessor.Get(property);
                Type propertyType = property.PropertyType;
                DataColumn dc = dt.Columns[dt.Columns.IndexOf(property.Name)];
                int i = 0;
                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    Type underlyingType = Nullable.GetUnderlyingType(property.PropertyType);
                    if (dc.DataType.Equals(underlyingType))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (!Convert.IsDBNull(dr[property.Name]))
                            {
                                pa.SetValue(array[i], dr[property.Name]);
                            }
                            i++;
                        }
                    }
                    else
                    {
                        try
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (!Convert.IsDBNull(dr[property.Name]))
                                {
                                    pa.SetValue(array[i], Convert.ChangeType(dr[property.Name], underlyingType));
                                }
                                i++;
                            }
                        }
                        catch (Exception e)
                        {
                            logger.Warn("GetList Convert UnderlyingType Error!", e);
                        }
                    }
                }
                else
                {
                    if (dc.DataType.Equals(property.PropertyType))
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (!Convert.IsDBNull(dr[property.Name]))
                            {
                                pa.SetValue(array[i], dr[property.Name]);
                            }
                            i++;
                        }
                    }
                    else
                    {
                        try
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (!Convert.IsDBNull(dr[property.Name]))
                                {
                                    pa.SetValue(array[i], Convert.ChangeType(dr[property.Name], property.PropertyType));
                                }
                                i++;
                            }
                        }
                        catch (Exception e)
                        {
                            logger.Warn("GetList Convert Error!", e);
                        }
                    }
                }
            }
            return array.ToList();
        }
    }
}
