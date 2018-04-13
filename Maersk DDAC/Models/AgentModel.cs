using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Maersk_DDAC.Models
{

    public class Customer
    {
        public int CustomerID { get; set; }
        
        [DisplayName("Customer Name")]
        public String CustomerName { get; set; }

        public String AssociatedComapany { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
    public class Good
    {
        public int GoodID { get; set; }

        [DisplayName("Goods Name")]
        public String GoodName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }

    public class Order
    {
        public int OrderID { get; set; }

        public DateTime TimeBooked { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public int GoodID { get; set; }
        public virtual Good Good { get; set; }

        public int ScheduleID { get; set; }
        public virtual Schedule Schedule { get; set; }

    
    }
}