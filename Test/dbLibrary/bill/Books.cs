using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dbLibrary.bill
{
    internal class Books
    {
        public static List<Books> GetBooks()
        {
            mvcStudyEntities db = new mvcStudyEntities();
            List<Books> books = db.Books.ToList<Books>();
            return books;
        }

        public static List<Detail> GetDetail()
        {
            mvcStudyEntities db = new mvcStudyEntities();
            List<Detail> detail = db.Detail.ToList<Detail>();
            return detail;
        }
        public static Books GetEntry(int bookid)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            Books testBook = db.Books.SingleOrDefault(a => a.BookId == bookid);
            return testBook;
        }
    }
}
