using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InterFood.Models
{
    public abstract class ModelBase : IDisposable
    {
        protected SqlConnection connection = null;

        public ModelBase()
        {
            string strConn = @"Data Source=.\sqlexpress;
                               Initial Catalog=FoodTruck;
                               Integrated Security=true";
            //User Id = sa; Password=dba
            connection = new SqlConnection(strConn);
            connection.Open();
        }
        public void Dispose()
        {
            connection.Close();
        }
    }
}