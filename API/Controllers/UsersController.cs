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
using API.DTOs;
using AutoMapper;

namespace API.Controllers
{
    // [ApiController] **from BaseApiController
    // [Route("api/[controller]")]
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository; //Field
        private readonly IMapper _mapper;

       private readonly DataContext _context;
       public UsersController(IUserRepository userRepository, IMapper mapper)
       {
            _mapper = mapper;
            _userRepository = userRepository;
       }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers() //IEnumerable almost like a list
        {
            var users = await _userRepository.GetUsersAsync(); 
            var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            return Ok(usersToReturn); //Wrap in Ok response
        }

        //api/users/3
        [HttpGet("{username}")] //will give you a 204 No Content Error!
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            return _mapper.Map<MemberDto>(user);
        }
        
    }
}