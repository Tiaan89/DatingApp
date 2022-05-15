using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;
using System.Security.Cryptography;
using API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        public AccountController(DataContext context) //constructor
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
        {
            if(await UserExists(registerDto.Username)) return BadRequest("Username already exists!");

            using var hmac = new HMACSHA512(); //'using' to ensure dispose

            var user = new AppUser
            { //Properties
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user); //database.table.method(object)
            await _context.SaveChangesAsync();

            return user;
        }

        //To ensure username is unique
        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }

    }
}