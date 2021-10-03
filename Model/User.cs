using System.ComponentModel.DataAnnotations;

namespace dotnet_graphql_test.Model
{
    public class User
    {
        [Key]
        [Required]
        public int Id {get;set;}

        [Required]
        public string Username {get;set;}

        [Required]
        public string Password {get;set;}

        public string Name {get;set;}

        public string Surname{get;set;}

        public int Age {get;set;}
    }
}