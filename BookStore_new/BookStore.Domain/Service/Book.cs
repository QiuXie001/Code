using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BookStore.DBStandard;
using BookStore.DBStandard.Models;

namespace BookStore.Domain.Service
{
    public class BookService
    {
        public MvcStudyContext DbContext { get; set; }
        public BookService(MvcStudyContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<Book> GetBooks()
        {
            List<Book> books = DbContext.Books.ToList();
            return books;
        }
    }
}
