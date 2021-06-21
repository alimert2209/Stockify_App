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
    public partial class BoxMessage : Form
    {
        public static string message;
        public static int width;
        public static int height;

        public BoxMessage()
        {
            InitializeComponent();
            this.Size = new Size(width,height);
        }

        private void CustomizedMessageBox_Load(object sender, EventArgs e)
        {
            labelMessageBox.Text = message;
        } //messageBox içindeki mesajı belirler

        private void ıconButton_MessageBox_Click(object sender, EventArgs e)
        {
            Close();
        } //kapatma
    }
}
