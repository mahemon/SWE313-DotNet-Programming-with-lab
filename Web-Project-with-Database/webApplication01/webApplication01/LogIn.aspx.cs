using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace webApplication01
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void DbCon()
        {
            try
            {
                String strCon = "Data Source=DESKTOP-DK4F0I6\\SAIF;Initial Catalog=UniversitySystem;Integrated Security=True";
                con = new SqlConnection(strCon);
                con.Open();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            String userName = tbxUserName.Text;
            String password = tbxPassword.Text;

            DbCon();
           
            SqlCommand cmd = new SqlCommand("select * from LogInInfo where UserName=@userName and Password=@pass", con);
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@pass", password);
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            if (dt.Rows.Count > 0) {
                //session
                Session["UserName"] = dt.Rows[0]["UserName"].ToString();
                Response.Redirect("~/Default.aspx", true);

                //Cookies
                //Response.Cookies["UserName"].Value= dt.Rows[0]["UserName"].ToString();
                //Response.Cookies["UserName"].Expires = DateTime.Now.AddHours(1);
               
                //OR
                //HttpCookie cok = new HttpCookie("cookieName");
                //cok.Value= dt.Rows[0]["UserName"].ToString();
                //cok.Expires = DateTime.Now.AddHours(1);
                //Response.Cookies.Add(cok);

            }
            else {
                lblMessage.Text = "Login Failed";
            }
            con.Close();
        }
    }
}