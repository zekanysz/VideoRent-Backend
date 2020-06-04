using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoRent.Models;

namespace VideoRent.Services
{
    public class CustomerService
    {

        MovieRentContext dbContext;
        public CustomerService(MovieRentContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Customer> Get()
        {
            return dbContext.Customers.AsEnumerable();
        }


        public Customer Get(int id)
        {
            return dbContext.Customers.SingleOrDefault(p => p.CustomerId.Equals(id));
        }

        public string GetNameById(int id)
        {
            return dbContext.Customers.SingleOrDefault(p => p.CustomerId.Equals(id)).FirstName + " " + dbContext.Customers.SingleOrDefault(p => p.CustomerId.Equals(id)).LastName;
        }


        public Customer Create(Customer customer)
        {
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();

            return customer;
        }
        public bool Update(Customer customer)
        {
            dbContext.Update(customer);

            return dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            try
            {
                dbContext.Customers.Remove(new Customer()
                {
                    CustomerId = id
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
