using System;
using System.Collections.Generic;
using TestTask.Data.Context;
using TestTask.Data.Contexts;
using TestTask.Data.Models;

namespace TestTask.Data.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork<PictureContext, Picture>
    {
        private readonly Dictionary<string, IRepository<Picture>> _repositories;
        private IPictureContext context;
        public UnitOfWork(IPictureContext pictureContext)
        {
            _repositories = new Dictionary<string, IRepository<Picture>>();
            context = pictureContext;
        }

        public void Register(IRepository<Picture> repository)
        {
            _repositories.Add(repository.GetType().Name, repository);
        }

        public IRepository<Picture> GetRepository(string repositoryName)
        {
            var repo = _repositories[repositoryName];
            if (repo == null)
            {
                throw new Exception($"Repository {repositoryName} cannot find");
            }
            return repo;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
