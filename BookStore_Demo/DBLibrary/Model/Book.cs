using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary
{
    public partial class Book
    {
        [Display(Name = "书籍编号")]
        public int Id { get; set; }

        [Display(Name = "作者")]
        [Required(ErrorMessage = "{0}必填")]
        public string AuthorName { get; set; }

        [Display(Name = "书名")]
        [Required(ErrorMessage = "{0}必填")]
        public string Title { get; set; }

        [Display(Name = "单价")]
        [Required(ErrorMessage = "{0}必填")]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "封面链接")]
        public string BookCoverUrl { get; set; }

        [Display(Name = "书籍类别号")]
        [Required(ErrorMessage = "{0}必填")]
        public int BookTypeID { get; set; }

        [Display(Name = "书籍标签")]
        [Required(ErrorMessage = "{0}必填")]
        public string BookTag { get; set; }

        [Display(Name = "书籍类别")]
        [Required(ErrorMessage = "{0}必填")]

        public virtual BookType BookTypes { get; set; }


    }
}
