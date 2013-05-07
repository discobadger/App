using System;
namespace App.Services.Validation
{
    public interface IValidator<T>
    {
        bool Validate(T obj);
    }
}
