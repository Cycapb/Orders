using System.Collections.Generic;

namespace Businesslogic
{
    public interface IUnloader<in T> where T:class
    {
        void Unload(IEnumerable<T> items);
    }
}