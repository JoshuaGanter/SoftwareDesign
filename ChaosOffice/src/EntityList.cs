using System.Collections.Generic;

namespace ChaosOffice
{
    public class EntityList<T> : List<T>
        where T : Entity
    {
        public bool Contains(string entityName)
        {
            return Exists(entity => entity.Name.ToLower() == entityName.ToLower());
        }
        
        public T Get(string entityName)
        {
            int entityIndex = FindIndex(entity => entity.Name.ToLower() == entityName.ToLower());
            if (entityIndex != -1)
            {
                return this[entityIndex];
            }
            else
            {
                return null;
            }
        }

        public bool Remove(string entityName)
        {
            if (TryGet(entityName, out T entity))
            {
                return Remove(entity);
            }
            else
            {
                return false;
            }
        }

        public bool TryGet(string entityName, out T entity)
        {
            entity = Get(entityName);
            return entity != null;
        }
    }
}