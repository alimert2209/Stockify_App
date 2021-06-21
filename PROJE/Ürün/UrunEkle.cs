using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJE
{
    public partial class UrunEkle : Form
    {
        OleDbConnection connect = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Data.accdb");
        DataTable eklesil = new DataTable();

        public UrunEkle()
        {
            InitializeComponent();
        }

        private void UrunEkle_Load(object sender, EventArgs e)
        {
            Database.Listele("Ürün_Kodu, Tedarikçi, Kategori, Kumaş_Türü, Özellik, Renk, Alış_Fiyatı, Satış_Fiyatı", eklesil, dataGridView_EkleSil, connect);
            Database.Gorunum(dataGridView_EkleSil);

            #region Design
            textBox_UrunEkle_Ad.Text = "";
            textBox_UrunEkle_Renk.Text = "";
            textBoxTedarikci.Text = "";

            a = true;
            textBox_EkleSil_KumasTuru.Text = "Pamuklu";
            textBox_EkleSil_KumasTuru.ForeColor = Color.FromArgb(224, 223, 202);
            textBox_EkleSil_KumasTuru.Font = new Font(textBox_EkleSil_KumasTuru.Font, FontStyle.Italic);
            b = true;
            textBox_EkleSil_UrunOzellik.Text = "V yaka / Bol Paça";
            textBox_EkleSil_UrunOzellik.ForeColor = Color.FromArgb(224, 223, 202);
            textBox_EkleSil_UrunOzellik.Font = new Font(textBox_EkleSil_KumasTuru.Font, FontStyle.Italic);
            c = true;
            textBox_UrunEkle_AlisFiyati.Text = "12,3";
            textBox_UrunEkle_AlisFiyati.ForeColor = Color.FromArgb(224, 223, 202);
            textBox_UrunEkle_AlisFiyati.Font = new Font(textBox_EkleSil_KumasTuru.Font, FontStyle.Italic);
            d = true;
            textBox_UrunEkle_SatisFiyati.Text = "15,7";
            textBox_UrunEkle_SatisFiyati.ForeColor = Color.FromArgb(224, 223, 202);
            textBox_UrunEkle_SatisFiyati.Font = new Font(textBox_EkleSil_KumasTuru.Font, FontStyle.Italic);
            #endregion Design
        }

        #region enteringDesign
        private bool a = true, b = true, c = true, d = true;

        private void textBox_EkleSil_KumasTuru_Enter(object sender, EventArgs e)
        {
            if (a)
            {
                textBox_EkleSil_KumasTuru.Text = "";
                textBox_EkleSil_KumasTuru.ForeColor = Color.FromArgb(198, 209, 227);
                textBox_EkleSil_KumasTuru.Font = new Font(textBox_EkleSil_KumasTuru.Font, FontStyle.Regular);
                a = false;
            }
        }

        private void textBox_EkleSil_UrunOzellik_Enter(object sender, EventArgs e)
        {
            if (b)
            {
                textBox_EkleSil_UrunOzellik.Text = "";
                textBox_EkleSil_UrunOzellik.ForeColor = Color.FromArgb(198, 209, 227);
                textBox_EkleSil_UrunOzellik.Font = new Font(textBox_EkleSil_KumasTuru.Font, FontStyle.Regular);
                b = false;
            }
        }

        private void textBox_UrunEkle_AlisFiyati_Enter(object sender, EventArgs e)
        {
            if (c)
            {
                textBox_UrunEkle_AlisFiyati.Text = "";
                textBox_UrunEkle_AlisFiyati.ForeColor = Color.FromArgb(198, 209, 227);
                textBox_UrunEkle_AlisFiyati.Font = new Font(textBox_EkleSil_KumasTuru.Font, FontStyle.Regular);
                c = false;
            }
        }

        private void textBox_UrunEkle_SatisFiyati_Enter(object sender, EventArgs e)
        {
            if (d)
            {
                textBox_UrunEkle_SatisFiyati.Text = "";
                textBox_UrunEkle_SatisFiyati.ForeColor = Color.FromArgb(198, 209, 227);
                textBox_UrunEkle_SatisFiyati.Font = new Font(textBox_EkleSil_KumasTuru.Font, FontStyle.Regular);
                d = false;
            }
        }
        #endregion

        private void ıconButton_UrunEkle_Click(object sender, EventArgs e)
        {
            notifyIconEkle.Visible = true;

            if (textBox_UrunEkle_Ad.Text == "" || textBox_EkleSil_KumasTuru.Text == "" || textBox_EkleSil_UrunOzellik.Text == "" || textBox_UrunEkle_Renk.Text == "" || textBoxTedarikci.Text == "")
            {
                Message.Show("Lütfen gerekli alanları doldurunuz.", true);
            }
            else
            {
                try
                {
                    if (double.Parse(textBox_UrunEkle_AlisFiyati.Text) > 0 && double.Parse(textBox_UrunEkle_SatisFiyati.Text) > 0)
                    {
                        textBox_UrunEkle_AlisFiyati.Text = textBox_UrunEkle_AlisFiyati.Text.Replace('.', ',');
                        textBox_UrunEkle_SatisFiyati.Text = textBox_UrunEkle_SatisFiyati.Text.Replace('.', ',');

                        if (Message.Show("Kategori özellikleri daha sonra değiştirilemez, işleme devam etmek istiyor musunuz?"))
                        {
                            string urunKod = UrunKodu();

                            connect.Open();
                            OleDbCommand komut = new OleDbCommand("insert into Urunler(Ürün_Kodu, Kategori,Alış_Fiyatı,Satış_Fiyatı, Kumaş_Türü, Özellik, Renk, Tedarikçi) values('" + urunKod + "','" + textBox_UrunEkle_Ad.Text + "','" + textBox_UrunEkle_AlisFiyati.Text + "','" + textBox_UrunEkle_SatisFiyati.Text + "','" + textBox_EkleSil_KumasTuru.Text + "','" + textBox_EkleSil_UrunOzellik.Text + "', '" + textBox_UrunEkle_Renk.Text + "','" + textBoxTedarikci.Text + "')", connect);
                            //bilgileri girilen ürünü veri tabanına ekler
                            komut.ExecuteNonQuery();
                            connect.Close();

                            //notification
                            notifyIconEkle.ShowBalloonTip(1000, "Başarılı", "Ürün başarıyla eklendi!", ToolTipIcon.None);
                            notifyIconEkle.Visible = false;

                            eklesil.Clear();
                            Database.Listele("Ürün_Kodu, Tedarikçi, Kategori, Alış_Fiyatı, Satış_Fiyatı, Kumaş_Türü, Özellik, Renk", eklesil, dataGridView_EkleSil, connect);

                            textBox_UrunEkle_Ad.Text = "";
                            textBox_UrunEkle_AlisFiyati.Text = "";
                            textBox_UrunEkle_SatisFiyati.Text = "";
                            textBox_EkleSil_KumasTuru.Text = "";
                            textBox_EkleSil_UrunOzellik.Text = "";
                            textBox_UrunEkle_Renk.Text = "";
                            textBoxTedarikci.Text = "";
                        }
                    }
                    else
                    {
                        Message.Show("Lütfen alış ve satış fiyatı yerine negatif değer girmeyiniz!", true);
                    }
                }
                catch (Exception)
                {
                    Message.Show("Lütfen alış ve satış fiyatı yerine karakter girmeyiniz!", true);
                }
            }
        } //Ekle butonu

        private string UrunKodu()
        {
            Random random = new Random();

            while (true)
            {
                string urunKod = textBox_UrunEkle_Ad.Text[0].ToString().ToUpper() + textBox_EkleSil_KumasTuru.Text[0].ToString().ToUpper() +
                                  textBox_EkleSil_UrunOzellik.Text[0].ToString().ToUpper() + textBox_UrunEkle_Renk.Text[0].ToString().ToUpper() + "-" +
                                  Math.Truncate(double.Parse(textBox_UrunEkle_AlisFiyati.Text)).ToString() + "-" +
                                  Math.Truncate(double.Parse(textBox_UrunEkle_SatisFiyati.Text)).ToString() + "-";

                for (int i = 0; i < 16 - urunKod.Length; i++)
                {
                    urunKod += random.Next(0, 10).ToString();
                }

                connect.Open();
                OleDbCommand isOK = new OleDbCommand("Select * from Urunler where Ürün_Kodu='" + urunKod + "'", connect);
                OleDbDataAdapter adap = new OleDbDataAdapter(isOK);
                DataTable urun = new DataTable();
                adap.Fill(urun);
                connect.Close();

                if (urun.Rows.Count != 1)
                    return urunKod;
            }
        } //ürün kodu oluşturan metot
    }
}
