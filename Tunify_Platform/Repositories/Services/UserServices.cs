using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Services
{
    public class UserServices : IUser
    {
        private readonly TunifyDbContext _context;

        public UserServices(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(int id)
        {
            var getUser = await GetUserById(id);
            _context.Users.Remove(getUser);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            var allUsers = await _context.Users.ToListAsync();
            return allUsers;
        }

        public async Task<User> GetUserById(int id)
        {
            var specificUser = await _context.Users.FindAsync(id);
            return specificUser;
        }

        public async Task<User> UpdateUser(int id, User user)
        {
            var exsitingUser = await _context.Users.FindAsync(id);
            exsitingUser = user;
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
