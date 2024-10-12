using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppTest.Data;
using WebAppTest.Models;

namespace WebAppTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductCategoriesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //Получение списка всех категорий
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategories()
        {
            return await this.context.ProductCategories.ToListAsync();
        }

        //Получение категории по Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetProductCategory(int id)
        {
            var productCategory = await this.context.ProductCategories.FindAsync(id);

            if (productCategory == null)
            {
                return NotFound();
            }

            return productCategory;
        }

        //Обновление категории
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductCategory(int id, ProductCategory productCategory)
        {
            if (id != productCategory.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.context.Entry(productCategory).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryExists(id))
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

        //Создание новой категории
        [HttpPost]
        public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            this.context.ProductCategories.Add(productCategory);
            await this.context.SaveChangesAsync();

            return CreatedAtAction("GetProductCategory", new { id = productCategory.Id }, productCategory);
        }

        //Удаление категории
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            var productCategory = await this.context.ProductCategories.FindAsync(id);
            if (productCategory == null)
            {
                return NotFound();
            }

            this.context.ProductCategories.Remove(productCategory);
            await this.context.SaveChangesAsync();

            return NoContent();
        }
        //Проверка существования категории
        private bool ProductCategoryExists(int id)
        {
            return this.context.ProductCategories.Any(e => e.Id == id);
        }
    }
}
