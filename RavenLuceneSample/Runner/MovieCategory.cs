using System.Collections.Generic;

namespace Runner
{
    public class MovieCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
    
    public class Movie
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
