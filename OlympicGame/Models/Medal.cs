namespace OlympicGame.Models
{
    public class Medal
    {
        public int id { get; set; }
        public string maedal_name { get; set; }

        public ICollection<CompetitorEvent> competitorEvents { get; set; }
    }
}
