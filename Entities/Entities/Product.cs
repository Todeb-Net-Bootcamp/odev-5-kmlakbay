using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Product:IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public int GenderId { get; set; }

        public Category Category { get; set; }
        public Color Color { get; set; }
        public Brand Brand { get; set; }
        public Gender Gender { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
