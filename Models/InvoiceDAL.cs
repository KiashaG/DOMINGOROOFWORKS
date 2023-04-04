using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DOMINGOROOFWORKSCLDV6211.Models
{
    public class InvoiceDAL
    {
        //string connectionStringPROD = "Data Source=KIASHA-LAPTOP-H;Initial Catalog=DOMINGOROOFWORKSDB;Integrated Security=True";
        string connectionStringPROD = "Server=tcp:domingoroofworksdb.database.windows.net,1433;Initial Catalog=DOMINGOROOFWORKSDB;Persist Security Info=False;User ID=Kiasha;Password=Gungudoo$1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET ALL INVOICES
        public IEnumerable<InvoiceInfo> GetAllInvoices()
        {
            List<InvoiceInfo> invoiceList = new List<InvoiceInfo>();
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllInvoices", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    InvoiceInfo inv = new InvoiceInfo(); 
                    inv.JobCard_NO = Convert.ToInt32(dr["JobCard_NO"].ToString());
                    inv.Customer_Name = dr["Customer_Name"].ToString();
                    inv.Customer_Surname= dr["Customer_Surname"].ToString();
                    inv.Address = dr["Address"].ToString();
                    inv.JobType_Name = dr["JobType_Name"].ToString();
                    inv.Employee_Name= dr["Employee_Name"].ToString();
                    inv.Employee_Surname = dr["Employee_Surname"].ToString();
                    inv.Materials_Used = dr["Materials_Used"].ToString();
                    inv.DailyRate= Convert.ToDecimal(dr["DailyRate"].ToString());
                    inv.No_Of_Days = Convert.ToInt32(dr["No_Of_Days"].ToString());
                    inv.SubTotal= Convert.ToDecimal(dr["SubTotal"].ToString());
                    inv.Vat = Convert.ToDecimal(dr["Vat"].ToString());
                    inv.Total = Convert.ToDecimal(dr["Total"].ToString());
                  

                    invoiceList.Add(inv);
                }
                con.Close();
            }
            return invoiceList;
        }
        // INSERT INVOICES
        public void AddInvoices(InvoiceInfo inv)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertInvoice", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@JobCard_NO", inv.JobCard_NO);
                cmd.Parameters.AddWithValue("@Customer_Name",inv.Customer_Name);
                cmd.Parameters.AddWithValue("@Customer_Surname", inv.Customer_Surname);
                cmd.Parameters.AddWithValue("@Address", inv.Address);
                cmd.Parameters.AddWithValue("@JobType_Name", inv.JobType_Name);
                cmd.Parameters.AddWithValue("@Employee_Name", inv.Employee_Name);
                cmd.Parameters.AddWithValue("@Employee_Surname", inv.Employee_Surname);
                cmd.Parameters.AddWithValue("@Materials_Used", inv.Materials_Used);
                cmd.Parameters.AddWithValue("@DailyRate", inv.DailyRate);
                cmd.Parameters.AddWithValue("@No_Of_Days", inv.No_Of_Days);
                cmd.Parameters.AddWithValue("@SubTotal", inv.SubTotal);
                cmd.Parameters.AddWithValue("@Vat", inv.Vat);
                cmd.Parameters.AddWithValue("@Total", inv.Total);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        // GET INVOICE BY ID
        public InvoiceInfo GetInvoiceById(int? Invoice_ID)
        {
            InvoiceInfo inv= new InvoiceInfo();

            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetInvoiceById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@INVOICEID", Invoice_ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    inv.JobCard_NO = Convert.ToInt32(dr["JobCard_NO"].ToString());
                    inv.Customer_Name = dr["Customer_Name"].ToString();
                    inv.Customer_Surname = dr["Customer_Surname"].ToString();
                    inv.Address = dr["Address"].ToString();
                    inv.JobType_Name = dr["JobType_Name"].ToString();
                    inv.Employee_Name = dr["Employee_Name"].ToString();
                    inv.Employee_Surname = dr["Employee_Surname"].ToString();
                    inv.Materials_Used = dr["Materials_Used"].ToString();
                    inv.DailyRate = Convert.ToDecimal(dr["DailyRate"].ToString());
                    inv.No_Of_Days = Convert.ToInt32(dr["No_Of_Days"].ToString());
                    inv.SubTotal = Convert.ToDecimal(dr["SubTotal"].ToString());
                    inv.Vat = Convert.ToDecimal(dr["Vat"].ToString());
                    inv.Total = Convert.ToDecimal(dr["Total"].ToString());
                }
                con.Close();
            }
            return inv;
        }
        // UPDATE INVOICES
        public void UpdateInvoices(InvoiceInfo inv)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateInvoices", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@JobCard_NO", inv.JobCard_NO);
                cmd.Parameters.AddWithValue("@Customer_Name", inv.Customer_Name);
                cmd.Parameters.AddWithValue("@Customer_Surname", inv.Customer_Surname);
                cmd.Parameters.AddWithValue("@Address", inv.Address);
                cmd.Parameters.AddWithValue("@JobType_Name", inv.JobType_Name);
                cmd.Parameters.AddWithValue("@Employee_Name", inv.Employee_Name);
                cmd.Parameters.AddWithValue("@Employee_Surname", inv.Employee_Surname);
                cmd.Parameters.AddWithValue("@Materials_Used", inv.Materials_Used);
                cmd.Parameters.AddWithValue("@DailyRate", inv.DailyRate);
                cmd.Parameters.AddWithValue("@No_Of_Days", inv.No_Of_Days);
                cmd.Parameters.AddWithValue("@SubTotal", inv.SubTotal);
                cmd.Parameters.AddWithValue("@Vat", inv.Vat);
                cmd.Parameters.AddWithValue("@Total", inv.Total);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        // DELETE INVOICES
        public void DeleteInvoice(int? JobCard_NO)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteInvoice", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("JOBCARDNO", JobCard_NO);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
    }

