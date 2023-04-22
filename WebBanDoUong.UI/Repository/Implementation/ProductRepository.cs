using Microsoft.EntityFrameworkCore;
using WebBanDoUong.UI.Data;
using WebBanDoUong.UI.Models.Domain;
using WebBanDoUong.UI.Repository.Abstract;

namespace WebBanDoUong.UI.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext db;

        public ProductRepository(DatabaseContext db)
        {
            this.db = db;
        }
        public bool Add(Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<Product> GetAll()
        {
            var products = db.Products.Include("Category").ToList();
            return products;
        }

        public Product? GetById(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return null;
            }
            return product;
        }
    }
}
