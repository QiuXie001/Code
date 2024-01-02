using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary
{
    [MetadataType(typeof(metaClass))]
    public partial class Custom
    {
        public class metaClass
        {
            [Display(Name = "用户名")]
            public int Custom_ID { get; set; }
            [Display(Name = "密码")]
            public string Custom_Password { get; set; }
            [Display(Name = "年龄")]
            public string Custom_Age { get; set; }
            [Display(Name = "电话号码")]
            public string Custom_Telephone { get; set; }
            [Display(Name = "昵称")]
            public string Custom_Name { get; set; }
            [Display(Name = "身份证号")]
            public string Custom_IdentityID { get; set; }
        }

    }
}
