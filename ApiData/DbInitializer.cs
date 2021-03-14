using System;
using System.Collections.Generic;
using System.Text;
using ApiModels.Event;
namespace ApiData
{
    public static class DbInitializer 
    {
        public static void Initialize(EventContext context)
        {
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var eventList = new List<Event>
            //{
            //    new Event{Name="asdasd", Date=DateTime.Now,Price= 10m }
            //};

            //eventList.ForEach(e => context.Event.Add(e));




            //context.SaveChanges();
        }

    }
}