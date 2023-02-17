using ElevenNote.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElevenNote.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Happy People"
                },
                new Category
                {
                    Id = 2,
                    Name = "Sad People"
                },
                new Category
                {
                    Id = 3,
                    Name = "Video Games"
                },
                new Category
                {
                    Id = 4,
                    Name = "Art"
                },
                new Category
                {
                    Id = 5,
                    Name = "Music"
                }
            );

            modelBuilder.Entity<Note>().HasData(
                new Note
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "Im so Happy!",
                    Content = @"Bacon ipsum dolor amet ground round meatloaf pancetta chuck 
                      venison chicken chislic pork. Short ribs alcatra prosciutto ham.
                      Short ribs jowl pastrami burgdoggen pork rump. Filet mignon ribeye boudin,
                      short ribs sirloin tri-tip turducken shank jerky swine corned beef tongue venison 
                      spare ribs."
                }
            );
        }
    }
}