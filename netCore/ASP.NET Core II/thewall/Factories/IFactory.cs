using thewall.Models;
using System.Collections.Generic;

namespace thewall.Factories
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}