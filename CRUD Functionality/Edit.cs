using MindfireSolutions.Models;
using MindfireSolutions.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MindfireSolutions.CRUD_Functionality
{
    public class Edit
    {
        MindfireDbContext obj = new MindfireDbContext();
        public void EditDetails(string userEmail, EditEmployeeDetails emp)
        {
            var getEmployeeDetails = obj.GetEmployeeDetails.Where(m => m.Email == userEmail).SingleOrDefault();
            getEmployeeDetails.Firstname = emp.Firstname;
            getEmployeeDetails.Lastname = emp.Lastname;
            getEmployeeDetails.Address = emp.Address;
            obj.SaveChanges();
        }
    }
}