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

namespace PROJE
{
    public partial class UrunBilgileri : Form
    {
        OleDbConnection connect = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Data.accdb");
        DataTable stok = new DataTable();

        public UrunBilgileri()
        {
            InitializeComponent();
            textBox_StokButce_Arama.Text = "";
        }

        private void UrunBilgileri_Load(object sender, EventArgs e)
        {
            Database.Listele("Ürün_Kodu, Tedarikçi, Kategori, Kumaş_Türü, Özellik, Renk, Alış_Fiyatı, Satış_Fiyatı, Adet, XS, S, M, L, XL, XXL", stok, dataGridView_StokButce, connect);
            Database.Gorunum(dataGridView_StokButce);
        }

        private void textBox_StokButce_Arama_TextChanged(object sender, EventArgs e)
        {
            Database.Arama("Ürün_Kodu, Tedarikçi, Kategori, Alış_Fiyatı, Satış_Fiyatı , Adet, XS, S, M, L, XL, XXL, Kumaş_Türü, Özellik, Renk", stok, dataGridView_StokButce, textBox_StokButce_Arama.Text, connect);
        } //arama
    }
}
