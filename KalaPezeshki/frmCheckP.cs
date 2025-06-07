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
    public partial class frmCheckP : Form
    {
        // ---------------------------------------------------------------------
        // تعریف اتصال به پایگاه‌داده SQL Server
        // ---------------------------------------------------------------------
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        // ---------------------------------------------------------------------
        // سازنده‌ی فرم
        // ---------------------------------------------------------------------
        public frmCheckP()
        {
            InitializeComponent();
        }

        // ---------------------------------------------------------------------
        // تنظیم تاریخ جاری شمسی هنگام بارگذاری فرم
        // ---------------------------------------------------------------------
        private void frmCheckP_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            string today = p.GetYear(DateTime.Now).ToString() +
                           p.GetMonth(DateTime.Now).ToString("0#") +
                           p.GetDayOfMonth(DateTime.Now).ToString("0#");

            // مقداردهی تاریخ امروز به فیلدهای تاریخ
            mskSarResid.Text = today;
            mskTarikh.Text = today;
        }

        // ---------------------------------------------------------------------
        // دکمه ذخیره‌سازی چک پرداختی
        // ---------------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO CheckP(ids, AcctNum, NameAcct, NameM, Balance, Tarikh, SarResid, Vaziyat, Tozih) " +
                                  "VALUES(@a, @b, @c, @d, @e, @f, @g, @h, @i)";

                // تنظیم پارامترها با مقادیر واردشده در فرم
                cmd.Parameters.AddWithValue("@a", txtCode.Text);
                cmd.Parameters.AddWithValue("@b", txtShH.Text);
                cmd.Parameters.AddWithValue("@c", txtNameH.Text);
                cmd.Parameters.AddWithValue("@d", txtNameM.Text);
                cmd.Parameters.AddWithValue("@e", txtMablagh.Text);
                cmd.Parameters.AddWithValue("@f", mskTarikh.Text);
                cmd.Parameters.AddWithValue("@g", mskSarResid.Text);
                cmd.Parameters.AddWithValue("@h", cmbVaziyat.Text);
                cmd.Parameters.AddWithValue("@i", txtTozih.Text);

                // اجرای دستور درج (Insert)
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // نمایش پیام موفقیت
                MessageBox.Show("چک پرداختی ثبت شد");

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
        // دکمه حذف چک پرداختی بر اساس شناسه
        // ---------------------------------------------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM CheckP WHERE ids=" + txtCode.Text;

                // اجرای دستور حذف (Delete)
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // نمایش پیام موفقیت
                MessageBox.Show("چک پرداختی حذف شد");
            }
            catch (Exception)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // ---------------------------------------------------------------------
        // دکمه ویرایش اطلاعات چک پرداختی
        // ---------------------------------------------------------------------
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE CheckP SET " +
                                  "ids='" + txtCode.Text + "', " +
                                  "AcctNum='" + txtShH.Text + "', " +
                                  "NameAcct='" + txtNameH.Text + "', " +
                                  "NameM='" + txtNameM.Text + "', " +
                                  "Balance='" + txtMablagh.Text + "', " +
                                  "Tarikh='" + mskTarikh.Text + "', " +
                                  "SarResid='" + mskSarResid.Text + "', " +
                                  "Vaziyat='" + cmbVaziyat.Text + "', " +
                                  "Tozih='" + txtTozih.Text + "' " +
                                  "WHERE ids=" + txtCode.Text;

                // اجرای دستور به‌روزرسانی (Update)
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // نمایش پیام موفقیت
                MessageBox.Show("چک پرداختی ویرایش شد");

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
        // جستجوی چک پرداختی بر اساس کد
        // ---------------------------------------------------------------------
        private void btnS_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader dr;

                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM CheckP WHERE IdS=@N";
                cmd.Parameters.AddWithValue("@N", txtCode.Text);

                // اجرای فرمان و دریافت نتایج
                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // نمایش اطلاعات چک پرداختی در فیلدهای فرم
                    txtCode.Text = dr["idS"].ToString();
                    txtShH.Text = dr["NameAcct"].ToString(); // اینجا AcctNum معمولاً بهتر است، ولی طبق کد ارسالی خودت گذاشتم NameAcct
                    txtNameH.Text = dr["NameAcct"].ToString();
                    txtNameM.Text = dr["NameM"].ToString();
                    txtMablagh.Text = dr["Balance"].ToString();
                    mskTarikh.Text = dr["Tarikh"].ToString();
                    mskSarResid.Text = dr["SarResid"].ToString();
                    cmbVaziyat.Text = dr["Vaziyat"].ToString();
                    txtTozih.Text = dr["Tozih"].ToString();
                }
                else
                {
                    // در صورت عدم یافتن اطلاعات برای کد وارد شده
                    txtCode.Text = "";
                    txtCode.Focus();
                    MessageBox.Show("برای کد وارد شده اطلاعاتی یافت نشد");
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
        // جستجوی نام حساب بر اساس شماره حساب
        // ---------------------------------------------------------------------
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader dr;

                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Bank WHERE AcctNum=@N";
                cmd.Parameters.AddWithValue("@N", txtShH.Text);

                // اجرای فرمان و دریافت نتایج
                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // نمایش اطلاعات حساب در فیلدهای فرم
                    txtNameH.Text = dr["NameAcct"].ToString();
                    txtShH.Text = dr["AcctNum"].ToString();
                }
                else
                {
                    // در صورت عدم یافتن اطلاعات برای شماره حساب وارد شده
                    txtShH.Text = "";
                    txtShH.Focus();
                    MessageBox.Show("برای کد وارد شده اطلاعاتی یافت نشد");
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
        // نمایش لیست جدید از فرم چک پرداختی
        // ---------------------------------------------------------------------
        private void btnList_Click(object sender, EventArgs e)
        {
            new frmListCheckP().ShowDialog();
        }

        // ---------------------------------------------------------------------
        // پاکسازی فیلدها
        // ---------------------------------------------------------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            frmHelper.ClearFormFields(this);
        }

        // ---------------------------------------------------------------------
        // تغییر متن نام حساب (فعلاً استفاده نشده)
        // ---------------------------------------------------------------------
        private void txtNameH_TextChanged(object sender, EventArgs e)
        {
        }

        // ---------------------------------------------------------------------
        // تغییر وضعیت (فعلاً استفاده نشده)
        // ---------------------------------------------------------------------
        private void cmbVaziyat_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

    } // پایان کلاس frmCheckP
} // پایان فضای نام KalaPezeshki
