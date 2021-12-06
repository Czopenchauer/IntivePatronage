using Application.Filters;
using Application.Helper;
using Application.Models;
using Application.ResourceParameters;
using Database.Entities;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AddUserAsync(User user);
        void AddAddress(Address address);

        Task<bool> DeleteUserAsync(User user);
        void DeleteAddress(Address address);


        Task<User> GetUserAsync(int id);
        Task<PagedList<User>> GetUsersAsync(UserResourceParameter userResourceParameter);
        Task<PagedList<FilteredUserDto>> GetFilteredUsersAsync(Filter filter, UserResourceParameter userResourceParameter);

        Task<Address> GetAddressAsync(int id);
        Task<PagedList<Address>> GetAddressesAsync(AddressResourceParameter addressResourceParameter);

        Task<bool> SaveChangesAsync();

    }
}
