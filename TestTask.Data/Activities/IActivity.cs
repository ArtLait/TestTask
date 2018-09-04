using TestTask.Data.Context;
using TestTask.Data.Models;
using TestTask.Data.Repositories;

namespace TestTask.Data.Activities
{
    public interface IMainActivity
    {
        IUnitOfWork<PictureContext, Picture> GetUnitOfWork();
    }
}
