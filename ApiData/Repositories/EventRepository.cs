using ApiData.Infastructure;
using ApiModels.Event;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiData.Repositories
{
    public interface IEventRepository : IRepository<Event>
    {

    }
    public class EventRepository : RepositoryBase<Event, EventContext>, IEventRepository
    {
        public EventRepository(IDbFactory<EventContext> dbFactory) : base(dbFactory)
        {
        }
        public override IEnumerable<Event> GetAll()
        {
            return DbContext.Event.Include(t => t.Location).Include(t => t.Sessions);
        }
        public override Event GetById(int id)
        {
            return DbContext.Event.Include(t => t.Location).Include(t => t.Sessions).FirstOrDefault(e => e.EventID == id);
        }
    }
}
