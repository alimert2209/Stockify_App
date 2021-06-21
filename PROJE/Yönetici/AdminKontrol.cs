using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; //regex için kullanılan kütüphane
using System.Threading.Tasks;
using System.Security.Cryptography; //şifrelemek için kullanılan kütüphane

namespace PROJE
{
    class AdminKontrol
    {
        public static bool AdKontrol(string k_ad)
        {
            bool check = true;
            if (k_ad == "")
            {
                check = false;
            }
            foreach (var item in k_ad)
            {
                if (char.IsWhiteSpace(item))
                    check = false;
            }
            return check;
        }

        public static bool PostaKontrol(string email)
        {
            const string strRegex = @"^([a-zA-Z0-9_\-\.]+)@(([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$";
            /* ^ satır başını ifade eder.
            [a-zA-Z0-9_\-\.] bu kısım @ işaretinden önce a'dan z'ye büyük ya da küçük harf,
            0'dan 9'a rakamlar ve _'den .'ya özel karakterler koyulabilmesini sağlar.
            + işareti belirlenen grubun birden fazla tekrarlanmasına olanak sağlar.
            | ya da işaretidir.
            {} parantez içindeki ilk ifade kendinden önceki ifadenin en az kaç defa tekrarlanması gerektiğini gösterir,
            ikinci ifade ise en çok kaç defa tekrarlanacağını gösterir.
            \ escape işaretidir.
            $ satır sonunu ifade eder */

            return (new Regex(strRegex)).IsMatch(email);
        }

        public static bool SifreKontrol(string sifre)
        {
            bool check = false;

            //Şifrenin uygun kriterleri sağlayıp sağlamadığını kontrol eder
            foreach (var item in sifre)
                if (char.IsNumber(item) && !char.IsWhiteSpace(item) && char.IsUpper(item) && (char.IsPunctuation(item) || char.IsSymbol(item)))
                    check = true;

            if (check == true && sifre.Length > 3) //kritirleri geçmişse ve uzunluğu en az 4 karakterse şifreyi kabul eder
                return true;
            else
                return false;
        }

        public static string Hashleme(string sifre)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider(); //md5 şifreleme için kullanılan class
            byte[] bt = Encoding.UTF8.GetBytes(sifre); //şifrelenecek stringi byte dizisine çevirir
            bt = md5.ComputeHash(bt); //byte dizisindeki verileri md5 ile şifreler

            StringBuilder sb = new StringBuilder(); //byte yapılan stringi tekrar stringe çevirmek için kullanılan builder
            foreach (byte item in bt) //şifrelenmiş diziyi stringe dönüştürerek sb değişkeninin sonuna ekler
                sb.Append(item.ToString("x2").ToLower());

            return sb.ToString(); //şifrelenmiş metnin son halini return eder
        }
    }
}
