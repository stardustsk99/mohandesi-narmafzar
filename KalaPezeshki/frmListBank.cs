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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace KalaPezeshki
{
    public partial class frmListBank : Form
    {
        // سازنده فرم - مقداردهی اولیه کنترل‌های فرم
        public frmListBank()
        {
            InitializeComponent();
        }

        // تعریف اتصال به دیتابیس SQL Server
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");

        // تعریف شیء فرمان SQL برای اجرای دستورات
        SqlCommand cmd = new SqlCommand();

        // متد Display - نمایش اطلاعات بانک‌ها در DataGridView
        void Display()
        {
            try
            {
                // مجموعه داده‌ها برای ذخیره نتیجه
                DataSet ds = new DataSet();

                // آداپتور برای پر کردن DataSet
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;

                // بازیابی همه رکوردهای جدول Bank
                adp.SelectCommand.CommandText = "SELECT * FROM Bank";
                adp.Fill(ds, "Bank"); // پر کردن دیتاست با داده‌ها

                // اتصال دیتاست به DataGridView
                dgvCompany.DataSource = ds;
                dgvCompany.DataMember = "Bank";

                // تنظیم عنوان ستون‌های جدول نمایش داده‌شده
                dgvCompany.Columns[0].HeaderText = "کد";
                dgvCompany.Columns[1].HeaderText = "نام";
                dgvCompany.Columns[2].HeaderText = "نام بانک";
                dgvCompany.Columns[3].HeaderText = "شماره حساب";
                dgvCompany.Columns[4].HeaderText = "موجودی";
                dgvCompany.Columns[5].HeaderText = "توضیحات";

                // تنظیم عرض برخی از ستون‌ها
                dgvCompany.Columns[5].Width = 150;
                dgvCompany.Columns[1].Width = 150;
                dgvCompany.Columns[3].Width = 150;
            }
            catch (Exception ex)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }
        // رویداد بارگذاری فرم - هنگام باز شدن فرم لیست بانک‌ها
        private void frmListBank_Load(object sender, EventArgs e)
        {
            Display(); // فراخوانی متد نمایش اطلاعات
        }

        // رویداد تغییر متن تکست‌باکس txtRool (فعلاً بدون استفاده)
        private void txtRool_TextChanged(object sender, EventArgs e)
        {

        }

        // رویداد کلیک دکمه "حذف" - حذف بانک انتخاب‌شده از DataGridView
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // دریافت شناسه بانک انتخاب‌شده از DataGridView
                int x = Convert.ToInt32(dgvCompany.SelectedCells[0].Value);

                // آماده‌سازی فرمان حذف
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "DELETE FROM Bank WHERE id=@N";
                cmd.Parameters.AddWithValue("@N", x);

                // اجرای دستور حذف
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("حذف انجام شد");

                // بروزرسانی نمایش داده‌ها پس از حذف
                Display();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // رویداد تغییر متن فیلد جستجو براساس نام بانک
        private void txtName_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                // مجموعه داده‌ها برای ذخیره نتیجه
                DataSet ds = new DataSet();

                // آداپتور برای پر کردن DataSet
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;

                // فیلتر کردن رکوردهای بانک براساس عبارت وارد شده در txtName
                adp.SelectCommand.CommandText = "SELECT * FROM Bank WHERE Bank LIKE '%' + @S + '%'";
                adp.SelectCommand.Parameters.AddWithValue("@S", txtName.Text + "%");

                // پر کردن دیتاست با داده‌های فیلترشده
                adp.Fill(ds, "Bank");
                dgvCompany.DataSource = ds;
                dgvCompany.DataMember = "Bank";
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }


        // رویداد تغییر متن فیلد شماره حساب (جستجو در جدول بانک)
        private void txtAcctNum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // مجموعه داده‌ها برای ذخیره نتیجه
                DataSet ds = new DataSet();

                // آداپتور برای پر کردن DataSet
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;

                // فیلتر رکوردهای جدول Bank براساس شماره حساب وارد شده
                adp.SelectCommand.CommandText = "SELECT * FROM Bank WHERE AcctNum LIKE '%' + @S + '%'";
                adp.SelectCommand.Parameters.AddWithValue("@S", txtAcctNum.Text + "%");

                // پر کردن دیتاست با داده‌های فیلترشده
                adp.Fill(ds, "Bank");
                dgvCompany.DataSource = ds;
                dgvCompany.DataMember = "Bank";
            }
            catch (Exception ex)
            {
                // نمایش پیام خطا در صورت بروز مشکل
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }
    }
}
