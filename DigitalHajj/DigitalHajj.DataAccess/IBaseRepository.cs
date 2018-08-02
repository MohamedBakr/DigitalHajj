using System.Collections.Generic;

namespace DigitalHajj.DataAccess
{
    public interface IBaseRepository<Entity>
    {
        void Add(Entity entity);
        void Delete(Entity id);
        IEnumerable<Entity> GetAll();
        Entity GetDetails(Entity id);
        void Update(Entity prod);
    }
}