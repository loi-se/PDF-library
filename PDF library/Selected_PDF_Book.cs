using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PdfiumViewer;

using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace PDF_library
{
    public partial class Selected_PDF_Book : Form
    {
        public PDF_Book _PDF_Book_Selected;
        //public ArrayList _PDF_Bookshelves;
        public Dictionary<string, string> _PDF_Bookshelves = new Dictionary<string, string>();

        private Boolean _writer_valid = false;
        private Boolean _subject_valid = false;
        private Boolean _title_valid = false;
        private Boolean _description_valid = false;
        private Boolean _tags_valid = false;

        string Invalid_userinput = " Please enter valid values:" + Environment.NewLine + Environment.NewLine +
                          " - Title: (Number of characters should be between: 0-250) " + Environment.NewLine +
                          " - Writer: (Number of characters should be between: 0-250) " + Environment.NewLine +
                          " - Subject: (Number of characters should be between: 0-250) " + Environment.NewLine +
                          " - Description: (Number of characters should be between: 0-1000) " + Environment.NewLine +
                          " - Tags: (Number of characters should be between: 0-1000)" + Environment.NewLine + Environment.NewLine +
                          " - Characters not allowed: &.";


        public Selected_PDF_Book(PDF_Book Sel_PDF_Book, Dictionary<string, string> PDF_Book_shelves, string _CancelButtonText)
        {
            InitializeComponent();
            _PDF_Book_Selected = Sel_PDF_Book;
            _PDF_Bookshelves = PDF_Book_shelves;
            bSelBookCancel.Text = _CancelButtonText;
        }

        private void Selected_PDF_Book_Shown(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(_PDF_Book_Selected.cover_imagepath))
                {
                    //    MessageBox.Show("No Image");
                    //}
                    //else
                    //{

                    //  Bookcover_PB = new PB_Coverimage();

                    FileStream fs = null;
                    try
                    {
                        fs = new FileStream(_PDF_Book_Selected.cover_imagepath, FileMode.Open, FileAccess.Read);
                        pSelBookCoverImage.BackgroundImage = System.Drawing.Image.FromStream(fs);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        fs.Close();
                    }

                    lBookIDValue.Text = _PDF_Book_Selected.Book_ID;
                    labelSelBookBookShelf_IDValue.Text = _PDF_Book_Selected.Book_Shelf_ID;
                    lSelBookFileName.Text = _PDF_Book_Selected.filename;
                    TSelBookTitle.Text = _PDF_Book_Selected.title;
                    TSelBookSubject.Text = _PDF_Book_Selected.subject;
                    TSelBookWriter.Text = _PDF_Book_Selected.writer;
                    
                    TSelBookDescription.Text = _PDF_Book_Selected.description;
                    TSelBookTags.Text = _PDF_Book_Selected.tags;
                    dateTimePickerSelBookPublishDate.Value = _PDF_Book_Selected.publishdate;

                    lSelBookNofpages.Text = _PDF_Book_Selected.number_of_pages.ToString();
                    tSelBookFilePath.Text = _PDF_Book_Selected.filepath;
                    nUSelBookRating.Value = Convert.ToDecimal(_PDF_Book_Selected.rating);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Selected_PDF_Book_Load(object sender, EventArgs e)
        {
            try
            {
                string CurrentBookshelfName = "";
                //foreach (string _Book_Shelf_Info in _PDF_Bookshelves)
                //{
                foreach (KeyValuePair<string, string> entry in  _PDF_Bookshelves)
                {
                    comboBoxBookShelves.Items.Add(entry.Key);

                    if (entry.Value == _PDF_Book_Selected.Book_Shelf_ID)
                    {
                        CurrentBookshelfName = entry.Key;
                    }
                }
                //}

                comboBoxBookShelves.SelectedIndex = comboBoxBookShelves.FindString(CurrentBookshelfName);
                comboBoxBookShelves.Enabled = false;

                GlobalVar._PDF_Book_Bookshelf_old_ID = _PDF_Book_Selected.Book_Shelf_ID;
                GlobalVar._PDF_Book_Bookshelf_old_coverimagepath = _PDF_Book_Selected.cover_imagepath;
                

                _writer_valid = false;
                _subject_valid = false;
                _title_valid = false;

                _description_valid = false;
                _tags_valid = false;

                tSelBookFilePath.ReadOnly = true;
            }
            catch
            {
            }

        }

        private void bSelBookCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSelBookRead_Click(object sender, EventArgs e)
        {
            string folderpath = _PDF_Book_Selected.filepath;
            //Form1 form1 = new Form1();
            GlobalVar._PDF_Book_Read_Filepath = _PDF_Book_Selected.filepath;
            GlobalVar._PDF_Book_Read_Boolean = true;
            GlobalVar._PDF_Book_Opened = _PDF_Book_Selected;

         

            //TCMain.SelectedIndex = 2;

            //form1.webBrowser.Navigate(folderpath);
            //form1.webBrowser.Show();

            
            this.Close();
        }

        // Change the selected book:
        private void bSelBookChange_Click(object sender, EventArgs e)
        {
            
                DialogResult result = MessageBox.Show("Do you want to update the meta information of this book?", "Change book",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
           
                if (result == DialogResult.OK)
                {

                    Validate_UserInput();

                    if (_title_valid == true & _writer_valid == true & _subject_valid == true & _description_valid == true & _tags_valid == true)
                    {
                        GlobalVar._PDF_Book_Changed_Boolean = true;
                        GlobalVar._PDF_Book_Changed = new PDF_Book();

                        GlobalVar._PDF_Book_Changed.filename = _PDF_Book_Selected.filename;
                        GlobalVar._PDF_Book_Changed.filepath = _PDF_Book_Selected.filepath;
                        GlobalVar._PDF_Book_Changed.cover_imagepath = _PDF_Book_Selected.cover_imagepath;
                        GlobalVar._PDF_Book_Changed.number_of_pages = _PDF_Book_Selected.number_of_pages;
                        GlobalVar._PDF_Book_Changed.Book_Shelf_ID = _PDF_Book_Selected.Book_Shelf_ID;
                        GlobalVar._PDF_Book_Changed.Book_ID = _PDF_Book_Selected.Book_ID;
                        GlobalVar._PDF_Book_Changed.rating = Convert.ToInt32(nUSelBookRating.Value);
                        GlobalVar._PDF_Book_Changed.subject = TSelBookSubject.Text;
                        GlobalVar._PDF_Book_Changed.filesize = _PDF_Book_Selected.filesize;
                        GlobalVar._PDF_Book_Changed.description = TSelBookDescription.Text;
                        GlobalVar._PDF_Book_Changed.tags = TSelBookTags.Text;
                        GlobalVar._PDF_Book_Changed.publishdate = dateTimePickerSelBookPublishDate.Value;


                        GlobalVar._PDF_Book_Changed.title = TSelBookTitle.Text;
                        GlobalVar._PDF_Book_Changed.writer = TSelBookWriter.Text;



                        if (GlobalVar._PDF_Book_Bookshelf_Changed_Boolean == true)
                        {
                            //string[] Book_Shelf_Info;

                            //Book_Shelf_Info = comboBoxBookShelves.SelectedItem.ToString().Split('|');


                            //GlobalVar._PDF_Book_Bookshelf_new_ID = Book_Shelf_Info[0];

                            GlobalVar._PDF_Book_Bookshelf_new_ID = _PDF_Bookshelves[comboBoxBookShelves.SelectedItem.ToString()];

                            if (GlobalVar._PDF_Book_Bookshelf_old_ID == GlobalVar._PDF_Book_Bookshelf_new_ID)
                            {
                                GlobalVar._PDF_Book_Bookshelf_Changed_Boolean = false;
                            }
                            else
                            {
                                GlobalVar._PDF_Book_Bookshelf_Changed_Boolean = true;
                            }
                        }

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(Invalid_userinput,
                           "Information",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                  
                }

                else if (result == DialogResult.Cancel)
                {
                    //code for No
                }
        }

        private void bSelBookDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to delete this book from this bookshelf?" +
                " The original PDF file is of course not deleted from your computer", "Delete a book",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                //if (TSelBookWriter.Text.Length > 0 && TSelBookTitle.Text.Length > 0 && TSelBookSubject.Text.Length > 0)
                //{
                    GlobalVar._PDF_Book_Changed = new PDF_Book();
                    // Only the Book_ID is needed to delete a book:
                    GlobalVar._PDF_Book_Changed.Book_ID = _PDF_Book_Selected.Book_ID;
                    GlobalVar._PDF_Book_Changed.Book_Shelf_ID = _PDF_Book_Selected.Book_Shelf_ID;

                    GlobalVar._PDF_Book_Del_Boolean = true;

                    this.Close();
                //}
                //else
                //{
                //    MessageBox.Show("Please enter valid values");
                //}


            }

            else if (result == DialogResult.Cancel)
            {
                //code for No
            }
        }

        private void bOpenFolder_Click(object sender, EventArgs e)
        {
            string directory = Path.GetDirectoryName(_PDF_Book_Selected.filepath);

            try
            {
                System.Diagnostics.Process.Start(directory);
            }
            catch
            {
                MessageBox.Show("Directory not found");
            }

           // MessageBox.Show(directory);
        }

        private void cBChangeBookshelf_CheckedChanged(object sender, EventArgs e)
        {
            if (cBChangeBookshelf.Checked == true)
            {
                comboBoxBookShelves.Enabled = true;
                GlobalVar._PDF_Book_Bookshelf_Changed_Boolean = true;
            }
            else if (cBChangeBookshelf.Checked == false)
            {
                comboBoxBookShelves.Enabled = false;
                GlobalVar._PDF_Book_Bookshelf_Changed_Boolean = false;
            }
        }

        private void Validate_UserInput()
        {
            _writer_valid = false;
            _subject_valid = false;
            _title_valid = false;

            _description_valid = false;
            _tags_valid = false;
            

             if (TSelBookTitle.Text.Length > 0 && TSelBookTitle.Text.Length < 250)
            {
                if (GlobalVar.IsValidXmlString(TSelBookTitle.Text) == true)
                {
                    _title_valid = true;
                }
            }


            if (TSelBookWriter.Text.Length > 0 && TSelBookWriter.Text.Length < 250)
            {
                 if (GlobalVar.IsValidXmlString(TSelBookWriter.Text) == true)
                {
                    _writer_valid = true;
                }
            }

             if (TSelBookSubject.Text.Length > 0 && TSelBookSubject.Text.Length < 250)
            {
                if (GlobalVar.IsValidXmlString(TSelBookSubject.Text) == true)
                {
                    _subject_valid = true;
                }
            }


              if (TSelBookDescription.Text.Length > 0 && TSelBookDescription.Text.Length < 1000)
            {
                if (GlobalVar.IsValidXmlString(TSelBookDescription.Text) == true)
                {
                    _description_valid = true;
                }
            }

              if (TSelBookTags.Text.Length > 0 && TSelBookTags.Text.Length < 1000)
            {
                if (GlobalVar.IsValidXmlString(TSelBookTags.Text) == true)
                {
                    _tags_valid = true;
                }
            }
        }

        private void bSelBookTagsInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can enter search tags here so your book can be easily found. If you want to enter multiple search tags you have "
                + " to seperate them with a: , "
          , "Information",
           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
    }
}
