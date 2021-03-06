namespace Mass.Service.Db.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataAccess : DbContext
    {
        // Your context has been configured to use a 'DataAccess' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Mass.Service.Db.DataAccess.DataAccess' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DataAccess' 
        // connection string in the application configuration file.
        public DataAccess()
            : base("name=DataAccess")
        {
        }

        public DataAccess(string sqlConnectionString)
            : base(sqlConnectionString)
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            if (type == null)
                throw new Exception("Do not remove, ensures static reference to System.Data.Entity.SqlServer");
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}