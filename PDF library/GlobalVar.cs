using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace PDF_library
{
    public static class GlobalVar
    {

        // Maximum number of books on a bookshelf:
        public static int MaxBookshelfBooks = 500;
        public static int MaxBookTotal = 1500;

        /// <summary>
        /// Access routine for global variable.
        /// </summary>
        public static string _PDF_BookFilePath;
        public static List<PDF_Book> Alreadyscanned_Books = new List<PDF_Book>();

        public static PDF_Book _PDF_Book_Changed;

        public static Boolean _PDF_Book_Changed_Boolean = false;
        public static Boolean _PDF_Book_Read_Boolean = false;
        public static PDF_Book _PDF_Book_Opened; 
        public static Boolean _PDF_Book_Del_Boolean = false;

        public static Boolean _PDF_Book_Bookshelf_Changed_Boolean = false;
        public static string _PDF_Book_Bookshelf_old_ID = "";
        public static string _PDF_Book_Bookshelf_new_ID = "";
        public static string _PDF_Book_Bookshelf_old_coverimagepath = "";

        public static string _PDF_Book_Read_Filepath = "";


        // Bookshelf view options:

        public static int Book_location_X = 10;
        public static int Book_location_Y = 30;
        public static int Bookheight = 190;
        public static int Bookwidth = 130;


        public static int Footer_Location_X = 10;
        public static int Footer_Location_Y = Book_location_Y + Bookheight + 4;
        public static int FooterHeight = 50;
        public static int FooterWidth = 130;
        public static int FooterFontSize = 8;

        public static int BookShelf_HorizontalScrollbar_ExtraHeight = 15;

        public static int Book_offset = 20;

        public static int BookShelf_location_X;
        public static int BookShelf_location_Y;
        public static int BookShelfheight = 290;
        public static int BookShelfWidth;

        public static int BookShelf_SelectedSizeIndex = 3;

        public static Color BookShelf_BackgroundColor = Color.LightGray;


        // Scan Options:

        public static Boolean Scan_PDFfilename = true;
        public static Boolean Scan_PDFpages = true;



        public static bool IsValidXmlString(string text)
        {
            try
            {
                XmlConvert.VerifyXmlChars(text);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
