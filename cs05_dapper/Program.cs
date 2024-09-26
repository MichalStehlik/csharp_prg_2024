// See https://aka.ms/new-console-template for more information
using cs05_dapper.Models;
using Dapper;
using System.Data.SqlClient;

string cs = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Tasks01;Integrated Security=True;Connect Timeout=30";
using (var conn = new SqlConnection(cs))
{
    conn.Open();
    var version = conn.ExecuteScalar<string>("SELECT @@VERSION");
    Console.WriteLine(version);
    // INSERT
    var q = "INSERT INTO Users (UserId, Firstname, Lastname) Values ('" + Guid.NewGuid() + "', 'Richard','Black')";
    int result = conn.Execute(q);
    Console.WriteLine($"Inserted {result} rows");
    // INSERT with parameters
    var u = new User { UserId = Guid.NewGuid(), Firstname = "Francis", Lastname = "Daniels" };
    q = "INSERT INTO Users (UserId, Firstname, Lastname) Values (@UserId, @Firstname, @Lastname)";
    result = conn.Execute(q, u);
    Console.WriteLine($"Inserted {result} rows");
    // SELECT
    var users = conn.Query<User>("SELECT * FROM Users");
    foreach (var user in users)
    {
        Console.WriteLine($"{user.UserId} {user.Firstname} {user.Lastname}");
    }
}