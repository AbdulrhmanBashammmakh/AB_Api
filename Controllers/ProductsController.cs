using AB_Api.Models;
using AB_Api.Models.FactoryModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AB_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase


    {

       
        private readonly Ab238_salesContext _context;
        private Product NewProduct = new Product();
        public ProductsController(Ab238_salesContext context)
        {
            _context = context;
           
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(bool? inStack, int? skip, int? take)
        {
            var products = _context.Products.AsQueryable();
            if (inStack != null)
            {
                products = _context.Products.Where(i => i.Code != null);
            }

            if (skip != null)
            {
                products = products.Skip((int)skip);
            }
            if (take != null)
            {
                products = products.Take((int)take);
            }
            //            return await _context.Products.ToListAsync();


            return await products.ToListAsync();


        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductFactory>> PostProduct(ProductFactory product)
        {


            NewProduct.Id = product.Id;
            NewProduct.Code = product.Code;
            NewProduct.Title = product.Title;
            NewProduct.CateId = product.CateId;
            NewProduct.UnitId = product.UnitId;
            NewProduct.CrDate = product.CrDate;


            _context.Products.Add(NewProduct);
            /*
            await _context.SaveChangesAsync();
            _context.CurrentProducts.Add(new CurrentProduct
            {
                IdProduct = NewProduct.Id,
                Detials = "-",
                PriceBuy = 0,
                PriceSale = 0,
                QtyAvaliabe = 0,
                UpdDate = DateTime.Now

            }) ;
            await _context.SaveChangesAsync();
            */
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
