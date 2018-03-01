using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcMovie1.Models;

namespace MvcMovie1.Areas.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Movies")]
    public class MoviesController : Controller
    {
        private readonly MvcMovie1Context _context;

        public MoviesController(MvcMovie1Context context)
        {
            _context = context;
        }

        //// GET: api/Movies
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok("Hello world");
        //}

        //GET: api/Movies
        public IEnumerable<Movie> GetAll()
        {
            return _context.Movie.ToList();
        }

        //// GET: api/Movies/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "GetId")]
        public IActionResult GetById(long id)
        {
            var item = _context.Movie.FirstOrDefault(t => t.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        
        // POST: api/Movies
        [HttpPost]
        public IActionResult Post([FromBody]Movie value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            _context.Movie.Add(value);
            _context.SaveChanges();

            return CreatedAtRoute("GetId", new { id = value.ID }, value);
        }
    }
}
