using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models;
using App.Services;
using App.Data;
using App.Services.Finance;
using App.Services.Validation;

namespace App.Debug
{
    public class MyPerson : Customer
    {
        public MyPerson()
        {
            Firstname = "Wolfgang";
            Surname = "Mozart";
            EmailAddress = "overture@opera.com";
            DateOfBirth = DateTime.Now.AddYears(-22);
            Company = new Company() { Id = 1 };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var customer = new MyPerson();

            var vali = new CustomerValidator(new GenericValidationDictionary());
            var cusrepo = new CustomerRepoStub();
            var comprepo = new CompanyRepoStub();
            var csvr = new CreditServiceStub();
            var cc = new CustomerCreditChecker(csvr, comprepo);

            var cs = new CustomerService(vali, cusrepo, comprepo, cc);

            if (!cs.Create(customer))
            {
                // show validation messages
            }
            else
            {
                Console.WriteLine("buy many, many products now ok");
            }

            Console.ReadKey();
        }
    }
}
