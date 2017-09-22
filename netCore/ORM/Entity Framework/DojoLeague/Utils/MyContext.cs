using Microsoft.EntityFrameworkCore;
public class MyContext: DbContext {
    public MyContext(DbContextOptions<MyContext> options) : base(options) {}

    public DbSet<Ninja> Ninjas{get;set;}
    public DbSet<Dojo> Dojos{get;set;}
}