using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace KalaPezeshki
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        void Display()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "Select * from Karbar";
            adp.Fill(ds, "Karbar");
            dgvUser.DataSource = ds;
            dgvUser.DataMember = "Karbar";
            //***************************
            dgvUser.Columns[0].HeaderText = "کد";
            dgvUser.Columns[1].HeaderText = "نام کاربری";
            dgvUser.Columns[2].HeaderText = "کلمه عبور";
            dgvUser.Columns[3].HeaderText = "شماره تماس";

        }
        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        try
            {
                cmd.Parameters.Clear();
                cmd.Connection = con;

                // اعتبارسنجی پسورد
                string password = txtPass.Text;
                if (password.Length < 8)
                {
                    MessageBox.Show("پسورد باید حداقل ۸ کاراکتر داشته باشد.");
                    return;
                }
                if (password.Length > 50)
                {
                    MessageBox.Show("پسورد نمی‌تواند بیشتر از ۵۰ کاراکتر باشد.");
                    return;
                }
                if (!password.Any(char.IsUpper))
                {
                    MessageBox.Show("پسورد باید حداقل یک حرف بزرگ داشته باشد.");
                    return;
                }
                if (!password.Any(char.IsLower))
                {
                    MessageBox.Show("پسورد باید حداقل یک حرف کوچک داشته باشد.");
                    return;
                }
                if (!password.Any(char.IsDigit))
                {
                    MessageBox.Show("پسورد باید حداقل یک عدد داشته باشد.");
                    return;
                }

                // اعتبارسنجی شماره تماس
                string phone = txtPhoneNumber.Text;
                if (string.IsNullOrWhiteSpace(phone))
                {
                    MessageBox.Show("شماره تماس نمی‌تواند خالی باشد.");
                    return;
                }
                if (!phone.All(char.IsDigit))
                {
                    MessageBox.Show("شماره تماس باید فقط شامل ارقام باشد.");
                    return;
                }
                if (phone.Length != 11)
                {
                    MessageBox.Show("شماره تماس باید دقیقاً ۱۱ رقم باشد.");
                    return;
                }

                string hashedPassword = HashHelper.ComputeSha256Hash(password);

                // ثبت در دیتابیس
                cmd.CommandText = "INSERT INTO Karbar(UName, Password, PhoneNumber) VALUES(@a, @b, @c)";
                cmd.Parameters.AddWithValue("@a", txtUName.Text);
                cmd.Parameters.AddWithValue("@b", hashedPassword);
                cmd.Parameters.AddWithValue("@c", phone);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Display();
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
                    int x = Convert.ToInt32(dgvUser.SelectedCells[0].Value);
                    cmd.Parameters.Clear();
                    cmd.Connection = con;
                    cmd.CommandText = "Delete From Karbar where id=@N";
                    cmd.Parameters.AddWithValue("@N", x);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Display();
                    MessageBox.Show("حذف انجام شد");
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
                cmd.CommandText = "Update Karbar set UName='" + txtUName.Text + "',Password='" + txtPass.Text + "' where id=" + Convert.ToInt32(dgvUser.SelectedCells[0].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBox.Show("ویرایش انجام شد");
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        private void dgvUser_MouseUp(object sender, MouseEventArgs e)
        {
            txtUName.Text = dgvUser[1, dgvUser.CurrentRow.Index].Value.ToString();
            txtPass.Text = dgvUser[1, dgvUser.CurrentRow.Index].Value.ToString();
        }

        private void txtUName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
