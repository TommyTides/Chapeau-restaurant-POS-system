using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int LoginCode { get; set; }

        // default constructor
        public Employee()
        {

        }

        public Employee(string firstname, string lastname, string role)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Role = role;
        }
    }
}
