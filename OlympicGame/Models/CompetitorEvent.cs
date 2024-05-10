namespace OlympicGame.Models
{
    public class CompetitorEvent
    {
        public int event_id { get; set; }
        public int competitor_id { get; set; }
        public int medal_id { get; set; }
        public Medal medal { get; set; }

        public Event eventt { get; set; }

        public GamesCompetitor gamesCompetitor { get; set; }


    }
}

