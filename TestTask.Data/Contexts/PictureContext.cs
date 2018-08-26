using Microsoft.EntityFrameworkCore;
using TestTask.Data.Contexts;
using TestTask.Data.Models;

namespace TestTask.Data.Context
{
    public class PictureContext : DbContext, IPictureContext
    {
        public DbSet<Picture> Pictures { get; set; }

        public PictureContext(DbContextOptions<PictureContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        void IPictureContext.EntryContext(Picture item)
        {
            Entry(item).State = EntityState.Modified;
        }

        void IPictureContext.SaveChanges()
        {
            SaveChanges();
        }
    }
}
