using Stimulsoft.Svg;
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
    public partial class frmListGoods: Form
    {
        public frmListGoods()
        {
            InitializeComponent();
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
            adp.SelectCommand.CommandText = "Select * from Goods"; // بازیابی همه کاربران
            adp.Fill(ds, "Goods"); // پر کردن دیتاست با داده‌ها
            dgvGoods.DataSource = ds;
            dgvGoods.DataMember = "Goods";

            // تنظیم عنوان ستون‌های جدول نمایش داده شده
            dgvGoods.Columns[0].HeaderText = "کد";
            dgvGoods.Columns[1].HeaderText = "نام گروه ";
            dgvGoods.Columns[2].HeaderText = "نام کالا ";
            dgvGoods.Columns[3].HeaderText = "شرکت/کشور ";
            dgvGoods.Columns[4].HeaderText = "تاریخ تولید ";
            dgvGoods.Columns[5].HeaderText = "تاریخ انقضا ";
            dgvGoods.Columns[6].HeaderText = "تعداد کالا ";
            dgvGoods.Columns[7].HeaderText = "قیمت خرید ";
            dgvGoods.Columns[8].HeaderText = "قیمت فروش";
            dgvGoods.Columns[9].HeaderText = "توضیحات ";
            dgvGoods.Columns[0].Width = 80;
            dgvGoods.Columns[2].Width = 120;
            dgvGoods.Columns[9].Width = 150;
        }
        void DisplayEXP()
        {
            DataSet ds = new DataSet(); // مجموعه داده‌ها برای ذخیره نتیجه
            SqlDataAdapter adp = new SqlDataAdapter(); // آداپتور برای پر کردن DataSet
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select * from Goods where EXP between '"+mskEXP1.Text+"' AND '"+mskEXP2.Text+"'"; // بازیابی همه کاربران
            adp.Fill(ds, "Goods"); // پر کردن دیتاست با داده‌ها
            dgvGoods.DataSource = ds;
            dgvGoods.DataMember = "Goods";

            // تنظیم عنوان ستون‌های جدول نمایش داده شده
            dgvGoods.Columns[0].HeaderText = "کد";
            dgvGoods.Columns[1].HeaderText = "نام گروه ";
            dgvGoods.Columns[2].HeaderText = "نام کالا ";
            dgvGoods.Columns[3].HeaderText = "شرکت/کشور ";
            dgvGoods.Columns[4].HeaderText = "تاریخ تولید ";
            dgvGoods.Columns[5].HeaderText = "تاریخ انقضا ";
            dgvGoods.Columns[6].HeaderText = "تعداد کالا ";
            dgvGoods.Columns[7].HeaderText = "قیمت خرید ";
            dgvGoods.Columns[8].HeaderText = "قیمت فروش";
            dgvGoods.Columns[9].HeaderText = "توضیحات ";
            dgvGoods.Columns[0].Width = 80;
            dgvGoods.Columns[2].Width = 120;
            dgvGoods.Columns[9].Width = 150;
        }
        private void frmListGoods_Load(object sender, EventArgs e)
        {
            Display();
            System.Globalization.PersianCalendar persianCalendar = new System.Globalization.PersianCalendar();
            mskEXP1.Text = persianCalendar.GetYear(DateTime.Now).ToString() + persianCalendar.GetMonth(DateTime.Now).ToString("0#") + persianCalendar.GetDayOfMonth(DateTime.Now).ToString("0#");
            mskEXP2.Text = persianCalendar.GetYear(DateTime.Now).ToString() + persianCalendar.GetMonth(DateTime.Now).ToString("0#") + persianCalendar.GetDayOfMonth(DateTime.Now).ToString("0#");

        }

        private void mskEXP1_TextChanged(object sender, EventArgs e)
        {
            DisplayEXP();
        }

        private void mskEXP2_TextChanged(object sender, EventArgs e)
        {
            DisplayEXP();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            DisplayEXP();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet(); // مجموعه داده‌ها برای ذخیره نتیجه
            SqlDataAdapter adp = new SqlDataAdapter(); // آداپتور برای پر کردن DataSet
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select * from Goods where NameGoods like '%'+@S+'%'"; // بازیابی همه کاربران
            adp.SelectCommand.Parameters.AddWithValue("@S", txtName.Text + "%");
            adp.Fill(ds, "Goods"); // پر کردن دیتاست با داده‌ها
            dgvGoods.DataSource = ds;
            dgvGoods.DataMember = "Goods";
        }

        private void txtGroup_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet(); // مجموعه داده‌ها برای ذخیره نتیجه
            SqlDataAdapter adp = new SqlDataAdapter(); // آداپتور برای پر کردن DataSet
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select * from Goods where NameG like '%'+@S+'%'"; // بازیابی همه کاربران
            adp.SelectCommand.Parameters.AddWithValue("@S", txtGroup.Text + "%");
            adp.Fill(ds, "Goods"); // پر کردن دیتاست با داده‌ها
            dgvGoods.DataSource = ds;
            dgvGoods.DataMember = "Goods";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvGoods.SelectedCells[0].Value);
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Goods where id=@N";
                cmd.Parameters.AddWithValue("@N", x);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("حذف انجام شد");
                Display();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }
    }
}
