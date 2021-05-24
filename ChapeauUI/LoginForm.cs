using ChapeauModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauLogic;

namespace ChapeauUI
{
    public partial class LoginForm : Form
    {
        EmployeeService employeeService = new EmployeeService();
        public LoginForm()
        {
            InitializeComponent();
            txtlogincode.PasswordChar = '*';
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            WinAPI.AnimateWindow(this.Handle, 2000, WinAPI.BLEND);
        }

        private void KeypadButton_Click(object sender, EventArgs e)
        {
            txtlogincode.AppendText(((Button)sender).Text);

            if (txtlogincode.TextLength == 4)
            {
                GetEmployeeByLogin();
            }
        }

        private void GetEmployeeByLogin()
        {
            Employee employee = employeeService.GetEmployeeByCode(int.Parse(txtemployeeid.Text), int.Parse(txtlogincode.Text));

            string[] management = new string[] { "Waiter", "Manager" };

            string[] kitchen = new string[] { "Chef", "Barman" };


            // if employee not null and role is valid
            /* if (employee != null && (management.Contains(Role.Waiter) || kitchen.Contains(Role.Manager)))
             {
                 this.Hide();
                 if (management.Contains(employee.Role))
                 {
                     // the table view page will go here 
                     Menu mainMenu = new Menu(employee);
                     mainMenu.ShowDialog();

                 }
                 else if (kitchen.Contains(employee.Role))
                 {
                       //The kitchen and bar view page will go here 
                 }
                 this.Close();
             }
             else
             {
                 txtlogincode.Text = "";
                 MessageBox.Show("Password Entered is Incorrect");
             }
            */

            if (employee.Role == Role.Waiter || employee.Role == Role.Manager)
            {
                Menu mainMenu = new Menu();
                mainMenu.Show();
            }
            else if (employee.Role == Role.KitchenStaff || employee.Role == Role.Barman)
            {
                /*The kitchen and bar view will go here */
            }
            else
            {
                txtemployeeid.Text = "";
                txtlogincode.Text = "";
                MessageBox.Show("Invalid login credentials!");
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            txtlogincode.Text = txtlogincode.Text.Substring(0, (txtlogincode.TextLength - 1));
        }
    }
}
