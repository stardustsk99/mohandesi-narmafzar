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
    public partial class frmLogin: Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        // رشته اتصال به پایگاه داده
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");

        // تعریف شی‌ء اتصال و فرمان SQL
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

        }

        // رویداد کلیک روی دکمه خروج
 
        // رویداد کلیک روی گروه پنل (در حال حاضر بدون استفاده)
        private void groupPanel1_Click(object sender, EventArgs e) { }

        // رویداد کلیک روی تصویر (در حال حاضر بدون استفاده)
        private void pictureBox1_Click(object sender, EventArgs e) { }

        // رویداد تغییر وضعیت چک‌باکس نمایش پسورد

        private void frmLogin1_Load(object sender, EventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            // هش کردن پسورد وارد شده
            string hashedPassword = HashHelper.ComputeSha256Hash(txtPass.Text);

            // دستور SQL برای بازیابی اطلاعات کاربر
            string query = "SELECT UName, Role FROM Karbar WHERE UName = @N AND Password = @F";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@N", txtUName.Text);
            cmd.Parameters.AddWithValue("@F", hashedPassword);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read()) // اگر کاربر پیدا شد
            {
                // ذخیره اطلاعات در UserSession (کلاس کمکی شما)
                frmHelper.UserSession.Username = reader["UName"].ToString();
                frmHelper.UserSession.Role = reader["Role"].ToString();

                reader.Close();
                con.Close();

                // باز کردن فرم اصلی
                new Form1().Show();
                this.Hide();
            }
            else
            {
                con.Close();
                MessageBox.Show("کاربری با این مشخصات وجود ندارد");
            }
        }


        private void btnOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ChkPassword_CheckedChanged_1(object sender, EventArgs e)
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
