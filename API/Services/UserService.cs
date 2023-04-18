using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext context;

        public UserService(DataContext _context)
        {
            context = _context;
        }

        public async Task<bool> AddUser(User user)
        {
            var result = false;
            try
            {
                if (user is not null)
                {
                    await context.Users!.AddAsync(user);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var result = false;
            try
            {
                var deleteUser = await context.Users!.FirstOrDefaultAsync(u => u.Id == id);
                if(deleteUser is not null)
                {
                    context.Users!.Remove(deleteUser);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = new User();
            try
            {
                user =  await context.Users!.FirstOrDefaultAsync(u => u.Id == id);

                if(user is not null)
                {
                    user.PasswordHash = null;
                    user.PasswordSalt = null;
                }
            }
            catch (Exception)
            {
                user = null!;
            }
            return user!;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var user = new User();
            try
            {
                user = await context.Users!.FirstOrDefaultAsync(u => u.Username == username);
                if (user is not null)
                {
                    user.PasswordHash = null;
                    user.PasswordSalt = null;
                }
            }
            catch (Exception)
            {
                user = null!;
            }
            return user!;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = new List<User>();
            try
            {
                users = await context.Users!.ToListAsync();

                if (users is not null)
                {
                    foreach(var user in users)
                    {
                        user.PasswordHash = null;
                        user.PasswordSalt = null;
                    }
                }
            }
            catch (Exception)
            {
                users = null!;
            }
            return users!;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            var result = false;
            try
            {
                var userToUdate = await context.Users!.FirstOrDefaultAsync(u => u.Id == user.Id);
                if (userToUdate is not null)
                {
                    userToUdate.Username = user.Username;
                    userToUdate.FirstName = user.FirstName;
                    userToUdate.LastName = user.LastName;
                    userToUdate.Organization = user.Organization;
                    userToUdate.Role = user.Role;
                    userToUdate.City = user.City;
                    userToUdate.DateOfBirth = user.DateOfBirth;
                    userToUdate.Gender = user.Gender;
                    await context.SaveChangesAsync();
                    result = true;
                }
            }
            catch(Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
