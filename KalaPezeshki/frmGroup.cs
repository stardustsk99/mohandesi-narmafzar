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
    public partial class frmGroup : Form
    {
        public frmGroup()
        {
            InitializeComponent();
        }
        // تعریف اتصال به پایگاه داده SQL Server
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=medical goods;integrated security=true");

        // تعریف شیء فرمان SQL برای اجرای دستورات
        SqlCommand cmd = new SqlCommand();

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into Grooh(NameG)values(@a)";
                cmd.Parameters.AddWithValue("@a", txtName.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ثبت انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Grooh where id=" + txtCode.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("حذف انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Grooh where id=@N";
            cmd.Parameters.AddWithValue("@N", txtCode.Text);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                // مقداردهی به کنترل‌ها از داده‌های بازیابی‌شده
                txtName.Text = dr["NameG"].ToString();
            }
            else
            {
                // اگر رکوردی یافت نشد
                txtCode.Text = "";
                txtCode.Focus();
                MessageBox.Show("برای کد وارد شده اطلاعاتی پیدا نشد");
            }

            con.Close();
        }
    

        private void btnList_Click(object sender, EventArgs e)
        {
            new frmListGroup().ShowDialog();
        }
    }
}
