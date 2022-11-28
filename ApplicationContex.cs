using Microsoft.EntityFrameworkCore;
using SMS.model;

namespace SMS;

public class ApplicationContext : DbContext
{
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server=localhost;Database=SMSDBC;Uid=root;Pwd=1234",new MySqlServerVersion(new Version("8.0.29")));
    }
    public DbSet<Admin>admins {get;set;}
    public DbSet<Attendant>attendants {get;set;}
    public DbSet<Product>products {get;set;}
    public DbSet<Transaction>transaction {get;set;}
}