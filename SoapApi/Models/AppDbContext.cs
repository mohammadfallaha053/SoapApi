using Microsoft.EntityFrameworkCore;
using SoapApi.Models;

namespace MovApi.Models
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
             
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        /****************For User Table************
                builder.Entity<TeamMember>()
                    .HasIndex(e => e.Email)
                    .IsUnique();

        //**********************************************/

        }

        public DbSet<TeamMember> TeamMembers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Soap> Soap { get; set; } = default!;

        public DbSet<ImageSlider> ImageSliders { get; set; }

        public DbSet<Story> Stories { get; set; }
        


    }
}
