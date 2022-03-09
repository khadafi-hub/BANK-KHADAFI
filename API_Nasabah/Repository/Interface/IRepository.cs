using System.Collections.Generic;

namespace API_Nasabah.Repository.Interface
{
    public interface IRepository<Entity, Key> where Entity : class
    {
        IEnumerable<Entity> Get(); // Get Semua Data Entry
        Entity Get(Key key); // Get Data Berdasarkan Key
        int Insert(Entity entity); // Insert Data Ke entity
        int Update(Entity entity, Key key); // Update Data Ke entity Berdasarkan key
        int Delete(Key key); // Delete Data Berdasarkan key

    }
}

