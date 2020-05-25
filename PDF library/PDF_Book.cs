using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDF_library
{
     [Serializable()]
    public class PDF_Book
    {
        public string Book_Shelf_ID;
        public string Book_ID;
        public int rating;
        public string title;
        public string writer;
        public string subject;

        public string description;
        public string tags;
        public DateTime publishdate;
        public string filesize;

        public int number_of_pages;
        public string filepath;

        public string cover_imagepath;
        //public System.Drawing.Image cover_image;
        public string filename;

        public string PDF_version;
     
    }
}
