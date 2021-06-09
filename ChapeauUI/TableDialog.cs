using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauModel;

namespace ChapeauUI
{
    public partial class TableDialog : Form
    {
        Table table;
        public TableDialog(Table table)
        {
            this.table = table;
            InitializeComponent();
        }
    }
}
