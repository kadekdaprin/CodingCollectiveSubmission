using CodingCollectiveSubmission.Models;
using CodingCollectiveSubmission.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodingCollectiveSubmission.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly RepositoryWrapper _repository;

        public HomeController(RepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Employees([FromForm] DataTableAjaxPostModel model)
        {
            string orderBy = model.order[0].column switch
            {
                1 => nameof(EmployeeModel.JobTitle),
                2 => nameof(EmployeeModel.Salary),
                _ => nameof(EmployeeModel.Name),
            };

            string orderByDir = model.order[0].dir;

            var result = _repository.Employee
                .GetEmployees(
                    model.search.value,
                    orderBy,
                    orderByDir,
                    model.start,
                    model.length);

            result.draw = model.draw;

            return Json(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}