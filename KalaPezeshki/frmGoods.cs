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
    public partial class frmGoods : Form
    {
        // ---------------------------------------------------------------------
        // سازنده‌ی فرم
        // ---------------------------------------------------------------------
        public frmGoods()
        {
            InitializeComponent();
        }

        // ---------------------------------------------------------------------
        // تعریف اتصال به پایگاه داده SQL Server
        // ---------------------------------------------------------------------
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");

        // ---------------------------------------------------------------------
        // تعریف شیء فرمان SQL برای اجرای دستورات
        // ---------------------------------------------------------------------
        SqlCommand cmd = new SqlCommand();

        // ---------------------------------------------------------------------
        // جدول داده‌ها و منبع داده جهت اتصال به ComboBox
        // ---------------------------------------------------------------------
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        // ---------------------------------------------------------------------
        // رویداد بارگذاری فرم (Load)
        // ---------------------------------------------------------------------
        private void frmGoods_Load(object sender, EventArgs e)
        {
            try
            {
                // خواندن اطلاعات گروه کالاها از جدول Grooh و نمایش در ComboBox
                SqlDataAdapter da = new SqlDataAdapter("SELECT NameG FROM Grooh", con);
                da.Fill(dt);

                bs.DataSource = dt;
                cmbGroup.DataSource = bs;
                cmbGroup.DisplayMember = "NameG";

                // تنظیم تاریخ امروز به صورت شمسی برای تاریخ‌های فرم
                System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();

                mskFMG.Text = persianCalendar.GetYear(DateTime.Now).ToString() +
                              persianCalendar.GetMonth(DateTime.Now).ToString("0#") +
                              persianCalendar.GetDayOfMonth(DateTime.Now).ToString("0#");

                mskEXP.Text = persianCalendar.GetYear(DateTime.Now).ToString() +
                              persianCalendar.GetMonth(DateTime.Now).ToString("0#") +
                              persianCalendar.GetDayOfMonth(DateTime.Now).ToString("0#");
            }
            catch (Exception ex)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        // ---------------------------------------------------------------------
        // رویداد کلیک روی Label4 (فعلاً استفاده‌نشده)
        // ---------------------------------------------------------------------
        private void label4_Click(object sender, EventArgs e)
        {
        }

        // ---------------------------------------------------------------------
        // رویداد کلیک روی Label10 (فعلاً استفاده‌نشده)
        // ---------------------------------------------------------------------
        private void label10_Click(object sender, EventArgs e)
        {
        }

        // ---------------------------------------------------------------------
        // دکمه ذخیره اطلاعات کالا در جدول Goods
        // ---------------------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Goods " +
                                  "(NameG, NameGoods, Company, FMG, EXP, Number, CP, SP, Tozih) " +
                                  "VALUES (@a, @b, @c, @d, @e, @f, @g, @h, @i)";

                // مقداردهی پارامترها با مقادیر فرم
                cmd.Parameters.AddWithValue("@a", cmbGroup.Text);
                cmd.Parameters.AddWithValue("@b", txtName.Text);
                cmd.Parameters.AddWithValue("@c", txtCompany.Text);
                cmd.Parameters.AddWithValue("@d", mskFMG.Text);
                cmd.Parameters.AddWithValue("@e", mskEXP.Text);
                cmd.Parameters.AddWithValue("@f", txtNumber.Text);
                cmd.Parameters.AddWithValue("@g", txtCP.Text);
                cmd.Parameters.AddWithValue("@h", txtSP.Text);
                cmd.Parameters.AddWithValue("@i", txtTozih.Text);

                // اجرای دستور درج اطلاعات
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // نمایش پیام موفقیت
                MessageBox.Show("کالا اضافه شد");

                // پاکسازی فیلدهای فرم
                txtCode.Clear();
                txtName.Clear();
                txtCompany.Clear();
                txtNumber.Text = "";
                txtCP.Clear();
                txtSP.Clear();
                txtTozih.Clear();
            }
            catch (Exception)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // ---------------------------------------------------------------------
        // دکمه حذف کالا از جدول Goods بر اساس شناسه
        // ---------------------------------------------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Goods WHERE id=@N";
                cmd.Parameters.AddWithValue("@N", txtCode.Text);

                // اجرای دستور حذف
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // نمایش پیام موفقیت
                MessageBox.Show("کالا حذف شد");

                // پاکسازی فیلدهای فرم
                txtCode.Clear();
                txtName.Clear();
                txtCompany.Clear();
                txtNumber.Text = "";
                txtCP.Clear();
                txtSP.Clear();
                txtTozih.Clear();
            }
            catch (Exception)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // ---------------------------------------------------------------------
        // دکمه ویرایش اطلاعات کالا در جدول Goods
        // ---------------------------------------------------------------------
        private void btnEdite_Click(object sender, EventArgs e)
        {
            try
            {
                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Goods SET " +
                                  "NameG = @a, " +
                                  "NameGoods = @b, " +
                                  "Company = @c, " +
                                  "FMG = @d, " +
                                  "EXP = @e, " +
                                  "Number = @f, " +
                                  "CP = @g, " +
                                  "SP = @h, " +
                                  "Tozih = @i " +
                                  "WHERE id = @j";

                // مقداردهی پارامترها با مقادیر فرم
                cmd.Parameters.AddWithValue("@a", cmbGroup.Text);
                cmd.Parameters.AddWithValue("@b", txtName.Text);
                cmd.Parameters.AddWithValue("@c", txtCompany.Text);
                cmd.Parameters.AddWithValue("@d", mskFMG.Text);
                cmd.Parameters.AddWithValue("@e", mskEXP.Text);
                cmd.Parameters.AddWithValue("@f", txtNumber.Text);
                cmd.Parameters.AddWithValue("@g", txtCP.Text);
                cmd.Parameters.AddWithValue("@h", txtSP.Text);
                cmd.Parameters.AddWithValue("@i", txtTozih.Text);
                cmd.Parameters.AddWithValue("@j", txtCode.Text);

                // اجرای دستور به‌روزرسانی اطلاعات کالا
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // نمایش پیام موفقیت
                MessageBox.Show("ویرایش انجام شد");

                // پاکسازی فیلدهای فرم
                txtCode.Clear();
                txtName.Clear();
                txtCompany.Clear();
                txtNumber.Text = "";
                txtCP.Clear();
                txtSP.Clear();
                txtTozih.Clear();
            }
            catch (Exception)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // ---------------------------------------------------------------------
        // دکمه جستجوی اطلاعات کالا بر اساس شناسه
        // ---------------------------------------------------------------------
        private void btnS_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader dr;

                // آماده‌سازی فرمان SQL
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Goods WHERE id=@N";
                cmd.Parameters.AddWithValue("@N", txtCode.Text);

                // اجرای فرمان و دریافت نتایج
                con.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    // نمایش اطلاعات کالا در فیلدهای فرم
                    txtCode.Text = dr["id"].ToString();
                    cmbGroup.Text = dr["NameG"].ToString();
                    txtName.Text = dr["NameGoods"].ToString();
                    txtCompany.Text = dr["Company"].ToString();
                    mskFMG.Text = dr["FMG"].ToString();
                    mskEXP.Text = dr["EXP"].ToString();
                    txtNumber.Text = dr["Number"].ToString();
                    txtCP.Text = dr["CP"].ToString();
                    txtSP.Text = dr["SP"].ToString();
                    txtTozih.Text = dr["Tozih"].ToString();
                }
                else
                {
                    // در صورت عدم یافتن اطلاعات برای کد وارد شده
                    txtCode.Clear();
                    txtCode.Focus();
                    MessageBox.Show("برای کد وارد شده اطلاعاتی وجود ندارد");
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
        // دکمه نمایش لیست کالاها
        // ---------------------------------------------------------------------
        private void btnList_Click(object sender, EventArgs e)
        {
            new frmListGoods().ShowDialog();
        }

        // ---------------------------------------------------------------------
        // رویداد کلیک روی گروه پنل (فعلاً استفاده‌نشده)
        // ---------------------------------------------------------------------
        private void groupPanel1_Click(object sender, EventArgs e)
        {
        }

        // ---------------------------------------------------------------------
        // دکمه پاکسازی فیلدهای فرم
        // ---------------------------------------------------------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            frmHelper.ClearFormFields(this);
        }

        // ---------------------------------------------------------------------
        // رویداد تغییر نام کالا (فعلاً استفاده‌نشده)
        // ---------------------------------------------------------------------
        private void txtName_TextChanged(object sender, EventArgs e)
        {
        }

        // ---------------------------------------------------------------------
        // رویداد تغییر نام شرکت (فعلاً استفاده‌نشده)
        // ---------------------------------------------------------------------
        private void txtCompany_TextChanged(object sender, EventArgs e)
        {
        }

        // ---------------------------------------------------------------------
        // رویداد تغییر قیمت خرید (فعلاً استفاده‌نشده)
        // ---------------------------------------------------------------------
        private void txtCP_TextChanged(object sender, EventArgs e)
        {
        }
        // ---------------------------------------------------------------------
        // رویداد تغییر قیمت فروش (فعلاً استفاده‌نشده)
        // ---------------------------------------------------------------------
        private void txtSP_TextChanged(object sender, EventArgs e)
        {
        }

    } // پایان کلاس frmGoods
} // پایان فضای نام KalaPezeshki