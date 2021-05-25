using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Table
    {
        public int TableID { get; set; }
        public TableStatus TableStatus { get; set; }
        public string OrderStatus { get; set; }

        public Table(int tableid)
        {
            this.TableID = tableid;
        }

        // default constructor
        public Table()
        {

        }
    }

    public enum TableStatus { Free = 1, Occupied, Reserved }
}
