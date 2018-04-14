using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyFX.Repository.Ef;
using MyFX.Repository.Test.Domain;

namespace MyFX.Repository.Test.DAL
{
    public class SqlServerDbContext : DbContextBase
    {
        /// <summary>
        /// SqlServerDbContext
        /// </summary>
        public SqlServerDbContext(string name)
            : base(name)
        {

        }

        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<DatabaseGeneratedAttributeConvention>();

            modelBuilder.Entity<Order>().ToTable("ORDERS");
            //自增列需要在数据库建序列+触发器配合生成
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Order>().Property(o => o.Id).HasColumnName("ORDERID");
            modelBuilder.Entity<Order>().Property(o => o.OrderNo).HasColumnName("ORDERNO");
            modelBuilder.Entity<Order>().Property(o => o.StoreId).HasColumnName("STOREID");
            modelBuilder.Entity<Order>().Property(o => o.StoreOwnerId).HasColumnName("STOREOWNERID");
            modelBuilder.Entity<Order>().Property(o => o.CustomerId).HasColumnName("CUSTOMERID");
            modelBuilder.Entity<Order>().Property(o => o.OrderType).HasColumnName("ORDERTYPE");
            modelBuilder.Entity<Order>().Property(o => o.OrderStatus).HasColumnName("ORDERSTATUS");
            modelBuilder.Entity<Order>().Ignore(o => o.Version);
        }
    }
}
