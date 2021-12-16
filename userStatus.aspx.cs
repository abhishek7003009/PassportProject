using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace PassportProject
{
    public partial class userStatus : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=ITCLABJ69\SQLEXPRESS ;Integrated security=true ; Initial Catalog = login table admin");
        private object id;
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.Open();

            string query = "Select * from Passport_ApplicationDetails a inner join passport_logindetails b on a.id = b.id where a.id =" + id;
            SqlCommand cmd = new SqlCommand(query, conn);
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}