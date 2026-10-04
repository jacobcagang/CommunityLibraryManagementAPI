using CommunityLibraryManagementAPI.Models.Dto;
using CommunityLibraryManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommunityLibraryManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _service;

        public MembersController(IMemberService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<MemberDto>>> GetAll()
        {
            var members = await _service.GetAllAsync();

            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetById(int id)
        {
            var member = await _service.GetByIdAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult<MemberDto>> Create(MemberDto dto)
        {
            var member = await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = member.Id },
                member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MemberDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}