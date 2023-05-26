using EasyCash.DataAccessLayer.Abstract;
using EasyCash.DataAccessLayer.Concrete;
using EasyCash.DtoLayer;
using EasyCash.DtoLayer.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyCash.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly Context _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetList(Expression<Func<T, bool>> filter)
        {
            /*
                // Fiyatı 15 TL üzerinde olan ürünleri filtreleyen bir lambda ifadesi
                Expression<Func<T, bool>> highPriceProductsFilter = p => p.Price > 15.0m;

                // Filtrelenmiş ürünleri al
                List<T> highPriceProducts = repository.GetAll(highPriceProductsFilter);
             */
            return _context.Set<T>().Where(filter).ToList();
        }

        public void Insert(T t)
        {

            _context.Set<T>().Add(t);
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            _context.Set<T>().Update(t);
            _context.SaveChanges();
        }
    }
}
