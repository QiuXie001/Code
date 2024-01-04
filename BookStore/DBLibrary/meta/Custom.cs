﻿using System;
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
            [Display(Name = "顾客ID")]
            public int Custom_ID { get; set; }

            [Display(Name = "用户名")]
            [Required(ErrorMessage = "必填")]
            [StringLength(10, ErrorMessage = "用户名长度不能超过{1}字节！")]
            public string Custom_Name { get; set; }

            [Display(Name = "密码")]
            [Required(ErrorMessage = "必填")]
            public string Custom_Password { get; set; }


            [Display(Name = "年龄")]
            [Range(16, 25)]
            public string Custom_Age { get; set; }


            [Display(Name = "电话号码")]
            [DataType(DataType.PhoneNumber, ErrorMessage = "请输入正确的{0}！")]
            public string Custom_Telephone { get; set; }

            [Display(Name = "身份证号")]
            [StringLength(18, MinimumLength = 18, ErrorMessage = "身份证长度应该为{1}位！")]
            public string Custom_IdentityID { get; set; }
        }

    }
}