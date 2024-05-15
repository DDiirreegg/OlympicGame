using ApplicationCore.Models;


namespace ApplicationCore.Interface
{
    public interface IOlympicGameRepository
    {
       
        Task<Sport> FindSport(int id);
        Task<Event> FindEvent(int id);
        Task<Medal> FindMedal(int id);
        Task<GamesCompetitor> FindGamesCompetitor(int id);
        Task<Games> FindGames(int id);
        Task<City> FindCity(int id);
        Task<Person> FindPerson(int id);
        Task<NocRegion> FindNocRegion(int id);


        Task<List<Sport>> FindSportPage(int page, int size);
        Task<List<Event>> FindEventPage(int page, int size);
        Task<List<Medal>> FindMedalPage(int page, int size);
        Task<List<GamesCompetitor>> FindGamesCompetitorPage(int page, int size);
        Task<List<Games>> FindGamesPage(int page, int size);
        Task<List<City>> FindCityPage(int page, int size);
        Task<List<Person>> FindPersonPage(int page, int size);
        Task<List<NocRegion>> FindNocRegionPage(int page, int size);
    }
}
