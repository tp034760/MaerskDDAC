using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Maersk_DDAC.Models
{
    public class ShipModel
    {
            public int ShipID { get; set; }
            public String ShipName { get; set; }
            public int ShipBay { get; set; }

    }
}