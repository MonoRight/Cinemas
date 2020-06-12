using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Cinemas
{
    class ForDecorate
    {
        public void FilmsDecorate()
        {
            ConnectionBD connection = new ConnectionBD();
            connection.OpenDB();
            string sqlExpression = "SELECT Film.FilmName, Film.CountryName, Person.PIB FROM " +
                "Film INNER JOIN MultyFilm ON Film.Id=MultyFilm.FilmId " +
                "INNER JOIN Person ON MultyFilm.PersonId= Person.Id " +
                "WHERE MultyFilm.PersonRole= 'actor' " +
                "ORDER BY Film.FilmName";

            SqlCommand command = new SqlCommand(sqlExpression, connection.BDConnection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                int i = 0;
                string fimm = "";
                Film film = new Film();
                while (reader.Read())
                {
                    object filmname = reader.GetValue(0);
                    object countryname = reader.GetValue(1);
                    object pib = reader.GetValue(2);
                    if (i == 0)
                    {
                        fimm = filmname.ToString();
                        film = new Film(filmname.ToString(), countryname.ToString(), pib.ToString());
                    }
                    else if (fimm == filmname.ToString())
                    {
                        film = new DecoratorActors(film, " " + pib.ToString());
                    }
                    else
                    {
                        Console.WriteLine("FilmName: {0} country: {1} actors: {2}", film.FilmName, film.CountryName, film.PIB);
                        fimm = filmname.ToString();
                        film = new Film(filmname.ToString(), countryname.ToString(), pib.ToString());
                    }
                    i++;
                }
            }

            reader.Close();
            connection.Close();
        }
    }
}
