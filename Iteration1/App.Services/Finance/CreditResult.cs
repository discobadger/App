using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Services.Finance
{
    public class CreditResult
    {
        public bool Failed { get; set; }
        public int Limit { get; set; }
        public bool HasCreditLimit { get; set; }
    }
}
