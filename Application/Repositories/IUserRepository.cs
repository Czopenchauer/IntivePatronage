﻿using Application.Helper;
using Application.ResourceParameters;
using Database.Entities;
using System.Linq;
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
        IQueryable<User> GetFilteredUsersAsync();

        Task<Address> GetAddressAsync(int id);
        Task<PagedList<Address>> GetAddressesAsync(AddressResourceParameter addressResourceParameter);

        Task<bool> SaveChangesAsync();

    }
}
