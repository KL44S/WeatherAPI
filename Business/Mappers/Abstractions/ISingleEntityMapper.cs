using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mappers.Abstractions
{ 
    public interface ISingleEntityMapper<T, K>
    {
        T Map(K mapEntity);
    }
}
