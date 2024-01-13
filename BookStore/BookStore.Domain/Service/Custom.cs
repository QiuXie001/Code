using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.DBStandard;
using BookStore.DBStandard.Models;

namespace BookStore.Domain.Service
{
    public class CustomService
    {
        public MvcStudyContext DbContext { get; set; }
        public CustomService(MvcStudyContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Register(Custom custom)
        {
            DbContext.Customs.Add(custom);
            DbContext.SaveChanges();
        }
    }
}
