using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Data;
using App.Models;

namespace App.Debug
{
    public class CompanyRepoStub : IRepository<Company>
    {
        #region IRepository<Company> Members

        bool IRepository<Company>.Create(Company obj)
        {
            throw new NotImplementedException();
        }

        Company IRepository<Company>.Get(int id)
        {
            return new Company() { Classification = Classification.Gold, Id = 1, Name = "VeryImportantClient" };
        }

        #endregion
    }
}
