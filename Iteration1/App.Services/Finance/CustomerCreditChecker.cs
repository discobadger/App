using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Data;
using App.Models;

namespace App.Services.Finance
{
    public sealed class CustomerCreditChecker : ICreditChecker
    {
        private ICustomerCreditService _creditChecker;
        private IRepository<Company> _companyRepo;

        public CustomerCreditChecker(ICustomerCreditService creditChecker, IRepository<Company> companyRepoistory)
        {
            _companyRepo = companyRepoistory;
            _creditChecker = creditChecker;
        }

        public CreditResult GetResultFor(Customer customer)
        {
            return CheckCredit(customer);
        }

        protected CreditResult CheckCredit(Customer customer)
        {
            var company = _companyRepo.Get(customer.Company.Id);
            var result = new CreditResult();

            result.Failed = false;

            if (company.Name == "VeryImportantClient")
            {
                // Skip credit check
                result.HasCreditLimit = false;
            }
            else if (company.Name == "ImportantClient")
            {
                // Do credit check and double credit limit
                result.HasCreditLimit = true;
                var creditLimit = _creditChecker.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth);
                result.Limit = (creditLimit * 2);
            }
            else
            {
                // Do credit check
                result.HasCreditLimit = true;
                var creditLimit = _creditChecker.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth);
                result.Limit = creditLimit;
            }

            if (result.HasCreditLimit && result.Limit < 500)
            {
                result.Failed = true;
            }

            return result;
        }
    }
}
