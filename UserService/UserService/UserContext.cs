﻿using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }        

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
    }
}
