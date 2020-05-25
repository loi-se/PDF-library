using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDF_library
{
     [Serializable()]
   public class PDF_Book_Shelf
    {
        public string Book_Shelf_ID;
        public string name;
        public string folderpath;
        public string subject;
        public string search_terms;
        public string search_terms_active;
        public string cover_imagefolderpath;
        public string subdirs;
        public string directory_scan;

        public int number_of_books;
        public DateTime creationdate;
    }
}
