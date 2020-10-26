namespace SULS.Services
{
    public interface ISubmissionsService
    {
        void Create(string problemId, string userId, string code);

        string GetNameById(string id);

        void Delete(string id);
    }
}
