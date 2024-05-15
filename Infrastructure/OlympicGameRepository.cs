using ApplicationCore.Interface;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class OlympicGameRepository : IOlympicGameRepository
    {
        private readonly ApplicationDbContext _context;

        public OlympicGameRepository(ApplicationDbContext context)
        {
            _context = context;
        }        

        ///one entitie
        ///

        public Task<Sport> FindSport(int id)
        {
            return _context.sport
               .Where(sport => sport.id == id)
              .Include(sport => sport.events)
              .FirstAsync();
        }
        public Task<Event> FindEvent(int id)
        {
            return _context.Event
               .Where(Events => Events.id == id)
               .Include(Event => Event.sport)
               .Include(Event => Event.competitorEvents)
               .FirstAsync();
        }
        public Task<CompetitorEvent> FindCompetitorEvent(int event_id, int competitor_id, int medal_id)
        {
            return _context.competitor_event 
                .Where(competitor_event => competitor_event.event_id == event_id && competitor_event.competitor_id == competitor_id && competitor_event.medal_id == medal_id)
                .Include(competitor_event => competitor_event.eventt)
                .Include(competitor_event => competitor_event.medal)
                .Include(competitor_event => competitor_event.gamesCompetitor)
                .FirstAsync();
        }
        public Task<Medal> FindMedal(int id)
        {
            return _context.medal
                .Where(medal => medal.id == id)
                .Include(medal => medal.competitorEvents)
                .FirstAsync();
        }
        public Task<GamesCompetitor> FindGamesCompetitor(int id)
        {
            return _context.games_competitor
                .Where(games_competitor => games_competitor.id == id)
                .Include(games_competitor => games_competitor.competitorEvents)
                .Include(games_competitor => games_competitor.games)
                .Include(games_competitor => games_competitor.person)
                .FirstAsync();
        }
        public Task<Games> FindGames(int id)
        {
            return _context.games
                .Where(games => games.id == id)
                .Include(games => games.gamesCompetitors)
                .Include(games => games.gamesCities)
                .FirstAsync();
        }
        public Task<GamesCity> FindGamesCityn(int games_id, int city_id)
        {
            return _context.games_city
                .Where(games_city => games_city.games_id == games_id && games_city.city_id == city_id)
                .Include(games_city => games_city.games)
                .Include(games_city => games_city.city)
                .FirstAsync();
        }
        public Task<City> FindCity(int id)
        {
            return _context.city
                .Where(city => city.id == id)
                .Include(city => city.gamesCities)
                .FirstAsync();
        }
        public Task<Person> FindPerson(int id)
        {
            return _context.person
                .Where(person => person.id == id)
                .Include(person => person.gamesCompetitors)
                .Include(person => person.personRegions)
                .FirstAsync();
        }
        public Task<PersonRegion> FindPersonRegion(int person_id, int region_id)
        {
            return _context.person_region
                .Where(person_region => person_region.person_id == person_id && person_region.region_id == region_id)
                .Include(person_region => person_region.person)
                .Include(person_region => person_region.nocRegion)
                .FirstAsync();
        }
        public Task<NocRegion> FindNocRegion(int id)
        {
            return _context.noc_region
                .Where(noc_region => noc_region.id == id)
                .Include(noc_region => noc_region.personRegions)
                .FirstAsync();
        }

        ///range entities
        ///

        public Task<List<Sport>> FindSportPage(int page, int size)
        {
            return _context.sport
                .Skip(page)
                .Take(size)
                .Include(sport => sport.events)
                .ToListAsync();
        }

        public Task<List<Event>> FindEventPage(int page, int size)
        {
            return _context.Event
                .Skip(page)
                .Take(size)
                .Include(Event => Event.sport)
                .Include(Event => Event.medals)
                .ToListAsync();
        }

        

        public Task<List<Medal>> FindMedalPage(int page, int size)
        {
            return _context.medal
                .Skip(page)
                .Take(size)
                .Include(medal => medal.events)
                .Include(medal => medal.gamesCompetitors)
                .ToListAsync();
        }

        public Task<List<GamesCompetitor>> FindGamesCompetitorPage(int page, int size)
        {
            return _context.games_competitor 
                .Skip(page)
                .Take(size)
                .Include(games_competitor => games_competitor.medals)
                .Include(games_competitor => games_competitor.games)
                .Include(games_competitor => games_competitor.person)
                .ToListAsync();
        }

        public Task<List<Games>> FindGamesPage(int page, int size)
        {
            return _context.games
                .Skip(page)
                .Take(size)
                .Include(games => games.gamesCompetitors)
                .Include(games => games.citys)
                .ToListAsync();
        }

        public Task<List<Person>> FindPersonPage(int page, int size)
        {
            return _context.person
                .Skip(page)
                .Take(size)
                .Include(person => person.gamesCompetitors)
                .Include(person => person.nocRegions)
                .ToListAsync();
        }
                  
     
        public Task<List<City>> FindCityPage(int page, int size)
        {
            return _context.city  .Skip(page).Take(size)
                .Include(city => city.games)
                .ToListAsync();
        }

        public Task<List<NocRegion>> FindNocRegionPage(int page, int size)
        {
            return _context.noc_region  .Skip(page).Take(size)
                .Include(noc_region => noc_region.persons)
                .ToListAsync();
        }
    }
}
