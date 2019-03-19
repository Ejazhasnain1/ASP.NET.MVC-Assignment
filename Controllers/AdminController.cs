using MindfireSolutions.CRUD_Functionality;
using MindfireSolutions.Models;
using MindfireSolutions.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MindfireSolutions.Controllers
{
    public class AdminController : Controller
    {
        MindfireDbContext obj = new MindfireDbContext();
        // GET: Admin
        public ActionResult AdminDetails()
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


        [HttpGet]
        public ActionResult EditUsersDetails(int id)
        {
            var emp = obj.GetEmployeeDetails.Where(m => m.EmployeeId == id).SingleOrDefault();
            return Json(emp, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EditDetails(EditEmployeeDetails emp)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var getEmployeeDetails = obj.GetEmployeeDetails.Where(m => m.EmployeeId == emp.EmployeeId).SingleOrDefault();
                    getEmployeeDetails.Firstname = emp.Firstname;
                    getEmployeeDetails.Lastname = emp.Lastname;
                    getEmployeeDetails.Address = emp.Address;
                    obj.SaveChanges();
                    return Json(new { success = true, }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return RedirectToAction("LoginUser", "Login");
            }
        }



        public ActionResult UserDetails()
        {
            try
            {
                var temp = Convert.ToString(Session["user"]);
                var emp = obj.GetEmployeeDetails.Where(m => m.Email != temp).ToList();
                return View(emp);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }



        public ActionResult ViewUserDetails(int UserId)
        {
            try
            {
                var getEmployeeDetails = obj.GetEmployeeDetails.Where(m => m.EmployeeId == UserId).SingleOrDefault();
                var getContactDetailsList = obj.GetContactDetails.Where(m => m.EmployeeId == getEmployeeDetails.EmployeeId).Include(m => m.ContactTypeDetails).ToList();
                MindfireEmployeeDetails employee = new MindfireEmployeeDetails();

                employee.EmployeeId = getEmployeeDetails.EmployeeId;
                employee.Firstname = getEmployeeDetails.Firstname;
                employee.Lastname = getEmployeeDetails.Lastname;
                employee.Email = getEmployeeDetails.Email;
                employee.Address = getEmployeeDetails.Address;
                employee.EmployeeImage = getEmployeeDetails.EmployeeImage;
                employee.GetEmployeeContactList = getContactDetailsList;

                return View(employee);
            }
            catch
            {
                return RedirectToAction("UserDetails", "Admin");
            }
        }


        [HttpGet]
        public ActionResult DeleteUser(int UserId)
        {
            try
            {
                var getEmployeeDetails = obj.GetEmployeeDetails.Single(m => m.EmployeeId == UserId);
                obj.GetEmployeeDetails.Remove(getEmployeeDetails);
                obj.SaveChanges();
                return RedirectToAction("UserDetails", "Admin");
            }
            catch
            {
                return RedirectToAction("UserDetails", "Admin");
            }
        }
    }
}


