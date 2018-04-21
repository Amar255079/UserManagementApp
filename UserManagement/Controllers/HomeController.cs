using System;
using System.Linq;
using System.Web.Mvc;
using UserManagement.Models;
using UserManagement.Service;
using UserManagement.Web.Models;
using PagedList;
using AutoMapper;

namespace UserManagement.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserService userService;
        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult StaticStates(int CountryID)
        {
            return Json(WebHelper.StateList.Where(x => x.CountryID == CountryID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult StaticCities(int StateID)
        {
            return Json(WebHelper.CityList.Where(x => x.StateID == StateID), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Users(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var users = userService.GetUsers();
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s =>
               s.LastName.ToUpper().Contains(searchString.ToUpper())
                ||
               s.FirstName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(s => s.LastName);
                    break;
                default:
                    users = users.OrderBy(s => s.LastName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Register()
        {
            UserViewModel model = new UserViewModel();
            WebHelper.LoadUserViewModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = Mapper.Map<UserViewModel, UserManagement.Domain.User>(model);
                    userService.CreateUser(user);
                    return RedirectToAction("Users");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Register");
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}