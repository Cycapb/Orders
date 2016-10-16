using System.Collections.Generic;

namespace Businesslogic
{
    public interface IUnloader<in T> where T:class
    {
        string Unload(IEnumerable<T> items);
    }
}