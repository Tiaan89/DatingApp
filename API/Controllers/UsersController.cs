using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;

namespace API.Controllers
{
    // [ApiController] **from BaseApiController
    // [Route("api/[controller]")]
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository; //Field

       private readonly DataContext _context;
       public UsersController(IUserRepository userRepository)
       {
            _userRepository = userRepository;
       }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() //IEnumerable almost like a list
        {
            return Ok(await _userRepository.GetUsersAsync()); //Wrap in Ok response
        }

        //api/users/3
        [HttpGet("{username}")] //will give you a 204 No Content Error!
        public async Task<ActionResult<AppUser>> GetUser(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }
        
    }
}