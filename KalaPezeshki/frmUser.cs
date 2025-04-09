using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KalaPezeshki
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        void Display()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select * from Karbar";
            adp.Fill(ds, "Karbar");
            dgvUser.DataSource = ds;
            dgvUser.DataMember = "Karbar";
            //***************************
            dgvUser.Columns[0].HeaderText = "کد";
            dgvUser.Columns[1].HeaderText = "نام کاربری";
            dgvUser.Columns[2].HeaderText = "کلمه عبور";
        }
        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Insert into Karbar(UName,Password)Values(@a,@b)";
                    cmd.Parameters.AddWithValue("@a", txtUName.Text);
                    cmd.Parameters.AddWithValue("@b", txtPass.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Display();
                    MessageBox.Show("ثبت انجام شد");
                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی پیش آمده است");
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
                try
                {
                    int x = Convert.ToInt32(dgvUser.SelectedCells[0].Value);
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Delete From Karbar where id=@N";
                    cmd.Parameters.AddWithValue("@N", x);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Display();
                    MessageBox.Show("حذف انجام شد");
                }
                catch (Exception)
                {
                    MessageBox.Show("مشکلی پیش آمده است");
            }

        }

        private void btnEdite_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Update Karbar set UName='" + txtUName.Text + "',Password='" + txtPass.Text + "' where id=" + Convert.ToInt32(dgvUser.SelectedCells[0].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("ویرایش انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        private void dgvUser_MouseUp(object sender, MouseEventArgs e)
        {
            txtUName.Text = dgvUser[1, dgvUser.CurrentRow.Index].Value.ToString();
            txtPass.Text = dgvUser[1, dgvUser.CurrentRow.Index].Value.ToString();
        }

        private void txtUName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
