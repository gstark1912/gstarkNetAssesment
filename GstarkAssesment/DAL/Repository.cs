using DAL.Context;
using DAL.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AssesmentDbContext _contexto;
        protected DbSet<T> dbSet { get; set; }

        public Repository(IUnitOfWork unitOfWork)
        {
            _contexto = unitOfWork.DbContext;
            dbSet = _contexto.Set<T>();
        }

        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity", "An entity can't be null.");

            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            _contexto.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            dbSet.Remove(this.GetByID(id));
        }

        public T GetByID(int id)
        {
            return dbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public void SaveChanges()
        {
            _contexto.SaveChanges();
        }
    }
}
