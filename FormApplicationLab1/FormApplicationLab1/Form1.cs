using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApplicationLab1
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
            loadinfo();
        }
        public void loadinfo() {
           
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("department", typeof(string));
            dataGridView1.DataSource = dt;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2(dt);
            this.Hide();
            obj.Show();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string i = tbxId.Text;
            string n = tbxName.Text;
            string d = tbxDept.Text;
            dt.Rows.Add(i, n, d);

            dataGridView1.DataSource = dt;
        }
    }
}
