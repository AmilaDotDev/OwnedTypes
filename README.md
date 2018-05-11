# OwnedTypes
This repository contains code to demonstrate an error I'm getting when using Proxies in EF Core 2.1.0-rc1-final

OwnedTypes project is working without any exception. 

OwnedTypes.NotWorking gives an exception when I query for data already in the database.

# What's Comman between OwnedTypes Project and OwnedTypes.NotWorking project

They both uses EF Core 2.1.0-rc1-final

They both have the following model.

![](OwnedTypes.jpg)

`FullName`, `FirstName` and `LastName` are OwnedTypes (`ValueObjects` in `DDD`)

Both console applications will Create a database called OwnedTypesTestDb in your localdb, insert some data and query those inserted data.

`Program.cs` has the following code

```
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
```

As you can see, I have two `using` statements. It works fine if I have the code as follows (all the code in one `using` statement).

```
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

            var people = db.People.FirstOrDefault();
            var applicants = db.Applicants.ToList();
            var addresses = db.Addresses.ToList();
        }
    }
}
```

# Difference between OwnedTypes project and OwnedTypes.NotWorking project

OwnedTypes.NotWorking is using Microsoft.EntityFrameworkCore.Proxies and the model is updated with what's required for Proxies to work (i.e. Virtual Navigation Properties, called `UseLazyLoadingProxies()` in `DbContext` configuration)