using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pusula.Models
{
    public class PagerFilteredCountry
    {
        public int TotalPage { get; set; }
        public NumberedFilteredCountry[] NumberedFilteredCountry { get; set; }
    }
}