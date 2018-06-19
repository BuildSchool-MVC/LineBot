using bingshopLibrary.Models;
using bingshopLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bingshopLibrary.Service
{
    public class service
    {
        BSModel model = new BSModel();

        public List<Categories> CategoriesGetAll()
        {
            var repository = new Repository<Categories>(model);

            return repository.GetAll().ToList();
        }

        public List<Customer> CustomerGetAll()
        {
            var repository = new Repository<Customer>(model);

            return repository.GetAll().ToList();
        }

        public List<Order> OrderGetAll()
        {
            var repository = new Repository<Order>(model);

            return repository.GetAll().ToList();
        }

        public List<Order_Details> Order_DetailsGetAll()
        {
            var repository = new Repository<Order_Details>(model);

            return repository.GetAll().ToList();
        }

        public List<Product_Photo> Product_PhotoGetAll()
        {
            var repository = new Repository<Product_Photo>(model);

            return repository.GetAll().ToList();
        }

        public List<Products> ProductsGetAll()
        {
            var repository = new Repository<Products>(model);

            return repository.GetAll().ToList();
        }

        public List<Shoppingcart_Details> Shoppingcart_DetailsGetAll()
        {
            var repository = new Repository<Shoppingcart_Details>(model);

            return repository.GetAll().ToList();
        }

        public List<sysdiagrams> sysdiagramsGetAll()
        {
            var repository = new Repository<sysdiagrams>(model);

            return repository.GetAll().ToList();
        }
    }
}
