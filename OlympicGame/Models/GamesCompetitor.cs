namespace OlympicGame.Models
{
    public class GamesCompetitor
    {
        public int id { get; set; }
        public int games_id { get; set; }
        public int person_id { get; set; }
        public int age { get; set; }
        public ICollection<CompetitorEvent> competitorEvents { get; set; }

        public Games games { get; set; }

        public Person person { get; set; }

    }
}
