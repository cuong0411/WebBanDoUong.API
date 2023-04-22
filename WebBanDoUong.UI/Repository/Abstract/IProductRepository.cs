﻿using WebBanDoUong.UI.Models.Domain;

namespace WebBanDoUong.UI.Repository.Abstract
{
    public interface IProductRepository
    {
        bool Add(Product model);
        List<Product> GetAll();
    }
}
