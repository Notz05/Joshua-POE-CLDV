using Microsoft.EntityFrameworkCore;
using Joshua_POE_CLDV.Models;
namespace Joshua_POE_CLDV.wwwroot.Data { 

    public class DataContext
    
        
    {
        public class DataContext : DbContext
        {
            public DataContext(DbContextOptions<DataContext> options) : base(options) { }

            public DbSet<Product> Products { get; set; }
            public DbSet<CartItem> CartItems { get; set; }
        }
    }

}
}
