﻿using Azure;
using Microsoft.AspNetCore.JsonPatch;
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
        public ActionResult<IEnumerable<Product>> GetProducts() {

            IEnumerable<Product> products = _context.Products;

            return Ok(products);

        }

        //use Name to invoke this method later while creating route
        [HttpGet("{id:int}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> GetProduct(int Id) {

            if (Id == 0) {
                return BadRequest();
            }

            Product product = _context.Products.FirstOrDefault(p => p.Id == Id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Product> CreateProduct([FromBody] Product product) {

            /*if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }*/

            //custom validation: check if product name already exists
            if (_context.Products.FirstOrDefault(p => p.Name.ToLower() == product.Name.ToLower()) != null)
            {
                ModelState.AddModelError("", "Product already exists");
                return BadRequest(ModelState);
            }

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

            //return Ok(product);

            //return url of the new item
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);

        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id:int}")]
        //IActionResult instead of ActionResult because we dont need to specify return type
        public IActionResult DeleteProduct(int id) {

            if (id == 0)
            {
                return BadRequest();
            }

            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null) {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        //product object has id but we can get explicitly to double check
        public IActionResult UpdateProduct(int id, [FromBody] Product product) {

            if (product == null || product.Id != id) 
            {
                return BadRequest();            
            }

            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);

            if (existingProduct == null) {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Category = product.Category;
            existingProduct.Price = product.Price;

            _context.SaveChanges();

            return NoContent();

        }

        //patch requires JsonPatch and Mvc.NewtonsoftJson
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPatch]
        public IActionResult UpdatePartialProduct(int id, JsonPatchDocument<Product> patch)
        { 

            if (id == 0 || patch == null)
            {
                return BadRequest();
            }

            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);

            if (existingProduct == null)
            { 
                return NotFound();            
            }

            //store errors in ModelState
            patch.ApplyTo(existingProduct, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.SaveChanges();

            return NoContent();        
        }

    }
}
