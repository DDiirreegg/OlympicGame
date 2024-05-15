using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Interface;
using Infrastructure;
using ApplicationCore.Models;
using System;


namespace OlympicGame.Controllers
{
    [ApiController]
    [Route("/weather")]
    public class OlympicGameController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IOlympicGameRepository _repository;

        public OlympicGameController(IOlympicGameRepository repository, ApplicationDbContext context)
        {
            _context = context;
            _repository = repository;
        }


        [HttpGet("sport/{page}/{size}")]
        public Task<List<Sport>> GetSports(int page, int size)
        {
            return _repository.FindSportPage(page, size);
        }


        [HttpGet("event/{page}/{size}")]
        public Task<List<Event>> GetEvents(int page, int size)
        {
            return _repository.FindEventPage(page, size);
        }


        [HttpGet("medal/{page}/{size}")]
        public Task<List<Medal>> GetMedals(int page, int size)
        {
            return _repository.FindMedalPage(page, size);
        }


        [HttpGet("gameCompotitor/{page}/{size}")]
        public Task<List<GamesCompetitor>> GetGamesCompetitors(int page, int size)
        {
            return _repository.FindGamesCompetitorPage(page, size);
        }


        [HttpGet("games/{page}/{size}")]
        public Task<List<Games>> GetGames(int page, int size)
        {
            return _repository.FindGamesPage(page, size);
        }


        [HttpGet("city/{page}/{size}")]
        public Task<List<City>> GetCitys(int page, int size)
        {
            return _repository.FindCityPage(page, size);
        }


        [HttpGet("person/{page}/{size}")]
        public Task<List<Person>> GetPerson(int page, int size)
        {
            return _repository.FindPersonPage(page, size);
        }

        [HttpGet("nocRegion/{page}/{size}")]
        public Task<List<NocRegion>> GetNocRegion(int page, int size)
        {
            return _repository.FindNocRegionPage(page, size);
        }        

        [HttpGet("api/people/{id}")]
        public async Task<ActionResult<GamesCompetitor>> GetParticipantById(int id)
        {
            var gamesCompetitors = await _context.games_competitor
                .Include(gc => gc.person)
                .Include(gc => gc.games)
                .Include(gc => gc.medals)
                    .ThenInclude(ce => ce.events)
                .Where(gc => gc.person_id == id)
                .ToListAsync();

            if (gamesCompetitors == null || !gamesCompetitors.Any())
            {
                return NotFound();
            }

            var events = gamesCompetitors.SelectMany(gc => gc.games.Select(gc => gc.medals
            {
                MedalName = m.medal_name,
                GameName = m.games.?.Games?.Name,
                EventName = m.Event?.Event_Name
            })).ToList();

            var participantData = new
            {
                FullName = gamesCompetitors.First().Person.Full_Name,
                Weight = gamesCompetitors.First().Person.Weight,
                Height = gamesCompetitors.First().Person.Height,
                Events = events
            };

            return participantData;
        }
    }
}



}
}
