namespace PDF_library
{
    partial class Scanned_Books
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
            this.tLPScannedBooks = new System.Windows.Forms.TableLayoutPanel();
            this.pAddedBooks = new System.Windows.Forms.Panel();
            this.pErrorBooks = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bOK = new System.Windows.Forms.Button();
            this.lBooksInDirectory = new System.Windows.Forms.Label();
            this.lAddedBooks = new System.Windows.Forms.Label();
            this.lErrorBooks = new System.Windows.Forms.Label();
            this.tLPScannedBooks.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tLPScannedBooks
            // 
            this.tLPScannedBooks.ColumnCount = 1;
            this.tLPScannedBooks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tLPScannedBooks.Controls.Add(this.pAddedBooks, 0, 2);
            this.tLPScannedBooks.Controls.Add(this.pErrorBooks, 0, 4);
            this.tLPScannedBooks.Controls.Add(this.tableLayoutPanel1, 0, 5);
            this.tLPScannedBooks.Controls.Add(this.lBooksInDirectory, 0, 0);
            this.tLPScannedBooks.Controls.Add(this.lAddedBooks, 0, 1);
            this.tLPScannedBooks.Controls.Add(this.lErrorBooks, 0, 3);
            this.tLPScannedBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLPScannedBooks.Location = new System.Drawing.Point(0, 0);
            this.tLPScannedBooks.Name = "tLPScannedBooks";
            this.tLPScannedBooks.RowCount = 6;
            this.tLPScannedBooks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tLPScannedBooks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tLPScannedBooks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tLPScannedBooks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tLPScannedBooks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tLPScannedBooks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tLPScannedBooks.Size = new System.Drawing.Size(631, 481);
            this.tLPScannedBooks.TabIndex = 0;
            // 
            // pAddedBooks
            // 
            this.pAddedBooks.BackColor = System.Drawing.Color.White;
            this.pAddedBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAddedBooks.Location = new System.Drawing.Point(3, 99);
            this.pAddedBooks.Name = "pAddedBooks";
            this.pAddedBooks.Size = new System.Drawing.Size(625, 162);
            this.pAddedBooks.TabIndex = 0;
            // 
            // pErrorBooks
            // 
            this.pErrorBooks.BackColor = System.Drawing.Color.White;
            this.pErrorBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pErrorBooks.Location = new System.Drawing.Point(3, 315);
            this.pErrorBooks.Name = "pErrorBooks";
            this.pErrorBooks.Size = new System.Drawing.Size(625, 114);
            this.pErrorBooks.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.bOK, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 435);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(625, 43);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // bOK
            // 
            this.bOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bOK.Location = new System.Drawing.Point(503, 10);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(119, 23);
            this.bOK.TabIndex = 0;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // lBooksInDirectory
            // 
            this.lBooksInDirectory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lBooksInDirectory.AutoSize = true;
            this.lBooksInDirectory.Location = new System.Drawing.Point(3, 17);
            this.lBooksInDirectory.Name = "lBooksInDirectory";
            this.lBooksInDirectory.Size = new System.Drawing.Size(10, 13);
            this.lBooksInDirectory.TabIndex = 3;
            this.lBooksInDirectory.Text = "-";
            // 
            // lAddedBooks
            // 
            this.lAddedBooks.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lAddedBooks.AutoSize = true;
            this.lAddedBooks.Location = new System.Drawing.Point(3, 65);
            this.lAddedBooks.Name = "lAddedBooks";
            this.lAddedBooks.Size = new System.Drawing.Size(10, 13);
            this.lAddedBooks.TabIndex = 4;
            this.lAddedBooks.Text = "-";
            // 
            // lErrorBooks
            // 
            this.lErrorBooks.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lErrorBooks.AutoSize = true;
            this.lErrorBooks.Location = new System.Drawing.Point(3, 281);
            this.lErrorBooks.Name = "lErrorBooks";
            this.lErrorBooks.Size = new System.Drawing.Size(10, 13);
            this.lErrorBooks.TabIndex = 5;
            this.lErrorBooks.Text = "-";
            // 
            // Scanned_Books
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 481);
            this.Controls.Add(this.tLPScannedBooks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Scanned_Books";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scanned Books";
            this.Load += new System.EventHandler(this.Scanned_Books_Load);
            this.tLPScannedBooks.ResumeLayout(false);
            this.tLPScannedBooks.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tLPScannedBooks;
        private System.Windows.Forms.Panel pAddedBooks;
        private System.Windows.Forms.Panel pErrorBooks;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Label lBooksInDirectory;
        private System.Windows.Forms.Label lAddedBooks;
        private System.Windows.Forms.Label lErrorBooks;
    }
}