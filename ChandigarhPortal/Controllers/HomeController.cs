using ChandigarhPortal.Models;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ChandigarhPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Login objUser)
        {
            if (ModelState.IsValid)
            {
                var obj = new ChandigarhAPI.Controllers.UsersController().AutheticateUser(objUser);
                if (obj != null && obj.RoleId == 1)
                {
                    return RedirectToAction();
                }
                else
                {

                }
                //using (DB_Entities db = new DB_Entities())
                //{
                //    var obj = db.UserProfiles.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                //    if (obj != null)
                //    {
                //        Session["UserID"] = obj.UserId.ToString();
                //        Session["UserName"] = obj.UserName.ToString();
                //        return RedirectToAction("UserDashBoard");
                //    }
                //}
            }
            return View(objUser);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}