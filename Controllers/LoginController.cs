using MindfireSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MindfireSolutions.ViewModel;

namespace MindfireSolutions.Controllers
{
    public class LoginController : Controller
    {
        MindfireDbContext reference = new MindfireDbContext();
        // GET: Login
        public ActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginUser(EmployeeLogin emp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string localPassword = Hash.GetHash(emp.Password);
                    var value = reference.GetEmployeeDetails.Where(m => m.Email.Equals(emp.Email) && m.Password.Equals(localPassword)).SingleOrDefault();

                    if (value != null)
                    {
                        Session["user"] = emp.Email;
                        return RedirectToAction("DisplayUserDetails", "Details");
                    }
                    else
                    {
                        TempData["error"] = "*Invalid Username or Password";
                        return RedirectToAction("LoginUser");
                    }
                }
                catch (Exception)
                {
                    TempData["error"] = "*Invalid Username or Password";
                    return RedirectToAction("LoginUser");
                }
            }
            return View("LoginUser");
        }
    }
}