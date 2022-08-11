using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3},
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
                new Product{ProductId=5, CategoryId=2, ProductName="Fare", UnitPrice=85, UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            if (productToDelete != null)
            {
                _products.Remove(productToDelete);
            }
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            if (productToUpdate != null)
            {
                // Manuel 
                //productToUpdate.ProductName = product.ProductName;
                //productToUpdate.CategoryId = product.CategoryId;
                //productToUpdate.ProductId = product.ProductId;
                //productToUpdate.UnitPrice = product.UnitPrice;
                //productToUpdate.UnitsInStock = product.UnitsInStock;

                // If the properties of the Product is changed by us, we need to refactor
                // the above code.
                // But if we use the Reflection, we do not have to refactor here again when we
                // change the properties of the Product entity.

                // System.Reflection
                productToUpdate.GetType().GetProperties().ToList().ForEach(pForProductToUpdate =>
                {
                    product.GetType().GetProperties().ToList().ForEach(pForProduct =>
                    {
                        if (pForProductToUpdate.Name == pForProduct.Name)
                        {
                            pForProductToUpdate.SetValue(productToUpdate, pForProduct.GetValue(product));
                        }
                    });
                });

                // Below code is same with the above code

                //foreach (var pForProductToUpdate in productToUpdate.GetType().GetProperties().ToList())
                //{
                //    foreach (var pForProduct in product.GetType().GetProperties().ToList())
                //    {
                //        if (pForProductToUpdate.Name == pForProduct.Name)
                //        {
                //            pForProductToUpdate.SetValue(productToUpdate, pForProduct.GetValue(product));
                //        }
                //    }
                //}
            }
        }
    }
}
