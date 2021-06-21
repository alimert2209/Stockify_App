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
    public partial class Chat : Form
    {
        OleDbConnection connect = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Data.accdb");

        private string ek = "";

        public Chat()
        {
            InitializeComponent();

            listViewChat.View = View.Details;

            //gelen kutusunun sütun başlıklarını ekler
            listViewChat.Columns.Add("ID", 0);
            listViewChat.Columns.Add("Tarih", -2, HorizontalAlignment.Left);
            listViewChat.Columns.Add("Saat", -2, HorizontalAlignment.Left);
            listViewChat.Columns.Add("Gönderen", -2, HorizontalAlignment.Center);
            listViewChat.Columns.Add("Başlık", -2, HorizontalAlignment.Left);

            listViewGiden.View = View.Details;

            //giden kutusunun sütun başlıklarını ekler
            listViewGiden.Columns.Add("ID", 0);
            listViewGiden.Columns.Add("Tarih", -2, HorizontalAlignment.Left);
            listViewGiden.Columns.Add("Saat", -2, HorizontalAlignment.Left);
            listViewGiden.Columns.Add("Alıcı", -2, HorizontalAlignment.Center);
            listViewGiden.Columns.Add("Başlık", -2, HorizontalAlignment.Left);
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            ek = "";
            labelKullaniciAdi.Text = "Gönderen";
            comboBox_Alicilar.Enabled = true;

            Listele();

            ListeleGiden();
        }

        private void Chat_FormClosed(object sender, FormClosedEventArgs e)
        {
            AnaEkran.isChatOpen = false;
        } //chat formunun açık olup olmadığını anaEkrandan kontrol etmemizi sağlar

        private void Listele()
        {
            listViewChat.Items.Clear(); //listViewdaki satırları temizler
            listViewChat.Refresh();

            if (connect.State == ConnectionState.Closed) connect.Open();
            OleDbCommand komut = new OleDbCommand("SELECT ID, Gönderen, Başlık, Tarih, Saat, isRead FROM Mesajlar where Alıcı like '" + AnaEkran.user + "'", connect);
            OleDbDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["ID"].ToString());
                item.SubItems.Add(dr["Tarih"].ToString());
                item.SubItems.Add(dr["Saat"].ToString());
                item.SubItems.Add(dr["Gönderen"].ToString());
                item.SubItems.Add(dr["Başlık"].ToString());
                if (!dr.GetBoolean(5))
                {
                    item.BackColor = Color.FromArgb(37, 36, 81);
                    item.ForeColor = Color.FromArgb(85, 213, 219);
                }
                listViewChat.Items.Add(item);
            }
            if (connect.State == ConnectionState.Open) connect.Close();
        } //gelen kutusundaki mesaj satırlarını listeler

        private void ListeleGiden()
        {
            listViewGiden.Items.Clear();
            listViewGiden.Refresh();

            if (connect.State == ConnectionState.Closed) connect.Open();
            OleDbCommand komut = new OleDbCommand("SELECT ID, Alıcı, Başlık, Tarih, Saat FROM Mesajlar where Gönderen like '" + AnaEkran.user + "'", connect);
            OleDbDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["ID"].ToString());
                item.SubItems.Add(dr["Tarih"].ToString());
                item.SubItems.Add(dr["Saat"].ToString());
                item.SubItems.Add(dr["Alıcı"].ToString());
                item.SubItems.Add(dr["Başlık"].ToString());
                listViewGiden.Items.Add(item);
            }
            if (connect.State == ConnectionState.Open) connect.Close();
        } //giden kutusundaki mesaj satırlarını listeler

        private void Goruntule()
        {
            comboBox_Alicilar.Items.Clear();

            connect.Open();
            OleDbCommand komut = new OleDbCommand("SELECT * FROM Admins", connect);
            OleDbDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                if (dr["Admin_Adı"].ToString() != AnaEkran.user)
                {
                    comboBox_Alicilar.Items.Add(dr["Admin_Adı"]);
                }
            }

            dr.Close();
            komut.Dispose();
            if (connect.State == ConnectionState.Open) connect.Close();
        } //comboBoxda adminleri sıralar

        private void listViewChat_SizeChanged(object sender, EventArgs e)
        {
            for (int i = 1; i < listViewChat.Columns.Count; i++)
                listViewChat.Columns[i].Width = -2;
        } //listViewChat boyutu değiştikçe responsive yapar

        private void listViewGiden_SizeChanged(object sender, EventArgs e)
        {
            for (int i = 1; i < listViewGiden.Columns.Count; i++)
                listViewGiden.Columns[i].Width = -2;
        } //listViewGiden boyutu değiştikçe responsive yapar

        private void listViewChat_DoubleClick(object sender, EventArgs e)
        {
            int id = int.Parse(listViewChat.SelectedItems[0].SubItems[0].Text);
            if (id > 0)
            {
                if (connect.State == ConnectionState.Closed) connect.Open();
                OleDbCommand komut = new OleDbCommand("SELECT Gönderen, Başlık, Tarih, Saat, İçerik FROM Mesajlar where ID like '" + id.ToString() + "'", connect);
                OleDbDataReader dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    labelBaslik.Text = dr["Başlık"].ToString();
                    labelGonderen.Text = dr["Gönderen"].ToString();
                    labelTarih.Text = dr["Tarih"].ToString() + " , " + dr["Saat".ToString()];
                    labelMessage.Text = dr["İçerik"].ToString();
                }
                if (connect.State == ConnectionState.Open) connect.Close();

                //açılan mesajı okundu olarak günceller
                if (connect.State == ConnectionState.Closed) connect.Open();
                OleDbCommand update = new OleDbCommand("update Mesajlar set isRead= true where ID=" + id + "", connect);
                update.ExecuteNonQuery();
                if (connect.State == ConnectionState.Open) connect.Close();

                tabControlChat.SelectedIndex = 1;
            }
        } //satıra çift tıklandığında gelen mesajın içeriğini görüntülemeyi sağlar

        private void listViewGiden_DoubleClick(object sender, EventArgs e)
        {
            int id = int.Parse(listViewGiden.SelectedItems[0].SubItems[0].Text);
            if (id > 0)
            {
                if (connect.State == ConnectionState.Closed) connect.Open();
                OleDbCommand komut = new OleDbCommand("SELECT Alıcı, Başlık, Tarih, Saat, İçerik FROM Mesajlar where ID like '" + id.ToString() + "'", connect);
                OleDbDataReader dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    labelBaslik.Text = dr["Başlık"].ToString();
                    labelGonderen.Text = dr["Alıcı"].ToString();
                    labelTarih.Text = dr["Tarih"].ToString() + " , " + dr["Saat".ToString()];
                    labelMessage.Text = dr["İçerik"].ToString();
                }
                if (connect.State == ConnectionState.Open) connect.Close();

                labelKullaniciAdi.Text = "Alıcı";

                if (labelKullaniciAdi.Text == "Gönderen")
                {
                    if (connect.State == ConnectionState.Closed) connect.Open();
                    OleDbCommand update = new OleDbCommand("update Mesajlar set isRead= true where ID=" + id + "", connect);
                    update.ExecuteNonQuery();
                    if (connect.State == ConnectionState.Open) connect.Close();
                }

                tabControlChat.SelectedIndex = 1;
            }
        } //satıra çift tıklandığında giden mesajın içeriğini görüntülemeyi sağlar


        #region contextMenu
        private void listViewChat_MouseDown(object sender, MouseEventArgs e)
        {
            bool isRead = false;

            if (e.Button == MouseButtons.Right)
            {
                ListView.SelectedListViewItemCollection selected = this.listViewChat.SelectedItems;
                if (selected.Count > 0)
                    if (!string.IsNullOrEmpty(selected[0].ToString()))
                    {
                        if (connect.State == ConnectionState.Closed) connect.Open();
                        OleDbCommand komut = new OleDbCommand("SELECT isRead FROM Mesajlar where ID like '" + listViewChat.SelectedItems[0].SubItems[0].Text + "'", connect);
                        OleDbDataReader dr = komut.ExecuteReader();

                        while (dr.Read())
                        {
                            isRead = bool.Parse(dr["isRead"].ToString());
                        }
                        if (connect.State == ConnectionState.Open) connect.Close();

                        if (isRead)
                            isReadToolStripMenuItem.Text = "Okunmadı Olarak İşaretle";
                        else
                            isReadToolStripMenuItem.Text = "Okundu Olarak İşaretle";

                        contextMenuStripChat.Show(Cursor.Position); //contextMenu'yü farenin olduğu yerde gösterir
                    }
            }
        } //Mesajın okunup okunmamasına göre contextMenu'de yazacak yazıyı düzenler

        private void isReadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Closed) connect.Open();
            try
            {
                if (isReadToolStripMenuItem.Text.StartsWith("Okunmadı"))
                {
                    OleDbCommand update = new OleDbCommand("update Mesajlar set isRead= false where ID=" + listViewChat.SelectedItems[0].SubItems[0].Text + "", connect);
                    update.ExecuteNonQuery();
                }
                else if (isReadToolStripMenuItem.Text.StartsWith("Okundu"))
                {
                    OleDbCommand update = new OleDbCommand("update Mesajlar set isRead= true where ID=" + listViewChat.SelectedItems[0].SubItems[0].Text + "", connect);
                    update.ExecuteNonQuery();
                }
                Listele();
            }
            catch (Exception)
            {

            }
            if (connect.State == ConnectionState.Open) connect.Close();
        } //contextMenu mesajı okundu olarak işaretle ya da okunmadı olarak işaretle işlevini yapar

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed) connect.Open();
                OleDbCommand komut = new OleDbCommand("delete * from Mesajlar where ID=" + listViewChat.SelectedItems[0].SubItems[0].Text + "", connect);
                komut.ExecuteNonQuery();
                if (connect.State == ConnectionState.Open) connect.Close();

                Listele();
            }
            catch (Exception)
            {

            }
        } //contextMenu mesajı sil işlevini yapar

        private void iletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(listViewChat.SelectedItems[0].SubItems[0].Text);
                if (id > 0)
                {
                    if (connect.State == ConnectionState.Closed) connect.Open();
                    OleDbCommand komut = new OleDbCommand("SELECT Gönderen, Başlık, İçerik, Tarih, Saat FROM Mesajlar where ID like '" + id.ToString() + "'", connect);
                    OleDbDataReader dr = komut.ExecuteReader();

                    while (dr.Read())
                    {
                        richTextBoxMesaj.Text = "\n\n---------- İletilen Mesaj ---------\nGönderen: " + dr["Gönderen"].ToString() + "\n" +
                            "Tarih: " + dr["Tarih"].ToString() + " , " + dr["Saat"].ToString() + "\n" +
                            "Başlık: " + dr["Başlık"].ToString() + "\n" +
                            "Alıcı: " + AnaEkran.user + "\n\n" + dr["İçerik"].ToString();
                    }
                    if (connect.State == ConnectionState.Open) connect.Close();

                    Goruntule();
                    ek = " (İletildi)";

                    tabControlChat.SelectedIndex = 2;

                }
            }
            catch (Exception)
            {

            }
        } //contextMenu ilet işlevini sağlar

        private void yanitlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ıconButtonYanitla_Click(sender, e);
        } //contextMenu yanıtla işlevini sağlar
        #endregion

        private void ıconButton_MesajOlustur_Click(object sender, EventArgs e)
        {
            Goruntule();
            richTextBoxMesaj.Text = "";
            tabControlChat.SelectedIndex = 2;
        } //mesaj oluştur butonuna basınca olacak olayları düzenler

        private void ıconButton_MesajYolla_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_Baslik.Text))
            {
                if (comboBox_Alicilar.SelectedItem != null)
                {
                    if (!string.IsNullOrEmpty(richTextBoxMesaj.Text))
                    {
                        if (connect.State == ConnectionState.Closed) connect.Open();
                        OleDbCommand komut = new OleDbCommand("insert into Mesajlar(Gönderen, Alıcı, Başlık, İçerik, Tarih, Saat) values('" + AnaEkran.user + "','" + comboBox_Alicilar.SelectedItem.ToString() + "','" + textBox_Baslik.Text + ek + "', '" + richTextBoxMesaj.Text + "', '" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToString("HH:mm") + "')", connect);
                        komut.ExecuteNonQuery();
                        if (connect.State == ConnectionState.Open) connect.Close();

                        Message.Show("Mesajınız gönderildi.", false);
                        textBox_Baslik.Text = "";
                        comboBox_Alicilar.SelectedItem = null;
                        richTextBoxMesaj.Text = "";
                        comboBox_Alicilar.Enabled = true;

                        Chat_Load(sender, e);
                    }
                    else
                        Message.Show("Lütfen mesajınızı giriniz.", true);
                }
                else
                    Message.Show("Lütfen alıcı seçiniz.", true);
            }
            else
                Message.Show("Lütfen başlık giriniz.", true);

            ek = "";
        } //mesaj yollar

        private void ıconButton_Geri_Click(object sender, EventArgs e)
        {
            ek = "";
            labelKullaniciAdi.Text = "Gönderen";
            tabControlChat.SelectedIndex = 0;
            listViewChat_SizeChanged(sender, e);
            Listele();
        } //mesaj okuma yerinden geriye dönmeyi sağlar

        private void ıconButtonGeri2_Click(object sender, EventArgs e)
        {
            ek = "";
            comboBox_Alicilar.Enabled = true;
            tabControlChat.SelectedIndex = 0;
        } //mesaj yollama yerinden geriye dönmeyi sağlar

        private void ıconButtonYanitla_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(listViewChat.SelectedItems[0].SubItems[0].Text);
                if (id > 0)
                {
                    if (connect.State == ConnectionState.Closed) connect.Open();
                    OleDbCommand komut = new OleDbCommand("SELECT Gönderen, İçerik, Tarih, Saat FROM Mesajlar where ID like '" + id.ToString() + "'", connect);
                    OleDbDataReader dr = komut.ExecuteReader();

                    comboBox_Alicilar.Items.Clear();

                    while (dr.Read())
                    {
                        comboBox_Alicilar.Items.Add(dr["Gönderen"]);
                        richTextBoxMesaj.Text = "\n\n---------- Yanıtlanan Mesaj ---------\n" + dr["Gönderen"].ToString() + " " +
                            dr["Tarih"].ToString() + " , " + dr["Saat"].ToString() + " tarihinde şunu yazdı:\n" +
                            "\n" + dr["İçerik"].ToString();
                    }
                    if (connect.State == ConnectionState.Open) connect.Close();

                    comboBox_Alicilar.SelectedIndex = 0;
                    comboBox_Alicilar.Enabled = false;

                    ek = " (Cevaplandı)";

                    tabControlChat.SelectedIndex = 2;

                }
            }
            catch (Exception)
            {

            }
        } // mesajı yanıtlar
    }
}
