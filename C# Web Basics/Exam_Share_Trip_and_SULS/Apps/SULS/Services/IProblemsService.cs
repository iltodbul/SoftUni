using System.Collections.Generic;
using SULS.ViewModels.Problems;

namespace SULS.Services
{
    public interface IProblemsService
    {
        void Create(string name, int totalPoints);

        IEnumerable<HomePageProblemViewModel> GetAll();

        ProblemViewModel GetById(string id);
    }
}
