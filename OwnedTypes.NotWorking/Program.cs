using OwnedTypes.Models;
using System;
using System.Linq;

namespace OwnedTypes.NotWorking
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TestDbContext db = new TestDbContext())
            {
                #region Step1

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                db.Applicants.Add(new Applicant(new FullName(FirstName.Create("Amila"), LastName.Create("Udayanga"))));

                var person = new Person(new FullName(FirstName.Create("Amila"), LastName.Create("Udayanga")));
                person.Address = new Address { Line1 = "Line1", Line2 = "Line2" };
                db.People.Add(person);
                db.SaveChanges();

                #endregion
            }

            using (TestDbContext db = new TestDbContext())
            {
                #region Step2

                var people = db.People.FirstOrDefault();
                var applicants = db.Applicants.ToList();
                var addresses = db.Addresses.ToList();

                #endregion
            }
        }
    }
}
