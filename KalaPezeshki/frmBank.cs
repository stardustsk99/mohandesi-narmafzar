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
using System.Xml.Linq;

namespace KalaPezeshki
{
    public partial class frmBank: Form
    {
        public frmBank()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "insert into Bank(NameAcct,Bank,AcctNum,Balance,Tozih)values (@a,@b,@c,@d,@e)";
                cmd.Parameters.AddWithValue("@a", txtNameAcct.Text);
                cmd.Parameters.AddWithValue("@b", txtBankName.Text);
                cmd.Parameters.AddWithValue("@c", txtAcctNum.Text);
                cmd.Parameters.AddWithValue("@d", txtBalance.Text);
                cmd.Parameters.AddWithValue("@e", txtTozih.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("حساب اضافه شد");
                //-------------------------------
                txtCode.Clear();
                txtNameAcct.Clear();
                txtBankName.Clear();
                txtAcctNum.Clear();
                txtBalance.Clear();
                txtTozih.Clear();

            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Bank where id=@N";
                cmd.Parameters.AddWithValue("@N", txtCode.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("حساب حذف شد");
                //-------------------------------
                txtCode.Clear();
                txtNameAcct.Clear();
                txtBankName.Clear();
                txtAcctNum.Clear();
                txtBalance.Clear();
                txtTozih.Clear();

            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        private void btnEdite_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Bank SET NameAcct=@a, Bank=@b, AcctNum=@c, Balance=@d,Tozih=@e WHERE id=" +txtCode.Text;
                cmd.Parameters.AddWithValue("@a", txtNameAcct.Text);
                cmd.Parameters.AddWithValue("@b", txtBankName.Text);
                cmd.Parameters.AddWithValue("@c", txtAcctNum.Text);
                cmd.Parameters.AddWithValue("@d", txtBalance.Text);
                cmd.Parameters.AddWithValue("@e", txtTozih.Text); // کلید برای شناسایی رکورد

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("حساب ویرایش شد");

                //-------------------------------
                txtCode.Clear();
                txtNameAcct.Clear();
                txtBankName.Clear();
                txtAcctNum.Clear();
                txtBalance.Clear();
                txtTozih.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }

        }

        private void btnS_Click(object sender, EventArgs e)
        {
            SqlDataReader dr;
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "select * from Bank where id=@N";
            cmd.Parameters.AddWithValue("@N", txtCode.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtCode.Text = dr["id"].ToString();
                txtNameAcct.Text = dr["NameAcct"].ToString();
                txtBankName.Text = dr["Bank"].ToString();
                txtAcctNum.Text = dr["AcctNum"].ToString();
                txtBalance.Text = dr["Balance"].ToString();
                txtTozih.Text = dr["Tozih"].ToString();
            }
            else
            {
                txtCode.Clear();
                txtCode.Focus();
                MessageBox.Show("برای کد وارد شده اطلاعاتی وجود ندارد");
            }
            con.Close();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            new frmListBank().ShowDialog();
        }

        private void frmBank_Load(object sender, EventArgs e)
        {

        }
    }
}
