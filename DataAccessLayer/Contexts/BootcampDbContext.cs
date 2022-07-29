using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contexts
{
    public class BootcampDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"server=NT00783;Database=kemalAkbayFinalProjectDB;Trusted_Connection=true"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
            .HasData(
                new Brand() { Id = 1, Name = "Mavi" }
                , new Brand() { Id = 2, Name = "Avva" }
                , new Brand() { Id = 3, Name = "Loft" }
                , new Brand() { Id = 4, Name = "Adidas" }
                , new Brand() { Id = 5, Name = "Nike" }
                , new Brand() { Id = 6, Name = "Pegasus" }
            );
            modelBuilder.Entity<Category>()
            .HasData(
                new Category() { Id = 1, Name = "Dress", Description = "Dress Category" }
                , new Category() { Id = 2, Name = "Tshirt", Description = "Tshirt Category", ParentCategoryId = 1 }
                , new Category() { Id = 3, Name = "Pants", Description = "Pants Category", ParentCategoryId = 1 }
                , new Category() { Id = 4, Name = "Shoe", Description = "Shoe Category" }
                , new Category() { Id = 5, Name = "Sneakers", Description = "Sneakers Category", ParentCategoryId = 4 }
                , new Category() { Id = 6, Name = "Slipper", Description = "Slipper Category", ParentCategoryId = 4 }
                , new Category() { Id = 7, Name = "Sandals", Description = "Sandals Category", ParentCategoryId = 4 }
                , new Category() { Id = 8, Name = "Book", Description = "Book Category" }
                , new Category() { Id = 9, Name = "History", Description = "History Category", ParentCategoryId = 8 }
                , new Category() { Id = 10, Name = "Economy", Description = "Economy Category", ParentCategoryId = 8 }
                , new Category() { Id = 11, Name = "Programming", Description = "Programming Category", ParentCategoryId = 8 }
                , new Category() { Id = 12, Name = "Jean", Description = "Jean Category", ParentCategoryId = 3 }
            );
            modelBuilder.Entity<Color>()
            .HasData(
                new Color { Id = 1, Name = "Black" }
                , new Color { Id = 2, Name = "Blue" }
                , new Color { Id = 3, Name = "Red" }
                , new Color { Id = 4, Name = "NavyBlue" }
                , new Color { Id = 5, Name = "Pink" }
            );
            modelBuilder.Entity<Gender>()
            .HasData(
                new Gender { Id = 1, Name = "Male" }
                , new Gender { Id = 2, Name = "Female" }
                , new Gender { Id = 3, Name = "Boy" }
                , new Gender { Id = 4, Name = "Girl" }
                , new Gender { Id = 5, Name = "Unisex" }
            );
            modelBuilder.Entity<Size>()
            .HasData(
                new Size { Id = 1, Name = "Xs" }
                , new Size { Id = 2, Name = "S" }
                , new Size { Id = 3, Name = "M" }
                , new Size { Id = 4, Name = "L" }
                , new Size { Id = 5, Name = "XL" }
                , new Size { Id = 6, Name = "XXL" }
                , new Size { Id = 7, Name = "37" }
                , new Size { Id = 8, Name = "38" }
                , new Size { Id = 9, Name = "39" }
                , new Size { Id = 10, Name = "40" }
                , new Size { Id = 11, Name = "41" }
                , new Size { Id = 12, Name = "42" }
                , new Size { Id = 13, Name = "43" }
                , new Size { Id = 14, Name = "44" }
                , new Size { Id = 15, Name = "45" }
                , new Size { Id = 16, Name = "25/27" }
                , new Size { Id = 17, Name = "26/27" }
                , new Size { Id = 18, Name = "27/27" }
                , new Size { Id = 19, Name = "27/29" }
            );
            modelBuilder.Entity<Product>()
            .HasData(
                new Product { Id = 1, CategoryId=2,Name="Basic Tshirt",ColorId=4,BrandId=1,GenderId=1 }
                , new Product { Id = 2, CategoryId = 5, Name = "Star Runner 3 Sneakers", ColorId = 1, BrandId = 5, GenderId = 5 }
                , new Product { Id = 3, CategoryId = 12, Name = "Women Pants", ColorId = 1, BrandId = 3, GenderId = 2 }
            );
            modelBuilder.Entity<ProductDetail>()
            .HasData(
                new ProductDetail{Id=1,ProductId=1,UnitsInStock=10,UnitPrice=100,IsContinue=true,SizeId=2}
                ,new ProductDetail{Id=2,ProductId=1,UnitsInStock=5,UnitPrice=100,IsContinue= true, SizeId=3}
                ,new ProductDetail{Id=3,ProductId=1,UnitsInStock=3,UnitPrice=100,IsContinue= true, SizeId=4}
                ,new ProductDetail{Id=4,ProductId=2,UnitsInStock=50,UnitPrice=790,IsContinue= true, SizeId=13}
                ,new ProductDetail{Id=5,ProductId=2,UnitsInStock=5,UnitPrice=750,IsContinue= true, SizeId=14}
                ,new ProductDetail{Id=6,ProductId=3,UnitsInStock=20,UnitPrice=299.95m,IsContinue= true, SizeId=18}
                ,new ProductDetail{Id=7,ProductId=3,UnitsInStock=18,UnitPrice = 299.95m, IsContinue= true, SizeId=19}
            );
        }
    }
}
