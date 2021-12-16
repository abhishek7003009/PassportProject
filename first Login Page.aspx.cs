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
    public partial class first_Login_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=ITCLABJ69\SQLEXPRESS ;Integrated security=true ; Initial Catalog = login table admin");
        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void txt_admin_username_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select count(1) from [dbo].[LoginTable] where [username]='" + txt_admin_username.Text + "' and [pwd]='" + txt_admin_pwd.Text + "'", conn);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            int val = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            if (val > 0)
            {
                Response.Write("Valid login");
                Response.Redirect("Option Page.aspx");
            }
            else
            {
                Response.Write("Invalid login");
            }
            conn.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
           
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Newuser.aspx");
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "Select id from[dbo].[passport_logindetails] where username = '" + txtuser.Text + "' and pwd = '" + txtpwd.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = System.Data.CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            int val = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            if (val > 0)
            {
                Response.Write("Valid login");
                Response.Redirect("userStatus.aspx"); 
            }
            else
            {
                Response.Write("Invalid login");
            }
            conn.Close();
            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Close(); 
        }
    }
}