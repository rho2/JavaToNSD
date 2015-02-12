namespace JavaToNSD
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.druckenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seitenansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rückgängigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wiederholenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ausschneidenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kopierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einfügenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.alleauswählenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anpassenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inhaltToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.rtbIN = new System.Windows.Forms.RichTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lbIn = new System.Windows.Forms.ListView();
            this.tvOut = new System.Windows.Forms.TreeView();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.rtbOut = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.bearbeitenToolStripMenuItem,
            this.extrasToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.öffnenToolStripMenuItem,
            this.toolStripSeparator,
            this.speichernToolStripMenuItem,
            this.toolStripSeparator1,
            this.druckenToolStripMenuItem,
            this.seitenansichtToolStripMenuItem,
            this.toolStripSeparator2,
            this.beendenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "&Datei";
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("neuToolStripMenuItem.Image")));
            this.neuToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.neuToolStripMenuItem.Text = "&Neu";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.neuToolStripMenuItem_Click);
            // 
            // öffnenToolStripMenuItem
            // 
            this.öffnenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("öffnenToolStripMenuItem.Image")));
            this.öffnenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
            this.öffnenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.öffnenToolStripMenuItem.Text = "Ö&ffnen";
            this.öffnenToolStripMenuItem.Click += new System.EventHandler(this.öffnenToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(165, 6);
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("speichernToolStripMenuItem.Image")));
            this.speichernToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.speichernToolStripMenuItem.Text = "&Speichern";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // druckenToolStripMenuItem
            // 
            this.druckenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("druckenToolStripMenuItem.Image")));
            this.druckenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.druckenToolStripMenuItem.Name = "druckenToolStripMenuItem";
            this.druckenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.druckenToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.druckenToolStripMenuItem.Text = "&Drucken";
            this.druckenToolStripMenuItem.Click += new System.EventHandler(this.druckenToolStripMenuItem_Click);
            // 
            // seitenansichtToolStripMenuItem
            // 
            this.seitenansichtToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("seitenansichtToolStripMenuItem.Image")));
            this.seitenansichtToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seitenansichtToolStripMenuItem.Name = "seitenansichtToolStripMenuItem";
            this.seitenansichtToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.seitenansichtToolStripMenuItem.Text = "&Seitenansicht";
            this.seitenansichtToolStripMenuItem.Click += new System.EventHandler(this.seitenansichtToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.beendenToolStripMenuItem.Text = "&Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rückgängigToolStripMenuItem,
            this.wiederholenToolStripMenuItem,
            this.toolStripSeparator3,
            this.ausschneidenToolStripMenuItem,
            this.kopierenToolStripMenuItem,
            this.einfügenToolStripMenuItem,
            this.toolStripSeparator4,
            this.alleauswählenToolStripMenuItem});
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.bearbeitenToolStripMenuItem.Text = "&Bearbeiten";
            // 
            // rückgängigToolStripMenuItem
            // 
            this.rückgängigToolStripMenuItem.Name = "rückgängigToolStripMenuItem";
            this.rückgängigToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.rückgängigToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.rückgängigToolStripMenuItem.Text = "&Rückgängig";
            this.rückgängigToolStripMenuItem.Click += new System.EventHandler(this.rückgängigToolStripMenuItem_Click);
            // 
            // wiederholenToolStripMenuItem
            // 
            this.wiederholenToolStripMenuItem.Name = "wiederholenToolStripMenuItem";
            this.wiederholenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.wiederholenToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.wiederholenToolStripMenuItem.Text = "Wiede&rholen";
            this.wiederholenToolStripMenuItem.Click += new System.EventHandler(this.wiederholenToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
            // 
            // ausschneidenToolStripMenuItem
            // 
            this.ausschneidenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ausschneidenToolStripMenuItem.Image")));
            this.ausschneidenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ausschneidenToolStripMenuItem.Name = "ausschneidenToolStripMenuItem";
            this.ausschneidenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.ausschneidenToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.ausschneidenToolStripMenuItem.Text = "&Ausschneiden";
            this.ausschneidenToolStripMenuItem.Click += new System.EventHandler(this.ausschneidenToolStripMenuItem_Click);
            // 
            // kopierenToolStripMenuItem
            // 
            this.kopierenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kopierenToolStripMenuItem.Image")));
            this.kopierenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.kopierenToolStripMenuItem.Name = "kopierenToolStripMenuItem";
            this.kopierenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.kopierenToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.kopierenToolStripMenuItem.Text = "&Kopieren";
            this.kopierenToolStripMenuItem.Click += new System.EventHandler(this.kopierenToolStripMenuItem_Click);
            // 
            // einfügenToolStripMenuItem
            // 
            this.einfügenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("einfügenToolStripMenuItem.Image")));
            this.einfügenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.einfügenToolStripMenuItem.Name = "einfügenToolStripMenuItem";
            this.einfügenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.einfügenToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.einfügenToolStripMenuItem.Text = "&Einfügen";
            this.einfügenToolStripMenuItem.Click += new System.EventHandler(this.einfügenToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(188, 6);
            // 
            // alleauswählenToolStripMenuItem
            // 
            this.alleauswählenToolStripMenuItem.Name = "alleauswählenToolStripMenuItem";
            this.alleauswählenToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.alleauswählenToolStripMenuItem.Text = "&Alle auswählen";
            this.alleauswählenToolStripMenuItem.Click += new System.EventHandler(this.alleauswählenToolStripMenuItem_Click);
            // 
            // extrasToolStripMenuItem
            // 
            this.extrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anpassenToolStripMenuItem,
            this.optionenToolStripMenuItem});
            this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            this.extrasToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.extrasToolStripMenuItem.Text = "E&xtras";
            // 
            // anpassenToolStripMenuItem
            // 
            this.anpassenToolStripMenuItem.Name = "anpassenToolStripMenuItem";
            this.anpassenToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.anpassenToolStripMenuItem.Text = "&Anpassen";
            this.anpassenToolStripMenuItem.Click += new System.EventHandler(this.anpassenToolStripMenuItem_Click);
            // 
            // optionenToolStripMenuItem
            // 
            this.optionenToolStripMenuItem.Name = "optionenToolStripMenuItem";
            this.optionenToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.optionenToolStripMenuItem.Text = "&Optionen";
            this.optionenToolStripMenuItem.Click += new System.EventHandler(this.optionenToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inhaltToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.suchenToolStripMenuItem,
            this.toolStripSeparator5,
            this.infoToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.hilfeToolStripMenuItem.Text = "&Hilfe";
            // 
            // inhaltToolStripMenuItem
            // 
            this.inhaltToolStripMenuItem.Name = "inhaltToolStripMenuItem";
            this.inhaltToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.inhaltToolStripMenuItem.Text = "I&nhalt";
            this.inhaltToolStripMenuItem.Click += new System.EventHandler(this.inhaltToolStripMenuItem_Click);
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            this.indexToolStripMenuItem.Click += new System.EventHandler(this.indexToolStripMenuItem_Click);
            // 
            // suchenToolStripMenuItem
            // 
            this.suchenToolStripMenuItem.Name = "suchenToolStripMenuItem";
            this.suchenToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.suchenToolStripMenuItem.Text = "&Suchen";
            this.suchenToolStripMenuItem.Click += new System.EventHandler(this.suchenToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(110, 6);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.infoToolStripMenuItem.Text = "Inf&o...";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 639);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "java";
            this.openFileDialog1.FileName = "main";
            this.openFileDialog1.Filter = "Java-Dateien|*.java";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "nsd";
            this.saveFileDialog1.Filter = "NSD-Files|*.nsd";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            this.splitContainer1.Panel1.Controls.Add(this.rtbIN);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(984, 615);
            this.splitContainer1.SplitterDistance = 318;
            this.splitContainer1.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 543);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(100, 69);
            this.listBox1.TabIndex = 1;
            this.listBox1.Visible = false;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // rtbIN
            // 
            this.rtbIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbIN.Location = new System.Drawing.Point(0, 0);
            this.rtbIN.Name = "rtbIN";
            this.rtbIN.Size = new System.Drawing.Size(318, 615);
            this.rtbIN.TabIndex = 0;
            this.rtbIN.Text = "";
            this.rtbIN.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbIN_KeyDown);
            this.rtbIN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbIN_KeyPress);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listBox2);
            this.splitContainer2.Panel2.Controls.Add(this.rtbOut);
            this.splitContainer2.Size = new System.Drawing.Size(662, 615);
            this.splitContainer2.SplitterDistance = 313;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lbIn);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tvOut);
            this.splitContainer3.Size = new System.Drawing.Size(313, 615);
            this.splitContainer3.SplitterDistance = 256;
            this.splitContainer3.TabIndex = 0;
            // 
            // lbIn
            // 
            this.lbIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIn.Location = new System.Drawing.Point(0, 0);
            this.lbIn.Name = "lbIn";
            this.lbIn.Size = new System.Drawing.Size(313, 256);
            this.lbIn.TabIndex = 0;
            this.lbIn.UseCompatibleStateImageBehavior = false;
            this.lbIn.View = System.Windows.Forms.View.List;
            // 
            // tvOut
            // 
            this.tvOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOut.Location = new System.Drawing.Point(0, 0);
            this.tvOut.Name = "tvOut";
            this.tvOut.Size = new System.Drawing.Size(313, 355);
            this.tvOut.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(19, 556);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(215, 69);
            this.listBox2.TabIndex = 2;
            this.listBox2.Visible = false;
            this.listBox2.DoubleClick += new System.EventHandler(this.listBox2_DoubleClick);
            // 
            // rtbOut
            // 
            this.rtbOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbOut.Location = new System.Drawing.Point(0, 0);
            this.rtbOut.Name = "rtbOut";
            this.rtbOut.Size = new System.Drawing.Size(345, 615);
            this.rtbOut.TabIndex = 0;
            this.rtbOut.Text = "";
            this.rtbOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbOut_KeyDown);
            this.rtbOut.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbOut_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Java to NSD";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem druckenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seitenansichtToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rückgängigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wiederholenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ausschneidenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kopierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einfügenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem alleauswählenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anpassenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inhaltToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suchenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtbIN;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListView lbIn;
        private System.Windows.Forms.TreeView tvOut;
        private System.Windows.Forms.RichTextBox rtbOut;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
    }
}

