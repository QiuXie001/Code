using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db
{
    [MetadataType(typeof(metaClass))]
    public partial class Account
    {
        public class metaClass
        {
            public int UserID { get; set; }
            [Display(Name = "密码")]
            [Required(ErrorMessage = "{0}必填")]
            public string Password { get; set; }
            [Display(Name = "年龄")]
            [Range(16, 25)]
            public string Age { get; set; }
            [Display(Name = "邮箱")]
            [DataType(DataType.EmailAddress, ErrorMessage = "请输入正确的邮箱！")]
            public string Email { get; set; }
            [Display(Name = "身份证")]
            [Required(ErrorMessage = "{0}必填")]
            public string identityID { get; set; }
            [Display(Name = "手机号")]
            [Required(ErrorMessage = "{0}必填")]
            [DataType(DataType.PhoneNumber, ErrorMessage = "请输入正确的手机号！")]
            public string telephone { get; set; }
        }
    }
}
