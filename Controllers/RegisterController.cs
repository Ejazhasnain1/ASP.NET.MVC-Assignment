using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MindfireSolutions.CRUD_Functionality;
using MindfireSolutions.ViewModel;
using System.IO;
using MindfireSolutions.Models;
using MindfireSolutions.CustomHelper;

namespace MindfireSolutions.Controllers
{
    public class RegisterController : Controller
    {
        MindfireDbContext dbReference = new MindfireDbContext();
        // GET: Register
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(MindfireEmployeeRegister employeeRegister)
        {
            if (ModelState.IsValid)
            {
                if (dbReference.GetEmployeeDetails.Where(m => m.Email == employeeRegister.Email).SingleOrDefault() == null)
                {
                    string extension = Path.GetExtension(Path.GetFileName(employeeRegister.ImageUpload.FileName));
                    if (FileValidate.IsFileValid(extension))
                    {
                        if (ContactValidate.IsContactValid(employeeRegister))
                        {
                            var email = new Create().SaveData(employeeRegister);
                            Session["user"] = email;
                            return RedirectToAction("DisplayUserDetails", "Details");
                        }
                        else
                        {
                            TempData["contactError"] = "*Enter Valid number";
                            return View();
                        }
                    }
                    else
                    {
                        TempData["fileError"] = "Only Image files(.jpg .png .jpeg) can be uploaded";
                        return View();
                    }
                }
                else
                {
                    TempData["emailError"] = "Email-Id already Exists";
                    return View();
                }
            }

            return View();
        }

        public JsonResult UsernameAvailablity(string userEmail)
        {
            var userInput = new MindfireDbContext().GetEmployeeDetails.Where(m => m.Email == userEmail).SingleOrDefault();
            return userInput != null ? Json(0) : Json(1);
        }
    }
}