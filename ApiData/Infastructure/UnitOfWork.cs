using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiData.Infastructure
{
    public class UnitOfWork<T> : IUnitOfWork where T : DbContext
    {
        private readonly IDbFactory<T> dbFactory;
        private T dbContext;

        public UnitOfWork(IDbFactory<T> dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        
        public T DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public int Commit()
        {
            return DbContext.SaveChanges();
        }
    }
}
