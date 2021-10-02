using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnet_graphql_test.Model
{
    public class Job
    {
        [Key]
        [Required]
        public int Id {get;set;}

        [Required]
        public string Name {get;set;}
    }
}