
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovApi.Models;
using SoapApi.Dtos.ImageSlider;
using SoapApi.Models;

namespace SoapApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ImageSliderController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ImageSliderController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ImageSlider


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllImageSlider()
        {

            return Ok(_mapper.Map<IEnumerable<ResponseImageSliderDto>>(await _context.ImageSliders.OrderBy(a => a.Order).ToListAsync()));

        }

        // GET: api/ImageSlider/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageSlider(int id)
        {
            var ImageSlider = await _context.ImageSliders.FindAsync(id);

            if (ImageSlider == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ResponseImageSliderDto>(ImageSlider));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageSlider(int id, BaseImageSliderDto dto)
        {

            var ImageSlider = await _context.ImageSliders.FindAsync(id);

            if (ImageSlider == null) return NotFound();


            ImageSlider.Order = dto.Order;
            ImageSlider.Image1 = dto.Image1;
            ImageSlider.Image2 = dto.Image2;


            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<ResponseImageSliderDto>(ImageSlider));
        }



        [HttpPost]
        public async Task<IActionResult> PostImageSlider([FromBody] BaseImageSliderDto dto)
        {
            var ImageSlider = _mapper.Map<ImageSlider>(dto);
            await _context.AddAsync(ImageSlider);
            _context.SaveChanges();
            return Ok(_mapper.Map<ResponseImageSliderDto>(ImageSlider));
        }

        // DELETE: api/ImageSlider/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageSlider(int id)
        {
            var ImageSlider = await _context.ImageSliders.FindAsync(id);
            if (ImageSlider == null)
            {
                return NotFound();
            }

            _context.ImageSliders.Remove(ImageSlider);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
