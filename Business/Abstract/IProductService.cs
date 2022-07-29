using Core.Utilities.Results.Abstract;
using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        public IDataResult<IEnumerable<Product>> GetAll();

        IDataResult<Product> GetById(int id);
        public IResult Insert(ProductInsertDto p);
        public IResult Update(Product p);
        public IResult Delete(Product p);
    }
}
