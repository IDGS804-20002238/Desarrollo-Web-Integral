using System.ComponentModel.DataAnnotations;

namespace MvcMovies.Models
{
    public class Movie
    {
        //Propiedades del Modelo
        public int Id { get; set; }
        public string? Title { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre {  get; set; }
        public decimal Price { get; set; }
    }
}
