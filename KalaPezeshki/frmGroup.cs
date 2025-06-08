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
        // ---------------------------------------------------------------------
        // سازنده‌ی فرم
        // ---------------------------------------------------------------------
        public frmGroup()
        {
            InitializeComponent();
        }

        // ---------------------------------------------------------------------
        // تعریف اتصال به پایگاه داده SQL Server
        // ---------------------------------------------------------------------
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");

        // ---------------------------------------------------------------------
        // تعریف شیء فرمان SQL برای اجرای دستورات
        // ---------------------------------------------------------------------
        SqlCommand cmd = new SqlCommand();

        // ---------------------------------------------------------------------
        // دکمه ذخیره نام گروه جدید در جدول Grooh
        // ---------------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Grooh (NameG) VALUES (@a)";
                cmd.Parameters.AddWithValue("@a", txtName.Text);

                // اجرای دستور درج اطلاعات
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // نمایش پیام موفقیت
                MessageBox.Show("ثبت انجام شد");
            }
            catch (Exception)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // ---------------------------------------------------------------------
        // دکمه حذف گروه از جدول Grooh بر اساس شناسه
        // ---------------------------------------------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Grooh WHERE id=" + txtCode.Text;

                // اجرای دستور حذف
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // نمایش پیام موفقیت
                MessageBox.Show("حذف انجام شد");
            }
            catch (Exception)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // ---------------------------------------------------------------------
        // دکمه جستجوی گروه بر اساس شناسه
        // ---------------------------------------------------------------------
        private void btnS_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader dr;

                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Grooh WHERE id=@N";
                cmd.Parameters.AddWithValue("@N", txtCode.Text);

                // اجرای فرمان و دریافت نتیجه
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
            catch (Exception ex)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        // ---------------------------------------------------------------------
        // دکمه نمایش لیست گروه‌ها
        // ---------------------------------------------------------------------
        private void btnList_Click(object sender, EventArgs e)
        {
            new frmListGroup().ShowDialog();
        }

        // ---------------------------------------------------------------------
        // رویداد بارگذاری فرم (فعلاً بدون عملیات خاص)
        // ---------------------------------------------------------------------
        private void frmGroup_Load(object sender, EventArgs e)
        {
        }
    }
}