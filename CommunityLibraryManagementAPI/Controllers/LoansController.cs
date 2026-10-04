using CommunityLibraryManagementAPI.Models.Dto;
using CommunityLibraryManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommunityLibraryManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _service;

        public LoansController(ILoanService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<LoanDto>>> GetAll()
        {
            var loans = await _service.GetAllAsync();

            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanDto>> GetById(int id)
        {
            var loan = await _service.GetByIdAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);
        }

        [HttpPost]
        public async Task<ActionResult<LoanDto>> Create(LoanDto dto)
        {
            var loan = await _service.CreateAsync(dto);

            if (loan == null)
            {
                return BadRequest(
                    "Book does not exist, member does not exist, or book is not available.");
            }

            return CreatedAtAction(
                nameof(GetById),
                new { id = loan.Id },
                loan);
        }

        [HttpPut("{id}/return")]
        public async Task<IActionResult> ReturnBook(int id)
        {
            var returned = await _service.ReturnBookAsync(id);

            if (!returned)
            {
                return BadRequest(
                    "Loan does not exist, book does not exist, or the book has already been returned.");
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