using bingshopLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bingshopLibrary.Repositories
{
    public class Repository<T> where T : class  //抽象類別有不完整實作類別
    {
        public IQueryable<T> GetAll<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            return _context.Set<T>().OrderBy(keySelector);
        }

        private BSModel _context;

        protected BSModel Context
        { get { return _context; } }

        public Repository(BSModel context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
            _context = context;
        }


        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }


    }
}
