namespace PDF_library
{
    partial class PDF_Library_Options
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
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.tabPageBookshelf = new System.Windows.Forms.TabPage();
            this.tLPBookShelfSettings = new System.Windows.Forms.TableLayoutPanel();
            this.lOptionsBookShelfSize = new System.Windows.Forms.Label();
            this.cBBookCoverImageSize = new System.Windows.Forms.ComboBox();
            this.lOptionsBookShelfBackColor = new System.Windows.Forms.Label();
            this.bBookShelfBackgroundColor = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cBPDFpages = new System.Windows.Forms.CheckBox();
            this.cBFileName = new System.Windows.Forms.CheckBox();
            this.lScanOptionsDescription = new System.Windows.Forms.Label();
            this.bBookShelfSettingsApply = new System.Windows.Forms.Button();
            this.pOptionsApply = new System.Windows.Forms.Panel();
            this.tableLayoutPanelApply = new System.Windows.Forms.TableLayoutPanel();
            this.tabControlOptions.SuspendLayout();
            this.tabPageBookshelf.SuspendLayout();
            this.tLPBookShelfSettings.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pOptionsApply.SuspendLayout();
            this.tableLayoutPanelApply.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Controls.Add(this.tabPageBookshelf);
            this.tabControlOptions.Controls.Add(this.tabPage2);
            this.tabControlOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlOptions.Location = new System.Drawing.Point(0, 0);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(539, 363);
            this.tabControlOptions.TabIndex = 0;
            // 
            // tabPageBookshelf
            // 
            this.tabPageBookshelf.AutoScroll = true;
            this.tabPageBookshelf.Controls.Add(this.tLPBookShelfSettings);
            this.tabPageBookshelf.Location = new System.Drawing.Point(4, 22);
            this.tabPageBookshelf.Name = "tabPageBookshelf";
            this.tabPageBookshelf.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBookshelf.Size = new System.Drawing.Size(531, 337);
            this.tabPageBookshelf.TabIndex = 0;
            this.tabPageBookshelf.Text = "Bookshelf view settings";
            this.tabPageBookshelf.UseVisualStyleBackColor = true;
            // 
            // tLPBookShelfSettings
            // 
            this.tLPBookShelfSettings.ColumnCount = 4;
            this.tLPBookShelfSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tLPBookShelfSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tLPBookShelfSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tLPBookShelfSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tLPBookShelfSettings.Controls.Add(this.lOptionsBookShelfSize, 0, 0);
            this.tLPBookShelfSettings.Controls.Add(this.cBBookCoverImageSize, 1, 0);
            this.tLPBookShelfSettings.Controls.Add(this.lOptionsBookShelfBackColor, 0, 1);
            this.tLPBookShelfSettings.Controls.Add(this.bBookShelfBackgroundColor, 1, 1);
            this.tLPBookShelfSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPBookShelfSettings.Location = new System.Drawing.Point(3, 3);
            this.tLPBookShelfSettings.Name = "tLPBookShelfSettings";
            this.tLPBookShelfSettings.RowCount = 5;
            this.tLPBookShelfSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLPBookShelfSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLPBookShelfSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLPBookShelfSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLPBookShelfSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tLPBookShelfSettings.Size = new System.Drawing.Size(525, 331);
            this.tLPBookShelfSettings.TabIndex = 0;
            // 
            // lOptionsBookShelfSize
            // 
            this.lOptionsBookShelfSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lOptionsBookShelfSize.AutoSize = true;
            this.lOptionsBookShelfSize.Location = new System.Drawing.Point(7, 26);
            this.lOptionsBookShelfSize.Name = "lOptionsBookShelfSize";
            this.lOptionsBookShelfSize.Size = new System.Drawing.Size(117, 13);
            this.lOptionsBookShelfSize.TabIndex = 0;
            this.lOptionsBookShelfSize.Text = "Book cover image size:";
            // 
            // cBBookCoverImageSize
            // 
            this.cBBookCoverImageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBBookCoverImageSize.FormattingEnabled = true;
            this.cBBookCoverImageSize.Items.AddRange(new object[] {
            "Tiny",
            "Small",
            "Medium",
            "Normal",
            "Large"});
            this.cBBookCoverImageSize.Location = new System.Drawing.Point(134, 22);
            this.cBBookCoverImageSize.Name = "cBBookCoverImageSize";
            this.cBBookCoverImageSize.Size = new System.Drawing.Size(309, 21);
            this.cBBookCoverImageSize.TabIndex = 1;
            this.cBBookCoverImageSize.SelectedIndexChanged += new System.EventHandler(this.cBBookCoverImageSize_SelectedIndexChanged);
            // 
            // lOptionsBookShelfBackColor
            // 
            this.lOptionsBookShelfBackColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lOptionsBookShelfBackColor.AutoSize = true;
            this.lOptionsBookShelfBackColor.Location = new System.Drawing.Point(7, 86);
            this.lOptionsBookShelfBackColor.Name = "lOptionsBookShelfBackColor";
            this.lOptionsBookShelfBackColor.Size = new System.Drawing.Size(117, 26);
            this.lOptionsBookShelfBackColor.TabIndex = 3;
            this.lOptionsBookShelfBackColor.Text = "Bookshelf background color:";
            // 
            // bBookShelfBackgroundColor
            // 
            this.bBookShelfBackgroundColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bBookShelfBackgroundColor.Location = new System.Drawing.Point(134, 87);
            this.bBookShelfBackgroundColor.Name = "bBookShelfBackgroundColor";
            this.bBookShelfBackgroundColor.Size = new System.Drawing.Size(309, 23);
            this.bBookShelfBackgroundColor.TabIndex = 4;
            this.bBookShelfBackgroundColor.Text = "pick color";
            this.bBookShelfBackgroundColor.UseVisualStyleBackColor = true;
            this.bBookShelfBackgroundColor.Click += new System.EventHandler(this.bBookShelfBackgroundColor_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(531, 337);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Scan Options";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.lScanOptionsDescription, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cBFileName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cBPDFpages, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(525, 331);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // cBPDFpages
            // 
            this.cBPDFpages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBPDFpages.AutoSize = true;
            this.cBPDFpages.Location = new System.Drawing.Point(3, 74);
            this.cBPDFpages.Name = "cBPDFpages";
            this.cBPDFpages.Size = new System.Drawing.Size(204, 17);
            this.cBPDFpages.TabIndex = 3;
            this.cBPDFpages.Text = "First two pages of PDF file";
            this.cBPDFpages.UseVisualStyleBackColor = true;
            // 
            // cBFileName
            // 
            this.cBFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cBFileName.AutoSize = true;
            this.cBFileName.Location = new System.Drawing.Point(3, 41);
            this.cBFileName.Name = "cBFileName";
            this.cBFileName.Size = new System.Drawing.Size(204, 17);
            this.cBFileName.TabIndex = 2;
            this.cBFileName.Text = "PDF filename";
            this.cBFileName.UseVisualStyleBackColor = true;
            // 
            // lScanOptionsDescription
            // 
            this.lScanOptionsDescription.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lScanOptionsDescription.AutoSize = true;
            this.lScanOptionsDescription.Location = new System.Drawing.Point(3, 10);
            this.lScanOptionsDescription.Name = "lScanOptionsDescription";
            this.lScanOptionsDescription.Size = new System.Drawing.Size(118, 13);
            this.lScanOptionsDescription.TabIndex = 1;
            this.lScanOptionsDescription.Text = "Look for search term in:";
            // 
            // bBookShelfSettingsApply
            // 
            this.bBookShelfSettingsApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bBookShelfSettingsApply.Location = new System.Drawing.Point(434, 10);
            this.bBookShelfSettingsApply.Name = "bBookShelfSettingsApply";
            this.bBookShelfSettingsApply.Size = new System.Drawing.Size(102, 23);
            this.bBookShelfSettingsApply.TabIndex = 2;
            this.bBookShelfSettingsApply.Text = "Apply";
            this.bBookShelfSettingsApply.UseVisualStyleBackColor = true;
            this.bBookShelfSettingsApply.Click += new System.EventHandler(this.bBookShelfSettingsApply_Click);
            // 
            // pOptionsApply
            // 
            this.pOptionsApply.Controls.Add(this.tableLayoutPanelApply);
            this.pOptionsApply.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pOptionsApply.Location = new System.Drawing.Point(0, 363);
            this.pOptionsApply.Name = "pOptionsApply";
            this.pOptionsApply.Size = new System.Drawing.Size(539, 44);
            this.pOptionsApply.TabIndex = 1;
            // 
            // tableLayoutPanelApply
            // 
            this.tableLayoutPanelApply.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelApply.ColumnCount = 2;
            this.tableLayoutPanelApply.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelApply.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelApply.Controls.Add(this.bBookShelfSettingsApply, 1, 0);
            this.tableLayoutPanelApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelApply.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelApply.Name = "tableLayoutPanelApply";
            this.tableLayoutPanelApply.RowCount = 1;
            this.tableLayoutPanelApply.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelApply.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelApply.Size = new System.Drawing.Size(539, 44);
            this.tableLayoutPanelApply.TabIndex = 0;
            // 
            // PDF_Library_Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 407);
            this.Controls.Add(this.tabControlOptions);
            this.Controls.Add(this.pOptionsApply);
            this.Name = "PDF_Library_Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.PDF_Library_Options_Load);
            this.tabControlOptions.ResumeLayout(false);
            this.tabPageBookshelf.ResumeLayout(false);
            this.tLPBookShelfSettings.ResumeLayout(false);
            this.tLPBookShelfSettings.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pOptionsApply.ResumeLayout(false);
            this.tableLayoutPanelApply.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlOptions;
        private System.Windows.Forms.TabPage tabPageBookshelf;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tLPBookShelfSettings;
        private System.Windows.Forms.Label lOptionsBookShelfSize;
        private System.Windows.Forms.ComboBox cBBookCoverImageSize;
        private System.Windows.Forms.Button bBookShelfSettingsApply;
        private System.Windows.Forms.Label lOptionsBookShelfBackColor;
        private System.Windows.Forms.Button bBookShelfBackgroundColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox cBPDFpages;
        private System.Windows.Forms.CheckBox cBFileName;
        private System.Windows.Forms.Label lScanOptionsDescription;
        private System.Windows.Forms.Panel pOptionsApply;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelApply;
    }
}