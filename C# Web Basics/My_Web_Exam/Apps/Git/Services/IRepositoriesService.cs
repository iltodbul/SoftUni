using System.Collections.Generic;
using Git.ViewModels.Repositories;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        void Create(string name, string repositoryType, string userId);

        IEnumerable<AllRepositoryViewModel> GetAll();

        string GetNameById(string id);
    }
}
