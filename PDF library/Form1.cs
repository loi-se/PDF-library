using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Imaging;

using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using GhostscriptSharp;

using Microsoft.Win32;
using System.Runtime.InteropServices;

using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;

using System.Text.RegularExpressions;


using System.Dynamic;
using iTextSharp.text.pdf.parser;
using Excel = Microsoft.Office.Interop.Excel;
using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Messages;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Lucene.Net.Support;
using Lucene.Net.Util;
using System.util;




namespace PDF_library
{

    public partial class Form1 : Form
    {
        // File path to a folder with pdf files:
        public string PDF_Book_Shelf_folderpath;

        // File path to the App user data folder:
        public string UserAppdatapath = Application.UserAppDataPath;

        public static string AppStartupPath = Application.StartupPath;

       // public string gsdll32_path = AppStartupPath + "gsdll32.dll";


        public SerializableDictionary<PDF_Book_Shelf, List<PDF_Book>> MY_PDF_library = new SerializableDictionary<PDF_Book_Shelf, List<PDF_Book>>();
        public PDF_Book_Shelf PDF_Book_Shelf;
        //public PDF_Book PDF_Book;
        public List<PDF_Book> PDF_Books_On_Shelf;

        public Dictionary<string, string> Helptext = new Dictionary<string, string>();
        public string LastOpenedFolder = "";
        //private int Book_location_X;
        //private int Book_location_Y; 
        //private int Bookheight; 
        //private int Bookwidth;

        //private int BookShelf_location_X;
        //private int BookShelf_location_Y; 
        //private int BookShelfheight;
        //private int BookShelfWidth;

        private string OpenedPDFLibraryPath = "";
        private int OpenedPDFLibraryPathLines = 0;

        public int NumberOfBooksInLibrary;

        private string Sel_BookShelf_ID = "";

        BackgroundWorker _BackgroundWorker;

        public string IndexFolderPath = "";


        private List<PDF_Book> _PDF_Books_SearchResult = new List<PDF_Book>();

        private Chart Chart1;
        private Chart_controller _ChartController;
        // Background-worker------------------------------------------------------------------------------------------------------------------

        //FORM load event: ---------------------------------------------------------------------------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
            //_BackgroundWorker = new BackgroundWorker();

            // Create a background worker thread that ReportsProgress &
            // SupportsCancellation
            // Hook up the appropriate events.
            //_BackgroundWorker.DoWork += new DoWorkEventHandler(_BackgorundWorker_DoWork);
            //_BackgroundWorker.ProgressChanged += new ProgressChangedEventHandler
            //        (_BackgorundWorker_ProgressChanged);
            //_BackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler
            //        (_BackgorundWorker_RunWorkerCompleted);
            //_BackgroundWorker.WorkerReportsProgress = true;
            //_BackgroundWorker.WorkerSupportsCancellation = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //loadingCircle1.Active = true;
            //GlobalVar.Bookheight = 190;
            //GlobalVar.Bookwidth = 130;
            //GlobalVar.BookShelfheight = 240;
            _ChartController = new Chart_controller();
            GlobalVar.BookShelfWidth = pBookShelf.Width;
            bFilterWriter.Height = 21;
            bFilterTags.Height = 21;

            //bSave.Enabled = true;
            pdfViewer1.ShowToolbar = true;
            pContextInfo.Visible = false;

            cBAdvancedSearch.Checked = false;
            pFilterView.Visible = false;

            createHelpTexts();
            bSearchOpenPDF.Height = 20;
            bSearch.Height = 20;

            comboBoxStatistics.SelectedIndex = 0;
            comboBoxStatistics.DropDownStyle = ComboBoxStyle.DropDownList;

            Ccharttype.SelectedIndex = 0;
            Ccharttype.DropDownStyle = ComboBoxStyle.DropDownList;
            Ccharttype.Enabled = false;
            bApplyCharttype.Enabled = false;
            //Test();
            tableLayoutPanelBookShelves.RowStyles[0].Height = pBookShelfInfo.Height;
            tableLayoutPanelBookShelves.RowStyles[1].Height = 0;
           // tableLayoutPanelBookShelves.RowStyles[1].Height = pBookShelfInfo.Height - GlobalVar.BookShelfheight - 300;
         
        }


        private void createHelpTexts()
        {
            Helptext.Add("BookShelf", "Here you can see your selected bookshelf." + "\r\n" +
                "\r\n" + "FUNCTIONS:"+ "\r\n" + "\r\n" +
                "OPEN A BOOK - Click on a book cover image to open the book. You can also open a book by clicking on a rowheader in the gridview" + "\r\n" +
                "READ A BOOK - Click on the button: 'Read' in the gridview to open a book in the PDF reader." + "\r\n" + 
                "SORT A BOOKSHELF - You can sort a bookshelf by clicking on the columnheaders of the gridview below the bookshelf."
                );


            Helptext.Add("BookShelf-view", "Here you can see all your created bookshelves." + "\r\n" +
                "\r\n" + "FUNCTIONS:"  + "\r\n" + "\r\n" +
                "CREATE A NEW BOOKSHELF - Click on the new bookshelf button to create a new bookshelf." + "\r\n" +
                "VIEW BOOKSHELF - Click on a row header to view all the books on the bookshelf."+ "\r\n" +
                "SORT THE BOOKSHELF VIEW - Click on a column header to sort the bookshelf view."+ "\r\n" +
                "SELECT ALL BOOKSHELVES - Click on the button select all bookshelves."+ "\r\n" +
                "DESELECT ALL BOOKSHELVES - Click on the button deselect all bookshelves."+ "\r\n" +
                "COPY A BOOKSHELF - Click on the button copy to copy the selected bookshelf (only one bookshelf can be selected)." + "\r\n" +
                "DELETE A BOOKSHELF - Click on the X Button of the bookshelf you want to delete." + "\r\n" +
                "ADD A BOOK TO A BOOKSHELF - Click on the ADD Button of the bookshelf you want to add a book to." + "\r\n" +
                "EDIT A BOOKSHELF - Click on the EDIT Button of the bookshelf you want to edit." + "\r\n" +
                "OPEN THE FOLDER OF A BOOKSHELF - Click on the OPEN Button of the bookshelf (if you didn't scan a folder for the bookshelf the folder can't be opened)."
           );



            Helptext.Add("help", "To view help information please press the 'show' context information button in the lower left corner." +
               " This way you can see context information about functionalities you are using that will further assist you.");


            Helptext.Add("about", "PDF library is a program for organizing your PDF files." +
                    "" + "\r\n\r\n" +
                    " Version: 3.2" + "\r\n\r\n" +
                    "Copyright© 2015  Roland Meijerink");

            Helptext.Add("NoSearchIndex", "You have not yet created a search index for this PDF library. To use the free text search function you first have to create a search index." +
                                " To do so go to: Options -> Search index - > Create Search Index.");

            Helptext.Add("fulltextsearch", "Check this option if you want to do a full-text search on all the PDF content in your library." +
                " To use the full-text search function you first have to create a search index." +
                                " To do so go to: Options -> Search index - > Create Search Index." + "\r\n" + "\r\n" +
                                "When the search-index is build you can perform extremely fast full-text PDF library content searches. The PDF files in the search result are automatically sorted on search relevance. " +
                                "So the PDF document where the search-text is found most is shown first."
                                );
           
        }



        // ----------------------------------------------------------------------------------------------------------------------------------------------------

        // TEST CODE!!-----------------------------------------------------------------------------------------------------------------------------------------

        // Show all the BookShelves in the Bookhelf tab:
        private void Test()
        {
            ArrayList _PDF_Books_Found = new ArrayList();

            //===================

            for (int i = 0; i < 50; i++)
            {
            PDF_Book_Shelf PDF_Book_Shelf_Empthy = new PDF_Book_Shelf();
            //List<PDF_Book> PDF_Books_On_Shelf_Empthy = new List<PDF_Book>();

            PDF_Book_Shelf_Empthy.folderpath = @"C:\Users\Rol\Documents\Books -Magazines\Popular science books";
            PDF_Book_Shelf_Empthy.name = "Name" + i.ToString();
            PDF_Book_Shelf_Empthy.creationdate = DateTime.Now;
            PDF_Book_Shelf_Empthy.subdirs = "false";
            PDF_Book_Shelf_Empthy.subject = "Name" + i.ToString();
            PDF_Book_Shelf_Empthy.search_terms = "-";
            PDF_Book_Shelf_Empthy.search_terms_active = "false";
            PDF_Book_Shelf_Empthy.Book_Shelf_ID = Guid.NewGuid().ToString();
            //PDF_Book_Shelf_Empthy.Book_Shelf_ID = DateTime.Now.ToString("yyyyMMddTHHmmss");
            PDF_Book_Shelf_Empthy.directory_scan = "false";

            PDF_Book_Shelf_Empthy.cover_imagefolderpath = System.IO.Path.Combine(UserAppdatapath, PDF_Book_Shelf_Empthy.name);
            if (System.IO.Directory.Exists(PDF_Book_Shelf_Empthy.cover_imagefolderpath))
            {
                PDF_Book_Shelf_Empthy.cover_imagefolderpath = System.IO.Path.Combine(UserAppdatapath, PDF_Book_Shelf_Empthy.name + DateTime.Now.ToString("yyyyMMddTHHmmss"));
            }
            System.IO.Directory.CreateDirectory(PDF_Book_Shelf_Empthy.cover_imagefolderpath);

            CreateBookShelf_Scan(PDF_Book_Shelf_Empthy.name, PDF_Book_Shelf_Empthy.folderpath, PDF_Book_Shelf_Empthy.subdirs, PDF_Book_Shelf_Empthy.subject, PDF_Book_Shelf_Empthy.search_terms, PDF_Book_Shelf_Empthy.search_terms_active, false, PDF_Book_Shelf_Empthy.Book_Shelf_ID); 
            //PDF_Book_Shelf_Empthy.number_of_books = PDF_Books_On_Shelf_Empthy.Count();
            //MY_PDF_library.Add(PDF_Book_Shelf_Empthy, PDF_Books_On_Shelf_Empthy);
            }

            // Add the PDF Book shelf and the arraylist with the books on a shelf to the Library dictionairy:
            //=============
            foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
            {
                    _PDF_Books_Found.Add(entry.Value);

            }
            Show_Book_shelf(_PDF_Books_Found, false);
        }





        // TEST CODE----------------------------------------------------------------------------------------------------------------------------------



        // Form menu strip------------------------------------------------------------------------------------------------------------------------------------------------------


        // Open a Library XML file
        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = UserAppdatapath;
            openFileDialog1.Filter = "XML Files|*.xml";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //DeleteItems();

                    //richTextBoxEx1.Text = "";
                    string XMLFilepath = openFileDialog1.FileName;
                    OpenedPDFLibraryPath = XMLFilepath;
                  
                    //string InputFile = XMLFilepath;
                    MY_PDF_library = new SerializableDictionary<PDF_Book_Shelf, List<PDF_Book>>();
                    XmlSerializer serializer = new XmlSerializer(MY_PDF_library.GetType());

                    using (StreamReader reader = new StreamReader(XMLFilepath))
                    {
                        MY_PDF_library = (SerializableDictionary<PDF_Book_Shelf, List<PDF_Book>>)serializer.Deserialize(reader);
                       //e = (entity)x.Deserialize(reader);
                        reader.Close();
                    }
                    tOpenedLibraryXML.Text = OpenedPDFLibraryPath;

                    pBookShelves.Controls.Clear();
                    pBookShelf.Controls.Clear();
                    pBookShelfBooks.Controls.Clear();
                    pAllBooks_Gridview.Controls.Clear();


                }
                catch (Exception e2)
                {
                    MessageBox.Show("An error occurred: '{0}':  " + e2);
                }

                showgridvieuw_Bookshelves();
                NumberOfBooksInLibrary = CountBooksInLibrary();

                string IndexFolderName = Path.GetFileName(OpenedPDFLibraryPath);
                IndexFolderName = IndexFolderName.Replace(".xml", "") + "index";

                IndexFolderPath = System.IO.Path.Combine(UserAppdatapath, IndexFolderName);
            }
        }


        // Save the library As XML file:
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MY_PDF_library.Count() > 0)
            {
                SavePDFLibraryAs();
            }
            else
            {
                MessageBox.Show("There are no books in your library yet. Saving is not possible");
            }
        }

        private void SavePDFLibraryAs()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = UserAppdatapath;
            saveFileDialog1.Filter = "xml files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;


            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {

                    XmlSerializer Serializer = new XmlSerializer(MY_PDF_library.GetType());

                    // Create a new file stream to write the serialized object to a file
                    TextWriter writer = new StreamWriter(saveFileDialog1.FileName.ToString().Replace(".xml", "") + ".xml");

                    OpenedPDFLibraryPath = saveFileDialog1.FileName.ToString().Replace(".xml", "") + ".xml";
                    Serializer.Serialize(writer, MY_PDF_library);

                    // Cleanup
                    writer.Close();
                    NumberOfBooksInLibrary = CountBooksInLibrary();


                    string IndexFolderName = Path.GetFileName(OpenedPDFLibraryPath);
                    IndexFolderName = IndexFolderName.Replace(".xml", "") + "index";


                    IndexFolderPath = System.IO.Path.Combine(UserAppdatapath, IndexFolderName);

                }

                catch (Exception e2)
                {
                    MessageBox.Show("An error occurred: '{0}':  " + e2);
                }
            }

        }


        // Save the Library as XML file:
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MY_PDF_library.Count() > 0)
            {
                SavePDFLibrary();
            }
            else
            {
                MessageBox.Show("There are no books in your library yet. Saving is not possible");
            }
        }

        // Save the library as XML File:
        private void SavePDFLibrary()
        {

            try
            {
                if (OpenedPDFLibraryPath.Length > 0)
                {
                    XmlSerializer Serializer = new XmlSerializer(MY_PDF_library.GetType());

                    // Create a new file stream to write the serialized object to a file
                    TextWriter writer = new StreamWriter(OpenedPDFLibraryPath.Replace(".xml", "") + ".xml");
                    Serializer.Serialize(writer, MY_PDF_library);


                    // Cleanup
                    writer.Close();
                    NumberOfBooksInLibrary = CountBooksInLibrary();
                }
                else
                {
                    SavePDFLibraryAs();
                }

            }

            catch (Exception e2)
            {
                MessageBox.Show("An error occurred: '{0}':  " + e2);
            }
        }

        // Create a new XML library:
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MY_PDF_library = new SerializableDictionary<PDF_Book_Shelf, List<PDF_Book>>();
            OpenedPDFLibraryPath = "";

            pBookShelves.Controls.Clear();
            pBookShelf.Controls.Clear();
            pBookShelfBooks.Controls.Clear();
            pAllBooks_Gridview.Controls.Clear();
            pBookInformation.Controls.Clear();

        }

        
        // Exit the application:
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Open the options screen:
        private void optionsToolStripMenuOptions_Click(object sender, EventArgs e)
        {
            PDF_Library_Options _PDF_Library_Options = new PDF_Library_Options();
            _PDF_Library_Options.ShowDialog();
        }


        // Create a Lucene search index
        private void createIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {


            DialogResult result = MessageBox.Show("Create an Index for this PDF Library (this index is needed to search in the content of the PDF files)?", "Lucene Index",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {


                if (OpenedPDFLibraryPath.Length > 1)
                {
                    string IndexFolderName = Path.GetFileName(OpenedPDFLibraryPath);
                    IndexFolderName = IndexFolderName.Replace(".xml", "") + "index";

                    IndexFolderPath = System.IO.Path.Combine(UserAppdatapath, IndexFolderName);
                    if (System.IO.Directory.Exists(IndexFolderPath))
                    {
                        //PDF_Book_Shelf.cover_imagefolderpath = System.IO.Path.Combine(UserAppdatapath, PDF_Book_Shelf.name + DateTime.Now.ToString("yyyyMMddTHHmmss"));
                    }
                    else
                    {
                        System.IO.Directory.CreateDirectory(IndexFolderPath);
                    }


                    string strIndexDir = IndexFolderPath;
                    Lucene.Net.Store.Directory indexDir = Lucene.Net.Store.FSDirectory.Open(new System.IO.DirectoryInfo(strIndexDir));
                    Analyzer std = new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29); //Version parameter is used for backward compatibility. Stop words can also be passed to avoid indexing certain words
                    IndexWriter idxw = new IndexWriter(indexDir, std, true, IndexWriter.MaxFieldLength.UNLIMITED); //Create an Index writer object.

                    foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                    {
                        // do something with entry.Value or entry.Key

                        foreach (PDF_Book _PDF_Book in entry.Value)
                        {


                            customProgressBar1.CustomText = "Building Search Index:  PDF file: " + _PDF_Book.filepath;
                            customProgressBar1.PerformStep();

                            try
                            {
                                Lucene.Net.Documents.Document doc = new Lucene.Net.Documents.Document();
                                Lucene.Net.Documents.Field fldPath = new Lucene.Net.Documents.Field("path", _PDF_Book.filepath, Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.YES);
                                doc.Add(fldPath);

                                Lucene.Net.Documents.Field fldbookid = new Lucene.Net.Documents.Field("bookid", _PDF_Book.Book_ID, Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.YES);
                                doc.Add(fldbookid);

                                string PDFtext = GetTextFromAllPages(_PDF_Book.filepath);
                                Lucene.Net.Documents.Field fldText = new Lucene.Net.Documents.Field("text", PDFtext, Lucene.Net.Documents.Field.Store.YES, Lucene.Net.Documents.Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.YES);
                                doc.Add(fldText);
                                //write the document to the index
                                idxw.AddDocument(doc);
                                //optimize and close the writer
                                idxw.Optimize();
                            }
                            catch
                            {

                            }
                        }
                    }


                    idxw.Close();

                    customProgressBar1.CustomText = "The search index is build and ready to use!";
                    customProgressBar1.PerformStep();
                }
                else
                {
                    MessageBox.Show("There are no PDF books in your library yet. Creating a search-index is not possible.");
                }

            }
            else if (result == DialogResult.Cancel)
            {
                //code for No
            }



        }


        public static string GetTextFromAllPages(String pdfPath)
        {
            PdfReader reader = new PdfReader(pdfPath);

            StringWriter output = new StringWriter();

            for (int i = 1; i <= reader.NumberOfPages; i++)
            {

                try
                {
                    output.WriteLine(PdfTextExtractor.GetTextFromPage(reader, i, new SimpleTextExtractionStrategy()));
                }
                catch
                {

                }
            }

            return output.ToString();
        }



        private void openSearchIndexFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Open Search index folder (don't delete or change files in this folder otherwise your search index doesn't work anymore)?", "Warning",
                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {

                if (System.IO.Directory.Exists(IndexFolderPath))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(IndexFolderPath);
                    }
                    catch
                    {
                        //MessageBox.Show("This Bookshelf does not have a directory path");
                    }
                }
                else
                {
                    MessageBox.Show(Helptext["NoSearchIndex"]);
                }
            }
            else if (result == DialogResult.Cancel)
            {
                //code for No
            }

        }


        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Helptext["help"], "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Helptext["about"], "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------


        // BookShelf Gridview-----------------------------------------------------------------------------------------------------------------------------------------------------

        private void toolStripButtonNewBookShelf_Click(object sender, EventArgs e)
        {
            New_PDF_Bookshelf _New_PDF_Bookshelf = new New_PDF_Bookshelf(this, null);
            _New_PDF_Bookshelf.Show();
        }

        private void tsBSelectAll_Click(object sender, EventArgs e)
        {
            if (pBookShelves.Controls.ContainsKey("Gridview_BookShelves"))
            {
                Control[] controls = pBookShelves.Controls.Find("Gridview_BookShelves", true);

                foreach (DataGridView c in controls)
                {
                    if (c.Name == "Gridview_BookShelves")
                    {
                        try
                        {

                            foreach (DataGridViewRow row in c.Rows)
                            {
                                if (row.Index <= c.Rows.Count - 1)
                                {

                                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)c.Rows[row.Index].Cells[0];

                                    c.BeginEdit(true);
                                    if (chk.Value == null || (int)chk.Value == 0)
                                    {
                                        chk.Value = 1;
                                    }
                                
                                    c.EndEdit();
                                }

                            }

                        }
                        catch
                        {
                        }
                    }
                }
            }


        }


        private void tSBDeselectAll_Click(object sender, EventArgs e)
        {
            if (pBookShelves.Controls.ContainsKey("Gridview_BookShelves"))
            {
                Control[] controls = pBookShelves.Controls.Find("Gridview_BookShelves", true);

                foreach (DataGridView c in controls)
                {
                    if (c.Name == "Gridview_BookShelves")
                    {
                        try
                        {

                            foreach (DataGridViewRow row in c.Rows)
                            {
                                if (row.Index <= c.Rows.Count - 1)
                                {

                                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)c.Rows[row.Index].Cells[0];

                                    c.BeginEdit(true);
                                    if ((int)chk.Value == 1)
                                    {
                                        chk.Value = 0;
                                    }

                                    c.EndEdit();
                                }

                            }

                        }
                        catch
                        {
                        }
                    }
                }
            }
        }


        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            int count_selected_bookshelves = 0;
            List<PDF_Book> _PDF_Books_On_Shelf_Copy = new List<PDF_Book>();
            PDF_Book_Shelf _PDF_Book_Shelf_Source = new PDF_Book_Shelf();
            //===================

            string _Book_Shelf_ID = "";

            if (pBookShelves.Controls.ContainsKey("Gridview_BookShelves"))
            {
                Control[] controls = pBookShelves.Controls.Find("Gridview_BookShelves", true);

                foreach (DataGridView c in controls)
                {
                    if (c.Name == "Gridview_BookShelves")
                    {
                        try
                        {
                          
                            foreach (DataGridViewRow row in c.Rows)
                            {
                                if (row.Index <= c.Rows.Count - 1)
                                {

                                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)c.Rows[row.Index].Cells[0];

                                    if (chk.Value == null || (int)chk.Value == 0)
                                    {

                                    }
                                    else
                                    {
                                        count_selected_bookshelves = count_selected_bookshelves + 1;
                                    }

                                }
                            }


                            if (count_selected_bookshelves == 1)
                            {
                                foreach (DataGridViewRow row in c.Rows)
                                {
                                    if (row.Index <= c.Rows.Count - 1)
                                     {

                                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)c.Rows[row.Index].Cells[0];

                                        if (chk.Value == null || (int)chk.Value == 0)
                                        {

                                        }
                                        else
                                        {
                                            _Book_Shelf_ID = c.Rows[row.Index].Cells[1].Value.ToString();
                                        }
                                    }
                                }  

                            }
                             else
                             {
                                   MessageBox.Show("Please select only one bookshelf");
                             }

                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.ToString());
                        }
                    }
                }
            }





            if (count_selected_bookshelves == 1)
            {

                foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                {
                    if (entry.Key.Book_Shelf_ID == _Book_Shelf_ID)
                    {

                        _PDF_Book_Shelf_Source = entry.Key;
                        _PDF_Books_On_Shelf_Copy = entry.Value;
                    }

                }


                PDF_Book_Shelf _Book_Shelf_Copy = new PDF_Book_Shelf();
                List<PDF_Book> _PDF_Books_Copy = new List<PDF_Book>();


                _Book_Shelf_Copy.Book_Shelf_ID = Guid.NewGuid().ToString();
               // _Book_Shelf_Copy.Book_Shelf_ID = DateTime.Now.ToString("yyyyMMddTHHmmss");


                //PDF_Book_Shelf.cover_imagefolderpath = System.IO.Path.Combine(UserAppdatapath, PDF_Book_Shelf.name);
                //if (Directory.Exists(PDF_Book_Shelf.cover_imagefolderpath))
                //{
                _Book_Shelf_Copy.cover_imagefolderpath = System.IO.Path.Combine(UserAppdatapath, _PDF_Book_Shelf_Source.name + _Book_Shelf_Copy.Book_Shelf_ID);
                //}
                System.IO.Directory.CreateDirectory(_Book_Shelf_Copy.cover_imagefolderpath);

                //foreach (var file in Directory.GetFiles(_PDF_Book_Shelf_Source.cover_imagefolderpath))
                //{
                //    File.Copy(file, Path.Combine(PDF_Book_Shelf.cover_imagefolderpath, Path.GetFileName(file)), true);
                //}


                //_Book_Shelf_Copy.cover_imagefolderpath = _PDF_Book_Shelf_Copy.cover_imagefolderpath;
                _Book_Shelf_Copy.creationdate = _PDF_Book_Shelf_Source.creationdate;
                _Book_Shelf_Copy.directory_scan = _PDF_Book_Shelf_Source.directory_scan;
                _Book_Shelf_Copy.folderpath = _PDF_Book_Shelf_Source.folderpath;
                _Book_Shelf_Copy.name = _PDF_Book_Shelf_Source.name + "copy";
                _Book_Shelf_Copy.number_of_books = _PDF_Book_Shelf_Source.number_of_books;
                _Book_Shelf_Copy.search_terms = _PDF_Book_Shelf_Source.search_terms;
                _Book_Shelf_Copy.search_terms_active = _PDF_Book_Shelf_Source.search_terms_active;
                _Book_Shelf_Copy.subdirs = _PDF_Book_Shelf_Source.subdirs;
                _Book_Shelf_Copy.subject = _PDF_Book_Shelf_Source.subject;


                int i = 0;
                foreach (PDF_Book _PDF_Book_Source in _PDF_Books_On_Shelf_Copy)
                {
                    PDF_Book _PDF_Book_Copy = new PDF_Book();

                    _PDF_Book_Copy.Book_Shelf_ID = _Book_Shelf_Copy.Book_Shelf_ID;
                    _PDF_Book_Copy.Book_ID = _Book_Shelf_Copy.Book_Shelf_ID + "-" + i.ToString();
                    _PDF_Book_Copy.filename = _PDF_Book_Source.filename;
                    _PDF_Book_Copy.cover_imagepath = _Book_Shelf_Copy.cover_imagefolderpath + "\\" + _PDF_Book_Copy.filename + ".Jpeg";
                    _PDF_Book_Copy.filepath = _PDF_Book_Source.filepath;

                    try
                    {
                        customProgressBar1.CustomText = "Copying in Progress :    Extracting Cover Image: " + _PDF_Book_Copy.filename;
                        customProgressBar1.PerformStep();
                        GhostscriptWrapper.GeneratePageThumb(_PDF_Book_Copy.filepath, _PDF_Book_Copy.cover_imagepath, 1, GlobalVar.Bookwidth / 3, GlobalVar.Bookheight / 3);
                    }
                    catch (Exception ex)
                    {
                        //_ErrorBooks.Add(pdfFile.FullName + "%" + ex.ToString());
                        //error = true;
                    }


                    _PDF_Book_Copy.description = _PDF_Book_Source.description;
                    _PDF_Book_Copy.filesize = _PDF_Book_Source.filesize;
                    _PDF_Book_Copy.number_of_pages = _PDF_Book_Source.number_of_pages;
                    _PDF_Book_Copy.PDF_version = _PDF_Book_Source.PDF_version;
                    _PDF_Book_Copy.publishdate = _PDF_Book_Source.publishdate;
                    _PDF_Book_Copy.rating = _PDF_Book_Source.rating;
                    _PDF_Book_Copy.subject = _PDF_Book_Source.subject;
                    _PDF_Book_Copy.tags = _PDF_Book_Source.tags;
                    _PDF_Book_Copy.title = _PDF_Book_Source.title;
                    _PDF_Book_Copy.writer = _PDF_Book_Source.writer;


                    _PDF_Books_Copy.Add(_PDF_Book_Copy);
                    i = i + 1;

                }

                MY_PDF_library.Add(_Book_Shelf_Copy, _PDF_Books_Copy);
                showgridvieuw_Bookshelves();

                customProgressBar1.CustomText = "Copying of bookshelf complete!";
                customProgressBar1.PerformStep();
            }
            

        }
                
        
     


        // Show the gridview with the meta information of each bookshelf:
        public void showgridvieuw_Bookshelves()
        {

            try
            {
                pBookShelves.Controls.Clear();
                DataGridView GView = new DataGridView();
                GView.Name = "Gridview_BookShelves";
                GView.BackgroundColor = Color.White;
                //GView.ScrollBars = ScrollBars.None;
                GView.ScrollBars = ScrollBars.Both;
                pBookShelves.AutoScroll = false;

                // 0 : index
                DataGridViewCheckBoxColumn newCol0_0 = new DataGridViewCheckBoxColumn();
                newCol0_0.HeaderText = "-";
               // newCol0_0.Daya = typeof(int);
                newCol0_0.Width = Convert.ToInt16(30);
                newCol0_0.Name = "Checkboxes";
                newCol0_0.ValueType = typeof(System.Int16);
                newCol0_0.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol0_0);


                // 0 : index
                DataGridViewColumn newCol0 = new DataGridViewTextBoxColumn();
                newCol0.HeaderText = "ID";
                newCol0.Width = Convert.ToInt16(50);
                newCol0.ValueType = typeof(System.Int16);
                newCol0.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol0);

                // 1: Bookshelf-name
                DataGridViewColumn newCol1 = new DataGridViewTextBoxColumn();
                newCol1.HeaderText = "Bookshelf name";
                newCol1.Width = Convert.ToInt16(100);
                newCol1.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol1);


        
                //2: Delete button:
                DataGridViewButtonColumn newCol1_1 = new DataGridViewButtonColumn();
                newCol1_1.Text = "X";
                newCol1_1.UseColumnTextForButtonValue = true;
                newCol1_1.HeaderText = "Del";
                newCol1_1.DefaultCellStyle.BackColor = Color.Red;
                newCol1_1.Width = Convert.ToInt16(30);
                newCol1_1.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol1_1);

                // 3: Re-scan button:
                DataGridViewButtonColumn newCol1_2 = new DataGridViewButtonColumn();
                newCol1_2.Text = "Edit";
                newCol1_2.UseColumnTextForButtonValue = true;
                newCol1_2.HeaderText = "Edit";
                newCol1_2.Width = Convert.ToInt16(55);
                newCol1_2.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol1_2);


                // 4: Add PDF Book:
                DataGridViewButtonColumn newCol1_3 = new DataGridViewButtonColumn();
                newCol1_3.Text = "Add";
                newCol1_3.UseColumnTextForButtonValue = true;
                newCol1_3.HeaderText = "Add";
                newCol1_3.Width = Convert.ToInt16(55);
                newCol1_3.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol1_3);

                // 5: Bookshelf-subject
                DataGridViewColumn newCol1_4 = new DataGridViewTextBoxColumn();
                newCol1_4.HeaderText = "Subject";
                newCol1_4.Width = Convert.ToInt16(80);
                newCol1_4.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol1_4);


                // 6: Number of books:
                DataGridViewColumn newCol2 = new DataGridViewTextBoxColumn();
                newCol2.HeaderText = "Number of books";
                newCol2.Width = Convert.ToInt16(100);
                newCol2.ValueType = typeof(System.Int16);
                newCol2.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol2);

                // 7: Creation date:
                DataGridViewColumn newCol3 = new DataGridViewTextBoxColumn();
                newCol3.HeaderText = "Creation date";
                newCol3.Width = Convert.ToInt16(100);
                newCol3.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol3);

                // 8: Folder Path open BUTTON:
                DataGridViewButtonColumn newCol6 = new DataGridViewButtonColumn();
                newCol6.Text = "Open";
                newCol6.UseColumnTextForButtonValue = true;
                newCol6.HeaderText = "Open";
                newCol6.Width = Convert.ToInt16(100);
                newCol6.ValueType = typeof(string);
                newCol6.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol6);

                // 9: Cover images Folder path open BUTTON:
                DataGridViewButtonColumn newCol7 = new DataGridViewButtonColumn();
                newCol7.Text = "Open";
                newCol7.UseColumnTextForButtonValue = true;
                newCol7.HeaderText = "Open Cover images folder";
                newCol7.Width = Convert.ToInt16(100);
                newCol7.ValueType = typeof(string);
                newCol7.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol7);

                //DataGridViewButtonCell bopenfolder1 = new DataGridViewButtonCell();
                //bopenfolder1.Value = "Open folder";

                int i = 0;

                foreach (var _PDF_Book_Shelf in MY_PDF_library.Keys)
                {
                    //PDF_Book_Shelf = new PDF_Book_Shelf();
                    DataGridViewRow row = (DataGridViewRow)GView.Rows[0].Clone();
                    row.Cells[1].Value = _PDF_Book_Shelf.Book_Shelf_ID;
                    row.Cells[2].Value = _PDF_Book_Shelf.name;

                    row.Cells[6].Value = _PDF_Book_Shelf.subject;
                    row.Cells[7].Value = _PDF_Book_Shelf.number_of_books;
                    row.Cells[8].Value = _PDF_Book_Shelf.creationdate;
                    row.Cells[9].ToolTipText = _PDF_Book_Shelf.folderpath;
                    row.Cells[10].ToolTipText = _PDF_Book_Shelf.cover_imagefolderpath;

                    row.Height = 50;
                    row.ReadOnly = true;
                    //DataGridViewButtonCell bopenfolder1 = new DataGridViewButtonCell();
                    //bopenfolder1.Value = "Open folder";

                    //row.Cells[6].Value = bopenfolder1;
                    GView.Rows.Add(row);

                    // _folderitem.FolderNode.FullPath;
                    i = i + 1;

                }

                GView.Width = pBookShelves.Width;
                GView.Height = pBookShelves.Height;

                GView.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(Bookshelves_rowheaderclick);
                GView.CellContentClick += new DataGridViewCellEventHandler(Bookshelves_Cellclick);
                GView.MouseHover += new System.EventHandler(Bookshelves_MouseHover);

                GView.AllowUserToAddRows = false;

                GView.PerformLayout();

                pBookShelves.Controls.Add(GView);

            }
            catch (Exception e2)
            {
                MessageBox.Show("An error occurred: '{0}':  " + e2);
            }
        }


        public void Bookshelves_MouseHover(object sender, EventArgs e)
        {
            tContextInfo.Text = "";
            tContextInfo.Text = Helptext["BookShelf-view"];
        }


        // When the row header of the Bookshelf gridview is clicked then the 
        // Images of the books on this bookshelf are loaded and showed:
        public void Bookshelves_rowheaderclick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int value = e.RowIndex;
            string cover_image_folderpath = "";
            string _bookshelfname = "";
            string _Book_Shelf_ID = "";

            if (pBookShelves.Controls.ContainsKey("Gridview_BookShelves"))
            {
                Control[] controls = pBookShelves.Controls.Find("Gridview_BookShelves", true);

                foreach (DataGridView c in controls)
                {
                    if (c.Name == "Gridview_BookShelves")
                    {
                        try
                        {
                            cover_image_folderpath = c.Rows[e.RowIndex].Cells[10].ToolTipText.ToString();
                            _bookshelfname = c.Rows[e.RowIndex].Cells[2].Value.ToString();
                            _Book_Shelf_ID = c.Rows[e.RowIndex].Cells[1].Value.ToString();

                            Sel_BookShelf_ID = c.Rows[e.RowIndex].Cells[1].Value.ToString();
                            // Show the book shelf:
                            pBookShelf.Controls.Clear();
                            pBookShelfBooks.Controls.Clear();

                            tableLayoutPanelBookShelves.RowStyles[1].Height = 30;
                            //List<PDF_Book> _PDF_Books_Found = new List<PDF_Book>();

                            ArrayList _PDF_Books_Found = new ArrayList();
                            // string 
                            List<PDF_Book> _PDF_Books_BookGridview = new List<PDF_Book>();

                            foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                            {
                                if (entry.Key.Book_Shelf_ID == _Book_Shelf_ID)
                                {
                                    _PDF_Books_Found.Add(entry.Value);

                                    foreach (PDF_Book _PDF_Book in entry.Value)
                                     {
                                      _PDF_Books_BookGridview.Add(_PDF_Book);
                                     }
                                }
                            }

                            
                         
                            Show_Book_shelf(_PDF_Books_Found, false);
                            ShowBookGridview(_PDF_Books_BookGridview, pBookShelfBooks, true);
                            // Select the Bookshelf tab:
                            TCMain.SelectedIndex = 0;
                        }
                        catch
                        {
                        }
                    }
                }

            }


        }

        // Show all the BookShelves in the Bookhelf tab:
        private void tSBShowAllBookshelves_Click(object sender, EventArgs e)
        {
            GC.Collect();
            int ShownBooks = 0;
            Boolean ShowBooks = true;
            Sel_BookShelf_ID = "";
            //tableLayoutPanelBookShelves.RowStyles[1].Height = 0;
            //tableLayoutPanelBookShelves.RowStyles[0].Height = pBookShelfInfo.Height;

            pBookShelf.Controls.Clear();

            ArrayList _PDF_Books_Found = new ArrayList();
            
            //===================
     
            string _Book_Shelf_ID = "";

            if (pBookShelves.Controls.ContainsKey("Gridview_BookShelves"))
            {
                Control[] controls = pBookShelves.Controls.Find("Gridview_BookShelves", true);

                foreach (DataGridView c in controls)
                {
                    if (c.Name == "Gridview_BookShelves")
                    {
                        try
                        {

                            foreach (DataGridViewRow row in c.Rows)
                            {
                                if (row.Index <= c.Rows.Count - 1)
                                {

                                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)c.Rows[row.Index].Cells[0];

                                    if (chk.Value == null || (int)chk.Value == 0)
                                    {
                                        chk.Value = 0;
                                    }
                                    else
                                    {
                                        chk.Value = 1;
                                    }

                                    if ((int)chk.Value == 1)
                                    {//if 
                                    _Book_Shelf_ID = c.Rows[row.Index].Cells[1].Value.ToString();

                                        foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                                        {
                                            if (entry.Key.Book_Shelf_ID == _Book_Shelf_ID)
                                            {

                                                ShownBooks = ShownBooks + entry.Key.number_of_books;
                                                if (ShownBooks <= GlobalVar.MaxBookTotal)
                                                {
                                                    _PDF_Books_Found.Add(entry.Value);
                                                }
                                                else
                                                {
                                                    ShowBooks = false;
                                                    MessageBox.Show("To much books are selected. The maximum amount of books that can be shown is: " + GlobalVar.MaxBookTotal.ToString() + 
                                                        ". Please deselect some bookshelves and try again.");
                                                    break;

                                                }
                                            }

                                        }
                                    }

                                }

                                
                            }

                        }
                        catch
                        {
                        }
                    }
                }

            }


            if (ShowBooks == true)
            {
            Show_Book_shelf(_PDF_Books_Found, true);
            }


        }

        private void toolStripButtonBookShelvesFullScreen_Click(object sender, EventArgs e)
        {
            //ShowFullScreen(pBookShelf);
        }

        // Show the bookShelf
        // Input: Arraylist consisting of: List<PDF_Book>
        public void Show_Book_shelf(ArrayList _PDF_Books_Found, Boolean AllBookShelves)
        {

            Boolean ErrorShowingBookShelfs = false;
            ArrayList Heigth_of_Each_BookShelf = new ArrayList();
            int i2 = 0;
            int Book_Shelf_Location_Y = 0;
            int PreviousBookShelfHeight = 0;

            GlobalVar.BookShelfWidth = pBookShelf.Width;

            foreach (List<PDF_Book> _PDF_Book_Shelf in _PDF_Books_Found)
            {
                List<PDF_Book> _PDF_Books = _PDF_Book_Shelf;
                int Book_Shelf_Height = 0;
                // Determine how many books have to be showed and if the bookshelfheight has to be adapted because of the horizontal scollbar:
                if (_PDF_Books.Count() * (GlobalVar.Bookwidth + GlobalVar.Book_offset) >= pBookShelf.Width)
                {
                    Book_Shelf_Height = GlobalVar.BookShelfheight + GlobalVar.BookShelf_HorizontalScrollbar_ExtraHeight;
                    //Book_Shelf_Location_Y = Book_Shelf_Location_Y + GlobalVar.BookShelf_HorizontalScrollbar_ExtraHeight;
                }
                else
                {
                    Book_Shelf_Height = GlobalVar.BookShelfheight;
                }

                Heigth_of_Each_BookShelf.Add(Book_Shelf_Height);
            }


            foreach (List<PDF_Book> _PDF_Book_Shelf in _PDF_Books_Found)
            {
                List<PDF_Book> _PDF_Books = _PDF_Book_Shelf;

                int Book_Location_X = GlobalVar.Book_location_X;
                int Book_Location_y = GlobalVar.Book_location_Y;

                int Footer_Location_X = GlobalVar.Footer_Location_X;
                int Footer_Location_y = GlobalVar.Book_location_Y + GlobalVar.Bookheight + 4; ;

                int Book_Shelf_Height = GlobalVar.BookShelfheight;

                int Book_Shelf_Location_X = 0;


                if (i2 == 0)
                {
                    Book_Shelf_Location_Y = 0;
                }
                else
                {
                    //Book_Shelf_Location_Y = i2 * (Book_Shelf_Location_Y + Book_Shelf_Height);
                    Book_Shelf_Location_Y = Book_Shelf_Location_Y + Convert.ToInt32(Heigth_of_Each_BookShelf[i2 - 1]);
                }



                // GlobalVar.Book_location_X = 10;
                // GlobalVar.Book_location_Y = 30;
                // GlobalVar.Book_offset = 20;
                //GlobalVar.BookShelf_location_X = X;
                //GlobalVar.BookShelf_location_Y = Y;
                //GlobalVar.BookShelfheight = 240;
                PB_Coverimage Bookcover_PB;
                PB_Coverimage Bookfooter_PB;

                System.Drawing.Image Bookcover_image = null;




                // Determine hpow many books have to be showed and if the book size have to be adapted to the horizontal scollbar
                Panel Bookshelf_Panel = new Panel();
                //Bookshelf_Panel.AllowDrop = true;
                Bookshelf_Panel.Width = GlobalVar.BookShelfWidth;
                Bookshelf_Panel.Height = Convert.ToInt32(Heigth_of_Each_BookShelf[i2]);
                Bookshelf_Panel.BackColor = GlobalVar.BookShelf_BackgroundColor;
                Bookshelf_Panel.BorderStyle = BorderStyle.FixedSingle;
                //Bookshelf_Panel.Dock = DockStyle.Top;

                //Bookshelf_Panel.BackgroundImage = Properties.Resources.Bookshelf;
                //Bookshelf_Panel.BackgroundImage = None;
                Bookshelf_Panel.BackgroundImageLayout = ImageLayout.Stretch;
                //Bookshelf_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                //    | System.Windows.Forms.AnchorStyles.Left)
                //    | System.Windows.Forms.AnchorStyles.Right)));

                Bookshelf_Panel.AutoScroll = true;
                Bookshelf_Panel.Location = new Point(Book_Shelf_Location_X, Book_Shelf_Location_Y);
                // Bookshelf_Panel.Dock = DockStyle.Top;


                //Bookshelf_Panel.DragOver += new DragEventHandler(Bookshelf_Panel_DragOver);
                //Bookshelf_Panel.DragDrop += new DragEventHandler(Bookshelf_Panel_DragDrop);  

                // Draw the bookshelf name on the background picture of the Panel:-----------------------
                //Graphics graphics = Graphics.FromImage(Bookshelf_Panel.BackgroundImage);
                //// Create the Font object for the image text drawing.
                //System.Drawing.Font font = new System.Drawing.Font("Arial", 10);

                //graphics.DrawString(_bookshelfname, font, Brushes.Black, 0, 0);
                //font.Dispose();
                //graphics.Flush();
                //graphics.Dispose();
                //------------------------------------------------------------------
                int i3 = 0;
                foreach (PDF_Book _PDF_Book in _PDF_Books)
                {


                    if (System.IO.File.Exists(_PDF_Book.cover_imagepath))
                    {
                        //    MessageBox.Show("No Image");
                        //}
                        //else
                        //{

                        Bookcover_PB = new PB_Coverimage();

                        FileStream fs = null;
                        try
                        {
                            fs = new FileStream(_PDF_Book.cover_imagepath, FileMode.Open, FileAccess.Read);
                            Bookcover_image = System.Drawing.Image.FromStream(fs);
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.ToString());
                            ErrorShowingBookShelfs = true;
                            break;
                        }

                        finally
                        {
                            fs.Close();

                        }

                        Bookcover_PB._PDF_Book = _PDF_Book;


                        //Bookcover_image = System.Drawing.Image.FromFile(pdfcover_image.FullName);

                        // Add Pictureboxes for each Book:
                        Bookcover_PB.BackgroundImage = Bookcover_image;
                        //Bookcover_PB._PDF_Book = 
                        //Bookcover_image.Dispose();

                        Bookcover_PB.Height = GlobalVar.Bookheight;
                        Bookcover_PB.Width = GlobalVar.Bookwidth;

                        //Bookcover_PB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        //    ))));

                        Bookcover_PB.BackgroundImageLayout = ImageLayout.Stretch;
                        Bookcover_PB.MouseClick += new MouseEventHandler(PDF_Book_mouseclick);
                        Bookcover_PB.MouseHover += new EventHandler(PDF_Book_mousehover);
                        //Bookcover_PB.MouseDown += new MouseEventHandler(PDF_Book_mousedown); 

                        if (i3 > 0)
                        {
                            Book_Location_X = Book_Location_X + GlobalVar.Bookwidth + GlobalVar.Book_offset;
                        }
                        else
                        {
                            Book_Location_X = GlobalVar.Book_location_X;
                        }
                        Bookcover_PB.Location = new Point(Book_Location_X, Book_Location_y);

                        Bookshelf_Panel.Controls.Add(Bookcover_PB);
                        //Bookcover_PB.Dispose();

                        //System.IO.File.Delete(IMAGE_TEMP_LOCATION);
                        //Bookcover_image.Dispose();
                        //Picture1.Image = 
                        //}

                        //**************************************************************** Footer Image:

                        Bookfooter_PB = new PB_Coverimage();
                        Bookfooter_PB.Width = GlobalVar.FooterWidth;
                        Bookfooter_PB.Height = GlobalVar.FooterHeight;


                        string[] bookid = _PDF_Book.Book_ID.Split('-');

                        string _title = _PDF_Book.title;

                        if (_title == "-")
                        {
                            _title = _PDF_Book.filename;
                        }
                        else
                        {
                        }

                        int BookNumber = i3 + 1;
                        System.Drawing.Image bmp = new Bitmap(Bookfooter_PB.Width, Bookfooter_PB.Height);
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                           // System.Drawing.Font font = new System.Drawing.Font("Comic", GlobalVar.FooterFontSize, FontStyle.Regular);
                            System.Drawing.Font font = new System.Drawing.Font("Verdana", GlobalVar.FooterFontSize, FontStyle.Regular);
                           // System.Drawing.Font font = new System.Drawing.Font("Segoe UI", GlobalVar.FooterFontSize, FontStyle.Regular);
                            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                           // System.Drawing.Font font = new System.Drawing.Font("Batang", GlobalVar.FooterFontSize, FontStyle.Regular);
                            //System.Drawing.Font font = new System.Drawing.Font("Arial Black", GlobalVar.FooterFontSize, FontStyle.Regular);
                            //System.Drawing.Font font = new System.Drawing.Font("Book Antiqua", GlobalVar.FooterFontSize, FontStyle.Regular);
                            //System.Drawing.Font font = new System.Drawing.Font("Andalus", GlobalVar.FooterFontSize, FontStyle.Regular);
                            //g.DrawString(bookid[bookid.Count() - 1] + ". " + _title, font, Brushes.Black, new System.Drawing.Rectangle(0, 0, Bookfooter_PB.Width, Bookfooter_PB.Height));// draw in bmp using g
                            g.DrawString(BookNumber.ToString() + ". " + _title, font, Brushes.Black, new System.Drawing.Rectangle(0, 0, Bookfooter_PB.Width, Bookfooter_PB.Height));// draw in bmp using g
                        }

                        if (i3 > 0)
                        {
                            Footer_Location_X = Footer_Location_X + GlobalVar.Bookwidth + GlobalVar.Book_offset;
                        }
                        else
                        {
                            Footer_Location_X = GlobalVar.Footer_Location_X;
                        }
                        Bookfooter_PB.Location = new Point(Footer_Location_X, Footer_Location_y);
                        //Graphics graphics = Graphics.FromImage(Bookfooter_PB.BackgroundImage);
                        //// Create the Font object for the image text drawing.
                        
                        //font.Dispose();
                        //graphics.Flush();
                        //graphics.Dispose();
                        Bookfooter_PB.BackgroundImage = bmp;
                        Bookfooter_PB.BorderStyle = BorderStyle.None;
                        Bookshelf_Panel.Controls.Add(Bookfooter_PB);
                        //********************************************** Footer


                        i3 = i3 + 1;
                    }
                    else
                    {
                    }


                    //}
                   // tableLayoutPanelBookShelves.RowStyles[1].Height = pBookShelfInfo.Height - (Bookshelf_Panel.Height + GlobalVar.BookShelfheight);

                    


                    pBookShelf.Controls.Add(Bookshelf_Panel);
                    //Bookcover_image.Dispose();
                }

                if (AllBookShelves == true)
                {
                    tableLayoutPanelBookShelves.RowStyles[0].Height = pBookShelfInfo.Height;
                    tableLayoutPanelBookShelves.RowStyles[1].Height = 0;
                    pBookShelf.AutoScroll = true;
                }
                else if (AllBookShelves == false)
                {
                    tableLayoutPanelBookShelves.RowStyles[1].Height = pBookShelfInfo.Height - (Bookshelf_Panel.Height + 10);
                    tableLayoutPanelBookShelves.RowStyles[0].Height = Bookshelf_Panel.Height + 10;
                    pBookShelf.AutoScroll = false;
                }

                i2 = i2 + 1;
            }


            if (ErrorShowingBookShelfs == true)
            {
                MessageBox.Show("Not all books on the selected bookshelves can be shown because of an out of memory exception." +
                    " Please deselect some bookshelves and try again!");

            }
        }

        // Boohshelf gridview cell button events:
        private void Bookshelves_Cellclick(object sender, DataGridViewCellEventArgs e)
        {
            //var senderGrid = (DataGridView)sender;
            String folderpath;
            //// Open folder:
            // if (e.ColumnIndex == 7 && e.RowIndex >= 0)

            // Open the folder where the original PDF files of this Bookshelf are situated: 


            if (e.ColumnIndex == 0)
            {
                if (pBookShelves.Controls.ContainsKey("Gridview_BookShelves"))
                {
                    Control[] controls = pBookShelves.Controls.Find("Gridview_BookShelves", true);

                    foreach (DataGridView c in controls)
                    {
                        if (c.Name == "Gridview_BookShelves")
                        {
                            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)c.Rows[e.RowIndex].Cells[0];
                            c.BeginEdit(true);

                            if (chk.Value == null || (int)chk.Value == 0)
                            {
                                chk.Value = 1;
                            }
                            else
                            {
                                chk.Value = 0;
                            }
                            c.EndEdit();
                        }
                    }
                }
            }



            if (e.ColumnIndex == 9)
            {


                    if (pBookShelves.Controls.ContainsKey("Gridview_BookShelves"))
                    {
                        Control[] controls = pBookShelves.Controls.Find("Gridview_BookShelves", true);

                        foreach (DataGridView c in controls)
                        {
                            if (c.Name == "Gridview_BookShelves")
                            {
                                folderpath = c.Rows[e.RowIndex].Cells[9].ToolTipText.ToString();
                                if (folderpath.Length > 0)
                                {

                                    DialogResult result = MessageBox.Show("Open PDF folder: " + folderpath + " ?", "Warning",
                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                    if (result == DialogResult.OK)
                                    {
                                        try
                                        {
                                            System.Diagnostics.Process.Start(folderpath);
                                        }
                                        catch
                                        {
                                            MessageBox.Show("This Bookshelf does not have a directory path");
                                        }
                                    }
                                    else if (result == DialogResult.Cancel)
                                    {
                                        //code for No
                                    }
                                }
                            
                                // c.Series["file extensions"].ChartType = SeriesChartType.Bar;
                            }
                        }
                    }


                    // FindNode_byTreeviewPath(treeView.Nodes, treeviewpath);
               

            }

            // Open the folder with the cover images of this bookshelf:
            else if (e.ColumnIndex == 10)
            {
               
                    if (pBookShelves.Controls.ContainsKey("Gridview_BookShelves"))
                    {
                        Control[] controls = pBookShelves.Controls.Find("Gridview_BookShelves", true);

                        foreach (DataGridView c in controls)
                        {
                            if (c.Name == "Gridview_BookShelves")
                            {
                                folderpath = c.Rows[e.RowIndex].Cells[10].ToolTipText.ToString();
                                if (folderpath.Length > 0)
                                {
                                    DialogResult result = MessageBox.Show("Open Cover images folder: " + folderpath + " ?", "Warning",
                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                    if (result == DialogResult.OK)
                                    {
                                    try
                                    {
                                        System.Diagnostics.Process.Start(folderpath);
                                    }
                                    catch (Exception Ex)
                                    {
                                            MessageBox.Show(Ex.ToString());
                                    }
                                    }
                                    else if (result == DialogResult.Cancel)
                                    {
                                        //code for No
                                    }
                                }
                                // c.Series["file extensions"].ChartType = SeriesChartType.Bar;
                            }
                        }
                    }


                    // FindNode_byTreeviewPath(treeView.Nodes, treeviewpath);
                

            }

            // Delete the bookshelf:!
            else if (e.ColumnIndex == 3)
            {


                DialogResult result = MessageBox.Show("Are you sure you want to delete this BookShelf from your library? " +
                    "(The original PDF files are of course not deleted from your computer) ", "Warning",
                  MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {

                    if (pBookShelves.Controls.ContainsKey("Gridview_BookShelves"))
                    {
                        Control[] controls = pBookShelves.Controls.Find("Gridview_BookShelves", true);

                        foreach (DataGridView c in controls)
                        {
                            if (c.Name == "Gridview_BookShelves")
                            {

                                PDF_Book_Shelf _PDF_Book_Shelf = new PDF_Book_Shelf();
                                string Coverimagesfolderpath = c.Rows[e.RowIndex].Cells[10].ToolTipText.ToString();

                                foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                                {
                                    if (entry.Key.Book_Shelf_ID == c.Rows[e.RowIndex].Cells[1].Value.ToString())
                                    {
                                        _PDF_Book_Shelf = entry.Key;
                                        //MY_PDF_library.Remove(entry.Key);


                                    }
                                }

                                MY_PDF_library.Remove(_PDF_Book_Shelf);

                                //Delete the folder with the cover images in the app user data folder

                                try
                                {
                                    System.IO.Directory.Delete(Coverimagesfolderpath, true);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }

                                // c.Series["file extensions"].ChartType = SeriesChartType.Bar;
                            }
                        }
                    }

                    showgridvieuw_Bookshelves();
                    // FindNode_byTreeviewPath(treeView.Nodes, treeviewpath);
                }
                else if (result == DialogResult.Cancel)
                {
                    //code for No
                }

            }

            // Edit the bookshelf:!
            else if (e.ColumnIndex == 4)
            {

                //SerializableDictionary<PDF_Book_Shelf, List<PDF_Book>> OneItem_MY_PDF_library = new SerializableDictionary<PDF_Book_Shelf, List<PDF_Book>>();
                PDF_Book_Shelf _PDF_Book_Shelf = new PDF_Book_Shelf();
                //string Coverimagesfolderpath = c.Rows[e.RowIndex].Cells[7].ToolTipText.ToString();

                GlobalVar.Alreadyscanned_Books.Clear();
                //DialogResult result = MessageBox.Show("Are you sure you want to rescan the bookshelf? (Rescanning means that books that you have" +
                //" recently added to this bookshelf folder are  incorporated in your Bookshelf", "Warning",
                //  MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                //if (result == DialogResult.OK)
                //{

                    if (pBookShelves.Controls.ContainsKey("Gridview_BookShelves"))
                    {
                        Control[] controls = pBookShelves.Controls.Find("Gridview_BookShelves", true);

                        foreach (DataGridView c in controls)
                        {
                            if (c.Name == "Gridview_BookShelves")
                            {
                                //ScanBookShelfFolder(tBookShelfName.Text, PDF_Book_Shelf_folderpath);
                                foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                                {
                                    try
                                    {
                                        if (entry.Key.Book_Shelf_ID == c.Rows[e.RowIndex].Cells[1].Value.ToString())
                                        {
                                            _PDF_Book_Shelf = entry.Key;

                                            foreach (PDF_Book _PDF_Book in entry.Value)
                                            {
                                                // do something with entry.Value or entry.Key
                                                GlobalVar.Alreadyscanned_Books.Add(_PDF_Book);
                                            }
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }

                                New_PDF_Bookshelf _New_PDF_Bookshelf = new New_PDF_Bookshelf(this, _PDF_Book_Shelf);
                                _New_PDF_Bookshelf.Show();
                                _New_PDF_Bookshelf.TopMost = true;


                            }
                        }
                    }
                    //-------------------
                  
            }

            // Add one PDF Book to the library:
            else if (e.ColumnIndex == 5)
            {

                //SerializableDictionary<PDF_Book_Shelf, List<PDF_Book>> OneItem_MY_PDF_library = new SerializableDictionary<PDF_Book_Shelf, List<PDF_Book>>();
                PDF_Book_Shelf _PDF_Book_Shelf = new PDF_Book_Shelf();
                //string Coverimagesfolderpath = c.Rows[e.RowIndex].Cells[7].ToolTipText.ToString();


                DialogResult result = MessageBox.Show("Add a new PDF book to this bookshelf?", "Warning",
                  MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {

                if (pBookShelves.Controls.ContainsKey("Gridview_BookShelves"))
                {
                    Control[] controls = pBookShelves.Controls.Find("Gridview_BookShelves", true);

                    foreach (DataGridView c in controls)
                    {
                        if (c.Name == "Gridview_BookShelves")
                        {
                            //ScanBookShelfFolder(tBookShelfName.Text, PDF_Book_Shelf_folderpath);

                            OpenFileDialog openFileDialog1 = new OpenFileDialog();

                            if (LastOpenedFolder.Length > 0)
                            {
                                openFileDialog1.InitialDirectory = LastOpenedFolder;
                            }
                            else
                            {
                                openFileDialog1.InitialDirectory = UserAppdatapath;
                            }
                                openFileDialog1.Filter = "Pdf Files|*.pdf";

                            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    //DeleteItems();
                                    string Book_Shelf_ID = c.Rows[e.RowIndex].Cells[1].Value.ToString();
                                    //richTextBoxEx1.Text = "";
                                    string PDFfilepath = openFileDialog1.FileName;

                                    string PDFfilename = System.IO.Path.GetFileName(openFileDialog1.FileName);
                                    LastOpenedFolder = openFileDialog1.FileName;


                                    AddPDFBook_To_BookShelf(Book_Shelf_ID, PDFfilename, PDFfilepath);

                                }
                                catch (Exception e2)
                                {
                                    MessageBox.Show("An error occurred: '{0}':  " + e2);
                                }

                               // showgridvieuw_Bookshelves();
                            }
                        }
                    }
                }
                }
                else if (result == DialogResult.Cancel)
                {
                    //code for No
                }
             
            }

        }

        // -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Add 1 book to the bookshelf
        public void AddPDFBook_To_BookShelf(string _Book_Shelf_ID, string PDFfilename, string PDFfilepath)
        {
            PdfReader pdfReader;
            PDF_Book PDF_Book_Add = new PDF_Book();
            Boolean error = false;

            //DirectoryInfo ourdir;
            //FileInfo[] pdfFilePath = null;

            List<PDF_Book> _PDF_Books_On_Shelf_Add = new List<PDF_Book>();
            PDF_Book_Shelf _PDF_Book_Shelf_Add = new PDF_Book_Shelf();

            int i = 0;
            foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
            {
                //if (entry.Key.name == c.Rows[e.RowIndex].Cells[1].Value.ToString())
                //{
                if (_Book_Shelf_ID == entry.Key.Book_Shelf_ID)
                {
                    _PDF_Books_On_Shelf_Add = entry.Value;
                    _PDF_Book_Shelf_Add = entry.Key;
                }
            }
            MY_PDF_library.Remove(_PDF_Book_Shelf_Add);

            // Add the new book---------------
            string PDF_version;
            string writer;
            string title;

            FileInfo info = new FileInfo(PDFfilepath);

            // Now convert to a string in megabytes.
           


            PDF_Book_Add.title = "-";
            PDF_Book_Add.writer = "-";
            PDF_Book_Add.number_of_pages = 0;
            PDF_Book_Add.PDF_version = "-";
            PDF_Book_Add.cover_imagepath = "-";
            //PDF_Book_Add.filepath = "-";
            //PDF_Book_Add.filename = "-";
            PDF_Book_Add.description = "-";
            PDF_Book_Add.tags = "-";
            PDF_Book_Add.publishdate = new DateTime(2014, 5, 1);
           // PDF_Book_Add.publishdate = Convert.ToDateTime("01/08/2010");
            PDF_Book_Add.subject = "-";
            PDF_Book_Add.rating = 1;
            PDF_Book_Add.filesize = ConvertBytesToMegabytes(info.Length).ToString("0.00") + " MB";

            int BookID = DetermindeBookID(_PDF_Books_On_Shelf_Add);
            string BookIDstring = BookID.ToString();

            PDF_Book_Add.Book_ID = _Book_Shelf_ID + "-" + BookIDstring;


            PDF_Book_Add.filepath = PDFfilepath;
            PDF_Book_Add.filename = PDFfilename;
            PDF_Book_Add.Book_Shelf_ID = _Book_Shelf_ID;
            PDF_Book_Add.cover_imagepath = _PDF_Book_Shelf_Add.cover_imagefolderpath + "\\" + PDFfilename + ".Jpeg";
            try
            {
                pdfReader = new PdfReader(PDFfilepath);


                PDF_Book_Add.number_of_pages = pdfReader.NumberOfPages;

                PDF_version = pdfReader.PdfVersion.ToString();
                try
                {
                    writer = pdfReader.Info["Author"];

                    if (!string.IsNullOrWhiteSpace(writer))
                    {
                        if (GlobalVar.IsValidXmlString(writer) == true)
                        {
                            PDF_Book_Add.writer = writer;
                        }
                    }
                }
                catch
                {
                }

                try
                {
                    title = pdfReader.Info["Title"];

                    if (!string.IsNullOrWhiteSpace(title))
                    {
                        if (GlobalVar.IsValidXmlString(title) == true)
                        {
                            PDF_Book_Add.title = title;
                        }
                    }
                }
                catch
                {

                }

                //MessageBox.Show(pdfReader.Info["Subject"]);


                if (!string.IsNullOrWhiteSpace(PDF_version))
                {
                    if (GlobalVar.IsValidXmlString(PDF_version) == true)
                    {
                        PDF_Book_Add.PDF_version = pdfReader.PdfVersion.ToString();
                    }
                    // ...
                }
                
              
                pdfReader.Close();
            }
            catch (Exception Ex)
            {
                error = true;
                MessageBox.Show(Ex.ToString());
               
            }

            // Use The Ghostwrapper library to generate an image of the cover of each PDF file:
            try
            {
                GhostscriptWrapper.GeneratePageThumb(PDF_Book_Add.filepath, PDF_Book_Add.cover_imagepath, 1, GlobalVar.Bookwidth / 3, GlobalVar.Bookheight / 3);
            }
            catch
            {
                error = true;
            }

            // Add the PDF book to the Arraylist:

            if (PDF_Book_Add.title.Length > 0 && PDF_Book_Add.writer.Length > 0 && PDF_Book_Add.filename.Length > 0 && PDF_Book_Add.filepath.Length > 0 &&
                PDF_Book_Add.number_of_pages > 0 && PDF_Book_Add.PDF_version.Length > 0 && PDF_Book_Add.cover_imagepath.Length > 0 && error == false)
            {

                if (_PDF_Books_On_Shelf_Add.Count <= GlobalVar.MaxBookshelfBooks)
                {
                    _PDF_Books_On_Shelf_Add.Add(PDF_Book_Add);

                    _PDF_Book_Shelf_Add.number_of_books = _PDF_Books_On_Shelf_Add.Count();
                    MY_PDF_library.Add(_PDF_Book_Shelf_Add, _PDF_Books_On_Shelf_Add);
                    Show_Selected_PDF_Book(PDF_Book_Add, "OK");
                }
                else
                {
                    MessageBox.Show("No more then " + GlobalVar.MaxBookshelfBooks.ToString() + " books are allowed on a bookshelf. Please create a new bookshelf and add the book" +
                     " there.");
                }
                //_PDF_Books_On_Shelf_Del.RemoveAt(_PDF_Book_index_Del);
               
            }
            else if (error == true)
            {

                _PDF_Book_Shelf_Add.number_of_books = _PDF_Books_On_Shelf_Add.Count();
                MY_PDF_library.Add(_PDF_Book_Shelf_Add, _PDF_Books_On_Shelf_Add);
                MessageBox.Show("This PDF file could not be added");
            }



            showgridvieuw_Bookshelves();

          }

        // -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //Context information----------------------------------------------------------------------------------------------------------------------------------

        private void toolStripButtonHide_Click(object sender, EventArgs e)
        {
            pContextInfo.Visible = false;
        }

        private void toolStripButtonShow_Click(object sender, EventArgs e)
        {
            pContextInfo.Visible = true;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------


        // Add Bookshelf Menu--------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Re-Scan a bookshelf folder (create an image of each book in the folder path and put the new key value pair in the dictionairy):
        public void CreateBookShelf_Rescan(PDF_Book_Shelf _PDF_Bookshelf, List<PDF_Book> _AlreadyScannedBooks, Boolean _ReScan)
        {

            if (_ReScan == true)
            {
                // First remove the bookshelf:
                PDF_Book_Shelf _PDF_Book_Shelf_Del = new PDF_Book_Shelf();
                foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                {
                    if (entry.Key.Book_Shelf_ID == _PDF_Bookshelf.Book_Shelf_ID)
                    {
                        _PDF_Book_Shelf_Del = entry.Key;
                        //MY_PDF_library.Remove(entry.Key);
                    }
                }
                MY_PDF_library.Remove(_PDF_Book_Shelf_Del);



                CreateBookShelf_Scan(_PDF_Bookshelf.name, _PDF_Bookshelf.folderpath, _PDF_Bookshelf.subdirs, _PDF_Bookshelf.subject, _PDF_Bookshelf.search_terms, _PDF_Bookshelf.search_terms_active, _ReScan, _PDF_Bookshelf.Book_Shelf_ID);

            }
            else if (_ReScan == false)
            {

                PDF_Book_Shelf _PDF_Book_Shelf_Del = new PDF_Book_Shelf();
                foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                {
                    if (entry.Key.Book_Shelf_ID == _PDF_Bookshelf.Book_Shelf_ID)
                    {
                        _PDF_Book_Shelf_Del = entry.Key;
                        //MY_PDF_library.Remove(entry.Key);


                    }
                }
                MY_PDF_library.Remove(_PDF_Book_Shelf_Del);
                //_PDF_Bookshelf.Book_Shelf_ID = _PDF_Bookshelf.Book_Shelf_ID;

                MY_PDF_library.Add(_PDF_Bookshelf, _AlreadyScannedBooks);

            

            }

            GlobalVar.Alreadyscanned_Books = new List<PDF_Book>();
            SavePDFLibrary();
            showgridvieuw_Bookshelves();
        }

        // Check if a string has no invalid characters in it that XML can't handle:
        public static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        // Scan a bookshelf folder (create an image of each book in the folder path and put the new key value pair in the dictionairy):
        public void CreateBookShelf_Scan(string Bookshelfname, string ChoosenFolderPath, string _subdirs, string _Bookshelfsubject, string SearchTerms, string SearchTermsActive, Boolean Rescan, string BookShelf_ID)
        {

            //_BackgroundWorker.RunWorkerAsync();
            Boolean error = false;
            List<string> _AddedBooks = new List<string>();
            List<string> _ErrorBooks = new List<string>();

            customProgressBar1.DisplayStyle = ProgressBarDisplayText.CustomText;
            customProgressBar1.ForeColor = customProgressBar1.BackColor;
            customProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;

            //customProgressBar1.CustomText = "Scanning directory: " + ChoosenFolderPath;
            //customProgressBar1.PerformStep();

            string[] _SearchTerms = SearchTerms.Split(',');
            ArrayList _SearchTermFound_PDF_Page1 = new ArrayList();
            ArrayList _SearchTermFound_PDF_Filename = new ArrayList();

            PdfReader pdfReader;
            PDF_Book PDF_Book;

            PDF_Book_Shelf = new PDF_Book_Shelf();
            PDF_Books_On_Shelf = new List<PDF_Book>();

            DirectoryInfo ourdir;
            FileInfo[] pdfFilePath = null;

            PDF_Book_Shelf.folderpath = ChoosenFolderPath;
            PDF_Book_Shelf.name = Bookshelfname;
            PDF_Book_Shelf.creationdate = DateTime.Now;
            PDF_Book_Shelf.subdirs = _subdirs;
            PDF_Book_Shelf.subject = _Bookshelfsubject;
            PDF_Book_Shelf.search_terms = SearchTerms;
            PDF_Book_Shelf.search_terms_active = SearchTermsActive;
            PDF_Book_Shelf.directory_scan = "true";

            //-----------------
            if (Rescan == true)
            {
                PDF_Book_Shelf.Book_Shelf_ID = BookShelf_ID;
            }
            else if (Rescan == false)
            {
                PDF_Book_Shelf.Book_Shelf_ID = Guid.NewGuid().ToString();

                //PDF_Book_Shelf.Book_Shelf_ID = DateTime.Now.ToString("yyyyMMddTHHmmss");
            }

             
            //if (MY_PDF_library.Count() == 0)
            //{
            //    PDF_Book_Shelf.Book_Shelf_ID = 1;
            //}
            //else if (MY_PDF_library.Count() > 0)
            //{
            //    PDF_Book_Shelf.Book_Shelf_ID = MY_PDF_library.Count() + 1;
            //}
            //---------------------

            ourdir = new DirectoryInfo(PDF_Book_Shelf.folderpath);

            if (_subdirs == "true")
            {
                pdfFilePath = ourdir.GetFiles("*.pdf", SearchOption.AllDirectories);
            }
            else if (_subdirs == "false")
            {
                pdfFilePath = ourdir.GetFiles("*.pdf", SearchOption.TopDirectoryOnly);
            }

            // If there are PDF files found:
            if (pdfFilePath.Count() > 0)
            {
                // Progress bar:
               // statusStripScan.Text = "Start";
                //progressBarMain.Value = 0;
                //progressBarMain.Maximum = pdfFilePath.Count();
                //progressBarMain.Step = (progressBarMain.Maximum / pdfFilePath.Count());

                
             

                PDF_Book_Shelf.cover_imagefolderpath = System.IO.Path.Combine(UserAppdatapath, PDF_Book_Shelf.name);
                if (System.IO.Directory.Exists(PDF_Book_Shelf.cover_imagefolderpath))
                {
                    PDF_Book_Shelf.cover_imagefolderpath = System.IO.Path.Combine(UserAppdatapath, PDF_Book_Shelf.name + DateTime.Now.ToString("yyyyMMddTHHmmss"));
                }
                System.IO.Directory.CreateDirectory(PDF_Book_Shelf.cover_imagefolderpath);

                int i = 0;
                // Scan each PDF file in the folder:

                if ((pdfFilePath.Count() < GlobalVar.MaxBookshelfBooks) || (pdfFilePath.Count() > GlobalVar.MaxBookshelfBooks && SearchTermsActive == "true"))
                {
                    foreach (FileInfo pdfFile in pdfFilePath)
                    {
                        //if (pdfFile.Name.Contains(_Bookshelfsubject))
                        //{
                        error = false;

                        _SearchTermFound_PDF_Filename.Clear();
                        _SearchTermFound_PDF_Page1.Clear();

                        customProgressBar1.CustomText = "Scan in progress :     PDF information scan: " + pdfFile.Name;
                        customProgressBar1.PerformStep();
                        //PDF_Book = new PDF_Book();
                        //lScannedFolderpath.Text = pdfFile.FullName;

                        if (SearchTermsActive == "true")
                        {

                            // Get the text of the first two pages of the PDF file:
                            if (GlobalVar.Scan_PDFpages == true)
                            {

                                StringBuilder PDF_FirstPage_Text = new StringBuilder();
                                String PDF_FP_Search_Text = "";
                                try
                                {
                                    pdfReader = new PdfReader(pdfFile.FullName);

                                    using (pdfReader)
                                    {
                                        //StringBuilder sb = new StringBuilder();

                                        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                                        for (int page = 0; page < 2; page++)
                                        {
                                            string text = PdfTextExtractor.GetTextFromPage(pdfReader, page + 1, strategy);
                                            if (!string.IsNullOrWhiteSpace(text))
                                                PDF_FirstPage_Text.Append(Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(text))));
                                        }

                                        //  Debug.WriteLine(sb.ToString());
                                    }
                                    pdfReader.Close();
                                }
                                catch
                                {
                                }


                                // Check if one of the search terms is found in the first page of the PDF file:
                                PDF_FP_Search_Text = PDF_FirstPage_Text.ToString();

                                foreach (string s in _SearchTerms)
                                {
                                    Boolean _BoolSearchTermFound;
                                    Regex rx = new Regex(s, RegexOptions.IgnoreCase);
                                    // Check text on the first page:
                                    if (rx.IsMatch(PDF_FP_Search_Text))
                                    {
                                        _BoolSearchTermFound = true;
                                    }
                                    else
                                    {
                                        _BoolSearchTermFound = false;
                                    }

                                    _SearchTermFound_PDF_Page1.Add(_BoolSearchTermFound);
                                }

                            }

                            // Check if the search term is found in the PDF File name:
                            if (GlobalVar.Scan_PDFfilename == true)
                            {

                                foreach (string s in _SearchTerms)
                                {
                                    Boolean _BoolSearchTermFound;
                                    Regex rx = new Regex(s, RegexOptions.IgnoreCase);
                                    // Check text on the first page:
                                    if (rx.IsMatch(pdfFile.Name))
                                    {
                                        _BoolSearchTermFound = true;
                                    }
                                    else
                                    {
                                        _BoolSearchTermFound = false;
                                    }

                                    _SearchTermFound_PDF_Filename.Add(_BoolSearchTermFound);
                                }
                            }

                            //else if (GlobalVar.Scan_PDFfilename == false && GlobalVar.Scan_PDFpages == false)
                            //{
                            //    _SearchTermFound_PDF_Page1.Add(true);
                            //    _SearchTermFound_PDF_Filename.Add(true);
                            //}

                        }

                        else if (SearchTermsActive == "false")
                        {
                            _SearchTermFound_PDF_Page1.Add(true);
                            _SearchTermFound_PDF_Filename.Add(true);

                        }


                        // If a search term is found in the document first page or file name:
                        if (_SearchTermFound_PDF_Page1.Contains(true) || _SearchTermFound_PDF_Filename.Contains(true))
                        {

                            string PDF_version;
                            string writer;
                            string title;

                            PDF_Book = new PDF_Book();
                            PDF_Book.title = "-";
                            PDF_Book.writer = "-";
                            PDF_Book.number_of_pages = 0;
                            PDF_Book.PDF_version = "-";
                            PDF_Book.cover_imagepath = "-";
                            PDF_Book.filepath = "-";
                            PDF_Book.filename = "-";
                            PDF_Book.description = "-";
                            PDF_Book.tags = _Bookshelfsubject;
                            //PDF_Book.publishdate = Convert.ToDateTime("01/08/2010");
                            PDF_Book.publishdate = new DateTime(2014, 5, 1);
                            PDF_Book.subject = _Bookshelfsubject;
                            PDF_Book.rating = 1;
                            PDF_Book.Book_ID = Convert.ToString(PDF_Book_Shelf.Book_Shelf_ID) + "-" + i.ToString();

                            PDF_Book.filesize = ConvertBytesToMegabytes(pdfFile.Length).ToString("0.00") + " MB";


                            PDF_Book.filepath = pdfFile.FullName;
                            PDF_Book.filename = pdfFile.Name;
                            PDF_Book.Book_Shelf_ID = PDF_Book_Shelf.Book_Shelf_ID;
                            PDF_Book.cover_imagepath = PDF_Book_Shelf.cover_imagefolderpath + "\\" + pdfFile.Name + ".Jpeg";
                            try
                            {
                                pdfReader = new PdfReader(pdfFile.FullName);


                                PDF_Book.number_of_pages = pdfReader.NumberOfPages;

                                PDF_version = pdfReader.PdfVersion.ToString();
                                writer = pdfReader.Info["Author"];
                                title = pdfReader.Info["Title"];

                                //MessageBox.Show(pdfReader.Info["Subject"]);


                                if (!string.IsNullOrWhiteSpace(PDF_version))
                                {
                                    if (GlobalVar.IsValidXmlString(PDF_version) == true)
                                    {
                                        PDF_Book.PDF_version = pdfReader.PdfVersion.ToString();
                                    }
                                    // ...
                                }
                                if (!string.IsNullOrWhiteSpace(writer))
                                {
                                    if (GlobalVar.IsValidXmlString(writer) == true)
                                    {
                                        PDF_Book.writer = writer;
                                    }
                                }
                                if (!string.IsNullOrWhiteSpace(title))
                                {
                                    if (GlobalVar.IsValidXmlString(title) == true)
                                    {
                                        PDF_Book.title = title;
                                    }
                                }
                                pdfReader.Close();
                            }
                            catch (Exception ex)
                            {
                                //_ErrorBooks.Add(pdfFile.Name + "%" + ex.ToString());
                                // error = false;
                            }


                            //string subjecttt = pdfReader.Info["Subject"];
                            //MessageBox.Show(subjecttt);



                            //PDF_Book.subject = pdfReader.Info["Subject"];


                            // Use The Ghostwrapper library to generate an image of the cover of each PDF file:
                            try
                            {
                                customProgressBar1.CustomText = "Scan in progress :    Extracting Cover Image: " + pdfFile.Name;
                                customProgressBar1.PerformStep();
                                GhostscriptWrapper.GeneratePageThumb(PDF_Book.filepath, PDF_Book.cover_imagepath, 1, GlobalVar.Bookwidth / 3, GlobalVar.Bookheight / 3);
                            }
                            catch (Exception ex)
                            {
                                _ErrorBooks.Add(pdfFile.FullName + "%" + ex.ToString());
                                error = true;
                            }

                            // Add the PDF book to the Arraylist:

                            if (PDF_Book.title.Length > 0 && PDF_Book.writer.Length > 0 && PDF_Book.filename.Length > 0 && PDF_Book.filepath.Length > 0 &&
                                PDF_Book.number_of_pages > 0 && PDF_Book.PDF_version.Length > 0 && PDF_Book.cover_imagepath.Length > 0 && error == false)
                            {
                                if (PDF_Books_On_Shelf.Count <= GlobalVar.MaxBookshelfBooks)
                                {
                                    _AddedBooks.Add(pdfFile.FullName);
                                    PDF_Books_On_Shelf.Add(PDF_Book);
                                }
                                else
                                {
                                    _ErrorBooks.Add(pdfFile.FullName + "%" + "No more then " + GlobalVar.MaxBookshelfBooks.ToString() + " books are allowed on a bookshelf. This book could not be added to this bookshelf");
                                }
                            }
                            i = i + 1;

                            //customProgressBar1.CustomText = "Extractin Cover image: " + pdfFile.Name;
                            //customProgressBar1.PerformStep();
                            //progressBarMain.PerformStep();
                            //statusStripScan.Text = pdfFile.FullName;

                        }

                    }


                PDF_Book_Shelf.number_of_books = PDF_Books_On_Shelf.Count();
  
                // Add the PDF Book shelf and the arraylist with the books on a shelf to the Library dictionairy:
                MY_PDF_library.Add(PDF_Book_Shelf, PDF_Books_On_Shelf);


                // Show the Bookshelf Gridview (Upper left corner):
                showgridvieuw_Bookshelves();


                var frm = Application.OpenForms.Cast<Form>().Where(x => x.Name == "New_PDF_Bookshelf").FirstOrDefault();
                if (null != frm)
                {
                    frm.Close();
                    frm = null;
                }

                Scanned_Books _ScannedBook = new Scanned_Books(_AddedBooks, _ErrorBooks, pdfFilePath.Count());
                _ScannedBook.ShowDialog(this);
                _ScannedBook.TopMost = true;

                customProgressBar1.CustomText = "Scan of directory: " + ChoosenFolderPath + " is complete!";
                customProgressBar1.PerformStep();

                }
                else
                {
                    MessageBox.Show(" More then " + GlobalVar.MaxBookshelfBooks.ToString() + " pdf files are found in this directory path. " +
                        "This path can't be scanned entirely (no more then " + GlobalVar.MaxBookshelfBooks.ToString() + " books are allowed on each shelf)." +
                        " You can do one of the following things to prevent this problem: " +
                         Environment.NewLine + Environment.NewLine +
                          " - Scan a subfolder of this directory with less PDF files in it." + Environment.NewLine +
                          " - Use a search term so only books relevant to the search term are scanned." + Environment.NewLine +
                          " - Divide the PDF files in this directory path in multiple sub folders in Windows." + Environment.NewLine +
                          " - Make different bookshelves for different sub categories of the pdf files in this directory and add them manually"

                          );

               
                }

              

                //tChoosenFolderPath.Text = "";
                //tBookShelfName.Text = "";

                //loadingCircle.Visible = false;
                //loadingCircle.Active = false;\
                //_BackgroundWorker.CancelAsync();
                //lScannedFolderpath.Text = "Scan of folder:" + ChoosenFolderPath + " is complete";
            }
            else
            {
                MessageBox.Show("No PDF files were found in this folderpath");
            }
        }


        // Create an Empthy BookShelf (the user can later add his own books):
        public void CreateBookShelf_Empthy(string Bookshelfname, string _Bookshelfsubject)
        {
            //PDF_Book PDF_Book;
            PDF_Book_Shelf PDF_Book_Shelf_Empthy = new PDF_Book_Shelf();
            List<PDF_Book> PDF_Books_On_Shelf_Empthy = new List<PDF_Book>();

            PDF_Book_Shelf_Empthy.folderpath = "-";
            PDF_Book_Shelf_Empthy.name = Bookshelfname;
            PDF_Book_Shelf_Empthy.creationdate = DateTime.Now;
            PDF_Book_Shelf_Empthy.subdirs = "false";
            PDF_Book_Shelf_Empthy.subject = _Bookshelfsubject;
            PDF_Book_Shelf_Empthy.search_terms = "-";
            PDF_Book_Shelf_Empthy.search_terms_active = "false";
            PDF_Book_Shelf_Empthy.Book_Shelf_ID = Guid.NewGuid().ToString();
            //PDF_Book_Shelf_Empthy.Book_Shelf_ID = DateTime.Now.ToString("yyyyMMddTHHmmss");
            PDF_Book_Shelf_Empthy.directory_scan = "false";

            PDF_Book_Shelf_Empthy.cover_imagefolderpath = System.IO.Path.Combine(UserAppdatapath, PDF_Book_Shelf_Empthy.name);
            if (System.IO.Directory.Exists(PDF_Book_Shelf_Empthy.cover_imagefolderpath))
            {
                PDF_Book_Shelf_Empthy.cover_imagefolderpath = System.IO.Path.Combine(UserAppdatapath, PDF_Book_Shelf_Empthy.name + DateTime.Now.ToString("yyyyMMddTHHmmss"));
            }
            System.IO.Directory.CreateDirectory(PDF_Book_Shelf_Empthy.cover_imagefolderpath);


            PDF_Book_Shelf_Empthy.number_of_books = PDF_Books_On_Shelf_Empthy.Count();

                // Add the PDF Book shelf and the arraylist with the books on a shelf to the Library dictionairy:
            MY_PDF_library.Add(PDF_Book_Shelf_Empthy, PDF_Books_On_Shelf_Empthy);
            showgridvieuw_Bookshelves();
        }




        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Main tab menu ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Tab index changed event:
        private void TCMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TCMain.SelectedIndex == 0)
            {
               // tContextInfo.Text = Helptext["agenda-view"];
            }

            if (TCMain.SelectedIndex == 1)
            {
                //List<PDF_Book> _PDF_Books_Found = new List<PDF_Book>();

                NumberOfBooksInLibrary = CountBooksInLibrary();

                //ShowAllBooks(_PDF_Books_Found);
                lAllBooksCountResult.Text = NumberOfBooksInLibrary.ToString();
            }
        }


        public int CountBooksInLibrary()
        {
            int i = 0;
            foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
            {
                foreach (PDF_Book _PDF_Book in entry.Value)
                {
                    i = i + 1;
                    //_PDF_Books_Found.Add(_PDF_Book);
                }
            }

            return i;

        }




        // TAB: BookShelves: -----------------------------------------------------------------------------------------------------------------

        private void RefreshBookShelf()
        {
            ArrayList _PDF_Books_Found = new ArrayList();
            // string 
            List<PDF_Book> _PDF_Books_BookGridview = new List<PDF_Book>();

            foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
            {
                if (entry.Key.Book_Shelf_ID == Sel_BookShelf_ID)
                {
                    _PDF_Books_Found.Add(entry.Value);

                    foreach (PDF_Book _PDF_Book in entry.Value)
                    {
                        _PDF_Books_BookGridview.Add(_PDF_Book);
                    }
                }
            }


            pBookShelf.Controls.Clear();
            Show_Book_shelf(_PDF_Books_Found, false);

            pBookShelfBooks.Controls.Clear();
            ShowBookGridview(_PDF_Books_BookGridview, pBookShelfBooks, true);
            // Select the Bookshelf tab:
            TCMain.SelectedIndex = 0;
        }


        // Show the selected book to the user:
        public void PDF_Book_mouseclick(object sender, EventArgs e)
        {
            GlobalVar._PDF_Book_Changed_Boolean = false;
            GlobalVar._PDF_Book_Read_Boolean = false;

            PDF_Book _PDF_Book = new PDF_Book();
            PB_Coverimage _PB_Coverimage = new PB_Coverimage();
            _PB_Coverimage = (PB_Coverimage)sender;
            //_PB_Coverimage.BorderStyle = BorderStyle.Fixed3D;

            // Each Picturebox has a field with the book that is selected: 
            _PDF_Book = _PB_Coverimage._PDF_Book;

            Show_Selected_PDF_Book(_PDF_Book, "Cancel");

        }


        public void Change_PDF_Book()
        {

            // Change the selected book:
            if (GlobalVar._PDF_Book_Changed_Boolean == true)
            {
                //PDF_Book _PDF_Book_Change = new PDF_Book();
                List<PDF_Book> _PDF_Books_On_Shelf_Change = new List<PDF_Book>();
                PDF_Book_Shelf _PDF_Book_Shelf_Change = new PDF_Book_Shelf();
                int _PDF_Book_index_Change = 0;

                int i = 0;
                foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                {
                    //if (entry.Key.name == c.Rows[e.RowIndex].Cells[1].Value.ToString())
                    //{
                    if (GlobalVar._PDF_Book_Changed.Book_Shelf_ID == entry.Key.Book_Shelf_ID)
                    {

                        _PDF_Books_On_Shelf_Change = entry.Value;
                        i = 0;
                        foreach (PDF_Book _PDF_Book_1 in _PDF_Books_On_Shelf_Change)
                        {

                            if (_PDF_Book_1.Book_ID == GlobalVar._PDF_Book_Changed.Book_ID)
                            {
                                _PDF_Book_Shelf_Change = entry.Key;
                                _PDF_Book_index_Change = i;
                            }
                            // do something with entry.Value or entry.Key
                            // Alreadyscanned_Books.Add(_PDF_Book);
                            i = i + 1;
                        }
                    }

                    //}
                }

                MY_PDF_library[_PDF_Book_Shelf_Change][_PDF_Book_index_Change] = GlobalVar._PDF_Book_Changed;
               


                if (GlobalVar._PDF_Book_Bookshelf_Changed_Boolean == true)
                {

                    // Delete the book from the old bookshelf:

                    Delete_PDF_Book_Sel();




                    // Add the book to the new bookshelf:

                    List<PDF_Book> _PDF_Books_On_Shelf_Add = new List<PDF_Book>();
                    PDF_Book_Shelf _PDF_BookShelf_New = new PDF_Book_Shelf();

                    //int i = 0;
                    foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                    {
                        //if (entry.Key.name == c.Rows[e.RowIndex].Cells[1].Value.ToString())
                        //{
                        if (GlobalVar._PDF_Book_Bookshelf_new_ID == entry.Key.Book_Shelf_ID)
                        {
                            _PDF_Books_On_Shelf_Add = entry.Value;
                            _PDF_BookShelf_New = entry.Key;
                        }
                    }
                 

                    GlobalVar._PDF_Book_Changed.Book_Shelf_ID = GlobalVar._PDF_Book_Bookshelf_new_ID;
                    int BookID = DetermindeBookID(_PDF_Books_On_Shelf_Add);
                    string BookIDstring = BookID.ToString();
                    GlobalVar._PDF_Book_Changed.Book_ID = GlobalVar._PDF_Book_Bookshelf_new_ID + "-" + BookIDstring;

                    string newCoverImagePath = _PDF_BookShelf_New.cover_imagefolderpath + @"\" + Path.GetFileName(GlobalVar._PDF_Book_Bookshelf_old_coverimagepath);
                    string oldCoverImagePath = GlobalVar._PDF_Book_Bookshelf_old_coverimagepath;
                    GlobalVar._PDF_Book_Changed.cover_imagepath = newCoverImagePath;
                    //GlobalVar._PDF_Book_Changed.cover_imagepath

                    if (File.Exists(oldCoverImagePath))
                    {
                        try
                        {
                            File.Move(oldCoverImagePath, newCoverImagePath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }

                    // Move the file.
                 


                     MY_PDF_library.Remove(_PDF_BookShelf_New);


                    _PDF_Books_On_Shelf_Add.Add(GlobalVar._PDF_Book_Changed);

                    _PDF_BookShelf_New.number_of_books = _PDF_Books_On_Shelf_Add.Count();

                    MY_PDF_library.Add(_PDF_BookShelf_New, _PDF_Books_On_Shelf_Add);

                 

                }

                GlobalVar._PDF_Book_Bookshelf_Changed_Boolean = false;
                GlobalVar._PDF_Book_Bookshelf_new_ID = "";
                GlobalVar._PDF_Book_Bookshelf_old_ID = "";
                GlobalVar._PDF_Book_Bookshelf_old_coverimagepath = "";

                GlobalVar._PDF_Book_Changed_Boolean = false;
                GlobalVar._PDF_Book_Changed = null;

                // _PDF_Books_SearchResult.Clear();
                showgridvieuw_Bookshelves();

                if (Sel_BookShelf_ID.Length > 1)
                {
                    RefreshBookShelf();
                }


                SavePDFLibrary();
                //MessageBox.Show("after edited ");
            }


            // Read the selected Book:
            if (GlobalVar._PDF_Book_Read_Boolean == true)
            {
                try
                {

                    pdfViewer1.Document = PdfiumViewer.PdfDocument.Load(GlobalVar._PDF_Book_Read_Filepath);
                    pViewerSearchresults.Controls.Clear();
                    TCMain.SelectedIndex = 2;
                    showOpenedBookInfo(GlobalVar._PDF_Book_Opened);
                    pdfViewer1.ShowToolbar = true;
                    GlobalVar._PDF_Book_Read_Filepath = "";
                    GlobalVar._PDF_Book_Read_Boolean = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }


            // Delete the selected Book:
            if (GlobalVar._PDF_Book_Del_Boolean == true)
            {

                Delete_PDF_Book_Sel();
                //MY_PDF_library[_PDF_Book_Shelf_Change][_PDF_Book_index_Change] = GlobalVar._PDF_Book_Changed;
                GlobalVar._PDF_Book_Changed_Boolean = false;

                GlobalVar._PDF_Book_Del_Boolean = false;
                GlobalVar._PDF_Book_Changed = null;
                //_PDF_Books_SearchResult.Clear();
                showgridvieuw_Bookshelves();

                if (Sel_BookShelf_ID.Length > 1)
                {
                    RefreshBookShelf();
                }

                SavePDFLibrary();
            }


        }

        // Find the maximum bookID in a collection of Books:
        public int DetermindeBookID(List<PDF_Book> _PDF_Books_On_Shelf_Add)
        {
            int MaxBookID = 0;
            int BookID = 0;
            ArrayList AllBookID = new ArrayList();

            int i = 0;
            foreach (PDF_Book _PDF_Book in _PDF_Books_On_Shelf_Add)
            {
                string[] bookid = _PDF_Book.Book_ID.Split('-');
                BookID = Convert.ToInt32(bookid[bookid.Count() - 1]);
                AllBookID.Add(BookID);
                i = i + 1; 
            }
            //int[] Array;
           
            //AllBookID.ToArray();

            MaxBookID = getMax(AllBookID) + 1;

                //array.Max() + 1;
            return MaxBookID;
        }


        private int getMax(ArrayList myArray)
        {
            int iMax = 0;
            foreach (int a in myArray)
            {
                if (a > iMax)
                {
                    iMax = a;
                }
            }
            return iMax;
        }

        // Delete a PDF book from a bookshelf!:
        public void Delete_PDF_Book_Sel()
        {
            List<PDF_Book> _PDF_Books_On_Shelf_Del = new List<PDF_Book>();
            PDF_Book_Shelf _PDF_Book_Shelf_Del = new PDF_Book_Shelf();
            //int _PDF_Book_index_Del = 0;
            PDF_Book _PDF_Book_index_Del = new PDF_Book();

            int i = 0;
            foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
            {
                //if (entry.Key.name == c.Rows[e.RowIndex].Cells[1].Value.ToString())
                //{
                if (GlobalVar._PDF_Book_Changed.Book_Shelf_ID == entry.Key.Book_Shelf_ID)
                {

                    _PDF_Books_On_Shelf_Del = entry.Value;
                    _PDF_Book_Shelf_Del = entry.Key;

                    i = 0;
                    foreach (PDF_Book _PDF_Book_1 in _PDF_Books_On_Shelf_Del)
                    {

                        if (_PDF_Book_1.Book_ID == GlobalVar._PDF_Book_Changed.Book_ID)
                        {
                            _PDF_Book_index_Del = _PDF_Book_1;
                            //_PDF_Book_index_Del = i;
                        }
                        i = i + 1;
                    }
                }

                //}
            }
            MY_PDF_library.Remove(_PDF_Book_Shelf_Del);
            _PDF_Books_On_Shelf_Del.Remove(_PDF_Book_index_Del);
            //_PDF_Books_On_Shelf_Del.RemoveAt(_PDF_Book_index_Del);
            _PDF_Book_Shelf_Del.number_of_books = _PDF_Books_On_Shelf_Del.Count();
            MY_PDF_library.Add(_PDF_Book_Shelf_Del, _PDF_Books_On_Shelf_Del);
            //MY_PDF_library[
        }



        //Show file name of PDF file when the mouse moves over the picturebox:
        public void PDF_Book_mousehover(object sender, EventArgs e)
        {
            PDF_Book _PDF_Book = new PDF_Book();
            PB_Coverimage _PB_Coverimage = new PB_Coverimage();
            _PB_Coverimage = (PB_Coverimage)sender;
            //_PB_Coverimage.BorderStyle = BorderStyle.Fixed3D;

            _PDF_Book = _PB_Coverimage._PDF_Book;


            Label labeltext = new Label();

            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.IsBalloon = true;
            //ToolTip1.ToolTipIcon = new NotifyIcon();

            try
            {
                ToolTip1.SetToolTip(labeltext, _PDF_Book.filename.ToString());

                ToolTip1.Show(_PDF_Book.filename, _PB_Coverimage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void AllBooks_Gridview_rowheaderclick_BookShelf(object sender, DataGridViewCellMouseEventArgs e)
        {
            PDF_Book _PDF_Book = new PDF_Book();
           // int value = e.RowIndex;

            if (pBookShelfBooks.Controls.ContainsKey("Gridview_AllBooks"))
            {
                Control[] controls = pBookShelfBooks.Controls.Find("Gridview_AllBooks", true);

                foreach (DataGridView c in controls)
                {
                    if (c.Name == "Gridview_AllBooks")
                    {
                        try
                        {
                            _PDF_Book = (PDF_Book)c.Rows[e.RowIndex].Tag;
                        }
                        catch
                        {
                        }
                    }
                }

                Show_Selected_PDF_Book(_PDF_Book, "Cancel");
            }
        }

        public void AllBooks_Gridview_columnheaderclick_BookShelf(object sender, DataGridViewCellMouseEventArgs e)
        {
            //MessageBox.Show("hi");

            //int value = e.RowIndex;

            List<PDF_Book> _PDF_Books_BookGridview = new List<PDF_Book>();
            ArrayList _PDF_Books_Found = new ArrayList();

            if (pBookShelfBooks.Controls.ContainsKey("Gridview_AllBooks"))
            {
                Control[] controls = pBookShelfBooks.Controls.Find("Gridview_AllBooks", true);

                foreach (DataGridView c in controls)
                {
                    if (c.Name == "Gridview_AllBooks")
                    {
                        foreach (DataGridViewRow row in c.Rows)
                        {
                            if (row.Index <= c.Rows.Count - 1)
                            {
                                _PDF_Books_BookGridview.Add((PDF_Book)row.Tag);
                            }
                        }

                    }
                }

                _PDF_Books_Found.Add(_PDF_Books_BookGridview);
                pBookShelf.Controls.Clear();
                Show_Book_shelf(_PDF_Books_Found, false);
                //Show_Selected_PDF_Book(_PDF_Book);
            }
        }

        private void AllBooks_Gridview_openfolderclick_BookShelf(object sender, DataGridViewCellEventArgs e)
        {
            //var senderGrid = (DataGridView)sender;
            String folderpath;
            PDF_Book _PDF_Book = new PDF_Book();
            //// Open folder:
            // if (e.ColumnIndex == 7 && e.RowIndex >= 0)

            // Open the folder where the original PDF files of this Bookshelf are situated: 
            if (e.ColumnIndex == 2)
            {

                if (pBookShelfBooks.Controls.ContainsKey("Gridview_AllBooks"))
                {
                    Control[] controls = pBookShelfBooks.Controls.Find("Gridview_AllBooks", true);

                    foreach (DataGridView c in controls)
                    {
                        if (c.Name == "Gridview_AllBooks")
                        {

                            try
                            {
                                string filename = c.Rows[e.RowIndex].Cells[10].Value.ToString();

                                DialogResult result = MessageBox.Show("Read the PDF book: " + filename + " ?", "Warning",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                if (result == DialogResult.OK)
                                {
                                    folderpath = c.Rows[e.RowIndex].Cells[12].Value.ToString();
                                    _PDF_Book = (PDF_Book)c.Rows[e.RowIndex].Tag;
                                    //webBrowser.Navigate(folderpath);
                                    //webBrowser.Show();
                                    pdfViewer1.ShowToolbar = true;
                                 
                                    pdfViewer1.Document = PdfiumViewer.PdfDocument.Load(folderpath);

                                    TCMain.SelectedIndex = 2;

                                    showOpenedBookInfo(_PDF_Book);
                                }

                                else if (result == DialogResult.Cancel)
                                {
                                    //code for No
                                }
                            }
                            catch
                            {
                            }
                            //System.Diagnostics.Process.Start(folderpath);
                            // c.Series["file extensions"].ChartType = SeriesChartType.Bar;
                        }
                    }

                    // FindNode_byTreeviewPath(treeView.Nodes, treeviewpath);
                }

            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------
        // TAB: Books: ------------------------------------------------------------------------------------------------------------------------------

        // Search for the entered search term
        private void bSearch_Click(object sender, EventArgs e)
        {

            if (tSearchBook.Text.Length > 2)
            {
                Boolean _BoolSearchTermFound = false;
                Regex rx = new Regex(tSearchBook.Text, RegexOptions.IgnoreCase);
                // Check text on the first page:
               // List<int> pages; 

                _PDF_Books_SearchResult = new List<PDF_Book>();


                if (cSearchPDFText.Checked == true)
                {

                    string IndexFolderName = Path.GetFileName(OpenedPDFLibraryPath);
                    IndexFolderName = IndexFolderName.Replace(".xml", "") + "index";

                    IndexFolderPath = System.IO.Path.Combine(UserAppdatapath, IndexFolderName);

                    if (System.IO.Directory.Exists(IndexFolderPath))
                    {
                        try
                        {

                            string strIndexDir = IndexFolderPath;
                            Analyzer std = new Lucene.Net.Analysis.Standard.StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29);
                            Lucene.Net.QueryParsers.QueryParser parser = new Lucene.Net.QueryParsers.QueryParser(Lucene.Net.Util.Version.LUCENE_29, "text", std);
                            Lucene.Net.Search.Query qry = parser.Parse(QueryParser.Escape(tSearchBook.Text));


                            Lucene.Net.Store.Directory directory = Lucene.Net.Store.FSDirectory.Open(new System.IO.DirectoryInfo(IndexFolderPath));
                            Lucene.Net.Search.Searcher searcher = new Lucene.Net.Search.IndexSearcher(Lucene.Net.Index.IndexReader.Open(directory, true));

                            TopScoreDocCollector collector = TopScoreDocCollector.Create(NumberOfBooksInLibrary, true);
                            searcher.Search(qry, collector);
                            ScoreDoc[] hits = collector.TopDocs().ScoreDocs;

                            for (int i = 0; i < hits.Length; i++)
                            {
                                int docId = hits[i].Doc;
                                float score = hits[i].Score;

                                Lucene.Net.Documents.Document doc = searcher.Doc(docId);

                                string bookid = doc.Get("bookid");
                                string bookpath = doc.Get("path");
                                //PDF_Book _PDF_Book = new PDF_Book();

                                foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                                {
                                    // do something with entry.Value or entry.Key

                                    foreach (PDF_Book _PDF_Book in entry.Value)
                                    {
                                        if (_PDF_Book.Book_ID == bookid)
                                        //if (_PDF_Book.filepath == bookpath)
                                        {
                                            _PDF_Books_SearchResult.Add(_PDF_Book);
                                        }

                                    }
                                }

                                //string result = "Score: " + score.ToString() +
                                //                " Field: " + doc.Get("path") +
                                //                " Field2: " + doc.Get("TERM");

                                //MessageBox.Show(result);
                            }
                        }
                        catch
                        {
                        }

                        }
                        else
                        {
                            MessageBox.Show(Helptext["NoSearchIndex"]);  
                        }
                  


                }
                else if (cSearchPDFText.Checked == false)
                {



                    foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                    {
                        // do something with entry.Value or entry.Key

                        foreach (PDF_Book _PDF_Book in entry.Value)
                        {

                            //pages = new List<int>();

                            _BoolSearchTermFound = false;

                            if (rx.IsMatch(_PDF_Book.title) == true)
                            {
                                _BoolSearchTermFound = true;
                            }

                            else if (rx.IsMatch(_PDF_Book.subject) == true)
                            {
                                _BoolSearchTermFound = true;
                            }

                            else if (rx.IsMatch(_PDF_Book.writer) == true)
                            {
                                _BoolSearchTermFound = true;
                            }

                            else if (rx.IsMatch(_PDF_Book.filename) == true)
                            {
                                _BoolSearchTermFound = true;
                            }

                            else if (rx.IsMatch(_PDF_Book.tags) == true)
                            {
                                _BoolSearchTermFound = true;
                            }



                            //if (cSearchPDFText.Checked == true)
                            //{
                            //    customProgressBar1.CustomText = "Search in progress :     PDF file: " + _PDF_Book.filepath;
                            //    customProgressBar1.PerformStep();

                            //    if (File.Exists(_PDF_Book.filepath))
                            //    {
                            //        PdfReader pdfReader = new PdfReader(_PDF_Book.filepath);

                            //        for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                            //        {
                            //            try 
                            //            {
                            //                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

                            //                string currentPageText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
                            //                if (currentPageText.Contains(tSearchBook.Text))
                            //                {
                            //                    pages.Add(page);
                            //                }
                            //            }
                            //            catch(Exception Ex)
                            //            {
                            //              //  MessageBox.Show(Ex.ToString()); 
                            //            }
                            //        }
                            //        pdfReader.Close();
                            //    }

                            //    if (pages.Count() > 0)
                            //    {
                            //        _BoolSearchTermFound = true;
                            //        pages.Clear();
                            //    }

                            //}


                            if (_BoolSearchTermFound == true)
                            {
                                _PDF_Books_SearchResult.Add(_PDF_Book);
                            }
                        }
                    }
                }


                if (cSearchPDFText.Checked == true)
                {
                    //customProgressBar1.CustomText = "PDF content search is complete!";
                    //customProgressBar1.PerformStep();
                }

                lAllBooksFoundCountResult.Text = _PDF_Books_SearchResult.Count().ToString();
                pAllBooks_Gridview.Controls.Clear();
                ShowBookGridview(_PDF_Books_SearchResult, pAllBooks_Gridview, false);
            }
            else
            {
                MessageBox.Show("Search query needs to have 3 characters or more");
            }
        }


        private void bLuceneInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Helptext["fulltextsearch"]);
        }


        // Show all books in the library in a gridview:
        //public DataGridView ShowBookGridview( List<PDF_Book> _PDF_Books, Panel _Panel)
        //{
            public void ShowBookGridview( List<PDF_Book> _PDF_Books, Panel _Panel, Boolean _BookShelf_Books)
            {
            try
            {
               // _Panel.Controls.Clear();
                DataGridView GView = new DataGridView();
                GView.Name = "Gridview_AllBooks";
                GView.BackgroundColor = Color.White;
                //GView.ScrollBars = ScrollBars.None;
                GView.ScrollBars = ScrollBars.Both;
                //pBookShelves.AutoScroll = false;

                DataGridViewColumn newCol0 = new DataGridViewTextBoxColumn();

                //DataGridViewColumn newCol0 = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
                //DataGridViewAutoFilter.DataGridViewAutoFilterColumnHeaderCell newCol0 = new DataGridViewAutoFilter.DataGridViewAutoFilterColumnHeaderCell();
                //newCol0.Value
                //newCol0. = DataGridViewAutoFilter.DataGridViewAutoFilterColumnHeaderCell;             
                newCol0.HeaderText = "Index";
                newCol0.Width = Convert.ToInt16(80);
                newCol0.ValueType = typeof(System.Int16);
                newCol0.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol0);

                DataGridViewColumn newCol1 = new DataGridViewTextBoxColumn();
                newCol1.HeaderText = "Bookshelf ID";
                newCol1.Width = Convert.ToInt16(200);
                newCol1.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol1);


                DataGridViewButtonColumn newCol6 = new DataGridViewButtonColumn();
                newCol6.Text = "Read";
                newCol6.UseColumnTextForButtonValue = true;
                newCol6.HeaderText = "Read";
                newCol6.Width = Convert.ToInt16(100);
                newCol6.SortMode = DataGridViewColumnSortMode.Automatic;

                GView.Columns.Add(newCol6);

                DataGridViewColumn newCol1_1 = new DataGridViewTextBoxColumn();
                newCol1_1.HeaderText = "Subject";
                newCol1_1.Width = Convert.ToInt16(150);
                newCol1_1.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol1_1);

                DataGridViewColumn newCol2 = new DataGridViewTextBoxColumn();
                newCol2.HeaderText = "Title:";
                newCol2.Width = Convert.ToInt16(100);
                newCol2.ValueType = typeof(System.Int16);
                newCol2.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol2);


                DataGridViewColumn newCol3 = new DataGridViewTextBoxColumn();
                newCol3.HeaderText = "Writer";
                newCol3.Width = Convert.ToInt16(100);
                newCol3.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol3);


                DataGridViewColumn newCol3_1 = new DataGridViewTextBoxColumn();
                newCol3_1.HeaderText = "Rating";
                newCol3_1.Width = Convert.ToInt16(100);
                newCol3_1.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol3_1);


                DataGridViewColumn newCol4 = new DataGridViewTextBoxColumn();
                newCol4.HeaderText = "Number of pages";
                newCol4.Width = Convert.ToInt16(120);
                newCol4.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol4);

                DataGridViewColumn newCol4_0 = new DataGridViewTextBoxColumn();
                newCol4_0.HeaderText = "Publishing date";
                newCol4_0.Width = Convert.ToInt16(120);
                newCol4_0.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol4_0);

                DataGridViewColumn newCol4_3 = new DataGridViewTextBoxColumn();
                newCol4_3.HeaderText = "Tags";
                newCol4_3.Width = Convert.ToInt16(100);
                newCol4_3.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol4_3);

                DataGridViewColumn newCol4_1 = new DataGridViewTextBoxColumn();
                newCol4_1.HeaderText = "File name";
                newCol4_1.Width = Convert.ToInt16(200);
                newCol4_1.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol4_1);

                DataGridViewColumn newCol4_2 = new DataGridViewTextBoxColumn();
                newCol4_2.HeaderText = "File size";
                newCol4_2.Width = Convert.ToInt16(80);
                newCol4_2.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol4_2);

                DataGridViewColumn newCol5 = new DataGridViewTextBoxColumn();
                newCol5.HeaderText = "File path";
                newCol5.Width = Convert.ToInt16(200);
                newCol5.ValueType = typeof(System.Int16);
                newCol5.SortMode = DataGridViewColumnSortMode.Automatic;
                GView.Columns.Add(newCol5);



                //DataGridViewButtonCell bopenfolder1 = new DataGridViewButtonCell();
                //bopenfolder1.Value = "Open folder";

                int i = 1;

                    // do something with entry.Value or entry.Key

                foreach (PDF_Book _PDF_Book in _PDF_Books)
                    {
                        // do something with entry.Value or entry.Key

                        DataGridViewRow row = (DataGridViewRow)GView.Rows[0].Clone();
                        row.Cells[0].Value = i;
                        row.Cells[1].Value = _PDF_Book.Book_Shelf_ID;
                        row.Cells[3].Value = _PDF_Book.subject;
                        row.Cells[4].Value = _PDF_Book.title;
                        row.Cells[5].Value = _PDF_Book.writer;

                        row.Cells[6].Value = _PDF_Book.rating;
                        row.Cells[7].Value = _PDF_Book.number_of_pages;
                        row.Cells[8].Value = _PDF_Book.publishdate;
                        row.Cells[9].Value = _PDF_Book.tags;
                        row.Cells[10].Value = _PDF_Book.filename;
                        row.Cells[11].Value = _PDF_Book.filesize;
                        row.Cells[12].Value = _PDF_Book.filepath;

                        row.Tag = _PDF_Book;
                        row.ReadOnly = true;
                        //row.Cells[6].Value = entry.Key.name;
                        //DataGridViewButtonCell bopenfolder1 = new DataGridViewButtonCell();
                        //bopenfolder1.Value = "Open folder";

                        //row.Cells[6].Value = bopenfolder1;
                        GView.Rows.Add(row);


                        i = i + 1;
                    }


                GView.Width = _Panel.Width;
                GView.Height = _Panel.Height;

                if (_BookShelf_Books == false)
                {
                    GView.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(AllBooks_Gridview_rowheaderclick);
                    GView.CellContentClick += new DataGridViewCellEventHandler(AllBooks_Gridview_Mouseclick);
                }
                else if (_BookShelf_Books == true)
                {
                    GView.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(AllBooks_Gridview_rowheaderclick_BookShelf);
                    GView.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(AllBooks_Gridview_columnheaderclick_BookShelf);

                    GView.CellContentClick += new DataGridViewCellEventHandler(AllBooks_Gridview_openfolderclick_BookShelf);

                }

                GView.PerformLayout();

                foreach (DataGridViewColumn col in GView.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new System.Drawing.Font("Arial", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
                }


               GView.Dock = DockStyle.Fill;
               GView.AllowUserToAddRows = false;
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


        private void tsBShowAllBooks_Click(object sender, EventArgs e)
        {

            List<PDF_Book> _PDF_Books = new List<PDF_Book>();

            foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
            {
                // do something with entry.Value or entry.Key

                foreach (PDF_Book _PDF_Book in entry.Value)
                {
                    _PDF_Books.Add(_PDF_Book);
                }
            }
            _PDF_Books_SearchResult.Clear();

            pAllBooks_Gridview.Controls.Clear();
            ShowBookGridview(_PDF_Books, pAllBooks_Gridview, false);
        }


        private void toolStripButtonShowSearchResults_Click(object sender, EventArgs e)
        {
            if (_PDF_Books_SearchResult.Count > 0)
            {
                Sel_BookShelf_ID = "";
                pBookShelf.Controls.Clear();
                pBookShelfBooks.Controls.Clear();
                tableLayoutPanelBookShelves.RowStyles[1].Height = 30;
                // Select the Bookshelf tab:
                TCMain.SelectedIndex = 0;

                ArrayList _PDF_Books_Found = new ArrayList();
                // string 
                // List<PDF_Book> _PDF_Books_Found = new List<PDF_Book>();
                _PDF_Books_Found.Add(_PDF_Books_SearchResult);
                ShowBookGridview(_PDF_Books_SearchResult, pBookShelfBooks, true);
                Show_Book_shelf(_PDF_Books_Found, false);
            }
            else
            {
                MessageBox.Show("There is no search result yet. Please first perform a search query.");
            }

        }

        // Export the all books gridview to excell:
        private void toolStripButtonExcell_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Export books gridview to excell?", "Warning",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                Export_toExcell(pAllBooks_Gridview, "Gridview_AllBooks");
            }
            else if (result == DialogResult.Cancel)
            {
                //code for No
            }

        }

        // Export to Excell:
        private void Export_toExcell(Panel _panel, string controlname)
        {


            Control[] controls = _panel.Controls.Find(controlname, true);

            if (controls.Length > 0)
            {
                foreach (DataGridView c in controls)
                {
                    if (c.Name == controlname)
                    {
                        try
                        {
                            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                            app.Visible = true;
                            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets.Add();
                            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;


                            for (int i = 1; i < c.Columns.Count + 1; i++)
                            {
                                worksheet.Cells[1, i] = c.Columns[i - 1].HeaderText;
                            }
                            for (int i = 0; i < c.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j < c.Columns.Count; j++)
                                {
                                    if (c.Rows[i].Cells[j].Value != null)
                                    {
                                        worksheet.Cells[i + 2, j + 1] = c.Rows[i].Cells[j].Value.ToString();
                                    }
                                    else
                                    {
                                        worksheet.Cells[i + 2, j + 1] = "";
                                    }
                                }
                            }
                        }
                        catch (Exception e2)
                        {
                            MessageBox.Show("An error occurred: '{0}':  " + e2);
                        }
                        // c.Series["file extensions"].ChartType = SeriesChartType.Bar;
                    }

                }
            }
            else
            {
                MessageBox.Show("There are no Books to export");
            }

        }

        public void AllBooks_Gridview_rowheaderclick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PDF_Book _PDF_Book = new PDF_Book();
            int value = e.RowIndex;
            //string cover_image_folderpath = "";
            //string _bookshelfname = "";
            //string _Book_Shelf_ID = "";

            if (pAllBooks_Gridview.Controls.ContainsKey("Gridview_AllBooks"))
            {
                Control[] controls = pAllBooks_Gridview.Controls.Find("Gridview_AllBooks", true);

                foreach (DataGridView c in controls)
                {
                    if (c.Name == "Gridview_AllBooks")
                    {
                        try
                        {
                            _PDF_Book = (PDF_Book)c.Rows[e.RowIndex].Tag;
                        }
                        catch
                        {
                        }
                    }
                }

                Show_Selected_PDF_Book(_PDF_Book, "Cancel");
            }

         

        }



        public void Show_Selected_PDF_Book(PDF_Book _PDF_Book, string _CancelButtonText)
        {
            Dictionary<string, string> _PDF_Bookshelves = new Dictionary<string, string>();
            //ArrayList _PDF_Bookshelves = new ArrayList();

            foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
            {
                // do something with entry.Value or entry.Key

                _PDF_Bookshelves.Add(entry.Key.name, entry.Key.Book_Shelf_ID);
          
            }

            Selected_PDF_Book _Selected_PDF_Book = new Selected_PDF_Book(_PDF_Book, _PDF_Bookshelves, _CancelButtonText);
                //Agendaitem_form.Show();
            _Selected_PDF_Book.ShowDialog();

            Change_PDF_Book();
        }

        // open a PDF file in the PDF viewer:
        private void AllBooks_Gridview_Mouseclick(object sender, DataGridViewCellEventArgs e)
        {
            //var senderGrid = (DataGridView)sender;
            String folderpath;
            PDF_Book _PDF_Book = new PDF_Book();
            //// Open folder:
            // if (e.ColumnIndex == 7 && e.RowIndex >= 0)

            // Open the folder where the original PDF files of this Bookshelf are situated: 
            if (e.ColumnIndex == 2)
            {

                    if (pAllBooks_Gridview.Controls.ContainsKey("Gridview_AllBooks"))
                    {
                        Control[] controls = pAllBooks_Gridview.Controls.Find("Gridview_AllBooks", true);

                        foreach (DataGridView c in controls)
                        {
                            if (c.Name == "Gridview_AllBooks")
                            {

                                try
                                {
                                    string filename = c.Rows[e.RowIndex].Cells[10].Value.ToString();

                                    DialogResult result = MessageBox.Show("Read the PDF book: " + filename + " ?", "Warning",
                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                    if (result == DialogResult.OK)
                                    {
                                        try
                                        {
                                            folderpath = c.Rows[e.RowIndex].Cells[12].Value.ToString();
                                            _PDF_Book = (PDF_Book)c.Rows[e.RowIndex].Tag;
                                            //webBrowser.Navigate(folderpath);
                                            //webBrowser.Show();
                                            pdfViewer1.ShowToolbar = true;
                                            pdfViewer1.Document = PdfiumViewer.PdfDocument.Load(folderpath);
                                            pViewerSearchresults.Controls.Clear();

                                            TCMain.SelectedIndex = 2;
                                            showOpenedBookInfo(_PDF_Book);
                                        }
                                        catch(Exception ex)
                                        {
                                            MessageBox.Show(ex.ToString());
                                        }
                                    }

                                    else if (result == DialogResult.Cancel)
                                    {
                                        //code for No
                                    }
                                }
                                catch
                                {
                                }
                                 //System.Diagnostics.Process.Start(folderpath);
                                // c.Series["file extensions"].ChartType = SeriesChartType.Bar;
                            }
                        }
                  
                    // FindNode_byTreeviewPath(treeView.Nodes, treeviewpath);
                }

            }
        }

     
        // Filter functionality----------------------------------------------------------------------------------------------------------

        private void cBAdvancedSearch_CheckedChanged(object sender, EventArgs e)
        {

            if (cBAdvancedSearch.Checked == true)
            {
                try
                {
                    pFilterView.Visible = true;

                    foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                    {
                        // do something with entry.Value or entry.Key

                        foreach (PDF_Book _PDF_Book in entry.Value)
                        {
                            if (!comboBoxFilterWriter.Items.Contains(_PDF_Book.writer))
                            {
                                comboBoxFilterWriter.Items.Add(_PDF_Book.writer);

                            }

                            string[] _Tags = _PDF_Book.tags.Split(',');

                            foreach (string s in _Tags)
                            {

                                if (!comboBoxFilterTags.Items.Contains(s))
                                {
                                    comboBoxFilterTags.Items.Add(s);
                                }
                            }


                            // _PDF_Books.Add(_PDF_Book);
                        }


                    }
                    comboBoxFilterWriter.Sorted = true;
                    comboBoxFilterWriter.DropDownStyle = ComboBoxStyle.DropDownList;
                    if (comboBoxFilterWriter.Items.Count > 0)
                    {
                        comboBoxFilterWriter.SelectedIndex = 0;
                    }

                    comboBoxFilterTags.Sorted = true;
                    comboBoxFilterTags.DropDownStyle = ComboBoxStyle.DropDownList;
                    if (comboBoxFilterTags.Items.Count > 0)
                    {
                        comboBoxFilterTags.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else if (cBAdvancedSearch.Checked == false)
            {
                pFilterView.Visible = false;
            }

        }

        //-----------------------------------------------------------------------------------------------------------------------

        private void bFilterWriter_Click(object sender, EventArgs e)
        {
                _PDF_Books_SearchResult = new List<PDF_Book>();

                foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                {
                    // do something with entry.Value or entry.Key

                    foreach (PDF_Book _PDF_Book in entry.Value)
                    {
                        if ( _PDF_Book.writer == comboBoxFilterWriter.SelectedItem.ToString())
                        {
                            _PDF_Books_SearchResult.Add(_PDF_Book);
                        }
                    }
                }

                lAllBooksFoundCountResult.Text = _PDF_Books_SearchResult.Count().ToString();
                pAllBooks_Gridview.Controls.Clear();
                ShowBookGridview(_PDF_Books_SearchResult, pAllBooks_Gridview, false);
            
        }


        private void bFilterTags_Click(object sender, EventArgs e)
        {
            _PDF_Books_SearchResult = new List<PDF_Book>();

            foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
            {
                // do something with entry.Value or entry.Key

                foreach (PDF_Book _PDF_Book in entry.Value)
                {

                       string[] _Tags = _PDF_Book.tags.Split(',');

                       foreach (string s in _Tags)
                       {
                           if (s == comboBoxFilterTags.SelectedItem.ToString())
                           {
                               _PDF_Books_SearchResult.Add(_PDF_Book);
                           }
                       }
                }
            }

            lAllBooksFoundCountResult.Text = _PDF_Books_SearchResult.Count().ToString();
            pAllBooks_Gridview.Controls.Clear();
            ShowBookGridview(_PDF_Books_SearchResult, pAllBooks_Gridview, false);

        }

        // TAB: BOOK -----------------------------------------------------------------------------------------------------------------------------------

        private void bSearchOpenPDF_Click(object sender, EventArgs e)
        {
            if (tSearchOpenPDF.Text.Length > 2)
            {
                try
                {

                    DoSearch(tSearchOpenPDF.Text, false, false);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                }
            
           
            }
            else
            {
                MessageBox.Show("Please enter 3 characters or more");
            }
        }



        private void DoSearch(string text, bool matchCase, bool wholeWord)
        {
            var matches = pdfViewer1.Document.Search(text, matchCase, wholeWord);
            var sb = new StringBuilder();

            pViewerSearchresults.Controls.Clear();

            DataGridView GView = new DataGridView();
            GView.Name = "Gridview_OpenPDFSearchResults";
            GView.BackgroundColor = Color.White;
            //GView.ScrollBars = ScrollBars.None;
            GView.ScrollBars = ScrollBars.Both;
            //pBookShelves.AutoScroll = false;

            DataGridViewColumn newCol0 = new DataGridViewTextBoxColumn();

            //DataGridViewColumn newCol0 = new DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn();
            //DataGridViewAutoFilter.DataGridViewAutoFilterColumnHeaderCell newCol0 = new DataGridViewAutoFilter.DataGridViewAutoFilterColumnHeaderCell();
            //newCol0.Value
            //newCol0. = DataGridViewAutoFilter.DataGridViewAutoFilterColumnHeaderCell;             
            newCol0.HeaderText = "Index";
            newCol0.Width = Convert.ToInt16(80);
            newCol0.ValueType = typeof(System.Int16);
            newCol0.SortMode = DataGridViewColumnSortMode.Automatic;
            GView.Columns.Add(newCol0);

            DataGridViewColumn newCol1 = new DataGridViewTextBoxColumn();
            newCol1.HeaderText = "Search text";
            newCol1.Width = Convert.ToInt16(200);
            newCol1.SortMode = DataGridViewColumnSortMode.Automatic;
            GView.Columns.Add(newCol1);

            DataGridViewColumn newCol1_1 = new DataGridViewTextBoxColumn();
            newCol1_1.HeaderText = "Page";
            newCol1_1.Width = Convert.ToInt16(80);
            newCol1_1.SortMode = DataGridViewColumnSortMode.Automatic;
            GView.Columns.Add(newCol1_1);

            DataGridViewButtonColumn newCol2 = new DataGridViewButtonColumn();
            newCol2.Text = "Go to";
            newCol2.UseColumnTextForButtonValue = true;
            newCol2.HeaderText = "Go to";
            newCol2.DefaultCellStyle.BackColor = Color.Green;
            newCol2.Width = Convert.ToInt16(60);
            newCol2.SortMode = DataGridViewColumnSortMode.Automatic;
            GView.Columns.Add(newCol2);

            int i = 1;


            foreach (var match in matches.Items)
            {


                try
                {

                        DataGridViewRow row = (DataGridViewRow)GView.Rows[0].Clone();
                        row.Cells[0].Value = i;
                        row.Cells[1].Value = match.Text;
                        row.Cells[2].Value = match.Page;
                        //row.Cells[3].Value = match.Location;
                       
                        GView.Rows.Add(row);


                        i = i + 1;
                    

                    //pViewerSearchresults
                    GView.Width =  pViewerSearchresults.Width;
                    GView.Height = pViewerSearchresults.Height;

                 
                   // GView.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(OpenPDFSearch_Gridview_rowheaderclick);
                    GView.CellContentClick += new DataGridViewCellEventHandler(OpenPDFSearch_Gridview_Cellclick);
                    //GView.CellContentClick += new DataGridViewCellEventHandler(AllBooks_Gridview_Mouseclick);
               

                    GView.PerformLayout();

            
                    GView.Dock = DockStyle.Fill;
                    GView.AllowUserToAddRows = false;
                    //  GView.SendToBack();
                    GView.BringToFront();
                    //GView.En

                    //return GView;
                    pViewerSearchresults.Controls.Add(GView);

                    tabControlContextInfo.SelectedIndex = 1;

                }
                catch (Exception e2)
                {
                    MessageBox.Show("An error occurred: '{0}':  " + e2);
                }

                lSearchOccurences.Text = "Occurences: " + matches.Items.Count();
                    



                //sb.AppendLine(
                //    String.Format(
                //    "Found \"{0}\" in page: {1}, bounds: {2}", match.Text, match.Page, match.Location)
                //);
            }

           

          //  searchResultLabel.Text = sb.ToString();
            //pdfViewer1.Document

          //  pdfViewer1.Renderer.Page = ;

        }


        public void OpenPDFSearch_Gridview_Cellclick(object sender, DataGridViewCellEventArgs e)
        {
           //PDF_Book _PDF_Book = new PDF_Book();
            // int value = e.RowIndex;


            if (e.ColumnIndex == 3)
            {

                if (pViewerSearchresults.Controls.ContainsKey("Gridview_OpenPDFSearchResults"))
                {
                    Control[] controls = pViewerSearchresults.Controls.Find("Gridview_OpenPDFSearchResults", true);

                    foreach (DataGridView c in controls)
                    {
                        if (c.Name == "Gridview_OpenPDFSearchResults")
                        {
                            try
                            {
                                pdfViewer1.Renderer.Page = Convert.ToInt32(c.Rows[e.RowIndex].Cells[2].Value.ToString());
                                //string searchterm = c.Rows[e.RowIndex].Cells[1].Value.ToString();
                                TCMain.SelectedIndex = 2;
                                //pdfViewer1.Document.Search(searchterm, true, false, pdfViewer1.Renderer.Page);

                            }
                            catch
                            {
                            }
                        }
                    }
                }



            }

        }

        private void toolStripButtonFullScreen_Click(object sender, EventArgs e)
        {
            ShowFullScreen(pPDFViewer);
        }

        public void ShowFullScreen(Control ctl)
        {
            // Setup host form to be full screen
            var host = new Form();
            host.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            host.WindowState = FormWindowState.Maximized;
            host.ShowInTaskbar = false;
            // Save properties of control
            var loc = ctl.Location;
            var dock = ctl.Dock;
            var parent = ctl.Parent;
            var form = parent;
            while (!(form is Form)) form = form.Parent;
            // Move control to host
            ctl.Parent = host;
            ctl.Location = Point.Empty;
            ctl.Dock = DockStyle.Fill;
            // Setup event handler to restore control back to form
            host.FormClosing += delegate
            {
                ctl.Parent = parent;
                ctl.Dock = dock;
                ctl.Location = loc;
                form.Show();
            };
            // Exit full screen with escape key
            host.KeyPreview = true;
            host.KeyDown += (KeyEventHandler)((s, e) =>
            {
                if (e.KeyCode == Keys.Escape) host.Close();
            });

            host.FormClosed += (FormClosedEventHandler)((s, e) =>
            {
                // MessageBox.Show(" hi");
               
               TCMain.SelectedIndex = 2;
                //create_physics_worldcloud(false);
            });


            // And go full screen
            host.Show();
            form.Hide();
        }


        public void showOpenedBookInfo(PDF_Book _PDF_Book_Read)
        {
            try
            {
                tabControlContextInfo.SelectedIndex = 2;
                pBookInformation.Controls.Clear();
                DataGridView GView_User = new DataGridView();
                GView_User.Dock = DockStyle.Fill;
                GView_User.Name = "Gridview_noffilesfolder";
                GView_User.BackgroundColor = Color.White;
                //GView.ScrollBars = ScrollBars.None;
                GView_User.ColumnHeadersHeight = 20;
                GView_User.ScrollBars = ScrollBars.Both;
                GView_User.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                //pFoundWords.AutoScroll = false;

                //Columns
                DataGridViewColumn newCol0_User = new DataGridViewTextBoxColumn();
                newCol0_User.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                newCol0_User.HeaderText = "";
                newCol0_User.Width = Convert.ToInt16(120);
                newCol0_User.ValueType = typeof(System.Int16);
                newCol0_User.SortMode = DataGridViewColumnSortMode.NotSortable;
                GView_User.Columns.Add(newCol0_User);

                DataGridViewColumn newCol1_User = new DataGridViewTextBoxColumn();
                newCol1_User.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                newCol1_User.HeaderText = "";
                newCol1_User.Width = Convert.ToInt16(220);
                newCol1_User.SortMode = DataGridViewColumnSortMode.NotSortable;
                GView_User.Columns.Add(newCol1_User);

                // Row: Title
                DataGridViewRow row_User = (DataGridViewRow)GView_User.Rows[0].Clone();
                row_User.Cells[0].Value = "Title:";
                row_User.Cells[1].Value = _PDF_Book_Read.title;
                GView_User.Rows.Add(row_User);

                // Writer
                row_User = (DataGridViewRow)GView_User.Rows[0].Clone();
                row_User.Cells[0].Value = "Writer:";
                row_User.Cells[1].Value = _PDF_Book_Read.writer;
                GView_User.Rows.Add(row_User);

                // Subject
                row_User = (DataGridViewRow)GView_User.Rows[0].Clone();
                row_User.Cells[0].Value = "Subject:";
                row_User.Cells[1].Value = _PDF_Book_Read.subject;
                GView_User.Rows.Add(row_User);

                // tags
                row_User = (DataGridViewRow)GView_User.Rows[0].Clone();
                row_User.Cells[0].Value = "Tags:";
                row_User.Cells[1].Value = _PDF_Book_Read.tags;
                GView_User.Rows.Add(row_User);

                // publish date:
                row_User = (DataGridViewRow)GView_User.Rows[0].Clone();
                row_User.Cells[0].Value = "Publish date:";
                row_User.Cells[1].Value = _PDF_Book_Read.publishdate;
                GView_User.Rows.Add(row_User);

                // Number of pages
                row_User = (DataGridViewRow)GView_User.Rows[0].Clone();
                row_User.Cells[0].Value = "Number of pages:";
                row_User.Cells[1].Value = _PDF_Book_Read.number_of_pages;
                GView_User.Rows.Add(row_User);

                // Description:
                row_User = (DataGridViewRow)GView_User.Rows[0].Clone();
                row_User.Cells[0].Value = "Description:";
                row_User.Cells[1].Value = _PDF_Book_Read.description;
                GView_User.Rows.Add(row_User);

                // Book ID:
                row_User = (DataGridViewRow)GView_User.Rows[0].Clone();
                row_User.Cells[0].Value = "Book ID:";
                row_User.Cells[1].Value = _PDF_Book_Read.Book_ID;
                GView_User.Rows.Add(row_User);

                // Rating
                row_User = (DataGridViewRow)GView_User.Rows[0].Clone();
                row_User.Cells[0].Value = "Rating:";
                row_User.Cells[1].Value = _PDF_Book_Read.rating;
                GView_User.Rows.Add(row_User);

                // Filename:
                row_User = (DataGridViewRow)GView_User.Rows[0].Clone();
                row_User.Cells[0].Value = "Filename:";
                row_User.Cells[1].Value = _PDF_Book_Read.filename;
                GView_User.Rows.Add(row_User);

                // Filepath:
                row_User = (DataGridViewRow)GView_User.Rows[0].Clone();
                row_User.Cells[0].Value = "Filepath:";
                row_User.Cells[1].Value = _PDF_Book_Read.filepath;
                GView_User.Rows.Add(row_User);

                // Filesize:
                row_User = (DataGridViewRow)GView_User.Rows[0].Clone();
                row_User.Cells[0].Value = "Filesize:";
                row_User.Cells[1].Value = _PDF_Book_Read.filesize;
                GView_User.Rows.Add(row_User);

                //row_User = (DataGridViewRow)GView_User.Rows[0].Clone();
                //row_User.Cells[0].Value = "User Score";
                //row_User.Cells[1].Value = userscore.ToString();
                //GView_User.Rows.Add(row_User);


                GView_User.Width = pBookInformation.Width;
                GView_User.Height = pBookInformation.Height;

                //GView.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(gridview_rowclick_noffiles);
                GView_User.PerformLayout();

                pBookInformation.Controls.Add(GView_User);
            }
            catch (Exception e2)
            {
                MessageBox.Show("An error occurred: '{0}':  " + e2);
            }

        }



        // ---------------------------------------------------------------------------------------------------------------------------------------------

        // TAB: Library XML: ------------------------------------------------------------------------------------------------------------------------------
        private void bOpenFile_Click(object sender, EventArgs e)
        {
            if (OpenedPDFLibraryPath.Length > 0)
              {


                
                  fastColoredTextBoxXML.OpenFile(OpenedPDFLibraryPath);
                  OpenedPDFLibraryPathLines = fastColoredTextBoxXML.Lines.Count();
                  //MessageBox.Show(fastColoredTextBoxXML.Lines.Count().ToString());
                  //fastColoredTextBoxXML.ReadOnly = true;
                 // bSave.Enabled = true;

                  //MessageBox.Show("You have opened your XML library file. It is recommended not to change anything in this file You can only change " +
                  //    " the black texts (the texts between the XML tags). Don't change the XML tags themselves (red texts) because " +
                  //    " otherwise your library file becomes unreadable and can't be opened anymore!"
                     
                  //, "Information",
                  // MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
             else
             {
                 MessageBox.Show("You have not openend a PDF library file");
             }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if (OpenedPDFLibraryPath.Length > 0)
                //{
                //    if (OpenedPDFLibraryPathLines == fastColoredTextBoxXML.Lines.Count())
                //    {
                //        XmlDocument document = new XmlDocument();
                //        document.LoadXml(fastColoredTextBoxXML.Text);
                //        document.Save(OpenedPDFLibraryPath.Replace(".xml", "") + ".xml");

                //        fastColoredTextBoxXML.Text = "";
                //       // fastColoredTextBoxXML.ReadOnly = true;
                //        bSave.Enabled = false;
                //    }
                //    else
                //    {
                //        MessageBox.Show("Your XML Library file can't be saved, because you have added additional lines to the opened XML file or removed lines. You are only allowed to change the values (the black texts) of the file. " +
                //        "You are not allowed to add or remove XML items");
                //    }

                //}
                //else
                //{
                //    //DialogResult _Message = MessageBox.Show("You have no agenda opened",
                //    // "Important",
                //    // MessageBoxButtons.OK,
                //    // MessageBoxIcon.Warning,
                //    // MessageBoxDefaultButton.Button1);
                //    //SavePDFLibraryAs();
                //}
                //if (OpenedPDFLibraryPath.Length > 0)
                //{

                //    MessageBox.Show("You are opening your XML library file. It is recommended not to change anything in this file. You can only change " +
                //        " the black texts (the texts between the XML tags). Don't change the XML tags themselves (red texts) because " +
                //        " otherwise your library file becomes unreadable and can't be opened anymore!"

                //  , "Information",
                //   MessageBoxButtons.OK, MessageBoxIcon.Information);

                //    System.Diagnostics.Process.Start(OpenedPDFLibraryPath);
                //}
                //else
                //{
                //    MessageBox.Show("You have not openend a PDF library file");
                //}

            }

            catch (Exception e2)
            {
                MessageBox.Show("An error occurred: '{0}':  " + e2);
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------

        // TAB: Statistics: ------------------------------------------------------------------------------------------------------------------------------

        private void bShowStatistics_Click(object sender, EventArgs e)
        {
            
            if (comboBoxStatistics.SelectedIndex == 0)
            {

                Dictionary<string, int> _WritersBooks = new Dictionary<string, int>();
                Dictionary<string, string> _ChartTexts = new Dictionary<string, string>();
                List<string> _writers = new List<string>();
                List<int> _writersnofbooks = new List<int>();
                //ArrayList _writers = new ArrayList();
                try
                {
                foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                {
                    // do something with entry.Value or entry.Key

                    foreach (PDF_Book _PDF_Book in entry.Value)
                    {
                        if (!_writers.Contains(_PDF_Book.writer))
                        {
                            _writers.Add(_PDF_Book.writer);

                        }
                    }
                }

                _writers.Sort();

                foreach (string _writername in _writers)
                {
                    int i = 0;
                    foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                    {
                        // do something with entry.Value or entry.Key

                        foreach (PDF_Book _PDF_Book in entry.Value)
                        {
                            if (_PDF_Book.writer == _writername)
                            {

                                i = i + 1;
                            }
                        }
                    }
                    _writersnofbooks.Add(i);
                }

                _WritersBooks = Enumerable.Range(0, _writers.Count()).ToDictionary(i => _writers[i], i => _writersnofbooks[i]);


                _ChartTexts.Add("title", "Number of books per writer");
                _ChartTexts.Add("AxisY_Title", "Books");
                _ChartTexts.Add("AxisX_Title", "Writers");
         
                _ChartTexts.Add("LegendText", "Books");

               // gBStatFilter.Visible = false;
                //Create_DataTable_Linq_Query();
                pStatistics.Controls.Clear();
                Chart1 = new Chart();
                Chart1 = _ChartController.Plot_String_Int(pStatistics.Width, pStatistics.Height, _WritersBooks, _ChartTexts);
                pStatistics.Controls.Add(Chart1);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            else if (comboBoxStatistics.SelectedIndex == 1)
            {
                Dictionary<string, int> _SubjectsBooks = new Dictionary<string, int>();
                Dictionary<string, string> _ChartTexts = new Dictionary<string, string>();
                List<string> _Subjects = new List<string>();
                List<int> _Subjectnofbooks = new List<int>();
                //ArrayList _writers = new ArrayList();
                 try
                {
                foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                {
                    // do something with entry.Value or entry.Key

                    foreach (PDF_Book _PDF_Book in entry.Value)
                    {
                        if (!_Subjects.Contains(_PDF_Book.subject))
                        {
                            _Subjects.Add(_PDF_Book.subject);

                        }
                    }
                }

                _Subjects.Sort();

                foreach (string _subjectname in _Subjects)
                {
                    int i = 0;
                    foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                    {
                        // do something with entry.Value or entry.Key

                        foreach (PDF_Book _PDF_Book in entry.Value)
                        {
                            if (_PDF_Book.subject == _subjectname)
                            {

                                i = i + 1;
                            }
                        }
                    }
                    _Subjectnofbooks.Add(i);
                }

                _SubjectsBooks = Enumerable.Range(0, _Subjects.Count()).ToDictionary(i => _Subjects[i], i => _Subjectnofbooks[i]);


                _ChartTexts.Add("title", "Number of books per subject");
                _ChartTexts.Add("AxisY_Title", "Books");
                _ChartTexts.Add("AxisX_Title", "Subject");

                _ChartTexts.Add("LegendText", "Books");

                // gBStatFilter.Visible = false;
                //Create_DataTable_Linq_Query();
                pStatistics.Controls.Clear();
                Chart1 = new Chart();
                Chart1 = _ChartController.Plot_String_Int(pStatistics.Width, pStatistics.Height, _SubjectsBooks, _ChartTexts);
                pStatistics.Controls.Add(Chart1);

                }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.ToString());
                 }
            }
            else if (comboBoxStatistics.SelectedIndex == 2)
            {

                Dictionary<string, int> _PublishingYearBooks = new Dictionary<string, int>();
                Dictionary<string, string> _ChartTexts = new Dictionary<string, string>();
                List<string> _Years = new List<string>();
                List<int> _Publishyearnofbooks = new List<int>();
                //ArrayList _writers = new ArrayList();
                 try
                {
                foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                {
                    // do something with entry.Value or entry.Key

                    foreach (PDF_Book _PDF_Book in entry.Value)
                    {
                        string year = _PDF_Book.publishdate.Year.ToString();

                        if (!_Years.Contains(year))
                        {
                            _Years.Add(year);

                        }
                    }
                }

                _Years.Sort();

                foreach (string _year in _Years)
                {
                    int i = 0;
                    foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in MY_PDF_library)
                    {
                        // do something with entry.Value or entry.Key

                        foreach (PDF_Book _PDF_Book in entry.Value)
                        {
                            string year = _PDF_Book.publishdate.Year.ToString();

                            if (year == _year)
                            {

                                i = i + 1;
                            }
                        }
                    }
                    _Publishyearnofbooks.Add(i);
                }

                _PublishingYearBooks = Enumerable.Range(0, _Years.Count()).ToDictionary(i => _Years[i], i => _Publishyearnofbooks[i]);


                _ChartTexts.Add("title", "Number of books per publishing year");
                _ChartTexts.Add("AxisY_Title", "Books");
                _ChartTexts.Add("AxisX_Title", "Publishing year");

                _ChartTexts.Add("LegendText", "Books");

                // gBStatFilter.Visible = false;
                //Create_DataTable_Linq_Query();
                pStatistics.Controls.Clear();
                Chart1 = new Chart();
                Chart1 = _ChartController.Plot_String_Int(pStatistics.Width, pStatistics.Height, _PublishingYearBooks, _ChartTexts);
                pStatistics.Controls.Add(Chart1);

                }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.ToString());
                 }
            }

            Ccharttype.Enabled = true;
            bApplyCharttype.Enabled = true;

        }


        private void toolStripButtonSaveStatJPEG_Click(object sender, EventArgs e)
        {
            int i = 0;
            string myfile = null;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = UserAppdatapath;
            saveFileDialog1.Filter = "xml files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            {
                if (pStatistics.Controls.ContainsKey("Chart1"))
                {
                    if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        try
                        {

                            Control[] controls = pStatistics.Controls.Find("Chart1", true);

                            foreach (Chart c in controls)
                            {
                                if (c.Name == "Chart1")
                                {
                                    c.SaveImage(saveFileDialog1.FileName.ToString() + ".Jpeg", ImageFormat.Jpeg);
                                }
                            }


                            //Bitmap bmp = new Bitmap(circleMap.Width, circleMap.Height);
                            //circleMap.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                            //bmp.Save(saveFileDialog1.FileName.ToString() + ".Jpeg", ImageFormat.Jpeg);

                        }
                        catch (Exception e2)
                        {
                            MessageBox.Show("An error occurred: '{0}':  " + e2);
                        }

                    }
                }
            }
        }


        private void bApplyCharttype_Click(object sender, EventArgs e)
        {
            try
            {
                if (Ccharttype.SelectedItem == "Point")
                {
                    //pGraph.Controls.Clear();
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.Point;


                    //pGraph.Controls.Add(Chart1);
                }
                else if (Ccharttype.SelectedItem == "FastPoint")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.FastPoint;
                }
                else if (Ccharttype.SelectedItem == "Bubble")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.Bubble;

                }
                else if (Ccharttype.SelectedItem == "Line")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.Line;
                }
                else if (Ccharttype.SelectedItem == "Spline")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.Spline;
                }
                else if (Ccharttype.SelectedItem == "StepLine")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.StepLine;
                }
                else if (Ccharttype.SelectedItem == "FastLine")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.FastLine;
                }
                else if (Ccharttype.SelectedItem == "Bar")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.Bar;
                }
                else if (Ccharttype.SelectedItem == "StackedBar")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.StackedBar;
                }
                else if (Ccharttype.SelectedItem == " StackedBar100")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.StackedBar100;

                }
                else if (Ccharttype.SelectedItem == "Column")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.Column;
                }
                else if (Ccharttype.SelectedItem == "StackedColumn")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.StackedColumn;
                }
                else if (Ccharttype.SelectedItem == "StackedColumn100")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.StackedColumn100;
                }
                else if (Ccharttype.SelectedItem == "Area")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.Area;
                }
                else if (Ccharttype.SelectedItem == "SplineArea")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.SplineArea;
                }
                else if (Ccharttype.SelectedItem == "StackedArea")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.StackedArea;
                }
                else if (Ccharttype.SelectedItem == "StackedArea100")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.StackedArea100;
                }
                else if (Ccharttype.SelectedItem == "Pie")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.Pie;
                }
                else if (Ccharttype.SelectedItem == "Doughnut")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.Doughnut;
                }
                else if (Ccharttype.SelectedItem == "Stock")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.Stock;
                }
                else if (Ccharttype.SelectedItem == "Candlestick")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.Candlestick;
                }
                else if (Ccharttype.SelectedItem == "Range")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.Range;
                }
                else if (Ccharttype.SelectedItem == "SplineRange")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.SplineRange;
                }
                else if (Ccharttype.SelectedItem == "RangeBar")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.RangeBar;
                }
                else if (Ccharttype.SelectedItem == "RangeColumn")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.RangeColumn;
                }
                else if (Ccharttype.SelectedItem == "Radar")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.Radar;
                }
                else if (Ccharttype.SelectedItem == "Polar")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.Polar;
                }
                else if (Ccharttype.SelectedItem == "ErrorBar")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.ErrorBar;
                }
                else if (Ccharttype.SelectedItem == "BoxPlot")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.BoxPlot;
                }
                else if (Ccharttype.SelectedItem == "Renko")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.Renko;
                }
                else if (Ccharttype.SelectedItem == "ThreeLineBreak")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.ThreeLineBreak;
                }
                else if (Ccharttype.SelectedItem == "Kagi")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.Kagi;
                }
                else if (Ccharttype.SelectedItem == "PointAndFigure")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.PointAndFigure;
                }
                else if (Ccharttype.SelectedItem == "Funnel")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.Funnel;
                }
                else if (Ccharttype.SelectedItem == "Pyramid")
                {
                    Chart1.Series["Agenda_items"].ChartType = SeriesChartType.Pyramid;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        
        //-------------------------------------------------------------------------------------------------------------------------------------------------

        // CONTEXT INFORMATION:

        private void pBookShelves_MouseHover(object sender, EventArgs e)
        {
            tContextInfo.Text = "";
            tContextInfo.Text = Helptext["BookShelf-view"];

        }

        private void pBookShelf_MouseHover(object sender, EventArgs e)
        {
            tContextInfo.Text = "";
            tContextInfo.Text = Helptext["BookShelf"];
        }

        private void pBookShelfBooks_MouseHover(object sender, EventArgs e)
        {
            tContextInfo.Text = "";
            tContextInfo.Text = Helptext["BookShelf"];
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


    
    

        // ------------------- ------------------------------------------------------------------------------------------------------------------------------

    }
    
}
