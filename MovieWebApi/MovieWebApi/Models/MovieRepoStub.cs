using System.Collections.Generic;
using System.Linq;

namespace MovieWebApi.Models
{
    public class MovieRepoStub
    {
        private static List<Movie> _movies = new List<Movie>
        {
            new Movie
            {
                Id = 1,
                Title = "Ghostbusters",
                Rating = "PG-13"
            },
            new Movie
            {
                Id = 2,
                Title = "Finding Nemo",
                Rating = "G"
            },
            new Movie
            {
                Id = 3,
                Title = "Rocky",
                Rating = "PG-13"
            }
        };

        public static List<Movie> ReadAll()
        {
            return _movies;
        }

        public static Movie ReadById(int id)
        {
            return _movies.FirstOrDefault(m => m.Id == id);
        }

        public static void Create(Movie movie)
        {
            movie.Id = _movies.Max(m => m.Id) + 1;
            _movies.Add(movie);
        }

        public static void Update(Movie movie)
        {
            _movies[_movies.FindIndex(m => m.Id == movie.Id)] = movie;
        }

        public static void Delete(int id)
        {
            _movies.RemoveAll(m => m.Id == id);
        }
    }
}