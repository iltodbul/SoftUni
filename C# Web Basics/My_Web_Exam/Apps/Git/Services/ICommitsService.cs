using System;
using System.Collections.Generic;
using System.Text;
using Git.ViewModels.Commits;

namespace Git.Services
{
    public interface ICommitsService
    {
        string Create(string description, string userId, string repoId);

        IEnumerable<CommitViewModel> GetAll(string userId);

        bool IsUserACreator(string userId, string commitId);

        bool Delete(string Id);
    }
}
