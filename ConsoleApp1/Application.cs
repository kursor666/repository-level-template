using System;
using System.Collections.Generic;
using System.Linq;

using ConsoleApp1.Examples;

using DAL;

using Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    class Application
    {
        public DataContext DataContext { get; }
        public IEnumerable<ExampleBase> ExampleBases { get; }

        public Application(DataContext dataContext, IEnumerable<ExampleBase> exampleBases)
        {
            DataContext = dataContext;
            ExampleBases = exampleBases;
        }

        public void Run()
        {
            MigrateAndSeed();

            foreach (var exampleBase in ExampleBases)
            {
                exampleBase.Test();
            }

            Console.WriteLine("\n\n");
            foreach (var result in TestResults.Results)
            {
                Console.WriteLine(result);
            }
        }

        private void MigrateAndSeed()
        {
            DataContext.Database.Migrate();

            if (!DataContext.Users.Any())
                for (var i = 0; i < 1000; i++)
                {
                    DataContext.Users.Add(new UserModel
                    {
                        IsActive = true,
                        IsTestBoolProperty = true
                    });
                }

            if (!DataContext.Documents.Any())
                for (var i = 0; i < 500; i++)
                {
                    DataContext.Documents.Add(new DocumentModel
                    {
                        IsActive = true
                    });
                }

            DataContext.SaveChanges();
        }
    }

    public static class TestResults
    {
        public static List<string> Results { get; } = new List<string>();
    }
}