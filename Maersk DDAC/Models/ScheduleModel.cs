using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace Maersk_DDAC.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleID { get; set; }

        [DisplayName("Remaining Bays")]
        public int BayLeft { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DepartureTime { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime ArrivalTime { get; set; }

        [ForeignKey("Ship")]
        public int ShipID { get; set; }

        public virtual Ship Ship { get; set; }

        [DisplayName("Departure Location")]
        public virtual Dock Departure { get; set; }

        [DisplayName("Arrival Location")]
        public virtual Dock Arrival { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }

    public class Ship
    {
        [Key] 
        public int ShipID { get; set; }

        public String ShipName { get; set; }

        public int ShipBay { get; set; }

        public virtual ICollection<Schedule> ScheduleShip { get; set; }

        public IEnumerable<SelectListItem> Ships { get; set; }

    }

    public class Dock
    {
        [Key]
        public int DockID { get; set; }

        [DisplayName("Dock Name")]
        public String DockName { get; set; }

        public String DockLocation { get; set; }

        [InverseProperty("Departure")]
        public virtual ICollection<Schedule> DepartureDock { get; set; }

        [InverseProperty("Arrival")]
        public virtual ICollection<Schedule> ArrivalDock { get; set; }


        public IEnumerable<SelectListItem> Docks { get; set; }

    }




}