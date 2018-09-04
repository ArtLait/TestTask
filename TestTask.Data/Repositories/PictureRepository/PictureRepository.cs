using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestTask.Data.Context;
using TestTask.Data.Contexts;
using TestTask.Data.Models;

namespace TestTask.Data.Repositories
{
    public class PictureRepository : GenericRepository<PictureContext, Picture>
    {
        private IPictureContext context;

        public PictureRepository(IPictureContext pictureContext, IUnitOfWork<PictureContext, Picture> unitOfWork) 
            : base(unitOfWork)
        {
            context = pictureContext;
        }

        public override void Create(Picture item)
        {
            if (item == null)
            {
                throw new Exception("Picture is empty");
            }
            context.Pictures.Add(item);
            context.SaveChanges();
        }

        public override void Delete(Picture item)
        {
            if (item == null)
            {
                throw new Exception("Picture is empty");
            }
            context.Pictures.Remove(item);
        }

        public override Picture Get(int id)
        {
            var picture = context.Pictures.Find(id);
            if (picture == null)
            {
                throw new Exception("Picture not found!");
            }
            return picture;
        }

        public override IEnumerable<Picture> GetAll()
        {
            var pictures = context.Pictures;
            if (pictures == null)
            {
                throw new Exception("Pictures not found!");
            }
            return pictures;
        }

        public override void Update(Picture item)
        {
            if (item == null)
            {
                throw new Exception("Picture is empty");
            }
            context.EntryContext(item);
        }
    }
}
