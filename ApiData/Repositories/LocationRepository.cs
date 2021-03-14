using ApiData.Infastructure;
using ApiModels.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiData.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {

    }
    public class LocationRepository : RepositoryBase<Location, EventContext>, ILocationRepository
    {
        public LocationRepository(IDbFactory<EventContext> dbFactory) : base(dbFactory)
        {
        }
    }
}
