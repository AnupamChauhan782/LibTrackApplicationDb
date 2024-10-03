using LibTrack.DbConnect;
using LibTrack.Models;
using LibTrack.Repository.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibTrack.Repository.Services
{
    public class BookService : IBookServicecs
    {
        private readonly Connection _connect;
        public BookService(Connection connection)
        {
           this. _connect = connection;
            
        }

        public async Task AddNewBook(Book book)
        {
            if (book == null) throw new ArgumentNullException("Not valid Data");
            await _connect.Book_Tables.AddAsync(book);
            await _connect.SaveChangesAsync();  

        }


        public async Task<List<Book>> FiltersBooks(string category, string name, decimal? maxRent, decimal? minRent)
        {
           
                var query = _connect.Book_Tables.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                    query = query.Where(b => b.Category == category);

                if (!string.IsNullOrEmpty(name))
                    query = query.Where(b => b.Name.Contains(name));

                if (minRent.HasValue)
                    query = query.Where(b => b.RentPerDay >= minRent.Value);

                if (maxRent.HasValue)
                    query = query.Where(b => b.RentPerDay <= maxRent.Value);

             return await query.ToListAsync();
          
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var books = await _connect.Book_Tables.ToListAsync();
            return books;
        }

        public async Task<Book> GetBookById(int id)
        {
           var books=await _connect.Book_Tables.FirstOrDefaultAsync(x=>x.BookId == id);
            if (books == null)
            {
                throw new Exception("Not Found");
            }
            return books;
        }

        public async Task<List<Book>> GetBookRentByRange(decimal min, decimal max)
        {
            var getRent=await _connect.Book_Tables.Where(b=>b.RentPerDay >=min&&b.RentPerDay <=max).ToListAsync();    
            return getRent;
        }

        public async Task<List<Book>> SearchBookByName(string name)
        {
            var names=await _connect.Book_Tables.Where(b=>b.Name.Contains(name)).ToListAsync();
            return names;
        }
    }
}

