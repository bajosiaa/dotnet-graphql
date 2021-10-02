using dotnet_graphql_test.Model;
using HotChocolate;
using HotChocolate.Types;

namespace dotnet_graphql_test.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Job OnJobAdded([EventMessage] Job job)
        {
            return job;
        }
    }
}