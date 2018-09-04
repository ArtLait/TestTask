using TestTask.Data.Context;
using TestTask.Data.Models;
using TestTask.Data.Repositories;

namespace TestTask.Data.Activities
{
    public class MainActivity : IMainActivity
    {
        private readonly IUnitOfWork<PictureContext, Picture> _unitOfWork;
        public MainActivity(IUnitOfWork<PictureContext, Picture> unitOfWork, IRepository<Picture> repo)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.Register(repo);
        }

        public IUnitOfWork<PictureContext, Picture> GetUnitOfWork()
        {
            return _unitOfWork;
        }
    }
}
