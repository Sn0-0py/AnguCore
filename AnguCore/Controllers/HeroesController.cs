using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnguCore.Core.Data.Interfaces.Repositories;
using AnguCore.Core.Entities;
using AnguCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnguCore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        public static List<HeroViewModel> Heroes { get; set; }
        private readonly IHeroRepository _heroRepo;

        public HeroesController(IHeroRepository heroRepo)
        {
            _heroRepo = heroRepo;
        }

        // GET api/heroes
        [HttpGet]
        public IActionResult Get(string name)
        {
            if (!String.IsNullOrEmpty(name))
                name = name.ToLower();

            var heroes = _heroRepo.GetAll();
            var model = heroes.Select(h => new HeroViewModel()
            {
                Id = h.Id,
                Name = h.Name
            });

            return Ok(model);
        }

        // GET api/heroes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var hero = await _heroRepo.GetById(id);
            if (hero == null)
                return NotFound(id);
            
            return Ok(new HeroViewModel() { Id = hero.Id, Name = hero.Name });
        }

        // POST api/heroes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HeroViewModel hero)
        {
            hero.Id = await _heroRepo.Create(new Hero() { Name = hero.Name });
            return Ok(hero);
        }

        // PUT api/heroes/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] HeroViewModel model)
        {
            var hero = await _heroRepo.GetById(id);
            if (hero != null)
            {
                hero.Name = model.Name;
                await _heroRepo.Update(id, hero);
            }
        }

        // DELETE api/heroes/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _heroRepo.Delete(id);
        }
    }
}
