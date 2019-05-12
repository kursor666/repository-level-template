using System;
using System.Diagnostics;
using System.Linq;

using DAL.Repositories.Simple;

namespace ConsoleApp1.Examples
{
    public class SimpleExample : ExampleBase
    {
        public IUserRepositorySimple RepositorySimple { get; }

        public SimpleExample(IUserRepositorySimple repositorySimple)
        {
            RepositorySimple = repositorySimple;
        }

        public override void Test()
        {
            //short query to disable cold start
            var users = RepositorySimple.GetAll();

            Console.WriteLine(users.Count());

            TestSimple();
        }

        public void TestSimple()
        {
            var stopwatch = new Stopwatch();

            var total = 0.0;

            for (var i = 0; i < Count; i++)
            {
                stopwatch.Start();

                var users = RepositorySimple.GetAll();

                foreach (var user in users)
                    Console.Write(user.Id);

                total += stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }

            TestResults.Results.Add($"Result of simple repository:{total / Count}ms \n\n");
        }
    }
}