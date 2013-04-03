using System;
using System.Collections.Generic;
using System.IO;

namespace Runner
{
    public static class ItemParser
    {
        private static IEnumerable<string> ReadFrom(string file)
        {
            using (var reader = File.OpenText(file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        public static List<MovieCategory> Parse(string filename)
        {
            var items = new List<MovieCategory>();
            MovieCategory currentMovieCategory = null;
            foreach (string line in ReadFrom("Items.txt"))
            {
                if (!line.StartsWith("\t"))
                {
                    currentMovieCategory = new MovieCategory { Name = line.Trim(), Movies = new List<Movie>() };
                    items.Add(currentMovieCategory);
                }
                else
                {
                    string[] tokens = line.Replace("\t", "").Split('|');
                    var subItem = new Movie { Name = tokens[0], Description = tokens[1] };
                    if (currentMovieCategory == null)
                        continue; //invalid format of file
                    currentMovieCategory.Movies.Add(subItem);
                }
            }
            return items;
        }
    }
}