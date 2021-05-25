using ChapeauModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ChapeauDAL
{
    public class MenuItemDAO : BaseDao
    {
        // This method passes the query to the ExecuteSelectQuery METHOD
        public List<MenuItem> GetAllMenuItems()
        {
            string query = "SELECT [item_id], [menu_type], [item_type], [item_name], [item_price], [stock], [place] FROM MENU_ITEM;";
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
                MenuCategory menu_type = (MenuCategory)dr["menu_type"];
                MenuSubCategory item_type = (MenuSubCategory)dr["item_type"];
                string item_name = (string)dr["item_name"];
                double item_price = (double)dr["item_price"];
                int stock = (int)dr["stock"];
                Place place = (Place)dr["place"];

                //MenuItem menuItem = new MenuItem(item_id, menu_type, item_type, item_name, item_price, stock, vat);
                //menuItems.Add(menuItem);
            }
            return null;
        }
    }
}