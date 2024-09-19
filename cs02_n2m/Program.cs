// See https://aka.ms/new-console-template for more information
using cs02_n2m.Data;
using Microsoft.EntityFrameworkCore;

AppDbContext db = new AppDbContext();
var at = db.Authors.Include(a => a.Books).ToList();
foreach (var a in at)
{
    Console.WriteLine(a.Firstname + " " + a.Lastname);
    foreach (var b in a.Books)
    {
        Console.WriteLine(" - " + b.Title);
    }
}