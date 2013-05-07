using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models;
using System.Data.SqlClient;

namespace App.Data
{
    public sealed class CustomerRepository : IRepository<Customer>
    {
        public bool Create(Customer customer)
        {
            bool created = true;
            try
            {
                CustomerDataAccess.AddCustomer(customer);
            }
            catch (SqlException ex)
            {
                // not allowed to modify lower class
                created = false;
                // do extra handling
            }
            return created;
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
