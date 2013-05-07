using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Services.Validation
{
    public sealed class GenericValidationDictionary : IValidationDictionary
    {

        private Dictionary<string,string> _validationErrors;

        public GenericValidationDictionary()
        {
            _validationErrors = new Dictionary<string, string>(); 
        }

        public void Add(string key, string message)
        {
            _validationErrors.Add(key, message);
        }

        public bool IsValid
        {
            get { return !(_validationErrors.Count() > 0); }
        }
    }
}