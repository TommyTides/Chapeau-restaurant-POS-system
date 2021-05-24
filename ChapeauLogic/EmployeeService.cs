using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauLogic
{
    public class EmployeeService
    {
        private EmployeeDAO employeeDAO;

        public EmployeeService()
        {
            employeeDAO = new EmployeeDAO();
        }

        public Employee GetEmployeeByCode(int employeeid, int logincode)
        {
            return employeeDAO.GetEmployeeByCode(employeeid, logincode);
        }
    }
}
