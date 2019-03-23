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
    public partial class Course : System.Web.UI.Page
    {
        SqlConnection con = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
                Response.Redirect("~/LogIn.aspx", true);

            if (!IsPostBack){
                LoadGrid();
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
            string query = "select * from Course";
            DataTable dt = new DataTable();
            SqlDataAdapter _da = new SqlDataAdapter(query, con);
            _da.Fill(dt);
            gvCourse.DataSource = dt;
            gvCourse.DataBind();
            con.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DbCon();

            SqlCommand cmd = new SqlCommand("insert into Course (CCode,Title,Credit) values (@ccode,@title,@credit)", con);
            cmd.Parameters.AddWithValue("@ccode", tbxCCode.Text.ToString());
            cmd.Parameters.AddWithValue("@title", tbxTitle.Text);
            cmd.Parameters.AddWithValue("@credit",tbxCredit.Text);
            cmd.ExecuteNonQuery();
            lblMessage.Text = "Save Successfully";
            lblMessage.ForeColor = System.Drawing.Color.Green;
            con.Close();
            clearText();
            LoadGrid();
        }
        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            DbCon();
            btnSave.Enabled = false;
            SqlCommand cmd = new SqlCommand("select * from Course where CCode=@ccode", con);
            cmd.Parameters.AddWithValue("@ccode", e.CommandArgument.ToString());
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            if (dt.Rows.Count > 0)
            {
                tbxCCode.Text = dt.Rows[0]["CCode"].ToString();
                tbxTitle.Text = dt.Rows[0]["Title"].ToString();
                tbxCredit.Text = dt.Rows[0]["Credit"].ToString();
            }
            else
            {

            }
            con.Close();
        }
        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                DbCon();

                SqlCommand cmd = new SqlCommand("delete Course where CCode=@ccode", con);
                cmd.Parameters.AddWithValue("@ccode", e.CommandArgument.ToString());
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DbCon();

                SqlCommand cmd = new SqlCommand("update Course set Title=@Title, Credit=@Credit where CCode=@CCode", con);

                cmd.Parameters.AddWithValue("@CCode", tbxCCode.Text);
                cmd.Parameters.AddWithValue("@Title", tbxTitle.Text);
                cmd.Parameters.AddWithValue("@Credit", tbxCredit.Text);

                cmd.ExecuteNonQuery();
                lblMessage.Text = "Updated Successfully";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                clearText();
                con.Close();
                LoadGrid();
                btnSave.Enabled = true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void clearText() {
            tbxCCode.Text = tbxCredit.Text = tbxTitle.Text = "";
        }
    }
}