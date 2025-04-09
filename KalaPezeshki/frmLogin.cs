using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace KalaPezeshki
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int i = 0;
            cmd = new SqlCommand("select count(*) from karbar where UName=@N AND Password=@F", con);
            cmd.Parameters.AddWithValue("@N", txtUName.Text);
            cmd.Parameters.AddWithValue("@F", txtPass.Text);
            con.Open();
            i = (int)cmd.ExecuteScalar();
            con.Close();
            if (i > 0)
            {
                new Form1().ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("کاربری با این مشخصات وجود ندارد");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
