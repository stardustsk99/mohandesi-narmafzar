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
        // اتصال به دیتابیس
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        public frmCheckP()
        {
            InitializeComponent();
        }

        // تنظیم تاریخ جاری شمسی هنگام بارگذاری فرم
        private void frmCheckP_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            string today = p.GetYear(DateTime.Now).ToString() +
                           p.GetMonth(DateTime.Now).ToString("0#") +
                           p.GetDayOfMonth(DateTime.Now).ToString("0#");

            mskSarResid.Text = today;
            mskTarikh.Text = today;
        }

        // دکمه ذخیره‌سازی چک پرداختی
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO CheckP(ids, AcctNum, NameAcct, NameM, Balance, Tarikh, SarResid, Vaziyat, Tozih) " +
                                  "VALUES(@a, @b, @c, @d, @e, @f, @g, @h, @i)";
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

                MessageBox.Show("چک پرداختی ثبت شد");
                frmHelper.ClearFormFields(this);
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // دکمه حذف چک پرداختی بر اساس شناسه
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM CheckP WHERE ids=" + txtCode.Text;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("چک پرداختی حذف شد");
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // دکمه ویرایش اطلاعات چک پرداختی
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
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

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("چک پرداختی ویرایش شد");
                frmHelper.ClearFormFields(this);
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // جستجوی چک پرداختی بر اساس کد
        private void btnS_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;

            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM CheckP WHERE IdS=@N";
            cmd.Parameters.AddWithValue("@N", txtCode.Text);

            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtCode.Text = dr["idS"].ToString();
                txtShH.Text = dr["NameAcct"].ToString();
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
                txtCode.Text = "";
                txtCode.Focus();
                MessageBox.Show("برای کد وارد شده اطلاعاتی یافت نشد");
            }

            con.Close();
        }

        // جستجوی نام حساب بر اساس شماره حساب
        private void buttonX1_Click(object sender, EventArgs e)
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
                txtShH.Text = "";
                txtShH.Focus();
                MessageBox.Show("برای کد وارد شده اطلاعاتی یافت نشد");
            }

            con.Close();
        }

        // نمایش لیست جدید از فرم چک پرداختی
        private void btnList_Click(object sender, EventArgs e)
        {
            new frmCheckP().ShowDialog();
        }

        // پاکسازی فیلدها
        private void btnClear_Click(object sender, EventArgs e)
        {
            frmHelper.ClearFormFields(this);
        }

        // تغییر متن نام حساب (فعلاً استفاده نشده)
        private void txtNameH_TextChanged(object sender, EventArgs e)
        {
        }

        // تغییر وضعیت (فعلاً استفاده نشده)
        private void cmbVaziyat_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
