using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary
{
    public partial class Order
    {
        [Display(Name = "顾客ID")]
        public int Id { get; set; }

        [Display(Name = "订单编号")]
        public long OrderID { get; set; }

        [Display(Name = "收货地址")]
        [Required(ErrorMessage = "{0}必填")]
        public string Address { get; set; }

        [Display(Name = "商品ID")]
        public string BookID { get; set; }

        [Display(Name = "数量")]
        public Nullable<int> Num { get; set; }

        [Display(Name = "订单金额")]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "买家ID")]
        public int CustomID { get; set; }

        [Display(Name = "收货手机号")]
        [Required(ErrorMessage = "{0}必填")]
        public string Custom_Telephone { get; set; }

        [Display(Name = "下单时间")]
        public DateTime? OrderTime { get; set; }

        [Display(Name = "付款")]
        public bool? ClearOrNot { get; set; }

        [Display(Name = "签收")]
        public bool? ReceiptOrNot { get; set; }

    }
}
