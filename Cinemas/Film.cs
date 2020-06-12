using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas
{
    class Film
    {
        public string FilmName { get; set; }
        public string CountryName { get; set; }
        public string PIB { get; set; }

        public Film(string name, string country, string pib)
        {
            FilmName = name;
            PIB = pib;
            CountryName = country;
        }

        public Film()
        {

        }
    }
}
