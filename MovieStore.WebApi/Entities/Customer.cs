using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.WebApi.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool isActive { get; set; }
        public List<Movie> BoughtMovies { get; set; }
        public List<CustomerGenre> CustomerGenres { get; set; }
    }
}