using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProductController : ControllerBase
    {
        DemoDbContext _context;
        public ApiProductController(DemoDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await _context.Products!.ToListAsync());
        }
        [HttpGet]
        [Route("search-name/{name}")]
        public async Task<ActionResult<List<Product>>> SearchProducts(string name)
        {
            return Ok(await _context.Products!.Where(p => p.Name!.Contains(name)).ToListAsync());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product?>> GetProducts(int id)
        {
            return Ok(await _context.Products!.SingleOrDefaultAsync(p => p.Id == id));
        }
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product p)
        {
            if (ModelState.IsValid)
            {
                _context.Products!.Add(p);
                await _context.SaveChangesAsync();
                return Ok(p);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<ActionResult<Product>> PutProduct(Product p)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(p).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(p);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            Product? pro = await _context.Products!.SingleOrDefaultAsync(p => p.Id == id);
            if (pro == null)
            {
                return BadRequest();
            }
            _context.Products!.Remove(pro!);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
