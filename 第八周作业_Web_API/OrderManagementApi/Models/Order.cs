using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace 订单管理
{
    public class Order
    {
        [Key]
        [Required(ErrorMessage = "订单ID是必填项")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "客户名称是必填项")]
        [StringLength(100, ErrorMessage = "客户名称不能超过100个字符")]
        public required string Customer { get; set; }

        public List<OrderDetails> Details { get; set; } = new List<OrderDetails>();

        [NotMapped]
        public decimal TotalAmount => Details.Sum(d => d.Quantity * d.Price);

        public override bool Equals(object? obj)
        {
            if (obj is Order order)
            {
                return OrderId == order.OrderId && Customer == order.Customer && Details.SequenceEqual(order.Details);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OrderId, Customer, Details);
        }

        public override string ToString()
        {
            return $"订单ID: {OrderId}, 客户: {Customer}, 总金额: {TotalAmount}\n明细:\n{string.Join("\n", Details)}";
        }
    }
}