using IntivePatronage.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntivePatronage.ApplicationUser
{
    public interface IUserRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();
        Task<User> GetUserAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();


    }
}
