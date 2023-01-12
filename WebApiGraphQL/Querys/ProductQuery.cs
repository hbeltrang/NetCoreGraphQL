using Microsoft.EntityFrameworkCore;
using WebApiGraphQL.DBContext;
using WebApiGraphQL.Models;

namespace WebApiGraphQL.Querys
{
    public class ProductQuery
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public List<Product> GetProducts([Service] ApplicationDbContext _context)
        {
            return _context.Products.ToList();
        }       

    }
}
