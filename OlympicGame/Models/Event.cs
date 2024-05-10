namespace OlympicGame.Models
{
    public class Event
    {
        public int id { get; set; }
        public int sport_id { get; set; }
        public string event_name { get; set; }
        public Sport sport { get; set; }
        public ICollection<CompetitorEvent> competitorEvents { get; set; }
    }
}
