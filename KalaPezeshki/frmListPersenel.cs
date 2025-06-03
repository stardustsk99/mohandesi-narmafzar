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
    public partial class frmListPersenel: Form
    {
        public frmListPersenel()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");

        // تعریف شیء فرمان SQL برای اجرای دستورات
        SqlCommand cmd = new SqlCommand();
        void Display()
        {
            DataSet ds = new DataSet(); // مجموعه داده‌ها برای ذخیره نتیجه
            SqlDataAdapter adp = new SqlDataAdapter(); // آداپتور برای پر کردن DataSet
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select * from Persenel"; // بازیابی همه کاربران
            adp.Fill(ds, "Persenel"); // پر کردن دیتاست با داده‌ها
            dgvCompany.DataSource = ds;
            dgvCompany.DataMember = "Persenel";

            // تنظیم عنوان ستون‌های جدول نمایش داده شده
            dgvCompany.Columns[0].HeaderText = "کد";
            dgvCompany.Columns[1].HeaderText = "نام";
            dgvCompany.Columns[2].HeaderText = "تلفن تماس";
            dgvCompany.Columns[3].HeaderText = "سمت";
            dgvCompany.Columns[4].HeaderText = " حقوق ماهیانه";
            dgvCompany.Columns[5].HeaderText = "تاریخ استخدام";
            dgvCompany.Columns[6].HeaderText = "توضیحات";
            dgvCompany.Columns[6].Width = 150;
            dgvCompany.Columns[2].Width = 150;
            dgvCompany.Columns[1].Width = 150;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvCompany.SelectedCells[0].Value);
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Persenel where id=@N";
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

        private void frmListPersenel_Load(object sender, EventArgs e)
        {
            Display();
        }



        private void txtName_TextChanged_1(object sender, EventArgs e)
        {
            DataSet ds = new DataSet(); // مجموعه داده‌ها برای ذخیره نتیجه
            SqlDataAdapter adp = new SqlDataAdapter(); // آداپتور برای پر کردن DataSet
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select * from Persenel where Name like '%'+ @S +'%'";// بازیابی همه کاربران
            adp.SelectCommand.Parameters.AddWithValue("@S", txtName.Text + "%");
            adp.Fill(ds, "Persenel"); // پر کردن دیتاست با داده‌ها
            dgvCompany.DataSource = ds;
            dgvCompany.DataMember = "Persenel";
        }

        private void txtRool_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet(); // مجموعه داده‌ها برای ذخیره نتیجه
            SqlDataAdapter adp = new SqlDataAdapter(); // آداپتور برای پر کردن DataSet
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select * from Persenel where Rool like '%'+ @S +'%'";// بازیابی همه کاربران
            adp.SelectCommand.Parameters.AddWithValue("@S", txtRool.Text + "%");
            adp.Fill(ds, "Persenel"); // پر کردن دیتاست با داده‌ها
            dgvCompany.DataSource = ds;
            dgvCompany.DataMember = "Persenel";
        }
    }
}
