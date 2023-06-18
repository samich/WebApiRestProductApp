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
        public ActionResult<IEnumerable<Product>> GetProducts(){

            IEnumerable<Product> products = _context.Products;

            return Ok(products);        

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> GetProduct(int Id) {

            if (Id == 0) {
                return BadRequest();
            }

            Product product = _context.Products.FirstOrDefault(o => o.Id == Id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Product> CreateProduct([FromBody]Product product) { 

            if (product == null) {
                return BadRequest(product);
            }

            //assume user should not enter any other Id than 0
            if (product.Id != 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            _context.Products.Add(product);
            _context.SaveChanges();
            
            return Ok(product);
        
        }        

    }
}
