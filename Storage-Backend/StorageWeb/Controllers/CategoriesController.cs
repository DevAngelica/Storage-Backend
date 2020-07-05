using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StorageData;
using StorageEntities.Storage;
using StorageWeb.Models.Storage.Category;

namespace StorageWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DbContextStorage _context;
        private object _conext;

        public CategoriesController(DbContextStorage context)
        {                       
            _context = context;
        }

        // GET: api/Categories/GetCategories
        [HttpGet("[action]")]
        public async Task <IEnumerable<CategoryViewModel>> GetCategories()
        {
            var category = await _context.Categories.ToListAsync();
            return category.Select(c => new CategoryViewModel
            {
                idcategory = c.idcategory,
                name = c.name,
                description = c.description,
                condition = c.condition
            });
        }

        // GET: api/Categories/GetCategory/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(new CategoryViewModel {
                idcategory = category.idcategory,
                name = category.name,
                description = category.description,
                condition = category.condition
            });
        }

        // PUT: api/Categories/PutCategory
        [HttpPut("[action]")]
        public async Task<IActionResult> PutCategory([FromBody] PutCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idcategory <= 0)
            {
                return BadRequest();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(c => c.idcategory == model.idcategory);

            if (category == null)
            {
                return NotFound();
            }

            category.name = model.name;
            category.description = model.description;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Categories/PostCategory
        [HttpPost("[action]")]
        public async Task<ActionResult<Category>> PostCategory([FromBody] PostCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category category = new Category
            {
                name = model.name,
                description = model.description,
                condition = true
            };

            _context.Categories.Add(category);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/Categories/DeleteCategory/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
           
            return Ok(category);
        }

        // PUT: api/Categories/DisableCategory/5
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> DisableCategory([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(c => c.idcategory == id);

            if (category == null)
            {
                return NotFound();
            }

            category.condition = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Categories/EnableCategory/5
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> EnableCategory([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(c => c.idcategory == id);

            if (category == null)
            {
                return NotFound();
            }

            category.condition = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.idcategory == id);
        }
    }
}
