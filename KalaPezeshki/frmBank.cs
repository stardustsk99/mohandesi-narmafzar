using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KalaPezeshki
{
    public partial class frmBank : Form
    {
        // ---------------------------------------------------------------------
        // تعریف اتصال به پایگاه‌داده SQL Server
        // ---------------------------------------------------------------------
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        // ---------------------------------------------------------------------
        // سازنده‌ی فرم
        // ---------------------------------------------------------------------
        public frmBank()
        {
            InitializeComponent();
        }

        // ---------------------------------------------------------------------
        // متد کمکی برای پاک‌سازی فیلدهای متنی فرم (به‌صورت بازگشتی)
        // * فراخوانی از frmHelper.ClearFormFields(this) در رویدادهای مختلف *
        // ---------------------------------------------------------------------

        // ---------------------------------------------------------------------
        // ذخیره اطلاعات جدید در جدول Bank
        // ---------------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Bank(NameAcct, Bank, AcctNum, Balance, Tozih) VALUES (@a, @b, @c, @d, @e)";

                // تنظیم پارامترها با مقادیر واردشده در فرم
                cmd.Parameters.AddWithValue("@a", txtNameAcct.Text);
                cmd.Parameters.AddWithValue("@b", txtBankName.Text);
                cmd.Parameters.AddWithValue("@c", txtAcctNum.Text);
                cmd.Parameters.AddWithValue("@d", txtBalance.Text);
                cmd.Parameters.AddWithValue("@e", txtTozih.Text);

                // اجرای دستور درج (Insert)
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // نمایش پیام موفقیت
                MessageBox.Show("✅ حساب با موفقیت اضافه شد");

                // پاک‌سازی فیلدها پس از ذخیره
                frmHelper.ClearFormFields(this);
            }
            catch (Exception)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("⚠️ مشکلی در هنگام ذخیره اطلاعات رخ داده است");
            }
        }

        // ---------------------------------------------------------------------
        // حذف حساب بر اساس شناسه وارد شده
        // ---------------------------------------------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Bank WHERE id=@N";

                // تنظیم شناسه حساب برای حذف
                cmd.Parameters.AddWithValue("@N", txtCode.Text);

                // اجرای دستور حذف (Delete)
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // نمایش پیام موفقیت
                MessageBox.Show("🗑 حساب با موفقیت حذف شد");

                // پاک‌سازی فرم پس از حذف
                frmHelper.ClearFormFields(this);
            }
            catch (Exception)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("⚠️ مشکلی در هنگام حذف اطلاعات رخ داده است");
            }
        }

        // ---------------------------------------------------------------------
        // ویرایش اطلاعات حساب موجود بر اساس شناسه
        // ---------------------------------------------------------------------
        private void btnEdite_Click(object sender, EventArgs e)
        {
            try
            {
                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText =
                    "UPDATE Bank SET NameAcct=@a, Bank=@b, AcctNum=@c, Balance=@d, Tozih=@e WHERE id=" + txtCode.Text;

                // تنظیم پارامترها با مقادیر واردشده در فرم
                cmd.Parameters.AddWithValue("@a", txtNameAcct.Text);
                cmd.Parameters.AddWithValue("@b", txtBankName.Text);
                cmd.Parameters.AddWithValue("@c", txtAcctNum.Text);
                cmd.Parameters.AddWithValue("@d", txtBalance.Text);
                cmd.Parameters.AddWithValue("@e", txtTozih.Text);

                // اجرای دستور به‌روزرسانی (Update)
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // نمایش پیام موفقیت
                MessageBox.Show("✏️ حساب با موفقیت ویرایش شد");

                // پاک‌سازی فیلدها پس از ویرایش
                frmHelper.ClearFormFields(this);
            }
            catch (Exception)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("⚠️ مشکلی در هنگام ویرایش اطلاعات رخ داده است");
            }
        }

        // ---------------------------------------------------------------------
        // جستجو و نمایش اطلاعات حساب بر اساس کد وارد شده
        // ---------------------------------------------------------------------
        private void btnS_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader dr;

                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Bank WHERE id=@N";
                cmd.Parameters.AddWithValue("@N", txtCode.Text);

                // اجرای فرمان و خواندن نتایج
                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // نمایش اطلاعات حساب در فیلدهای فرم
                    txtCode.Text = dr["id"].ToString();
                    txtNameAcct.Text = dr["NameAcct"].ToString();
                    txtBankName.Text = dr["Bank"].ToString();
                    txtAcctNum.Text = dr["AcctNum"].ToString();
                    txtBalance.Text = dr["Balance"].ToString();
                    txtTozih.Text = dr["Tozih"].ToString();
                }
                else
                {
                    // در صورت عدم یافتن اطلاعات
                    txtCode.Clear();
                    txtCode.Focus();
                    MessageBox.Show("❌ اطلاعاتی برای کد وارد شده یافت نشد");
                }

                con.Close();
            }
            catch (Exception)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("⚠️ مشکلی در هنگام جستجوی اطلاعات رخ داده است");
            }
        }
        // ---------------------------------------------------------------------
        // نمایش لیست کامل حساب‌ها در فرم جداگانه
        // ---------------------------------------------------------------------
        private void btnList_Click(object sender, EventArgs e)
        {
            new frmListBank().ShowDialog();
        }

        // ---------------------------------------------------------------------
        // پاک‌سازی تمام فیلدهای فرم
        // ---------------------------------------------------------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            frmHelper.ClearFormFields(this);
        }

        // ---------------------------------------------------------------------
        // رویداد بارگذاری فرم (در حال حاضر بدون عملیات خاص)
        // ---------------------------------------------------------------------
        private void frmBank_Load(object sender, EventArgs e)
        {
            // در صورت نیاز به بارگذاری اولیه اطلاعات، اینجا قرار می‌گیرد
        }

        // ---------------------------------------------------------------------
        // رویداد تغییر مقدار نام بانک (در حال حاضر بدون عملیات خاص)
        // ---------------------------------------------------------------------
        private void txtBankName_TextChanged(object sender, EventArgs e)
        {
            // در صورت نیاز به پردازش تغییرات نام بانک، اینجا کدنویسی می‌شود
        }

        // ---------------------------------------------------------------------
        // رویداد تغییر مقدار شماره حساب (در حال حاضر بدون عملیات خاص)
        // ---------------------------------------------------------------------
        private void txtAcctNum_TextChanged(object sender, EventArgs e)
        {
            // در صورت نیاز به پردازش تغییرات شماره حساب، اینجا کدنویسی می‌شود
        }

        // ---------------------------------------------------------------------
        // رویداد تغییر مقدار موجودی حساب (در حال حاضر بدون عملیات خاص)
        // ---------------------------------------------------------------------
        private void txtBalance_TextChanged(object sender, EventArgs e)
        {
            // در صورت نیاز به پردازش تغییرات موجودی حساب، اینجا کدنویسی می‌شود
        }
    } // پایان کلاس frmBank
} // پایان فضای نام KalaPezeshki