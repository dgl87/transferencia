using System;
using System.Linq;
using System.Threading.Tasks;
using MongoDataAccess.DataAccess;
using MongoDataAccess.Models;
using MongoDB.Driver;

namespace MongoDBDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ChoreDataAccess db = new ChoreDataAccess();
            await db.CreateUser(user: new UserModel()
            {
                FirstName = "Douglas",
                LastName = "Paiva"
            });

            var users = await db.GetAllUsers();

            var chore = new ChoreModel()
            {
                AssignedTo = users.First(),
                ChoreText = "Mow the Lawn",
                FrequencyInDays = 7
            };

            await db.CreateChore(chore);

            //usando transaction somente com datasets na nuvem
            var chores = await db.GetAllChores();

            var newChore = chores.First();
            newChore.LastCompleted = DateTime.UtcNow;

            await db.CompleteChore(newChore);

            //string connectionString = "mongodb://localhost:27017";
            //string databaseName = "simple_db";
            //string collectionName = "people";

            //var client = new MongoClient(connectionString);
            //var db = client.GetDatabase(databaseName);
            //var collection = db.GetCollection<PersonModel>(collectionName);

            //var person = new PersonModel
            //{
            //    FirstName = "Pedro",
            //    LastName = "Silva"
            //};
            //await collection.InsertOneAsync(person);

            //var results = await collection.FindAsync(_ => true);

            //foreach (var result in results.ToList())
            //{
            //    Console.WriteLine(value:$"{result.Id}: {result.FirstName} {result.LastName}");
            //}
        }
    }
}