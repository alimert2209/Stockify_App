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
    public partial class YesNoMessage : Form
    {
        public static string message;
        public static bool isYes;
        public static int width;
        public static int height;

        public YesNoMessage()
        {
            InitializeComponent();
            this.Size = new Size(width, height);
        }

        private void YesNoMessage_Load(object sender, EventArgs e)
        {
            labelMessageBox.Text = message;
        } //messageBox içindeki mesajı belirler

        private void ıconButtonYes_Click(object sender, EventArgs e)
        {
            isYes = true;
            this.Close();
        }

        private void ıconButtonNo_Click(object sender, EventArgs e)
        {
            isYes = false;
            this.Close();
        }
    }
}
