using Microsoft.EntityFrameworkCore;
using MyECommerce.BLL.Abstract;
using MyECommerce.DAL.Context;
using MyECommerce.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyECommerce.BLL.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MyECommerceContext _db;
        private readonly DbSet<T> _entities;

        public GenericRepository(MyECommerceContext myECommerceContext)
        {
            _db = myECommerceContext;
            _entities = _db.Set<T>();
        }

        public string Create(T entity)
        {
            try
            {
                _entities.Add(entity);
                _db.SaveChanges();
                return "Veri Başarıyla Eklendi";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string Delete(T entity)
        {
            try
            {
                var deleted = GetById(entity.Id);
                deleted.Status=Entity.Enum.Status.Deleted;
                Update(deleted);
                return "Veri Silindi";


            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.Where(x => x.Status == Entity.Enum.Status.Created || x.Status == Entity.Enum.Status.Updated);
        }

        public T GetById(int id)
        {
            var entity = _entities.Find(id);
            return entity;
        }

        public string Update(T entity)
        {
            string result = "";
            try
            {
                switch (entity.Status)
                {
                    
                    case Entity.Enum.Status.Created:
                        entity.Status = Entity.Enum.Status.Updated;
                        _db.Entry(entity).State = EntityState.Modified;
                        _db.SaveChanges();
                        result = "Veri Güncellendi";
                        break;
                    
                    case Entity.Enum.Status.Deleted:
                        entity.Status= Entity.Enum.Status.Deleted;
                        _db.SaveChanges();
                        result = "Veri Güncellendi";
                        break;
                    
                }               
            }
            catch (Exception ex)
            {

               return ex.Message;
            }

            return result;
        }
    }
}
