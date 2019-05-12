using System;
using System.Diagnostics;
using System.Linq;

using DAL.Repositories.Generic;
using DAL.Repositories.Generic.User;

using Domain.Models;

namespace ConsoleApp1.Examples
{
    public class GenericExample : ExampleBase
    {
        public IUserRepositoryGeneric UserRepository { get; }
        public IGenericRepository<UserModel> GenericRepository { get; }

        public GenericExample(IUserRepositoryGeneric userRepository, IGenericRepository<UserModel> genericRepository)
        {
            UserRepository = userRepository;
            GenericRepository = genericRepository;
        }

        public override void Test()
        {
            //short query to disable cold start
            var usersImpl = UserRepository.GetAll();

            Console.WriteLine(usersImpl.Count());

            TestImplemented();

            //short query to disable cold start
            var usersGnr = GenericRepository.GetAll();

            Console.Write(usersGnr.Count());

            TestGeneric();
        }

        public void TestImplemented()
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

            TestResults.Results.Add($"Result of generic repository(impl):{total / Count}ms \n\n");
        }

        public void TestGeneric()
        {
            var stopwatch = new Stopwatch();

            var total = 0.0;

            for (var i = 0; i < Count; i++)
            {
                stopwatch.Start();

                var users = GenericRepository.GetAll();

                foreach (var user in users)
                    Console.Write(user.Id);

                total += stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }

            TestResults.Results.Add($"Result of generic repository(gnr):{total / Count}ms \n\n");
        }
    }
}