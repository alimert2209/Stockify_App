using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace PROJE
{
    class Database
    {
        public static void Arama(string komut, DataTable tablo, DataGridView dataGrid, string text, OleDbConnection connect)
        {
            if(connect.State!=ConnectionState.Open) connect.Open();
            tablo.Clear(); // verileri üst üste yazmaması için her seferinde tabloyu temizleyen kod
            OleDbDataAdapter adap = new OleDbDataAdapter("select " + komut + " from Urunler where Ürün_Kodu like '" + text + "%'", connect);
            /* komut, Urunler tablosundan hangi sütunların çekileceğini gösterir
            like ise kategori sütunundaki text parametresinde yazan satırları listeler
            % işareti ise, örneğin arama çubuğuna "pa" yazınca pa ile başlayan tüm kategori satırlarını(ör: pantolon) listeler. */
            adap.Fill(tablo); // verileri tabloya yazdıran kod
            dataGrid.DataSource = tablo; // Urunler tablosunu datagridview'da görünür hale getirir
            if(connect.State!=ConnectionState.Closed) connect.Close();
        }//tablodan ürün ararken kullanılan metot

        public static void Listele(string sütun, DataTable tablo, DataGridView dataGrid, OleDbConnection connect)
        {
            if (connect.State != ConnectionState.Open) connect.Open();
            tablo.Clear(); // verileri üst üste yazmaması için her seferinde tabloyu temizleyen kod
            OleDbCommand komut = new OleDbCommand("SELECT " + sütun + " FROM Urunler", connect);
            /* Urunler tablosundan sütun parametresiyle gönderilen sütunları çeker */
            OleDbDataAdapter adap = new OleDbDataAdapter(komut); // veri tabanı kodunu C#'ta kullanılabilir hale getirir
            adap.Fill(tablo); // verileri tabloya yazdıran kod
            dataGrid.DataSource = tablo; // Urunler tablosunu datagridview'da görünür hale getirir
            komut.Dispose(); //Listeleme yapıldıktan sonra veri tabanı kodunu hafızadan atar (Garbage Collector)
            if (connect.State != ConnectionState.Closed) connect.Close();
        }

        public static void Gorunum(DataGridView dataGridView)
        {
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.FromArgb(85, 213, 219);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(28, 39, 58);
            dataGridView.BackgroundColor = Color.FromArgb(198, 209, 227);

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(28, 26, 43);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(198, 209, 227);
        } // datagridview dizaynı için
    }
}
