using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoRent.Models;

namespace VideoRent.Services
{
    public class RentService
    {
        MovieRentContext dbContext;
        public RentService(MovieRentContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Rent> Get()
        {
            return dbContext.Rents.AsEnumerable();
        }

        public Rent Get(int id)
        {
            return dbContext.Rents.SingleOrDefault(p => p.RentId.Equals(id));
        }

        public Rent Create(Rent rent)
        {
            dbContext.Rents.Add(rent);
            dbContext.SaveChanges();

            return rent;
        }
        public bool Update(Rent rent)
        {
            dbContext.Update(rent);

            return dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            try
            {
                dbContext.Rents.Remove(new Rent()
                {
                    RentId = id
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
