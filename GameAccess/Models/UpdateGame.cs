using System.ComponentModel.DataAnnotations;

namespace GameAccess.Models
{
    public class UpdateGame
    {

        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        public string Synopsis { get; set; }
    }
}
