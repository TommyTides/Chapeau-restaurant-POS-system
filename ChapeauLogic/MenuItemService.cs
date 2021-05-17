using System;
using ChapeauDAL;
using ChapeauModel;
using System.Collections.Generic;

namespace ChapeauLogic
{
    public class MenuItemService
    {
        private MenuItemDAO menuItemDAO;

        public MenuItemService()
        {
            menuItemDAO = new MenuItemDAO();
        }

        // Gets all the menu items data and stores it in a list of drinks
        public List<MenuItem> GetMenuItems()
        {
            List<MenuItem> drinks = menuItemDAO.GetAllDrinks();
            return drinks;
        }
    }
}
