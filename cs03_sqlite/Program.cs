// See https://aka.ms/new-console-template for more information
using cs03_sqlite.Data;

AppDbContext db = new AppDbContext();
//db.Database.EnsureDeleted();
//db.Database.EnsureCreated(); // náhrada migrací pro sqlite
var humans = db.Humans.ToList();
foreach (var human in humans)
{
    Console.WriteLine($"{human.Firstname} {human.Lastname}");
}