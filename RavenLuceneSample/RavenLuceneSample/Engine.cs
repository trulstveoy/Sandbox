using System;
using System.Reflection;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;

namespace RavenLuceneSample
{
    public class Engine
    {
        private readonly EmbeddableDocumentStore _documentStore;

        public Engine()
        {
            _documentStore = new EmbeddableDocumentStore {RunInMemory = true};
            _documentStore.Initialize();
        }

        public void CreateIndex(Assembly assembly)
        {
            IndexCreation.CreateIndexes(assembly, _documentStore);
        }

        public void WithSession(Action<IDocumentSession> action)
        {
            using (var session = _documentStore.OpenSession())
            {
                action(session);
            }
        }
    }
}