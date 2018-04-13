using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Maersk_DDAC.Models
{
    public class DockModel
    {
            public int DockID { get; set; }

            public String DockName { get; set; }

            public String DockLocation { get; set; }
        
    }
}