using DataAccessLayer.Contexts;
using DataAccessLayer.EntityFramework;
using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    internal class Program
    {
        
        
        static void Main(string[] args)
        {
            using (BootcampDbContext context = new BootcampDbContext())
            {
                var categories = context.Categories.ToList();
                ListProductsOfCategory(categories.Where(c => c.ParentCategoryId == null).ToList());
            }            
            
        }
        static int tabCount = 0;
        static void ListProductsOfCategory(List<Category> cats) 
        {            
            foreach (var cat in cats)
            {
                WriteCategory(cat);
                if (cat.ChildCategories!=null)
                {
                    tabCount++;
                    ListProductsOfCategory(cat.ChildCategories.ToList());
                    tabCount--;
                }              
            }
            
        }

        static void WriteCategory(Category cat)
        {
            for (int i = 0; i < tabCount; i++)
            {
                Console.Write("\t");
            }
            Console.WriteLine("Cat:{0}",  cat.Name);
            tabCount++;
            WriteProducts(cat.Id);
            tabCount--;
        }

        static void WriteProducts(int categoryId) 
        {
            //EfProductDal productDal = new EfProductDal();
            DataAccessLayer.Concrete.EntityFramework.EfProductDal productDal = new DataAccessLayer.Concrete.EntityFramework.EfProductDal();

            List<ProductDetailDto> list = productDal.GetProductDetailsByCategoryId(categoryId).ToList();
            if (list.Count>0)
            {
                foreach (var item in list)
                {
                    for (int i = 0; i < tabCount; i++)
                    {
                        Console.Write("\t");
                    }
                    Console.WriteLine("Name:{0} | Color:{1} | Brand:{2} | Gender:{3} | Size:{4} | UnitPrice:{5} | UnitsInStock:{6}"
                        , item.Name, item.Color, item.Brand,item.Gender,item.Size,item.UnitPrice,item.UnitsInStock);
                    
                }
            }
        }
    }
}
