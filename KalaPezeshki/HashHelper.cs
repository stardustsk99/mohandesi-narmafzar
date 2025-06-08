using System;
using System.Security.Cryptography;
using System.Text;

namespace KalaPezeshki
{
    // ---------------------------------------------------------------------
    // کلاس کمکی HashHelper برای محاسبه هش SHA-256
    // ---------------------------------------------------------------------
    public static class HashHelper
    {
        // ---------------------------------------------------------------------
        // متد محاسبه‌ی هش SHA-256 از یک رشته ورودی
        // ---------------------------------------------------------------------
        public static string ComputeSha256Hash(string rawData)
        {
            // ایجاد یک شیء از الگوریتم SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // محاسبه هش به صورت آرایه بایت
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // تبدیل آرایه بایت به رشته‌ی هگزادسیمال (Hexadecimal String)
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                // بازگشت رشته‌ی هش محاسبه‌شده
                return builder.ToString();
            }
        }
    }
}