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
    public partial class UrunAl : Form
    {
        OleDbConnection connect = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Data.accdb");
        DataTable stok = new DataTable();

        private string beden = "XS"; //varsayılan beden

        public UrunAl()
        {
            InitializeComponent();
        }

        private void UrunAl_Load(object sender, EventArgs e)
        {
            Database.Listele("ID, Ürün_Kodu, Tedarikçi, Kategori, Kumaş_Türü, Özellik, Renk, Alış_Fiyatı, Satış_Fiyatı, Adet, XS, S, M, L, XL, XXL", stok, dataGridView_AlmaSatma, connect);
            dataGridView_AlmaSatma.Columns["ID"].Visible = false;
            Database.Gorunum(dataGridView_AlmaSatma);
            richTextBox_AlmaSatma.Text = "";
            textBox_AlmaSatma_Arama.Text = "";
            numericUpDown_UrunAl.Value = 1;
            radioButton_xs.Checked = true;
        }

        private void textBox_AlmaSatma_Arama_TextChanged(object sender, EventArgs e)
        {
            Database.Arama("Ürün_Kodu, Tedarikçi, Kategori, Alış_Fiyatı, Satış_Fiyatı , Adet, XS, S, M, L, XL, XXL, Kumaş_Türü, Özellik, Renk", stok, dataGridView_AlmaSatma, textBox_AlmaSatma_Arama.Text, connect);
        } //arama

        private void dataGridView_AlmaSatma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            richTextBox_AlmaSatma.Text = "Ürün Kodu: "+ dataGridView_AlmaSatma.CurrentRow.Cells["Ürün_Kodu"].Value.ToString() +
                "\nTedarikçi: " + dataGridView_AlmaSatma.CurrentRow.Cells["Tedarikçi"].Value.ToString() +
                "\nKategori: " + dataGridView_AlmaSatma.CurrentRow.Cells["Kategori"].Value.ToString() +
                "\nAlış Fiyatı: " + dataGridView_AlmaSatma.CurrentRow.Cells["Alış_Fiyatı"].Value.ToString() + " ₺" +
                " | Satış Fiyatı: " + dataGridView_AlmaSatma.CurrentRow.Cells["Satış_Fiyatı"].Value.ToString() + " ₺" + "\n" +
                "Kumaş Türü: " + dataGridView_AlmaSatma.CurrentRow.Cells["Kumaş_Türü"].Value.ToString() +
                "\nKategori Özelliği: " + dataGridView_AlmaSatma.CurrentRow.Cells["Özellik"].Value.ToString() +
                "\nRenk: " + dataGridView_AlmaSatma.CurrentRow.Cells["Renk"].Value.ToString() + "\n" +
                "Adet (XS): " + dataGridView_AlmaSatma.CurrentRow.Cells["XS"].Value.ToString() +
                ", Adet (S): " + dataGridView_AlmaSatma.CurrentRow.Cells["S"].Value.ToString() +
                ", Adet (M): " + dataGridView_AlmaSatma.CurrentRow.Cells["M"].Value.ToString() +
                "\nAdet (L): " + dataGridView_AlmaSatma.CurrentRow.Cells["L"].Value.ToString() +
                ", Adet (XL): " + dataGridView_AlmaSatma.CurrentRow.Cells["XL"].Value.ToString() +
                ", Adet (XXL): " + dataGridView_AlmaSatma.CurrentRow.Cells["XXL"].Value.ToString() +
                "\nAdet (Toplam): " + dataGridView_AlmaSatma.CurrentRow.Cells["Adet"].Value.ToString();
        } //richTexBoxa yazdırma

        private void ıconButton_UrunAl_Click(object sender, EventArgs e)
        {
            double cost = 0;
            int stok = 0;
            int adet = 0;

            if (dataGridView_AlmaSatma.CurrentRow == null)
            {
                Message.Show("Lütfen alınacak ürünü seçiniz.", true);
            }
            else
            {
                adet = Convert.ToInt32(dataGridView_AlmaSatma.CurrentRow.Cells[beden].Value) + Convert.ToInt32(numericUpDown_UrunAl.Value);
                //ürün aldığında son durumda seçtiği bedenden toplam kaç adet olduğunu hesaplar

                stok = Convert.ToInt32(dataGridView_AlmaSatma.CurrentRow.Cells["S"].Value) +
                       Convert.ToInt32(dataGridView_AlmaSatma.CurrentRow.Cells["M"].Value) +
                       Convert.ToInt32(dataGridView_AlmaSatma.CurrentRow.Cells["L"].Value) +
                       Convert.ToInt32(dataGridView_AlmaSatma.CurrentRow.Cells["XL"].Value) +
                       Convert.ToInt32(dataGridView_AlmaSatma.CurrentRow.Cells["XXL"].Value) +
                       Convert.ToInt32(dataGridView_AlmaSatma.CurrentRow.Cells["XS"].Value) + Convert.ToInt32(numericUpDown_UrunAl.Value);
                //aldığı ürünlerle beraber tüm bedenlerin toplamının kaç adet olduğunu hesaplar

                cost = Convert.ToDouble(numericUpDown_UrunAl.Value) * Convert.ToDouble(dataGridView_AlmaSatma.CurrentRow.Cells["Alış_Fiyatı"].Value);
                //aldıklarının tutarını hesaplar

                if (Convert.ToDouble(AnaEkran.budget) < cost) //bütçe yeterli değilse
                {
                    Message.Show("Bütçeniz yeterli değildir.", true);
                }
                else //bütçe yeterliyse
                {
                    //eğer alma işlemini onaylarsa
                    if (Message.Show(dataGridView_AlmaSatma.CurrentRow.Cells["Tedarikçi"].Value.ToString() + " tedarikçisinden " +
                        cost.ToString() + " ₺ karşılığında " + numericUpDown_UrunAl.Value.ToString() + " adet " +
                        beden + " beden " +
                        dataGridView_AlmaSatma.CurrentRow.Cells["Renk"].Value.ToString() + " renkli, " +
                        dataGridView_AlmaSatma.CurrentRow.Cells["Özellik"].Value.ToString() + ", " +
                        dataGridView_AlmaSatma.CurrentRow.Cells["Kumaş_Türü"].Value.ToString() + ", " +
                        dataGridView_AlmaSatma.CurrentRow.Cells["Kategori"].Value.ToString() + " almayı kabul ediyor musunuz?",400,230))
                    {
                        AnaEkran.budget = (Convert.ToDouble(AnaEkran.budget) - cost).ToString(); //bütçeden tutarı düşer

                        connect.Open();
                        OleDbCommand rapor = new OleDbCommand("insert into Rapor(Kullanıcı, Ürün_Kodu, Tedarikçi, Kategori, Adet,Beden, Tutar, Tarih, Saat, Kumaş_Türü, Özellik, Renk) values('" + AnaEkran.user + "','" + dataGridView_AlmaSatma.CurrentRow.Cells["Ürün_Kodu"].Value.ToString() + "','" + dataGridView_AlmaSatma.CurrentRow.Cells["Tedarikçi"].Value.ToString() + "','" + dataGridView_AlmaSatma.CurrentRow.Cells["Kategori"].Value.ToString() + "','" + "+" + numericUpDown_UrunAl.Value.ToString() + "','" + beden + "','" + "-" + cost.ToString() + "','" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToString("HH:mm:ss") + "', '" + dataGridView_AlmaSatma.CurrentRow.Cells["Kumaş_Türü"].Value.ToString() + "','" + dataGridView_AlmaSatma.CurrentRow.Cells["Özellik"].Value.ToString() + "','" + dataGridView_AlmaSatma.CurrentRow.Cells["Renk"].Value.ToString() + "')", connect);
                        //yapılan işlemi rapora kaydeder
                        rapor.ExecuteNonQuery();
                        connect.Close();

                        connect.Open();
                        OleDbCommand komut2;
                        switch (beden) //alınan bedene göre gerekli kod parçacığını çalıştırır
                        {
                            case "XS":
                                komut2 = new OleDbCommand("update Urunler set XS=@Beden, Adet=@Adet where ID=@ID", connect);
                                //alınan ürünün XS beden ve toplam adedini günceller
                                komut2.Parameters.AddWithValue("@Beden", adet);
                                //bu metot veri tabanı sorgusuna girilecek değerin değişken olmasını sağlar
                                komut2.Parameters.AddWithValue("@Adet", stok);
                                komut2.Parameters.AddWithValue("@ID", dataGridView_AlmaSatma.CurrentRow.Cells["ID"].Value);
                                komut2.ExecuteNonQuery();
                                break;
                            case "S":
                                komut2 = new OleDbCommand("update Urunler set S=@Beden, Adet=@Adet where ID=@ID", connect);
                                komut2.Parameters.AddWithValue("@Beden", adet);
                                komut2.Parameters.AddWithValue("@Adet", stok);
                                komut2.Parameters.AddWithValue("@ID", dataGridView_AlmaSatma.CurrentRow.Cells["ID"].Value);
                                komut2.ExecuteNonQuery();
                                break;
                            case "M":
                                komut2 = new OleDbCommand("update Urunler set M=@Beden, Adet=@Adet where ID=@ID", connect);
                                komut2.Parameters.AddWithValue("@Beden", adet);
                                komut2.Parameters.AddWithValue("@Adet", stok);
                                komut2.Parameters.AddWithValue("@ID", dataGridView_AlmaSatma.CurrentRow.Cells["ID"].Value);
                                komut2.ExecuteNonQuery();
                                break;
                            case "L":
                                komut2 = new OleDbCommand("update Urunler set L=@Beden, Adet=@Adet where ID=@ID", connect);
                                komut2.Parameters.AddWithValue("@Beden", adet);
                                komut2.Parameters.AddWithValue("@Adet", stok);
                                komut2.Parameters.AddWithValue("@ID", dataGridView_AlmaSatma.CurrentRow.Cells["ID"].Value);
                                komut2.ExecuteNonQuery();
                                break;
                            case "XL":
                                komut2 = new OleDbCommand("update Urunler set XL=@Beden, Adet=@Adet where ID=@ID", connect);
                                komut2.Parameters.AddWithValue("@Beden", adet);
                                komut2.Parameters.AddWithValue("@Adet", stok);
                                komut2.Parameters.AddWithValue("@ID", dataGridView_AlmaSatma.CurrentRow.Cells["ID"].Value);
                                komut2.ExecuteNonQuery();
                                break;
                            case "XXL":
                                komut2 = new OleDbCommand("update Urunler set XXL=@Beden, Adet=@Adet where ID=@ID", connect);
                                komut2.Parameters.AddWithValue("@Beden", adet);
                                komut2.Parameters.AddWithValue("@Adet", stok);
                                komut2.Parameters.AddWithValue("@ID", dataGridView_AlmaSatma.CurrentRow.Cells["ID"].Value);
                                komut2.ExecuteNonQuery();
                                break;
                            default:
                                break;
                        }
                        OleDbCommand komut = new OleDbCommand("update ButceTablo set Butce='" + AnaEkran.budget + "'", connect);
                        //bütçeyi günceller
                        komut.ExecuteNonQuery();
                        connect.Close();

                        Message.Show("Ürün başarıyla satın alındı.", false);
                        UrunAl_Load(sender, e);
                    }
                }
            }
        } //ürün al butonu

        #region bedenler
        private void radioButton_xs_CheckedChanged(object sender, EventArgs e)
        {
            beden = "XS";
        }

        private void radioButton_s_CheckedChanged(object sender, EventArgs e)
        {
            beden = "S";
        }

        private void radioButton_m_CheckedChanged(object sender, EventArgs e)
        {
            beden = "M";
        }

        private void radioButton_l_CheckedChanged(object sender, EventArgs e)
        {
            beden = "L";
        }

        private void radioButton_xl_CheckedChanged(object sender, EventArgs e)
        {
            beden = "XL";
        }

        private void radioButton_xxl_CheckedChanged(object sender, EventArgs e)
        {
            beden = "XXL";
        }
        #endregion
    }
}
