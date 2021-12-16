using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PassportProject
{
    public partial class Newuser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=ITCLABJ69\SQLEXPRESS ;Integrated security=true ; Initial Catalog = login table admin");

        protected void Button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd =new SqlCommand("insert into dbo.LoginTable values('" + textname + "','" + txtusername + "' , '" + txtpwd + "' , '" + gender.ToString() + "' , '" + Securityquestion.ToString() + "' ,'" + secans + "')",conn);
            int status = cmd.ExecuteNonQuery();
            if(status > 0)
            {
                Response.Write("User added successfully");
            }
            else
            {
                Response.Write("Data Insertion Failed");
            }
            conn.Close();
        }    
    }
}