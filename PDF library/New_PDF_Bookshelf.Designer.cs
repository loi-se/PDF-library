namespace PDF_library
{
    partial class New_PDF_Bookshelf
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
            this.lBookshelfName = new System.Windows.Forms.Label();
            this.tBookShelfName = new System.Windows.Forms.TextBox();
            this.lBookshelfSubject = new System.Windows.Forms.Label();
            this.tBookShelfSubject = new System.Windows.Forms.TextBox();
            this.bChooseFolderPath = new System.Windows.Forms.Button();
            this.lChooseFolderPath = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bCancel = new System.Windows.Forms.Button();
            this.bAddBookShelf = new System.Windows.Forms.Button();
            this.cBBookShelfReScan = new System.Windows.Forms.CheckBox();
            this.lSubDirs = new System.Windows.Forms.Label();
            this.cBSubDirectories = new System.Windows.Forms.CheckBox();
            this.tChoosenFolderPath = new System.Windows.Forms.TextBox();
            this.cBSearchTermActive = new System.Windows.Forms.CheckBox();
            this.lBookshelfSearchTermActive = new System.Windows.Forms.Label();
            this.tBookShelfSearchTerm = new System.Windows.Forms.TextBox();
            this.lBookshelfSearchTerm = new System.Windows.Forms.Label();
            this.bInfoSearchTermActive = new System.Windows.Forms.Button();
            this.bInfoSearchTerm = new System.Windows.Forms.Button();
            this.bInfoFolderPath = new System.Windows.Forms.Button();
            this.bInfoIncludeSubDirectories = new System.Windows.Forms.Button();
            this.tableLayoutPanelBookShelf = new System.Windows.Forms.TableLayoutPanel();
            this.panelBookShelfMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lScanExistingPath = new System.Windows.Forms.Label();
            this.cBScanExistingDir = new System.Windows.Forms.CheckBox();
            this.panelScanFolderPath = new System.Windows.Forms.Panel();
            this.tableLayoutPanelScanBookShelf = new System.Windows.Forms.TableLayoutPanel();
            this.labelReScan = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelBookShelf.SuspendLayout();
            this.panelBookShelfMain.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelScanFolderPath.SuspendLayout();
            this.tableLayoutPanelScanBookShelf.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lBookshelfName
            // 
            this.lBookshelfName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lBookshelfName.AutoSize = true;
            this.lBookshelfName.Location = new System.Drawing.Point(24, 16);
            this.lBookshelfName.Name = "lBookshelfName";
            this.lBookshelfName.Size = new System.Drawing.Size(86, 13);
            this.lBookshelfName.TabIndex = 0;
            this.lBookshelfName.Text = "Bookshelf name:";
            // 
            // tBookShelfName
            // 
            this.tBookShelfName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBookShelfName.Location = new System.Drawing.Point(137, 12);
            this.tBookShelfName.Name = "tBookShelfName";
            this.tBookShelfName.Size = new System.Drawing.Size(370, 20);
            this.tBookShelfName.TabIndex = 1;
            // 
            // lBookshelfSubject
            // 
            this.lBookshelfSubject.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lBookshelfSubject.AutoSize = true;
            this.lBookshelfSubject.Location = new System.Drawing.Point(44, 61);
            this.lBookshelfSubject.Name = "lBookshelfSubject";
            this.lBookshelfSubject.Size = new System.Drawing.Size(46, 13);
            this.lBookshelfSubject.TabIndex = 8;
            this.lBookshelfSubject.Text = "Subject:";
            // 
            // tBookShelfSubject
            // 
            this.tBookShelfSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tBookShelfSubject.Location = new System.Drawing.Point(137, 57);
            this.tBookShelfSubject.Name = "tBookShelfSubject";
            this.tBookShelfSubject.Size = new System.Drawing.Size(370, 20);
            this.tBookShelfSubject.TabIndex = 9;
            // 
            // bChooseFolderPath
            // 
            this.bChooseFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bChooseFolderPath.Location = new System.Drawing.Point(137, 56);
            this.bChooseFolderPath.Name = "bChooseFolderPath";
            this.bChooseFolderPath.Size = new System.Drawing.Size(370, 23);
            this.bChooseFolderPath.TabIndex = 3;
            this.bChooseFolderPath.Text = "Choose directory path";
            this.bChooseFolderPath.UseVisualStyleBackColor = true;
            this.bChooseFolderPath.Click += new System.EventHandler(this.bChooseFolderPath_Click);
            // 
            // lChooseFolderPath
            // 
            this.lChooseFolderPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lChooseFolderPath.AutoSize = true;
            this.lChooseFolderPath.Location = new System.Drawing.Point(10, 61);
            this.lChooseFolderPath.Name = "lChooseFolderPath";
            this.lChooseFolderPath.Size = new System.Drawing.Size(113, 13);
            this.lChooseFolderPath.TabIndex = 2;
            this.lChooseFolderPath.Text = "Choose directory path:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.bCancel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bAddBookShelf, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(137, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(370, 36);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.Location = new System.Drawing.Point(3, 6);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(105, 23);
            this.bCancel.TabIndex = 6;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bAddBookShelf
            // 
            this.bAddBookShelf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bAddBookShelf.Location = new System.Drawing.Point(261, 6);
            this.bAddBookShelf.Name = "bAddBookShelf";
            this.bAddBookShelf.Size = new System.Drawing.Size(106, 23);
            this.bAddBookShelf.TabIndex = 5;
            this.bAddBookShelf.Text = "Add ";
            this.bAddBookShelf.UseVisualStyleBackColor = true;
            this.bAddBookShelf.Click += new System.EventHandler(this.bAddBookShelf_Click);
            // 
            // cBBookShelfReScan
            // 
            this.cBBookShelfReScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBBookShelfReScan.AutoSize = true;
            this.cBBookShelfReScan.Location = new System.Drawing.Point(137, 15);
            this.cBBookShelfReScan.Name = "cBBookShelfReScan";
            this.cBBookShelfReScan.Size = new System.Drawing.Size(370, 14);
            this.cBBookShelfReScan.TabIndex = 7;
            this.cBBookShelfReScan.UseVisualStyleBackColor = true;
            this.cBBookShelfReScan.CheckedChanged += new System.EventHandler(this.cBBookShelfReScan_CheckedChanged);
            // 
            // lSubDirs
            // 
            this.lSubDirs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lSubDirs.AutoSize = true;
            this.lSubDirs.Location = new System.Drawing.Point(9, 106);
            this.lSubDirs.Name = "lSubDirs";
            this.lSubDirs.Size = new System.Drawing.Size(116, 13);
            this.lSubDirs.TabIndex = 6;
            this.lSubDirs.Text = "Include sub directories:";
            // 
            // cBSubDirectories
            // 
            this.cBSubDirectories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBSubDirectories.AutoSize = true;
            this.cBSubDirectories.Location = new System.Drawing.Point(137, 105);
            this.cBSubDirectories.Name = "cBSubDirectories";
            this.cBSubDirectories.Size = new System.Drawing.Size(370, 14);
            this.cBSubDirectories.TabIndex = 7;
            this.cBSubDirectories.UseVisualStyleBackColor = true;
            // 
            // tChoosenFolderPath
            // 
            this.tChoosenFolderPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tChoosenFolderPath.Location = new System.Drawing.Point(137, 138);
            this.tChoosenFolderPath.Multiline = true;
            this.tChoosenFolderPath.Name = "tChoosenFolderPath";
            this.tChoosenFolderPath.ReadOnly = true;
            this.tChoosenFolderPath.Size = new System.Drawing.Size(370, 39);
            this.tChoosenFolderPath.TabIndex = 4;
            // 
            // cBSearchTermActive
            // 
            this.cBSearchTermActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBSearchTermActive.AutoSize = true;
            this.cBSearchTermActive.Location = new System.Drawing.Point(137, 195);
            this.cBSearchTermActive.Name = "cBSearchTermActive";
            this.cBSearchTermActive.Size = new System.Drawing.Size(370, 14);
            this.cBSearchTermActive.TabIndex = 14;
            this.cBSearchTermActive.UseVisualStyleBackColor = true;
            this.cBSearchTermActive.CheckedChanged += new System.EventHandler(this.cBSearchTermActive_CheckedChanged);
            // 
            // lBookshelfSearchTermActive
            // 
            this.lBookshelfSearchTermActive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lBookshelfSearchTermActive.AutoSize = true;
            this.lBookshelfSearchTermActive.Location = new System.Drawing.Point(17, 196);
            this.lBookshelfSearchTermActive.Name = "lBookshelfSearchTermActive";
            this.lBookshelfSearchTermActive.Size = new System.Drawing.Size(99, 13);
            this.lBookshelfSearchTermActive.TabIndex = 13;
            this.lBookshelfSearchTermActive.Text = "Search-term active:";
            // 
            // tBookShelfSearchTerm
            // 
            this.tBookShelfSearchTerm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBookShelfSearchTerm.Location = new System.Drawing.Point(137, 228);
            this.tBookShelfSearchTerm.Multiline = true;
            this.tBookShelfSearchTerm.Name = "tBookShelfSearchTerm";
            this.tBookShelfSearchTerm.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBookShelfSearchTerm.Size = new System.Drawing.Size(370, 45);
            this.tBookShelfSearchTerm.TabIndex = 12;
            // 
            // lBookshelfSearchTerm
            // 
            this.lBookshelfSearchTerm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lBookshelfSearchTerm.AutoSize = true;
            this.lBookshelfSearchTerm.Location = new System.Drawing.Point(33, 244);
            this.lBookshelfSearchTerm.Name = "lBookshelfSearchTerm";
            this.lBookshelfSearchTerm.Size = new System.Drawing.Size(67, 13);
            this.lBookshelfSearchTerm.TabIndex = 11;
            this.lBookshelfSearchTerm.Text = "Search-term:";
            // 
            // bInfoSearchTermActive
            // 
            this.bInfoSearchTermActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bInfoSearchTermActive.BackgroundImage = global::PDF_library.Properties.Resources.Information_icon;
            this.bInfoSearchTermActive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bInfoSearchTermActive.Location = new System.Drawing.Point(513, 191);
            this.bInfoSearchTermActive.Name = "bInfoSearchTermActive";
            this.bInfoSearchTermActive.Size = new System.Drawing.Size(22, 23);
            this.bInfoSearchTermActive.TabIndex = 16;
            this.bInfoSearchTermActive.UseVisualStyleBackColor = true;
            this.bInfoSearchTermActive.Click += new System.EventHandler(this.bInfoSearchTermActive_Click);
            // 
            // bInfoSearchTerm
            // 
            this.bInfoSearchTerm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bInfoSearchTerm.BackgroundImage = global::PDF_library.Properties.Resources.Information_icon;
            this.bInfoSearchTerm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bInfoSearchTerm.Location = new System.Drawing.Point(513, 239);
            this.bInfoSearchTerm.Name = "bInfoSearchTerm";
            this.bInfoSearchTerm.Size = new System.Drawing.Size(22, 23);
            this.bInfoSearchTerm.TabIndex = 17;
            this.bInfoSearchTerm.UseVisualStyleBackColor = true;
            this.bInfoSearchTerm.Click += new System.EventHandler(this.bInfoSearchTerm_Click);
            // 
            // bInfoFolderPath
            // 
            this.bInfoFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bInfoFolderPath.BackgroundImage = global::PDF_library.Properties.Resources.Information_icon;
            this.bInfoFolderPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bInfoFolderPath.Location = new System.Drawing.Point(513, 56);
            this.bInfoFolderPath.Name = "bInfoFolderPath";
            this.bInfoFolderPath.Size = new System.Drawing.Size(22, 23);
            this.bInfoFolderPath.TabIndex = 18;
            this.bInfoFolderPath.UseVisualStyleBackColor = true;
            this.bInfoFolderPath.Click += new System.EventHandler(this.bInfoFolderPath_Click);
            // 
            // bInfoIncludeSubDirectories
            // 
            this.bInfoIncludeSubDirectories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bInfoIncludeSubDirectories.BackgroundImage = global::PDF_library.Properties.Resources.Information_icon;
            this.bInfoIncludeSubDirectories.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bInfoIncludeSubDirectories.Location = new System.Drawing.Point(513, 101);
            this.bInfoIncludeSubDirectories.Name = "bInfoIncludeSubDirectories";
            this.bInfoIncludeSubDirectories.Size = new System.Drawing.Size(22, 23);
            this.bInfoIncludeSubDirectories.TabIndex = 19;
            this.bInfoIncludeSubDirectories.UseVisualStyleBackColor = true;
            this.bInfoIncludeSubDirectories.Click += new System.EventHandler(this.bInfoIncludeSubDirectories_Click);
            // 
            // tableLayoutPanelBookShelf
            // 
            this.tableLayoutPanelBookShelf.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelBookShelf.ColumnCount = 1;
            this.tableLayoutPanelBookShelf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBookShelf.Controls.Add(this.panelBookShelfMain, 0, 0);
            this.tableLayoutPanelBookShelf.Controls.Add(this.panelScanFolderPath, 0, 1);
            this.tableLayoutPanelBookShelf.Controls.Add(this.panelButtons, 0, 2);
            this.tableLayoutPanelBookShelf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBookShelf.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelBookShelf.Name = "tableLayoutPanelBookShelf";
            this.tableLayoutPanelBookShelf.RowCount = 3;
            this.tableLayoutPanelBookShelf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelBookShelf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelBookShelf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelBookShelf.Size = new System.Drawing.Size(544, 471);
            this.tableLayoutPanelBookShelf.TabIndex = 2;
            // 
            // panelBookShelfMain
            // 
            this.panelBookShelfMain.AutoScroll = true;
            this.panelBookShelfMain.BackColor = System.Drawing.Color.White;
            this.panelBookShelfMain.Controls.Add(this.tableLayoutPanel2);
            this.panelBookShelfMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBookShelfMain.Location = new System.Drawing.Point(3, 3);
            this.panelBookShelfMain.Name = "panelBookShelfMain";
            this.panelBookShelfMain.Size = new System.Drawing.Size(538, 135);
            this.panelBookShelfMain.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.Controls.Add(this.tBookShelfName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lBookshelfName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tBookShelfSubject, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lBookshelfSubject, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lScanExistingPath, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cBScanExistingDir, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(538, 135);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // lScanExistingPath
            // 
            this.lScanExistingPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lScanExistingPath.AutoSize = true;
            this.lScanExistingPath.Location = new System.Drawing.Point(9, 99);
            this.lScanExistingPath.Name = "lScanExistingPath";
            this.lScanExistingPath.Size = new System.Drawing.Size(116, 26);
            this.lScanExistingPath.TabIndex = 10;
            this.lScanExistingPath.Text = "Scan existing directory path:";
            // 
            // cBScanExistingDir
            // 
            this.cBScanExistingDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBScanExistingDir.AutoSize = true;
            this.cBScanExistingDir.Location = new System.Drawing.Point(137, 105);
            this.cBScanExistingDir.Name = "cBScanExistingDir";
            this.cBScanExistingDir.Size = new System.Drawing.Size(370, 14);
            this.cBScanExistingDir.TabIndex = 11;
            this.cBScanExistingDir.UseVisualStyleBackColor = true;
            this.cBScanExistingDir.CheckedChanged += new System.EventHandler(this.cBScanExistingDir_CheckedChanged);
            // 
            // panelScanFolderPath
            // 
            this.panelScanFolderPath.AutoScroll = true;
            this.panelScanFolderPath.BackColor = System.Drawing.Color.White;
            this.panelScanFolderPath.Controls.Add(this.tableLayoutPanelScanBookShelf);
            this.panelScanFolderPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScanFolderPath.Location = new System.Drawing.Point(3, 144);
            this.panelScanFolderPath.Name = "panelScanFolderPath";
            this.panelScanFolderPath.Size = new System.Drawing.Size(538, 276);
            this.panelScanFolderPath.TabIndex = 1;
            // 
            // tableLayoutPanelScanBookShelf
            // 
            this.tableLayoutPanelScanBookShelf.ColumnCount = 3;
            this.tableLayoutPanelScanBookShelf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelScanBookShelf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelScanBookShelf.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanelScanBookShelf.Controls.Add(this.bInfoSearchTerm, 2, 5);
            this.tableLayoutPanelScanBookShelf.Controls.Add(this.lBookshelfSearchTerm, 0, 5);
            this.tableLayoutPanelScanBookShelf.Controls.Add(this.cBBookShelfReScan, 1, 0);
            this.tableLayoutPanelScanBookShelf.Controls.Add(this.tBookShelfSearchTerm, 1, 5);
            this.tableLayoutPanelScanBookShelf.Controls.Add(this.lBookshelfSearchTermActive, 0, 4);
            this.tableLayoutPanelScanBookShelf.Controls.Add(this.bChooseFolderPath, 1, 1);
            this.tableLayoutPanelScanBookShelf.Controls.Add(this.lChooseFolderPath, 0, 1);
            this.tableLayoutPanelScanBookShelf.Controls.Add(this.cBSearchTermActive, 1, 4);
            this.tableLayoutPanelScanBookShelf.Controls.Add(this.bInfoFolderPath, 2, 1);
            this.tableLayoutPanelScanBookShelf.Controls.Add(this.bInfoSearchTermActive, 2, 4);
            this.tableLayoutPanelScanBookShelf.Controls.Add(this.tChoosenFolderPath, 1, 3);
            this.tableLayoutPanelScanBookShelf.Controls.Add(this.lSubDirs, 0, 2);
            this.tableLayoutPanelScanBookShelf.Controls.Add(this.bInfoIncludeSubDirectories, 2, 2);
            this.tableLayoutPanelScanBookShelf.Controls.Add(this.cBSubDirectories, 1, 2);
            this.tableLayoutPanelScanBookShelf.Controls.Add(this.labelReScan, 0, 0);
            this.tableLayoutPanelScanBookShelf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelScanBookShelf.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelScanBookShelf.Name = "tableLayoutPanelScanBookShelf";
            this.tableLayoutPanelScanBookShelf.RowCount = 6;
            this.tableLayoutPanelScanBookShelf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelScanBookShelf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelScanBookShelf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelScanBookShelf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelScanBookShelf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelScanBookShelf.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelScanBookShelf.Size = new System.Drawing.Size(538, 276);
            this.tableLayoutPanelScanBookShelf.TabIndex = 0;
            // 
            // labelReScan
            // 
            this.labelReScan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelReScan.AutoSize = true;
            this.labelReScan.Location = new System.Drawing.Point(42, 16);
            this.labelReScan.Name = "labelReScan";
            this.labelReScan.Size = new System.Drawing.Size(49, 13);
            this.labelReScan.TabIndex = 20;
            this.labelReScan.Text = "Re-Scan";
            // 
            // panelButtons
            // 
            this.panelButtons.AutoScroll = true;
            this.panelButtons.Controls.Add(this.tableLayoutPanel3);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(3, 426);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(538, 42);
            this.panelButtons.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(538, 42);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // New_PDF_Bookshelf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 471);
            this.Controls.Add(this.tableLayoutPanelBookShelf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "New_PDF_Bookshelf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Bookshelf";
            this.Load += new System.EventHandler(this.New_PDF_Bookshelf_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanelBookShelf.ResumeLayout(false);
            this.panelBookShelfMain.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panelScanFolderPath.ResumeLayout(false);
            this.tableLayoutPanelScanBookShelf.ResumeLayout(false);
            this.tableLayoutPanelScanBookShelf.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lBookshelfName;
        private System.Windows.Forms.TextBox tBookShelfName;
        private System.Windows.Forms.Label lChooseFolderPath;
        private System.Windows.Forms.Button bChooseFolderPath;
        private System.Windows.Forms.Button bAddBookShelf;
        private System.Windows.Forms.TextBox tChoosenFolderPath;
        private System.Windows.Forms.CheckBox cBSubDirectories;
        private System.Windows.Forms.Label lSubDirs;
        private System.Windows.Forms.Label lBookshelfSubject;
        private System.Windows.Forms.TextBox tBookShelfSubject;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label lBookshelfSearchTerm;
        private System.Windows.Forms.TextBox tBookShelfSearchTerm;
        private System.Windows.Forms.Label lBookshelfSearchTermActive;
        private System.Windows.Forms.CheckBox cBSearchTermActive;
        private System.Windows.Forms.CheckBox cBBookShelfReScan;
        private System.Windows.Forms.Button bInfoSearchTermActive;
        private System.Windows.Forms.Button bInfoSearchTerm;
        private System.Windows.Forms.Button bInfoFolderPath;
        private System.Windows.Forms.Button bInfoIncludeSubDirectories;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBookShelf;
        private System.Windows.Forms.Panel panelBookShelfMain;
        private System.Windows.Forms.Panel panelScanFolderPath;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelScanBookShelf;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lScanExistingPath;
        private System.Windows.Forms.CheckBox cBScanExistingDir;
        private System.Windows.Forms.Label labelReScan;
    }
}