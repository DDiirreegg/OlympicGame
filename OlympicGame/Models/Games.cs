namespace OlympicGame.Models
{
    public class Games
    {
        public int id { get; set; }
        public int games_year { get; set; }
        public string games_name { get; set; }
        public string season { get; set; }
        public ICollection<GamesCompetitor> gamesCompetitors { get; set; }
        public ICollection<GamesCity> gamesCities { get; set; }


    }
}
