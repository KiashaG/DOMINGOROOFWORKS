using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DOMINGOROOFWORKSCLDV6211.Models
{
    public class EmployeeDAL
    {
        //string connectionStringPROD = "Data Source=KIASHA-LAPTOP-H;Initial Catalog=DOMINGOROOFWORKSDB;Integrated Security=True";
        string connectionStringPROD = "Server=tcp:domingoroofworksdb.database.windows.net,1433;Initial Catalog=DOMINGOROOFWORKSDB;Persist Security Info=False;User ID=Kiasha;Password=Gungudoo$1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


    // GET ALL EMPLOYEES
        public IEnumerable<EmployeeInfo> GetAllEmployees()
        {
            List<EmployeeInfo> employeeList = new List<EmployeeInfo>();
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllEmployees", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EmployeeInfo emp = new EmployeeInfo();
                    emp.Employee_NO = dr["Employee_NO"].ToString();
                    emp.Employee_Name = dr["Employee_Name"].ToString();
                    emp.Employee_Surname = dr["Employee_Surname"].ToString();

                    employeeList.Add(emp);
                }
                con.Close();
            }
            return employeeList;
        }
       


        // INSERT EMPLOYEES
        public void AddEmployee(EmployeeInfo emp)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Employee_NO", emp.Employee_NO);
                cmd.Parameters.AddWithValue("@Employee_Name", emp.Employee_Name);
                cmd.Parameters.AddWithValue("@Employee_Surname", emp.Employee_Surname);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        // GET EMPLOYEE BY ID
        public EmployeeInfo GetEmployeeById(string Employee_ID)
        {
            EmployeeInfo emp = new EmployeeInfo();

            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetEmployeeById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EMPLOYEEID", Employee_ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   emp.Employee_NO  = dr["Employee_NO"].ToString();
                   emp.Employee_Name = dr["Employee_Name"].ToString();
                   emp.Employee_Surname = dr["Employee_Surname"].ToString();
                }
                con.Close();
            }
            return emp;
        }
        // UPDATE EMPLOYEES
        public void UpdateEmployees(EmployeeInfo emp)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EMPLOYEEID", emp.Employee_NO);
                cmd.Parameters.AddWithValue("@Employee_NO", emp.Employee_NO);
                cmd.Parameters.AddWithValue("@Employee_Name", emp.Employee_Name);
                cmd.Parameters.AddWithValue("@Employee_Surname", emp.Employee_Surname);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        // DELETE EMPLOYEES
        public void DeleteEmployee(string Employee_ID)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("EMPLOYEEID", Employee_ID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}