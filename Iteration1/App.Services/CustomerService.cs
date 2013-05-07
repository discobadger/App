using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using App.Models;
using App.Data;
using App.Services.Validation;
using App.Services.Finance;

namespace App.Services
{
    public sealed class CustomerService : ICustomerService
    {
        private IRepository<Customer> _customerRepo;
        private IRepository<Company> _companyRepo;
        private IValidator<Customer> _validator;
        private ICreditChecker _creditChecker;

        private Customer _customer;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        /// <param name="validator">The validator.</param>
        /// <param name="repository">The repository.</param>
        public CustomerService(IValidator<Customer> validator, IRepository<Customer> customerRepository, IRepository<Company> companyRepository, ICreditChecker creditChecker)
        {
            _validator = validator;
            _customerRepo = customerRepository;
            _companyRepo = companyRepository;
            _creditChecker = creditChecker; 
        }

        /// <summary>
        /// Validates and then creates a new customer based on the given customer details
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>TRUE if successful</returns>
        public bool Create(Customer customer)
        {
            _customer = customer;

            // Basic validation logic
            if (!_validator.Validate(_customer))
                return false;

            // Check customers credit, applies rules based on company
            if (!CheckCredit())
                return false;

            // Add new record to datastore
            return _customerRepo.Create(_customer);
        }

        /// <summary>
        /// Checks the credit.
        /// </summary>
        /// <returns></returns>
        protected bool CheckCredit()
        {
            var result = _creditChecker.GetResultFor(_customer);

            if (result.Failed)
                return false; // probably want to add appropiate error here

            _customer.CreditLimit = result.Limit;
            _customer.HasCreditLimit = result.HasCreditLimit;

            return true;
        }
    }
}
