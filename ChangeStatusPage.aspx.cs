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
    public partial class ChangeStatusPage : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=ITCLABJ69\SQLEXPRESS ;Integrated security=true ; Initial Catalog = login table admin");
        
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd1 = new SqlCommand("select [PassportRefNumber] from [dbo].[Passport_ApplicationDetails] where [PPstatus] = 'Pending'", conn);

            cmd1.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            list_refno.DataSource = ds;
            list_refno.DataBind();
            list_refno.DataTextField = "Name";
            list_refno.DataValueField = "PassportRefNumber";
            list_refno.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string query = "update [dbo].[passport_details] set [PPstatus]='" + list_refno.SelectedItem.ToString() + "' where [PassportRefNumber]=" + list_refno.SelectedItem.ToString();
            SqlCommand cmd2 = new SqlCommand(query, conn);
            int status = cmd2.ExecuteNonQuery();
            if(status > 0)
            {
                Response.Write("Passport Details updated Successfully");
            }
            else
            {
                Response.Write("Updation Failed");
            }
             conn.Close();
        }


        protected void list_status_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Option Page.aspx");
        }

        protected void list_refno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


}