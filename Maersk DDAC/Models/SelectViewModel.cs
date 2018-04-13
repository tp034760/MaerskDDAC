using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maersk_DDAC.Models
{
    public class SelectViewModel
    {
        public int ShipID { get; set; }
        public int DepartureID { get; set; }
        public int ArrivalID { get; set; }
        public IEnumerable<SelectListItem> ShipList { get; set; }
        public IEnumerable<SelectListItem> DockList { get; set; }

        public Schedule Schedule { get; set; }


    }
}