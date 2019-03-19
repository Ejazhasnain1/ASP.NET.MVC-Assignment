using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MindfireSolutions.Models;
using MindfireSolutions.ViewModel;
using System.Data.Entity;
using MindfireSolutions.CRUD_Functionality;
using System.Web.Security;

namespace MindfireSolutions.Controllers
{
    public class DetailsController : Controller
    {
        // GET: Details
        public ActionResult DisplayUserDetails()
        {
            try
            {
                if (Convert.ToString(Session["user"]) != null)
                {
                    var employee = new Read().ReadData(Convert.ToString(Session["user"]));
                    return View(employee);
                }
                else
                    return RedirectToAction("LoginUser", "Login");
            }
            catch
            {
                return RedirectToAction("LoginUser", "Login");
            }

        }


        [HttpPost]
        public ActionResult EditUserDetails(EditEmployeeDetails emp)
        {
            try
            {
                if (Convert.ToString(Session["user"]) != null)
                {
                    if (!ModelState.IsValid)
                    {
                        return Json(new { success = false, }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        new Edit().EditDetails(Convert.ToString(Session["user"]), emp);
                        return Json(new { success = true, }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                    return RedirectToAction("LoginUser", "Login");
            }
            catch (Exception)
            {
                return RedirectToAction("LoginUser", "Login");
            }
        }




        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            this.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            this.Response.Cache.SetNoStore();
            return RedirectToAction("Index", "Home");
        }
    }
}
