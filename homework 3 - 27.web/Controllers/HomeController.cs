using homework_3___27.data;
using homework_3___27.web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace homework_3___27.web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress; Initial Catalog=people 1 - 25; Integrated Security=true;";
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowPeople()
        {
            PeopleDB db = new PeopleDB(_connectionString);
            var vm = new PeopleViewModel
            {
                Peoples = db.GetPeoples()
            };
            if (TempData["message"] != null)
            {
                vm.Message = (string)TempData["message"];
            }

            return View(vm);
        }

        public IActionResult AddPeople()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPeople(List<People> peoples)
        {
            var db = new PeopleDB(_connectionString);
            db.AddMany(peoples);
            TempData["message"] = $"{peoples.Count} people have been added!";
            return Redirect("/home/showpeople");
        }
    }
}