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
    public class Constituencyrepo
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }

        public bool AddConstituency(Constituencymodel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("Insertconstituency", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@address", obj.address);
            com.Parameters.AddWithValue("@constituent_no", obj.constituent_no);
            com.Parameters.AddWithValue("@election_id", obj.election_id);


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

        public List<Constituencymodel> GetConstituency()
        {
            connection();
            List<Constituencymodel> ConstituencyList = new List<Constituencymodel>();


            SqlCommand com = new SqlCommand("Seleteconstituency", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {

                ConstituencyList.Add(

                    new Constituencymodel
                    {
                        constituent_id = Convert.ToInt32(dr["constituent_id"]),
                        address = Convert.ToString(dr["address"]),
                        constituent_no = Convert.ToString(dr["constituent_no"]),
                        election_id = Convert.ToInt32(dr["election_id"])
                    }
                    );
            }

            return ConstituencyList;
        }

        public bool UpdateConstituency(Constituencymodel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("Updateconstituency", con);
            com.Parameters.AddWithValue("@constituent_id", obj.constituent_id);
            com.Parameters.AddWithValue("@address", obj.address);
            com.Parameters.AddWithValue("@constituent_no", obj.constituent_no);
            com.Parameters.AddWithValue("@election_id", obj.election_id);

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
        public bool DeleteConstituency(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("Deleteconstituency", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@constituent_id", Id);

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