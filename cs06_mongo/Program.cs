// See https://aka.ms/new-console-template for more information
using cs06_mongo;
using cs06_mongo.Model;

MongoCRUD db = new MongoCRUD("playground");
Address add1 = new Address
{
    Street = "Mihai Viteazu",
    Municipality = "Cluj-Napoca",
    StreetNumber = 3
};
db.Create("AddressBook", add1);
foreach(var rec in db.List<Address>("AddressBook"))
{
    Console.WriteLine($"--> {rec.Id}: {rec.Street} {rec.Municipality} {rec.StreetNumber}");
}
