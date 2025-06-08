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
    // فرم لیست صندوق‌ها در سیستم کالاهای پزشکی
    public partial class frmListSandoogh : Form
    {
        // سازنده فرم - مقداردهی اولیه کنترل‌ها
        public frmListSandoogh()
        {
            InitializeComponent();
        }

        // تعریف اتصال به دیتابیس SQL Server
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");

        // تعریف شیء فرمان SQL برای اجرای دستورات
        SqlCommand cmd = new SqlCommand();

        // متد Display - نمایش اطلاعات صندوق‌ها در DataGridView
        void Display()
        {
            // مجموعه داده‌ها برای ذخیره نتیجه
            DataSet ds = new DataSet();

            // آداپتور برای پر کردن DataSet
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;

            // بازیابی تمام رکوردهای جدول Sandoogh
            adp.SelectCommand.CommandText = "SELECT * FROM Sandoogh";
            adp.Fill(ds, "Sandoogh");

            // تنظیم منبع داده برای DataGridView
            dgvSandoogh.DataSource = ds;
            dgvSandoogh.DataMember = "Sandoogh";

            // تنظیم عنوان و عرض ستون‌های جدول
            dgvSandoogh.Columns[0].HeaderText = "کد";
            dgvSandoogh.Columns[1].HeaderText = "نام صندوق";
            dgvSandoogh.Columns[2].HeaderText = "موجودی";
            dgvSandoogh.Columns[3].HeaderText = "توضیحات";

            dgvSandoogh.Columns[1].Width = 150;
            dgvSandoogh.Columns[2].Width = 150;
            dgvSandoogh.Columns[3].Width = 300;
        }

        // رویداد بارگذاری فرم - فراخوانی متد Display برای نمایش لیست صندوق‌ها
        private void frmListSandoogh_Load(object sender, EventArgs e)
        {
            Display();
        }
        // رویداد تغییر متن فیلد "نام صندوق" - فیلترسازی نتایج در DataGridView
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;

                // فیلتر رکوردها بر اساس نام صندوق
                adp.SelectCommand.CommandText = "Select * from Sandoogh where NameS like '%' + @S + '%'";
                adp.SelectCommand.Parameters.AddWithValue("@S", txtName.Text + "%");

                adp.Fill(ds, "Sandoogh");
                dgvSandoogh.DataSource = ds;
                dgvSandoogh.DataMember = "Sandoogh";
            }
            catch (Exception ex)
            {
                MessageBox.Show(" مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        // رویداد تغییر متن فیلد "کد صندوق" - فیلترسازی نتایج در DataGridView
        private void txtShH_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;

                // فیلتر رکوردها بر اساس کد صندوق
                adp.SelectCommand.CommandText = "Select * from Sandoogh where Ids like '%' + @S + '%'";
                adp.SelectCommand.Parameters.AddWithValue("@S", txtShH.Text + "%");

                adp.Fill(ds, "Sandoogh");
                dgvSandoogh.DataSource = ds;
                dgvSandoogh.DataMember = "Sandoogh";
            }
            catch (Exception ex)
            {
                MessageBox.Show(" مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        // رویداد کلیک دکمه "حذف" - حذف صندوق انتخاب‌شده از جدول
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvSandoogh.SelectedCells[0].Value);

                cmd.Parameters.Clear();
                cmd.Connection = con;

                // حذف رکورد بر اساس IdS
                cmd.CommandText = "Delete from Sandoogh where IdS=@N";
                cmd.Parameters.AddWithValue("@N", x);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // بروزرسانی لیست پس از حذف
                Display();

                MessageBox.Show("حذف انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }
    }
}
