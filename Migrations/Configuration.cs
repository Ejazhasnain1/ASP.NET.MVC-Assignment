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
        }
    }
}
