using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.DTOs;
using MoviesAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
	[ApiController]
	[Route("api/people")]
	public class PeopleController : ControllerBase
	{
		private readonly ApplicationDbContext context;
		private readonly IMapper mapper;

		public PeopleController(ApplicationDbContext context,
			IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<List<PersonDTO>>> Get()
		{
			var people = await context.People.ToListAsync();
			return mapper.Map<List<PersonDTO>>(people);
		}

		[HttpGet("{id}", Name = "GetPerson")]
		public async Task<ActionResult<PersonDTO>> Get(int id)
		{
			var person = await context.People.FirstOrDefaultAsync(x => x.Id == id);

			if(person == null)
			{
				return NotFound();
			}

			return mapper.Map<PersonDTO>(person);
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromBody] PersonCreationDTO personCreationDTO)
		{
			var person = mapper.Map<Person>(personCreationDTO);
			context.Add(person);
			await context.SaveChangesAsync();
			var personDTO = mapper.Map<PersonDTO>(person);
			return new CreatedAtRouteResult("getPerson", new { id = person.Id }, personDTO);
		}

	}
}
