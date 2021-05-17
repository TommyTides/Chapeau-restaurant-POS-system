using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ChapeauDAL
{
    public class MenuItemDAO : BaseDao
    {
        // This method passes the query to the ExecuteSelectQuery METHOD
        public List<MenuItem> GetAllDrinks()
        {
            string query = "SELECT drink_code, drink_type, drink_name, price, stock FROM [DRINK] WHERE stock >= 1 AND price > 1 ORDER BY stock,price;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        // Read the selected tablerows from the database and add it to the list
        private List<MenuItem> ReadTables(DataTable dataTable)
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            foreach (DataRow dr in dataTable.Rows)
            {
                int item_id = (int)dr["item_id"];
                string menu_type = (string)dr["menu_type"];
                string item_type = (string)dr["item_type"];
                string item_name = (string)dr["item_name"];
                double item_price = (double)dr["item_price"];
                int stock = (int)dr["stock"];
                int vat = (int)dr["vat"];

                MenuItem menuItem = new MenuItem(item_id, menu_type, item_type, item_name, item_price, stock, vat);
                menuItems.Add(menuItem);
            }
            return menuItems;
        }
    }
}
