using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;

namespace ChapeauDAL
{
    public class EmployeeDAO: BaseDao
    {
        public Employee GetEmployeeByCode(int logincode)
        {
            string query = "SELECT * FROM EMPLOYEE WHERE login_code = @login_code";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("login_code", logincode);
            return ReadEmployee(ExecuteSelectQuery(query, sqlParameters));
        }

        private Employee ReadEmployee(DataTable table)
        {
            if (table.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow dr = table.Rows[0];
                Employee employee = new Employee()
                {

                    FirstName = (string)(dr["firstname"]),
                    LastName = (string)(dr["lastname"]),
                    Role = (string)(dr["role_detail"]),
                    LoginCode = (int)(dr["login_code"])
                };
                return employee;
            }
        }
    }
}
