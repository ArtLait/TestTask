using System;
using TestTask.Data.Context;
using TestTask.Data.Contexts;

namespace TestTask.Data.Repositories
{
    //public class UnitOfWork<TContext> : IDisposable
    //{
    //    private readonly IRepository<PictureContext> _pictureRepository;
    //    private readonly IPictureContext context;
    //    public UnitOfWork(IRepository<PictureContext> repo, IPictureContext context)
    //    {
    //        _pictureRepository = repo;
    //        this.context = context;
    //    }

    //    public PictureRepository Pictures
    //    {
    //        get
    //        {
    //            return new PictureRepository(context);
    //        }
    //    }
        

    //    public BookRepository Books
    //    {
    //        get
    //        {
    //            if (bookRepository == null)
    //                bookRepository = new BookRepository(db);
    //            return bookRepository;
    //        }
    //    }

    //    public void Save()
    //    {
    //        context.SaveChanges();
    //    }

    //    private bool disposed = false;

    //    public virtual void Dispose(bool disposing)
    //    {
    //        if (!this.disposed)
    //        {
    //            if (disposing)
    //            {
    //                context.Dispose();
    //            }
    //            this.disposed = true;
    //        }
    //    }

    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }
    //}
}
