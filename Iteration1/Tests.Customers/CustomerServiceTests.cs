using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using App.Models;
using App.Data;
using App.Services.Validation;
using App.Services.Finance;
using App.Services;

namespace Tests.Customers
{
    [TestClass]
    public class CustomerServiceTests
    {
        [TestMethod]
        public void ValidCustomerCreated()
        {
            // Customer
            var customer = new ValidCustomerImportantClient();
            var customerRepoMock = new Mock<IRepository<Customer>>();
            customerRepoMock.Setup(m => m.Create(customer)).Returns(true);

            // Company
            var companyMock = new Mock<Company>();
            companyMock.Object.Id = 2;
            companyMock.Object.Name = "ImportantClient";

            var companyRepoMock = new Mock<IRepository<Company>>();
            companyRepoMock.Setup(m => m.Get(2)).Returns(companyMock.Object);

            // Credit Service
            var creditServiceMock = new Mock<ICustomerCreditService>();
            creditServiceMock.Setup(m => m.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth)).Returns(1000);
            var customerCreditChecker = new CustomerCreditChecker(creditServiceMock.Object, companyRepoMock.Object);

            // Validation Service
            var valDict = new GenericValidationDictionary();
            var validator = new CustomerValidator(valDict);


            var customerService = new CustomerService(validator, customerRepoMock.Object, companyRepoMock.Object, customerCreditChecker);

            Assert.IsNotNull(customerService);

            var result = customerService.Create(customer);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InvalidCustomerNotCreated()
        {
            // Customer
            var customer = new InvalidCustomerTooYoung();
            var customerRepoMock = new Mock<IRepository<Customer>>();
            customerRepoMock.Setup(m => m.Create(customer)).Returns(true);

            // Company
            var companyMock = new Mock<Company>();
            companyMock.Object.Id = 1;
            companyMock.Object.Name = "ImportantClient";

            var companyRepoMock = new Mock<IRepository<Company>>();
            companyRepoMock.Setup(m => m.Get(1)).Returns(companyMock.Object);

            // Credit Service
            var creditServiceMock = new Mock<ICustomerCreditService>();
            creditServiceMock.Setup(m => m.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth)).Returns(1000);
            var customerCreditChecker = new CustomerCreditChecker(creditServiceMock.Object, companyRepoMock.Object);

            // Validation Service
            var valDict = new GenericValidationDictionary();
            var validator = new CustomerValidator(valDict);


            var customerService = new CustomerService(validator, customerRepoMock.Object, companyRepoMock.Object, customerCreditChecker);

            var result = customerService.Create(customer);

            Assert.IsFalse(result);
        }

        // etc...
    }
}
