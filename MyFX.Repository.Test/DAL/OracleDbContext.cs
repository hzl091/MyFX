/****************************************************************************************
 * 文件名：TestDbContext
 * 作者：黄泽林
 * 创始时间：2018/1/17 10:20:49
 * 创建说明：
****************************************************************************************/

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MyFX.Repository.Test.Domain;

namespace MyFX.Repository.Test.DAL
{
    public class OracleDbContext : DbContext
    {
        /// <summary>
        /// OracleDbContext
        /// </summary>
        public OracleDbContext()
            : base("OracleDbContext")
        {
            
        }

        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ITEM");
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
