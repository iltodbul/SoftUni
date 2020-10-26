using System;
using System.Collections.Generic;
using System.Linq;
using Git.Data;
using Git.Models;
using Git.ViewModels.Repositories;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext dbContext;

        public RepositoriesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(string name, string repositoryType, string userId)
        {

            var repository = new Repository()
            {
                CreatedOn = DateTime.UtcNow,
                Name = name,
                IsPublic = repositoryType == "Public" ? true : false,
                OwnerId = userId,
                
            };

            this.dbContext.Repositories.Add(repository);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<AllRepositoryViewModel> GetAll()
        {
            var problems = this.dbContext.Repositories
                .Where(x=>x.IsPublic)
                .Select(x => new AllRepositoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedOn = x.CreatedOn,
                    Owner = x.Owner.Username,
                    CommitsCount = x.Commits.Count
                })
                .ToList();

            return problems;
        }

        public string GetNameById(string id)
        {
            var repoName = dbContext.Repositories
                .Where(x=>x.Id == id)
                .Select(x => x.Name)
                .FirstOrDefault();
            return repoName;
        }
    }
}
