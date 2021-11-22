using IntivePatronage.Database;
using IntivePatronage.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IntivePatronage.ApplicationUser
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _ctx;

        public UserRepository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Add<T>(T entity) where T : class
        {
            _ctx.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _ctx.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _ctx.SaveChangesAsync() > 0);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _ctx.Users
                .Include(x => x.Address)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {         
             return await _ctx.Users
                .Include(a => a.Address)
                .ToListAsync();
        }

    }
}
