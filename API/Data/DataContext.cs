using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptoins options) : base(options) //constructor
        {

        }

        public DbSet<AppUser> Users { get; set; }
    }
}