using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;
using StoreApp.Models;


namespace StoreApp.Contollers
{
    public class ProductController : Controller
    {
         private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(ProductRequestParameters p)
        {
         var products = _manager.ProductService.GetAllProductsWithDetails(p);
         var pagination = new Pagination()
         {
            CurrenPage = p.PageNumber,
            ItemsPerpage = p.PageSize,
            TotalItems = _manager.ProductService.GetAllProducts(false).Count() 
         };
         return View(new ProductListViewModel()
         {
            Products = products,
            Pagination = pagination
         });
           
        }

        public IActionResult Get([FromRoute(Name ="id")] int id)
        {
            var model = _manager.ProductService.GetOneProduct(id, false);
             return View(model);

        }
    }
    
}