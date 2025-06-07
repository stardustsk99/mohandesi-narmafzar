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
    public partial class frmListBank: Form
    {
        public frmListBank()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        void Display()
        {
            try
            {
                DataSet ds = new DataSet(); // مجموعه داده‌ها برای ذخیره نتیجه
                SqlDataAdapter adp = new SqlDataAdapter(); // آداپتور برای پر کردن DataSet
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "Select * from Bank"; // بازیابی همه کاربران
                adp.Fill(ds, "Bank"); // پر کردن دیتاست با داده‌ها
                dgvCompany.DataSource = ds;
                dgvCompany.DataMember = "Bank";

                // تنظیم عنوان ستون‌های جدول نمایش داده شده
                dgvCompany.Columns[0].HeaderText = "کد";
                dgvCompany.Columns[1].HeaderText = "نام ";
                dgvCompany.Columns[2].HeaderText = "نام بانک";
                dgvCompany.Columns[3].HeaderText = "شماره حساب";
                dgvCompany.Columns[4].HeaderText = " موجودی";
                dgvCompany.Columns[5].HeaderText = "توضیحات";
                dgvCompany.Columns[5].Width = 150;
                dgvCompany.Columns[1].Width = 150;
                dgvCompany.Columns[3].Width = 150;
            }
            catch (Exception ex)
            {
                MessageBox.Show(" مشکلی پیش آمده است\n" + ex.Message);
            }
        }
        private void frmListBank_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void txtRool_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvCompany.SelectedCells[0].Value);
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Bank where id=@N";
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

        private void txtName_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet(); // مجموعه داده‌ها برای ذخیره نتیجه
                SqlDataAdapter adp = new SqlDataAdapter(); // آداپتور برای پر کردن DataSet
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "Select * from Bank where Bank like '%'+ @S +'%'";// بازیابی همه کاربران
                adp.SelectCommand.Parameters.AddWithValue("@S", txtName.Text + "%");
                adp.Fill(ds, "Bank"); // پر کردن دیتاست با داده‌ها
                dgvCompany.DataSource = ds;
                dgvCompany.DataMember = "Bank";
            }
            catch (Exception ex)
            {
                MessageBox.Show(" مشکلی پیش آمده است\n" + ex.Message);
            }
        }


        private void txtAcctNum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet(); // مجموعه داده‌ها برای ذخیره نتیجه
                SqlDataAdapter adp = new SqlDataAdapter(); // آداپتور برای پر کردن DataSet
                adp.SelectCommand = new SqlCommand();
                adp.SelectCommand.Connection = con;
                adp.SelectCommand.CommandText = "Select * from Bank where AcctNum like '%'+ @S +'%'";// بازیابی همه کاربران
                adp.SelectCommand.Parameters.AddWithValue("@S", txtAcctNum.Text + "%");
                adp.Fill(ds, "Bank"); // پر کردن دیتاست با داده‌ها
                dgvCompany.DataSource = ds;
                dgvCompany.DataMember = "Bank";
            }
            catch (Exception ex)
            {
                MessageBox.Show(" مشکلی پیش آمده است\n" + ex.Message);
            }
        }
    }
}
