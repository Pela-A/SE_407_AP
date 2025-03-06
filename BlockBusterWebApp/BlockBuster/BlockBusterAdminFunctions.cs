using BlockBuster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBuster
{
    public class BlockBusterAdminFunctions
    {

        public static void AddMovie(Movie movie)
        {
            try
            {
                using (var db = new Se407BlockBusterContext())
                {
                    db.Movies
                        .Add(movie);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void DeleteMovie(int id)
        {
            try
            {
                using (var db = new Se407BlockBusterContext())
                {
                    var movieToDelete = db.Movies.Find(id);
                    db.Movies.Remove(movieToDelete);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void EditMovie(Movie movie)
        {
            try
            {
                using (var db = new Se407BlockBusterContext())
                {
                    db.Movies.Update(movie);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }


    }
}
