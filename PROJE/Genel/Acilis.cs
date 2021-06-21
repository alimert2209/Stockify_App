using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJE
{
    public partial class Acilis : Form
    {
        private int artis = 0;

        public Acilis()
        {
            InitializeComponent();
            circularProgressBar1.Value = 0; // progressbarı sıfırdan başlat
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (artis++ % 2 == 0)
                circularProgressBar1.Value += 1; // Yüklenme ekranındaki artış miktarı
            else
                circularProgressBar1.Value += 2; // Yüklenme ekranındaki artış miktarı

            circularProgressBar1.Text = "%" + circularProgressBar1.Value.ToString(); // artış miktarının yüzdesi

            if (circularProgressBar1.Value == 99) // progressbar dolduğunda
            {
                timer1.Enabled = false; //timer1 i durdur
                this.Visible = false; // açılış formunu görünmez yap
                AnaEkran anaEkran = new AnaEkran(); //ana ekran formunu oluştur
                anaEkran.ShowDialog(); // ana ekran formunu göster
                this.Close(); // açılış ekranını kapat
            }
        } //progress bar
    }
}
