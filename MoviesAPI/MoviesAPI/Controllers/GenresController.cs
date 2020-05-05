using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesAPI.DTOs;
using MoviesAPI.Entities;
using MoviesAPI.Filters;
using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    [Route("api/genres")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenresController : ControllerBase
    {
        private readonly ILogger<GenresController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenresController(ILogger<GenresController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GenreDTO>>> Get()
        {
            var genres = await context.Genres.AsNoTracking().ToListAsync();
            var genresDTOs = mapper.Map<List<GenreDTO>>(genres);
            return genresDTOs;
        }

        [HttpGet("{Id:int}", Name = "getGenre")]
        public async Task<ActionResult<GenreDTO>> Get(int Id)
        {
            var genre = await context.Genres.FirstOrDefaultAsync(x => x.Id == Id);
            if(genre == null)
            {
                return NotFound();
            }

            var genreDTO = mapper.Map<GenreDTO>(genre);

            return genreDTO; 
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenreCreationDTO genreCreation)
        {
            var genre = mapper.Map<Genre>(genreCreation);
            context.Add(genre);
            await context.SaveChangesAsync();
            var genreDTO = mapper.Map<GenreDTO>(genre);

            await context.SaveChangesAsync();

            return new CreatedAtRouteResult("getGenre", new { genre.Id }, genre);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GenreCreationDTO genreCreation)
        {
            var genre = mapper.Map<Genre>(genreCreation);
            genre.Id = id;
            context.Entry(genre).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await context.Genres.AnyAsync(x => x.Id == id);
            if(!exists)
            {
                return NotFound();
            }
            context.Remove(new Genre() { Id = id });
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}