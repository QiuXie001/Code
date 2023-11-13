using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace db.bill
{
    public class books
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

        public static void insert1(db.Books entry)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            db.Books.Add(entry);
            
            db.SaveChanges();
        }
        public static void insert2(string bookname, string title, Nullable<decimal> Price)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            db.Books books = new Books();
            books.Title = title;
            books.Price = Price;
            books.AuthorName = bookname;
            db.Books.Add(books);
            db.SaveChanges();
        }
        public static void update1(db.Books entry)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            db.Entry<db.Books>(entry).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }
        public static void update2(db.Books entry)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            db.Entry<db.Books>(entry).State = System.Data.EntityState.Unchanged;
            //List<String> list = System.Web.HttpContext.Current.Request.Form.AllKeys.ToList<string>();
            db.Entry(entry).Property("Price").IsModified = true;
            db.SaveChanges();
        }
        public static void update3(int bookid,string AuthorName,string title, Nullable<decimal> Price)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            db.Books books = db.Books.SingleOrDefault(a => a.BookId == bookid);
            books.Title = title;
            books.Price = Price;
            books.AuthorName = AuthorName;
            db.SaveChanges();
        }
        public static void delete(int bookid)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            db.Books books = db.Books.SingleOrDefault(a => a.BookId == bookid);
            db.Books.Remove(books);
            db.SaveChanges();
        }

    }
}
