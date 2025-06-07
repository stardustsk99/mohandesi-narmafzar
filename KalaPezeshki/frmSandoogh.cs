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
    public partial class frmSandoogh : Form
    {
        public frmSandoogh()
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
                cmd.CommandText = "Insert into Sandoogh(Ids,NameS,Mablagh,Tozih)values(@a,@b,@c,@d)";
                cmd.Parameters.AddWithValue("@a", txtCode.Text);
                cmd.Parameters.AddWithValue("@b", txtName.Text);
                cmd.Parameters.AddWithValue("@c", txtMablagh.Text);
                cmd.Parameters.AddWithValue("@d", txtTozih.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ثبت انجام شد");
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
                cmd.CommandText = "Delete from Sandoogh where idS=" + txtCode.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("حذف انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "Update Sandoogh set Ids='" + txtCode.Text + "',NameS='" + txtName.Text + "',Mablagh='" + txtMablagh.Text + "',Tozih='" + txtTozih.Text + "' where ids=" + txtCode.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ویرایش انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }


        private void btnList_Click(object sender, EventArgs e)
        {
            new frmListSandoogh().ShowDialog();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader dr;
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "select * from Sandoogh where IdS=@N";
                cmd.Parameters.AddWithValue("@N", txtCode.Text);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtCode.Text = dr["idS"].ToString();
                    txtName.Text = dr["NameS"].ToString();
                    txtMablagh.Text = dr["Mablagh"].ToString();
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
            catch (Exception ex)
            {
                MessageBox.Show(" مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        private void frmSandoogh_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            frmHelper.ClearFormFields(this);
        }

        private void txtMablagh_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
