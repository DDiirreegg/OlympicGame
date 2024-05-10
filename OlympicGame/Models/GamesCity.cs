namespace OlympicGame.Models
{
    public class GamesCity
    {           
        public int games_id { get; set; }
        public int city_id { get; set; }
        public Games games { get; set; }

        public City city { get; set; }

    }
}
