using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalaPezeshki
{
    class frmHelper
    {
        SqlConnection con = new SqlConnection("Data source=HAMY\\SQLEXPRESS;initial catalog=KalaPezeshki;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        public static class UserSession
        {
            public static string Username { get; set; }
            public static string Role { get; set; }
        }
        public static string ToPersianNumbers(string input)
        {
            string[] persianDigits = { "۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹" };
            for (int i = 0; i < 10; i++)
            {
                input = input.Replace(i.ToString(), persianDigits[i]);
            }
            return input;
        }
        

        public static void ConvertNumbersToPersian(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Label || c is Button || c is TextBox)
                {
                    c.Text = ToPersianNumbers(c.Text);
                }

                if (c.HasChildren)
                {
                    ConvertNumbersToPersian(c);
                }
            }
        }
        public static void Backup(string filename)
        {
            SqlConnection con = null;
            try
            {
                string Backup = @"Backup DataBase [KalaPezeshki] To Disk='" + filename + "'";
                SqlCommand cmd = null;
                con = new SqlConnection("Data Source=HAMY\\SQLEXPRESS;Initial Catalog=KalaPezeshki;Integrated Security=True");
                con.Open();
                cmd = new SqlCommand(Backup, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("پشتيبان گيري انجام شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        public static void Restore(string filename)
        {
            SqlConnection con = null;
            try
            {
                string Restore = @"ALTER DATABASE [KalaPezeshki] SET SINGLE_USER with ROLLBACK IMMEDIATE " + " USE master " + " RESTORE DATABASE [KalaPezeshki] FROM DISK= N'" + filename + "'WITH RECOVERY, REPLACE";
                SqlCommand cmd = null;
                con = new SqlConnection("Data Source=HAMY\\SQLEXPRESS;Initial Catalog=KalaPezeshki;Integrated Security=True");
                con.Open();
                cmd = new SqlCommand(Restore, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("بازيابي اطلاعات انجام شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : ", ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public static string GetPersianDateTime()
        {
            DateTime now = DateTime.Now;
            PersianCalendar pc = new PersianCalendar();

            string hour = now.Hour.ToString("00");
            string minute = now.Minute.ToString("00");
            string second = now.Second.ToString("00");

            string full = $"{hour}:{minute}:{second}";

            return ToPersianNumbers(full);
        }
        // متد پاک‌سازی فیلدها
        public static void ClearFormFields(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();

                if (c.HasChildren)
                    ClearFormFields(c); // بازگشتی برای کنترل‌های تو در تو
            }
        }
    }
}
