using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MindfireSolutions.Models
{
    public class EmployeeContact
    {
        [Column(Order =0)]
        [Key]
        public int ContactId { get; set; }


        
        [Column(Order = 2)]
        public string ContactNumber { get; set; }



        [Column(Order = 3)]
        [ForeignKey("ContactTypeDetails")]
        public int ContactTypeId { get; set; }

        public ContactType ContactTypeDetails { get; set; }



        [Column(Order = 1)]
        [ForeignKey("EmployeeDetails")]        
        public int EmployeeId { get; set; }

        public Employee EmployeeDetails { get; set; }

       

      
    }
}














//List<ContactType> addContact = new List<ContactType>();

//addContact.Add(new ContactType() { ContactTypeValue = "Mobile" });
//            addContact.Add(new ContactType() { ContactTypeValue = "Fax" });
//            addContact.Add(new ContactType() { ContactTypeValue = "Home" });
//            addContact.Add(new ContactType() { ContactTypeValue = "Office" });
//            addContact.Add(new ContactType() { ContactTypeValue = "Landline" });

//            context.GetContactType.AddRange(addContact);

//            List<Role> addRole = new List<Role>();
//addRole.Add(new Role() { RolePosition = "Admin" });
//            addRole.Add(new Role() { RolePosition = "User" });
//            context.GetRoleType.AddRange(addRole);

//            Employee addEmployee = new Employee();
//addEmployee.Firstname = "Naibedya";
//            addEmployee.Lastname = "Kar";
//            addEmployee.Address = "Mindfire Solutions";
//            addEmployee.Email = "naibedyak@mindfiresolutions.com";
//            addEmployee.Password = Hash.GetHash("Ejaz@123");
//            addEmployee.EmployeeImage = @"\UploadImage\naibedyak@mindfiresolutions.com.jpg";

//            context.GetEmployeeDetails.Add(addEmployee);

//            Access access = new Access();
//var emp = context.GetEmployeeDetails.Where(m => m.Email == "naibedyak@mindfiresolutions.com").SingleOrDefault();

//access.EmployeeId = emp.EmployeeId;
//            access.RoleId = 1;

//            context.GetAccessType.Add(access);