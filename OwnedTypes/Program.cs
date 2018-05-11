using OwnedTypes.Models;
using System;
using System.Linq;

namespace OwnedTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TestDbContext db = new TestDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                db.Applicants.Add(new Applicant(new FullName(FirstName.Create("Amila"), LastName.Create("Udayanga"))));

                var person = new Person(new FullName(FirstName.Create("Amila"), LastName.Create("Udayanga")));
                person.Address = new Address { Line1 = "Line1", Line2 = "Line2" };
                db.People.Add(person);
                db.SaveChanges();
            }

            using (TestDbContext db = new TestDbContext())
            {
                var people = db.People.FirstOrDefault();
                var applicants = db.Applicants.ToList();
                var addresses = db.Addresses.ToList();
            }
        }
    }
}
