using System.Threading;
using System.Threading.Tasks;
using dotnet_graphql_test.Data;
using dotnet_graphql_test.GraphQL.ObjJob;
using dotnet_graphql_test.GraphQL.ObjPerson;
using dotnet_graphql_test.Model;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace dotnet_graphql_test.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPersonPayload> AddPersonAsync(AddPersonInput input, [ScopedService] AppDbContext ctx)
        {
            var person = new Person
            {
                Name=input.Name,
                Surname=input.Surname,
                Age=input.Age,
                JobId=input.JobId
            };

            ctx.Persons.Add(person);
            await ctx.SaveChangesAsync();

            return new AddPersonPayload(person);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddJobPayload> AddJobAsync(
            AddJobInput input, 
            [ScopedService] AppDbContext ctx, 
            [Service] ITopicEventSender eventSender, 
            CancellationToken cancellationToken)
        {
            var job = new Job
            {
                Name=input.Name
            };

            ctx.Jobs.Add(job);
            await ctx.SaveChangesAsync(cancellationToken);
            await eventSender.SendAsync(nameof(Subscription.OnJobAdded), job, cancellationToken);

            return new AddJobPayload(job);
        }
    }
}