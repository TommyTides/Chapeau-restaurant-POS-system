﻿using System;
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
        public Employee GetEmployeeByCode(int pin)
        {
            string query = " SELECT e.firstName, e.lastName, e.roleID ,r.description FROM EMPLOYEE as e " +
            " JOIN ROLE as r ON e.roleID = r.roleID " +
            " WHERE PIN = @PIN";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@PIN", pin);
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
                    Role = (Role)(dr["roleID"])
                };
                return employee;
            }
        }

        public Employee GetEmployee(int employeeid)
        {
            string query = "SELECT employeeID, firstName, lastName, roleID FROM EMPLOYEE WHERE employeeID = @employeeID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@employeeID", employeeid);
            return ReadEmployee(ExecuteSelectQuery(query, sqlParameters));
        }

    }
}
