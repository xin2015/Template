using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.EF.Extensions
{
    public static class DbContextExtension
    {
        public static void SqlBulkCopyInsert(this DbContext db, DataTable dt)
        {
            using(SqlBulkCopy sbc=new SqlBulkCopy(db.Database.Connection.ConnectionString))
            {
                sbc.DestinationTableName = dt.TableName;
                sbc.BatchSize = 50000;
                foreach (DataColumn item in dt.Columns)
                {
                    sbc.ColumnMappings.Add(item.ColumnName, item.ColumnName);
                }
                sbc.WriteToServer(dt);
            }
        }
    }
}
