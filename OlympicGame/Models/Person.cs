namespace OlympicGame.Models
{
    public class Person
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public string gender { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public ICollection<GamesCompetitor> gamesCompetitors { get; set; }
        public ICollection<PersonRegion> personRegions { get; set; }

    }
}
