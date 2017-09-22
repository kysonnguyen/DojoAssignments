using Microsoft.EntityFrameworkCore;
 
namespace restauranter.Models
{
    public class MyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Review> Reviews{get;set;}
    }
}