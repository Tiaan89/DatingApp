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

namespace API.Controllers
{
    // [ApiController] **from BaseApiController
    // [Route("api/[controller]")]
    public class UsersController : BaseApiController
    {

       private readonly DataContext _context;
       public UsersController(DataContext context)
       {
           _context = context;
       }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() //IEnumerable almost like a list
        {
            return await _context.Users.ToListAsync();
        }

        //api/users/3
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id) //IEnumerable almost like a list
        {
            return await _context.Users.FindAsync(id);
        }
    }
}