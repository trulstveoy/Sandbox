using System.Linq;
using Raven.Abstractions.Indexing;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace Runner
{
    public class CategoryAndMoviesIndex : AbstractIndexCreationTask
    {
        public override IndexDefinition CreateIndexDefinition()
        {
            return new IndexDefinitionBuilder<MovieCategory>
                       {
                           Map = categories => from category in categories
                                               select new
                                                          {
                                                              category.Name,
                                                              Movies = category.Movies.Select(x => new[] {x.Name, x.Description})
                                                          },
                           Indexes =
                               {
                                   {x => x.Name, FieldIndexing.Analyzed},
                                   {x => x.Movies.Select(y => y.Name), FieldIndexing.Analyzed},
                                   {x => x.Movies.Select(y => y.Description), FieldIndexing.Analyzed},
                               }
                       }.ToIndexDefinition(new DocumentConvention());
        }
    }
}