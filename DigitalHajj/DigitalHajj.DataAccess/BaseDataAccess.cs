using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper.FastCrud;

namespace DigitalHajj.DataAccess
{
    public class BaseDataAccess<Entity> : IBaseRepository<Entity>
    {
        public BaseDataAccess(IDbConnection dbConnection)
        {
            DbConnection = dbConnection;
        }

        public IDbConnection DbConnection { get; }

        public void Add(Entity entity)
        {
            DbConnection.Insert(entity);
        }

        public IEnumerable<Entity> GetAll()
        {
            return DbConnection.Find<Entity>();
        }

        public Entity GetDetails(Entity entity)
        {
            return DbConnection.Get<Entity>(entity);
        }

        public void Delete(Entity entity)
        {
            DbConnection.Delete(entity);
        }

        public void Update(Entity entity)
        {
            DbConnection.Update(entity);
        }

    }
}
