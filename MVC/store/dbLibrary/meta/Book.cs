using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db
{
    [MetadataType(typeof(metaClass))]
    public partial class Books
    {
        public class metaClass
        {
            [Display(Name = "图书编号")]
            public int BookId { get; set; }
            [Display(Name = "作者")]
            public string AuthorName { get; set; }
            [Display(Name = "图书")]
            public string Title { get; set; }
            [Display(Name = "价格")]
            public Nullable<decimal> Price { get; set; }
            [Display(Name = "封面")]
            public string BookCoverUrl { get; set; }
            [Display(Name = "图书类别")]
            public string BookType { get; set; }
            [Display(Name = "标签")]
            public string BookTag { get; set; }

        }
    }
}
