using ApiData.Infastructure;
using ApiModels.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiData.Repositories
{
    public interface ISessionRepository : IRepository<Session>
    {

    }
    public class SessionRepository : RepositoryBase<Session, EventContext>, ISessionRepository
    {
        public SessionRepository(IDbFactory<EventContext> dbFactory) : base(dbFactory)
        {
        }
    }
}
