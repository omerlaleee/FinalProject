﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int categoryId);
        List<Product> GetByUnitPrice(decimal min, decimal max);
        Product GetById(int productId);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        List<ProductDetailDto> GetProductDetails();
    }
}
