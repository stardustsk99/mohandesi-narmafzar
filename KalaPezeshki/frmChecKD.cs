using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KalaPezeshki
{
    public partial class frmCheckD : Form
    {
        // اتصال به پایگاه‌داده
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        public frmCheckD()
        {
            InitializeComponent();
        }

        // رویداد بارگذاری فرم
        private void frmChckD_Load(object sender, EventArgs e)
        {
            // مقداردهی تاریخ امروز به صورت شمسی برای فیلدها
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            mskSarResid.Text = p.GetYear(DateTime.Now).ToString() +
                               p.GetMonth(DateTime.Now).ToString("0#") +
                               p.GetDayOfMonth(DateTime.Now).ToString("0#");

            mskTarikh.Text = mskSarResid.Text;
        }

        // دکمه ذخیره چک دریافتی
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = @"INSERT INTO CheckD (ids, AcctNum, NameAcct, NameM, Balance, Tarikh, SarResid, Vaziyat, Tozih)
                                    VALUES (@a, @b, @c, @d, @e, @f, @g, @h, @i)";
                cmd.Parameters.AddWithValue("@a", txtCode.Text);
                cmd.Parameters.AddWithValue("@b", txtShH.Text);
                cmd.Parameters.AddWithValue("@c", txtNameH.Text);
                cmd.Parameters.AddWithValue("@d", txtNameM.Text);
                cmd.Parameters.AddWithValue("@e", txtMablagh.Text);
                cmd.Parameters.AddWithValue("@f", mskTarikh.Text);
                cmd.Parameters.AddWithValue("@g", mskSarResid.Text);
                cmd.Parameters.AddWithValue("@h", cmbVaziyat.Text);
                cmd.Parameters.AddWithValue("@i", txtTozih.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("چک دریافتی ثبت شد");
                frmHelper.ClearFormFields(this);
            }
            catch
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // دکمه حذف چک دریافتی
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM CheckD WHERE ids=" + txtCode.Text;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("چک دریافتی حذف شد");
                frmHelper.ClearFormFields(this);
            }
            catch
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // دکمه ویرایش چک دریافتی
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = @"UPDATE CheckD SET
                                    ids = @a,
                                    AcctNum = @b,
                                    NameAcct = @c,
                                    NameM = @d,
                                    Balance = @e,
                                    Tarikh = @f,
                                    SarResid = @g,
                                    Vaziyat = @h,
                                    Tozih = @i
                                    WHERE ids = @a";

                cmd.Parameters.AddWithValue("@a", txtCode.Text);
                cmd.Parameters.AddWithValue("@b", txtShH.Text);
                cmd.Parameters.AddWithValue("@c", txtNameH.Text);
                cmd.Parameters.AddWithValue("@d", txtNameM.Text);
                cmd.Parameters.AddWithValue("@e", txtMablagh.Text);
                cmd.Parameters.AddWithValue("@f", mskTarikh.Text);
                cmd.Parameters.AddWithValue("@g", mskSarResid.Text);
                cmd.Parameters.AddWithValue("@h", cmbVaziyat.Text);
                cmd.Parameters.AddWithValue("@i", txtTozih.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("چک دریافتی ویرایش شد");
                frmHelper.ClearFormFields(this);
            }
            catch
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // دکمه جستجوی چک بر اساس شناسه
        private void btnS_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader dr;
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM CheckD WHERE ids=@N";
                cmd.Parameters.AddWithValue("@N", txtCode.Text);

                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtCode.Text = dr["ids"].ToString();
                    txtShH.Text = dr["AcctNum"].ToString();
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
                    txtCode.Clear();
                    txtCode.Focus();
                    MessageBox.Show("برای کد وارد شده اطلاعاتی یافت نشد");
                }

                con.Close();
            }
            catch
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // دکمه جستجوی حساب بانکی با شماره حساب
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader dr;
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Bank WHERE AcctNum=@N";
                cmd.Parameters.AddWithValue("@N", txtShH.Text);

                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtNameH.Text = dr["NameAcct"].ToString();
                    txtShH.Text = dr["AcctNum"].ToString();
                }
                else
                {
                    txtShH.Clear();
                    txtShH.Focus();
                    MessageBox.Show("برای شماره حساب وارد شده اطلاعاتی یافت نشد");
                }

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("مشکلی پیش آمده است\n"+ ex.Message);
            }
        }

        // دکمه نمایش لیست چک‌ها
        private void btnList_Click(object sender, EventArgs e)
        {
            new frmListCheckD().ShowDialog();
        }

        // دکمه پاک کردن فرم
        private void btnClear_Click(object sender, EventArgs e)
        {
            frmHelper.ClearFormFields(this);
        }

        // رویدادهای استفاده‌نشده (می‌توان حذف کرد اگر نیاز ندارید)
        private void mskTarikh_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }

        private void txtNameH_TextChanged(object sender, EventArgs e) { }
    }
}
