
namespace PROJE
{
    partial class BoxMessage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoxMessage));
            this.label1 = new System.Windows.Forms.Label();
            this.labelMessageBox = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ıconButton_MessageBox = new FontAwesome.Sharp.IconButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.label1.Location = new System.Drawing.Point(134, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "<  STOCKIFY  >";
            // 
            // labelMessageBox
            // 
            this.labelMessageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMessageBox.BackColor = System.Drawing.Color.Transparent;
            this.labelMessageBox.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.labelMessageBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.labelMessageBox.Location = new System.Drawing.Point(3, 42);
            this.labelMessageBox.Name = "labelMessageBox";
            this.labelMessageBox.Size = new System.Drawing.Size(370, 59);
            this.labelMessageBox.TabIndex = 10;
            this.labelMessageBox.Text = "Message";
            this.labelMessageBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelMessageBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ıconButton_MessageBox);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 151);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // ıconButton_MessageBox
            // 
            this.ıconButton_MessageBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ıconButton_MessageBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.ıconButton_MessageBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ıconButton_MessageBox.FlatAppearance.BorderSize = 0;
            this.ıconButton_MessageBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ıconButton_MessageBox.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ıconButton_MessageBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.ıconButton_MessageBox.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.ıconButton_MessageBox.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.ıconButton_MessageBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconButton_MessageBox.IconSize = 32;
            this.ıconButton_MessageBox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ıconButton_MessageBox.Location = new System.Drawing.Point(121, 89);
            this.ıconButton_MessageBox.Name = "ıconButton_MessageBox";
            this.ıconButton_MessageBox.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ıconButton_MessageBox.Size = new System.Drawing.Size(134, 50);
            this.ıconButton_MessageBox.TabIndex = 2;
            this.ıconButton_MessageBox.Text = "Tamam";
            this.ıconButton_MessageBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ıconButton_MessageBox.UseVisualStyleBackColor = false;
            this.ıconButton_MessageBox.Click += new System.EventHandler(this.ıconButton_MessageBox_Click);
            // 
            // BoxMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(400, 166);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BoxMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stockify";
            this.Load += new System.EventHandler(this.CustomizedMessageBox_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton ıconButton_MessageBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMessageBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}