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
        public static List<Books> SearchBooks(string str)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            List<Books> books = new List<Books>();
            var entry = db.Books.Where(b => b.Title.Contains(str) );
            foreach (var i in entry)
            { 
                if(i.Title.Contains(str))
                books.Add(i);
            }
            return books;
        }
        public static List<Books> SelectBooks(string TypeName)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            List<Books> books = new List<Books>();
            var types = db.BookTypes.ToList();
            foreach(var i in types)
            {
                if (i.BookType == TypeName)
                {
                    var entry = db.Books.Where(b => b.BookTypeID == i.BookTypeID);
                    foreach (var j in entry)
                    { 
                        books.Add(j);
                    }
                    break;
                }
            }
            
            return books;
        }
        public static List<BookTypes> GetTypes()
        {
            mvcStudyEntities db = new mvcStudyEntities();
            List<BookTypes> types = db.BookTypes.ToList<BookTypes>();
            return types;
        }
        public static DBLibrary.Books GetBooks(int id)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            var entry = db.Books.FirstOrDefault(b => b.Book_ID == id);
            DBLibrary.Books books = new DBLibrary.Books();
            books = entry;
            return books;
        }
        public static void Update(DBLibrary.Books entry,int id)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            entry.Book_ID = id;
            db.Books.Attach(entry);
            db.Entry(entry).State = EntityState.Modified;
            db.SaveChanges();
        }


        public static void Regist(DBLibrary.Books entry)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            db.Books.Add(entry);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
        }

        //选取
        public static List<Books> Search(int id, string title)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            var entry = db.Books.Where(b => b.Book_ID == id || b.Title == title);
            List<Books> list = new List<Books>();
            int j = 0;
            foreach (var i in entry)
            {
                list.Add(i);
                j++;
            }
            return list;
        }
        public static void Delete(int id)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            var books = db.Books.FirstOrDefault(b => b.Book_ID == id);
            db.Books.Remove(books);
            db.SaveChanges();

        }

    }
}
