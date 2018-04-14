using MyFX.Repository.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MyFX.Repository.Test.DAL
{
    public class OMSUnitOfWork : EFUnitOfWork
    {
        public override DbContext Context
        {
           // get { return EFDbContextFactory.GetDbContext(); }
             get { return EFDbContextFactory.GetSqlServerDbContext(); }
            set { throw new NotSupportedException(); }
        }
    }
}
