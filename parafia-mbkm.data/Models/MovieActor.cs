using System.ComponentModel.DataAnnotations;

namespace parafia_mbkm.data.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [MaxLength(3)]
        public List<Actor> Actors { get; set; }
    }

    public class Actor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}