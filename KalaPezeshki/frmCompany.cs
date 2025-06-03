using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalaPezeshki
{
    public partial class frmCompany: Form
    {

        public frmCompany()
        {
            InitializeComponent();
        }

        // تعریف اتصال به پایگاه داده SQL Server
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");

        // تعریف شیء فرمان SQL برای اجرای دستورات
        SqlCommand cmd = new SqlCommand();
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear(); // پاکسازی پارامترها
                cmd.Connection = con; // تعیین اتصال
                cmd.CommandText = "insert into Company(NameC,Tel,Address,Tozih)values(@a,@b,@c,@d)";
                cmd.Parameters.AddWithValue("@a", txtName.Text);
                cmd.Parameters.AddWithValue("@b", txtTel.Text);
                cmd.Parameters.AddWithValue("@c", txtAddress.Text);
                cmd.Parameters.AddWithValue("@d", txtTozih.Text);
                con.Open();
                cmd.ExecuteNonQuery(); // اجرای دستور
                con.Close();
                MessageBox.Show("ثبت اطلاعات با موفقیت انجام شد");
                txtCode.Clear();
                txtName.Clear();
                txtTel.Clear();
                txtAddress.Clear();
                txtTozih.Clear();
            }
            catch(Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear(); // پاکسازی پارامترها
                cmd.Connection = con; // تعیین اتصال
                cmd.CommandText = "Delete from Company where id="+txtCode.Text;
                con.Open();
                cmd.ExecuteNonQuery(); // اجرای دستور
                con.Close();
                MessageBox.Show("حذف اطلاعات با موفقیت انجام شد");
                txtCode.Clear();
                txtName.Clear();
                txtTel.Clear();
                txtAddress.Clear();
                txtTozih.Clear();
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
                cmd.Parameters.Clear(); // پاکسازی پارامترها
                cmd.Connection = con; // تعیین اتصال
                cmd.CommandText = "Update Company set NameC='" + txtName.Text + "',Tel='" + txtTel.Text + "',Address='" + txtAddress.Text + "',Tozih='" + txtTozih.Text + "' where id="+txtCode.Text;
                con.Open();
                cmd.ExecuteNonQuery(); // اجرای دستور
                con.Close();
                MessageBox.Show("ویرایش اطلاعات با موفقیت انجام شد");
                txtCode.Clear();
                txtName.Clear();
                txtTel.Clear();
                txtAddress.Clear();
                txtTozih.Clear();
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
            cmd.CommandText = "select * from Company where id=@N";
            cmd.Parameters.AddWithValue("@N", txtCode.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtCode.Text = dr["id"].ToString();
                txtName.Text = dr["NameC"].ToString();
                txtTel.Text = dr["Tel"].ToString();
                txtAddress.Text = dr["Address"].ToString();
                txtTozih.Text = dr["Tozih"].ToString();
            }
            else
            {
                txtCode.Clear();
                txtCode.Focus();
                MessageBox.Show("برای کد وارد شده اطلاعاتی وجود ندارد");
            }
            con.Close();

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            new frmListCompany().ShowDialog();
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            frmHelper.ClearFormFields(this);
        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }
    }
}
