using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauLogic
{
    public class MenuItemService
    {
        private MenuItemDAO menuItemDAO;

        public MenuItemService()
        {
            menuItemDAO = new MenuItemDAO();
        }

        // Gets all the drinks data and stores it in a list of drinks
        public List<MenuItem> GetAllMenuItems()
        {
            List<MenuItem> menuItems = menuItemDAO.GetAllMenuItems();
            return menuItems;
        }

        // Edit Item
        public void EditMenuItem(MenuItem item)
        {
            menuItemDAO.EditMenuItem(item);
        }
    }
}