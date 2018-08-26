using System;
using System.Collections.Generic;
using System.Text;
using TestTask.Data.Models;
using TestTask.Models;

namespace TestTask.Services
{
    public interface IFileService
    {
        void PostFile(FileModel fileModel);
        List<FileModel> GetFiles();
    }
}
