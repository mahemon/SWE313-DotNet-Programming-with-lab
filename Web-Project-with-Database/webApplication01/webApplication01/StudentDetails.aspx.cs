using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webApplication01
{
    public partial class StudentDetails : System.Web.UI.Page
    {
       int StudentID
        {
            set { ViewState["StudentID"] = value; }
            get{
                try{
                    return Convert.ToInt32(ViewState["StudentID"].ToString());
                }
                catch{
                    return 0;
                }
            }
        }
        SqlConnection con = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
                Response.Redirect("~/LogIn.aspx", true);

            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    StudentID = Convert.ToInt32(Request.QueryString["ID"].ToString());
                    Session["StudentID"] = StudentID;
                    LoadInfoDetails();
                }
            }
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

        private void LoadInfoDetails()
        {
            DbCon();
            SqlCommand cmd = new SqlCommand("select * from StudentInfo where ID=@id", con);
            cmd.Parameters.AddWithValue("@id", StudentID);
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            if (dt.Rows.Count > 0)
            {
                lblID.Text = dt.Rows[0]["ID"].ToString();
                lblName.Text = dt.Rows[0]["Name"].ToString();
                lblFName.Text = dt.Rows[0]["FName"].ToString();
                lblMName.Text = dt.Rows[0]["MName"].ToString();
                lblAddress.Text = dt.Rows[0]["Address"].ToString();
            }
            else
            {

            }
            con.Close();
        }
    }
}