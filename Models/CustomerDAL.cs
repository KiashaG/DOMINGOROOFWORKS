using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DOMINGOROOFWORKSCLDV6211.Models
{
    public class CustomerDAL
    {
        //string connectionStringPROD = "Data Source=KIASHA-LAPTOP-H;Initial Catalog=DOMINGOROOFWORKSDB;Integrated Security=True";
        string connectionStringPROD = "Server=tcp:domingoroofworksdb.database.windows.net,1433;Initial Catalog=DOMINGOROOFWORKSDB;Persist Security Info=False;User ID=Kiasha;Password=Gungudoo$1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        // GET ALL CUSTOMERS
        public IEnumerable<CustomerInfo> GetAllCustomers()
        {
            List<CustomerInfo> customerList = new List<CustomerInfo>();
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllCustomers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CustomerInfo cust = new CustomerInfo();
                    cust.Customer_ID = Convert.ToInt32(dr["Customer_ID"].ToString());
                    cust.Customer_Name = dr["Customer_Name"].ToString();
                    cust.Customer_Surname = dr["Customer_Surname"].ToString();
                    cust.Address = dr["Address"].ToString();

                    customerList.Add(cust);
                }
                con.Close();
            }
            return customerList;
        }
        // INSERT CUSTOMERS
        public void AddCustomer(CustomerInfo cust)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Customer_ID", cust.Customer_ID);
                cmd.Parameters.AddWithValue("@Customer_Name", cust.Customer_Name);
                cmd.Parameters.AddWithValue("@Customer_Surname", cust.Customer_Surname);
                cmd.Parameters.AddWithValue("@Address", cust.Address);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // GET CUSTOMER BY ID
        public CustomerInfo GetCustomerById(int? Customer_ID)
        {
            CustomerInfo cust = new CustomerInfo();

            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetCustomerById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerID", Customer_ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cust.Customer_ID = Convert.ToInt32(dr["Customer_ID"].ToString());
                    cust.Customer_Name = dr["Customer_Name"].ToString();
                    cust.Customer_Surname= dr["Customer_Surname"].ToString();
                    cust.Address = dr["Address"].ToString();
                }
                con.Close();
            }
            return cust;
        }

        // UPDATE CUSTOMERS
        public void UpdateCustomer(CustomerInfo cust)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateCustomers", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Customer_ID", cust.Customer_ID);
                cmd.Parameters.AddWithValue("@Customer_Name", cust.Customer_Name);
                cmd.Parameters.AddWithValue("@Customer_Surname", cust.Customer_Surname);
                cmd.Parameters.AddWithValue("@Address", cust.Address);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // DELETE CUSTOMERS
        public void DeleteCustomer(int? Customer_ID)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteCustomer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("CUSTOMERID", Customer_ID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}