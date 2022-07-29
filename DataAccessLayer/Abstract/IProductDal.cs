using Core.DataAccess;
using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        public ICollection<ProductDetailDto> GetProductDetailsByCategoryId(int categoryId);
    }
}
