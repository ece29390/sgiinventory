using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGInventory.Test.Data
{
    public abstract class TestDataBase<T> where T:class,new()
    {
        protected T _entity;
        protected List<T> _entities;

        protected TestDataBase()
        {
            _entity = new T();
            _entities = new List<T>();
        }

        public T GetEntity()
        {
            return _entity;
        }
        public List<T> GetEntities()
        {
            return _entities;
        }
    }
}
