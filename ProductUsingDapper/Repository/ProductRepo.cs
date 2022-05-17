using ProductUsingDapper.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace ProductUsingDapper.Repository
{
    public class ProductRepo : IProductRepo
    {
        private string connectionString;
        public ProductRepo()
        {
            connectionString = @"Data Source=.;Initial Catalog=ProductDB;Integrated Security=True";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    
         public void Add(ProductModel product)
        {
            using (IDbConnection  dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Products (ProductName,Quantity,Price) VALUES(@ProductName,@Quantity,@Price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, product);
            }
        }

        public IEnumerable<ProductModel> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * From Products";
                dbConnection.Open();
                return dbConnection.Query<ProductModel>(sQuery);
            }
        }
        public ProductModel GetById( int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * From Products Where Id=@Id";
                dbConnection.Open();
                return dbConnection.Query<ProductModel>(sQuery , new { Id=id}).FirstOrDefault();
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM Products Where Id=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id =id});
            }
        }
        public void Update(ProductModel product)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Products SET ProductName=@ProductName,Quantity=@Quantity,Price=@Price Where Id=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery,product);
            }
        }
    }
}
