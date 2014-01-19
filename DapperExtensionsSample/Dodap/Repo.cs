using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using DapperExtensions;
using Dodap.Dto;

namespace Dodap
{
    public class Repo
    {
        private readonly Action<Action<DbConnection>> _connectionFactory;
        
        public Repo(Action<Action<DbConnection>> connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Insert(IEnumerable<Customer> items)
        {
            _connectionFactory(connection => connection.Insert(items));
        }

        public IEnumerable<Customer> GetList()
        {
            IEnumerable<Customer> items = null;
            _connectionFactory(connection => items = connection.GetList<Customer>());
            return items;
        }

        public IEnumerable<Customer> GetStartingWithR()
        {
            IEnumerable<Customer> items = null;
            _connectionFactory(connection =>
            {
                IFieldPredicate predicate = Predicates.Field<Customer>(f => f.Name, Operator.Like, "r%");
                items = connection.GetList<Customer>(predicate);
            });
            return items;
        }   

        public IEnumerable<Customer> GetPaged(int page)
        {
            IEnumerable<Customer> items = null;
            _connectionFactory(connection =>
            {
                IFieldPredicate predicate = Predicates.Field<Customer>(f => f.Name, Operator.Like, "r%");

                ISort sort = Predicates.Sort<Customer>(f => f.Name);

                items = connection.GetPage<Customer>(predicate, new[] {sort}, page, 3).ToList();
            });
            return items;
        }
    }
}
