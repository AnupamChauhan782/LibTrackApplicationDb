using LibTrack.Models;

namespace LibTrack.Repository.IServices
{
    public interface IBookServicecs
    {
        Task<List<Book>> GetAllBooks();
        Task<Book>  GetBookById(int id);
        Task AddNewBook(Book book);
        Task<List<Book>>  SearchBookByName(string name);
        Task<List<Book>>  GetBookRentByRange(decimal min,decimal max);
        Task<List<Book>> FiltersBooks(string category,string name, decimal? maxRent, decimal? minRent);

    }
}
