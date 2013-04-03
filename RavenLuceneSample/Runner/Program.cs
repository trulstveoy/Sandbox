using System;
using System.Collections.Generic;
using System.Linq;
using RavenLuceneSample;

namespace Runner
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Testing RavenDB with lucene");

            Console.WriteLine("Parsing Items.txt");
            List<MovieCategory> items = ItemParser.Parse("Items.txt");

            var engine = new Engine();
            engine.CreateIndex(typeof(Program).Assembly);
            StoreItems(engine, items);
            Print(Search(engine, "& Supsense~"));
            Print(Search(engine, "Pinocchio"));
        }

        private static void Print(List<MovieCategory> movieCategories)
        {
            foreach (MovieCategory movieCategory in movieCategories)
            {
                Console.WriteLine(movieCategory.Id + " " + movieCategory.Name);
            }
        }

        private static List<MovieCategory> Search(Engine engine, string query)
        {
           List<MovieCategory> movieCategories = null;

           engine.WithSession(session =>
                                  {
                                      movieCategories =
                                          session.Advanced.LuceneQuery<MovieCategory, CategoryAndMoviesIndex>()
                                                 .Search(x => x.Name, query)
                                                 .Search(x => x.Movies.Select(y => y.Name), query)
                                                 .WaitForNonStaleResults()
                                                 .ToList();
                                  });

            return movieCategories;
        }

        private static void StoreItems(Engine engine, IEnumerable<MovieCategory> items)
        {
           
            foreach (MovieCategory itemVal in items)
            {
                MovieCategory movieCategory = itemVal;
                engine.WithSession(session =>
                                       {
                                           session.Store(movieCategory);
                                           session.SaveChanges();
                                       });
            }
        }
    }
}
