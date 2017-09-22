using ecom.Models;
using System.Collections.Generic;
namespace ecom.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}