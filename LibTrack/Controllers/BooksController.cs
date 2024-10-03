using LibTrack.Models;
using LibTrack.Repository.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookServicecs _bookServicecs;
        public BooksController(IBookServicecs bookServicecs)
        {
            this._bookServicecs = bookServicecs;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res=await _bookServicecs.GetAllBooks();
            return Ok(res);
        }
        [HttpGet("SearchBookByName")]
        public async Task<IActionResult> SearchBookByName(string name)
        {
            var res = await _bookServicecs.SearchBookByName(name);
            return Ok(res);
        }

        [HttpPost("AddNewBooks")]
        public async Task<IActionResult> AddNewBooks(Book book)
        {
             await _bookServicecs.AddNewBook(book);
            return Ok("Added Successfully");
        }

        [HttpGet("Rent")]
        public async Task<IActionResult> Rent(decimal min,decimal max)
        {
            var res = await _bookServicecs.GetBookRentByRange(min ,max);
            return Ok(res);
        }


        [HttpGet("Filter")]
        public async Task<IActionResult> Filter(string category,string name,decimal? min, decimal? max)
        {
            var res = await _bookServicecs.FiltersBooks(category,name,min, max);
            return Ok(res);
        }
    }
}
