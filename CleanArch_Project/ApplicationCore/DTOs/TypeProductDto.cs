using ApplicationCore.Entities;
using System;
using System.Collections.Generic;

namespace ApplicationCore.DTOs
{
    public partial class TypeProductDto
    {
        public TypeProductDto()
        {
            Product = new HashSet<ProductDto>();
        }

        public int TypeProductId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<ProductDto> Product { get; set; }
    }
}
