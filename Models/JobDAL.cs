using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace DOMINGOROOFWORKSCLDV6211.Models
{
    public class JobDAL
    {
        //string connectionStringPROD = "Data Source=KIASHA-LAPTOP-H;Initial Catalog=DOMINGOROOFWORKSDB;Integrated Security=True";
        string connectionStringPROD = "Server=tcp:domingoroofworksdb.database.windows.net,1433;Initial Catalog=DOMINGOROOFWORKSDB;Persist Security Info=False;User ID=Kiasha;Password=Gungudoo$1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET ALL JOBS
        public IEnumerable<JobInfo> GetAllJobs()
        {
            List<JobInfo> jobList = new List<JobInfo>();
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllJobs", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    JobInfo JB = new JobInfo();
                    JB.JobCard_No = Convert.ToInt32(dr["JobCard_No"].ToString());
                
                    jobList.Add(JB);
                }
                con.Close();
            }
            return jobList;
        }
        // INSERT JOBS
        public void AddJob(JobInfo JB)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertJob", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@JobCard_No", JB.JobCard_No);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        // GET JOB BY ID
        public JobInfo GetJobById(int? JobCard_No)
        {
            JobInfo JB = new JobInfo();

            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetJobById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@JOBID", JobCard_No);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    JB.JobCard_No = Convert.ToInt32(dr["JobCard_No"].ToString());
                 
                }
                con.Close();
            }
            return JB;
        }
        // UPDATE JOBS
        public void UpdateJob(JobInfo JB)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateJobs", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@JobCard_No", JB.JobCard_No);    
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        // DELETE JOBS
        public void DeleteJob(int? JobCard_No)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteJob", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("JOBID", JobCard_No);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
    

