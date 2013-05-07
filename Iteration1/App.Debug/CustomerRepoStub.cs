using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Data;
using App.Models;

namespace App.Debug
{
    public class CustomerRepoStub : IRepository<Customer>
    {
        #region IRepository<Customer> Members

        bool IRepository<Customer>.Create(Customer obj)
        {
            return true;
        }

        Customer IRepository<Customer>.Get(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
