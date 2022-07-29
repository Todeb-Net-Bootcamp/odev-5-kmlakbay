using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ProductDetailDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }
        public int UnitsInStock { get; set; }
        public decimal UnitPrice{ get; set; }
        public bool IsContinue { get; set; }
    }
}
