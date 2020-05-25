using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace PDF_library
{
    public partial class Scanned_Books : Form
    {
        List<string> FoundBooks = new List<string>();
        List<string> ErrorBooks = new List<string>();
        int BooksInDirectory;



        public Scanned_Books(List<string> _FoundBooks, List<string> _ErrorBooks, int _PDFBooks)
        {
            InitializeComponent();
            FoundBooks = _FoundBooks;
            ErrorBooks = _ErrorBooks;
            BooksInDirectory = _PDFBooks;
        }

        private void Scanned_Books_Load(object sender, EventArgs e)
        {
            ShowBookGridview(FoundBooks, pAddedBooks);
            ShowBookGridview(ErrorBooks, pErrorBooks);

            lBooksInDirectory.Text = "PDF files found in the scanned directory path: " + BooksInDirectory.ToString();
            lAddedBooks.Text = "Added PDF books: " + FoundBooks.Count();
            lErrorBooks.Text = "Books that could not be added: " + ErrorBooks.Count();
        }

        public void ShowBookGridview(List<string> _Books, Panel _Panel)
        {

            try
            {
                // _Panel.Controls.Clear();
                DataGridView GView = new DataGridView();
                GView.Name = "Gridview_AllBooks";
                GView.BackgroundColor = Color.White;
                //GView.ScrollBars = ScrollBars.None;
                GView.ScrollBars = ScrollBars.Both;
                GView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                //pBookShelves.AutoScroll = false;

                DataGridViewColumn newCol0 = new DataGridViewTextBoxColumn();
                newCol0.HeaderText = "Index";
                newCol0.Width = Convert.ToInt16(80);
                newCol0.ValueType = typeof(System.Int16);
                newCol0.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol0);

                DataGridViewColumn newCol1 = new DataGridViewTextBoxColumn();
                newCol1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                newCol1.HeaderText = "PDF file";
                newCol1.Width = Convert.ToInt16(200);
                newCol1.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol1);

                DataGridViewColumn newCol2 = new DataGridViewTextBoxColumn();
                newCol2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                newCol2.HeaderText = "Error:";
                newCol2.Width = Convert.ToInt16(400);
                newCol2.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol2);

                //GView.Columns.Add(newCol2);

                int i = 1;

                // do something with entry.Value or entry.Key

                foreach (string s in _Books)
                {
                    // do something with entry.Value or entry.Key
                    string[] _value = s.Split('%');



                    DataGridViewRow row = (DataGridViewRow)GView.Rows[0].Clone();
                    row.Cells[0].Value = i;
                    row.Cells[1].Value = _value[0];

                    if (_value.Count() > 1)
                    {
                        row.Cells[2].Value = _value[1];
                    }
                    else
                    {
                        row.Cells[2].Value = "";
                    }

                    //row.ReadOnly = true;
                    //row.Cells[6].Value = entry.Key.name;
                    //DataGridViewButtonCell bopenfolder1 = new DataGridViewButtonCell();
                    //bopenfolder1.Value = "Open folder";

                    //row.Cells[6].Value = bopenfolder1;
                    GView.Rows.Add(row);


                    i = i + 1;
                }


                GView.Width = _Panel.Width;
                GView.Height = _Panel.Height;
                GView.PerformLayout();
                GView.Dock = DockStyle.Fill;
                //  GView.SendToBack();
                GView.BringToFront();
                //GView.En

                //return GView;
                _Panel.Controls.Add(GView);

            }
            catch (Exception e2)
            {
                MessageBox.Show("An error occurred: '{0}':  " + e2);
            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
