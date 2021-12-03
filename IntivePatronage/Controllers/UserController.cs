using Application.Filters;
using Application.Models;
using Application.Repositories;
using AutoMapper;
using Database.Entities;
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
                User user = new User();
                mapper.Map(request, user);

                if (!(await repository.AddUserAsync(user)))
                {
                    return BadRequest();
                }

                return Ok(mapper.Map<UserDto>(user));
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
                    return NotFound(new
                    {
                        error = "There was no users in database."
                    });
                }

                return Ok(mapper.Map<IEnumerable<UserDto>>(users));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<UserDto>>> FilterUsersAsync(Filter filter)
        {
            try
            {
                var users = await repository.GetFilteredUsersAsync(filter);

                if (!users.Any())
                {
                    return NotFound(new
                    {
                        error = "There was no users in database."
                    });
                }

                return Ok(mapper.Map<IEnumerable<FilteredUserDto>>(users));
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
                    return NotFound(new
                    {
                        Id = id,
                        error = $"There was no user with an id of {id}."
                    });
                }

                return Ok(mapper.Map<UserDto>(user));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult<UserDto>> UpdateUser( UpdateUserDto request)
        {
            try
            {
                var user = await repository.GetUserAsync(request.Id);

                if (user is null)
                {
                    return NotFound(new
                    {
                        Id = request.Id,
                        error = $"There was no user with an id of {request.Id}."
                    });
                }

                mapper.Map(request, user);

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
                    return NotFound(new
                    {
                        Id = id,
                        error = $"There was no user with an id of {id}."
                    });
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
