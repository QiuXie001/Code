using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DBLibrary.Bll
{
    public class BookService
    {
        public static List<DBLibrary.Book> GetBooks()
        {
            StoreContext db = new StoreContext();
            List<DBLibrary.Book> books = db.Books.ToList();
            return books;
        }
        public static List<DBLibrary.Book> SearchBooks(string str)
        {
            StoreContext db = new StoreContext();
            List<DBLibrary.Book> books = new List<DBLibrary.Book>();
            var entry = db.Books.Where(b => b.Title.Contains(str) );
            foreach (var i in entry)
            { 
                if(i.Title.Contains(str))
                books.Add(i);
            }
            return books;
        }
        public static List<DBLibrary.Book> SelectBooks(string typeName)
        {
            StoreContext db = new StoreContext();
            var type = db.BookTypes.FirstOrDefault(t=>t.Name.Contains(typeName));

            if (type != null)
            {
                return db.Books.Where(b => b.BookTypeID == type.Id).ToList();
            }
            else
            {
                return null;
            }

            //List<Books> books = new List<Books>();
            //var types = db.BookTypes.ToList();
            //foreach(var i in types)
            //{
            //    if (i.BookType == typeName)
            //    {
            //        var entry = db.Books.Where(b => b.BookTypeID == i.BookTypeID);
            //        foreach (var j in entry)
            //        { 
            //            books.Add(j);
            //        }
            //        break;
            //    }
            //}
            
            //return books;
        }
        public static List<BookType> GetTypes()
        {
            StoreContext db = new StoreContext();
            List<BookType> types = db.BookTypes.ToList<BookType>();
            return types;
        }
        public static DBLibrary.Book GetBooks(int id)
        {
            StoreContext db = new StoreContext();
            var entry = db.Books.FirstOrDefault(b => b.Id == id);
            DBLibrary.Book books = new DBLibrary.Book();
            books = entry;
            return books;
        }
        public static void Update(DBLibrary.Book entry,int id)
        {
            StoreContext db = new StoreContext();
            entry.Id = id;
            db.Books.Attach(entry);
            db.Entry(entry).State = EntityState.Modified;
            db.SaveChanges();
        }


        public static void Regist(DBLibrary.Book entry)
        {
            StoreContext db = new StoreContext();
            db.Books.Add(entry);
            db.Configuration.ValidateOnSaveEnabled = false;
            db.SaveChanges();
        }

        //选取
        public static List<DBLibrary.Book> Search(int id, string title)
        {
            StoreContext db = new StoreContext();
            var entry = db.Books.Where(b => b.Id == id || b.Title == title);
            List<DBLibrary.Book> list = new List<DBLibrary.Book>();
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
            StoreContext db = new StoreContext();
            var books = db.Books.FirstOrDefault(b => b.Id == id);
            db.Books.Remove(books);
            db.SaveChanges();

        }

    }
}
