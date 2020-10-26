using Git.Services;
using Git.ViewModels.Repositories;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(RepositoryCreateInputModel inputModel)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrEmpty(inputModel.Name)
                || inputModel.Name.Length < 3
                || inputModel.Name.Length > 10)
            {
                return this.Error("Invalid name. The name should be between 3 and 10 characters.");
            }

            var userId = this.GetUserId();
            this.repositoriesService.Create(inputModel.Name, inputModel.RepositoryType, userId);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse All()
        {
            var model = repositoriesService.GetAll();

            return this.View(model);
        }
    }
}
