using System.ComponentModel.DataAnnotations;

namespace GameAccess.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public string Synopsis { get; set; }
    }
}
