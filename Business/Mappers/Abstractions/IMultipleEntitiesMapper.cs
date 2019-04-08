using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mappers.Abstractions
{
    public interface IMultipleEntitiesMapper<T, K>
    {
        IList<T> Map(IList<K> mapEntities);
    }
}
