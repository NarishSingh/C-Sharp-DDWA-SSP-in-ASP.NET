using System.ComponentModel.DataAnnotations;

namespace MovieWebApi.Models
{
    public class UpdateMovieRequest
    {
        [Required] public int Id { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Rating { get; set; }
    }
}