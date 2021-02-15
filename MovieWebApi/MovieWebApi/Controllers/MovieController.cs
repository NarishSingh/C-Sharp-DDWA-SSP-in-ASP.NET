using System.Web.Http;
using MovieWebApi.Models;

namespace MovieWebApi.Controllers
{
    public class MovieController : ApiController
    {
        /// <summary>
        /// Read all movies Http Request to API
        /// </summary>
        /// <returns>200 OK JSON data with all movies from the stub</returns>
        [Route("movies/all")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            return Ok(MovieRepoStub.ReadAll());
        }

        /// <summary>
        /// Read by id API request using Query String
        /// </summary>
        /// <param name="id">int for an id in stub repo</param>
        /// <returns>200 OK with the JSON data with movie corresponding to id, 404 if invalid id</returns>
        [Route("movies/get/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int id)
        {
            Movie movie = MovieRepoStub.ReadById(id);

            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }
    }
}