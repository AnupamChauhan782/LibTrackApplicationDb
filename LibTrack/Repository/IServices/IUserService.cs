using LibTrack.Models;

namespace LibTrack.Repository.IServices
{
    public interface IUserService
    {
        Task<List<User>> GetUserData();
        Task  AddNewUser(User user);
        Task DeleteUser(int id);
        Task<User>  GetUserById(int id);
        Task UpdateUser(User user);
    }
}
