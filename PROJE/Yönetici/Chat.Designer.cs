
namespace PROJE
{
    partial class Chat
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
            this.components = new System.ComponentModel.Container();
            this.tabControlChat = new System.Windows.Forms.TabControl();
            this.tabPageMesajlar = new System.Windows.Forms.TabPage();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabPageGelen = new System.Windows.Forms.TabPage();
            this.ıconButton_MesajOlustur = new FontAwesome.Sharp.IconButton();
            this.listViewChat = new System.Windows.Forms.ListView();
            this.tabPageGiden = new System.Windows.Forms.TabPage();
            this.ıconButtonMesajOlustur = new FontAwesome.Sharp.IconButton();
            this.listViewGiden = new System.Windows.Forms.ListView();
            this.tabPageOku = new System.Windows.Forms.TabPage();
            this.ıconButtonYanitla = new FontAwesome.Sharp.IconButton();
            this.labelMessage = new System.Windows.Forms.RichTextBox();
            this.ıconButton_Geri = new FontAwesome.Sharp.IconButton();
            this.labelBaslik = new System.Windows.Forms.Label();
            this.labelTarih = new System.Windows.Forms.Label();
            this.labelTrh = new System.Windows.Forms.Label();
            this.labelMsg = new System.Windows.Forms.Label();
            this.labelGonderen = new System.Windows.Forms.Label();
            this.labelKullaniciAdi = new System.Windows.Forms.Label();
            this.tabPageGonder = new System.Windows.Forms.TabPage();
            this.ıconButtonGeri2 = new FontAwesome.Sharp.IconButton();
            this.ıconButton_MesajYolla = new FontAwesome.Sharp.IconButton();
            this.richTextBoxMesaj = new System.Windows.Forms.RichTextBox();
            this.comboBox_Alicilar = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelBslk = new System.Windows.Forms.Label();
            this.textBox_Baslik = new System.Windows.Forms.TextBox();
            this.labelAlici = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStripChat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.isReadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yanitlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlChat.SuspendLayout();
            this.tabPageMesajlar.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.tabPageGelen.SuspendLayout();
            this.tabPageGiden.SuspendLayout();
            this.tabPageOku.SuspendLayout();
            this.tabPageGonder.SuspendLayout();
            this.contextMenuStripChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlChat
            // 
            this.tabControlChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlChat.Controls.Add(this.tabPageMesajlar);
            this.tabControlChat.Controls.Add(this.tabPageOku);
            this.tabControlChat.Controls.Add(this.tabPageGonder);
            this.tabControlChat.Location = new System.Drawing.Point(-5, -23);
            this.tabControlChat.Name = "tabControlChat";
            this.tabControlChat.SelectedIndex = 0;
            this.tabControlChat.Size = new System.Drawing.Size(960, 540);
            this.tabControlChat.TabIndex = 1;
            // 
            // tabPageMesajlar
            // 
            this.tabPageMesajlar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.tabPageMesajlar.Controls.Add(this.metroTabControl1);
            this.tabPageMesajlar.Location = new System.Drawing.Point(4, 22);
            this.tabPageMesajlar.Name = "tabPageMesajlar";
            this.tabPageMesajlar.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMesajlar.Size = new System.Drawing.Size(952, 514);
            this.tabPageMesajlar.TabIndex = 0;
            this.tabPageMesajlar.Text = "Mesajlar";
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTabControl1.Controls.Add(this.tabPageGelen);
            this.metroTabControl1.Controls.Add(this.tabPageGiden);
            this.metroTabControl1.Location = new System.Drawing.Point(-4, 0);
            this.metroTabControl1.Multiline = true;
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(956, 508);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // tabPageGelen
            // 
            this.tabPageGelen.AutoScroll = true;
            this.tabPageGelen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.tabPageGelen.Controls.Add(this.ıconButton_MesajOlustur);
            this.tabPageGelen.Controls.Add(this.listViewChat);
            this.tabPageGelen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabPageGelen.Location = new System.Drawing.Point(4, 38);
            this.tabPageGelen.Name = "tabPageGelen";
            this.tabPageGelen.Size = new System.Drawing.Size(948, 466);
            this.tabPageGelen.TabIndex = 0;
            this.tabPageGelen.Text = "Gelen Kutusu";
            // 
            // ıconButton_MesajOlustur
            // 
            this.ıconButton_MesajOlustur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.ıconButton_MesajOlustur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ıconButton_MesajOlustur.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ıconButton_MesajOlustur.FlatAppearance.BorderSize = 0;
            this.ıconButton_MesajOlustur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ıconButton_MesajOlustur.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ıconButton_MesajOlustur.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.ıconButton_MesajOlustur.IconChar = FontAwesome.Sharp.IconChar.Comment;
            this.ıconButton_MesajOlustur.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.ıconButton_MesajOlustur.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconButton_MesajOlustur.IconSize = 32;
            this.ıconButton_MesajOlustur.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ıconButton_MesajOlustur.Location = new System.Drawing.Point(0, 405);
            this.ıconButton_MesajOlustur.Name = "ıconButton_MesajOlustur";
            this.ıconButton_MesajOlustur.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ıconButton_MesajOlustur.Size = new System.Drawing.Size(948, 61);
            this.ıconButton_MesajOlustur.TabIndex = 5;
            this.ıconButton_MesajOlustur.TabStop = false;
            this.ıconButton_MesajOlustur.Text = "Mesaj Oluştur";
            this.ıconButton_MesajOlustur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ıconButton_MesajOlustur.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ıconButton_MesajOlustur.UseVisualStyleBackColor = false;
            this.ıconButton_MesajOlustur.Click += new System.EventHandler(this.ıconButton_MesajOlustur_Click);
            // 
            // listViewChat
            // 
            this.listViewChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.listViewChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewChat.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.listViewChat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.listViewChat.FullRowSelect = true;
            this.listViewChat.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewChat.HideSelection = false;
            this.listViewChat.LabelWrap = false;
            this.listViewChat.Location = new System.Drawing.Point(0, 0);
            this.listViewChat.MultiSelect = false;
            this.listViewChat.Name = "listViewChat";
            this.listViewChat.Size = new System.Drawing.Size(945, 399);
            this.listViewChat.TabIndex = 6;
            this.listViewChat.UseCompatibleStateImageBehavior = false;
            this.listViewChat.SizeChanged += new System.EventHandler(this.listViewChat_SizeChanged);
            this.listViewChat.DoubleClick += new System.EventHandler(this.listViewChat_DoubleClick);
            this.listViewChat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewChat_MouseDown);
            // 
            // tabPageGiden
            // 
            this.tabPageGiden.AutoScroll = true;
            this.tabPageGiden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.tabPageGiden.Controls.Add(this.ıconButtonMesajOlustur);
            this.tabPageGiden.Controls.Add(this.listViewGiden);
            this.tabPageGiden.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabPageGiden.Location = new System.Drawing.Point(4, 38);
            this.tabPageGiden.Name = "tabPageGiden";
            this.tabPageGiden.Size = new System.Drawing.Size(948, 466);
            this.tabPageGiden.TabIndex = 1;
            this.tabPageGiden.Text = "Giden Kutusu";
            // 
            // ıconButtonMesajOlustur
            // 
            this.ıconButtonMesajOlustur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.ıconButtonMesajOlustur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ıconButtonMesajOlustur.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ıconButtonMesajOlustur.FlatAppearance.BorderSize = 0;
            this.ıconButtonMesajOlustur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ıconButtonMesajOlustur.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ıconButtonMesajOlustur.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.ıconButtonMesajOlustur.IconChar = FontAwesome.Sharp.IconChar.Comment;
            this.ıconButtonMesajOlustur.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.ıconButtonMesajOlustur.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconButtonMesajOlustur.IconSize = 32;
            this.ıconButtonMesajOlustur.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ıconButtonMesajOlustur.Location = new System.Drawing.Point(0, 405);
            this.ıconButtonMesajOlustur.Name = "ıconButtonMesajOlustur";
            this.ıconButtonMesajOlustur.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ıconButtonMesajOlustur.Size = new System.Drawing.Size(948, 61);
            this.ıconButtonMesajOlustur.TabIndex = 6;
            this.ıconButtonMesajOlustur.TabStop = false;
            this.ıconButtonMesajOlustur.Text = "Mesaj Oluştur";
            this.ıconButtonMesajOlustur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ıconButtonMesajOlustur.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ıconButtonMesajOlustur.UseVisualStyleBackColor = false;
            this.ıconButtonMesajOlustur.Click += new System.EventHandler(this.ıconButton_MesajOlustur_Click);
            // 
            // listViewGiden
            // 
            this.listViewGiden.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewGiden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.listViewGiden.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewGiden.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.listViewGiden.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.listViewGiden.FullRowSelect = true;
            this.listViewGiden.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewGiden.HideSelection = false;
            this.listViewGiden.LabelWrap = false;
            this.listViewGiden.Location = new System.Drawing.Point(0, 0);
            this.listViewGiden.MultiSelect = false;
            this.listViewGiden.Name = "listViewGiden";
            this.listViewGiden.Size = new System.Drawing.Size(945, 405);
            this.listViewGiden.TabIndex = 3;
            this.listViewGiden.UseCompatibleStateImageBehavior = false;
            this.listViewGiden.SizeChanged += new System.EventHandler(this.listViewGiden_SizeChanged);
            this.listViewGiden.DoubleClick += new System.EventHandler(this.listViewGiden_DoubleClick);
            // 
            // tabPageOku
            // 
            this.tabPageOku.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.tabPageOku.Controls.Add(this.ıconButtonYanitla);
            this.tabPageOku.Controls.Add(this.labelMessage);
            this.tabPageOku.Controls.Add(this.ıconButton_Geri);
            this.tabPageOku.Controls.Add(this.labelBaslik);
            this.tabPageOku.Controls.Add(this.labelTarih);
            this.tabPageOku.Controls.Add(this.labelTrh);
            this.tabPageOku.Controls.Add(this.labelMsg);
            this.tabPageOku.Controls.Add(this.labelGonderen);
            this.tabPageOku.Controls.Add(this.labelKullaniciAdi);
            this.tabPageOku.Location = new System.Drawing.Point(4, 22);
            this.tabPageOku.Name = "tabPageOku";
            this.tabPageOku.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOku.Size = new System.Drawing.Size(952, 514);
            this.tabPageOku.TabIndex = 1;
            this.tabPageOku.Text = "Oku";
            // 
            // ıconButtonYanitla
            // 
            this.ıconButtonYanitla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ıconButtonYanitla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.ıconButtonYanitla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ıconButtonYanitla.FlatAppearance.BorderSize = 0;
            this.ıconButtonYanitla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ıconButtonYanitla.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ıconButtonYanitla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.ıconButtonYanitla.IconChar = FontAwesome.Sharp.IconChar.Reply;
            this.ıconButtonYanitla.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.ıconButtonYanitla.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconButtonYanitla.IconSize = 32;
            this.ıconButtonYanitla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ıconButtonYanitla.Location = new System.Drawing.Point(805, 440);
            this.ıconButtonYanitla.Name = "ıconButtonYanitla";
            this.ıconButtonYanitla.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ıconButtonYanitla.Size = new System.Drawing.Size(128, 50);
            this.ıconButtonYanitla.TabIndex = 45;
            this.ıconButtonYanitla.Text = "Yanıtla";
            this.ıconButtonYanitla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ıconButtonYanitla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ıconButtonYanitla.UseVisualStyleBackColor = false;
            this.ıconButtonYanitla.Click += new System.EventHandler(this.ıconButtonYanitla_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.labelMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelMessage.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.labelMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.labelMessage.Location = new System.Drawing.Point(182, 156);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.ReadOnly = true;
            this.labelMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.labelMessage.Size = new System.Drawing.Size(595, 213);
            this.labelMessage.TabIndex = 44;
            this.labelMessage.Text = "";
            // 
            // ıconButton_Geri
            // 
            this.ıconButton_Geri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ıconButton_Geri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.ıconButton_Geri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ıconButton_Geri.FlatAppearance.BorderSize = 0;
            this.ıconButton_Geri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ıconButton_Geri.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ıconButton_Geri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.ıconButton_Geri.IconChar = FontAwesome.Sharp.IconChar.CaretLeft;
            this.ıconButton_Geri.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.ıconButton_Geri.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconButton_Geri.IconSize = 32;
            this.ıconButton_Geri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ıconButton_Geri.Location = new System.Drawing.Point(12, 440);
            this.ıconButton_Geri.Name = "ıconButton_Geri";
            this.ıconButton_Geri.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ıconButton_Geri.Size = new System.Drawing.Size(116, 50);
            this.ıconButton_Geri.TabIndex = 35;
            this.ıconButton_Geri.Text = "Geri";
            this.ıconButton_Geri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ıconButton_Geri.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ıconButton_Geri.UseVisualStyleBackColor = false;
            this.ıconButton_Geri.Click += new System.EventHandler(this.ıconButton_Geri_Click);
            // 
            // labelBaslik
            // 
            this.labelBaslik.BackColor = System.Drawing.Color.Transparent;
            this.labelBaslik.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelBaslik.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.labelBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.labelBaslik.Location = new System.Drawing.Point(3, 3);
            this.labelBaslik.Name = "labelBaslik";
            this.labelBaslik.Size = new System.Drawing.Size(946, 69);
            this.labelBaslik.TabIndex = 34;
            this.labelBaslik.Text = "Message";
            this.labelBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTarih
            // 
            this.labelTarih.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTarih.AutoSize = true;
            this.labelTarih.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.labelTarih.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.labelTarih.Location = new System.Drawing.Point(178, 114);
            this.labelTarih.Name = "labelTarih";
            this.labelTarih.Size = new System.Drawing.Size(41, 20);
            this.labelTarih.TabIndex = 33;
            this.labelTarih.Text = "Tarih";
            // 
            // labelTrh
            // 
            this.labelTrh.AutoSize = true;
            this.labelTrh.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.labelTrh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.labelTrh.Location = new System.Drawing.Point(83, 114);
            this.labelTrh.Name = "labelTrh";
            this.labelTrh.Size = new System.Drawing.Size(45, 20);
            this.labelTrh.TabIndex = 32;
            this.labelTrh.Text = "Tarih:";
            // 
            // labelMsg
            // 
            this.labelMsg.AutoSize = true;
            this.labelMsg.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.labelMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.labelMsg.Location = new System.Drawing.Point(83, 156);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(57, 20);
            this.labelMsg.TabIndex = 31;
            this.labelMsg.Text = "Mesaj:";
            // 
            // labelGonderen
            // 
            this.labelGonderen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGonderen.AutoSize = true;
            this.labelGonderen.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.labelGonderen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.labelGonderen.Location = new System.Drawing.Point(178, 72);
            this.labelGonderen.Name = "labelGonderen";
            this.labelGonderen.Size = new System.Drawing.Size(74, 20);
            this.labelGonderen.TabIndex = 28;
            this.labelGonderen.Text = "STOCKIFY";
            // 
            // labelKullaniciAdi
            // 
            this.labelKullaniciAdi.AutoSize = true;
            this.labelKullaniciAdi.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.labelKullaniciAdi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.labelKullaniciAdi.Location = new System.Drawing.Point(83, 72);
            this.labelKullaniciAdi.Name = "labelKullaniciAdi";
            this.labelKullaniciAdi.Size = new System.Drawing.Size(89, 20);
            this.labelKullaniciAdi.TabIndex = 26;
            this.labelKullaniciAdi.Text = "Gönderen:";
            // 
            // tabPageGonder
            // 
            this.tabPageGonder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.tabPageGonder.Controls.Add(this.ıconButtonGeri2);
            this.tabPageGonder.Controls.Add(this.ıconButton_MesajYolla);
            this.tabPageGonder.Controls.Add(this.richTextBoxMesaj);
            this.tabPageGonder.Controls.Add(this.comboBox_Alicilar);
            this.tabPageGonder.Controls.Add(this.panel1);
            this.tabPageGonder.Controls.Add(this.labelBslk);
            this.tabPageGonder.Controls.Add(this.textBox_Baslik);
            this.tabPageGonder.Controls.Add(this.labelAlici);
            this.tabPageGonder.Controls.Add(this.label3);
            this.tabPageGonder.Location = new System.Drawing.Point(4, 22);
            this.tabPageGonder.Name = "tabPageGonder";
            this.tabPageGonder.Size = new System.Drawing.Size(952, 514);
            this.tabPageGonder.TabIndex = 2;
            this.tabPageGonder.Text = "Gönder";
            // 
            // ıconButtonGeri2
            // 
            this.ıconButtonGeri2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ıconButtonGeri2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.ıconButtonGeri2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ıconButtonGeri2.FlatAppearance.BorderSize = 0;
            this.ıconButtonGeri2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ıconButtonGeri2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ıconButtonGeri2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.ıconButtonGeri2.IconChar = FontAwesome.Sharp.IconChar.CaretLeft;
            this.ıconButtonGeri2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.ıconButtonGeri2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconButtonGeri2.IconSize = 32;
            this.ıconButtonGeri2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ıconButtonGeri2.Location = new System.Drawing.Point(49, 427);
            this.ıconButtonGeri2.Name = "ıconButtonGeri2";
            this.ıconButtonGeri2.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ıconButtonGeri2.Size = new System.Drawing.Size(116, 50);
            this.ıconButtonGeri2.TabIndex = 45;
            this.ıconButtonGeri2.Text = "Geri";
            this.ıconButtonGeri2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ıconButtonGeri2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ıconButtonGeri2.UseVisualStyleBackColor = false;
            this.ıconButtonGeri2.Click += new System.EventHandler(this.ıconButtonGeri2_Click);
            // 
            // ıconButton_MesajYolla
            // 
            this.ıconButton_MesajYolla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ıconButton_MesajYolla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.ıconButton_MesajYolla.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ıconButton_MesajYolla.FlatAppearance.BorderSize = 0;
            this.ıconButton_MesajYolla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ıconButton_MesajYolla.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ıconButton_MesajYolla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.ıconButton_MesajYolla.IconChar = FontAwesome.Sharp.IconChar.Share;
            this.ıconButton_MesajYolla.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.ıconButton_MesajYolla.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ıconButton_MesajYolla.IconSize = 32;
            this.ıconButton_MesajYolla.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ıconButton_MesajYolla.Location = new System.Drawing.Point(751, 427);
            this.ıconButton_MesajYolla.Name = "ıconButton_MesajYolla";
            this.ıconButton_MesajYolla.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.ıconButton_MesajYolla.Size = new System.Drawing.Size(139, 50);
            this.ıconButton_MesajYolla.TabIndex = 44;
            this.ıconButton_MesajYolla.Text = "Gönder";
            this.ıconButton_MesajYolla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ıconButton_MesajYolla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ıconButton_MesajYolla.UseVisualStyleBackColor = false;
            this.ıconButton_MesajYolla.Click += new System.EventHandler(this.ıconButton_MesajYolla_Click);
            // 
            // richTextBoxMesaj
            // 
            this.richTextBoxMesaj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxMesaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.richTextBoxMesaj.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.richTextBoxMesaj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.richTextBoxMesaj.Location = new System.Drawing.Point(218, 147);
            this.richTextBoxMesaj.Name = "richTextBoxMesaj";
            this.richTextBoxMesaj.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxMesaj.Size = new System.Drawing.Size(672, 258);
            this.richTextBoxMesaj.TabIndex = 43;
            this.richTextBoxMesaj.Text = "";
            // 
            // comboBox_Alicilar
            // 
            this.comboBox_Alicilar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.comboBox_Alicilar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Alicilar.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.comboBox_Alicilar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.comboBox_Alicilar.FormattingEnabled = true;
            this.comboBox_Alicilar.Location = new System.Drawing.Point(218, 101);
            this.comboBox_Alicilar.Name = "comboBox_Alicilar";
            this.comboBox_Alicilar.Size = new System.Drawing.Size(195, 29);
            this.comboBox_Alicilar.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.panel1.Location = new System.Drawing.Point(218, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 1);
            this.panel1.TabIndex = 42;
            // 
            // labelBslk
            // 
            this.labelBslk.AutoSize = true;
            this.labelBslk.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.labelBslk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.labelBslk.Location = new System.Drawing.Point(108, 63);
            this.labelBslk.Name = "labelBslk";
            this.labelBslk.Size = new System.Drawing.Size(52, 20);
            this.labelBslk.TabIndex = 41;
            this.labelBslk.Text = "Başlık:";
            // 
            // textBox_Baslik
            // 
            this.textBox_Baslik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.textBox_Baslik.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Baslik.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.textBox_Baslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.textBox_Baslik.Location = new System.Drawing.Point(218, 63);
            this.textBox_Baslik.Name = "textBox_Baslik";
            this.textBox_Baslik.Size = new System.Drawing.Size(196, 20);
            this.textBox_Baslik.TabIndex = 0;
            // 
            // labelAlici
            // 
            this.labelAlici.AutoSize = true;
            this.labelAlici.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.labelAlici.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.labelAlici.Location = new System.Drawing.Point(108, 105);
            this.labelAlici.Name = "labelAlici";
            this.labelAlici.Size = new System.Drawing.Size(43, 20);
            this.labelAlici.TabIndex = 38;
            this.labelAlici.Text = "Alıcı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.label3.Location = new System.Drawing.Point(108, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "Mesaj:";
            // 
            // contextMenuStripChat
            // 
            this.contextMenuStripChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.contextMenuStripChat.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.contextMenuStripChat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.isReadToolStripMenuItem,
            this.yanitlaToolStripMenuItem,
            this.iletToolStripMenuItem,
            this.silToolStripMenuItem});
            this.contextMenuStripChat.Name = "contextMenuStripChat";
            this.contextMenuStripChat.ShowImageMargin = false;
            this.contextMenuStripChat.Size = new System.Drawing.Size(212, 100);
            // 
            // isReadToolStripMenuItem
            // 
            this.isReadToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.isReadToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.isReadToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.isReadToolStripMenuItem.Name = "isReadToolStripMenuItem";
            this.isReadToolStripMenuItem.Size = new System.Drawing.Size(211, 24);
            this.isReadToolStripMenuItem.Text = "Okundu Olarak İşaretle";
            this.isReadToolStripMenuItem.Click += new System.EventHandler(this.isReadToolStripMenuItem_Click);
            // 
            // yanitlaToolStripMenuItem
            // 
            this.yanitlaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.yanitlaToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.yanitlaToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.yanitlaToolStripMenuItem.Name = "yanitlaToolStripMenuItem";
            this.yanitlaToolStripMenuItem.Size = new System.Drawing.Size(211, 24);
            this.yanitlaToolStripMenuItem.Text = "Yanıtla";
            this.yanitlaToolStripMenuItem.Click += new System.EventHandler(this.yanitlaToolStripMenuItem_Click);
            // 
            // iletToolStripMenuItem
            // 
            this.iletToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.iletToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.iletToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.iletToolStripMenuItem.Name = "iletToolStripMenuItem";
            this.iletToolStripMenuItem.Size = new System.Drawing.Size(211, 24);
            this.iletToolStripMenuItem.Text = "İlet";
            this.iletToolStripMenuItem.Click += new System.EventHandler(this.iletToolStripMenuItem_Click);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(209)))), ((int)(((byte)(227)))));
            this.silToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.silToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(211, 24);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.tabControlChat);
            this.Name = "Chat";
            this.Text = "Chat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Chat_FormClosed);
            this.Load += new System.EventHandler(this.Chat_Load);
            this.tabControlChat.ResumeLayout(false);
            this.tabPageMesajlar.ResumeLayout(false);
            this.metroTabControl1.ResumeLayout(false);
            this.tabPageGelen.ResumeLayout(false);
            this.tabPageGiden.ResumeLayout(false);
            this.tabPageOku.ResumeLayout(false);
            this.tabPageOku.PerformLayout();
            this.tabPageGonder.ResumeLayout(false);
            this.tabPageGonder.PerformLayout();
            this.contextMenuStripChat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControlChat;
        private System.Windows.Forms.TabPage tabPageMesajlar;
        private System.Windows.Forms.TabPage tabPageOku;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripChat;
        private System.Windows.Forms.ToolStripMenuItem isReadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.Label labelGonderen;
        private System.Windows.Forms.Label labelKullaniciAdi;
        private System.Windows.Forms.Label labelMsg;
        private System.Windows.Forms.Label labelTarih;
        private System.Windows.Forms.Label labelTrh;
        private System.Windows.Forms.Label labelBaslik;
        private System.Windows.Forms.TabPage tabPageGonder;
        private System.Windows.Forms.Label labelAlici;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelBslk;
        private System.Windows.Forms.TextBox textBox_Baslik;
        private System.Windows.Forms.ComboBox comboBox_Alicilar;
        private System.Windows.Forms.RichTextBox richTextBoxMesaj;
        private FontAwesome.Sharp.IconButton ıconButton_MesajYolla;
        private FontAwesome.Sharp.IconButton ıconButton_Geri;
        private FontAwesome.Sharp.IconButton ıconButtonGeri2;
        private System.Windows.Forms.ToolStripMenuItem iletToolStripMenuItem;
        private System.Windows.Forms.RichTextBox labelMessage;
        private FontAwesome.Sharp.IconButton ıconButtonYanitla;
        private System.Windows.Forms.ToolStripMenuItem yanitlaToolStripMenuItem;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private System.Windows.Forms.TabPage tabPageGelen;
        private System.Windows.Forms.TabPage tabPageGiden;
        private FontAwesome.Sharp.IconButton ıconButton_MesajOlustur;
        private FontAwesome.Sharp.IconButton ıconButtonMesajOlustur;
        private System.Windows.Forms.ListView listViewGiden;
        private System.Windows.Forms.ListView listViewChat;
    }
}