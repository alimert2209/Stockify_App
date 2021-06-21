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
    public partial class FiyatDuzenle : Form
    {
        OleDbConnection connect = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Data.accdb");
        DataTable BirimDuzenle = new DataTable();

        public FiyatDuzenle()
        {
            InitializeComponent();
            textBox_Duzenle_Arama.Text = "";
            textBox_Duzenle_UrunAdi.Text = "";
            textBox_Duzenle_AlisFiyati.Text = "";
            textBox_Duzenle_SatisFiyati.Text = "";
        }

        private void FiyatDuzenle_Load(object sender, EventArgs e)
        {
            Database.Listele("ID, Ürün_Kodu, Tedarikçi, Kategori, Kumaş_Türü, Özellik, Renk, Alış_Fiyatı, Satış_Fiyatı", BirimDuzenle, dataGridView_Duzenle, connect);
            dataGridView_Duzenle.Columns["ID"].Visible = false;
            Database.Gorunum(dataGridView_Duzenle);
        }

        private void textBox_Duzenle_Arama_TextChanged(object sender, EventArgs e)
        {
            Database.Arama("Ürün_Kodu, Tedarikçi, Kategori, Kumaş_Türü, Özellik, Renk, Alış_Fiyatı, Satış_Fiyatı", BirimDuzenle, dataGridView_Duzenle, textBox_Duzenle_Arama.Text, connect);
        } //arama

        private void ıconButton_FiyatDuzenle_Click(object sender, EventArgs e)
        {
            notifyIconDegistir.Visible = true;

            if (textBox_Duzenle_UrunAdi.Text == "")
            {
                Message.Show("Lütfen değiştirmek istediğiniz ürünü seçiniz!", true);
            }
            else
            {
                try
                {
                    //sayının ondalık kısmını belirtmek için virgüle alternatif olarak noktayı sunar
                    textBox_Duzenle_AlisFiyati.Text = textBox_Duzenle_AlisFiyati.Text.Replace('.', ',');
                    textBox_Duzenle_SatisFiyati.Text = textBox_Duzenle_SatisFiyati.Text.Replace('.', ',');
                    //Alış ve satış fiyatı yerine karakter girmesi durumunda alıcanak hatayı denetlemek için yazılan kod parçacığı
                    if (double.Parse(textBox_Duzenle_AlisFiyati.Text) > 0 && double.Parse(textBox_Duzenle_SatisFiyati.Text) > 0)
                    {
                        if (textBox_Duzenle_AlisFiyati.Text != dataGridView_Duzenle.CurrentRow.Cells["Alış_Fiyatı"].Value.ToString() || textBox_Duzenle_SatisFiyati.Text != dataGridView_Duzenle.CurrentRow.Cells["Satış_Fiyatı"].Value.ToString())
                        {
                            if (connect.State != ConnectionState.Open) connect.Open();
                            OleDbCommand komut = new OleDbCommand("update Urunler set Alış_Fiyatı='" + textBox_Duzenle_AlisFiyati.Text + "', Satış_Fiyatı='" + textBox_Duzenle_SatisFiyati.Text + "' where ID=" + dataGridView_Duzenle.CurrentRow.Cells["ID"].Value.ToString() + "", connect);
                            //dataGridView üzerinde seçilen ürünün alış satış fiyatını güncelleyen veri tabanı sorgusu
                            komut.ExecuteNonQuery(); //veri tabanı sorgusunu çalıştırır
                            if (connect.State != ConnectionState.Closed) connect.Close();


                            //notification
                            notifyIconDegistir.ShowBalloonTip(1, "Başarılı", "Ürün bilgisi başarıyla güncellendi!", ToolTipIcon.None);
                            notifyIconDegistir.Visible = false;

                            BirimDuzenle.Clear(); //veri tablosunu temizler
                            Database.Listele("ID, Ürün_Kodu, Tedarikçi, Kategori, Kumaş_Türü, Özellik, Renk, Alış_Fiyatı, Satış_Fiyatı", BirimDuzenle, dataGridView_Duzenle, connect);
                            //güncellenmiş halini göstermek için temizlenmiş tabloya yeniden listeler

                            textBox_Duzenle_UrunAdi.Text = "";
                            textBox_Duzenle_AlisFiyati.Text = "";
                            textBox_Duzenle_SatisFiyati.Text = "";
                            textBox_Duzenle_Arama.Text = "";

                        }
                        else
                        {
                            Message.Show("Alış ve satış fiyatında herhangi bir değişiklik yapmadınız.", true);
                        }//alış satış fiyatında herhangi bir değişiklik yapmadıysa
                    }
                    else
                    {
                        Message.Show("Lütfen alış ve satış fiyatına negatif değer girmeyiniz!", true);
                    }
                }
                catch (Exception)
                {
                    Message.Show("Lütfen alış ve satış fiyatı yerine karakter girmeyiniz!", true);
                }
            }
        } //fiyat düzenle

        private void dataGridView_Duzenle_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox_Duzenle_UrunAdi.Text = dataGridView_Duzenle.CurrentRow.Cells["Ürün_Kodu"].Value.ToString();
            textBox_Duzenle_AlisFiyati.Text = dataGridView_Duzenle.CurrentRow.Cells["Alış_Fiyatı"].Value.ToString();
            textBox_Duzenle_SatisFiyati.Text = dataGridView_Duzenle.CurrentRow.Cells["Satış_Fiyatı"].Value.ToString();
        } //datagridviewdan bilgileri texte getirir
    }
}
