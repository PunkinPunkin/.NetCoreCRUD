using DAL.Models;
using DAL.UnitOfWork;
using LibServer.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMyDbUnit _unit;

        public HomeController(ILogger<HomeController> logger, IMyDbUnit unit)
        {
            _logger = logger;
            _unit = unit;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ApUser user)
        {
            _unit.Repository<ApUser>().Insert(user);
            _unit.Commit();
            return RedirectToAction("ShowUser", "Home", new { id = user.Id });
        }

        public IActionResult Edit(string id)
        {
            ApUser user = _unit.Repository<ApUser>().Find(int.Parse(id));
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(ApUser editUser)
        {
            _unit.Repository<ApUser>().Update(editUser);
            _unit.Repository<LoginRecord>().Insert(new LoginRecord { Comment = "測試UnitOfWork", UserId = editUser.Id, Result = 1, System = "Test", LoginIp = "127.0.0.1" });

            _unit.Commit();
            return RedirectToAction("UserList", "Home");
        }

        public IActionResult Delete(string id)
        {
            ApUser user = _unit.Repository<ApUser>().Find(int.Parse(id));
            _unit.Repository<ApUser>().Delete(user);
            _unit.Commit();
            return RedirectToAction("UserList", "Home");
        }

        public IActionResult ShowUser(string id)
        {
            ApUser user = _unit.Repository<ApUser>().Find(int.Parse(id));
            return View(user);
        }

        [Route("{searchString?}/{pageNumber:int?}")]
        public IActionResult UserList(
            string searchString,
            int? pageNumber)
        {
            if (pageNumber == null)
                pageNumber = 1;

            var list = _unit.Repository<ApUser>().Query;
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(s => s.LastName.Contains(searchString) || s.FirstName.Contains(searchString));
            }

            return View(_unit.Repository<ApUser>().GetPaged(m => list.OrderBy(s => s.Account), pageNumber.Value));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
