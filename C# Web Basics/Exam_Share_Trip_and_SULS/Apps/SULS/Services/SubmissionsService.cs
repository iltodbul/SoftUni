using System;
using System.Linq;
using SULS.Data;
using SULS.Models;

namespace SULS.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly SULSContext dbContext;
        private readonly Random random;

        public SubmissionsService(SULSContext dbContext, Random random)
        {
            this.dbContext = dbContext;
            this.random = random;
        }

        public void Create(string problemId, string userId, string code)
        {
            var problemMaxPoint = dbContext.Problems
                .Where(x => x.Id == problemId)
                .Select(x => x.Points)
                .FirstOrDefault();

            var submission = new Submission()
            {
                ProblemId = problemId,
                UserId = userId,
                Code = code,
                CreatedOn = DateTime.UtcNow,
                AchievedResult = this.random.Next(0, problemMaxPoint + 1)
            };

            this.dbContext.Submissions.Add(submission);
            this.dbContext.SaveChanges();
        }

        public string GetNameById(string id)
        {
            var problemName = dbContext.Problems
                .FirstOrDefault(x => x.Id == id);

            return problemName?.Name;
        }

        public void Delete(string id)
        {
            var submission = this.dbContext.Submissions.Find(id);

            this.dbContext.Submissions.Remove(submission);
            this.dbContext.SaveChanges();
        }
    }
}
