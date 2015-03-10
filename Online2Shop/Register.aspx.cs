using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controller;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
//using MySql.Data;
//using MySql.Data.MySqlClient;


namespace Online2Shop
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       /* protected void CreateUser(object sender, EventArgs e)
        {

            //String myConnectionString = "server=202.146.213.88;User Id=mkgmint_user;password=9891titi;database=mkgmint_Online2Shop";
            String myConnectionString = "server=localhost;User Id=root;password=root;database=mkgmint_Online2Shop";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySqlConnection(myConnectionString);
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            string query = "INSERT INTO members(Username,Password, Admin, Email, Discount) VALUES(@param2,@param3,@param4,@param5,@param6)";

            cmd.CommandText = query;

            //cmd.Parameters.AddWithValue("@param1", 100);
            cmd.Parameters.AddWithValue("@param2", "gigio");
            cmd.Parameters.AddWithValue("@param3", "topo");
            cmd.Parameters.AddWithValue("@param4", 0);
            cmd.Parameters.AddWithValue("@param5", "mail");
            cmd.Parameters.AddWithValue("@param6", 0);
            cmd.ExecuteNonQuery();

            conn.Close();
            
        }*/
    }
}