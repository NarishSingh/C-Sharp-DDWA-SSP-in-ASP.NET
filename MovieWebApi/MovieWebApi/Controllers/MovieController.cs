using System.Web.Http;
using System.Web.Http.Cors;
using MovieWebApi.Models;

namespace MovieWebApi.Controllers
{
    // [EnableCors(origins: "*", headers: "*", methods: "*")]
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

        /*
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
        */

        /// <summary>
        /// Read by id API request using URL path
        /// </summary>
        /// <param name="id">int for an id in stub repo</param>
        /// <returns>200 OK with the JSON data with movie corresponding to id, 404 if invalid id</returns>
        [Route("movies/get/{id}")]
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

        /// <summary>
        /// POST a new movie record
        /// </summary>
        /// <param name="req">CreateMovieRequest with Title and Rating in body</param>
        /// <returns>201 Created with a GET to the new movie record, 400 Bad Request if invalid</returns>
        [Route("movies/add")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(CreateMovieRequest req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Movie m = new Movie
            {
                Title = req.Title,
                Rating = req.Rating
            };

            MovieRepoStub.Create(m);

            return Created($"movies/get/{m.Id}", m);
        }

        /// <summary>
        /// PUT an update to a movie record
        /// </summary>
        /// <param name="req">UpdateMovieRequest obj, well formed</param>
        /// <returns>200 OK if update successful, 404 Not Found if id is invalid</returns>
        [Route("movies/update")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Update(UpdateMovieRequest req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Movie m = MovieRepoStub.ReadById(req.Id);

            if (m == null)
            {
                return NotFound();
            }

            m.Title = req.Title;
            m.Rating = req.Rating;
            MovieRepoStub.Update(m);

            return Ok(m);
        }

        /// <summary>
        /// DELETE a movie record using query string
        /// </summary>
        /// <param name="id">int for a valid id</param>
        /// <returns>200 OK if delete successful, 404 Not Found if id is invalid</returns>
        [Route("movies/delete")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int id)
        {
            Movie m = MovieRepoStub.ReadById(id);

            if (m == null)
            {
                return NotFound();
            }

            MovieRepoStub.Delete(m.Id);

            return Ok();
        }
    }
}