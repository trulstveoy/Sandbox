using System.Data.Entity;
using Webbox.DataAccess.Dtos;

namespace Webbox.DataAccess
{
    public class WebboxContext : DbContext
    {
        static WebboxContext()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public WebboxContext() : base("Webbox")
        {}

        public DbSet<Movie> Movies { get; set; } 
    }
}
