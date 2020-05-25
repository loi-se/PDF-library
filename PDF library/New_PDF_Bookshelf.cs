using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MRG.Controls;
using System.Threading.Tasks;
using System.Threading;

namespace PDF_library
{
    public partial class New_PDF_Bookshelf : Form
    {

        public string PDF_Book_Shelf_folderpath;
        public PDF_Book_Shelf _PDF_BookShelf_Changed;
        Form1 _form1;
        BackgroundWorker _BackgroundWorker;

        public string UserAppdatapath = Application.UserAppDataPath;
        private string LastOpenedFolder = "";

        private Boolean _BookShelfName_valid = false;
        private Boolean _BookShelfSubject_valid = false;
        private Boolean _BookShelffolderpath_valid = false;
        private Boolean _BookShelfSearchTerm_valid = false;

        private string Invalid_user_input = " Please enter valid values:" + Environment.NewLine + Environment.NewLine +
                          " - Bookshelf name: (Number of characters should be between: 0-250 and the name need to be unique) " + Environment.NewLine +
                          " - Bookshelf subject: (Number of characters should be between: 0-250) " + Environment.NewLine +
                          " - Bookshelf directory path: (Number of characters: > 0) " + Environment.NewLine +
                          " - Bookshelf search term: (Number of characters should be between: 0-1000) " + Environment.NewLine +
                          " - Characters not allowed: &.";


        private string Invalid_user_input2 = " Please enter valid values:" + Environment.NewLine + Environment.NewLine +
                          " - Bookshelf name: (Number of characters should be between: 0-250 and the name need to be unique) " + Environment.NewLine +
                          " - Bookshelf subject: (Number of characters should be between: 0-250) " + Environment.NewLine +
                        
                          " - Characters not allowed: &.";

        public New_PDF_Bookshelf(Form1 _new_form1, PDF_Book_Shelf PDF_BookShelf_Changed)
        {
            InitializeComponent();
            _form1 = _new_form1;
            _PDF_BookShelf_Changed = new PDF_Book_Shelf();
            //_PDF_BookShelf_Changed = new PDF_Book_Shelf();


            if (PDF_BookShelf_Changed == null)
            {
                _PDF_BookShelf_Changed.name = "";
            }
            else
            {
                _PDF_BookShelf_Changed = PDF_BookShelf_Changed;
            }
            bAddBookShelf.Text = "";
        }


        private void New_PDF_Bookshelf_Load(object sender, EventArgs e)
        {
            // a new bookshelf:
            //loadingCircle.Visible = true;
            //loadingCircle.Active = true;
            panelScanFolderPath.Enabled = false;

            
            _BookShelfName_valid = false;
            _BookShelfSubject_valid = false;
            _BookShelffolderpath_valid = false;
            _BookShelfSearchTerm_valid = false;


            // A new bookshelf is made:
            if (_PDF_BookShelf_Changed.name.Length == 0)
            {

                bAddBookShelf.Text = "Add";
                cBBookShelfReScan.Enabled = false;
                tBookShelfSearchTerm.Enabled = false;
                labelReScan.Enabled = false;
                labelReScan.Visible = false;

                cBBookShelfReScan.Enabled = false;
                cBBookShelfReScan.Visible = false;


                 //MessageBox.Show("new bookshelf");

            }
            
            // An existing bookshelf is changed:
            else if (_PDF_BookShelf_Changed.name.Length > 0)
            {
                cBBookShelfReScan.Enabled = true;
                bAddBookShelf.Text = "Change";
                this.Text = "Change bookshelf";

                tBookShelfName.Text = _PDF_BookShelf_Changed.name;
                tBookShelfSubject.Text = _PDF_BookShelf_Changed.subject;
                tBookShelfSearchTerm.Text = _PDF_BookShelf_Changed.search_terms;
                tChoosenFolderPath.Text = _PDF_BookShelf_Changed.folderpath;
                cBSubDirectories.Enabled = false;
                labelReScan.Enabled = true;
                labelReScan.Visible = true;

                cBBookShelfReScan.Enabled = true;
                cBBookShelfReScan.Visible = true;



                if (_PDF_BookShelf_Changed.directory_scan == "true")
                {
                    cBScanExistingDir.Checked = true;
                    cBScanExistingDir.Enabled = false;
                }
                else if (_PDF_BookShelf_Changed.directory_scan == "false")
                {
                    // _subdir = "false";
                    cBScanExistingDir.Checked = false;
                    cBScanExistingDir.Enabled = false;
                }



                if (_PDF_BookShelf_Changed.subdirs == "true")
                {
               
                    cBSubDirectories.Checked = true;
                }
                else if (_PDF_BookShelf_Changed.subdirs == "false")
                {
                   // _subdir = "false";
                    cBSubDirectories.Checked = false;
                }


                if (_PDF_BookShelf_Changed.search_terms_active == "true")
                {

                    cBSearchTermActive.Checked = true;
                }
                else if (_PDF_BookShelf_Changed.search_terms_active == "false")
                {
                    // _subdir = "false";
                    cBSearchTermActive.Checked = false;
                }


                bChooseFolderPath.Enabled = false;
                tBookShelfSearchTerm.Enabled = false;
                cBSearchTermActive.Enabled = false;


            }
        
        }


        private void bAddBookShelf_Click(object sender, EventArgs e)
        {
            // Change an excisting bookshelf:
            if (bAddBookShelf.Text == "Change")
            {

                //lScannedFolderpath.Text = "The scanning of folder: " + tChoosenFolderPath.Text + " is in progress:";
                //string _subdir = "";
                //if (cBSubDirectories.Checked == true)
                //{
                //    _subdir = "true";
                //}
                //else if (cBSubDirectories.Checked == false)
                //{
                //    _subdir = "false";
                //}
                Boolean _Rescan = false;

               // _PDF_BookShelf_Changed.name = tBookShelfName.Text;
               // _PDF_BookShelf_Changed.subject = tBookShelfSubject.Text;

                //Form1 _Form1 = new Form1();
                if (cBBookShelfReScan.Checked == true)
                {


                    Validate_UserInput();

                    if (_BookShelfName_valid == true && _BookShelfSubject_valid == true && _BookShelffolderpath_valid == true)
                    {

                         DialogResult result = MessageBox.Show("You are going to do a re-scan of the selected directory path. A re-scan means that all the books" +
                            " in the choosen directory will be scanned. This means that the meta-information of your current bookshelf books is also rescanned so you might lose some book information" 
                            + " (If you just want to add a couple of new books to your bookshelf it is recommended to add them with the ADD function. This way all your added book meta-information remains intact)." +
                            " Are you sure you want to do a re-scan of this directory path?", "Warning",
                  MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                         if (result == DialogResult.OK)
                         {
                             _Rescan = true;
                             // _PDF_BookShelf_Changed.folderpath = PDF_Book_Shelf_folderpath;
                             _PDF_BookShelf_Changed.folderpath = tChoosenFolderPath.Text;


                             string _subdir = "";
                             if (cBSubDirectories.Checked == true)
                             {
                                 _subdir = "true";
                             }
                             else if (cBSubDirectories.Checked == false)
                             {
                                 _subdir = "false";
                             }

                             _PDF_BookShelf_Changed.subdirs = _subdir;


                             string _SearchTermsActive = "";
                             if (cBSearchTermActive.Checked == true)
                             {
                                 _SearchTermsActive = "true";
                             }
                             else if (cBSearchTermActive.Checked == false)
                             {
                                 _SearchTermsActive = "false";
                             }

                             _PDF_BookShelf_Changed.search_terms_active = _SearchTermsActive;
                             _PDF_BookShelf_Changed.search_terms = tBookShelfSearchTerm.Text;
                             _PDF_BookShelf_Changed.name = tBookShelfName.Text;
                             _PDF_BookShelf_Changed.subject = tBookShelfSubject.Text;


                             _form1.CreateBookShelf_Rescan(_PDF_BookShelf_Changed, GlobalVar.Alreadyscanned_Books, _Rescan);
                             this.Close();
                         }
                         else if (result == DialogResult.Cancel)
                         {
                             //code for No
                         }

                    }
                    else
                    {
                        MessageBox.Show(Invalid_user_input,
                           "Information",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

                else if (cBBookShelfReScan.Checked == false)
                {
                    Validate_UserInput();

                    if (_BookShelfName_valid == true && _BookShelfSubject_valid == true)
                    {

                        _Rescan = false;
                        _PDF_BookShelf_Changed.name = tBookShelfName.Text;
                        _PDF_BookShelf_Changed.subject = tBookShelfSubject.Text;
                        _form1.CreateBookShelf_Rescan(_PDF_BookShelf_Changed, GlobalVar.Alreadyscanned_Books, _Rescan);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(Invalid_user_input2,
                           "Information",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

               
            }


            else if (bAddBookShelf.Text == "Add")
            {
                //lScannedFolderpath.Text = "";

                if (cBScanExistingDir.Checked == false)
                {
                    Validate_UserInput();

                    if (_BookShelfName_valid == true && _BookShelfSubject_valid == true)
                    {


                        //Form1 _Form1 = new Form1();


                        //_form1.loadingCircle.Visible = true;
                        //_form1.loadingCircle.Active = true;
                        // loadingCircle1.Active = true;


                        //_BackgroundWorker.RunWorkerAsync();

                        //_form1.PerformSafely(() => _form1.CreateBookShelf_Empthy(tBookShelfName.Text, tBookShelfSubject.Text));
                        _form1.CreateBookShelf_Empthy(tBookShelfName.Text, tBookShelfSubject.Text);
                        //_form1.loadingCircle.Visible = false;
                        //_form1.loadingCircle.Active = false;
                        //_BackgroundWorker.CancelAsync();
                        //this.PerformSafely(() => this.Close());
                         this.Close();

                    }
                    else
                    {
                        MessageBox.Show(Invalid_user_input2,
                           "Information",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }



                }
                else if (cBScanExistingDir.Checked == true)
                {

                    Validate_UserInput();

                    if (_BookShelfName_valid == true && _BookShelfSubject_valid == true && _BookShelffolderpath_valid == true)
                    {
                        //lScannedFolderpath.Text = "The scanning of folder: " + tChoosenFolderPath.Text + " is in progress:";
                        string _subdir = "";
                        if (cBSubDirectories.Checked == true)
                        {
                            _subdir = "true";
                        }
                        else if (cBSubDirectories.Checked == false)
                        {
                            _subdir = "false";
                        }


                        string _SearchTermsActive = "";
                        if (cBSearchTermActive.Checked == true)
                        {
                            _SearchTermsActive = "true";
                        }
                        else if (cBSearchTermActive.Checked == false)
                        {
                            _SearchTermsActive = "false";
                        }

                        //Form1 _Form1 = new Form1();


                        //_form1.loadingCircle.Visible = true;
                        //_form1.loadingCircle.Active = true;
                        // loadingCircle1.Active = true;


                        //_BackgroundWorker.RunWorkerAsync();

                        //  Thread t = new Thread(Loadingcircle);
                        //t.Start();
                        //Task.Factory.StartNew(Loadingcircle();
                        //_form1.loadingCircle2.Active = true;

                       // loadingCircle1.Active = true;
                       // _form1.PerformSafely(() => _form1.CreateBookShelf_Scan(tBookShelfName.Text, PDF_Book_Shelf_folderpath, _subdir, tBookShelfSubject.Text, tBookShelfSearchTerm.Text, _SearchTermsActive, false, ""));

                        //if (_SearchTermsActive == "true")
                        //{
                        //    Scan_Options _Scan_Options = new Scan_Options();
                        //    //Agendaitem_form.Show();
                        //    _Scan_Options.ShowDialog();
                        //}



                        _form1.CreateBookShelf_Scan(tBookShelfName.Text, PDF_Book_Shelf_folderpath, _subdir, tBookShelfSubject.Text, tBookShelfSearchTerm.Text, _SearchTermsActive, false, "");
                        //_form1.loadingCircle.Visible = false;
                        //_form1.loadingCircle.Active = false;
                        //_BackgroundWorker.CancelAsync();
                       // loadingCircle1.Active = false;
                        //this.PerformSafely(() => this.Close());
                         this.Close();

                    }
                    else
                    {
                        MessageBox.Show(Invalid_user_input,
                           "Information",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        private void bChooseFolderPath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog openFileDialog = new FolderBrowserDialog();

                if (LastOpenedFolder.Length > 0)
                {
                    openFileDialog.SelectedPath = LastOpenedFolder;
                }
                else
                {
                    openFileDialog.SelectedPath = UserAppdatapath;
                }

                //openFileDialog.SelectedPath = @"C:\Users\Rol\Documents\Books -Magazines\National geographic magazine";

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    PDF_Book_Shelf_folderpath = openFileDialog.SelectedPath;
                    tChoosenFolderPath.Text = PDF_Book_Shelf_folderpath;
                    LastOpenedFolder = openFileDialog.SelectedPath;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tlpBookShelf_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cBBookShelfReScan_CheckedChanged(object sender, EventArgs e)
        {
            if (cBBookShelfReScan.Checked == true)
            {
                bChooseFolderPath.Enabled = true;
                tBookShelfSearchTerm.Enabled = true;
                cBSearchTermActive.Enabled = true;
                cBSubDirectories.Enabled = true;

                  if (cBSearchTermActive.Checked == true)
            {
                tBookShelfSearchTerm.Enabled = true;
            }
            else if (cBSearchTermActive.Checked == false)
            {
                tBookShelfSearchTerm.Enabled = false;
            }
            }
            else if (cBBookShelfReScan.Checked == false)
            {
                bChooseFolderPath.Enabled = false;
                tBookShelfSearchTerm.Enabled = false;
                cBSearchTermActive.Enabled = false;
                cBSubDirectories.Enabled = false;

            }
        }

        private void cBSearchTermActive_CheckedChanged(object sender, EventArgs e)
        {
            if (cBSearchTermActive.Checked == true)
            {
                tBookShelfSearchTerm.Enabled = true;
            }
            else if (cBSearchTermActive.Checked == false)
            {
                tBookShelfSearchTerm.Enabled = false;
            }
        }

        private void bInfoSearchTermActive_Click(object sender, EventArgs e)
        {

            MessageBox.Show("With this option you can determine if a search term is used or not used when scanning for the PDF files in your choosen folder path." +
            " If this option is checked it means that only PDF files that satisfy the following conditions are included in your PDF Shelf:"  + Environment.NewLine + Environment.NewLine +
            " -The entered search term is found in the PDF filename. " + Environment.NewLine +
            " -The entered search term is found in the first two pages of the scanned PDF file." + Environment.NewLine + Environment.NewLine +
            
            " If this option is unchecked all PDF files in your choosen folder path will be scanned and added to your bookshelf."
            , "Information",
             MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void bInfoSearchTerm_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
           " If a search term is entered only PDF documents that satisfy the following conditions are included in your PDF Shelf:" + Environment.NewLine + Environment.NewLine +
           " -The entered search term is found in the PDF filename. " + Environment.NewLine +
           " -The entered search term is found in the first two pages of the scanned PDF file." + Environment.NewLine + Environment.NewLine + 
        
           "For example: If you only want to find PDF books that are about politics you can use the following search term: " + Environment.NewLine + Environment.NewLine +
           " politics " + Environment.NewLine + Environment.NewLine +

            "If you want to use multiple search terms you have to separate them with a comma: "+ Environment.NewLine + Environment.NewLine + 

            "search-term1,search-term2,search-term3" 
            ,
            "Information",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bInfoIncludeSubDirectories_Click(object sender, EventArgs e)
        {


            MessageBox.Show(" If this option is checked not only the PDF files in the choosen root-directory will be scanned but also " +
                " all the PDF files in all the subdirectories of the choosen root-directory will be scanned! " 
            , "Information",
             MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void bInfoFolderPath_Click(object sender, EventArgs e)
        {

            MessageBox.Show(" Here you can select which folder or directory on your computer needs to be scanned for PDF files."
            , "Information",
             MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cBScanExistingDir_CheckedChanged(object sender, EventArgs e)
        {
            if (cBScanExistingDir.Checked == true)
            {

                panelScanFolderPath.Enabled = true;
            }
            else if (cBScanExistingDir.Checked == false)
            {
                panelScanFolderPath.Enabled = false;
            }
        }

        private void Validate_UserInput()
        {

            _BookShelfName_valid = false;
            _BookShelfSubject_valid = false;
            _BookShelffolderpath_valid = false;
            _BookShelfSearchTerm_valid = false;

            if (tBookShelfName.Text.Length > 0 && tBookShelfName.Text.Length < 250)
            {
                if (GlobalVar.IsValidXmlString(tBookShelfName.Text) == true)
                {
                    ArrayList Bookshelfnames = new ArrayList();
                   
                    //int i = 0;
                    foreach (KeyValuePair<PDF_Book_Shelf, List<PDF_Book>> entry in _form1.MY_PDF_library)
                    {
                        // do something with entry.Value or entry.Key
                        if (_PDF_BookShelf_Changed.name.Length > 0)
                        {
                            if (entry.Key.name == _PDF_BookShelf_Changed.name)
                            {
                                // do nothing
                            }
                            else
                            {
                                Bookshelfnames.Add(entry.Key.name);
                            }
                        }
                        else
                        {
                            Bookshelfnames.Add(entry.Key.name);
                        }

                    }

                    if (Bookshelfnames.Contains(tBookShelfName.Text))
                    {
                        _BookShelfName_valid = false;
                    }
                    else
                    {
                        _BookShelfName_valid = true;
                    }
                    Bookshelfnames.Clear();
                }
            }


            if (tBookShelfSubject.Text.Length > 0 && tBookShelfSubject.Text.Length < 250)
            {
                if (GlobalVar.IsValidXmlString(tBookShelfSubject.Text) == true)
                {
                    _BookShelfSubject_valid = true;
                }
            }

            if (tChoosenFolderPath.Text.Length > 0)
            {     
                    _BookShelffolderpath_valid = true;
            }


            if (tBookShelfSearchTerm.Text.Length > 0 && tBookShelfSearchTerm.Text.Length < 1000)
            {
                if (GlobalVar.IsValidXmlString(tBookShelfSearchTerm.Text) == true)
                {
                    _BookShelfSearchTerm_valid = true;
                }
            }

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
