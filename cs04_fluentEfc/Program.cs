// See https://aka.ms/new-console-template for more information
using cs04_fluentEfc.Data;
using cs04_fluentEfc.Models;

Console.WriteLine("Hello, World!");
AppDbContext db = new AppDbContext();
db.Users.Add(new User { Firstname = "Charlie", Lastname = "Brown" });
db.SaveChanges();
foreach (var r in db.Records.GroupBy(x => x.UserId).ToList())
{
    Console.WriteLine(r.Key.ToString() + " " + r.Count());
}