using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary
{
    public partial class Admin
    {
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "{0}必填")]
        public int Id { get; set; }

        [Display(Name = "昵称")]
        [Required(ErrorMessage = "{0}必填")]
        [StringLength(20, ErrorMessage = "昵称长度不能超过{1}字节！")]
        public string Name { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "{0}必填")]
        public string Password { get; set; }

        [Display(Name = "年龄")]
        [Range(16, 25)]
        public string Age { get; set; }

        public string HeadShotUrl { get; set; }


        [Display(Name = "电话号码")]
        [Required(ErrorMessage = "必填")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "请输入正确的{0}！")]
        public string Telephone { get; set; }

        [Display(Name = "身份证号")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "身份证长度应该为{1}位！")]
        public string IdentityID { get; set; }
    }
}

