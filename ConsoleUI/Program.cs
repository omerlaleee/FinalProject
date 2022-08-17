using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

ProductManager productManager = new ProductManager(new EfProductDal());

var productDetails = productManager.GetProductDetails();
if (productDetails.Success)
{
    foreach (var item in productDetails.Data)
    {
        Console.WriteLine(item.ProductName + " / " + item.CategoryName);
    }
}
Console.WriteLine("-----------------------------------------");
Console.WriteLine(productDetails.Message);
Console.WriteLine("-----------------------------------------");
var getAll = productManager.GetAll();
if (getAll.Success)
{
    foreach (var item in getAll.Data)
    {
        Console.WriteLine(item.ProductName);
    }
}
Console.WriteLine("-----------------------------------------");
Console.WriteLine(getAll.Message);
Console.WriteLine("-----------------------------------------");
CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());