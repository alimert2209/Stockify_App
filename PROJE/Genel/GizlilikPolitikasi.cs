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
    public partial class GizlilikPolitikasi : Form
    {
        public GizlilikPolitikasi()
        {
            InitializeComponent();
        }

        private void GizlilikPolitikasi_Load(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile(".\\Privacy-Policy-of-Stockify.pdf");
            //PDF okutmaya yarayan kod
        }
    }
}
