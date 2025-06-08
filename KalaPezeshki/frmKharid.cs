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

        // تعریف اتصال به دیتابیس SQL Server
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");

        // شی فرمان SQL برای اجرای دستورات
        SqlCommand cmd = new SqlCommand();

        // رویداد کلیک روی سلول‌های DataGridView (در حال حاضر بدون استفاده)
        private void dgvFactor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // رویداد بارگذاری فرم - مقداردهی اولیه تاریخ به صورت شمسی
        private void frmKharid_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            mskTarikh.Text = p.GetYear(DateTime.Now).ToString()
                           + p.GetMonth(DateTime.Now).ToString("0#")
                           + p.GetDayOfMonth(DateTime.Now).ToString("0#");
        }

        // رویداد کلیک دکمه "جستجو" - جستجوی کالا براساس کد کالا
        private void btnS_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader dr;
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Goods WHERE id=@N";
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
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        // رویداد کلیک دکمه "افزودن" - افزودن کالا به فاکتور خرید
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // بررسی اینکه هزینه خدمات و تخفیف وارد شده باشند
                if (txtKhadamat.Text == "" || txtTakhfif.Text == "")
                {
                    MessageBox.Show("لطفا هزینه خدمات یا تخفیف را وارد کنید");
                    return;
                }

                // افزودن ردیف جدید به DataGridView فاکتور
                dgvFactor.Rows.Add(txtCode.Text, txtName.Text, txtNumber.Text, txtCP.Text);

                // پاکسازی فیلدهای ورودی کالا پس از افزودن
                txtCode.Text = "";
                txtName.Text = "";
                txtNumber.Text = "";
                txtCP.Text = "";

                // *******
                // محاسبه جمع کل مبلغ کالاها و جمع کل فاکتور
                int JameGood = 0;   // جمع کل مبلغ کالاها
                int JameKol = 0;    // جمع کل نهایی فاکتور
                int TotalCP = 0;    // مبلغ هر ردیف (تعداد × قیمت خرید)

                for (int i = 0; i < dgvFactor.Rows.Count; i++)
                {
                    // محاسبه جمع کل مبلغ کالاها
                    JameGood = JameGood + (Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value) * Convert.ToInt32(dgvFactor.Rows[i].Cells[3].Value));
                    txtJameGood.Text = JameGood.ToString();

                    // محاسبه مبلغ ردیف جاری
                    TotalCP = Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value) * Convert.ToInt32(dgvFactor.Rows[i].Cells[3].Value);
                    dgvFactor.Rows[i].Cells[4].Value = TotalCP;

                    // محاسبه جمع کل فاکتور (کالاها + خدمات - تخفیف)
                    JameKol = (JameGood + Convert.ToInt32(txtKhadamat.Text)) - Convert.ToInt32(txtTakhfif.Text);
                    txtJameKol.Text = JameKol.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }
        // رویداد تغییر متن txtJameGood (در حال حاضر بدون استفاده)
        private void txtJameGood_TextChanged(object sender, EventArgs e)
        {

        }

        // رویداد کلیک دکمه "محاسبه جمع کل" - محاسبه جمع کل فاکتور
        private void btnSum_Click(object sender, EventArgs e)
        {
            try
            {
                int JameKol = 0;

                // جمع کل فاکتور = جمع کالاها + هزینه خدمات - تخفیف
                JameKol = (Convert.ToInt32(txtJameGood.Text) + Convert.ToInt32(txtKhadamat.Text)) - Convert.ToInt32(txtTakhfif.Text);

                txtJameKol.Text = JameKol.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        // رویداد کلیک دکمه "حذف ردیف از فاکتور"
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int JameGood = 0;
                int JameGood2 = 0;
                int jameKol = 0;

                // مبلغ ردیف انتخاب‌شده
                JameGood = Convert.ToInt32(dgvFactor.CurrentRow.Cells[4].Value);

                // به‌روزرسانی جمع کل مبلغ کالاها پس از حذف
                JameGood2 = Convert.ToInt32(txtJameGood.Text) - JameGood;
                txtJameGood.Text = JameGood2.ToString();

                // به‌روزرسانی جمع کل فاکتور پس از حذف
                jameKol = Convert.ToInt32(txtJameKol.Text) - JameGood;
                txtJameKol.Text = jameKol.ToString();

                // حذف ردیف انتخاب‌شده از DataGridView
                dgvFactor.Rows.RemoveAt(dgvFactor.CurrentRow.Index);
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        // رویداد کلیک دکمه "پرداخت چک" - باز کردن فرم ثبت چک پرداختی
        private void btnCheckP_Click(object sender, EventArgs e)
        {
            try
            {
                frmCheckP frm = new frmCheckP();

                // مقداردهی اولیه فیلدهای فرم چک پرداختی
                frm.txtTozih.Text = "پرداخت مبلغ فاکتور خرید به صورت چک به شماره فاکتور" + txtIdFactor.Text;
                frm.txtNameM.Text = txtNameM.Text;
                frm.txtMablagh.Text = txtJameKol.Text;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        // رویداد کلیک دکمه "ذخیره" - ثبت فاکتور خرید در دیتابیس
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false; // غیرفعال‌کردن موقت دکمه برای جلوگیری از دوباره‌کلیک

            try
            {
                // بررسی وارد شدن کد فاکتور
                if (txtIdFactor.Text == "")
                {
                    MessageBox.Show("کد فاکتور وارد نشده است");
                    txtIdFactor.Focus();
                    return;
                }

                // شروع ارتباط با دیتابیس
                using (SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true"))
                {
                    con.Open();

                    // بررسی تکراری نبودن کد فاکتور
                    using (SqlCommand cmd = new SqlCommand("SELECT CodeFactor FROM Kharid WHERE CodeFactor=@N", con))
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

                    // ثبت تک‌تک ردیف‌های کالاهای خرید در جدول Kharid
                    for (int i = 0; i < dgvFactor.Rows.Count; i++)
                    {
                        if (dgvFactor.Rows[i].IsNewRow) continue; // رد کردن ردیف خالی

                        using (SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Kharid (CodeFactor, Tarikh, NameM, Tel, Address, id, NameGoods, Number, CP, TotalCP, TotalPGood, Khadamat, Takhfif, JameKol, Tozih) " +
                            "VALUES(@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n,@o)", con))
                        {
                            // پرکردن پارامترها از مقادیر فرم و DataGridView
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

                            cmd.ExecuteNonQuery(); // اجرای درج اطلاعات ردیف
                        }

                        // افزایش موجودی انبار پس از خرید
                        using (SqlCommand sqlcmd = new SqlCommand("SELECT Number FROM Goods WHERE id=@iddd", con))
                        {
                            sqlcmd.Parameters.AddWithValue("@iddd", Convert.ToInt32(dgvFactor.Rows[i].Cells[0].Value));
                            int currentNumber = Convert.ToInt32(sqlcmd.ExecuteScalar());
                            int purchasedNumber = Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value);
                            int newNumber = currentNumber + purchasedNumber;

                            using (SqlCommand com = new SqlCommand("UPDATE Goods SET Number=@nn WHERE id=@idd", con))
                            {
                                com.Parameters.AddWithValue("@nn", newNumber);
                                com.Parameters.AddWithValue("@idd", Convert.ToInt32(dgvFactor.Rows[i].Cells[0].Value));
                                com.ExecuteNonQuery();
                            }
                        }
                    }
                }
                // پیام موفقیت در ثبت فاکتور
                MessageBox.Show("ثبت با موفقیت انجام شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشکلی پیش آمده است:\n" + ex.Message);
            }
            finally
            {
                btnSave.Enabled = true; // فعال کردن مجدد دکمه ذخیره
            }
        }
        // رویداد کلیک دکمه "چاپ فاکتور خرید"
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdFactor.Text == "")
                {
                    MessageBox.Show("لطفا شماره فاکتور را وارد کنید");
                    return;
                }

                // بارگذاری و چاپ گزارش فاکتور خرید
                StiReport Report = new StiReport();
                Report.Load("Report/rptKharid.mrt");
                Report.Compile();
                Report["CodeFactor"] = Convert.ToInt32(txtIdFactor.Text);
                Report.ShowWithRibbonGUI();
            }
            catch (Exception)
            {
                MessageBox.Show("مشکلی پیش آمده است");
            }
        }

        // رویداد کلیک دکمه "پرداخت نقدی" - کسر مبلغ فاکتور از حساب بانکی
        private void btnNagd_Click(object sender, EventArgs e)
        {
            try
            {
                con.Close();

                // بررسی وارد شدن شماره حساب
                if (txtShH.Text == "")
                {
                    MessageBox.Show("لطفا شماره حساب را وارد کنید");
                    return;
                }

                string str;
                int str1;

                con.Open();

                // دریافت موجودی فعلی حساب
                SqlCommand sqlcmd = new SqlCommand("SELECT Balance FROM Bank WHERE AcctNum='" + txtShH.Text + "'", con);
                str = Convert.ToString((int)sqlcmd.ExecuteScalar());
                str1 = Convert.ToInt32(txtJameKol.Text);

                // محاسبه موجودی جدید پس از کسر مبلغ فاکتور
                int sum = Int32.Parse(str) - str1;

                // به‌روزرسانی موجودی حساب
                string UpdateBalance = "UPDATE Bank SET Balance='" + sum + "' WHERE AcctNum='" + txtShH.Text + "'";
                SqlCommand com = new SqlCommand(UpdateBalance, con);
                com.ExecuteNonQuery();

                MessageBox.Show("مبلغ از حساب پرداخت و کسر شد");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("مشکلی پیش آمده است\n" + ex.Message);
            }
        }

        // رویداد کلیک دکمه "نمایش لیست فاکتورهای خرید"
        private void btnList_Click(object sender, EventArgs e)
        {
            new frmListKharid().ShowDialog();
        }

        // رویداد تغییر متن شماره حساب (فعلاً بدون استفاده)
        private void txtShH_TextChanged(object sender, EventArgs e)
        {

        }

        // رویداد کلیک روی پانل چهارم (فعلاً بدون استفاده)
        private void groupPanel4_Click(object sender, EventArgs e)
        {

        }

        // رویداد کلیک روی خط سوم (فعلاً بدون استفاده)
        private void line3_Click(object sender, EventArgs e)
        {

        }

        // رویداد کلیک روی برچسب شماره 8 (فعلاً بدون استفاده)
        private void label8_Click(object sender, EventArgs e)
        {

        }

        // رویداد کلیک دکمه "پاکسازی فرم"
        private void btnClear_Click(object sender, EventArgs e)
        {
            frmHelper.ClearFormFields(this);
        }

        // رویداد تغییر متن شماره تلفن (فعلاً بدون استفاده)
        private void txtTel_TextChanged(object sender, EventArgs e)
        {

        }

        // رویداد تغییر متن آدرس (فعلاً بدون استفاده)
        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}