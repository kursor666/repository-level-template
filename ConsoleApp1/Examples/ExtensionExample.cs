using System;
using System.Diagnostics;
using System.Linq;

using DAL;
using DAL.Repositories.ExtensionRepository;

using Domain.Models;

namespace ConsoleApp1.Examples
{
    public class ExtensionExample : ExampleBase
    {
        public Storage Storage { get; }
        public IExtensionRepository<UserModel> UserRepository { get; }

        public ExtensionExample(Storage storage, IExtensionRepository<UserModel> userRepository)
        {
            Storage = storage;
            UserRepository = userRepository;
        }

        public override void Test()
        {
            //short query to disable cold start
            var usersImpl = UserRepository.GetAll();
                
            Console.WriteLine(usersImpl.Count());
            
            TestStorage();
            
            //short query to disable cold start
            var usersGnr = UserRepository.GetAll();
                
            Console.WriteLine(usersGnr.Count());
            
            TestGeneric();
        }

        public void TestStorage()
        {
            var repository = Storage.Get<UserModel>();
            
            var stopwatch = new Stopwatch();

            var total = 0.0;
            
            for (var i = 0; i < Count; i++)
            {
                stopwatch.Start();
                
                var users = repository.GetAll();
                
                foreach (var user in users)
                    Console.Write(user.Id);

                total += stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }

            TestResults.Results.Add($"Result of extension repository(str):{total / Count}ms \n\n");
        }

        public void TestGeneric()
        {
            var stopwatch = new Stopwatch();

            var total = 0.0;
            
            for (var i = 0; i < Count; i++)
            {
                stopwatch.Start();
                
                var users = UserRepository.GetAll();
                
                foreach (var user in users)
                    Console.Write(user.Id);

                total += stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }

            TestResults.Results.Add($"Result of extension repository(gnr):{total / Count}ms \n\n");
        }
    }
}
