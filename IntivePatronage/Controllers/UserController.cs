using IntivePatronage.ApplicationUser;
using IntivePatronage.Entities;
using IntivePatronage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntivePatronage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly LinkGenerator _linkGenerator;

        public UserController(IUserRepository repository, LinkGenerator linkGenerator)
        {
            _repository = repository;
            _linkGenerator = linkGenerator;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUserAsync(CreateUserModel request)
        {
            try
            {
                var address = new Address
                {
                    Country = request.AddressCountry,
                    City = request.AddressCity,
                    PostCode = request.AddressPostCode,
                    Street = request.AddressPostCode,
                    HouseNumber = request.AddressHouseNumber,
                    LocalNumber = request.AddressLocalNumber
                };
                _repository.Add(address);

                if (!(await _repository.SaveChangesAsync()))
                {
                    return BadRequest();
                }

                var user = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DateOfBirth = request.DateOfBirth,
                    Gender = request.Gender,
                    Weight = request.Weight,
                    AddressId = address.Id,
                    Address = address
                };

                _repository.Add(user);

                if (!(await _repository.SaveChangesAsync()))
                {
                    return BadRequest();
                }

                //var location = _linkGenerator.GetPathByAction("HttpGet", "User", new { id = user.Id});
/*
                if (string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest();
                }*/

                return Created($"/user/{ user.Id}", new UserModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth,
                    Gender = user.Gender,
                    Weight = user.Weight
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsersAsync() 
        {
            try
            {
                var users = await _repository.GetUsersAsync();

                if (!users.Any())
                {
                    return NotFound();
                }

                return Ok(users.Select(x => new UserModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateOfBirth = x.DateOfBirth,
                    Gender = x.Gender,
                    Weight = x.Weight,

                    AddressCountry = x.Address.Country,
                    AddressCity = x.Address.City,
                    AddressPostCode = x.Address.PostCode,
                    AddressStreet = x.Address.Street,
                    AddressHouseNumber = x.Address.HouseNumber,
                    AddressLocalNumber = x.Address.LocalNumber

                }));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserModel>> GetUser(int id) 
        {
            try
            {
                var user = await _repository.GetUserAsync(id);

                if (user is null)
                {
                    return NotFound("Couldn't find the user");
                }

                return Ok(new UserModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth,
                    Gender = user.Gender,
                    Weight = user.Weight,

                    AddressCountry = user.Address.Country,
                    AddressCity = user.Address.City,
                    AddressPostCode = user.Address.PostCode,
                    AddressStreet = user.Address.Street,
                    AddressHouseNumber = user.Address.HouseNumber,
                    AddressLocalNumber = user.Address.LocalNumber
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }
        }

        [HttpPost("{id:int}/update")]
        public async Task<ActionResult<UserModel>> UpdateUser(int id, UpdateUserModel request)
        {
            try
            {
                var user = await _repository.GetUserAsync(id);

                if(user is null)
                {
                    return NotFound("Couldn't find the user");
                }

                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.DateOfBirth = request.DateOfBirth;
                user.Gender = request.Gender;
                user.Weight = request.Weight;

                if (!(await _repository.SaveChangesAsync()))
                {
                    return BadRequest();
                }

                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }

        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _repository.GetUserAsync(id);

                if (user is null)
                {
                    return NotFound("Couldn't find the user");
                }

                _repository.Delete(user);

                if (!(await _repository.SaveChangesAsync()))
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database failure");
            }

        }
    }
}
