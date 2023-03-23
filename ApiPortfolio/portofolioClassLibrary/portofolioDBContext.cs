using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using portofolioClassLibrary.Model;

namespace portofolioClassLibrary
{
    public class portofolioDBContext : DbContext
    {
        public portofolioDBContext()
        {

        }
        public portofolioDBContext(DbContextOptions options) : base(options)
        {

        }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=portapi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

       
        public DbSet<Post> Posts { get; set; }
        public DbSet<Project> Projects { get; set; }


    }
}