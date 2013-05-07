using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using App.Data;
using App.Models;
using App.Services.Finance;

namespace Tests.Customers
{
    [TestClass]
    public class CreditServiceTests
    {
        [TestMethod]
        public void CustomerFromVeryImportantClientHasNoCreditLimit()
        {
            var customer = new ValidCustomerVeryImportantClient();

            var companyMock = new Mock<Company>();
            companyMock.Object.Id = 1;
            companyMock.Object.Name = "VeryImportantClient";

            var companyRepoMock = new Mock<IRepository<Company>>();
            companyRepoMock.Setup(m => m.Get(1)).Returns(companyMock.Object);

            var creditServiceMock = new Mock<ICustomerCreditService>();
            creditServiceMock.Setup(m => m.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth)).Returns(1000);

            var creditChecker = new CustomerCreditChecker(creditServiceMock.Object, companyRepoMock.Object);

            var result = creditChecker.GetResultFor(customer);

            Assert.IsFalse(result.HasCreditLimit);
            Assert.IsFalse(result.Failed);
        }

        [TestMethod]
        public void CustomerFromImportantClientDoublesCreditLimit()
        {
            var customer = new ValidCustomerImportantClient();

            var companyMock = new Mock<Company>();
            companyMock.Object.Id = 2;
            companyMock.Object.Name = "ImportantClient";

            var companyRepoMock = new Mock<IRepository<Company>>();
            companyRepoMock.Setup(m => m.Get(2)).Returns(companyMock.Object);

            var creditServiceMock = new Mock<ICustomerCreditService>();
            creditServiceMock.Setup(m => m.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth)).Returns(1000);

            var creditChecker = new CustomerCreditChecker(creditServiceMock.Object, companyRepoMock.Object);

            var result = creditChecker.GetResultFor(customer);

            Assert.IsTrue(result.HasCreditLimit);
            Assert.IsFalse(result.Failed);
            Assert.AreEqual(2000, result.Limit);
        }

        [TestMethod]
        public void CustomerFromUnrecognisedCompanyHasStandardCredit()
        {
            var customer = new ValidCustomerNonTrustedCompany();

            var companyMock = new Mock<Company>();
            companyMock.Object.Id = 3;
            companyMock.Object.Name = "FakeHipsterHandbags.com";

            var companyRepoMock = new Mock<IRepository<Company>>();
            companyRepoMock.Setup(m => m.Get(3)).Returns(companyMock.Object);

            var creditServiceMock = new Mock<ICustomerCreditService>();
            creditServiceMock.Setup(m => m.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth)).Returns(1000);

            var creditChecker = new CustomerCreditChecker(creditServiceMock.Object, companyRepoMock.Object);

            var result = creditChecker.GetResultFor(customer);

            Assert.IsTrue(result.HasCreditLimit);
            Assert.IsFalse(result.Failed);
            Assert.AreEqual(1000, result.Limit);
        }

        [TestMethod]
        public void CustomerWithBadCreditFailsCreditCheck()
        {
            var customer = new ValidCustomerNonTrustedCompany();

            var companyMock = new Mock<Company>();
            companyMock.Object.Id = 3;
            companyMock.Object.Name = "FakeHipsterHandbags.com";

            var companyRepoMock = new Mock<IRepository<Company>>();
            companyRepoMock.Setup(m => m.Get(3)).Returns(companyMock.Object);

            var creditServiceMock = new Mock<ICustomerCreditService>();
            creditServiceMock.Setup(m => m.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth)).Returns(100);

            var creditChecker = new CustomerCreditChecker(creditServiceMock.Object, companyRepoMock.Object);

            var result = creditChecker.GetResultFor(customer);

            Assert.IsTrue(result.HasCreditLimit);
            Assert.IsTrue(result.Failed);
            Assert.AreEqual(100, result.Limit);
        }
    }
}
