using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int? DetailProductId { get; set; }
        public int? DetailOrderId { get; set; }
        public int? Quantity { get; set; }

        public virtual Order DetailOrder { get; set; }
        public virtual Product DetailProduct { get; set; }
    }
}
