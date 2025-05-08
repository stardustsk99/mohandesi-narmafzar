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
    // فرم مربوط به اطلاعات فروشگاه یا مرکز پزشکی
    public partial class frmInfo : Form
    {
        // سازنده فرم - مقداردهی اولیه کنترل‌ها
        public frmInfo()
        {
            InitializeComponent();
        }

        // تعریف اتصال به پایگاه داده SQL Server
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=medical goods;integrated security=true");

        // تعریف شیء فرمان SQL برای اجرای دستورات
        SqlCommand cmd = new SqlCommand();

        // رویداد کلیک روی Label4 (در حال حاضر خالی)
        private void label4_Click(object sender, EventArgs e) { }

        // رویداد کلیک روی Label5 (در حال حاضر خالی)
        private void label5_Click(object sender, EventArgs e) { }

        // رویداد تغییر متن TextBox سوم (در حال حاضر خالی)
        private void textBox3_TextChanged(object sender, EventArgs e) { }

        // رویداد کلیک روی پانل دوم (در حال حاضر خالی)
        private void groupPanel2_Click(object sender, EventArgs e) { }

        // رویداد کلیک دکمه ذخیره - ثبت اطلاعات جدید در جدول Info
        private void btnSave_Click(object sender, EventArgs e)
        {
            cmd.Parameters.Clear(); // پاکسازی پارامترها
            cmd.Connection = con; // تعیین اتصال
            cmd.CommandText = "insert into Info(NameK,Tel,Saheb,Address)values(@a,@b,@c,@d)";
            cmd.Parameters.AddWithValue("@a", txtName.Text);
            cmd.Parameters.AddWithValue("@b", txtTel.Text);
            cmd.Parameters.AddWithValue("@c", txtSaheb.Text);
            cmd.Parameters.AddWithValue("@d", txtAddress.Text);
            con.Open();
            cmd.ExecuteNonQuery(); // اجرای دستور
            con.Close();
            MessageBox.Show("ثبت اطلاعات با موفقیت انجام شد");
        }

        // رویداد کلیک دکمه حذف - حذف رکورد بر اساس کد وارد شده
        private void btnDelete_Click(object sender, EventArgs e)
        {
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "Delete from Info where Id=" + txtCode.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("حذف اطلاعات با موفقیت انجام شد");
        }

        // رویداد کلیک دکمه ویرایش - به‌روزرسانی رکورد موجود
        private void btnEdite_Click(object sender, EventArgs e)
        {
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "Update Info Set NameK='" + txtName.Text + "',Tel='" + txtTel.Text + "',Saheb='" + txtSaheb.Text + "',Address='" + txtAddress.Text + "' where Id=" + txtCode.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("ویرایش اطلاعات با موفقیت انجام شد");
        }

        // رویداد کلیک دکمه جستجو - بازیابی اطلاعات بر اساس کد وارد شده
        private void btnS_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Info where id=@N";
            cmd.Parameters.AddWithValue("@N", txtCode.Text);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                // مقداردهی به کنترل‌ها از داده‌های بازیابی‌شده
                txtCode.Text = dr["id"].ToString();
                txtName.Text = dr["NameK"].ToString();
                txtTel.Text = dr["Tel"].ToString();
                txtSaheb.Text = dr["Saheb"].ToString();
                txtAddress.Text = dr["Address"].ToString();
            }
            else
            {
                // اگر رکوردی یافت نشد
                txtCode.Text = "";
                txtCode.Focus();
                MessageBox.Show("برای کد وارد شده اطلاعاتی پیدا نشد");
            }

            con.Close();
        }

        // رویداد بارگذاری فرم (در حال حاضر خالی)
        private void frmInfo_Load(object sender, EventArgs e) { }
    }
}
