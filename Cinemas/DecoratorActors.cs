using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemas
{
    class DecoratorActors : Decorator
    {
        public DecoratorActors(Film film, string actor) : base(film.FilmName, film.CountryName, film.PIB + " " + actor, film)
        {
        }
    }
}
