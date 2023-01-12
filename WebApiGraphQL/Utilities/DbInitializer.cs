using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApiGraphQL.DBContext;
using WebApiGraphQL.Models;

namespace WebApiGraphQL.Utilities
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;

        public DbInitializer(ApplicationDbContext context)
        {
            _context = context; 
        }

        public void Initialize()
        {
            try
            {
                var pendingMigration = _context.Database.GetPendingMigrations();
                if (pendingMigration.Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }

            var cat1 = _context.Categories.FirstOrDefault(c => c.CategoryName == "Software");
            if (cat1 == null)
            {
                var newCategory = new Category
                {
                    CategoryName = "Software",
                };
                _context.Categories.Add(newCategory);
                _context.SaveChanges();
            }

            var cat2 = _context.Categories.FirstOrDefault(c => c.CategoryName == "Electronics");
            if (cat2 == null)
            {
                var newCategory = new Category
                {
                    CategoryName = "Electronics",
                };
                _context.Categories.Add(newCategory);
                _context.SaveChanges();
            }

            var cat3 = _context.Categories.FirstOrDefault(c => c.CategoryName == "Computers");
            if (cat3 == null)
            {
                var newCategory = new Category
                {
                    CategoryName = "Computers",
                };
                _context.Categories.Add(newCategory);
                _context.SaveChanges();
            }

            if (cat3 == null)
            {
                cat3 = _context.Categories.FirstOrDefault(c => c.CategoryName == "Computers");
            }

            var prod1 = _context.Products.FirstOrDefault(c => c.ProductName == "Laptop HP");
            if (prod1 == null)
            {
                var newProduct = new Product
                {
                    ProductCode = "001",
                    ProductName = "Laptop HP",
                    Price = 800,
                    StockQty = 10,
                    Categoryid = cat3.Id,
                };
                _context.Products.Add(newProduct);
                _context.SaveChanges();
            }

            var prod2 = _context.Products.FirstOrDefault(c => c.ProductName == "Laptop Toshiba");
            if (prod2 == null)
            {
                var newProduct = new Product
                {
                    ProductCode = "002",
                    ProductName = "Laptop Toshiba",
                    Price = 900,
                    StockQty = 12,
                    Categoryid = cat3.Id,
                };
                _context.Products.Add(newProduct);
                _context.SaveChanges();
            }

            var prod3 = _context.Products.FirstOrDefault(c => c.ProductName == "Laptop Lenovo");
            if (prod3 == null)
            {
                var newProduct = new Product
                {
                    ProductCode = "003",
                    ProductName = "Laptop Lenovo",
                    Price = 700,
                    StockQty = 5,
                    Categoryid = cat3.Id,
                };
                _context.Products.Add(newProduct);
                _context.SaveChanges();
            }

        }

    }
}
