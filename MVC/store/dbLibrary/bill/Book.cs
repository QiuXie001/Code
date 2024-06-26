﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace db.bill
{
    public class Book
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
        public static List<SelectListItem> getBookTypes()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "计算机", Value = "computer" });
            list.Add(new SelectListItem() { Text = "文学", Value = "literature" });
            list.Add(new SelectListItem() { Text = "地理", Value = "geography" });

            return list;
        }
        public static List<SelectListItem> getBookTypes(string oldValue)
        {
            if (oldValue == null)
            {
                oldValue = "";
            }

            List<string> selectedList = oldValue.Split(',').ToList<string>();

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "计算机", Value = "computer" });
            list.Add(new SelectListItem() { Text = "文学", Value = "literature" });
            list.Add(new SelectListItem() { Text = "地理", Value = "geography" });

            foreach (var item in list)
            {
                if (selectedList.Contains(item.Value))
                    item.Selected = true;
            }
            return list;
        }

        public static List<SelectListItem> getBookTags(string oldValue)
        {
            if (oldValue == null)
            {
                oldValue = "";
            }

            List<string> selectedList = oldValue.Split(',').ToList<string>();

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "促销", Value = "sale" });
            list.Add(new SelectListItem() { Text = "畅销", Value = "best" });
            list.Add(new SelectListItem() { Text = "清仓", Value = "clear" });

            foreach (var item in list)
            {
                if (selectedList.Contains(item.Value))
                    item.Selected = true;
            }
            return list;
        }
        public static List<SelectListItem> getBookTags()
        {

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "促销", Value = "sale" });
            list.Add(new SelectListItem() { Text = "畅销", Value = "best" });
            list.Add(new SelectListItem() { Text = "清仓", Value = "clear" });

            return list;
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
            db.Entry<db.Books>(entry).State = System.Data.EntityState.Unchanged;
            //List<String> list = System.Web.HttpContext.Current.Request.Form.AllKeys.ToList<string>();
            List<string> list = System.Web.HttpContext.Current.Request.Form.AllKeys.ToList<string>();
            foreach (var p in entry.GetType().GetProperties())
            {
                if (list.Contains(p.Name))
                    db.Entry(entry).Property(p.Name).IsModified = true;
            }
            //db.Entry(entry).Property("Price").IsModified = true;
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
        public static void batchUpdate(
            List<string> bookIdList,
            List<string> priceList,
            List<string> booktypeList,
            Dictionary<string, string> dicTags)
        {
            mvcStudyEntities dc = new mvcStudyEntities();
            for (int iIndex = 0; iIndex < bookIdList.Count; ++iIndex)
            {
                int bookId = Convert.ToInt32(bookIdList[iIndex]);
                Books entry = dc.Books.SingleOrDefault(a => a.BookId == bookId);
                entry.Price = Convert.ToDecimal(priceList[iIndex]);
                entry.BookType = Convert.ToString(booktypeList[iIndex]);
                entry.BookTag = dicTags[bookIdList[iIndex]];
            }
            dc.SaveChanges();
        }
        public static void batchDelete(List<string> bookList)
        {
           mvcStudyEntities dc = new mvcStudyEntities();
            for (int iIndex = 0; iIndex < bookList.Count; ++iIndex)
            {
                if (bookList[iIndex] == "")
                {
                    break;
                }
                int bookId = Convert.ToInt32(bookList[iIndex]);
                Books entry = dc.Books.SingleOrDefault(a => a.BookId == bookId);
                dc.Books.Remove(entry);
            }
            dc.SaveChanges();
        }


    }
}
