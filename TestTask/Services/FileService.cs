using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.Data.Activities;
using TestTask.Data.Context;
using TestTask.Data.Models;
using TestTask.Data.Repositories;
using TestTask.Models;

namespace TestTask.Services
{
    public class FileService : IFileService
    {
        private readonly IUnitOfWork<PictureContext, Picture> _unitOfWork;
        private readonly IRepository<Picture> _fileRepo;

        public FileService(IUnitOfWork<PictureContext, Picture> unitOfWork, IMainActivity mainActivities)
        {
            _unitOfWork = mainActivities.GetUnitOfWork();
            _fileRepo = _unitOfWork.GetRepository(typeof(PictureRepository).Name);
        }

        public List<FileModel> GetFiles()
        {
            var config = new MapperConfiguration(x => x.CreateMap<Picture, FileModel>());
            var mapper = config.CreateMapper();
            return _fileRepo.GetAll().Select(x => mapper.Map<Picture, FileModel>(x)).ToList();
        }

        public void PostFile(FileModel fileModel)
        {
            var config = new MapperConfiguration(x => x.CreateMap<FileModel, Picture>()
            .ForMember("Id", y => Guid.NewGuid()));
            var mapper = config.CreateMapper();

            _fileRepo.Create(mapper.Map<FileModel, Picture>(fileModel));
            _unitOfWork.Commit();
        }
    }
}
