using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

ProductManager productManager = new ProductManager(new InMemoryProductDal());

foreach (var item in productManager.GetAll())
{
    Console.WriteLine(item.ProductName);
}

Console.WriteLine("-----------------------------------------");

foreach (var item in productManager.GetAllByCategory(2))
{
    Console.WriteLine(item.ProductName + " - " + item.CategoryId);
}

Console.WriteLine("-----------------------------------------");

productManager.Add(new Product { ProductId = 6, CategoryId = 3, ProductName = "Hediyelik Eşya", UnitPrice = 100, UnitsInStock = 33 });

foreach (var item in productManager.GetAll())
{
    Console.WriteLine(item.ProductName);
}

Console.WriteLine("-----------------------------------------");

productManager.Delete(new Product { ProductId = 2 });

foreach (var item in productManager.GetAll())
{
    Console.WriteLine(item.ProductName);
}

Console.WriteLine("-----------------------------------------");

productManager.Update(new Product { ProductId = 6, CategoryId = 3, ProductName = "Hediyelik Eşya Updated", UnitPrice = 100, UnitsInStock = 33 });

foreach (var item in productManager.GetAll())
{
    Console.WriteLine(item.ProductName);
}