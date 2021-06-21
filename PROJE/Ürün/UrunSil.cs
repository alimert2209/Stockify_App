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
    public partial class UrunSil : Form
    {
        OleDbConnection connect = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Data.accdb");
        DataTable sil = new DataTable();

        public UrunSil()
        {
            InitializeComponent();
            textBox_EkleSil_Arama.Text = "";
        }

        private void UrunSil_Load(object sender, EventArgs e)
        {
            Database.Listele("Ürün_Kodu, Tedarikçi, Kategori, Kumaş_Türü, Özellik, Renk, Alış_Fiyatı, Satış_Fiyatı, ID", sil, dataGridView_Sil, connect);
            dataGridView_Sil.Columns["ID"].Visible = false;
            Database.Gorunum(dataGridView_Sil);
        }

        private void textBox_EkleSil_Arama_TextChanged(object sender, EventArgs e)
        {
            Database.Arama("Ürün_Kodu, Tedarikçi, Kategori, Alış_Fiyatı, Satış_Fiyatı, Kumaş_Türü, Özellik, Renk, ID", sil, dataGridView_Sil, textBox_EkleSil_Arama.Text, connect);
        } //arama

        private void ıconButton_UrunSil_Click(object sender, EventArgs e)
        {
            if (dataGridView_Sil.CurrentRow != null) //silmek için seçtiyse
            {
                //silme işlemi onaylanırsa
                if (Message.Show("Ürün silme işlemi geri alınamaz, devam etmek istiyor musunuz?"))
                {
                    connect.Open();
                    OleDbCommand komut = new OleDbCommand("delete * from Urunler where ID=" + dataGridView_Sil.CurrentRow.Cells["ID"].Value.ToString() + "", connect);
                    //seçilen ürünü veri tabanından siler
                    komut.ExecuteNonQuery();
                    connect.Close();

                    //notification
                    notifyIconUrunSil.ShowBalloonTip(1000, "Başarılı", "Ürün başarıyla silindi!", ToolTipIcon.None);
                    notifyIconUrunSil.Visible = false;


                    textBox_EkleSil_Arama.Text = "";
                    sil.Clear(); //tabloyu temizler
                    Database.Listele("Ürün_Kodu, Tedarikçi, Kategori, Alış_Fiyatı, Satış_Fiyatı, Kumaş_Türü, Özellik, Renk, ID", sil, dataGridView_Sil, connect);
                    //temizlenen tabloyu güncellenmiş veriyle doldurur
                }
            }
            else
                Message.Show("Lütfen silmek istediğiniz ürünü seçiniz!",true);
        } //Sil butonu
    }
}
