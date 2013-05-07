using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models;

namespace Tests.Customers
{
    public class ValidCustomerVeryImportantClient : Customer
    {
        public ValidCustomerVeryImportantClient()
        {
            Firstname = "Wolfgang";
            Surname = "Mozart";
            EmailAddress = "overture@opera.com";
            DateOfBirth = DateTime.Now.AddYears(-22);
            Company = new Company() { Id = 1 };
        }
    }

    public class ValidCustomerImportantClient : Customer
    {
        public ValidCustomerImportantClient()
        {
            Firstname = "Wolfgang";
            Surname = "Mozart";
            EmailAddress = "overture@opera.com";
            DateOfBirth = DateTime.Now.AddYears(-22);
            Company = new Company() { Id = 2 };
        }
    }

    public class ValidCustomerNonTrustedCompany : Customer
    {
        public ValidCustomerNonTrustedCompany()
        {
            Firstname = "Wolfgang";
            Surname = "Mozart";
            EmailAddress = "overture@opera.com";
            DateOfBirth = DateTime.Now.AddYears(-22);
            Company = new Company() { Id = 3 };
        }
    }

    public class InvalidCustomerTooYoung : Customer
    {
        public InvalidCustomerTooYoung()
        {
            Firstname = "Wolfgang";
            Surname = "Mozart";
            EmailAddress = "overture@opera.com";
            DateOfBirth = DateTime.Now.AddYears(-18);
            Company = new Company() { Id = 1 };
        }
    }

    public class InvalidCustomerBadEmail : Customer
    {
        public InvalidCustomerBadEmail()
        {
            Firstname = "Wolfgang";
            Surname = "Mozart";
            EmailAddress = "overture";
            DateOfBirth = DateTime.Now.AddYears(-22);
            Company = new Company() { Id = 1 };
        }
    }
}
