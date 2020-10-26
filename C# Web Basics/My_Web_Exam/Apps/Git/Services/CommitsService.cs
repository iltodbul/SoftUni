using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Git.Data;
using Git.Models;
using Git.ViewModels.Commits;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext dbContext;

        public CommitsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public string Create(string description, string userId, string repoId)
        {
            var entity = new Commit()
            {
                Description = description,
                CreatedOn = DateTime.Now,
                CreatorId = userId,
                RepositoryId = repoId,
            };

            this.dbContext.Commits.Add(entity);
            this.dbContext.SaveChanges();

            return entity?.Id;
        }

        public bool Delete(string Id)
        {
            var entity = this.dbContext.Commits.FirstOrDefault(x => x.Id == Id);

            if (entity == null)
            {
                return false;
            }

            this.dbContext.Commits.Remove(entity);
            this.dbContext.SaveChanges();

            return true;
        }

        public IEnumerable<CommitViewModel> GetAll(string userId)
        {
            return this.dbContext.Commits
                .Where(x => x.CreatorId == userId)
                .Select(x => new CommitViewModel()
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    repoName = x.Repository.Name,
                    Description = x.Description,
                }).ToList();
        }

        public bool IsUserACreator(string userId, string commitId)
        {
            var entity = this.dbContext.Commits.FirstOrDefault(x => x.Id == commitId);

            if (entity == null || entity.CreatorId != userId) return false;
            else return true;
        }
    }
}
