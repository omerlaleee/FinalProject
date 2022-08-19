using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
            // IoC Containers will be added.
            // 19.08.22 - 16:44
            // 01:33:44

        }

        [HttpGet]
        public List<Product> GetAll()
        {
            return _productService.GetAll().Data;
        }
    }
}
