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
using System.Security.Cryptography;


// فضای نام اصلی فرم مدیریت کاربران در سیستم کالاهای پزشکی
namespace KalaPezeshki
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent(); // مقداردهی اولیه کنترل‌های فرم
        }

        // تعریف اتصال به دیتابیس SQL Server
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=medical goods;integrated security=true");
        SqlCommand cmd = new SqlCommand(); // شی فرمان SQL برای اجرای دستورات

        // متدی برای نمایش اطلاعات کاربران در DataGridView
        void Display()
        {
            DataSet ds = new DataSet(); // مجموعه داده‌ها برای ذخیره نتیجه
            SqlDataAdapter adp = new SqlDataAdapter(); // آداپتور برای پر کردن DataSet
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select * from Karbar"; // بازیابی همه کاربران
            adp.Fill(ds, "Karbar"); // پر کردن دیتاست با داده‌ها
            dgvUser.DataSource = ds;
            dgvUser.DataMember = "Karbar";

            // تنظیم عنوان ستون‌های جدول نمایش داده شده
            dgvUser.Columns[0].HeaderText = "کد";
            dgvUser.Columns[1].HeaderText = "نام کاربری";
            dgvUser.Columns[2].HeaderText = "کلمه عبور";
            dgvUser.Columns[3].HeaderText = "شماره تماس";

            // مخفی‌سازی ستون رمز عبور
            dgvUser.Columns[2].Visible = false;
        }

        private void groupPanel3_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // رویداد کلیک دکمه "ذخیره"
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;

                // *** اعتبارسنجی رمز عبور ***
                string password = txtPass.Text;
                if (password.Length < 8)
                {
                    MessageBox.Show("پسورد باید حداقل ۸ کاراکتر داشته باشد.");
                    return;
                }
                if (password.Length > 50)
                {
                    MessageBox.Show("پسورد نمی‌تواند بیشتر از ۵۰ کاراکتر باشد.");
                    return;
                }
                if (!password.Any(char.IsUpper))
                {
                    MessageBox.Show("پسورد باید حداقل یک حرف بزرگ داشته باشد.");
                    return;
                }
                if (!password.Any(char.IsLower))
                {
                    MessageBox.Show("پسورد باید حداقل یک حرف کوچک داشته باشد.");
                    return;
                }
                if (!password.Any(char.IsDigit))
                {
                    MessageBox.Show("پسورد باید حداقل یک عدد داشته باشد.");
                    return;
                }

                // *** اعتبارسنجی شماره تماس ***
                string phone = txtPhoneNumber.Text;
                if (string.IsNullOrWhiteSpace(phone))
                {
                    MessageBox.Show("شماره تماس نمی‌تواند خالی باشد.");
                    return;
                }
                if (!phone.All(char.IsDigit))
                {
                    MessageBox.Show("شماره تماس باید فقط شامل ارقام باشد.");
                    return;
                }
                if (phone.Length != 11)
                {
                    MessageBox.Show("شماره تماس باید دقیقاً ۱۱ رقم باشد.");
                    return;
                }

                // هش‌کردن رمز عبور با استفاده از SHA-256
                string hashedPassword = HashHelper.ComputeSha256Hash(password);

                // درج اطلاعات کاربر در دیتابیس
                cmd.CommandText = "INSERT INTO Karbar(UName, Password, PhoneNumber) VALUES(@a, @b, @c)";
                cmd.Parameters.AddWithValue("@a", txtUName.Text);
                cmd.Parameters.AddWithValue("@b", hashedPassword);
                cmd.Parameters.AddWithValue("@c", phone);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Display(); // نمایش مجدد داده‌ها پس از ذخیره
                MessageBox.Show("ثبت انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // رویداد کلیک دکمه "حذف"
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvUser.SelectedCells[0].Value); // دریافت ID کاربر
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete From Karbar where id=@N";
                cmd.Parameters.AddWithValue("@N", x);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display(); // بروزرسانی نمایش داده‌ها
                MessageBox.Show("حذف انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // رویداد کلیک دکمه "ویرایش"
        private void btnEdite_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;

                // به‌روزرسانی اطلاعات کاربر در دیتابیس (رمز عبور بدون هش)
                cmd.CommandText = "Update Karbar set UName='" + txtUName.Text + "',Password='" + txtPass.Text + "' where id=" + Convert.ToInt32(dgvUser.SelectedCells[0].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display(); // بروزرسانی داده‌ها پس از ویرایش
                MessageBox.Show("ویرایش انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // واکشی اطلاعات ردیف انتخاب‌شده و نمایش در کنترل‌ها
        private void dgvUser_MouseUp(object sender, MouseEventArgs e)
        {
            txtUName.Text = dgvUser[1, dgvUser.CurrentRow.Index].Value.ToString();
            txtPass.Text = dgvUser[1, dgvUser.CurrentRow.Index].Value.ToString(); // نمایش پسورد بدون رمزنگاری (غیرامن)
        }

        private void txtUName_TextChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void txtPhoneNumber_TextChanged(object sender, EventArgs e) { }

        // رویداد تغییر وضعیت چک‌باکس نمایش/مخفی‌سازی رمز عبور
        private void ChkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkPassword.Checked)
            {
                txtPass.PasswordChar = '\0'; // نمایش رمز عبور
                ChkPassword.Text = "مخفی کردن پسورد";
            }
            else
            {
                txtPass.PasswordChar = '*'; // مخفی کردن رمز عبور
                ChkPassword.Text = "نمایش پسورد";
            }
        }

        private void frmUser_Load(object sender, EventArgs e) { }
    }
}
