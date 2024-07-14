using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovApi.Models;
using SoapApi.Dtos.TeamMemmber;
using SoapApi.Models;

namespace SoapApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TeamMembersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TeamMembers
       

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllTeamMembers()
        {       
 
         return Ok(_mapper.Map<IEnumerable<ResponseTeamMemberDto>>(await _context.TeamMembers.OrderByDescending(a => a.TeamMemberId).ToListAsync()));
               
        }

        // GET: api/TeamMembers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamMember(int id)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);

            if (teamMember == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ResponseTeamMemberDto>(teamMember));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamMember(int id, BaseTeamMemberDto dto)
        {
            
            var teamMember = await _context.TeamMembers.FindAsync(id);

            if (teamMember == null) return NotFound();

            teamMember.FirstName = dto.FirstName;
            teamMember.LastName = dto.LastName;
            teamMember.Email = dto.Email;
            teamMember.Phone = dto.Phone;
            teamMember.Image1 = dto.Image1;
            teamMember.Image2 = dto.Image2;
            teamMember.Country = dto.Country;
            
            await _context.SaveChangesAsync();

             return Ok(_mapper.Map<ResponseTeamMemberDto>(teamMember));
        }



        [HttpPost]
        public async Task<IActionResult> PostTeamMember([FromBody]BaseTeamMemberDto dto)
        {
            var teamMember = _mapper.Map<TeamMember>(dto);
            await  _context.AddAsync(teamMember);
            _context.SaveChanges();   
            return Ok(_mapper.Map<ResponseTeamMemberDto>(teamMember));
        }

        // DELETE: api/TeamMembers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMember(int id)
        {
            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember == null)
            {
                return NotFound();
            }

            _context.TeamMembers.Remove(teamMember);
            await _context.SaveChangesAsync();

            return NoContent();
        }

       
    }
}
