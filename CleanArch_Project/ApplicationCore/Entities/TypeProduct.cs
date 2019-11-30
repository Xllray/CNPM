using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class TypeProduct : IAggregateRoot
    {
        public TypeProduct()
        {
            Product = new HashSet<Product>();
        }

        public int TypeProductId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
