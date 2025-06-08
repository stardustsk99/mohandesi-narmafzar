using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.ComponentModel;

namespace KalaPezeshki
{
    // ---------------------------------------------------------------------
    // فرم ورود (Login) به سیستم کالاهای پزشکی
    // ---------------------------------------------------------------------
    public partial class frmLogin : Form
    {
        // ---------------------------------------------------------------------
        // سازنده فرم - مقداردهی اولیه کنترل‌ها
        // ---------------------------------------------------------------------
        public frmLogin()
        {
            InitializeComponent();
        }

        // ---------------------------------------------------------------------
        // تعریف اتصال به دیتابیس SQL Server
        // ---------------------------------------------------------------------
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");

        // ---------------------------------------------------------------------
        // تعریف شیء فرمان SQL برای اجرای دستورات
        // ---------------------------------------------------------------------
        SqlCommand cmd = new SqlCommand();

        // ---------------------------------------------------------------------
        // متد کمکی برای تشخیص حالت طراحی (Design Mode)
        // ---------------------------------------------------------------------
        private bool IsDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;
        }

        // ---------------------------------------------------------------------
        // توابع خالی که Designer به آن‌ها وصل شده است (نباید حذف شوند)
        // ---------------------------------------------------------------------
        private void txtPass_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void txtUName_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void btnSave_Click(object sender, EventArgs e) { }
        private void groupPanel1_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void frmLogin1_Load(object sender, EventArgs e) { }

        // ---------------------------------------------------------------------
        // رویداد کلیک دکمه "ورود" - بررسی صحت نام کاربری و کلمه عبور
        // ---------------------------------------------------------------------
        private void btnIn_Click(object sender, EventArgs e)
        {
            // جلوگیری از اجرای کد در حالت Design Mode
            if (IsDesignMode()) return;

            try
            {
                // محاسبه هش رمز عبور
                string hashedPassword = HashHelper.ComputeSha256Hash(txtPass.Text);

                // تعریف Query بررسی نام کاربری و رمز عبور
                string query = "SELECT UName, Role FROM Karbar WHERE UName = @N AND Password = @F";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@N", txtUName.Text);
                cmd.Parameters.AddWithValue("@F", hashedPassword);

                // اجرای Query
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // اگر کاربر معتبر پیدا شد
                if (reader.Read())
                {
                    // ذخیره نام کاربری و نقش کاربر در UserSession
                    frmHelper.UserSession.Username = reader["UName"].ToString();
                    frmHelper.UserSession.Role = reader["Role"].ToString();

                    // بستن Reader و Connection
                    reader.Close();
                    con.Close();

                    // خروج موفق و بستن فرم
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // کاربر پیدا نشد
                    con.Close();
                    MessageBox.Show("کاربری با این مشخصات وجود ندارد");
                }
            }
            catch (Exception ex)
            {
                // مدیریت خطا
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();

                MessageBox.Show("خطا در اتصال به پایگاه داده:\n" + ex.Message);
            }
        }
        // ---------------------------------------------------------------------
        // رویداد کلیک دکمه "خروج" - بستن فرم Login بدون ورود
        // ---------------------------------------------------------------------
        private void btnOut_Click(object sender, EventArgs e)
        {
            // جلوگیری از اجرای کد در حالت Design Mode
            if (IsDesignMode()) return;

            // خروج بدون ورود (Cancel)
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // ---------------------------------------------------------------------
        // رویداد تغییر وضعیت چک‌باکس نمایش/مخفی‌سازی رمز عبور
        // ---------------------------------------------------------------------
        private void ChkPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ChkPassword.Checked)
            {
                // نمایش رمز عبور
                txtPass.PasswordChar = '\0';
            }
            else
            {
                // مخفی کردن رمز عبور
                txtPass.PasswordChar = '*';
            }
        }

        // ---------------------------------------------------------------------
        // رویداد تغییر متن txtUName (فعلاً استفاده‌نشده)
        // ---------------------------------------------------------------------
        private void txtUName_TextChanged_1(object sender, EventArgs e)
        {
            // این رویداد فعلاً استفاده نشده است (می‌تواند برای اعتبارسنجی آنلاین نام کاربری استفاده شود)

        }
    }
}
    // پایان کلاس frmLogin