using System.ComponentModel.DataAnnotations;

namespace dotnet_graphql_test.Model
{
    public class Person
    {
        [Key]
        [Required]
        public int Id {get;set;}

        [Required]
        public string Name {get;set;}

        [Required]
        public string Surname{get;set;}

        [Required]
        public int Age {get;set;}

        public int JobId{get;set;}

        public Job Job {get;set;}
    }
}