namespace OlympicGame.Models
{
    public class Sport
    {
        public int id { get; set; }
        public string sport_name { get; set; }

        public ICollection<Event> events { get; set; }
    }
}
