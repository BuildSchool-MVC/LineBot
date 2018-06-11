
using Dapper;
using ModelsLibrary.DtO_Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ModelsLibrary.Repositories
{
    public class OrderRepository<T> where T : class
    {        
        private string sqlstr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public IEnumerable<T> OrderGetAll()
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            return connection.Query<T>("SELECT * FROM [Order]");
        }

        public IEnumerable<T> OrderDetailsGetAll()
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            return connection.Query<T>("SELECT * FROM [OrderDetails]");
        }

        public IEnumerable<T> ProductsGetAll()
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            return connection.Query<T>("SELECT * FROM Products");
        }

        public IEnumerable<T> CustomerGetAll()
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            return connection.Query<T>("SELECT * FROM Customer");
        }

        public IEnumerable<T> CategoriesGetAll()
        {
            SqlConnection connection = new SqlConnection(sqlstr);
            return connection.Query<T>("SELECT * FROM Categories");
        }

    }
}

