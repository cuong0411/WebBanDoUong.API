using WebBanDoUong.UI.Models.Domain;

namespace WebBanDoUong.UI.Repository.Abstract
{
    public interface ICategoryRepository
    {
        bool Add(Category model);
        Category? GetById(int id);
        List<Category> GetAll();
    }
}
