using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.ComponentModel;

namespace KalaPezeshki
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        private bool IsDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;
        }

        // توابع خالی که Designer بهشون وصل شده نباید حذف بشن:
        private void txtPass_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void txtUName_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void btnSave_Click(object sender, EventArgs e) { }
        private void groupPanel1_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void frmLogin1_Load(object sender, EventArgs e) { }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (IsDesignMode()) return;

            try
            {
                string hashedPassword = HashHelper.ComputeSha256Hash(txtPass.Text);
                string query = "SELECT UName, Role FROM Karbar WHERE UName = @N AND Password = @F";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@N", txtUName.Text);
                cmd.Parameters.AddWithValue("@F", hashedPassword);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    frmHelper.UserSession.Username = reader["UName"].ToString();
                    frmHelper.UserSession.Role = reader["Role"].ToString();

                    reader.Close();
                    con.Close();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    con.Close();
                    MessageBox.Show("کاربری با این مشخصات وجود ندارد");
                }
            }
            catch (Exception ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();

                MessageBox.Show("خطا در اتصال به پایگاه داده:\n" + ex.Message);
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            if (IsDesignMode()) return;

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ChkPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ChkPassword.Checked)
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }

        private void txtUName_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
