using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models;

namespace App.Services
{
    public interface ICustomerService
    {
        bool Create(Customer customer);
    }
}
