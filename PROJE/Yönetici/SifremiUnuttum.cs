using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net.Mail; //for mail

namespace PROJE
{
    public partial class SifremiUnuttum : Form
    {
        OleDbConnection connect = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Data.accdb");

        private string kod;
        private string lastKod;

        private int saniye;
        private int dakika;

        public SifremiUnuttum()
        {
            InitializeComponent();
            ıconButton_SifreUnuttum_Degistir.Enabled = false;
            labelKalanSure.Visible = false;
            lastKod = "";
            labelKalanSure.Text = "1:30";
        }
        private void SifremiUnuttum_Load(object sender, EventArgs e)
        {
            textBox_SifreUnuttum_Ad.Text = "";
            textBox_SifreUnuttum_Mail.Text = "";
            textBox_SifreUnuttum_Sifre.Text = "";
            textBox_SifreUnuttum_Onay.Text = "";
        }

        private void checkBox_SifremiUnuttum_Sifre_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_SifremiUnuttum_Sifre.Checked)
            {
                textBox_SifreUnuttum_Sifre.UseSystemPasswordChar = false;
                textBox_SifreUnuttum_Onay.UseSystemPasswordChar = false;
            }
            else
            {
                textBox_SifreUnuttum_Sifre.UseSystemPasswordChar = true;
                textBox_SifreUnuttum_Onay.UseSystemPasswordChar = true;
            }
        } //şifre göster

        private void ıconButton_SifreUnuttum_Degistir_Click(object sender, EventArgs e)
        {
            //eğer gerekli alanlar doluysa
            if (textBox_SifreUnuttum_Ad.Text != "" && textBox_SifreUnuttum_Sifre.Text != "" && textBox_SifreUnuttum_Onay.Text != "" && textBox_SifreUnuttum_Kod.Text != "")
            {
                connect.Open();
                OleDbCommand komut = new OleDbCommand("Select * from Admins where Admin_Adı='" + textBox_SifreUnuttum_Ad.Text.Trim() + "'and Admin_Mail='" + AdminKontrol.Hashleme(AdminKontrol.Hashleme(AdminKontrol.Hashleme(textBox_SifreUnuttum_Mail.Text.Trim()))) + "'", connect);
                //şifresi değiştirilmek istenen hesabın veri tabanında kayıtlı olup olmadığını kontrol eder
                OleDbDataAdapter adap = new OleDbDataAdapter(komut);
                DataTable admin = new DataTable();
                adap.Fill(admin);
                connect.Close();

                if (admin.Rows.Count == 1) //eğer hesap kayıtlıysa
                {
                    if (lastKod != textBox_SifreUnuttum_Kod.Text || lastKod == "") //aktivasyon kodunun süresi dolmadıysa
                    {
                        if (kod == textBox_SifreUnuttum_Kod.Text) //girilen akivasyon kodu ile mailde yollanan kod eşleşiyorsa
                        {
                            if (textBox_SifreUnuttum_Sifre.Text == textBox_SifreUnuttum_Onay.Text) //şifre ve onay şifresi eşleşiyorsa
                            {
                                if (AdminKontrol.SifreKontrol(textBox_SifreUnuttum_Sifre.Text)) //koyulmak istenen şifre formata uyuyorsa
                                {
                                    connect.Open();
                                    OleDbCommand komut2 = new OleDbCommand("update Admins set Admin_Şifre='" + AdminKontrol.Hashleme(AdminKontrol.Hashleme(AdminKontrol.Hashleme(textBox_SifreUnuttum_Sifre.Text.Trim()))) + "'where Admin_Adı='" + textBox_SifreUnuttum_Ad.Text.Trim() + "'and Admin_Mail='" + AdminKontrol.Hashleme(AdminKontrol.Hashleme(AdminKontrol.Hashleme(textBox_SifreUnuttum_Mail.Text.Trim()))) + "'", connect);
                                    //şifreyi günceller
                                    komut2.ExecuteNonQuery();
                                    connect.Close();

                                    Message.Show("Şifreniz başarıyla güncellendi.",false);
                                    this.Close();
                                }
                                else
                                    Message.Show("Şifreniz uygun değildir!\n\nİdeal şifrede olması gereken özellikler:\n1. En az 4 karakter içermeli\n2. En az bir büyük harf içermeli\n3. En az bir özel karakter içermeli\n4. En az bir sayı içermeli\n5. Boşluk içermemelidir.",480,360,true);
                            }
                            else
                                Message.Show("Girdiğiniz şifreler uyuşmuyor.",true);
                        }
                        else
                            Message.Show("Aktivasyon kodunuz yanlış.",true);
                    }
                    else
                        Message.Show("Aktivasyon kodunuzun süresi dolmuş.",true);
                }
                else
                    Message.Show("Kullanıcı bulunamadı.",true);
            }
            else
                Message.Show("Lütfen gerekli yerleri doldurunuz!",true);
        } //şifreyi yeniler

        private void ıconButton_SifremiUnuttum_Geri_Click(object sender, EventArgs e)
        {
            this.Close();
        } //geri döner

        private void ıconButtonAktivasyonKodu_Click(object sender, EventArgs e)
        {
            if (textBox_SifreUnuttum_Mail.Text.Trim() == "") //mail girilmediyse
            {
                Message.Show("Lütfen mail adresinizi giriniz.",true);
            }
            else //mail adresi girildiyse
            {
                connect.Open();
                OleDbCommand komut = new OleDbCommand("Select * from Admins where Admin_Mail='" +  AdminKontrol.Hashleme(AdminKontrol.Hashleme(AdminKontrol.Hashleme(textBox_SifreUnuttum_Mail.Text.Trim()))) + "'", connect);
                //girilen mail adresinin veri tabanında olup olmadığını kontrol eder
                OleDbDataAdapter adap = new OleDbDataAdapter(komut);
                DataTable admin2 = new DataTable();
                adap.Fill(admin2);
                connect.Close();

                if (admin2.Rows.Count == 1) //mail adresi veri tabanında varsa
                {
                    try
                    {
                        Random random = new Random();
                        kod = random.Next(100000, 1000000).ToString(); //aktivasyon kodu için rastgele bir kod belirlenir

                        #region Mail
                        MailMessage message = new MailMessage(); //mail için mesaj oluşturur
                        SmtpClient client = new SmtpClient(); //mail yollamak için gerekli bağlantı bilgilerini tutar
                        client.Credentials = new System.Net.NetworkCredential("stock.management.project@hotmail.com", "bm102project"); //mail yollayacak hesabın adı ve şifresi eklenir
                        client.Port = 587; //kullanılan port numarası
                        client.Host = "smtp.live.com"; //outlook için gerekli host
                        client.EnableSsl = true; //güvenliği sağlamak amacıyla veriyi şifreli olarak iletir
                        message.To.Add(textBox_SifreUnuttum_Mail.Text); //mailin kime yollanacağını belirler
                        message.From = new MailAddress("stock.management.project@hotmail.com"); //mailin kimden gideceğini belirler
                        message.Subject = "STOCKIFY"; //mail başlığını belirler
                        message.Body = "Merhaba " + textBox_SifreUnuttum_Ad.Text + ";\n\n" + "Unuttuğunuz şifreniz için aktivasyon kodunuz: " + kod; //mail içeriğini belirler
                        client.Send(message); //maili yollar
                        #endregion
                        Message.Show("Aktivasyon kodunuz mail adresinize gönderildi.",false);

                        ıconButton_SifreUnuttum_Degistir.Enabled = true;
                        labelKalanSure.Visible = true;
                        timerKalanSure.Start(); //aktivasyon kodunu girmek için kalan süreyi gösteren sayacı başlatır
                    }
                    catch (Exception)
                    {
                        Message.Show("Kısa bir süreliğine mail hizmetimiz çalışmamaktadır.\nLütfen daha sonra tekrar deneyiniz...",true);
                    }
                }
                else
                    Message.Show("Girdiğiniz mail adresine ait hesap bulunmuyor.",true);
            }
        } //mail yollar

        private void timerKalanSure_Tick(object sender, EventArgs e)
        {
            string[] temp = labelKalanSure.Text.Split(':'); //labelKalanSure labelında bulunan metni dakika ve saniye olarak ikiye böler
            saniye = int.Parse(temp[1]); //saniyeyi temsil eder
            dakika = int.Parse(temp[0]); //dakikayi temsil eder

            if (saniye > 0) //hala saniye varsa
            {
                saniye -= 1; //saniyeyi azalt
                if (saniye / 10 != 0) //saniye çift haneden oluşuyorsa
                {
                    labelKalanSure.Text = dakika.ToString() + ":" + saniye.ToString(); //dakika ve saniyeyi birleştirip ekrana yazdır
                }
                else //saniye tek sayı kaldıysa
                {
                    labelKalanSure.Text = dakika.ToString() + ":0" + saniye.ToString(); //dakika ve saniyeyi düzgün bi formatta ekrana yazdır
                }

            }
            else if (dakika > 0) //hala dakika varsa
            {
                dakika -= 1; //dakikayı azalt
                saniye = 59; //saniyeyi sıfırla
                labelKalanSure.Text = dakika.ToString() + ":" + saniye.ToString();
            }
            else //eğer süre bittiyse
            {
                timerKalanSure.Stop(); //sayacı durdur
                labelKalanSure.Text = "1:30"; //sayacı sıfırla
                labelKalanSure.Visible = false; //sayacın görünürlüğünü kapat
                lastKod = kod; //aktivasyon kodunun süresi artık geçersiz olduğundan bir önceki akticasyon kodunu tutan lastKod'a atama yapar
                Message.Show("Kodunuzun süresi dolmuştur.\nLütfen yeni bir kod talep ediniz.",true);
            }
        } //sayaç
    }
}
