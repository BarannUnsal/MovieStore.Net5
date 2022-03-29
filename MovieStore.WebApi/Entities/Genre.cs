using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.WebApi.Entities
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; } = true;

        public List<CustomerGenre> GenreCustomers { get; set; }
        public List<Movie> GenreMovies { get; set; }
    }
}