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
        private BSModel _context;

        public Repository(BSModel context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }
    }
}
