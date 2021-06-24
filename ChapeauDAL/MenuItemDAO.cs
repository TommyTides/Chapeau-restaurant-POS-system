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

                MenuItem menuItem = new MenuItem(item_id, menu_type, item_type, item_name, item_price, stock, place);
                menuItems.Add(menuItem);
            }
            return menuItems;
        }

        public void EditMenuItem(MenuItem item)
        {
            string query = "UPDATE MENU_ITEM SET menu_type = @menu_type, item_type = @item_type, " +
                "item_name = @item_name, item_price = @item_price, stock = @stock, place = @place WHERE item_id = @item_id";
            SqlParameter[] sqlParameters = new SqlParameter[7];
            sqlParameters[0] = new SqlParameter("@menu_type", (int)item.menu_type);
            sqlParameters[1] = new SqlParameter("@item_type", (int)item.item_type);
            sqlParameters[2] = new SqlParameter("@item_name", item.item_name);
            sqlParameters[3] = new SqlParameter("@item_price", item.item_price);
            sqlParameters[4] = new SqlParameter("@stock", item.stock);
            sqlParameters[5] = new SqlParameter("@place", (int)item.place);
            sqlParameters[6] = new SqlParameter("@item_id", item.item_id);
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}