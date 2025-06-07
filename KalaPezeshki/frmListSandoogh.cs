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
    public partial class frmListSandoogh : Form
    {
        public frmListSandoogh()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        void Display()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select * from Sandoogh";
            adp.Fill(ds, "Sandoogh");
            dgvSandoogh.DataSource = ds;
            dgvSandoogh.DataMember = "Sandoogh";
            //***************************
            dgvSandoogh.Columns[0].HeaderText = "کد";
            dgvSandoogh.Columns[1].HeaderText = "نام صندوق";
            dgvSandoogh.Columns[2].HeaderText = "موجودی";
            dgvSandoogh.Columns[3].HeaderText = "توضیحات";
            dgvSandoogh.Columns[1].Width = 150;
            dgvSandoogh.Columns[2].Width = 150;
            dgvSandoogh.Columns[3].Width = 300;
        }
        private void frmListSandoogh_Load(object sender, EventArgs e)
        {
            Display();
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "Select * from Sandoogh where NameS like '%' + @S + '%'";
                adp.SelectCommand.Parameters.AddWithValue("@S", txtName.Text + "%");
                adp.Fill(ds, "Sandoogh");
                dgvSandoogh.DataSource = ds;
                dgvSandoogh.DataMember = "Sandoogh";
            }
            catch (Exception ex)
            {
                MessageBox.Show(" مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        private void txtShH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "Select * from Sandoogh where Ids like '%' + @S + '%'";
                adp.SelectCommand.Parameters.AddWithValue("@S", txtShH.Text + "%");
                adp.Fill(ds, "Sandoogh");
                dgvSandoogh.DataSource = ds;
                dgvSandoogh.DataMember = "Sandoogh";
            }
            catch (Exception ex)
            {
                MessageBox.Show(" مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                int x = Convert.ToInt32(dgvSandoogh.SelectedCells[0].Value);
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Sandoogh where IdS=@N";
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
    }
}
