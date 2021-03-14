using System;
using System.Collections.Generic;
using System.Text;

namespace ApiData.Infastructure
{
    public class DbFactory : Disposable, IDbFactory<EventContext>
    {
        private EventContext dbContext;

        public EventContext Init()
        {
            return dbContext ?? (dbContext = new EventContext());
        }
        protected override void DisposeCore()
        {
            if(dbContext!= null)
            {
                dbContext.Dispose();
            }
        }
    }
}
