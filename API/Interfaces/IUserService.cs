using API.Entities;

namespace API.Interfaces
{
    public interface IUserService
    {
        Task<bool> UpdateAsync(User user);
        Task<bool> AddUser(User user);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<bool> DeleteUserAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
    }
}