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
        public bool Add(Product model)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
