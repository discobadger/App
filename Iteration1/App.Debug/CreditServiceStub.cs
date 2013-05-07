using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Services.Finance;

namespace App.Debug
{
    public class CreditServiceStub : ICustomerCreditService
    {
        #region ICustomerCreditService Members

        int ICustomerCreditService.GetCreditLimit(string firstname, string surname, DateTime dateOfBirth)
        {
            return 1000;
        }

        #endregion
    }
}
