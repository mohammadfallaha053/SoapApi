using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovApi.Models;
using SoapApi.Dtos.Category;
using SoapApi.Dtos.Soap;
using SoapApi.Dtos.TeamMemmber;
using SoapApi.Models;

namespace SoapApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;


        public CategoriesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: api/Categories
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetGetAllCategories()
        {
            return Ok(_mapper.Map <IEnumerable<ResponseCategoryDto>>(await _context.Categories.OrderByDescending(a => a.CategoryId).ToListAsync()));
        }

        [HttpGet("GetAllwithSoap")]
        public async Task<IActionResult> GetGetAllCategoriesWithSoap()
        {
            return Ok(_mapper.Map<IEnumerable<ResponseCategoryWithSoapDto>>(await _context.Categories.Include("Soaps").OrderByDescending(a => a.CategoryId).ToListAsync()));
            
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ResponseCategoryDto>(category));
        }



        // GET: api/Categories/5
        [HttpGet("WithSoaps/{id}")]
        public async Task<IActionResult> GetCategoryWithSoaps(int id)
        {
            var category = await _context.Categories.Include(x => x.Soaps.OrderByDescending(a => a.SoapId)).FirstOrDefaultAsync(a=>a.CategoryId==id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ResponseCategoryWithSoapDto>(category));
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, BaseCategoryDto dto)
        {

            var category = await _context.Categories.FindAsync(id);

            if (category == null) return NotFound();

            category.CategoryName = dto.CategoryName;
           

            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<ResponseCategoryDto>(category));
        }

      



    


        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] BaseCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _context.AddAsync(category);
            _context.SaveChanges();
            return Ok(_mapper.Map<ResponseCategoryDto>(category));
        }



        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

       
    }
}
