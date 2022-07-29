using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ProductDetailInsertDto
    {
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public int SizeId { get; set; }
    }
}
