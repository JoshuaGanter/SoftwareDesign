using System.Collections.Generic;

namespace ChaosOffice
{
    public class EntityList<T> : List<T>
        where T : Entity
    {
        public bool Contains(string entityName)
        {
            foreach(Entity entity in this)
            {
                if (entity.Name == entityName)
                {
                    return true;
                }
            }
            return false;
        }
        public T Get(string entityName)
        {
            foreach(Entity entity in this)
            {
                if (entity.Name == entityName)
                {
                    return (T) entity;
                }
            }
            return null;
        }

        public bool TryGet(string entityName, out T entity)
        {
            if(Contains(entityName))
            {
                entity = Get(entityName);
                return true;
            }
            else
            {
                entity = null;
                return false;
            }
        }
    }
}