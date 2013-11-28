using Webbox.DataAccess.Dtos;

namespace Webbox.DataAccess
{
    public class Migrate
    {
        public static void Now()
        {
            using (var db = new WebboxContext())
            {
                db.Movies.Add(new Movie() {Name = "Star Wars"});
                db.Movies.Add(new Movie() {Name = "Evil Dead"});
                db.Movies.Add(new Movie() {Name = "Platoon"});
                db.Movies.Add(new Movie() {Name = "Rocky"});
                db.Movies.Add(new Movie() {Name = "First Blood"});
                db.Movies.Add(new Movie() {Name = "Friday 13th"});
                db.Movies.Add(new Movie() {Name = "Das Boot"});
                
                db.SaveChanges();
            }
        }
    }
}
