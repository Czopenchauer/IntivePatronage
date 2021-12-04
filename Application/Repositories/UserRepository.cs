using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Database;
using System.Linq;
using Application.Filters;
using Application.Helper;
using Application.ResourceParameters;

namespace Application.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext ctx;

        public UserRepository(ApplicationDbContext ctx)
        {
            this.ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public async Task<bool> AddUserAsync(User user)
        {
            if(user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            try
            {
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    ctx.Users.Add(user);

                    await ctx.SaveChangesAsync();

                    await transaction.CommitAsync();
                }              
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            try
            {
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    var address = user.Address;
                    ctx.Users.Remove(user);
                    ctx.Addresses.Remove(address);

                    await ctx.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public void AddAddress(Address address)
        {
            if(address is null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            ctx.Addresses.Add(address);
        }


        public void DeleteAddress(Address address)
        {
            if (address is null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            ctx.Addresses.Remove(address);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await ctx.Users
                        .Include(x => x.Address)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedList<User>> GetUsersAsync(UserResourceParameter userResourceParameter)
        {
            var query = ctx.Users
                .Include(a => a.Address);

            return await PagedList<User>.Create(query, userResourceParameter.PageNumber, userResourceParameter.PageSize);
        }

        public IQueryable<User> GetFilteredUsersAsync()
        {
            return ctx.Users.AsQueryable();               
        }

        public async Task<Address> GetAddressAsync(int id)
        {
            return await ctx.Addresses
                        .Include(u => u.User)
                        .FirstOrDefaultAsync(x => x.User.Id == id);
        }

        public async Task<PagedList<Address>> GetAddressesAsync(AddressResourceParameter addressResourceParameter)
        {
            var query = ctx.Addresses.AsQueryable();

            return await PagedList<Address>.Create(query, addressResourceParameter.PageNumber, addressResourceParameter.PageSize);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await ctx.SaveChangesAsync() > 0);
        }

    }
}
