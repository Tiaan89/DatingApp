using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context) //constructor getting the data from the database
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers() //IEnumerable almost like a list
        {
            return _context.Users.ToList();
        }

        //api/users/3
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id) //IEnumerable almost like a list
        {
            return _context.Users.Find(id);
        }
    }
}