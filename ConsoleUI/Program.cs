using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

// ProductManager productManager = new ProductManager(new InMemoryProductDal());
ProductManager productManager = new ProductManager(new EfProductDal());

ProductTest(productManager);

static void ProductTest(ProductManager productManager)
{
    //foreach (var item in productManager.GetAll())
    //{
    //    Console.WriteLine(item.ProductName);
    //}

    //Console.WriteLine("-----------------------------------------");

    //productManager.Add(new Product { ProductId = 6, CategoryId = 3, ProductName = "Hediyelik Eşya", UnitPrice = 100, UnitsInStock = 33 });

    //foreach (var item in productManager.GetAll())
    //{
    //    Console.WriteLine(item.ProductName);
    //}

    //Console.WriteLine("-----------------------------------------");

    //productManager.Delete(new Product { ProductId = 2 });

    //foreach (var item in productManager.GetAll())
    //{
    //    Console.WriteLine(item.ProductName);
    //}

    //Console.WriteLine("-----------------------------------------");

    //productManager.Update(new Product { ProductId = 6, CategoryId = 3, ProductName = "Hediyelik Eşya Updated", UnitPrice = 100, UnitsInStock = 33 });

    //foreach (var item in productManager.GetAll())
    //{
    //    Console.WriteLine(item.ProductName);
    //}

    //Console.WriteLine("-----------------------------------------");
    //foreach (var item in productManager.GetAllByCategoryId(2))
    //{
    //    Console.WriteLine(item.ProductName + " / " + item.CategoryId);
    //}

    //Console.WriteLine("-----------------------------------------");
    //foreach (var item in productManager.GetByUnitPrice(100, 300))
    //{
    //    Console.WriteLine(item.ProductName + " / " + item.UnitPrice);
    //}

    Console.WriteLine("-----------------------------------------");
    foreach (var item in productManager.GetProductDetails())
    {
        Console.WriteLine(item.ProductName + " / " + item.CategoryName);
    }
}

CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

// CategoryTest(categoryManager);

static void CategoryTest(CategoryManager categoryManager)
{
    foreach (var item in categoryManager.GetAll())
    {
        Console.WriteLine(item.CategoryName);
    }
}

// merged - 16.08.2022 - 00:07