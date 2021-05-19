using ChapeauModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System;

namespace ChapeauDAL
{
    public class PaymentDAO : BaseDao
    {
        public List<Payment> GetAllPayments()
        {
            string query = "SELECT payment_id, orderitem_code, paymentStatus, paymentMethod, payment_date FROM PAYMENT";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Payment> ReadTables(DataTable dataTable)
        {
            List<Payment> payments = new List<Payment>();

            foreach(DataRow dr in dataTable.Rows)
            {
                Payment payment = new Payment()
                {
                    PaymentID = (int)dr["payment_id"],
                    OrderitemCode = (int)dr["orderitem_code"],
                    paymentMethod = (Payment.PaymentMethod)dr["paymentMethod"],
                    paymentStatus = (Payment.PaymentStatus)dr["paymentStatus"],
                    PaymentDate = (DateTime)dr["payment_date"]
                };
                payments.Add(payment);
            }
            return payments;
        }
    }
}
