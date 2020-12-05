using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pusula.Models
{
    //https://restcountries.eu/rest/v2/all?fields=name;altSpellings
    public class FilteredCountry
    {
        public Language[] languages { get; set; }
        public string name { get; set; }
    }

    public class Language
    {
        public string iso639_1 { get; set; }
        public string iso639_2 { get; set; }
        public string name { get; set; }
        public string nativeName { get; set; }
    }


}