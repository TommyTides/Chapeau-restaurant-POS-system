using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    public class TableServices
    {
        TableDAO tableDAO;
        
        public TableServices()
        {
            tableDAO = new TableDAO();
        }

        public List<Table> GetAllTables()
        {
            return tableDAO.GetAllTables();
        }

        public void ChangeTableStatus(int tableid, int tablestatus)
        {
            tableDAO.ChangeTableStatus(tableid, tablestatus);
        }

    }
}
