using Microsoft.EntityFrameworkCore;
using System;
using TestTask.Data.Models;

namespace TestTask.Data.Contexts
{
    public interface IPictureContext : IDisposable
    {
        DbSet<Picture> Pictures { get; set; }
        void SaveChanges();
        void EntryContext(Picture item);
    }
}
