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
    public partial class Teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
        SqlConnection con = null;
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
            string query = "select * from Teacher";
            DataTable dt = new DataTable();
            SqlDataAdapter _da = new SqlDataAdapter(query, con);
            _da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            con.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DbCon();

            string query = @"INSERT INTO [Teacher]
               ([TID]
               ,[TName]
               ,[Designation])
             VALUES
                   ('" + tbxID.Text + "', '" + tbxName.Text + "', '" +  tbxDes.Text + "')";
            SqlCommand _cmd = new SqlCommand(query, con);
            _cmd.ExecuteNonQuery();
            con.Close();
            LoadGrid();

        }
    }
}