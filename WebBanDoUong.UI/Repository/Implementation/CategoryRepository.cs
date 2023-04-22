using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebBanDoUong.UI.Data;
using WebBanDoUong.UI.Models.Domain;
using WebBanDoUong.UI.Repository.Abstract;

namespace WebBanDoUong.UI.Repository.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext db;

        public CategoryRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public bool Add(Category model)
        {
            try
            {
                db.Categories.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public Category? GetById(int id)
        {
            var category = db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return null;
            }
            return category;
        }

        public List<Product>? GetProductsById(int id)
        {
            var products = db.Products.Where(c => c.Category.Id == id).ToList();
            if (products.Count == 0)
            {
                return null;
            }
            return products;
        }
    }
}
