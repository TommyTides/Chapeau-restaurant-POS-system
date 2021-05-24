using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;
namespace ChapeauDAL
{
    class TableDAO: BaseDao
    {
        public List<Table> GetAllTables()
        {
            string query = "SELECT t.table_id, t.capacity, ts.description " +
            "FROM[TABLE] as t " +
            " JOIN TABLE_STATUS as ts on t.statusID = ts.tablestatusID; ";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadAllTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Table> ReadAllTables(DataTable dataTable)
        {
            List<Table> tables = new List<Table>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Table table = new Table()
                {
                    TableID = (int)dr["tableID"],
                    TableStatus = (TableStatus)(dr["description"]),
                    Capacity = (int)(dr["capacity"])
                };
                tables.Add(table);
            }
            return tables;
        }

    }
}
