namespace MindfireSolutions.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MindfireSolutions.Models.MindfireDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MindfireSolutions.Models.MindfireDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //



            List<ContactType> addContact = new List<ContactType>();

            addContact.Add(new ContactType() { ContactTypeValue = "Mobile" });
            addContact.Add(new ContactType() { ContactTypeValue = "Fax" });
            addContact.Add(new ContactType() { ContactTypeValue = "Home" });
            addContact.Add(new ContactType() { ContactTypeValue = "Office" });
            addContact.Add(new ContactType() { ContactTypeValue = "Landline" });

            context.GetContactType.AddRange(addContact);

            List<Role> addRole = new List<Role>();
            addRole.Add(new Role() { RolePosition = "Admin" });
            addRole.Add(new Role() { RolePosition = "User" });

            context.GetRoleType.AddRange(addRole);

            Employee addEmployee = new Employee();
            addEmployee.Firstname = "Naibedya";
            addEmployee.Lastname = "Kar";
            addEmployee.Address = "Mindfire Solutions";
            addEmployee.Email = "naibedyak@mindfiresolutions.com";
            addEmployee.Password = Hash.GetHash("Ejaz@123");
            addEmployee.EmployeeImage = @"\UploadImage\naibedyak@mindfiresolutions.com.jpg";

            context.GetEmployeeDetails.Add(addEmployee);

            EmployeeContact contact = new EmployeeContact();
            contact.ContactNumber = "877693273";
            contact.ContactTypeDetails = addContact.Single(s => s.ContactTypeValue == "Mobile");
            contact.EmployeeDetails = addEmployee;

            context.GetContactDetails.Add(contact);


            Access access = new Access();
            access.EmployeeUserDetails = addEmployee;
            access.RoleDetails = addRole.Single(s => s.RolePosition == "Admin");

            context.GetAccessType.Add(access);
        }
    }
}
