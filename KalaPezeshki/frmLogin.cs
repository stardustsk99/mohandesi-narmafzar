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
    // فرم ورود کاربران به برنامه
    public partial class frmLogin : Form
    {
        // سازنده فرم ورود
        public frmLogin()
        {
            InitializeComponent();
        }

        // رشته اتصال به پایگاه داده
        private const string ConnectionString = "Data source=HAMY\\SQLEXPRESS;initial catalog=medical goods;integrated security=true";

        // تعریف شی‌ء اتصال و فرمان SQL
        SqlConnection con = new SqlConnection(ConnectionString);
        SqlCommand cmd = new SqlCommand();

        // رویداد تغییر متن رمز عبور (در حال حاضر بدون استفاده)
        private void txtPass_TextChanged(object sender, EventArgs e) { }

        // رویداد کلیک بر روی Label1 (در حال حاضر بدون استفاده)
        private void label1_Click(object sender, EventArgs e) { }

        // رویداد تغییر نام کاربری (در حال حاضر بدون استفاده)
        private void txtUName_TextChanged(object sender, EventArgs e) { }

        // رویداد کلیک بر روی Label2 (در حال حاضر بدون استفاده)
        private void label2_Click(object sender, EventArgs e) { }

        // رویداد کلیک دکمه ورود به سیستم
        private void btnSave_Click(object sender, EventArgs e)
        {
            int i = 0;

            // هش کردن پسورد وارد شده توسط کاربر
            string hashedPassword = HashHelper.ComputeSha256Hash(txtPass.Text);

            // تنظیم دستور SQL برای بررسی نام کاربری و پسورد هش شده
            cmd = new SqlCommand("SELECT COUNT(*) FROM Karbar WHERE UName = @N AND Password = @F", con);
            cmd.Parameters.AddWithValue("@N", txtUName.Text);
            cmd.Parameters.AddWithValue("@F", hashedPassword);

            // اجرای دستور و بررسی نتیجه
            con.Open();
            i = (int)cmd.ExecuteScalar();
            con.Close();

            if (i > 0)
            {
                // اگر کاربر معتبر باشد، فرم اصلی باز می‌شود
                new Form1().ShowDialog();
                this.Close();
            }
            else
            {
                // اگر کاربر وجود نداشته باشد
                MessageBox.Show("کاربری با این مشخصات وجود ندارد");
            }
        }

        // رویداد کلیک روی دکمه خروج
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Application.Exit(); // خروج از برنامه
        }

        // رویداد کلیک روی گروه پنل (در حال حاضر بدون استفاده)
        private void groupPanel1_Click(object sender, EventArgs e) { }

        // رویداد کلیک روی تصویر (در حال حاضر بدون استفاده)
        private void pictureBox1_Click(object sender, EventArgs e) { }

        // رویداد تغییر وضعیت چک‌باکس نمایش پسورد
        private void ChkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkPassword.Checked)
            {
                txtPass.PasswordChar = '\0';   // نمایش پسورد
                ChkPassword.Text = "مخفی کردن پسورد";  // متن زمانی که پسورد قابل مشاهده است
            }
            else
            {
                txtPass.PasswordChar = '*';    // مخفی کردن پسورد
                ChkPassword.Text = "نمایش پسورد";  // متن زمانی که پسورد مخفی شده
            }
        }
    }
}
