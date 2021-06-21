using ClosedXML.Excel; //excel için
using iTextSharp.text;
using iTextSharp.text.pdf; //pdf için
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO; //dosya işlemleri için
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJE
{
    public partial class ZRaporu : Form
    {
        OleDbConnection connect = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Data.accdb");
        DataTable rapor = new DataTable();

        private string result;

        public ZRaporu()
        {
            InitializeComponent();
        }

        private void ZRaporu_Load(object sender, EventArgs e)
        {
            label_Bilgilendirme.Text = "➦ \"Günü Bitir\" butonuna\nbasmadan önce verilerinizi\naktarmayı unutmayınız!";

            connect.Open();
            rapor.Clear();
            OleDbCommand sum = new OleDbCommand(@"select sum(Tutar) from Rapor where Tarih like '" + DateTime.Now.ToShortDateString() + "'", connect);
            //Tutar sütunundaki tüm elemanların toplamını bulur
            result = sum.ExecuteScalar().ToString();

            OleDbCommand komut = new OleDbCommand("SELECT Tarih, Saat, Kullanıcı, Ürün_Kodu, Tedarikçi, Beden, Adet, Tutar FROM Rapor where Tarih like '" + DateTime.Now.ToShortDateString() + "'", connect);
            OleDbDataAdapter adap = new OleDbDataAdapter(komut);
            adap.Fill(rapor);

            try
            {
                rapor.Rows.Add("", "", "", "", "", "", isProfit(), Math.Round(double.Parse(result), 2).ToString()); //gridView'un sonuna satır eklemeyi sağlar
            }
            catch (Exception)
            {

            }

            dataGridView_ZRaporu.DataSource = rapor;
            connect.Close();

            Database.Gorunum(dataGridView_ZRaporu);
        }

        private string isProfit()
        {
            try
            {
                if (double.Parse(result) > 0)
                {
                    return "Toplam kâr:";
                }
                else
                {
                    return "Toplam zarar:";
                }
            }
            catch (Exception)
            {
                return "";
            }
        } //kar ya da zarar durumuna bakar

        private void ıconButton_Excel_Click(object sender, EventArgs e)
        {
            if (dataGridView_ZRaporu.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = DateTime.Now.ToShortDateString() }; //farklı kaydet
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook workbook = new XLWorkbook();
                        workbook.Worksheets.Add(this.rapor.Copy(), "Z Raporu");
                        workbook.SaveAs(sfd.FileName);

                        Message.Show("Excel'e aktarıldı.", false);
                    }
                    catch (Exception ex)
                    {
                        Message.Show(ex.Message, true);
                    }
                }
            }
            else
                Message.Show("Tabloda veri bulunamadı.", true);
        } //Excele aktarma

        private void ıconButton_PDF_Click(object sender, EventArgs e)
        { 
            //PDF'te Türkçe karakter görüntelemeyi sağlar
            string Tahoma = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Tahoma.TTF");
            BaseFont bf = BaseFont.CreateFont(Tahoma, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            if (dataGridView_ZRaporu.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog() { Filter = "PDF (*.pdf)|*.pdf", FileName = DateTime.Now.ToShortDateString() + ".pdf" }; //farklı kaydet

                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                        File.Delete(save.FileName);
                    try
                    {
                        PdfPTable pTable = new PdfPTable(dataGridView_ZRaporu.Columns.Count);
                        pTable.DefaultCell.Padding = 4;
                        pTable.WidthPercentage = 100;
                        pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                        foreach (DataGridViewColumn col in dataGridView_ZRaporu.Columns) //Gridview'deki sütunların başlıklarını ekliyor 
                        {
                            PdfPCell pCell = new PdfPCell(new Phrase(new Chunk(col.HeaderText, new iTextSharp.text.Font(bf))));
                            pCell.Border = 0;
                            pCell.HorizontalAlignment = Element.ALIGN_LEFT;
                            pCell.BackgroundColor = new BaseColor(198, 209, 227);
                            pTable.AddCell(pCell);
                        }

                        foreach (DataGridViewRow viewRow in dataGridView_ZRaporu.Rows) //Gridview'deki satırları ekliyor 
                        {
                            foreach (DataGridViewCell dcell in viewRow.Cells)
                            {
                                PdfPCell dCell = new PdfPCell(new Phrase(new Chunk(dcell.Value.ToString(), new iTextSharp.text.Font(bf))));
                                dCell.Border = 1;
                                dCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                dCell.BackgroundColor = new BaseColor(245, 245, 245);
                                pTable.AddCell(dCell);
                            }
                        }

                        FileStream fileStream = new FileStream(save.FileName, FileMode.Create);
                        Document document = new Document(PageSize.A3, 10f, 10f, 10f, 10f); //sol,sağ,yukarısı,aşağısı
                        PdfWriter.GetInstance(document, fileStream);
                        document.Open();
                        document.Add(pTable);
                        document.Close();
                        fileStream.Close();

                        Message.Show("PDF'e aktarıldı.", false);
                    }
                    catch (Exception ex)
                    {
                        Message.Show(ex.Message, true);
                    }
                }
            }
            else
                Message.Show("Tabloda veri bulunamadı.", true);
        } //PDFe aktarma

        private void ıconButton_Bitir_Click(object sender, EventArgs e)
        {
            if (Message.Show("Günü bitirirseniz veri tabanındaki kayıtlar silinecek.\nOnaylıyor musunuz?"))
            {
                connect.Open();
                OleDbCommand komut = new OleDbCommand("delete * from Rapor", connect);
                komut.ExecuteNonQuery();
                connect.Close();
            }

            ZRaporu_Load(sender, e);
        } //Günü bitir
    }
}
