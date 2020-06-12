using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas
{
    abstract class Decorator :Film
    {
        public Film film;
        public Decorator(string name, string country, string pib, Film film) : base(name, country, pib)
        {
            this.film = film;
        }
    }
}
