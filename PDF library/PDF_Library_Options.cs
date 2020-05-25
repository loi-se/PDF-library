using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PDF_library
{
    public partial class PDF_Library_Options : Form
    {
        public PDF_Library_Options()
        {
            InitializeComponent();
       
        }

        private void cBBookCoverImageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void bBookShelfSettingsApply_Click(object sender, EventArgs e)
        {

            // tiny
            if (cBBookCoverImageSize.SelectedIndex == 0)
            {

                GlobalVar.Book_location_X = 3;
                GlobalVar.Book_location_Y = 1;
                GlobalVar.Bookheight = 21;
                GlobalVar.Bookwidth = 14;
                GlobalVar.BookShelf_HorizontalScrollbar_ExtraHeight = 15;
                GlobalVar.Book_offset = 3;
                GlobalVar.BookShelfheight = 34;
                GlobalVar.BookShelf_SelectedSizeIndex = 0;


                GlobalVar.FooterFontSize = 3;
                GlobalVar.FooterHeight = 5;
                GlobalVar.FooterWidth = 14;
            }



            //small: (normal / 3)
            if (cBBookCoverImageSize.SelectedIndex == 1)
            {

                GlobalVar.Book_location_X = 10;
                GlobalVar.Book_location_Y = 5;
                GlobalVar.Bookheight = 63;
                GlobalVar.Bookwidth = 43;
                GlobalVar.BookShelf_HorizontalScrollbar_ExtraHeight = 15;
                GlobalVar.Book_offset = 7;
                GlobalVar.BookShelfheight = 100;
                GlobalVar.BookShelf_SelectedSizeIndex = 1;

                GlobalVar.FooterFontSize = 4;
                GlobalVar.FooterHeight = 17;
                GlobalVar.FooterWidth = 43;
            }

            // medium: (normal / 2)
            else if (cBBookCoverImageSize.SelectedIndex == 2)
            {

                GlobalVar.Book_location_X = 10;
                GlobalVar.Book_location_Y = 15;
                GlobalVar.Bookheight = 95;
                GlobalVar.Bookwidth = 65;
                GlobalVar.BookShelf_HorizontalScrollbar_ExtraHeight = 15;
                GlobalVar.Book_offset = 10;
                GlobalVar.BookShelfheight = 145;

                GlobalVar.BookShelf_SelectedSizeIndex = 2;

                GlobalVar.FooterFontSize = 6;
                GlobalVar.FooterHeight = 25;
                GlobalVar.FooterWidth = 65;
            }

            // normal
            else if (cBBookCoverImageSize.SelectedIndex == 3)
            {

                GlobalVar.Book_location_X = 10;
                GlobalVar.Book_location_Y = 30;
                GlobalVar.Bookheight = 190;
                GlobalVar.Bookwidth = 130;
                GlobalVar.BookShelf_HorizontalScrollbar_ExtraHeight = 15;
                GlobalVar.Book_offset = 20;
                GlobalVar.BookShelfheight = 290;

                GlobalVar.BookShelf_SelectedSizeIndex = 3;

                GlobalVar.FooterFontSize = 8;
                GlobalVar.FooterHeight = 50;
                GlobalVar.FooterWidth = 130;

            }
            //Large (normal * 2)
            else if (cBBookCoverImageSize.SelectedIndex == 4)
            {
                GlobalVar.Book_location_X = 10;
                GlobalVar.Book_location_Y = 60;
                GlobalVar.Bookheight = 380;
                GlobalVar.Bookwidth = 260;
                GlobalVar.BookShelf_HorizontalScrollbar_ExtraHeight = 30;
                GlobalVar.Book_offset = 40;
                GlobalVar.BookShelfheight = 580;

                GlobalVar.BookShelf_SelectedSizeIndex = 4;

                GlobalVar.FooterFontSize = 16;
                GlobalVar.FooterHeight = 100;
                GlobalVar.FooterWidth = 260;
            }


            if (cBFileName.Checked == true)
            {
                GlobalVar.Scan_PDFfilename = true;
            }
            else if (cBFileName.Checked == false)
            {
                GlobalVar.Scan_PDFfilename = false;
            }


            if (cBPDFpages.Checked == true)
            {
                GlobalVar.Scan_PDFpages = true;
            }
            else if (cBPDFpages.Checked == false)
            {
                GlobalVar.Scan_PDFpages = false;

            }



            this.Close();
        }

        private void PDF_Library_Options_Load(object sender, EventArgs e)
        {
            bBookShelfBackgroundColor.BackColor = GlobalVar.BookShelf_BackgroundColor;
            cBBookCoverImageSize.SelectedIndex = GlobalVar.BookShelf_SelectedSizeIndex;

            if (GlobalVar.Scan_PDFfilename == true)
            {
                cBFileName.Checked = true;
            }
            else if (GlobalVar.Scan_PDFfilename == false)
            {
                cBFileName.Checked = false;
            }

            if (GlobalVar.Scan_PDFpages == true)
            {
                cBPDFpages.Checked = true;
            }
            else if (GlobalVar.Scan_PDFpages == false)
            {
                cBPDFpages.Checked = false;
            }
        }

        private void bBookShelfBackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();

            colorDlg.AllowFullOpen = false;
            colorDlg.AnyColor = true;

            colorDlg.SolidColorOnly = false;

            colorDlg.Color = Color.Red;



            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDlg.Color;
                //_ColorName = c.ToArgb().ToString();
                GlobalVar.BookShelf_BackgroundColor = c;

                bBookShelfBackgroundColor.BackColor = c;

            }
        }
    }
}
