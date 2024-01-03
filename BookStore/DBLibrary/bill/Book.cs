using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DBLibrary.bill
{
    public class Book
    {
        public static List<Books> GetBooks()
        {
            mvcStudyEntities db = new mvcStudyEntities();
            List<Books> books = db.Books.ToList<Books>();
            return books;
        }
        public static List<BookTypes> GetTypes()
        {
            mvcStudyEntities db = new mvcStudyEntities();
            List<BookTypes> types = db.BookTypes.ToList<BookTypes>();
            return types;
        }
        public static void Update(Books entry)
        {
            
        }

    }
}
