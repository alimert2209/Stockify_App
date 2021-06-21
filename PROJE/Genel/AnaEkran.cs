using System;
using System.Data; // datatable için gereklü kütüphane
using System.Drawing; // tasarım için gerekli kütüphane
using System.Runtime.InteropServices; //sürükleme için
using System.Windows.Forms;
using FontAwesome.Sharp; //ikonlu butonlar için
using System.Data.OleDb; //veri tabanı için
using System.Diagnostics;

namespace PROJE
{
    public partial class AnaEkran : Form
    {
        OleDbConnection connect = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Data.accdb");

        private IconButton currentButton;
        private Panel leftBorderButton;
        private Form currentForm;

        private int panelWidth;
        private bool isClosed = false;

        private bool isLogin = false;
        public static string budget;
        private byte hak = 3;
        private bool chat;
        public static bool isChatOpen = false;

        static public string user;

        public AnaEkran()
        {
            InitializeComponent(); // designer.cs dosyasını çağırır
            timerTarihSaat.Start();
            panelWidth = panelMenu.Width;
            leftBorderButton = new Panel();
            leftBorderButton.Size = new Size(7, 50);
            panelMenu.Controls.Add(leftBorderButton);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.MinimumSize = new Size(Screen.FromHandle(this.Handle).WorkingArea.Width / 2 + 100, Screen.FromHandle(this.Handle).WorkingArea.Height / 2 + 100);
            this.Size = new Size(Screen.FromHandle(this.Handle).WorkingArea.Width / 3 * 2 + 100, Screen.FromHandle(this.Handle).WorkingArea.Height / 3 * 2 + 100);
        }

        private void AnaEkran_Load(object sender, EventArgs e)
        {
            label_Butce.Text = writeBudget();
            login();
            timerMenu.Start();

            //tarih
            labelTarih.Text = DateTime.Now.ToShortDateString();
        }

        private string writeBudget()
        {
            connect.Open();
            OleDbCommand butce = new OleDbCommand("SELECT Butce FROM ButceTablo WHERE ID=1", connect);
            // yukarıdaki satır veri tabanındaki ButceTablo adlı tablodan butce verisini çeker
            OleDbDataReader dr = butce.ExecuteReader(); //veri tabanındaki veriyi form üzerinde okunabilir kılar

            while (dr.Read()) //ButceTablo adlı tablodaki satır sayısı kadar dönen döngü
                budget = dr["Butce"].ToString();
            dr.Close(); //veriyi form üzerinde okunabilir kılan kısmı kapatır
            butce.Dispose(); // Garbagge Collector ı çalıştırır
            connect.Close();
            return budget + " ₺";
        } //Bütçe yazdıran metot

        private void login()
        {
            if (isLogin) //Giriş yapılmışsa menüdeki butonları aktif et
            {
                ıconButton_UrunBilgi.Enabled = true;
                ıconButton_EkleCikar.Enabled = true;
                ıconButton_Ekle.Enabled = true;
                ıconButton_Cikar.Enabled = true;
                ıconButton_AlimSatim.Enabled = true;
                ıconButton_Alim.Enabled = true;
                ıconButton_Satim.Enabled = true;
                ıconButton_FiyatDuzenle.Enabled = true;
                ıconButton_YoneticiPaneli.Enabled = true;
                ıconButton_YöneticiEkle.Enabled = true;
                ıconButton_YoneticiSil.Enabled = true;
                ıconButton_ZRaporu.Enabled = true;
                ıconButton_YoneticiCikis.Enabled = true;
                pictureBoxLogo.Cursor = Cursors.Hand;
                pictureBoxLogo.Enabled = true;
            }
            else // Giriş yapılmamışsa menüdeki butonların işlevini kapat
            {
                ıconButton_UrunBilgi.Enabled = false;
                ıconButton_EkleCikar.Enabled = false;
                ıconButton_Ekle.Enabled = false;
                ıconButton_Cikar.Enabled = false;
                ıconButton_AlimSatim.Enabled = false;
                ıconButton_Alim.Enabled = false;
                ıconButton_Satim.Enabled = false;
                ıconButton_FiyatDuzenle.Enabled = false;
                ıconButton_YoneticiPaneli.Enabled = false;
                ıconButton_YöneticiEkle.Enabled = false;
                ıconButton_YoneticiSil.Enabled = false;
                ıconButton_ZRaporu.Enabled = false;
                ıconButton_YoneticiCikis.Enabled = false;
                pictureBoxLogo.Cursor = Cursors.Default;
                pictureBoxLogo.Enabled = false;
            }
        } //giriş çıkışlarda enable kontrolü

        private void openChildForm(Form form)
        {
            if (currentForm != null) // herhangi bir form açıksa 
                currentForm.Close(); // o formu kapatır

            currentForm = form; // desktop panelinin içinde açılan formu currentForm'a atar
            form.TopLevel = false; // ana formumuz bu form olmadığı için TopLevel özelliğini kapattık
            form.Dock = DockStyle.Fill; //formu panele sığdırma
            form.FormBorderStyle = FormBorderStyle.None; // formun kenarlarını kapatma
            panelDesktop.Controls.Add(form); // açılan formun panelde görüntülenmesini sağlar
            form.BringToFront(); // açılan formları, giriş ekranının üstüne getirir
            form.Show(); // formu açar
        } //panel içinde açılacak form

        private void activateButton(object sender, int locationY)
        {
            if (sender != null)
            {
                disableButton();
                #region currentButton
                /*bu bölgede menüde herhangi bir sekme seçildiğinde, sekmenin ikonu soldan sağ tarafa geçer,
                 seçilen sekmenin renkleri düzenlenir. Yazı ile ikon ortalanır.*/
                currentButton = (IconButton)sender;//sender'ı IconButton tipine dönüştürüp seçilen butonu currentButton'a atar
                currentButton.BackColor = Color.FromArgb(37, 36, 81);
                currentButton.ForeColor = Color.FromArgb(85, 213, 219);
                currentButton.TextAlign = ContentAlignment.MiddleCenter; // yazıyı ortalar
                currentButton.IconColor = Color.FromArgb(85, 213, 219);
                currentButton.TextImageRelation = TextImageRelation.TextBeforeImage;//ikonla yazıyı yer değiştirir
                currentButton.ImageAlign = ContentAlignment.MiddleRight; // ikonu ortalar
                #endregion

                #region leftBorderButton
                /*Bu bölgede ise seçili sekmeyi belirtmek için sekmenin en solunda oluşan ışık için
                 ince bir panel oluşturur.*/
                leftBorderButton.BackColor = Color.FromArgb(85, 213, 219);
                leftBorderButton.Location = new Point(0, locationY); // ince panelin konumu
                leftBorderButton.Visible = true;
                leftBorderButton.BringToFront();
                #endregion
            }
        } //seçili buton gösterimi

        private void disableButton()
        {
            if (currentButton != null)
            {
                timerKapanma.Enabled = false;

                currentButton.BackColor = Color.FromArgb(28, 26, 43);
                currentButton.ForeColor = Color.FromArgb(198, 209, 227);
                currentButton.TextAlign = ContentAlignment.MiddleLeft;
                currentButton.IconColor = Color.FromArgb(198, 209, 227);
                currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentButton.ImageAlign = ContentAlignment.MiddleLeft;
            }
        } //seçilmeyen butonların disable olması

        private void subButton(object sender)
        {
            ıconButton_Ekle.BackColor = Color.FromArgb(28, 26, 30);
            ıconButton_Cikar.BackColor = Color.FromArgb(28, 26, 30);
            ıconButton_Alim.BackColor = Color.FromArgb(28, 26, 30);
            ıconButton_Satim.BackColor = Color.FromArgb(28, 26, 30);
            ıconButton_YöneticiEkle.BackColor = Color.FromArgb(28, 26, 30);
            ıconButton_YoneticiSil.BackColor = Color.FromArgb(28, 26, 30);

            if (sender != null)
            {
                IconButton button = (IconButton)sender;
                button.BackColor = Color.FromArgb(28, 39, 58);
            }
        } //subMenülerdeki buton renklerini düzenler

        private void hideSubMenu()
        {
            if (panel_AlimSatimMenu.Visible == true)
                panel_AlimSatimMenu.Visible = false;
            if (panel_EkleCıkarMenu.Visible == true)
                panel_EkleCıkarMenu.Visible = false;
            if (panel_YoneticiMenu.Visible == true)
                panel_YoneticiMenu.Visible = false;
        } //sub menüleri gizler

        private void showSubMenu(Panel sub)
        {
            if (sub.Visible == false)
            {
                hideSubMenu();
                sub.Visible = true;
            }
            else
            {
                hideSubMenu();
            }
        } //sub menüleri gösterir

        private void textBox_Admin_Pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;              //Enter tuşu basıldığında çıkan sesi iptal etmek için kullandık.
                ıconButton_Admin_Giris_Click(sender, e);
            }
        } //giriş ekranında şifreyi yazarken enterlayınca giriş yapmayı sağlar

        //Ürün Bilgileri
        private void ıconButton_UrunBilgi_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            activateButton(sender, 100);
            openChildForm(new UrunBilgileri());
            subButton(null);
        }

        //Ürün Ekle - Çıkar
        private void ıconButton_EkleCikar_Click(object sender, EventArgs e)
        {
            activateButton(sender, 150);
            showSubMenu(panel_EkleCıkarMenu);
        }
        #region EkleCikarMenu
        private void ıconButton_Ekle_Click(object sender, EventArgs e)
        {
            subButton(ıconButton_Ekle);
            openChildForm(new UrunEkle());
        }

        private void ıconButton_Cikar_Click(object sender, EventArgs e)
        {
            subButton(ıconButton_Cikar);
            openChildForm(new UrunSil());
        }
        #endregion

        //Ürün Alım- Satım
        private void ıconButton_AlimSatim_Click(object sender, EventArgs e)
        {
            activateButton(sender, 200);
            showSubMenu(panel_AlimSatimMenu);
        }
        #region AlimSatimMenu
        private void ıconButton_Alim_Click(object sender, EventArgs e)
        {
            subButton(ıconButton_Alim);
            openChildForm(new UrunAl());
        }

        private void ıconButton_Satim_Click(object sender, EventArgs e)
        {
            subButton(ıconButton_Satim);
            openChildForm(new UrunSat());
        }
        #endregion

        //Fiyat Düzenle
        private void ıconButton_FiyatDuzenle_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            activateButton(sender, 250);
            openChildForm(new FiyatDuzenle());
            subButton(null);
        }

        //Yöneti Paneli
        private void ıconButton_YoneticiPaneli_Click(object sender, EventArgs e)
        {
            activateButton(sender, 300);
            showSubMenu(panel_YoneticiMenu);
        }
        #region YoneticiPaneliMenu
        private void ıconButton_YöneticiEkle_Click(object sender, EventArgs e)
        {
            subButton(ıconButton_YöneticiEkle);
            openChildForm(new YoneticiEkle());
        }

        private void ıconButton_YoneticiSil_Click(object sender, EventArgs e)
        {
            timerKapanma.Enabled = true;
            subButton(ıconButton_YoneticiSil);
            openChildForm(new YoneticiSil());
        }
        #endregion

        //Z Raporu
        private void ıconButton_ZRaporu_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            activateButton(sender, 350);
            openChildForm(new ZRaporu());
            subButton(null);
        }

        //Kullanıcı Çıkış
        private void ıconButton_YoneticiCikis_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width >= panelWidth) //Soldaki menü paneli tam olarak açılmadan çıkış butonuna tıklanamaz
            {
                hideSubMenu();
                reset();
                currentForm.Close();
                isLogin = false;
                login();
                timerMenu.Start(); //soldaki panelin kapanma animasyonu
            }
        }

        private void reset()
        {
            //Çıkış yapıldığında menüdeki ve üst paneldeki ikonların ve butonların renklerini düzenler
            disableButton();
            leftBorderButton.Visible = false;
            iconUser.IconColor = Color.FromArgb(198, 209, 227);
            pictureBoxLogo.BackColor = Color.FromArgb(28, 26, 43); //çıkış yapıldığında chat logosunun rengini sabitler
            label_User.Visible = false;
            label_Butce.Visible = false;
            iconButce.Visible = false;
            subButton(null);

            //notification baloon
            notifyIconum.ShowBalloonTip(1000, "STOCKIFY", label_User.Text + " olarak çıkış yapıldı.", ToolTipIcon.None);
            notifyIconum.Visible = false;
        } //girişe yollarken temizler

        #region Drag
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")] //attributes
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            //Form penceresinin en üstteki panelden taşınabilmesini sağlar
            this.FormBorderStyle = FormBorderStyle.Sizable;
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelMenu_MouseDown(object sender, MouseEventArgs e)
        {
            //Form penceresinin soldaki menü panelinden taşınabilmesini sağlar
            this.FormBorderStyle = FormBorderStyle.Sizable;
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelLogo_MouseDown(object sender, MouseEventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelMenu_MouseEnter(object sender, EventArgs e)
        {
            if (this.Size == Screen.FromHandle(this.Handle).WorkingArea.Size)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
        }
        #endregion

        #region Exit
        private void ıconButtonExit_Click(object sender, EventArgs e)
        {
            if (Message.Show("Çıkış yapmak istediğinize emin misiniz?"))
            {
                Application.Exit();
            }
        }
        private void ıconButtonExit_MouseHover(object sender, EventArgs e)
        {
            ıconButtonExit.BackColor = Color.FromArgb(255, 96, 92);
        }
        private void ıconButtonExit_MouseLeave(object sender, EventArgs e)
        {
            ıconButtonExit.BackColor = Color.FromArgb(28, 26, 43);
        }
        #endregion

        #region Maximize
        private void ıconButtonMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
            }
        }
        #endregion

        #region Minimize
        private void ıconButtonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region timers
        private void timerKapanma_Tick(object sender, EventArgs e)
        {
            if (isLogin == true)
            {
                if (YoneticiSil.deleteUser == user)
                {
                    ıconButton_YoneticiCikis_Click(ıconButton_YoneticiCikis, e);
                    YoneticiSil.deleteUser = "";
                }
            }
        } //açık olan hesap silinmeye çalışılırsa, direkt çıkış yapılır

        private void timerTarihSaat_Tick(object sender, EventArgs e)
        {
            //saat
            DateTime dt = DateTime.Now;
            labelSaat.Text = dt.ToString("HH:mm:ss");

            label_Butce.Text = writeBudget(); // bütçe değişimini sürekli kontrol eder
        }
        private void labelTarih_MouseHover(object sender, EventArgs e)
        {
            int gun = (int)DateTime.Now.DayOfWeek;

            switch (gun)
            {
                case 1:
                    labelTarih.Text = "Pazartesi";
                    break;
                case 2:
                    labelTarih.Text = "Salı";
                    break;
                case 3:
                    labelTarih.Text = "Çarşamba";
                    break;
                case 4:
                    labelTarih.Text = "Perşembe";
                    break;
                case 5:
                    labelTarih.Text = "Cuma";
                    break;
                case 6:
                    labelTarih.Text = "Cumartesi";
                    break;
                case 7:
                    labelTarih.Text = "Pazar";
                    break;
                default:
                    break;
            }
        } //tarihin üstüne gelindiğinde hangi gün olduğunu gösterir

        private void labelTarih_MouseLeave(object sender, EventArgs e)
        {
            labelTarih.Text = DateTime.Now.ToShortDateString();

        }

        private void timerMenu_Tick(object sender, EventArgs e)
        {
            if (isClosed) //menü paneli kapalıysa
            {
                if (panelMenu.Width >= panelWidth) //panel tam olarak açılmışsa
                {
                    //panel tam açılmış halinde 193px
                    isClosed = false;
                    timerMenu.Stop();//açılma anismayonunu durdur
                    this.Refresh();
                }

                //Açılırken önce hızlı sonra yavaş açılmasını sağlayan if blokları
                if (panelMenu.Width >= 157)
                {
                    panelMenu.Width += 5;

                }
                else if (panelMenu.Width >= 105)
                {
                    panelMenu.Width += 8;
                }
                else
                {
                    panelMenu.Width += 13;
                }
            }
            else //menü paneli açıksa
            {
                if (panelMenu.Width <= 0) //panel tam olarak kapanmışsa
                {
                    isClosed = true;
                    timerMenu.Stop(); //kapanma anismayonunu durdur
                    this.Refresh();
                }

                if (panelMenu.Width >= 157)
                {
                    panelMenu.Width -= 13;

                }
                else if (panelMenu.Width >= 105)
                {
                    panelMenu.Width -= 8;
                }
                else
                {
                    panelMenu.Width -= 5;
                }
            }
        }

        private void ıconButtonPopUp_Click(object sender, EventArgs e)
        {
            // menü açma kapama butonu (üç çizgi)
            if (isClosed)
            {
                panelMenu.Width = panelWidth;
                isClosed = false;
            }
            else
            {
                panelMenu.Width = 0;
                isClosed = true;
            }
        }
        #endregion

        private void ıconButton_Admin_Giris_Click(object sender, EventArgs e)
        {
            if (textBox_Admin_User.Text == "" || textBox_Admin_Pass.Text == "")
            {
                Message.Show("Lütfen gerekli alanları doldurunuz!", true);
            }
            else
            {
                connect.Open();
                OleDbCommand komut = new OleDbCommand("Select * from Admins where Admin_Adı='" + textBox_Admin_User.Text.Trim() + "'and Admin_Şifre='" + AdminKontrol.Hashleme(AdminKontrol.Hashleme(AdminKontrol.Hashleme(textBox_Admin_Pass.Text.Trim()))) + "'", connect);
                OleDbDataAdapter adap = new OleDbDataAdapter(komut);
                DataTable admin = new DataTable();
                adap.Fill(admin);
                connect.Close();

                if (admin.Rows.Count == 1)
                {
                    isLogin = true;
                    login(); // butonların visible olması için gidilen metot
                    if (isClosed)
                        timerMenu.Start();

                    openChildForm(new Giris()); //giriş yapıldığı anda ortaya çıkan logo ve marka adı
                    iconUser.IconColor = Color.FromArgb(85, 213, 219);
                    label_User.Text = textBox_Admin_User.Text;
                    user = label_User.Text;
                    label_User.Visible = true;
                    label_Butce.Visible = true;
                    iconButce.Visible = true;
                    checkBox_Admin_Sifre.Checked = false;
                    hak = 3; // çıkış yapıldığın hak tekrar 3 olur

                    //notification baloon
                    notifyIconum.Visible = true; // görev çubuğundaki bildirim simgesini aktif eder
                    notifyIconum.ShowBalloonTip(1000, "STOCKIFY", label_User.Text + " olarak giriş yapıldı.", ToolTipIcon.None);
                }
                else
                {
                    if (hak == 0)
                    {
                        Message.Show("Çok fazla giriş yapmaya çalıştınız!\nSistem kapatılıyor...", true);
                        Application.Exit();
                    }
                    else
                    {
                        Message.Show("Kullanıcı adı veya şifreniz yanlış!\nKalan deneme hakkı: " + hak--.ToString(), true);
                    }
                }

                textBox_Admin_User.Text = "";
                textBox_Admin_Pass.Text = "";
            }
        } //YÖNETİCİ GİRİŞİ KONTROLÜ

        private void checkBox_Admin_Sifre_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Admin_Sifre.Checked)
            {
                textBox_Admin_Pass.UseSystemPasswordChar = false;
            }
            else
            {
                textBox_Admin_Pass.UseSystemPasswordChar = true;
            }
        } //Şifreyi göster

        private void linkLabel_Admin_Unuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openChildForm(new SifremiUnuttum());
        } //şifreyi unuttum sayfasına yönlendirir

        #region chat
        private void labelSaat_TextChanged(object sender, EventArgs e)
        {
            connect.Open();
            OleDbCommand komut = new OleDbCommand("SELECT isRead FROM Mesajlar where Alıcı like '" + user + "'", connect);
            OleDbDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                if (!bool.Parse(dr["isRead"].ToString()))
                {
                    chat = true;
                }
            }
            connect.Close();

            if (isLogin && chat && !isChatOpen)
            {
                if (int.Parse(labelSaat.Text.Substring(7, 1)) % 2 == 0)
                    pictureBoxLogo.BackColor = Color.FromArgb(50, 150, 150);
                else
                    pictureBoxLogo.BackColor = Color.FromArgb(28, 26, 43);
            }
            else
            {
                pictureBoxLogo.BackColor = Color.FromArgb(28, 26, 43);
            }

            chat = false;
        } //mesaj varsa bildirim ışığının yanıp sönmesini sağlar

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            subButton(null);
            disableButton();
            leftBorderButton.Visible = false;
            isChatOpen = true;
            openChildForm(new Chat());
        } //chat butonuna basıldığında yapılacakları düzenler
        #endregion

        //Görev çubuğundaki bildirim simgesinden yapılan sekme geçişlerini sağlayan kodlar
        #region notifyIcon
        private void ürünBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ıconButton_UrunBilgi_Click(ıconButton_UrunBilgi, e);
        } // Ürün bilgileri aç

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activateButton(ıconButton_EkleCikar, 150);
            showSubMenu(panel_EkleCıkarMenu);
            subButton(ıconButton_Ekle);
            openChildForm(new UrunEkle());
        } //Ürün ekle aç

        private void çıkarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activateButton(ıconButton_EkleCikar, 150);
            showSubMenu(panel_EkleCıkarMenu);
            subButton(ıconButton_Cikar);
            openChildForm(new UrunSil());
        } //Ürün çıkar aç

        private void alımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activateButton(ıconButton_AlimSatim, 200);
            showSubMenu(panel_AlimSatimMenu);
            subButton(ıconButton_Alim);
            openChildForm(new UrunAl());
        } //Ürün alımı aç

        private void satımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activateButton(ıconButton_AlimSatim, 200);
            showSubMenu(panel_AlimSatimMenu);
            subButton(ıconButton_Satim);
            openChildForm(new UrunSat());
        } //Ürün satımı aç

        private void fiyatDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ıconButton_FiyatDuzenle_Click(ıconButton_FiyatDuzenle, e);
        } //fiyat düzenleyi aç

        private void yöneticiEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activateButton(ıconButton_YoneticiPaneli, 300);
            showSubMenu(panel_YoneticiMenu);
            subButton(ıconButton_YöneticiEkle);
            openChildForm(new YoneticiEkle());
        } //yönetici ekle aç

        private void yöneticiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activateButton(ıconButton_YoneticiPaneli, 300);
            showSubMenu(panel_YoneticiMenu);
            subButton(ıconButton_YoneticiSil);
            openChildForm(new YoneticiSil());
        } //yönetici sil aç

        private void zRaporuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ıconButton_ZRaporu_Click(ıconButton_ZRaporu, e);
        } //z raporu aç

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ıconButton_YoneticiCikis_Click(ıconButton_YoneticiCikis, e);
        } // yönetici çıkış

        private void uygulamayıKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        } // tamamen kapat
        #endregion

        private void linkLabel_GizlilikPolitikasi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                GizlilikPolitikasi gizlilikPolitikasi = new GizlilikPolitikasi();
                gizlilikPolitikasi.Show();
            }
            catch (Exception)
            {
                System.Diagnostics.Process.Start("https://drive.google.com/file/d/1rSdk_DAVlv5-wGWnigeWMoIJW-uVkvkM/view");
            }

        } //gizlilik politikası
    }
}