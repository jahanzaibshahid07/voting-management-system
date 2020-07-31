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
    public class Citizenrepo
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }

        public bool AddCitizen(Citizenmodel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("Insertcitizens", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@name", obj.name);
            com.Parameters.AddWithValue("@age", obj.age);
            com.Parameters.AddWithValue("@address", obj.address);
            com.Parameters.AddWithValue("@email", obj.email);
            com.Parameters.AddWithValue("@cnic_no", obj.cnic_no);
            com.Parameters.AddWithValue("@constituent_id", obj.constituent_id);

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

        public List<Citizenmodel> GetCitizen()
        {
            connection();
            List<Citizenmodel> CitizenList = new List<Citizenmodel>();


            SqlCommand com = new SqlCommand("Selectcitizens", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {

                CitizenList.Add(

                    new Citizenmodel
                    {

                        citizen_id = Convert.ToInt32(dr["citizen_id"]),
                        name = Convert.ToString(dr["name"]),
                        age = Convert.ToString(dr["age"]),
                        address = Convert.ToString(dr["address"]),
                        email = Convert.ToString(dr["email"]),
                        cnic_no = Convert.ToInt32 (dr["cnic_no"]),
                        constituent_id = Convert.ToInt32(dr["constituent_id"])

                    }


                    );


            }

            return CitizenList;


        }

        public bool UpdateCitizen(Citizenmodel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("Updatecitizens", con);
            com.Parameters.AddWithValue("@citizen_id", obj.citizen_id);
            com.Parameters.AddWithValue("@name", obj.name);
            com.Parameters.AddWithValue("@age", obj.age);
            com.Parameters.AddWithValue("@address", obj.address);
            com.Parameters.AddWithValue("@email", obj.email);
            com.Parameters.AddWithValue("@cnic_no", obj.cnic_no);
            com.Parameters.AddWithValue("@constituent_id", obj.constituent_id);

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
        public bool DeleteCitizen(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("Deletecitizens", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@citizen_id", Id);

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