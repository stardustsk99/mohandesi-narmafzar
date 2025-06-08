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
    public partial class frmSandoogh : Form
    {
        public frmSandoogh()
        {
            InitializeComponent();  // مقداردهی اولیه اجزای فرم
        }

        // تعریف اتصال به دیتابیس SQL Server
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");

        // تعریف یک شیء SqlCommand برای اجرای دستورات SQL
        SqlCommand cmd = new SqlCommand();

        /// <summary>
        /// رویداد کلیک دکمه "ثبت" - اطلاعات ورودی کاربر را به جدول Sandoogh وارد می‌کند
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // پاک‌سازی پارامترهای قبلی
                cmd.Parameters.Clear();

                // تنظیم اتصال به دیتابیس
                cmd.Connection = con;

                // آماده‌سازی دستور INSERT
                cmd.CommandText = "Insert into Sandoogh(Ids,NameS,Mablagh,Tozih)values(@a,@b,@c,@d)";

                // افزودن مقادیر پارامترها از کنترل‌های فرم
                cmd.Parameters.AddWithValue("@a", txtCode.Text);
                cmd.Parameters.AddWithValue("@b", txtName.Text);
                cmd.Parameters.AddWithValue("@c", txtMablagh.Text);
                cmd.Parameters.AddWithValue("@d", txtTozih.Text);

                // باز کردن اتصال و اجرای دستور
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

        /// <summary>
        /// رویداد کلیک دکمه "حذف" - رکورد انتخابی را از جدول Sandoogh حذف می‌کند
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // پاک‌سازی پارامترهای قبلی
                cmd.Parameters.Clear();

                // تنظیم اتصال به دیتابیس
                cmd.Connection = con;

                // آماده‌سازی دستور DELETE
                cmd.CommandText = "Delete from Sandoogh where idS=" + txtCode.Text;

                // باز کردن اتصال و اجرای دستور
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

        /// <summary>
        /// رویداد کلیک دکمه "ویرایش" - اطلاعات رکورد انتخابی را در جدول Sandoogh بروزرسانی می‌کند
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // پاک‌سازی پارامترهای قبلی
                cmd.Parameters.Clear();

                // تنظیم اتصال به دیتابیس
                cmd.Connection = con;

                // آماده‌سازی دستور UPDATE
                cmd.CommandText = "Update Sandoogh set Ids='" + txtCode.Text + "',NameS='" + txtName.Text + "',Mablagh='" + txtMablagh.Text + "',Tozih='" + txtTozih.Text + "' where ids=" + txtCode.Text;

                // باز کردن اتصال و اجرای دستور
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // نمایش پیام موفقیت
                MessageBox.Show("ویرایش انجام شد");
            }
            catch (Exception)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            // نمایش فرم لیست صندوق‌ها به صورت دیالوگ (Modal)
            new frmListSandoogh().ShowDialog();
        }

        /// <summary>
        /// رویداد کلیک دکمه "جستجو" - جستجو و بازیابی اطلاعات یک رکورد مشخص از جدول Sandoogh
        /// </summary>
        private void btnS_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader dr;  // خواندن داده‌ها از دیتابیس

                // پاک‌سازی پارامترهای قبلی
                cmd.Parameters.Clear();

                // تنظیم اتصال به دیتابیس
                cmd.Connection = con;

                // آماده‌سازی دستور SELECT برای جستجو بر اساس شناسه (IdS)
                cmd.CommandText = "select * from Sandoogh where IdS=@N";

                // افزودن مقدار پارامتر از کنترل txtCode
                cmd.Parameters.AddWithValue("@N", txtCode.Text);

                // باز کردن اتصال و اجرای دستور
                con.Open();
                dr = cmd.ExecuteReader();

                // اگر رکوردی پیدا شد
                if (dr.Read())
                {
                    // مقداردهی کنترل‌های فرم با داده‌های خوانده شده
                    txtCode.Text = dr["idS"].ToString();
                    txtName.Text = dr["NameS"].ToString();
                    txtMablagh.Text = dr["Mablagh"].ToString();
                    txtTozih.Text = dr["Tozih"].ToString();
                }
                else
                {
                    // در صورت عدم وجود رکورد، فیلد کد خالی شده و فوکوس روی آن قرار می‌گیرد
                    txtCode.Text = "";
                    txtCode.Focus();
                    MessageBox.Show("برای کد وارد شده اطلاعاتی یافت نشد");
                }

                // بستن اتصال دیتابیس
                con.Close();
            }
            catch (Exception ex)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show(" مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        /// <summary>
        /// رویداد بارگذاری فرم - در اینجا خالی است (امکان درج کدهای اولیه فرم وجود دارد)
        /// </summary>
        private void frmSandoogh_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// رویداد کلیک دکمه "پاک‌سازی" - پاک‌سازی تمامی فیلدهای فرم با استفاده از متد کمکی
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            frmHelper.ClearFormFields(this);
        }

        /// <summary>
        /// رویداد تغییر مقدار در کنترل txtMablagh - در حال حاضر بدون پیاده‌سازی
        /// </summary>
        private void txtMablagh_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
