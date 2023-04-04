using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DOMINGOROOFWORKSCLDV6211.Models
{
    public class JobTypeDAL
    {
        //string connectionStringPROD = "Data Source=KIASHA-LAPTOP-H;Initial Catalog=DOMINGOROOFWORKSDB;Integrated Security=True";
        string connectionStringPROD = "Server=tcp:domingoroofworksdb.database.windows.net,1433;Initial Catalog=DOMINGOROOFWORKSDB;Persist Security Info=False;User ID=Kiasha;Password=Gungudoo$1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        // GET ALL JOBTYPES
        public IEnumerable<JobTypeInfo> GetAllJobTypes()
        {
            List<JobTypeInfo> jobtypeList = new List<JobTypeInfo>();
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllJobTypes", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    JobTypeInfo JT = new JobTypeInfo();
                    JT.Job_ID = Convert.ToInt32(dr["Job_ID"].ToString());
                    JT.JobType_Name = dr["JobType_Name"].ToString();
                    JT.No_Of_Days = Convert.ToInt32(dr["No_Of_Days"].ToString());
                    JT.DailyRate = Convert.ToDecimal(dr["DailyRate"].ToString());

                    jobtypeList.Add(JT);
                }
                con.Close();
            }
            return jobtypeList;
        }
        // INSERT JOBTYPES
        public void AddJobType(JobTypeInfo JT)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertJobType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Job_ID", JT.Job_ID);
                cmd.Parameters.AddWithValue("@JobType_Name", JT.JobType_Name);
                cmd.Parameters.AddWithValue("@No_Of_Days", JT.No_Of_Days);
                cmd.Parameters.AddWithValue("@DailyRate", JT.DailyRate);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        // GET JOBTYPE BY ID
        public JobTypeInfo GetJobTypeById(int? Job_ID)
        {
            JobTypeInfo JT = new JobTypeInfo();

            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetJobTypeById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@JOBTYPE", Job_ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    JT.Job_ID = Convert.ToInt32(dr["Job_ID"].ToString());
                    JT.JobType_Name = dr["JobType_Name"].ToString();
                    JT.No_Of_Days = Convert.ToInt32(dr["No_Of_Days"].ToString());
                    JT.DailyRate = Convert.ToDecimal(dr["DailyRate"].ToString());
                }
                con.Close();
            }
            return JT;
        }

        // UPDATE JOBTYPES
        public void UpdateJobTypes(JobTypeInfo JT)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateJobTypes", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Job_ID", JT.Job_ID);
                cmd.Parameters.AddWithValue("@JobType_Name", JT.JobType_Name);
                cmd.Parameters.AddWithValue("@No_Of_Days", JT.No_Of_Days);
                cmd.Parameters.AddWithValue("@DailyRate", JT.DailyRate);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        // DELETE JOBTYPES
        public void DeleteJobType(int? Job_ID)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteJobType", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("JOBTYPEID", Job_ID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


    }
}
