using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maersk_DDAC.Models;

namespace Maersk_DDAC.DAL
{
    public class ScheduleInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ScheduleContext>
    {
        protected override void Seed(ScheduleContext context)
        {
            var ships = new List<Ship>
            {
            new Ship{ShipID=1,ShipName="Titanic",ShipBay=100},
            
            };

            ships.ForEach(s => context.Ships.Add(s));
            context.SaveChanges();

            var docks = new List<Dock>
            {
            new Dock{DockID=1,DockLocation="Malaysia",DockName="Port Klang"},
            };
            docks.ForEach(s => context.Docks.Add(s));
            context.SaveChanges();

            var schedules = new List<Schedule>
            {

            };
            schedules.ForEach(s => context.Schedules.Add(s));
            context.SaveChanges();
        }
    }
}