using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maersk_DDAC.Models
{
    public class FilterModel
    {
        public int CustomerID { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}