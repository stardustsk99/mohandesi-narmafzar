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
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand();

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
            dgvUser.Columns[4].HeaderText = "نقش";


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
                if (txtPass.Text != txtPassRep.Text)
                {
                    MessageBox.Show("کلمه عبور یا تکرار آن برابر نیست");
                    return;
                }
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

                // *** بررسی نام کاربری تکراری ***
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Karbar WHERE UName = @UName", con);
                checkCmd.Parameters.AddWithValue("@UName", txtUName.Text);

                con.Open();
                int count = (int)checkCmd.ExecuteScalar();
                con.Close();

                if (count > 0)
                {
                    MessageBox.Show("این نام کاربری قبلاً ثبت شده است.");
                    return;
                }

                // هش‌کردن رمز عبور با استفاده از SHA-256
                string hashedPassword = HashHelper.ComputeSha256Hash(password);

                // درج اطلاعات کاربر در دیتابیس
                cmd.CommandText = "INSERT INTO Karbar(UName, Password, PhoneNumber, Role) VALUES(@a, @b, @c, @d)";
                cmd.Parameters.AddWithValue("@a", txtUName.Text);
                cmd.Parameters.AddWithValue("@b", hashedPassword);
                cmd.Parameters.AddWithValue("@c", phone);
                cmd.Parameters.AddWithValue("@d", cmbRole.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Display(); // نمایش مجدد داده‌ها پس از ذخیره
                MessageBox.Show("ثبت انجام شد");
                frmHelper.ClearFormFields(this);
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
                if (con.State == ConnectionState.Open)
                    con.Close();
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
                frmHelper.ClearFormFields(this);

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

                string updateQuery = "UPDATE Karbar SET ";
                List<string> fieldsToUpdate = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrWhiteSpace(txtUName.Text))
                {
                    fieldsToUpdate.Add("UName = @UName");
                    parameters.Add(new SqlParameter("@UName", txtUName.Text));
                }
                string password = txtPass.Text;
                string hashedPassword = HashHelper.ComputeSha256Hash(password);

                if (!string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    fieldsToUpdate.Add("Password = @Password");
                    parameters.Add(new SqlParameter("@Password", hashedPassword));
                }
                if (!string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                {
                    fieldsToUpdate.Add("PhoneNumber = @PhoneNumber");
                    parameters.Add(new SqlParameter("@PhoneNumber", txtPhoneNumber.Text));
                }

                if (!string.IsNullOrWhiteSpace(cmbRole.Text))
                {
                    fieldsToUpdate.Add("Role = @Role");
                    parameters.Add(new SqlParameter("@Role", cmbRole.Text));
                }
                if (fieldsToUpdate.Count > 0)
                {
                    updateQuery += string.Join(", ", fieldsToUpdate);
                    updateQuery += " WHERE id = @id";

                    SqlCommand cmd = new SqlCommand(updateQuery, con);
                    cmd.Parameters.AddRange(parameters.ToArray());
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dgvUser.SelectedCells[0].Value));

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Display();
                    MessageBox.Show("ویرایش انجام شد");
                    frmHelper.ClearFormFields(this);

                }
                else
                {
                    MessageBox.Show("هیچ فیلدی برای آپدیت وارد نشده است.");
                }

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
            txtPhoneNumber.Text = dgvUser[3, dgvUser.CurrentRow.Index].Value.ToString();
            cmbRole.Text = dgvUser[4, dgvUser.CurrentRow.Index].Value.ToString();

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
                txtPassRep.PasswordChar= '\0';
                ChkPassword.Text = "مخفی کردن پسورد";
            }
            else
            {
                txtPass.PasswordChar = '*'; // مخفی کردن رمز عبور
                txtPassRep.PasswordChar = '*';
                ChkPassword.Text = "نمایش پسورد";
            }
        }

        private void frmUser_Load(object sender, EventArgs e) 
        {
            Display();
        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }
    }
}
