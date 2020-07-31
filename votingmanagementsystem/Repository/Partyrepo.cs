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
    public class Partyrepo
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }

        public bool AddParty(Partymodel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("Insertparty", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@party_name", obj.party_name);
            com.Parameters.AddWithValue("@party_logo", obj.party_logo);
       

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

        public List<Partymodel> GetParty()
        {
            connection();
            List<Partymodel> PartyList = new List<Partymodel>();


            SqlCommand com = new SqlCommand("Selectparty", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {

                PartyList.Add(

                    new Partymodel
                    {

                        party_id = Convert.ToInt32(dr["party_id"]),
                        party_name = Convert.ToString(dr["party_name"]),
                        party_logo = Convert.ToString(dr["party_logo"])
                    }


                    );


            }

            return PartyList;


        }

        public bool UpdateParty(Partymodel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("Updateparty", con);
            com.Parameters.AddWithValue("@party_id", obj.party_id);
            com.Parameters.AddWithValue("@party_name", obj.party_name);
            com.Parameters.AddWithValue("@party_logo", obj.party_logo);

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
        public bool DeleteParty(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("Deleteparty", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@party_id", Id);

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