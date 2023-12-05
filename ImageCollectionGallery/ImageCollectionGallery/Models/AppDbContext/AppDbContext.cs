using Microsoft.EntityFrameworkCore;

namespace ImageCollectionGallery.Models.AppDbContext
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Image> Images { get; set; }
    }
}
