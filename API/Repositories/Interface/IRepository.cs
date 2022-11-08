﻿namespace API.Repositories.Interface
{
    public interface IRepository<Entity> where Entity : class
    {
        public IEnumerable<Entity> Get();
        public Entity GetById(int id);
        public int Create(Entity Entity);
        public int Update(Entity Entity);
        public int Delete(int id);
    }
}
