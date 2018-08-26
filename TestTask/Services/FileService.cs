using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.Data.Models;
using TestTask.Data.Repositories;
using TestTask.Models;

namespace TestTask.Services
{
    public class FileService : IFileService
    {
        private IRepository<Picture> _repo { get; set; }
        public FileService(IRepository<Picture> repo)
        {
            _repo = repo;
        }

        public List<FileModel> GetFiles()
        {
            var config = new MapperConfiguration(x => x.CreateMap<Picture, FileModel>());
            var mapper = config.CreateMapper();
            return _repo.GetAll().Select(x => mapper.Map<Picture, FileModel>(x)).ToList();
        }

        public void PostFile(FileModel fileModel)
        {
            var config = new MapperConfiguration(x => x.CreateMap<FileModel, Picture>()
            .ForMember("Id", y => Guid.NewGuid()));
            var mapper = config.CreateMapper();
                
            _repo.Create(mapper.Map<FileModel, Picture>(fileModel));
            _repo.Save();
        }
    }
}
