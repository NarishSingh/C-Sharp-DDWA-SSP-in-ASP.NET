using System.ComponentModel.DataAnnotations;

namespace MovieWebApi.Models
{
    public class CreateMovieRequest
    {
        [Required] public string Title { get; set; }
        [Required] public string Rating { get; set; }
    }
}