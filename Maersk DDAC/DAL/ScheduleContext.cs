using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Maersk_DDAC.Models;

namespace Maersk_DDAC.DAL
{
    public class ScheduleContext: DbContext
    {
        public ScheduleContext() : base("ScheduleContext")
        {

        }

        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Dock> Docks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<ScheduleContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}