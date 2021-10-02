using dotnet_graphql_test.Model;
using Microsoft.EntityFrameworkCore;

namespace dotnet_graphql_test.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opts) : base(opts)
        {

        }

        public DbSet<Person> Persons {get;set;}
        public DbSet<Job> Jobs{get;set;}
    }
}