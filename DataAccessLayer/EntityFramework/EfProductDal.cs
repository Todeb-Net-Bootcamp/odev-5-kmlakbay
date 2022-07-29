using DataAccessLayer.Contexts;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal
    {
        public List<ProductDetailDto> GetProductDetailsByCategoryId(int categoryId)
        {
            using (BootcampDbContext context = new BootcampDbContext())
            {
                var result = from p in context.Products
                             join pd in context.ProductDetails on p.Id equals pd.ProductId
                             join c in context.Categories on p.CategoryId equals c.Id
                             join b in context.Brands on p.BrandId equals b.Id
                             join col in context.Colors on p.ColorId equals col.Id
                             join g in context.Genders on p.GenderId equals g.Id
                             join s in context.Sizes on pd.SizeId equals s.Id
                             where c.Id==categoryId
                             select new ProductDetailDto {Id=p.Id,Name=p.Name,UnitPrice=pd.UnitPrice,UnitsInStock=pd.UnitsInStock,CategoryId=c.Id,Category=c.Name,Brand=b.Name,Color=col.Name,Size=s.Name, Gender=g.Name,IsContinue=pd.IsContinue  };
                return result.ToList();
            }
        }
    }
}
