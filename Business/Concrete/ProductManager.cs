using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Extensions.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        IProductDetailDal _productDetailDal;
        IMapper _mapper;
        public ProductManager(IProductDal productDal,IProductDetailDal productDetailDal,IMapper mapper)
        {
            _productDal = productDal;
            _productDetailDal = productDetailDal;
            _mapper = mapper;
        }
        public IResult Delete(Product p)
        {
            _productDal.Delete(p);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<IEnumerable<Product>> GetAll()
        {
            var products = _productDal.GetAll();
            return new SuccessDataResult<IEnumerable<Product>>(products,Messages.ProductsListed);
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == id), Messages.ProductsListed);
        }

        public IResult Insert(ProductInsertDto pDto)
        {
            var validator = new ProductInsertDtoValidator();
            var valid = validator.Validate(pDto).ThrowIfExeption();
            if (!valid.Success) return valid;            
            Product product = _mapper.Map<Product>(pDto);

            product = _productDal.Add(product);
            foreach (var item in pDto.Details)
            {
                ProductDetail productDetail =_mapper.Map<ProductDetail>(item);
                _productDetailDal.Add(productDetail);

            }
            
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Update(Product p)
        {
            _productDal.Update(p);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
