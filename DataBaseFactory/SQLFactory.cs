using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.IO;
using Infrastructure;

namespace DataBaseFactory
{
    public class SQLFactory : IDataBaseFactory
    {
        public DbConnection GetConnection()
        {
            var configuation = GetConfigration();
            return new SqlConnection(configuation.GetSection("Data").GetSection("MyConnectionString").Value);

        }

        public IConfigurationRoot GetConfigration()
        {
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public DbCommand GetCommand()
        { return new SqlCommand(); }


        public DbDataAdapter GetAdapter()
        {
            return new SqlDataAdapter();
        }


        public DbDataAdapter GetAdapter(SqlCommand cmd)
        {

            return new SqlDataAdapter(cmd);

        }

        public DbTransaction GetTransaction(DbConnection con)
        {
            return con.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public DbParameter GetParameter(string parameter, object value)
        {
            return new SqlParameter(parameter, value);
        }
    }
}


