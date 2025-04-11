using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace 订单管理
{
    public class OrderDetails
    {
        [Required(ErrorMessage = "订单ID是必填项")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "产品名称是必填项")]
        [StringLength(100, ErrorMessage = "产品名称不能超过100个字符")]
        public required string ProductName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "数量必须大于0")]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "价格必须大于0")]
        public decimal Price { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is OrderDetails details)
            {
                return ProductName == details.ProductName && Quantity == details.Quantity && Price == details.Price;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductName, Quantity, Price);
        }

        public override string ToString()
        {
            return $"产品: {ProductName}, 数量: {Quantity}, 价格: {Price}";
        }
    }
}