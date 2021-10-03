using System.Linq;
using dotnet_graphql_test.Data;
using dotnet_graphql_test.Model;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.AspNetCore.Http;

namespace dotnet_graphql_test.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Person> Persons([ScopedService] AppDbContext ctx)
        {
            return ctx.Persons;
        }
        
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Job> Jobs([ScopedService] AppDbContext ctx)
        {
            return ctx.Jobs;
        }

        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<User> Me([ScopedService] AppDbContext ctx, [Service]IHttpContextAccessor httpContextAccessor)
        {
            var uid = httpContextAccessor.HttpContext.Session.GetInt32("uid");
            return ctx.Users.Where(user => user.Id == uid);
        }
    }
}