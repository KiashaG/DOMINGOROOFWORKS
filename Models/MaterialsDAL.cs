using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DOMINGOROOFWORKSCLDV6211.Models
{
    public class MaterialsDAL
    {
        //string connectionStringPROD = "Data Source=KIASHA-LAPTOP-H;Initial Catalog=DOMINGOROOFWORKSDB;Integrated Security=True";
        string connectionStringPROD = "Server=tcp:domingoroofworksdb.database.windows.net,1433;Initial Catalog=DOMINGOROOFWORKSDB;Persist Security Info=False;User ID=Kiasha;Password=Gungudoo$1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET ALL MATERIALS
        public IEnumerable<MaterialsInfo> GetAllMaterials()
        {
            List<MaterialsInfo> materialList = new List<MaterialsInfo>();
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllMaterials", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    MaterialsInfo mat = new MaterialsInfo(); 
                    mat.Materials_Used = dr["Materials_Used"].ToString();
                    mat.Materials_ID = Convert.ToInt32(dr["Materials_ID"].ToString());
                    mat.Job_ID = Convert.ToInt32(dr["Job_ID"].ToString());
                    mat.JobCard_No = Convert.ToInt32(dr["JobCard_No"].ToString());

                    materialList.Add(mat);
                }
                con.Close();
            }
            return materialList;
        }
        // INSERT MATERIALS
        public void AddMaterials(MaterialsInfo mat)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertMaterials", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Materials_Used", mat.Materials_Used);
                cmd.Parameters.AddWithValue("@Materials_ID", mat.Materials_ID);
                cmd.Parameters.AddWithValue("@Job_ID", mat.Job_ID);
                cmd.Parameters.AddWithValue("@JobCard_No", mat.JobCard_No);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        // GET MATERIALS BY ID
        public MaterialsInfo GetMaterialsById(int? Materials_ID)
        {
            MaterialsInfo mat = new MaterialsInfo();

            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_GetMaterialsById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaterialsID", Materials_ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    mat.Materials_Used = dr["Materials_Used"].ToString();
                    mat.Materials_ID = Convert.ToInt32(dr["Materials_ID"].ToString());
                    mat.Job_ID = Convert.ToInt32(dr["Job_ID"].ToString());
                    mat.JobCard_No= Convert.ToInt32(dr["JobCard_No"].ToString());

                }
                con.Close();
            }
            return mat;
        }
        // UPDATE MATERIALS
        public void UpdateMaterials(MaterialsInfo mat)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateMaterials", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Materials_Used", mat.Materials_Used);
                cmd.Parameters.AddWithValue("@Materials_ID", mat.Materials_ID);
                cmd.Parameters.AddWithValue("@Job_ID", mat.Job_ID);
                cmd.Parameters.AddWithValue("@JobCard_No", mat.JobCard_No);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        // DELETE MATERIALS
        public void DeleteMaterial(int? Materials_ID)
        {
            using (SqlConnection con = new SqlConnection(connectionStringPROD))
            {
                SqlCommand cmd = new SqlCommand("SP_DeleteMaterials", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("MATERIALSID", Materials_ID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
