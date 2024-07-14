using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovApi.Models;
using SoapApi.Dtos.Soap;
using SoapApi.Dtos.TeamMemmber;
using SoapApi.Models;

namespace SoapApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SoapsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SoapsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllSoaps()
        {
          return Ok(_mapper.Map<IEnumerable<ResponseSoapDto>>(await _context.Soap.OrderByDescending(a => a.SoapId).ToListAsync()));

        }

        [HttpGet("GetAllMostWanted")]
        public async Task<IActionResult> GetAllMostWanted()
        {
            return Ok(_mapper.Map<IEnumerable<ResponseSoapDto>>(await _context.Soap.Where(a => a.MostWanted==true).OrderBy(a => a.Order).ToListAsync()));

        }



        [HttpGet("GetAllWithCategory")]
        public async Task<IActionResult> GetAllSoapsWithCategory()
        {
            return Ok(_mapper.Map <IEnumerable<ResponseSoapWithCategoryDto>>(await _context.Soap.Include("Category").OrderByDescending(a => a.SoapId).ToListAsync()));

        }






        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSoap(int id)
        {
            var soap = await _context.Soap.Include("Category").FirstOrDefaultAsync(a => a.SoapId==id);

            if (soap == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ResponseSoapWithCategoryDto>(soap));
        }




      


        [HttpPost]
        public async Task<IActionResult> PostSoap([FromBody] BaseSoapDto dto)
        {
            var soap = _mapper.Map<Soap>(dto);
            /*var soap = new Soap { 
                SoapAge=dto.SoapAge,
                CategoryId=dto.CategoryId,
                Description=dto.Description,
                Image1 = dto.Image1,
                Image2 = dto.Image2,
                LaurelOil=dto.LaurelOil,
                OliveOil=dto.OliveOil,
                Name = dto.Name,
            };*/

             await _context.AddAsync(soap);
            _context.SaveChanges();
             return Ok(_mapper.Map<ResponseSoapDto>(soap));

        }




        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoap(int id, BaseSoapDto dto)
        {

            var soap = await _context.Soap.FindAsync(id);

            if (soap == null) return NotFound();

            soap.LaurelOil = dto.LaurelOil;
            soap.OliveOil = dto.OliveOil;
            soap.Name = dto.Name;
            soap.SoapAge = dto.SoapAge;
            soap.Description = dto.Description;
            soap.Image1 = dto.Image1;
            soap.Image2 = dto.Image2;
            soap.Color = dto.Color;
            soap.CategoryId = dto.CategoryId;
            soap.MostWanted= dto.MostWanted;
            soap.Order =dto.Order;
            

            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<ResponseSoapDto>(soap));
        }






        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoap(int id)
        {
            var soap = await _context.Soap.FindAsync(id);
            if (soap == null)
            {
                return NotFound();
            }

            _context.Soap.Remove(soap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
    }
}
