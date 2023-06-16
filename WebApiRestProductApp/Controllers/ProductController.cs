using Microsoft.AspNetCore.Mvc;
using WebApiRestProductApp.Data;
using WebApiRestProductApp.Models;

namespace WebApiRestProductApp.Controllers
{
    //[Route("/api/[controller]")]
    [Route("/api/ProductAPI")]
    [ApiController]
    public class ProductController : Controller
    {

        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext productDbContext) {

            _context = productDbContext;

        }

        [HttpGet]
        public IEnumerable<Product> GetProducts(){

            IEnumerable<Product> products = _context.Products;

            return products;        

        }

        [HttpGet("Id")]
        public Product GetProduct(int Id) { 

            Product product = _context.Products.FirstOrDefault(o => o.Id == Id);

            return product;
        
        }

    }
}
