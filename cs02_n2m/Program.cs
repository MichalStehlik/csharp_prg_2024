// See https://aka.ms/new-console-template for more information
using cs02_n2m.Data;
using Microsoft.EntityFrameworkCore;

AppDbContext db = new AppDbContext();
var at = db.Authors.Include(a => a.BookAuthors).ThenInclude(ba => ba.Book).ToList();
foreach (var a in at)
{
    Console.WriteLine(a.Firstname + " " + a.Lastname);
    foreach (var ba in a.BookAuthors)
    {
        Console.WriteLine(" - " + ba.Book?.Title);
    }
}