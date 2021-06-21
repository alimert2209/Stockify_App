
namespace PROJE
{
    partial class YesNoMessage
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelMessageBox = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ıconButtonYes = new FontAwesome.Sharp.IconButton();
            this.ıconButtonNo = new FontAwesome.Sharp.IconButton();
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
            this.groupBox1.Controls.Add(this.ıconButtonNo);
            this.groupBox1.Controls.Add(this.labelMessageBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ıconButtonYes);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 151);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // ıconButtonYes
            // 
            this.ıconButtonYes.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ıconButtonYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.ıconButtonYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ıconButtonYes.FlatAppearance.BorderSize = 0;
            this.ıconButtonYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ıconButtonYes.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ıconButtonYes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.ıconButtonYes.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.ıconButtonYes.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.ıconButtonYes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconButtonYes.IconSize = 32;
            this.ıconButtonYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ıconButtonYes.Location = new System.Drawing.Point(46, 95);
            this.ıconButtonYes.Name = "ıconButtonYes";
            this.ıconButtonYes.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ıconButtonYes.Size = new System.Drawing.Size(119, 50);
            this.ıconButtonYes.TabIndex = 2;
            this.ıconButtonYes.Text = "Evet";
            this.ıconButtonYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ıconButtonYes.UseVisualStyleBackColor = false;
            this.ıconButtonYes.Click += new System.EventHandler(this.ıconButtonYes_Click);
            // 
            // ıconButtonNo
            // 
            this.ıconButtonNo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ıconButtonNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.ıconButtonNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ıconButtonNo.FlatAppearance.BorderSize = 0;
            this.ıconButtonNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ıconButtonNo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ıconButtonNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.ıconButtonNo.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.ıconButtonNo.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.ıconButtonNo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconButtonNo.IconSize = 32;
            this.ıconButtonNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ıconButtonNo.Location = new System.Drawing.Point(212, 95);
            this.ıconButtonNo.Name = "ıconButtonNo";
            this.ıconButtonNo.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ıconButtonNo.Size = new System.Drawing.Size(119, 50);
            this.ıconButtonNo.TabIndex = 11;
            this.ıconButtonNo.Text = "Hayır";
            this.ıconButtonNo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ıconButtonNo.UseVisualStyleBackColor = false;
            this.ıconButtonNo.Click += new System.EventHandler(this.ıconButtonNo_Click);
            // 
            // YesNoMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(400, 166);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "YesNoMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stockify";
            this.Load += new System.EventHandler(this.YesNoMessage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton ıconButtonYes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMessageBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton ıconButtonNo;
    }
}