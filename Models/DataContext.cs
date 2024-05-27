﻿using Microsoft.EntityFrameworkCore;
using Joshua_POE_CLDV.Models;

namespace Joshua_POE_CLDV.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
