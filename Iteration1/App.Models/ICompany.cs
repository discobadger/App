using System;
namespace App.Models
{
    public interface ICompany
    {
        Classification Classification { get; set; }
        int Id { get; set; }
        string Name { get; set; }
    }
}
