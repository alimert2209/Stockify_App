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
    public partial class YoneticiSil : Form
    {
        OleDbConnection connect = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Data.accdb");

        public static string deleteUser; //silinen kullanıcının o an hesabı açık olan kullanıcı olup olumadığını kontrol etmek için

        public YoneticiSil()
        {
            InitializeComponent();
        }

        private void YoneticiSil_Load(object sender, EventArgs e)
        {
            Goruntule();
        }

        private void ıconButton_YoneticiSil_Click(object sender, EventArgs e)
        {
            notifyIconSil.Visible = true;

            if (comboBox_YoneticiSil.SelectedItem != null) //eğer bir yönetici seçiliyse
            {
                if (comboBox_YoneticiSil.Items.Count > 1) //en az 1 yönetici bulunmak zorundadır bu yüzden 1 yönetici kaldığında silme işlemi yapılamaz
                {
                    if (Message.Show(comboBox_YoneticiSil.SelectedItem.ToString() + " adlı yöneticiyi silmek istediğinize emin misiniz?")) //işlemi onaylarsa
                    {
                        connect.Open();
                        OleDbCommand komut = new OleDbCommand("delete * from Admins where Admin_Adı='" + comboBox_YoneticiSil.SelectedItem.ToString() + "'", connect);
                        //seçilen yöneticiyi veri tabanından siler
                        deleteUser = comboBox_YoneticiSil.SelectedItem.ToString(); //silinen hesabın giriş yapılı olup olmadığını kontrol etmek için kullanılır
                        komut.ExecuteNonQuery();
                        connect.Close();

                        //notification
                        notifyIconSil.ShowBalloonTip(1000, "Başarılı", "Yönetici başarıyla silindi!", ToolTipIcon.None);
                        notifyIconSil.Visible = false;

                        Goruntule();
                    }
                }
                else
                    Message.Show("En az bir yönetici bulunmak zorundadır!", true);
            }
            else
                Message.Show("Yönetici seçmediniz.", true);
        } //yönetici sil

        private void Goruntule()
        {
            comboBox_YoneticiSil.Items.Clear(); //ComboBox’a veri çekerken eski verilerin silinmesini sağlar bu yüzden üst üste birikme olmaz

            connect.Open();
            OleDbCommand komut = new OleDbCommand("SELECT * FROM Admins", connect);
            OleDbDataReader dr = komut.ExecuteReader(); //veritabanından okuma yapabilmek için DataReader olusturduk

            while (dr.Read()) //veritabanındaki Admin_Adı isimli sutundaki verileri sırasıyla ComboBox’a Ekle
                    comboBox_YoneticiSil.Items.Add(dr["Admin_Adı"]); //çekmek istediğimiz sütunun adi yazılır

            dr.Close();
            komut.Dispose();
            connect.Close();
        } //comboboxa veri çeker
    }
}
