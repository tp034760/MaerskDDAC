using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Maersk_DDAC.Models
{
    public class BookingsModel
    {

        public int CustomerID { get; set; }
        public int GoodID { get; set; }
        public IEnumerable<Schedule> Schedule { get; set; }
        public Schedule SelectedSchedule { get; set; }
        public Order Order { get; set; }
        public Good Good { get; set; }
        public Customer Customer { get; set; }

        public IEnumerable<SelectListItem> GoodsList { get; set; }
    }
}