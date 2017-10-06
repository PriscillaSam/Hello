using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindConsoleApplication.Data;

namespace NorthwindConsoleApplication.Domain
{

    /// <summary>
    /// Customer Related Operations
    /// </summary>
    public class CustomerManager
    {
        private NORTHWNDEntities dbContext;

        public CustomerManager()
        {
            dbContext = new NORTHWNDEntities();
        }


        public string AddCustomer(Customer customer)
        {
            var newCustomer = dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
            if (newCustomer != null)
            {
                return customer.CustomerID;
            }
            else
            {
                return null;
            } 
            //throw new NotImplementedException();
        }

        public List<Customer> GetCustomers()
        {
            var data = dbContext.Customers.ToList();
            return data;
            //throw new NotImplementedException();

        }
        public bool UpdateCustomer(CustomerManager customer)
        {
            dbContext.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            int result = dbContext.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public List<Customer> SearchCustomerById(string id)
        {
            var customers = dbContext.Customers.Where(p => p.CustomerID.Contains(id));
            if(customers != null)
            {
                return customers.ToList();
            }
            else
            {
                return null;
            }
        }

        public Customer GetCustomerById(string id)
        {
            var data = dbContext.Customers.FirstOrDefault(p => p.CustomerID == id);
            return data;
        }
    }
}
