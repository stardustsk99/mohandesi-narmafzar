using Stimulsoft.Report;
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
    public partial class frmKharid : Form
    {
        public frmKharid()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        private void dgvFactor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmKharid_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            mskTarikh.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfMonth(DateTime.Now).ToString("0#");
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader dr;
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "select * from Goods where id=@N";
                cmd.Parameters.AddWithValue("@N", txtCode.Text);
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtCode.Text = dr["id"].ToString();
                    txtName.Text = dr["NameGoods"].ToString();
                    txtNumber.Text = dr["Number"].ToString();
                    txtCP.Text = dr["CP"].ToString();


                }
                else
                {
                    txtCode.Clear();
                    txtCode.Focus();
                    MessageBox.Show("برای کد وارد شده اطلاعاتی وجود ندارد");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKhadamat.Text == "" || txtTakhfif.Text == "")
                {
                    MessageBox.Show("لطفا هزینه خدمات یا تخفیف را وارد کنید");
                    return;
                }
                dgvFactor.Rows.Add(txtCode.Text, txtName.Text, txtNumber.Text, txtCP.Text);
                txtCode.Text = "";
                txtName.Text = "";
                txtNumber.Text = "";
                txtCP.Text = "";
                //***********************
                int JameGood = 0;
                int JameKol = 0;
                int TotalCP = 0;
                for (int i = 0; i < dgvFactor.Rows.Count; i++)
                {
                    JameGood = JameGood + (Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value) * Convert.ToInt32(dgvFactor.Rows[i].Cells[3].Value));
                    txtJameGood.Text = JameGood.ToString();

                    TotalCP = Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value) * Convert.ToInt32(dgvFactor.Rows[i].Cells[3].Value);
                    dgvFactor.Rows[i].Cells[4].Value = TotalCP;

                    JameKol = (JameGood + Convert.ToInt32(txtKhadamat.Text)) - Convert.ToInt32(txtTakhfif.Text);
                    txtJameKol.Text = JameKol.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        private void txtJameGood_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            try
            {
                int JameKol = 0;
                JameKol = (Convert.ToInt32(txtJameGood.Text) + Convert.ToInt32(txtKhadamat.Text)) - Convert.ToInt32(txtTakhfif.Text);
                txtJameKol.Text = JameKol.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" مشکلی پیش آمده است\n" + ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                int JameGood = 0;
                int JameGood2 = 0;
                int jameKol = 0;
                JameGood = Convert.ToInt32(dgvFactor.CurrentRow.Cells[4].Value);
                JameGood2 = Convert.ToInt32(txtJameGood.Text) - JameGood;
                txtJameGood.Text = JameGood2.ToString();
                jameKol = Convert.ToInt32(txtJameKol.Text) - JameGood;
                txtJameKol.Text = jameKol.ToString();
                dgvFactor.Rows.RemoveAt(dgvFactor.CurrentRow.Index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        private void btnCheckP_Click(object sender, EventArgs e)
        {
            try
            {
                frmCheckP frm = new frmCheckP();
                frm.txtTozih.Text = "پرداخت مبلغ فاکتور خرید به صورت چک به شماره فاکتور" + txtIdFactor.Text;
                frm.txtNameM.Text = txtNameM.Text;
                frm.txtMablagh.Text = txtJameKol.Text;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" مشکلی پیش آمده است\n" + ex.Message);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            try
            {
                if (txtIdFactor.Text == "")
                {
                    MessageBox.Show("کد فاکتور وارد نشده است");
                    txtIdFactor.Focus();
                    return;
                }

                using (SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true"))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("select CodeFactor from Kharid where CodeFactor=@N", con))
                    {
                        cmd.Parameters.AddWithValue("@N", txtIdFactor.Text);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                txtIdFactor.Text = "";
                                txtIdFactor.Focus();
                                MessageBox.Show("این کد فاکتور قبلا ثبت شده است");
                                return;
                            }
                        }
                    }

                    for (int i = 0; i < dgvFactor.Rows.Count; i++)
                    {
                        if (dgvFactor.Rows[i].IsNewRow) continue; // رد کردن ردیف خالی

                        using (SqlCommand cmd = new SqlCommand("insert into Kharid (CodeFactor, Tarikh, NameM, Tel, Address, id, NameGoods, Number, CP, TotalCP, TotalPGood, Khadamat, Takhfif, JameKol, Tozih) " +
                                                              "values(@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n,@o)", con))
                        {
                            cmd.Parameters.AddWithValue("@a", txtIdFactor.Text);
                            cmd.Parameters.AddWithValue("@b", mskTarikh.Text);
                            cmd.Parameters.AddWithValue("@c", txtNameM.Text);
                            cmd.Parameters.AddWithValue("@d", txtTel.Text);
                            cmd.Parameters.AddWithValue("@e", txtAddress.Text);

                            cmd.Parameters.AddWithValue("@f", Convert.ToInt32(dgvFactor.Rows[i].Cells[0].Value));
                            cmd.Parameters.AddWithValue("@g", dgvFactor.Rows[i].Cells[1].Value);
                            cmd.Parameters.AddWithValue("@h", Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value));
                            cmd.Parameters.AddWithValue("@i", Convert.ToInt32(dgvFactor.Rows[i].Cells[3].Value));
                            cmd.Parameters.AddWithValue("@j", Convert.ToInt32(dgvFactor.Rows[i].Cells[4].Value));

                            int jameGood = string.IsNullOrWhiteSpace(txtJameGood.Text) ? 0 : Convert.ToInt32(txtJameGood.Text);
                            int khadamat = string.IsNullOrWhiteSpace(txtKhadamat.Text) ? 0 : Convert.ToInt32(txtKhadamat.Text);
                            int takhfif = string.IsNullOrWhiteSpace(txtTakhfif.Text) ? 0 : Convert.ToInt32(txtTakhfif.Text);
                            int jameKol = string.IsNullOrWhiteSpace(txtJameKol.Text) ? 0 : Convert.ToInt32(txtJameKol.Text);

                            cmd.Parameters.AddWithValue("@k", jameGood);
                            cmd.Parameters.AddWithValue("@l", khadamat);
                            cmd.Parameters.AddWithValue("@m", takhfif);
                            cmd.Parameters.AddWithValue("@n", jameKol);
                            cmd.Parameters.AddWithValue("@o", txtTozih.Text);

                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand sqlcmd = new SqlCommand("select Number from Goods where id=@iddd", con))
                        {
                            sqlcmd.Parameters.AddWithValue("@iddd", Convert.ToInt32(dgvFactor.Rows[i].Cells[0].Value));
                            int currentNumber = Convert.ToInt32(sqlcmd.ExecuteScalar());

                            int purchasedNumber = Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value);
                            int newNumber = currentNumber + purchasedNumber;

                            using (SqlCommand com = new SqlCommand("Update Goods set Number=@nn where id=@idd", con))
                            {
                                com.Parameters.AddWithValue("@nn", newNumber);
                                com.Parameters.AddWithValue("@idd", Convert.ToInt32(dgvFactor.Rows[i].Cells[0].Value));
                                com.ExecuteNonQuery();
                            }
                        }
                    }
                }
                MessageBox.Show("ثبت با موفقیت انجام شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشکلی پیش آمده است:\n" + ex.Message);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdFactor.Text == "")
                {
                    MessageBox.Show(" لطفا شماره فاکتور را وارد کنید");
                    return;
                }
                StiReport Report = new StiReport();
                Report.Load("Report/rptKharid.mrt");
                Report.Compile();
                Report["CodeFactor"] = Convert.ToInt32(txtIdFactor.Text);
                Report.ShowWithRibbonGUI();
            }
            catch (Exception)
            {
                MessageBox.Show(" مشکلی پیش آمده است");
            }
        }

        private void btnNagd_Click(object sender, EventArgs e)
        {
            try
            {
                con.Close();
                if (txtShH.Text == "")
                {
                    MessageBox.Show("لطفا شماره حساب را وارد کنید");
                    return;
                }
                string str;
                int str1;
                con.Open();
                SqlCommand sqlcmd = new SqlCommand("select Balance from Bank where AcctNum='" + txtShH.Text + "'", con);
                str = Convert.ToString((int)sqlcmd.ExecuteScalar());//مبلغ حساب
                str1 = Convert.ToInt32(txtJameKol.Text);//مبلغ فاکتور
                int sum = Int32.Parse(str) - str1;//مبلغ نهایی حساب
                                                  //**********************************ویرایش موجودی حساب
                string UpdateBalance = "Update bank set Balance='" + sum + "' where AcctNum='" + txtShH.Text + "'";
                SqlCommand com = new SqlCommand(UpdateBalance, con);
                com.ExecuteNonQuery();

                MessageBox.Show(" مبلغ از حساب پرداخت و کسر شد");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            new frmListKharid().ShowDialog();
        }

        private void txtShH_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupPanel4_Click(object sender, EventArgs e)
        {

        }

        private void line3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            frmHelper.ClearFormFields(this);
        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
 