using MindfireSolutions.CRUD_Functionality;
using MindfireSolutions.Models;
using MindfireSolutions.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MindfireSolutions.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        MindfireDbContext obj = new MindfireDbContext();
        // GET: Admin
        [Authorize]
        public ActionResult AdminDetails()
        {
            string email = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
            var employee = new Read().ReadData(email);
            return View(employee);
        }

        [HttpGet]
        public ActionResult EditUsersDetails(int id)
        {
            var emp = obj.GetEmployeeDetails.Where(m => m.EmployeeId == id).SingleOrDefault();
            return Json(emp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDetails(EditEmployeeDetails emp)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var employee = obj.GetEmployeeDetails.Where(m => m.EmployeeId == emp.EmployeeId).SingleOrDefault();
                new Edit().EditDetails(employee.Email, emp);
                return Json(new { success = true, }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult UserDetails()
        {
            string email = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
            var emp = obj.GetEmployeeDetails.Where(m => m.Email != email).ToList();
            return View(emp);
        }

        public ActionResult ViewUserDetails(int UserId)
        {
            var getEmployeeDetails = obj.GetEmployeeDetails.Where(m => m.EmployeeId == UserId).SingleOrDefault();
            var employee = new Read().ReadData(getEmployeeDetails.Email);
            return View(employee);
        }

        [HttpGet]
        public ActionResult DeleteUser(int UserId)
        {
            var getEmployeeDetails = obj.GetEmployeeDetails.Single(m => m.EmployeeId == UserId);
            obj.GetEmployeeDetails.Remove(getEmployeeDetails);
            obj.SaveChanges();
            return RedirectToAction("UserDetails", "Admin");
        }
    }
}