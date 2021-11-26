using API.Models;
using AutoMapper;
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
        private readonly IUserRepository repository;
        private readonly IMapper mapper;

        public UserController(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUserAsync(CreateUserDto request)
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<CreateUserDto, User>();
                    cfg.CreateMap<AddressDto, Address>();
                });
                var mapp = config.CreateMapper();

                User user = new User();
                user = mapp.Map<CreateUserDto, User>(request);

                if(!(await repository.AddUserAsync(user)))
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersAsync() 
        {
            try
            {
                var users = await repository.GetUsersAsync();

                if (!users.Any())
                {
                    return NotFound();
                }
                
                return Ok(mapper.Map<IEnumerable<UserDto>>(users));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> GetUser(int id) 
        {
            try
            {
                var user = await repository.GetUserAsync(id);

                if (user is null)
                {
                    return NotFound("Couldn't find the user");
                }

                return Ok(mapper.Map<UserDto>(user));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("update/{id:int}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, UpdateUserDto request)
        {
            try
            {              
                var user = await repository.GetUserAsync(id);

                if (user is null)
                {
                    return NotFound("Couldn't find the user");
                }

                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<UpdateUserDto, User>()
                        .ForMember(x => x.Address, options => options.Condition(src => src.Address != null));
                    cfg.CreateMap<AddressDto, Address>();
                });

                var mapp = config.CreateMapper();

                mapp.Map(request, user);

                if (!(await repository.SaveChangesAsync()))
                {
                    return BadRequest();
                }

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await repository.GetUserAsync(id);

                if(user is null)
                {
                    return NotFound("Couldn't find the user");
                }
                
                if(!(await repository.DeleteUserAsync(user)))
                {
                    return BadRequest();
                }

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
