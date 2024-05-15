using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //
            // Sport - Event 1:m  relation 
            //
            modelBuilder.Entity<Sport>()
                .HasMany(sport => sport.events)
                .WithOne(events => events.sport)
                .HasForeignKey(events => events.sport_id);
            /*.HasPrincipalKey(sport => sport.id);*/

            //
            // Games - GamesCompetitor 1:m  relation 
            //
            modelBuilder.Entity<Games>()
                .HasMany(games => games.gamesCompetitors)
                .WithOne(gamesCompetitor => gamesCompetitor.games)
                .HasForeignKey(gamesCompetitor => gamesCompetitor.games_id);

            //
            // Person - GamesCompetitor 1:m  relation 
            //
            modelBuilder.Entity<Person>()
                .HasMany(person => person.gamesCompetitors)
                .WithOne(gamesCompetitor => gamesCompetitor.person)
                .HasForeignKey(gamesCompetitor => gamesCompetitor.person_id);

            ///////////////////////////////////////////////////////////////

            /* modelBuilder.Entity<PersonRegion>()
                 .HasKey(pr => new { pr.person_id, pr.region_id });

             //
             // Person - PersonRegion 1:m  relation 
             //
             modelBuilder.Entity<PersonRegion>()
                 .HasOne(personRegion => personRegion.person)
                 .WithMany(person => person.personRegions)
                 .HasForeignKey(personRegion => personRegion.person_id);

             //
             // nocRegion - PersonRegion 1:m  relation 
             //
             modelBuilder.Entity<PersonRegion>()
                 .HasOne(personRegion => personRegion.nocRegion)
                 .WithMany(nocRegion => nocRegion.personRegions)
                 .HasForeignKey(personRegion => personRegion.region_id);*/
            modelBuilder.Entity<NocRegion>()
                .HasMany(nr => nr.persons)
                .WithMany(p => p.nocRegions)
                .UsingEntity<PersonRegion>(
                    pr => pr.HasOne(pr => pr.person).WithMany().HasForeignKey(pr => pr.person_id),
                    pr => pr.HasOne(pr => pr.nocRegion).WithMany().HasForeignKey(pr => pr.region_id),
                    pr =>
                    {
                        pr.HasKey(pr => new { pr.region_id, pr.person_id });
                    }
                );

            ////////////////////////////////////////////////////////////////


            /*modelBuilder.Entity<GamesCity>()
                .HasKey(gc => new { gc.games_id, gc.city_id });

            //
            // Games - gamesCity 1:m  relation 
            //
            modelBuilder.Entity<GamesCity>()
                .HasOne(gameCity => gameCity.games)
                .WithMany(games => games.gamesCities)
                .HasForeignKey(gamesCities => gamesCities.games_id);

            //
            // City - GamesCity 1:m  relation 
            //
            modelBuilder.Entity<GamesCity>()
                .HasOne(gameCity => gameCity.city)
                .WithMany(city => city.gamesCities)
                .HasForeignKey(gamesCities => gamesCities.city_id);*/

            modelBuilder.Entity<City>()
                .HasMany(c => c.games)
                .WithMany(g => g.citys)
                .UsingEntity<GamesCity>(
                    gs => gs.HasOne(gs => gs.games).WithMany().HasForeignKey(gs => gs.games_id),
                    gs => gs.HasOne(gs => gs.city).WithMany().HasForeignKey(gs => gs.city_id),
                    gs =>
                    {
                        gs.HasKey(gs => new { gs.games_id, gs.city_id });
                    }
                );


            ////////////////////////////////////////////////////////////////
            modelBuilder.Entity<Medal>()
                .HasMany(m => m.events)
                .WithMany(e => e.medals)
                .UsingEntity<CompetitorEvent>(
                    ce => ce.HasOne(ce => ce.eventt).WithMany().HasForeignKey(ce => ce.event_id),
                    ce => ce.HasOne(ce => ce.medal).WithMany().HasForeignKey(ce => ce.medal_id),
                    ce =>
                    {
                        ce.HasKey(ce => new { ce.event_id, ce.medal_id });
                    }
                );

            modelBuilder.Entity<Medal>()
                .HasMany(m => m.gamesCompetitors)
                .WithMany(gc => gc.medals)
                .UsingEntity<CompetitorEvent>(
                    ce => ce.HasOne(ce => ce.gamesCompetitor).WithMany().HasForeignKey(ce => ce.competitor_id),
                    ce => ce.HasOne(ce => ce.medal).WithMany().HasForeignKey(ce => ce.medal_id),
                    ce =>
                    {
                        ce.HasKey(ce => new { ce.competitor_id, ce.medal_id });
                    }
                );





        }

        public DbSet<Sport> sport { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<CompetitorEvent> competitor_event { get; set; }
        public DbSet<Medal> medal { get; set; }
        public DbSet<GamesCompetitor> games_competitor { get; set; }
        public DbSet<Games> games { get; set; }
        public DbSet<GamesCity> games_city { get; set; }
        public DbSet<City> city { get; set; }
        public DbSet<Person> person { get; set; }
        public DbSet<PersonRegion> person_region { get; set; }
        public DbSet<NocRegion> noc_region { get; set; }
    }
}
