using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoRent.Models;

namespace VideoRent.Services
{
    public class MovieService
    {

        MovieRentContext dbContext;
        public MovieService(MovieRentContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Movie> Get()
        {
            return dbContext.Movies.AsEnumerable();
        }

        public IEnumerable<Movie> GetAvailable()
        {
            return dbContext.Movies.AsEnumerable().Where(x => x.MovieStatus == MovieStatus.Available);
        }

        public Movie Get(int id)
        {
            return dbContext.Movies.SingleOrDefault(p => p.MovieId.Equals(id));
        }


        public string GetTitleById(int id)
        {
            return dbContext.Movies.SingleOrDefault(p => p.MovieId.Equals(id)).Title;
        }

        public Movie Create(Movie movie)
        {
            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();

            return movie;
        }

        public bool Update(Movie movie)
        {
            dbContext.Update(movie);

            return dbContext.SaveChanges() > 0;
        }


        public bool Delete(int id)
        {
            try
            {
                dbContext.Movies.Remove(new Movie()
                {
                    MovieId = id
                });
                dbContext.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
    }
}
