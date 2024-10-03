using LibTrack.DbConnect;
using Microsoft.AspNetCore.Http;
using LibTrack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly Connection _context;

        public TransactionsController(Connection context)
        {
            _context = context;
        }

        // API to issue a book
        [HttpPost("IssueBook")]
        public async Task<IActionResult> IssueBook([FromBody] Transaction transaction)
        {
            if (transaction == null)
                return BadRequest("Transaction data is required.");

            // Add logic to save transaction
            await _context.Transcation_Tbles.AddAsync(transaction);
            await _context.SaveChangesAsync();

            return Ok("Book issued successfully.");
        }


       



       


        // API to get the issued history of a book
        [HttpGet("history/{bookId}")]
        public async Task<IActionResult> GetBookHistory(int bookId)
        {
            var transactions = await _context.Transcation_Tbles
                .Where(t => t.BookId == bookId)
                .Include(t => t.User)
                .ToListAsync();

            var totalIssuedCount = transactions.Count;
            var currentHolder = transactions.FirstOrDefault(t => t.ReturnDate == null);

            return Ok(new
            {
                TotalIssuedCount = totalIssuedCount,
                CurrentlyIssuedTo = currentHolder?.User.User_Name ?? "Not Issued"
            });
        }

        

        // API to get list of books issued to a specific user
        [HttpGet("user/{userId}/books")]
        public async Task<IActionResult> GetBooksIssuedToUser(int userId)
        {
            var issuedBooks = await _context.Transcation_Tbles
                .Where(t => t.UserId == userId && t.ReturnDate == null)
                .Select(t => t.Book)
                .ToListAsync();

            return Ok(new { IssuedBooks = issuedBooks });
        }

        // API to get list of books issued in a specific date range
        [HttpGet("issued")]
        public async Task<IActionResult> GetIssuedBooksInRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var issuedBooks = await _context.Transcation_Tbles
                .Where(t => t.IssueDate >= startDate && t.IssueDate <= endDate)
                .Include(t => t.User)
                .Include(t => t.Book)
                .ToListAsync();

            return Ok(new
            {
                IssuedBooks = issuedBooks.Select(t => new
                {
                    t.Book.Name,
                    IssuedTo = t.User.User_Name,
                    t.IssueDate
                })
            });
        }
    }
}

