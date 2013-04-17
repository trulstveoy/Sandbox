using System;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Version = Lucene.Net.Util.Version;

namespace LuceneInMemory
{
    public class Engine
    {
        public Engine()
        {
            var directory = new RAMDirectory();
            var analyzer = new StandardAnalyzer(Version.LUCENE_30);

            using (var indexWriter = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.LIMITED))
            {
                for (int i = 0; i < 10000; i++)
                {
                    Console.Write(".");
                    var document = new Document();
                    document.Add(new Field("Id", i.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                    document.Add(new Field("Name", "Name" + i.ToString(), Field.Store.YES, Field.Index.ANALYZED));
                    indexWriter.AddDocument(document);
                }
            }

            Console.ReadKey();

            var queryParser = new QueryParser(Version.LUCENE_30, "Name", analyzer);
            var query = queryParser.Parse("Name37~");

            IndexReader indexReader = IndexReader.Open(directory, true);
            var searcher = new IndexSearcher(indexReader);

            TopDocs resultDocs = searcher.Search(query, indexReader.MaxDoc);
        }
    }
}
