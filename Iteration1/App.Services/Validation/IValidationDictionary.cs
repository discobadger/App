using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Services.Validation
{
    public interface IValidationDictionary
    {
        void Add(string key, string message);
        bool IsValid { get; }
    }
}
