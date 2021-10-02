using System.Linq;
using dotnet_graphql_test.Data;
using dotnet_graphql_test.Model;
using HotChocolate;
using HotChocolate.Types;

namespace dotnet_graphql_test.GraphQL.ObjPerson
{
    public class PersonType : ObjectType<Person>
    {
        protected override void Configure(IObjectTypeDescriptor<Person> descriptor)
        {
            descriptor
                .Field(person => person.Job)
                .ResolveWith<Resolvers>(x => x.GetJob(default,default))
                .UseDbContext<AppDbContext>();
        }

        private class Resolvers
        {
            public IQueryable<Job> GetJob([Parent]Person person, [ScopedService] AppDbContext ctx)
            {
                return ctx.Jobs.Where(job => job.Id == person.JobId);
            }
        }
    }
}