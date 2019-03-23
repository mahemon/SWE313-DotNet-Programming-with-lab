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
    public partial class CourseAssign : System.Web.UI.Page
    {
        SqlConnection con = null;
        protected void Page_Load(object sender, EventArgs e)
        {
           // if (Session["UserName"] == null)
              //  Response.Redirect("~/LogIn.aspx", true);

            if (!IsPostBack)
            {
                LoadGrid();
                LoadStudentList();
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
        private void LoadGrid()
        {
            DbCon();
            string query = @"select TKID, StudentInfo.ID, Name, Course.CCode, Title, Credit
                            from StudentInfo inner join CourseTaken on StudentInfo.ID = CourseTaken.ID
                            inner join Course on CourseTaken.CCode = Course.CCode
                            order by StudentInfo.ID asc";
            DataTable dt = new DataTable();
            SqlDataAdapter _da = new SqlDataAdapter(query, con);
            _da.Fill(dt);
            if (dt.Rows.Count > 0) {
                gvCT.DataSource = dt;
                gvCT.DataBind();
            }
            con.Close();
        }
        protected void LoadStudentList()
        {
            DbCon();
            string query = "select * from StudentInfo";
            DataTable dt = new DataTable();
            SqlDataAdapter _da = new SqlDataAdapter(query, con);
            _da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlStudent.SelectedValue = dt.Rows[0]["ID"].ToString();
                ddlStudent.DataSource = dt;
                ddlStudent.DataBind();
            }
            else {
                ddlStudent.DataSource = dt;
                ddlStudent.DataBind();
            }
                con.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DbCon();

            String code = ddlCourse.SelectedValue;
            int id = Convert.ToInt32(ddlStudent.SelectedValue);

            SqlCommand cmd = new SqlCommand("insert into CourseTaken (CCode,ID) values (@code,@id)", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@code", code);

            cmd.ExecuteNonQuery();
            lblMessage.Text = "Save Successfully";
            lblMessage.ForeColor = System.Drawing.Color.Green;
            con.Close();
            LoadGrid();
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e) {
            try{
                DbCon();

                SqlCommand cmd = new SqlCommand("delete CourseTaken where TKID=@id", con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(e.CommandArgument.ToString()));
                cmd.ExecuteNonQuery();
                lblMessage.Text = "Delete Successfully";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                con.Close();
                LoadGrid();
            }
            catch (Exception ex)
            {

            }
        }
    }
}