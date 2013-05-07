using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models;
using App.Data;

namespace App.Services.Validation
{
    public sealed class CustomerValidator : IValidator<Customer>
    {
        private IValidationDictionary _validation;

        public IValidationDictionary Validation 
        {
            get { return _validation; } 
        }

        public CustomerValidator(IValidationDictionary validation)
        {
            _validation = validation;
        }

        /// <summary>
        /// Validates the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        public bool Validate(Customer customer)
        {
            if (!customer.Firstname.IsPopulated())
                _validation.Add("Firstname", "Firstname not specified");

            if (!customer.Surname.IsPopulated())
                _validation.Add("Surname", "Surname not specified");

            if (!customer.EmailAddress.Contains("@") && !customer.EmailAddress.Contains("."))
                _validation.Add("Email", "Invalid Email");

            var now = DateTime.Now;
            int age = now.Year - customer.DateOfBirth.Year;
            if (now.Month < customer.DateOfBirth.Month || (now.Month == customer.DateOfBirth.Month && now.Day < customer.DateOfBirth.Day)) age--;

            if (age < 21)
                _validation.Add("Age", "Not old enough to drink in the USA");


            return _validation.IsValid;
        }
    }
}
