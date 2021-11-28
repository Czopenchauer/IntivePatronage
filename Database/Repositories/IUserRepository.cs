using Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AddUserAsync(User user);
        void AddAddress(Address address);

        Task<bool> DeleteUserAsync(User user);
        void DeleteAddress(Address address);


        Task<User> GetUserAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();

        Task<Address> GetAddressAsync(int id);
        Task<IEnumerable<Address>> GetAddressesAsync();

        Task<bool> SaveChangesAsync();

    }
}
