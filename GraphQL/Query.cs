using System.Linq;
using dotnet_graphql_test.Data;
using dotnet_graphql_test.Model;
using HotChocolate;
using HotChocolate.Data;

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
    }
}