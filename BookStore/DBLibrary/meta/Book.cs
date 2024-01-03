using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary
{
    [MetadataType(typeof(metaClass))]
    public partial class Books
    {
        public class metaClass
        {
            [Display(Name = "书籍编号")]
            public int Book_ID { get; set; }

            [Display(Name = "作者")]
            public string AuthorName { get; set; }

            [Display(Name = "书名")]
            public string Title { get; set; }

            [Display(Name = "单价")]
            public Nullable<decimal> Price { get; set; }

            [Display(Name = "封面链接")]
            public string BookCoverUrl { get; set; }

            [Display(Name = "书籍类别号")]
            public int BookTypeID { get; set; }

            [Display(Name = "书籍标签")]
            public string BookTag { get; set; }

            [Display(Name = "书籍类别")]

            public virtual BookTypes BookTypes { get; set; }


        }
    }
}
