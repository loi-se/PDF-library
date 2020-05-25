namespace PDF_library
{
    partial class Selected_PDF_Book
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
            System.Windows.Forms.TabControl tabControlPDF_Book;
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pSelBookMetaInformation = new System.Windows.Forms.Panel();
            this.tableLayoutPanelSelBookDescription = new System.Windows.Forms.TableLayoutPanel();
            this.labelSelBookFileName = new System.Windows.Forms.Label();
            this.labelSelBookTitle = new System.Windows.Forms.Label();
            this.labelSelBookWriter = new System.Windows.Forms.Label();
            this.lSelBookFileName = new System.Windows.Forms.Label();
            this.TSelBookWriter = new System.Windows.Forms.TextBox();
            this.TSelBookTitle = new System.Windows.Forms.TextBox();
            this.labelSelBookSubject = new System.Windows.Forms.Label();
            this.TSelBookSubject = new System.Windows.Forms.TextBox();
            this.labelSelBookFilepath = new System.Windows.Forms.Label();
            this.lSelBookNofpages = new System.Windows.Forms.Label();
            this.labelSelBookNofpages = new System.Windows.Forms.Label();
            this.labelSelBookRating = new System.Windows.Forms.Label();
            this.nUSelBookRating = new System.Windows.Forms.NumericUpDown();
            this.bOpenFolder = new System.Windows.Forms.Button();
            this.tSelBookFilePath = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pSelBookMetaInformation2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMetaInformation2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelSelBookDescription = new System.Windows.Forms.Label();
            this.TSelBookDescription = new System.Windows.Forms.TextBox();
            this.labelSelBookPublishDate = new System.Windows.Forms.Label();
            this.dateTimePickerSelBookPublishDate = new System.Windows.Forms.DateTimePicker();
            this.labelSelBookTags = new System.Windows.Forms.Label();
            this.TSelBookTags = new System.Windows.Forms.TextBox();
            this.labelSelBookBookID = new System.Windows.Forms.Label();
            this.lBookIDValue = new System.Windows.Forms.Label();
            this.bSelBookTagsInfo = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelMetaInformation3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelSelBookBookShelf = new System.Windows.Forms.Label();
            this.comboBoxBookShelves = new System.Windows.Forms.ComboBox();
            this.cBChangeBookshelf = new System.Windows.Forms.CheckBox();
            this.labelSelBookBookShelf_ID = new System.Windows.Forms.Label();
            this.labelSelBookBookShelf_IDValue = new System.Windows.Forms.Label();
            this.pSelBookChangeButtons = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bSelBookChange = new System.Windows.Forms.Button();
            this.bSelBookDelete = new System.Windows.Forms.Button();
            this.tableLayoutPanelSelBook = new System.Windows.Forms.TableLayoutPanel();
            this.pSelBookCoverImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanelSelBook2 = new System.Windows.Forms.TableLayoutPanel();
            this.pSelBookDescription = new System.Windows.Forms.Panel();
            this.pSelBookButtons = new System.Windows.Forms.Panel();
            this.tableLayoutPanelSelbookButtons = new System.Windows.Forms.TableLayoutPanel();
            this.bSelBookRead = new System.Windows.Forms.Button();
            this.bSelBookCancel = new System.Windows.Forms.Button();
            tabControlPDF_Book = new System.Windows.Forms.TabControl();
            tabControlPDF_Book.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pSelBookMetaInformation.SuspendLayout();
            this.tableLayoutPanelSelBookDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUSelBookRating)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.pSelBookMetaInformation2.SuspendLayout();
            this.tableLayoutPanelMetaInformation2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanelMetaInformation3.SuspendLayout();
            this.pSelBookChangeButtons.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelSelBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pSelBookCoverImage)).BeginInit();
            this.tableLayoutPanelSelBook2.SuspendLayout();
            this.pSelBookDescription.SuspendLayout();
            this.pSelBookButtons.SuspendLayout();
            this.tableLayoutPanelSelbookButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlPDF_Book
            // 
            tabControlPDF_Book.Controls.Add(this.tabPage1);
            tabControlPDF_Book.Controls.Add(this.tabPage2);
            tabControlPDF_Book.Controls.Add(this.tabPage3);
            tabControlPDF_Book.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlPDF_Book.Location = new System.Drawing.Point(0, 0);
            tabControlPDF_Book.Name = "tabControlPDF_Book";
            tabControlPDF_Book.SelectedIndex = 0;
            tabControlPDF_Book.Size = new System.Drawing.Size(391, 340);
            tabControlPDF_Book.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pSelBookMetaInformation);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(383, 314);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PDF Book info ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pSelBookMetaInformation
            // 
            this.pSelBookMetaInformation.AutoScroll = true;
            this.pSelBookMetaInformation.Controls.Add(this.tableLayoutPanelSelBookDescription);
            this.pSelBookMetaInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pSelBookMetaInformation.Location = new System.Drawing.Point(3, 3);
            this.pSelBookMetaInformation.Name = "pSelBookMetaInformation";
            this.pSelBookMetaInformation.Size = new System.Drawing.Size(377, 308);
            this.pSelBookMetaInformation.TabIndex = 1;
            // 
            // tableLayoutPanelSelBookDescription
            // 
            this.tableLayoutPanelSelBookDescription.AutoScroll = true;
            this.tableLayoutPanelSelBookDescription.ColumnCount = 3;
            this.tableLayoutPanelSelBookDescription.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelSelBookDescription.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelSelBookDescription.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelBookDescription.Controls.Add(this.labelSelBookFileName, 0, 0);
            this.tableLayoutPanelSelBookDescription.Controls.Add(this.labelSelBookTitle, 0, 1);
            this.tableLayoutPanelSelBookDescription.Controls.Add(this.labelSelBookWriter, 0, 2);
            this.tableLayoutPanelSelBookDescription.Controls.Add(this.lSelBookFileName, 1, 0);
            this.tableLayoutPanelSelBookDescription.Controls.Add(this.TSelBookWriter, 1, 2);
            this.tableLayoutPanelSelBookDescription.Controls.Add(this.TSelBookTitle, 1, 1);
            this.tableLayoutPanelSelBookDescription.Controls.Add(this.labelSelBookSubject, 0, 3);
            this.tableLayoutPanelSelBookDescription.Controls.Add(this.TSelBookSubject, 1, 3);
            this.tableLayoutPanelSelBookDescription.Controls.Add(this.labelSelBookFilepath, 0, 6);
            this.tableLayoutPanelSelBookDescription.Controls.Add(this.lSelBookNofpages, 1, 5);
            this.tableLayoutPanelSelBookDescription.Controls.Add(this.labelSelBookNofpages, 0, 5);
            this.tableLayoutPanelSelBookDescription.Controls.Add(this.labelSelBookRating, 0, 4);
            this.tableLayoutPanelSelBookDescription.Controls.Add(this.nUSelBookRating, 1, 4);
            this.tableLayoutPanelSelBookDescription.Controls.Add(this.bOpenFolder, 2, 6);
            this.tableLayoutPanelSelBookDescription.Controls.Add(this.tSelBookFilePath, 1, 6);
            this.tableLayoutPanelSelBookDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSelBookDescription.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelSelBookDescription.Name = "tableLayoutPanelSelBookDescription";
            this.tableLayoutPanelSelBookDescription.RowCount = 8;
            this.tableLayoutPanelSelBookDescription.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.57876F));
            this.tableLayoutPanelSelBookDescription.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.57876F));
            this.tableLayoutPanelSelBookDescription.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.57876F));
            this.tableLayoutPanelSelBookDescription.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.57876F));
            this.tableLayoutPanelSelBookDescription.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.57876F));
            this.tableLayoutPanelSelBookDescription.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.57876F));
            this.tableLayoutPanelSelBookDescription.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.55241F));
            this.tableLayoutPanelSelBookDescription.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.975012F));
            this.tableLayoutPanelSelBookDescription.Size = new System.Drawing.Size(377, 308);
            this.tableLayoutPanelSelBookDescription.TabIndex = 0;
            // 
            // labelSelBookFileName
            // 
            this.labelSelBookFileName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelBookFileName.AutoSize = true;
            this.labelSelBookFileName.Location = new System.Drawing.Point(29, 12);
            this.labelSelBookFileName.Name = "labelSelBookFileName";
            this.labelSelBookFileName.Size = new System.Drawing.Size(55, 13);
            this.labelSelBookFileName.TabIndex = 0;
            this.labelSelBookFileName.Text = "File name:";
            // 
            // labelSelBookTitle
            // 
            this.labelSelBookTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelBookTitle.AutoSize = true;
            this.labelSelBookTitle.Location = new System.Drawing.Point(41, 50);
            this.labelSelBookTitle.Name = "labelSelBookTitle";
            this.labelSelBookTitle.Size = new System.Drawing.Size(30, 13);
            this.labelSelBookTitle.TabIndex = 1;
            this.labelSelBookTitle.Text = "Title:";
            // 
            // labelSelBookWriter
            // 
            this.labelSelBookWriter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelBookWriter.AutoSize = true;
            this.labelSelBookWriter.Location = new System.Drawing.Point(37, 88);
            this.labelSelBookWriter.Name = "labelSelBookWriter";
            this.labelSelBookWriter.Size = new System.Drawing.Size(38, 13);
            this.labelSelBookWriter.TabIndex = 2;
            this.labelSelBookWriter.Text = "Writer:";
            // 
            // lSelBookFileName
            // 
            this.lSelBookFileName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lSelBookFileName.AutoSize = true;
            this.lSelBookFileName.Location = new System.Drawing.Point(221, 12);
            this.lSelBookFileName.Name = "lSelBookFileName";
            this.lSelBookFileName.Size = new System.Drawing.Size(10, 13);
            this.lSelBookFileName.TabIndex = 5;
            this.lSelBookFileName.Text = "-";
            // 
            // TSelBookWriter
            // 
            this.TSelBookWriter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TSelBookWriter.Location = new System.Drawing.Point(116, 85);
            this.TSelBookWriter.Name = "TSelBookWriter";
            this.TSelBookWriter.Size = new System.Drawing.Size(220, 20);
            this.TSelBookWriter.TabIndex = 10;
            // 
            // TSelBookTitle
            // 
            this.TSelBookTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TSelBookTitle.Location = new System.Drawing.Point(116, 47);
            this.TSelBookTitle.Name = "TSelBookTitle";
            this.TSelBookTitle.Size = new System.Drawing.Size(220, 20);
            this.TSelBookTitle.TabIndex = 11;
            // 
            // labelSelBookSubject
            // 
            this.labelSelBookSubject.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelBookSubject.AutoSize = true;
            this.labelSelBookSubject.Location = new System.Drawing.Point(33, 126);
            this.labelSelBookSubject.Name = "labelSelBookSubject";
            this.labelSelBookSubject.Size = new System.Drawing.Size(46, 13);
            this.labelSelBookSubject.TabIndex = 13;
            this.labelSelBookSubject.Text = "Subject:";
            // 
            // TSelBookSubject
            // 
            this.TSelBookSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TSelBookSubject.Location = new System.Drawing.Point(116, 123);
            this.TSelBookSubject.Name = "TSelBookSubject";
            this.TSelBookSubject.Size = new System.Drawing.Size(220, 20);
            this.TSelBookSubject.TabIndex = 14;
            // 
            // labelSelBookFilepath
            // 
            this.labelSelBookFilepath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelBookFilepath.AutoSize = true;
            this.labelSelBookFilepath.Location = new System.Drawing.Point(31, 250);
            this.labelSelBookFilepath.Name = "labelSelBookFilepath";
            this.labelSelBookFilepath.Size = new System.Drawing.Size(50, 13);
            this.labelSelBookFilepath.TabIndex = 4;
            this.labelSelBookFilepath.Text = "File path:";
            // 
            // lSelBookNofpages
            // 
            this.lSelBookNofpages.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lSelBookNofpages.AutoSize = true;
            this.lSelBookNofpages.Location = new System.Drawing.Point(221, 202);
            this.lSelBookNofpages.Name = "lSelBookNofpages";
            this.lSelBookNofpages.Size = new System.Drawing.Size(10, 13);
            this.lSelBookNofpages.TabIndex = 8;
            this.lSelBookNofpages.Text = "-";
            // 
            // labelSelBookNofpages
            // 
            this.labelSelBookNofpages.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelBookNofpages.AutoSize = true;
            this.labelSelBookNofpages.Location = new System.Drawing.Point(11, 202);
            this.labelSelBookNofpages.Name = "labelSelBookNofpages";
            this.labelSelBookNofpages.Size = new System.Drawing.Size(91, 13);
            this.labelSelBookNofpages.TabIndex = 3;
            this.labelSelBookNofpages.Text = "Number of pages:";
            // 
            // labelSelBookRating
            // 
            this.labelSelBookRating.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelBookRating.AutoSize = true;
            this.labelSelBookRating.Location = new System.Drawing.Point(36, 164);
            this.labelSelBookRating.Name = "labelSelBookRating";
            this.labelSelBookRating.Size = new System.Drawing.Size(41, 13);
            this.labelSelBookRating.TabIndex = 15;
            this.labelSelBookRating.Text = "Rating:";
            // 
            // nUSelBookRating
            // 
            this.nUSelBookRating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nUSelBookRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nUSelBookRating.Location = new System.Drawing.Point(116, 161);
            this.nUSelBookRating.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUSelBookRating.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUSelBookRating.Name = "nUSelBookRating";
            this.nUSelBookRating.Size = new System.Drawing.Size(220, 20);
            this.nUSelBookRating.TabIndex = 16;
            this.nUSelBookRating.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bOpenFolder
            // 
            this.bOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bOpenFolder.BackgroundImage = global::PDF_library.Properties.Resources.open_folder_document_clip_art;
            this.bOpenFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bOpenFolder.Location = new System.Drawing.Point(342, 245);
            this.bOpenFolder.Name = "bOpenFolder";
            this.bOpenFolder.Size = new System.Drawing.Size(32, 23);
            this.bOpenFolder.TabIndex = 17;
            this.bOpenFolder.UseVisualStyleBackColor = true;
            this.bOpenFolder.Click += new System.EventHandler(this.bOpenFolder_Click);
            // 
            // tSelBookFilePath
            // 
            this.tSelBookFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tSelBookFilePath.Location = new System.Drawing.Point(116, 231);
            this.tSelBookFilePath.Multiline = true;
            this.tSelBookFilePath.Name = "tSelBookFilePath";
            this.tSelBookFilePath.ReadOnly = true;
            this.tSelBookFilePath.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tSelBookFilePath.Size = new System.Drawing.Size(220, 51);
            this.tSelBookFilePath.TabIndex = 18;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pSelBookMetaInformation2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(383, 314);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PDF Book info ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pSelBookMetaInformation2
            // 
            this.pSelBookMetaInformation2.AutoScroll = true;
            this.pSelBookMetaInformation2.Controls.Add(this.tableLayoutPanelMetaInformation2);
            this.pSelBookMetaInformation2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pSelBookMetaInformation2.Location = new System.Drawing.Point(3, 3);
            this.pSelBookMetaInformation2.Name = "pSelBookMetaInformation2";
            this.pSelBookMetaInformation2.Size = new System.Drawing.Size(377, 308);
            this.pSelBookMetaInformation2.TabIndex = 0;
            // 
            // tableLayoutPanelMetaInformation2
            // 
            this.tableLayoutPanelMetaInformation2.ColumnCount = 3;
            this.tableLayoutPanelMetaInformation2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelMetaInformation2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.tableLayoutPanelMetaInformation2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanelMetaInformation2.Controls.Add(this.labelSelBookDescription, 0, 0);
            this.tableLayoutPanelMetaInformation2.Controls.Add(this.TSelBookDescription, 1, 0);
            this.tableLayoutPanelMetaInformation2.Controls.Add(this.labelSelBookPublishDate, 0, 1);
            this.tableLayoutPanelMetaInformation2.Controls.Add(this.dateTimePickerSelBookPublishDate, 1, 1);
            this.tableLayoutPanelMetaInformation2.Controls.Add(this.labelSelBookTags, 0, 2);
            this.tableLayoutPanelMetaInformation2.Controls.Add(this.TSelBookTags, 1, 2);
            this.tableLayoutPanelMetaInformation2.Controls.Add(this.labelSelBookBookID, 0, 3);
            this.tableLayoutPanelMetaInformation2.Controls.Add(this.lBookIDValue, 1, 3);
            this.tableLayoutPanelMetaInformation2.Controls.Add(this.bSelBookTagsInfo, 2, 2);
            this.tableLayoutPanelMetaInformation2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMetaInformation2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMetaInformation2.Name = "tableLayoutPanelMetaInformation2";
            this.tableLayoutPanelMetaInformation2.RowCount = 4;
            this.tableLayoutPanelMetaInformation2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelMetaInformation2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelMetaInformation2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelMetaInformation2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelMetaInformation2.Size = new System.Drawing.Size(377, 308);
            this.tableLayoutPanelMetaInformation2.TabIndex = 0;
            // 
            // labelSelBookDescription
            // 
            this.labelSelBookDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelBookDescription.AutoSize = true;
            this.labelSelBookDescription.Location = new System.Drawing.Point(25, 32);
            this.labelSelBookDescription.Name = "labelSelBookDescription";
            this.labelSelBookDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelSelBookDescription.Size = new System.Drawing.Size(63, 13);
            this.labelSelBookDescription.TabIndex = 0;
            this.labelSelBookDescription.Text = "Description:";
            // 
            // TSelBookDescription
            // 
            this.TSelBookDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TSelBookDescription.Location = new System.Drawing.Point(116, 3);
            this.TSelBookDescription.Multiline = true;
            this.TSelBookDescription.Name = "TSelBookDescription";
            this.TSelBookDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TSelBookDescription.Size = new System.Drawing.Size(227, 71);
            this.TSelBookDescription.TabIndex = 1;
            // 
            // labelSelBookPublishDate
            // 
            this.labelSelBookPublishDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelBookPublishDate.AutoSize = true;
            this.labelSelBookPublishDate.Location = new System.Drawing.Point(22, 109);
            this.labelSelBookPublishDate.Name = "labelSelBookPublishDate";
            this.labelSelBookPublishDate.Size = new System.Drawing.Size(68, 13);
            this.labelSelBookPublishDate.TabIndex = 2;
            this.labelSelBookPublishDate.Text = "Publish date:";
            // 
            // dateTimePickerSelBookPublishDate
            // 
            this.dateTimePickerSelBookPublishDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerSelBookPublishDate.Location = new System.Drawing.Point(116, 105);
            this.dateTimePickerSelBookPublishDate.Name = "dateTimePickerSelBookPublishDate";
            this.dateTimePickerSelBookPublishDate.Size = new System.Drawing.Size(227, 20);
            this.dateTimePickerSelBookPublishDate.TabIndex = 3;
            // 
            // labelSelBookTags
            // 
            this.labelSelBookTags.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelBookTags.AutoSize = true;
            this.labelSelBookTags.Location = new System.Drawing.Point(39, 186);
            this.labelSelBookTags.Name = "labelSelBookTags";
            this.labelSelBookTags.Size = new System.Drawing.Size(34, 13);
            this.labelSelBookTags.TabIndex = 4;
            this.labelSelBookTags.Text = "Tags:";
            // 
            // TSelBookTags
            // 
            this.TSelBookTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TSelBookTags.Location = new System.Drawing.Point(116, 157);
            this.TSelBookTags.Multiline = true;
            this.TSelBookTags.Name = "TSelBookTags";
            this.TSelBookTags.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TSelBookTags.Size = new System.Drawing.Size(227, 71);
            this.TSelBookTags.TabIndex = 5;
            // 
            // labelSelBookBookID
            // 
            this.labelSelBookBookID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelBookBookID.AutoSize = true;
            this.labelSelBookBookID.Location = new System.Drawing.Point(32, 263);
            this.labelSelBookBookID.Name = "labelSelBookBookID";
            this.labelSelBookBookID.Size = new System.Drawing.Size(49, 13);
            this.labelSelBookBookID.TabIndex = 6;
            this.labelSelBookBookID.Text = "Book ID:";
            // 
            // lBookIDValue
            // 
            this.lBookIDValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lBookIDValue.AutoSize = true;
            this.lBookIDValue.Location = new System.Drawing.Point(224, 263);
            this.lBookIDValue.Name = "lBookIDValue";
            this.lBookIDValue.Size = new System.Drawing.Size(10, 13);
            this.lBookIDValue.TabIndex = 7;
            this.lBookIDValue.Text = "-";
            // 
            // bSelBookTagsInfo
            // 
            this.bSelBookTagsInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bSelBookTagsInfo.BackgroundImage = global::PDF_library.Properties.Resources.Information_icon;
            this.bSelBookTagsInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSelBookTagsInfo.Location = new System.Drawing.Point(349, 181);
            this.bSelBookTagsInfo.Name = "bSelBookTagsInfo";
            this.bSelBookTagsInfo.Size = new System.Drawing.Size(25, 23);
            this.bSelBookTagsInfo.TabIndex = 8;
            this.bSelBookTagsInfo.UseVisualStyleBackColor = true;
            this.bSelBookTagsInfo.Click += new System.EventHandler(this.bSelBookTagsInfo_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Controls.Add(this.tableLayoutPanelMetaInformation3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(383, 314);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Bookshelf info";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelMetaInformation3
            // 
            this.tableLayoutPanelMetaInformation3.ColumnCount = 3;
            this.tableLayoutPanelMetaInformation3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelMetaInformation3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanelMetaInformation3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMetaInformation3.Controls.Add(this.labelSelBookBookShelf, 0, 0);
            this.tableLayoutPanelMetaInformation3.Controls.Add(this.comboBoxBookShelves, 1, 0);
            this.tableLayoutPanelMetaInformation3.Controls.Add(this.cBChangeBookshelf, 1, 1);
            this.tableLayoutPanelMetaInformation3.Controls.Add(this.labelSelBookBookShelf_ID, 0, 7);
            this.tableLayoutPanelMetaInformation3.Controls.Add(this.labelSelBookBookShelf_IDValue, 1, 7);
            this.tableLayoutPanelMetaInformation3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMetaInformation3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelMetaInformation3.Name = "tableLayoutPanelMetaInformation3";
            this.tableLayoutPanelMetaInformation3.RowCount = 8;
            this.tableLayoutPanelMetaInformation3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelMetaInformation3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelMetaInformation3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelMetaInformation3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelMetaInformation3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelMetaInformation3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelMetaInformation3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelMetaInformation3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanelMetaInformation3.Size = new System.Drawing.Size(377, 308);
            this.tableLayoutPanelMetaInformation3.TabIndex = 0;
            // 
            // labelSelBookBookShelf
            // 
            this.labelSelBookBookShelf.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelBookBookShelf.AutoSize = true;
            this.labelSelBookBookShelf.Location = new System.Drawing.Point(28, 12);
            this.labelSelBookBookShelf.Name = "labelSelBookBookShelf";
            this.labelSelBookBookShelf.Size = new System.Drawing.Size(57, 13);
            this.labelSelBookBookShelf.TabIndex = 0;
            this.labelSelBookBookShelf.Text = "Bookshelf:";
            // 
            // comboBoxBookShelves
            // 
            this.comboBoxBookShelves.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxBookShelves.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBookShelves.FormattingEnabled = true;
            this.comboBoxBookShelves.Location = new System.Drawing.Point(116, 8);
            this.comboBoxBookShelves.Name = "comboBoxBookShelves";
            this.comboBoxBookShelves.Size = new System.Drawing.Size(220, 21);
            this.comboBoxBookShelves.TabIndex = 1;
            // 
            // cBChangeBookshelf
            // 
            this.cBChangeBookshelf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBChangeBookshelf.AutoSize = true;
            this.cBChangeBookshelf.Location = new System.Drawing.Point(116, 48);
            this.cBChangeBookshelf.Name = "cBChangeBookshelf";
            this.cBChangeBookshelf.Size = new System.Drawing.Size(220, 17);
            this.cBChangeBookshelf.TabIndex = 2;
            this.cBChangeBookshelf.Text = "Change Bookshelf";
            this.cBChangeBookshelf.UseVisualStyleBackColor = true;
            this.cBChangeBookshelf.CheckedChanged += new System.EventHandler(this.cBChangeBookshelf_CheckedChanged);
            // 
            // labelSelBookBookShelf_ID
            // 
            this.labelSelBookBookShelf_ID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelBookBookShelf_ID.AutoSize = true;
            this.labelSelBookBookShelf_ID.Location = new System.Drawing.Point(21, 280);
            this.labelSelBookBookShelf_ID.Name = "labelSelBookBookShelf_ID";
            this.labelSelBookBookShelf_ID.Size = new System.Drawing.Size(71, 13);
            this.labelSelBookBookShelf_ID.TabIndex = 3;
            this.labelSelBookBookShelf_ID.Text = "Bookshelf ID:";
            // 
            // labelSelBookBookShelf_IDValue
            // 
            this.labelSelBookBookShelf_IDValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelBookBookShelf_IDValue.AutoSize = true;
            this.labelSelBookBookShelf_IDValue.Location = new System.Drawing.Point(221, 280);
            this.labelSelBookBookShelf_IDValue.Name = "labelSelBookBookShelf_IDValue";
            this.labelSelBookBookShelf_IDValue.Size = new System.Drawing.Size(10, 13);
            this.labelSelBookBookShelf_IDValue.TabIndex = 4;
            this.labelSelBookBookShelf_IDValue.Text = "-";
            // 
            // pSelBookChangeButtons
            // 
            this.pSelBookChangeButtons.Controls.Add(this.tableLayoutPanel1);
            this.pSelBookChangeButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pSelBookChangeButtons.Location = new System.Drawing.Point(217, 3);
            this.pSelBookChangeButtons.Name = "pSelBookChangeButtons";
            this.pSelBookChangeButtons.Size = new System.Drawing.Size(171, 34);
            this.pSelBookChangeButtons.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.bSelBookChange, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.bSelBookDelete, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(171, 34);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // bSelBookChange
            // 
            this.bSelBookChange.BackgroundImage = global::PDF_library.Properties.Resources.change_icon;
            this.bSelBookChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSelBookChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bSelBookChange.Location = new System.Drawing.Point(139, 3);
            this.bSelBookChange.Name = "bSelBookChange";
            this.bSelBookChange.Size = new System.Drawing.Size(29, 28);
            this.bSelBookChange.TabIndex = 0;
            this.bSelBookChange.UseVisualStyleBackColor = true;
            this.bSelBookChange.Click += new System.EventHandler(this.bSelBookChange_Click);
            // 
            // bSelBookDelete
            // 
            this.bSelBookDelete.BackgroundImage = global::PDF_library.Properties.Resources.red_delete_button;
            this.bSelBookDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bSelBookDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bSelBookDelete.Location = new System.Drawing.Point(71, 3);
            this.bSelBookDelete.Name = "bSelBookDelete";
            this.bSelBookDelete.Size = new System.Drawing.Size(28, 28);
            this.bSelBookDelete.TabIndex = 1;
            this.bSelBookDelete.UseVisualStyleBackColor = true;
            this.bSelBookDelete.Click += new System.EventHandler(this.bSelBookDelete_Click);
            // 
            // tableLayoutPanelSelBook
            // 
            this.tableLayoutPanelSelBook.ColumnCount = 2;
            this.tableLayoutPanelSelBook.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanelSelBook.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanelSelBook.Controls.Add(this.pSelBookCoverImage, 0, 0);
            this.tableLayoutPanelSelBook.Controls.Add(this.tableLayoutPanelSelBook2, 1, 0);
            this.tableLayoutPanelSelBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSelBook.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelSelBook.Name = "tableLayoutPanelSelBook";
            this.tableLayoutPanelSelBook.RowCount = 1;
            this.tableLayoutPanelSelBook.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSelBook.Size = new System.Drawing.Size(731, 439);
            this.tableLayoutPanelSelBook.TabIndex = 0;
            // 
            // pSelBookCoverImage
            // 
            this.pSelBookCoverImage.BackColor = System.Drawing.Color.White;
            this.pSelBookCoverImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pSelBookCoverImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pSelBookCoverImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pSelBookCoverImage.Location = new System.Drawing.Point(3, 3);
            this.pSelBookCoverImage.Name = "pSelBookCoverImage";
            this.pSelBookCoverImage.Size = new System.Drawing.Size(322, 433);
            this.pSelBookCoverImage.TabIndex = 0;
            this.pSelBookCoverImage.TabStop = false;
            // 
            // tableLayoutPanelSelBook2
            // 
            this.tableLayoutPanelSelBook2.ColumnCount = 1;
            this.tableLayoutPanelSelBook2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSelBook2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelSelBook2.Controls.Add(this.pSelBookDescription, 0, 0);
            this.tableLayoutPanelSelBook2.Controls.Add(this.pSelBookButtons, 0, 1);
            this.tableLayoutPanelSelBook2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSelBook2.Location = new System.Drawing.Point(331, 3);
            this.tableLayoutPanelSelBook2.Name = "tableLayoutPanelSelBook2";
            this.tableLayoutPanelSelBook2.RowCount = 2;
            this.tableLayoutPanelSelBook2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelSelBook2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelSelBook2.Size = new System.Drawing.Size(397, 433);
            this.tableLayoutPanelSelBook2.TabIndex = 1;
            // 
            // pSelBookDescription
            // 
            this.pSelBookDescription.AutoScroll = true;
            this.pSelBookDescription.BackColor = System.Drawing.Color.White;
            this.pSelBookDescription.Controls.Add(tabControlPDF_Book);
            this.pSelBookDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pSelBookDescription.Location = new System.Drawing.Point(3, 3);
            this.pSelBookDescription.Name = "pSelBookDescription";
            this.pSelBookDescription.Size = new System.Drawing.Size(391, 340);
            this.pSelBookDescription.TabIndex = 0;
            // 
            // pSelBookButtons
            // 
            this.pSelBookButtons.AutoScroll = true;
            this.pSelBookButtons.BackColor = System.Drawing.Color.White;
            this.pSelBookButtons.Controls.Add(this.tableLayoutPanelSelbookButtons);
            this.pSelBookButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pSelBookButtons.Location = new System.Drawing.Point(3, 349);
            this.pSelBookButtons.Name = "pSelBookButtons";
            this.pSelBookButtons.Size = new System.Drawing.Size(391, 81);
            this.pSelBookButtons.TabIndex = 1;
            // 
            // tableLayoutPanelSelbookButtons
            // 
            this.tableLayoutPanelSelbookButtons.ColumnCount = 3;
            this.tableLayoutPanelSelbookButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanelSelbookButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelSelbookButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanelSelbookButtons.Controls.Add(this.bSelBookRead, 2, 1);
            this.tableLayoutPanelSelbookButtons.Controls.Add(this.bSelBookCancel, 0, 1);
            this.tableLayoutPanelSelbookButtons.Controls.Add(this.pSelBookChangeButtons, 2, 0);
            this.tableLayoutPanelSelbookButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSelbookButtons.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelSelbookButtons.Name = "tableLayoutPanelSelbookButtons";
            this.tableLayoutPanelSelbookButtons.RowCount = 2;
            this.tableLayoutPanelSelbookButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSelbookButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSelbookButtons.Size = new System.Drawing.Size(391, 81);
            this.tableLayoutPanelSelbookButtons.TabIndex = 0;
            // 
            // bSelBookRead
            // 
            this.bSelBookRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bSelBookRead.Location = new System.Drawing.Point(217, 49);
            this.bSelBookRead.Name = "bSelBookRead";
            this.bSelBookRead.Size = new System.Drawing.Size(171, 23);
            this.bSelBookRead.TabIndex = 0;
            this.bSelBookRead.Text = "Read";
            this.bSelBookRead.UseVisualStyleBackColor = true;
            this.bSelBookRead.Click += new System.EventHandler(this.bSelBookRead_Click);
            // 
            // bSelBookCancel
            // 
            this.bSelBookCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bSelBookCancel.Location = new System.Drawing.Point(3, 49);
            this.bSelBookCancel.Name = "bSelBookCancel";
            this.bSelBookCancel.Size = new System.Drawing.Size(169, 23);
            this.bSelBookCancel.TabIndex = 1;
            this.bSelBookCancel.Text = "Cancel";
            this.bSelBookCancel.UseVisualStyleBackColor = true;
            this.bSelBookCancel.Click += new System.EventHandler(this.bSelBookCancel_Click);
            // 
            // Selected_PDF_Book
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 439);
            this.Controls.Add(this.tableLayoutPanelSelBook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Selected_PDF_Book";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF Book";
            this.Load += new System.EventHandler(this.Selected_PDF_Book_Load);
            this.Shown += new System.EventHandler(this.Selected_PDF_Book_Shown);
            tabControlPDF_Book.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pSelBookMetaInformation.ResumeLayout(false);
            this.tableLayoutPanelSelBookDescription.ResumeLayout(false);
            this.tableLayoutPanelSelBookDescription.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUSelBookRating)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.pSelBookMetaInformation2.ResumeLayout(false);
            this.tableLayoutPanelMetaInformation2.ResumeLayout(false);
            this.tableLayoutPanelMetaInformation2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanelMetaInformation3.ResumeLayout(false);
            this.tableLayoutPanelMetaInformation3.PerformLayout();
            this.pSelBookChangeButtons.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanelSelBook.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pSelBookCoverImage)).EndInit();
            this.tableLayoutPanelSelBook2.ResumeLayout(false);
            this.pSelBookDescription.ResumeLayout(false);
            this.pSelBookButtons.ResumeLayout(false);
            this.tableLayoutPanelSelbookButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSelBook;
        private System.Windows.Forms.PictureBox pSelBookCoverImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSelBook2;
        private System.Windows.Forms.Panel pSelBookDescription;
        private System.Windows.Forms.Panel pSelBookButtons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSelBookDescription;
        private System.Windows.Forms.Label labelSelBookFileName;
        private System.Windows.Forms.Label labelSelBookTitle;
        private System.Windows.Forms.Label labelSelBookWriter;
        private System.Windows.Forms.Label labelSelBookNofpages;
        private System.Windows.Forms.Label labelSelBookFilepath;
        private System.Windows.Forms.Label lSelBookFileName;
        private System.Windows.Forms.Label lSelBookNofpages;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSelbookButtons;
        private System.Windows.Forms.Button bSelBookRead;
        private System.Windows.Forms.Button bSelBookCancel;
        private System.Windows.Forms.TextBox TSelBookWriter;
        private System.Windows.Forms.TextBox TSelBookTitle;
        private System.Windows.Forms.Panel pSelBookChangeButtons;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button bSelBookChange;
        private System.Windows.Forms.Label labelSelBookSubject;
        private System.Windows.Forms.TextBox TSelBookSubject;
        private System.Windows.Forms.Button bSelBookDelete;
        private System.Windows.Forms.Label labelSelBookRating;
        private System.Windows.Forms.NumericUpDown nUSelBookRating;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pSelBookMetaInformation;
        private System.Windows.Forms.Panel pSelBookMetaInformation2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMetaInformation2;
        private System.Windows.Forms.Label labelSelBookDescription;
        private System.Windows.Forms.TextBox TSelBookDescription;
        private System.Windows.Forms.Label labelSelBookPublishDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerSelBookPublishDate;
        private System.Windows.Forms.Label labelSelBookTags;
        private System.Windows.Forms.TextBox TSelBookTags;
        private System.Windows.Forms.Label labelSelBookBookID;
        private System.Windows.Forms.Label lBookIDValue;
        private System.Windows.Forms.Button bOpenFolder;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMetaInformation3;
        private System.Windows.Forms.Label labelSelBookBookShelf;
        private System.Windows.Forms.ComboBox comboBoxBookShelves;
        private System.Windows.Forms.CheckBox cBChangeBookshelf;
        private System.Windows.Forms.Label labelSelBookBookShelf_ID;
        private System.Windows.Forms.Label labelSelBookBookShelf_IDValue;
        private System.Windows.Forms.TextBox tSelBookFilePath;
        private System.Windows.Forms.Button bSelBookTagsInfo;

    }
}