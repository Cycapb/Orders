using System;

namespace Domain
{
    public class OrderToUnload
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ProductQuantity { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
