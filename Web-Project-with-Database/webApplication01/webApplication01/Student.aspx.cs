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
    public partial class Student : System.Web.UI.Page
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
        protected void DbCon() {
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
            string query = "select * from StudentInfo";
            DataTable dt = new DataTable();
            SqlDataAdapter _da = new SqlDataAdapter(query, con);
            _da.Fill(dt);
            if (dt.Rows.Count > 0){
                gvStudent.DataSource = dt;
                gvStudent.DataBind();
            }
            else{
                gvStudent.DataSource = dt;
                gvStudent.DataBind();
            }
            con.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DbCon();

            //string query = @"INSERT INTO [StudentInfo]
            //   ([ID]
            //   ,[Name]
            //   ,[FName]
            //   ,[MName]
            //   ,[Address])
            // VALUES
            //       ('" + tbxID.Text + "', '" + tbxName.Text + "', '" + tbxFName.Text + "', '" + tbxName.Text + "', '" + tbxAddress.Text + "')";
            //SqlCommand _cmd = new SqlCommand(query, con);
            //_cmd.ExecuteNonQuery();
            //con.Close();
            //LoadGrid();

            SqlCommand cmd = new SqlCommand("insert into StudentInfo (ID,Name,FName, MName, Address) values (@id,@name,@fname,@mname,@address)", con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(tbxID.Text.ToString().Trim()));
            cmd.Parameters.AddWithValue("@name", tbxName.Text);
            cmd.Parameters.AddWithValue("@fname", tbxFName.Text);
            cmd.Parameters.AddWithValue("@mname", tbxMName.Text);
            cmd.Parameters.AddWithValue("@address", tbxAddress.Text);
            cmd.ExecuteNonQuery();
            lblMessage.Text = "Save Successfully";
            lblMessage.ForeColor = System.Drawing.Color.Green;
            con.Close();
            LoadGrid();
        }
        protected void btnEdit_Command(object sender, CommandEventArgs e){
            DbCon();
            SqlCommand cmd = new SqlCommand("select * from StudentInfo where ID=@id", con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(e.CommandArgument.ToString()));
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            if (dt.Rows.Count > 0)
            {
                tbxID.Text = dt.Rows[0]["ID"].ToString();
                tbxName.Text = dt.Rows[0]["Name"].ToString();
                tbxFName.Text = dt.Rows[0]["FName"].ToString();
                tbxMName.Text = dt.Rows[0]["MName"].ToString();
                tbxAddress.Text = dt.Rows[0]["Address"].ToString();
            }
            else {

            }
            con.Close();
        }
        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            try
            {
                DbCon();

                SqlCommand cmd = new SqlCommand("delete StudentInfo where ID=@id", con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(e.CommandArgument.ToString()));
                cmd.ExecuteNonQuery();
                lblMessage.Text = "Delete Successfully";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                con.Close();
                LoadGrid();
            }
            catch (Exception ex){

            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e) {
            try
            {
                DbCon();

                SqlCommand cmd = new SqlCommand("update StudentInfo set Name=@name,FName=@fname, MName=@mname, Address=@address where ID=@id", con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(tbxID.Text.ToString()));
                cmd.Parameters.AddWithValue("@name", tbxName.Text);
                cmd.Parameters.AddWithValue("@fname", tbxFName.Text);
                cmd.Parameters.AddWithValue("@mname", tbxMName.Text);
                cmd.Parameters.AddWithValue("@address", tbxAddress.Text);
                cmd.ExecuteNonQuery();
                lblMessage.Text = "Updated Successfully";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                con.Close();
                LoadGrid();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}