using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Services.Validation;

namespace Tests.Customers
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void InvalidCustomerTooYoung()
        {
            var validationDict = new GenericValidationDictionary();
            var customer = new InvalidCustomerTooYoung();

            var validator = new CustomerValidator(validationDict);

            var result = validator.Validate(customer);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InvalidCustomerBadEmail()
        {
            var validationDict = new GenericValidationDictionary();
            var customer = new InvalidCustomerBadEmail();

            var validator = new CustomerValidator(validationDict);

            var result = validator.Validate(customer);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidCustomer()
        {
            var validationDict = new GenericValidationDictionary();
            var customer = new ValidCustomerNonTrustedCompany();

            var validator = new CustomerValidator(validationDict);

            var result = validator.Validate(customer);

            Assert.IsTrue(result);
        }

        // Other required tests : Firstname, Surname, Firstname and Surname
    }
}
