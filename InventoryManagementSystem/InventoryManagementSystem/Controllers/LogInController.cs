using BusinessLayer.BusinessLogic;
using BusinessLayer.Interfaces;
using DataLayer.Models;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class LogInController : Controller
    {
        private readonly Inventory_Management_systeamEntities _dbContext=new Inventory_Management_systeamEntities();
        private readonly ILoginBusinessLogic _loginBusinessLogic=new LoginBusinessLogic();
        public LogInController()
        {

        }
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(LogIn objUser)
        {

            string message = string.Empty;
            tbUser obj = new tbUser();
            if (ModelState.IsValid)
            {
                obj = _loginBusinessLogic.LoginUser(objUser);
                if (obj != null)
                {
                    Session["UserID"] = obj.UserId.ToString();
                    Session["Email"] = obj.Email.ToString();
                    Session["AuthenticatedUser"]= obj.FirstName.ToString();
                    return RedirectToAction("DisplayItems","Item");

                }
                else
                {
                    message = "Username and/or password is incorrect.";

                    ViewBag.Message = message;
                }
            }
            return View(obj);
        }

        public ActionResult LogOut()
        {
            Session["UserID"] = null;
            Session["Email"] = null;
            Session["AuthenticatedUser"] = null;
            return RedirectToAction("Login");
        }
    }
}