using SULS.Services;
using SULS.ViewModels.Problems;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SULS.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateInputModel inputModel)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(inputModel.Name) 
                || inputModel.Name.Length < 5
                 || inputModel.Name.Length > 20)
            {
                return this.Error("Name should be between 5 and 20 characters.");
            }

            if (inputModel.TotalPoints < 50 || inputModel.TotalPoints > 300)
            {
                return this.Error("Points should be between 50 and 300.");
            }

            this.problemsService.Create(inputModel.Name, inputModel.TotalPoints);

            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.problemsService.GetById(id);
            return this.View(viewModel);
        }
    }
}
