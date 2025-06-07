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
    public partial class frmCompany : Form
    {
        // ---------------------------------------------------------------------
        // سازنده‌ی فرم
        // ---------------------------------------------------------------------
        public frmCompany()
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
        // رویداد کلیک روی label5 (فعلاً استفاده نشده)
        // ---------------------------------------------------------------------
        private void label5_Click(object sender, EventArgs e)
        {
        }

        // ---------------------------------------------------------------------
        // رویداد کلیک روی label4 (فعلاً استفاده نشده)
        // ---------------------------------------------------------------------
        private void label4_Click(object sender, EventArgs e)
        {
        }

        // ---------------------------------------------------------------------
        // دکمه ذخیره اطلاعات شرکت
        // ---------------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear(); // پاکسازی پارامترها
                cmd.Connection = con;   // تعیین اتصال
                cmd.CommandText = "INSERT INTO Company (NameC, Tel, Address, Tozih) VALUES (@a, @b, @c, @d)";

                // تنظیم پارامترها با مقادیر واردشده در فرم
                cmd.Parameters.AddWithValue("@a", txtName.Text);
                cmd.Parameters.AddWithValue("@b", txtTel.Text);
                cmd.Parameters.AddWithValue("@c", txtAddress.Text);
                cmd.Parameters.AddWithValue("@d", txtTozih.Text);

                // اجرای دستور درج (Insert)
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // نمایش پیام موفقیت
                MessageBox.Show("ثبت اطلاعات با موفقیت انجام شد");

                // پاک‌سازی فیلدهای فرم پس از ذخیره
                frmHelper.ClearFormFields(this);
            }
            catch (Exception)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // ---------------------------------------------------------------------
        // دکمه حذف اطلاعات شرکت بر اساس شناسه
        // ---------------------------------------------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear(); // پاکسازی پارامترها
                cmd.Connection = con;   // تعیین اتصال
                cmd.CommandText = "DELETE FROM Company WHERE id=" + txtCode.Text;

                // اجرای دستور حذف (Delete)
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // نمایش پیام موفقیت
                MessageBox.Show("حذف اطلاعات با موفقیت انجام شد");

                // پاک‌سازی فیلدهای فرم پس از حذف
                frmHelper.ClearFormFields(this);
            }
            catch (Exception)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // ---------------------------------------------------------------------
        // دکمه ویرایش اطلاعات شرکت
        // ---------------------------------------------------------------------
        private void btnEdite_Click(object sender, EventArgs e)
        {
            try
            {
                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear(); // پاکسازی پارامترها
                cmd.Connection = con;   // تعیین اتصال
                cmd.CommandText = "UPDATE Company SET " +
                                  "NameC='" + txtName.Text + "', " +
                                  "Tel='" + txtTel.Text + "', " +
                                  "Address='" + txtAddress.Text + "', " +
                                  "Tozih='" + txtTozih.Text + "' " +
                                  "WHERE id=" + txtCode.Text;

                // اجرای دستور به‌روزرسانی (Update)
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // نمایش پیام موفقیت
                MessageBox.Show("ویرایش اطلاعات با موفقیت انجام شد");

                // پاک‌سازی فیلدهای فرم پس از ویرایش
                frmHelper.ClearFormFields(this);
            }
            catch (Exception)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }
        // ---------------------------------------------------------------------
        // دکمه جستجوی اطلاعات شرکت بر اساس شناسه
        // ---------------------------------------------------------------------
        private void btnS_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader dr;

                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Company WHERE id=@N";
                cmd.Parameters.AddWithValue("@N", txtCode.Text);

                // اجرای فرمان و دریافت نتایج
                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // نمایش اطلاعات شرکت در فیلدهای فرم
                    txtCode.Text = dr["id"].ToString();
                    txtName.Text = dr["NameC"].ToString();
                    txtTel.Text = dr["Tel"].ToString();
                    txtAddress.Text = dr["Address"].ToString();
                    txtTozih.Text = dr["Tozih"].ToString();
                }
                else
                {
                    // در صورت عدم یافتن اطلاعات برای شناسه وارد شده
                    txtCode.Clear();
                    txtCode.Focus();
                    MessageBox.Show("برای کد وارد شده اطلاعاتی وجود ندارد");
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
        // دکمه نمایش لیست اطلاعات شرکت‌ها
        // ---------------------------------------------------------------------
        private void btnList_Click(object sender, EventArgs e)
        {
            new frmListCompany().ShowDialog();
        }

        // ---------------------------------------------------------------------
        // رویداد بارگذاری فرم (فعلاً بدون عملیات خاص)
        // ---------------------------------------------------------------------
        private void frmCompany_Load(object sender, EventArgs e)
        {
        }

        // ---------------------------------------------------------------------
        // دکمه پاک‌سازی فیلدهای فرم
        // ---------------------------------------------------------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            frmHelper.ClearFormFields(this);
        }

        // ---------------------------------------------------------------------
        // رویداد کلیک روی گروه (فعلاً استفاده نشده)
        // ---------------------------------------------------------------------
        private void groupPanel3_Click(object sender, EventArgs e)
        {
        }

        // ---------------------------------------------------------------------
        // رویداد تغییر متن شماره تلفن (فعلاً استفاده نشده)
        // ---------------------------------------------------------------------
        private void txtTel_TextChanged(object sender, EventArgs e)
        {
        }

    } // پایان کلاس frmCompany
} // پایان فضای نام KalaPezeshki