using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BnsShopWeb.Models;

public class BnsContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public BnsContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
        "server=localhost;user=root;password=passtobeadmin;database=BnsShopAsp",
        new MySqlServerVersion(new Version(8,0,29))
            );
    }
}