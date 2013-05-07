using System;
using App.Models;
namespace App.Services.Finance
{
    public interface ICreditChecker
    {
        CreditResult GetResultFor(Customer customer);
    }
}
