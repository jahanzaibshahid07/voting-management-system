using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using votingmanagementsystem.Models;

namespace votingmanagementsystem.Repository
{
    public class Candidaterepo
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }

        public bool AddCandidate(Candidatemodel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("Insertcandidate", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@name", obj.name);
            com.Parameters.AddWithValue("@age", obj.age);
            com.Parameters.AddWithValue("@address", obj.address);
            com.Parameters.AddWithValue("@email", obj.email);
            com.Parameters.AddWithValue("@party_id", obj.party_id);
 

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }

        public List<Candidatemodel> GetCandidate()
        {
            connection();
            List<Candidatemodel> CandidateList = new List<Candidatemodel>();


            SqlCommand com = new SqlCommand("Seletecandidate", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {

                CandidateList.Add(

                    new Candidatemodel
                    {
                        candidate_id = Convert.ToInt32(dr["candidate_id"]),
                        name = Convert.ToString(dr["name"]),
                        age = Convert.ToInt32(dr["age"]),
                        address = Convert.ToString(dr["address"]),
                        email = Convert.ToString(dr["email"]),
                        party_id = Convert.ToInt32(dr["party_id"])
                    }
                    );
            }

            return CandidateList;
        }

        public bool UpdateCandidate(Candidatemodel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("Updatecandidate", con);
            com.Parameters.AddWithValue("@candidate_id", obj.candidate_id);
            com.Parameters.AddWithValue("@name", obj.name);
            com.Parameters.AddWithValue("@age", obj.age);
            com.Parameters.AddWithValue("@address", obj.address);
            com.Parameters.AddWithValue("@email", obj.email);
            com.Parameters.AddWithValue("@party_id", obj.party_id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }


        }
        public bool DeleteCandidate(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("Deletecandidate", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@candidate_id", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }
        }
    }
}