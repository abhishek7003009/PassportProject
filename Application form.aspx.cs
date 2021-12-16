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
    public partial class Application_form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(@"Data Source=ITCLABJ69\SQLEXPRESS ;Integrated security=true ; Initial Catalog = login table admin");

        protected void Button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int PassportRefNumber = rnd.Next(100, 20000);
            string ppstatus = "Pending";
            conn.Open();
            string query = "insert into Passport_ApplicationDetails(FirstName,LastName,Email,Address,District,State,Gender,PassportRefNumber,PPstatus)values ('" + txt_firstname.Text + "' , '" + txt_lastname.Text + "' , '" + txt_email.Text + "' , '" + txt_address.Text + "' , '" + txt_district.Text + "' , '" + txt_state.Text + "' , '" + list_gender.Text + "' , " + PassportRefNumber.ToString() + " , '" + ppstatus + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            int status = cmd.ExecuteNonQuery();
            if (status == 1)
            {
                Response.Write("Details Updated Successfully");
            }
            else
            {
                Response.Write("Update Failed");
            }
            SqlCommand cmd1 = new SqlCommand("select id from passport_logindetails order by id desc", conn);
            cmd1.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            string query3 = "insert into passport_logindetails(Id,username,pwd,Security_Question,Security_Password) values(" + id + "' , '" + txt_username.Text + "' ,'" + txt_password.Text + "' , '" + list_Securityques.SelectedItem.Text + "' , '" + txt_securityans.Text + "')";
            SqlCommand cmd2 = new SqlCommand(query3,conn);
            int val2 = cmd2.ExecuteNonQuery();
            if (val2 > 0)
            {
                Response.Write("Passport User Login details added successfully");

            }
            else
            {
                Response.Write("Data Insertion failed");
            }
        }
    }
}