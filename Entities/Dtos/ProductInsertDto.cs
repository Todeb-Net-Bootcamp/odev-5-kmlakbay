using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ProductInsertDto
    {        
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public int GenderId { get; set; }
        public ICollection<ProductDetailInsertDto> Details { get; set; }
    }
}
