using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mappers.Abstractions
{
    public abstract class MultipleEntitiesMapper<T, K> : ISingleEntityMapper<T, K>, IMultipleEntitiesMapper<T, K>
    {
        public IList<T> Map(IList<K> mapEntities)
        {
            IList<T> mappedEntities = new List<T>();

            foreach (K mapEntity in mapEntities)
            {
                T mappedEntity = this.Map(mapEntity);

                mappedEntities.Add(mappedEntity);
            }

            return mappedEntities;
        }

        public abstract T Map(K mapEntity);
    }
}
