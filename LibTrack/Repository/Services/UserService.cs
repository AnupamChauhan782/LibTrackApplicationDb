using LibTrack.DbConnect;
using LibTrack.Models;
using LibTrack.Repository.IServices;
using Microsoft.EntityFrameworkCore;

namespace LibTrack.Repository.Services
{
    public class UserService : IUserService
    {
        private readonly Connection _connection;
        public UserService(Connection connection)
        {
            this._connection = connection; 
        }
        public async Task AddNewUser(User user)
        {
            if (user == null)
            {
                throw new Exception("Data is not valid");
            }
           await _connection.User_tbles.AddAsync(user);
            await _connection.SaveChangesAsync();   
        }

        public async Task DeleteUser(int id)
        {
          var res=await _connection.User_tbles.FirstOrDefaultAsync(x=>x.UserId == id);
            if (res == null)
            {
                throw new Exception("Not found Data");
            }
             _connection.User_tbles.Remove(res);
            await _connection.SaveChangesAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            var res=await _connection.User_tbles.FirstOrDefaultAsync(x=>x.UserId == id);
            if(res == null)
            {
                throw new Exception("Not found Data");
            }
            return res;
        }

        public async Task<List<User>> GetUserData()
        {
           var users=await _connection.User_tbles.ToListAsync();
            return users;
        }

        public async Task UpdateUser(User user)
        {
           var res=await _connection.User_tbles.FirstOrDefaultAsync(x=> x.UserId == user.UserId);
            if(res == null)
            {
                throw new Exception("Not found");
            }
            res.User_Name = user.User_Name;
            res.Email= user.Email;
             _connection.User_tbles.Update(res);
            await _connection.SaveChangesAsync();

        }
    }
}
