using PROJE.Adapter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJE
{
    public partial class YoneticiEkle : Form
    {
        OleDbConnection connect = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Data.accdb");

        private string tc;
        private string kod;
        private string lastKod;

        private int saniye;
        private int dakika;

        public YoneticiEkle()
        {
            InitializeComponent();
            ıconButton_YöneticiEkle.Enabled = false;
            label1.Visible = false;
            linkLabel_YöneticiEkle.Visible = false;
            label_KalanSure.Visible = false;
            lastKod = "";
            label_KalanSure.Text = "3:00";
        }

        private void YoneticiEkle_Load(object sender, EventArgs e)
        {
            textBox_YöneticiEkle_Ad.Text = "";
            textBox_YöneticiEkle_Mail.Text = "";
            textBox_YöneticiEkle_Sifre.Text = "";
            textBox_YöneticiEkle_Onay.Text = "";
            textBox_YoneticiEkle_Kod.Text = "";

            textBox_YoneticiKontrol_Ad.Text = "";
            textBox_YoneticiKontrol_Soyad.Text = "";
            dateTimePicker.Text = DateTime.Now.ToShortDateString();
            textBox_YoneticiKontrol_TC.Text = "";
        }
        private void ıconButton_SifremiUnuttum_Geri_Click(object sender, EventArgs e)
        {
            tabControl_YoneticiEkle.SelectedIndex = 0;
        } //geri ekle sayfasına yollar

        private void linkLabel_YöneticiEkle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl_YoneticiEkle.SelectedIndex = 1;
        } //yönetici doğrula sayfasına yollae

        private void ıconButtonDoğrula_Click(object sender, EventArgs e)
        {
            try
            {
                //doğrulanmak istenen kişinin bilgileriyle bir person oluşturulur
                Person person = new Person { DateOfYear = int.Parse(DateTime.Parse(dateTimePicker.Value.ToString()).Year.ToString()), firstName = textBox_YoneticiKontrol_Ad.Text, lastName = textBox_YoneticiKontrol_Soyad.Text, NationalityId = textBox_YoneticiKontrol_TC.Text };

                //mernis servisini kullanmak üzere bir adapter oluşturulur
                MernisServiceAdapter adapter = new MernisServiceAdapter();

                if (adapter.CheckIfRealPerson(person)) //adapterda oluşturulan person'ın gerçek insan olduğu doğrulanırsa 
                {
                    connect.Open();
                    OleDbCommand komut = new OleDbCommand("Select * from Admins where TC='" + AdminKontrol.Hashleme(AdminKontrol.Hashleme(AdminKontrol.Hashleme(textBox_YoneticiKontrol_TC.Text))) + "'", connect);
                    //girilen TC Kimlik bilgisiyle daha önce bir yöneticinin kayıt olup olmadığını kontrol eder
                    OleDbDataAdapter adap = new OleDbDataAdapter(komut);
                    DataTable admin = new DataTable();
                    adap.Fill(admin);
                    connect.Close();

                    if (admin.Rows.Count == 1) //kayıtlı yönetici varsa
                    {
                        Message.Show("Bu yönetici daha önce eklenmiş!", true);
                    }
                    else //kayıtlı yönetici yoksa
                    {
                        tc = textBox_YoneticiKontrol_TC.Text; //daha sonra veri tabanına eklenmek üzere değişkene atanır
                        Message.Show("Doğrulama başarılı!", false);
                        tabControl_YoneticiEkle.SelectedIndex = 0;
                        ıconButton_YöneticiEkle.Enabled = true;
                    }

                    textBox_YoneticiKontrol_Ad.Text = "";
                    textBox_YoneticiKontrol_Soyad.Text = "";
                    dateTimePicker.Text = DateTime.Now.ToShortDateString();
                    textBox_YoneticiKontrol_TC.Text = "";
                }
                else
                    Message.Show("Doğrulama başarısız!", true);
            }
            catch (Exception)
            {
                Message.Show("Lütfen gerekli yerleri doldurunuz!", true);
            }
        } //doğrulama

        private void ıconButton_YöneticiEkle_Click(object sender, EventArgs e)
        {
            notifyIconDogrula.Visible = true;

            if (lastKod != textBox_YoneticiEkle_Kod.Text || lastKod == "") //aktivasyon kodunun süresi dolmadıysa
                if (kod == textBox_YoneticiEkle_Kod.Text) //aktivasyon kodu doğruysa
                    if (textBox_YöneticiEkle_Sifre.Text == textBox_YöneticiEkle_Onay.Text) //şifre ve şifre onay uyuşuyorsa
                        if (AdminKontrol.SifreKontrol(textBox_YöneticiEkle_Sifre.Text)) //şifre formatı doğruysa
                            if (AdminKontrol.PostaKontrol(textBox_YöneticiEkle_Mail.Text)) //posta formatı doğruysa
                                if (AdminKontrol.AdKontrol(textBox_YöneticiEkle_Ad.Text)) //ad formatı doğruysa
                                {
                                    connect.Open();
                                    OleDbCommand kmt = new OleDbCommand("Select * from Admins where Admin_Adı='" + textBox_YöneticiEkle_Ad.Text.Trim() + "'", connect);
                                    //girilen kullanıcı adına sahip daha önce bir kullanıcı eklenmiş mi kontrol eder
                                    OleDbDataAdapter adap = new OleDbDataAdapter(kmt);
                                    DataTable admin = new DataTable();
                                    adap.Fill(admin);
                                    connect.Close();

                                    if (admin.Rows.Count == 1) //kullanıcı adı daha önce kullanışsa
                                    {
                                        Message.Show("Bu kullanıcı adı daha önce kullanılmış!", true);
                                    }
                                    else //kullanıcı adı daha önce kullanılmamışsa
                                    {
                                        try
                                        {
                                            connect.Open();
                                            OleDbCommand komut = new OleDbCommand("insert into Admins(Admin_Adı, Admin_Şifre, Admin_Mail, TC) values('" + textBox_YöneticiEkle_Ad.Text.Trim() + "','" + AdminKontrol.Hashleme(AdminKontrol.Hashleme(AdminKontrol.Hashleme(textBox_YöneticiEkle_Sifre.Text.Trim()))) + "','" + AdminKontrol.Hashleme(AdminKontrol.Hashleme(AdminKontrol.Hashleme(textBox_YöneticiEkle_Mail.Text.Trim()))) + "', '" + AdminKontrol.Hashleme(AdminKontrol.Hashleme(AdminKontrol.Hashleme(tc))) + "')", connect);
                                            //kullanıcı Admins tablosuna eklenir
                                            komut.ExecuteNonQuery();
                                            connect.Close();

                                            //notification
                                            notifyIconDogrula.ShowBalloonTip(1000, "Başarılı", "Yönetici başarıyla eklendi!", ToolTipIcon.None);
                                            notifyIconDogrula.Visible = false;

                                            ıconButton_YöneticiEkle.Enabled = false;
                                            label1.Visible = false;
                                            linkLabel_YöneticiEkle.Visible = false;
                                            label_KalanSure.Visible = false;
                                            label_KalanSure.Text = "3:00";
                                            textBox_YöneticiEkle_Ad.Text = "";
                                            textBox_YöneticiEkle_Mail.Text = "";
                                            textBox_YöneticiEkle_Sifre.Text = "";
                                            textBox_YöneticiEkle_Onay.Text = "";
                                            textBox_YoneticiEkle_Kod.Text = "";
                                        }
                                        catch (Exception)
                                        {
                                            Message.Show("Bu mail adresi daha önce kullanılmıştır.", true);
                                        }
                                    }
                                }
                                else
                                    Message.Show("Kullanıcı adı boşluk içeremez!", true);
                            else
                                Message.Show("Mail formatınız hatalı!", true);
                        else
                            Message.Show("Şifreniz uygun değildir!\n\nİdeal şifrede olması gereken özellikler:\n1. En az 4 karakter içermeli\n2. En az bir büyük harf içermeli\n3. En az bir özel karakter içermeli\n4. En az bir sayı içermeli\n5. Boşluk içermemelidir.", 480, 360, true);
                    else
                        Message.Show("Girdiğiniz şifreler uyuşmuyor.", true);
                else
                    Message.Show("Aktivasyon kodunuz yanlış.", true);
            else
                Message.Show("Aktivasyon kodunuzun süresi dolmuş.", true);
        } //yönetici ekler

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox_YöneticiEkle_Sifre.UseSystemPasswordChar = false;
                textBox_YöneticiEkle_Onay.UseSystemPasswordChar = false;
            }
            else
            {
                textBox_YöneticiEkle_Sifre.UseSystemPasswordChar = true;
                textBox_YöneticiEkle_Onay.UseSystemPasswordChar = true;
            }
        } //şifre göster

        private void ıconButton_AktivasyonKodu_Click(object sender, EventArgs e)
        {
            if (textBox_YöneticiEkle_Mail.Text.Trim() == "") //mail adresi girilmemişse
            {
                Message.Show("Lütfen mail adresinizi giriniz.", true);
            }
            else //mail adresi girilmişse
            {
                connect.Open();
                OleDbCommand komut = new OleDbCommand("Select * from Admins where Admin_Mail='" + AdminKontrol.Hashleme(AdminKontrol.Hashleme(AdminKontrol.Hashleme(textBox_YöneticiEkle_Mail.Text.Trim()))) + "'", connect);
                //girilen mail adresi daha önce kulanılmış mı kontrol eder
                OleDbDataAdapter adap = new OleDbDataAdapter(komut);
                DataTable admin2 = new DataTable();
                adap.Fill(admin2);
                connect.Close();

                if (admin2.Rows.Count == 1) //mail daha önce kullanılmışsa
                {
                    Message.Show("Girdiğiniz mail adresine ait hesap bulunuyor.", true);
                }
                else //mail adresi daha önce kullanılmamışsa
                {
                    try
                    {
                        Random random = new Random();
                        kod = random.Next(100000, 1000000).ToString(); //rastgele aktivasyon kodu oluşturur

                        #region Mail
                        MailMessage message = new MailMessage(); //mail için mesaj oluşturur
                        SmtpClient client = new SmtpClient(); //mail yollamak için gerekli bağlantı bilgilerini tutar
                        client.Credentials = new System.Net.NetworkCredential("stock.management.project@hotmail.com", "bm102project"); //mail yollayacak hesabın adı ve şifresi eklenir
                        client.Port = 587; //kullanılan port numarası
                        client.Host = "smtp.live.com"; //outlook için gerekli host
                        client.EnableSsl = true; //güvenliği sağlamak amacıyla veriyi şifreli olarak iletir
                        message.To.Add(textBox_YöneticiEkle_Mail.Text); //mailin kime yollanacağını belirler
                        message.From = new MailAddress("stock.management.project@hotmail.com"); //mailin kimden gideceğini belirler
                        message.Subject = "STOCKIFY"; //mail başlığını belirler
                        message.Body = "Merhaba " + textBox_YöneticiEkle_Ad.Text + ";\n\n" + "Yönetici olabilmek için aktivasyon kodunuz: " + kod; //mail içeriğini belirler
                        client.Send(message); //maili yollar
                        #endregion
                        Message.Show("Aktivasyon kodunuz mail adresinize gönderildi.", false);

                        label1.Visible = true;
                        linkLabel_YöneticiEkle.Visible = true;
                        label_KalanSure.Visible = true;
                        timer_KalanSure.Start();
                    }
                    catch (Exception)
                    {
                        Message.Show("Kısa bir süreliğine mail hizmetimiz çalışmamaktadır.\nLütfen daha sonra tekrar deneyiniz...", true);
                    }
                }
            }
        } //mail yollar

        private void timer_KalanSure_Tick(object sender, EventArgs e)
        {
            string[] temp = label_KalanSure.Text.Split(':'); //labelKalanSure labelında bulunan metni dakika ve saniye olarak ikiye böler
            saniye = int.Parse(temp[1]); //saniyeyi temsil eder
            dakika = int.Parse(temp[0]); //dakikayi temsil eder

            if (saniye > 0) //hala saniye varsa
            {
                saniye -= 1; //saniyeyi azalt
                if (saniye / 10 != 0) //saniye çift haneden oluşuyorsa
                {
                    label_KalanSure.Text = dakika.ToString() + ":" + saniye.ToString(); //dakika ve saniyeyi birleştirip ekrana yazdır
                }
                else //saniye tek sayı kaldıysa
                {
                    label_KalanSure.Text = dakika.ToString() + ":0" + saniye.ToString(); //dakika ve saniyeyi düzgün bi formatta ekrana yazdır
                }
            }
            else if (dakika > 0) //hala dakika varsa
            {
                dakika -= 1; //dakikayı azalt
                saniye = 59; //saniyeyi sıfırla
                label_KalanSure.Text = dakika.ToString() + ":" + saniye.ToString();
            }
            else //eğer süre bittiyse
            {
                timer_KalanSure.Stop(); //sayacı durdur
                label_KalanSure.Text = "3:00"; //sayacı sıfırla
                label_KalanSure.Visible = false; //sayacın görünürlüğünü kapat
                lastKod = kod; //aktivasyon kodunun süresi artık geçersiz olduğundan bir önceki akticasyon kodunu tutan lastKod'a atama yapar
                Message.Show("Kodunuzun süresi dolmuştur.\nLütfen yeni bir kod talep ediniz.", true);
            }
        } //sayaç
    }
}
