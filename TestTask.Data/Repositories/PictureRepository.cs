using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestTask.Data.Context;
using TestTask.Data.Contexts;
using TestTask.Data.Models;

namespace TestTask.Data.Repositories
{
    public class PictureRepository : IRepository<Picture>
    {
        private IPictureContext context;

        public PictureRepository(IPictureContext pictureContext)
        {
            context = pictureContext;
        }

        public void Create(Picture item)
        {
            if (item == null)
            {
                throw new Exception("Picture is empty");
            }
            context.Pictures.Add(item);
        }

        public void Delete(Picture item)
        {
            if (item == null)
            {
                throw new Exception("Picture is empty");
            }
            context.Pictures.Remove(item);
        }

        public Picture Get(int id)
        {
            var picture = context.Pictures.Find(id);
            if (picture == null)
            {
                throw new Exception("Picture not found!");
            }
            return picture;
        }

        public IEnumerable<Picture> GetAll()
        {
            var pictures = context.Pictures;
            if (pictures == null)
            {
                throw new Exception("Pictures not found!");
            }
            return pictures;
        }

        public void Update(Picture item)
        {
            if (item == null)
            {
                throw new Exception("Picture is empty");
            }
            context.EntryContext(item);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
