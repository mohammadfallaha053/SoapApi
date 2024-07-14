
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovApi.Models;
using SoapApi.Dtos;
using SoapApi.Dtos.Story;
using SoapApi.Models;

namespace SoapApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public StoriesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Stories


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllStories()
        {

            return Ok(_mapper.Map<IEnumerable<ResponseStoryDto>>(await _context.Stories.OrderByDescending(a => a.StoryId).ToListAsync()));

        }

        // GET: api/Stories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStories(int id)
        {
            var Stories = await _context.Stories.FindAsync(id);

            if (Stories == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ResponseStoryDto>(Stories));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutStories(int id, BaseStoryDto dto)
        {

            var story = await _context.Stories.FindAsync(id);

            if (story == null) return NotFound();


            story.Description=dto.Description;
            story.Title=dto.Title;
            story.Image1 = dto.Image1;
            story.Image2 = dto.Image2;


            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<ResponseStoryDto>(story));
        }



        [HttpPost]
        public async Task<IActionResult> PostStories([FromBody] BaseStoryDto dto)
        {
            var story = _mapper.Map<Story>(dto);
            await _context.AddAsync(story);
            _context.SaveChanges();
            return Ok(_mapper.Map<ResponseStoryDto>(story));
        }

        // DELETE: api/Stories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStories(int id)
        {
            var story = await _context.Stories.FindAsync(id);
            if (story == null)
            {
                return NotFound();
            }

            _context.Stories.Remove(story);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
