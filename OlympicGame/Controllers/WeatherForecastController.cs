using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using OlympicGame.Models;

namespace OlympicGame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationDbContext _context;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet("sport")]
        public Task<List<Sport>> GetSport()
        {
            Task<List<Sport>> task = _context.sport.Include(sport => sport.events).ToListAsync();
            return task;
        }

        [HttpGet("event")]
        public Task<List<Event>> GetEvent()
        {
            var task = _context.Event
                .Where(e => e.id < 100)
                .Include(Event => Event.sport)
                .Include(Event => Event.competitorEvents)
                .ToListAsync();
            return task;
        }

        [HttpGet("medal")]
        public Task<List<Medal>> GetMedal()
        {
            var task = _context.medal
                .Where(e => e.id < 100)
                .Include(medal => medal.competitorEvents)
                .ToListAsync();
            return task;
        }

        [HttpGet("gamesCompetitor")]
        public Task<List<GamesCompetitor>> GetGamesCompetitor()
        {
            var task = _context.games_competitor
                .Where(e => e.id < 10)
                .Include(games_competitor => games_competitor.games)
                .Include(games_competitor => games_competitor.person)
                .ToListAsync();
            return task;
        }

        [HttpGet("games")]
        public Task<List<Games>> GetGames()
        {
            Task<List<Games>> task = _context.games.Include(games => games.gamesCompetitors).Include(games => games.gamesCities).ToListAsync();
            return task;
        }

        [HttpGet("persom")]
        public Task<List<Person>> GetPerson()
        {
            Task<List<Person>> task = _context.person.Include(person => person.gamesCompetitors).Include(person => person.personRegions).ToListAsync();
            return task;
        }

        [HttpGet("city")]
        public Task<List<City>> GetCity()
        {
            Task<List<City>> task = _context.city.Include(city => city.gamesCities).ToListAsync();
            return task;
        }

        [HttpGet("nocRegion")]
        public Task<List<NocRegion>> GetNocRegion()
        {
            Task<List<NocRegion>> task = _context.noc_region.Include(noc_region => noc_region.personRegions).ToListAsync();
            return task;
        }

        [HttpGet("GameCity")]
        public Task<List<GamesCity>> GetGameCity()
        {
            var task = _context.games_city.Include(gc => gc.games).Include(gc => gc.city).ToListAsync();
            return task;
        }

        [HttpGet("PersonRegion")]
        public Task<List<PersonRegion>> GetPersonRegion()
        {
            var task = _context.person_region.Include(pr => pr.person).Include(pr => pr.nocRegion).ToListAsync();
            return task;
        }

        [HttpGet("competitorEvent")]
        public Task<List<CompetitorEvent>> GetCompetitorEvent()
        {
            var task = _context.competitor_event.Include(ce => ce.medal).Include(ce => ce.eventt).Include(ce => ce.gamesCompetitor).ToListAsync();
            return task;
        }

        [HttpGet("getroutedata/{page}/{user}")]
        public List<string> GetString([FromRoute] int? page, [FromRoute] int user, [FromBody] string someData)
        {
            var a = new List<string>() { $"page:{page}, user: {user}, someData: {someData}", "" };
            return a;
        }

    }
}
