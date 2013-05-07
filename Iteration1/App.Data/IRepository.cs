using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Models;

namespace App.Data
{
    public interface IRepository<T>
    {
        bool Create(T obj);
        T Get(int id);
    }
}
