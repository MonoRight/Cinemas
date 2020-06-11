using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Cinemas
{
    class ShowTables
    { 
        public void Show()
        {
            ConnectionBD connection = new ConnectionBD();
            string sqlExpression;
            using (connection.BDConnection)
            {
                connection.OpenDB();
                sqlExpression = "SELECT * FROM Film";
                SqlCommand command = new SqlCommand(sqlExpression, connection.BDConnection);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("\t\t\t\tFilms\n");

                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    Console.WriteLine("{0}\t{1}\t\t\t\t\t{2}\t\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));

                    while (reader.Read()) // построчно считываем данные
                    {
                        object id = reader.GetValue(0);
                        object filmname = reader.GetValue(1);
                        object filmdate = reader.GetValue(2);
                        object countryname = reader.GetValue(3);

                        Console.WriteLine("{0}\t{1}\t{2}\t{3}", id, filmname, filmdate, countryname);
                    }
                }

                reader.Close();

                Console.WriteLine("\t\t\t\tPerson\n");
                sqlExpression = "SELECT * FROM Person";
                command = new SqlCommand(sqlExpression, connection.BDConnection);
                reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    Console.WriteLine("{0}\t{1}\t\t\t\t\t\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                    while (reader.Read()) // построчно считываем данные
                    {
                        object id = reader.GetValue(0);
                        object PIB = reader.GetValue(1);
                        object birthdate = reader.GetValue(2);

                        Console.WriteLine("{0}\t{1}\t{2}", id, PIB, birthdate);
                    }
                }

                reader.Close();

                Console.WriteLine("\t\t\t\tScedule\n");
                sqlExpression = "SELECT * FROM Schedule";
                command = new SqlCommand(sqlExpression, connection.BDConnection);
                reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                    while (reader.Read()) // построчно считываем данные
                    {
                        object id = reader.GetValue(0);
                        object FilmId = reader.GetValue(1);
                        object PlayTime = reader.GetValue(2);

                        Console.WriteLine("{0}\t{1}\t{2}", id, FilmId, PlayTime);
                    }
                }

                reader.Close();

                Console.WriteLine("\t\t\t\tMultyFilm\n");
                sqlExpression = "SELECT * FROM MultyFilm";
                command = new SqlCommand(sqlExpression, connection.BDConnection);
                reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    Console.WriteLine("{0}\t{1}\t\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));

                    while (reader.Read()) // построчно считываем данные
                    {
                        object id = reader.GetValue(0);
                        object FilmId = reader.GetValue(1);
                        object PersonId = reader.GetValue(2);
                        object PersonRole = reader.GetValue(3);

                        Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}", id, FilmId, PersonId, PersonRole);
                    }
                }

                reader.Close();


                connection.Close();
            }
        }

        public void Delete()
        {
            ConnectionBD connect = new ConnectionBD();
            SqlCommand command = new SqlCommand("DELETE FROM Film WHERE Id = @id", connect.OpenDB());
            Console.WriteLine("Choose id to delete film: ");
            string id = Console.ReadLine();
            command.Parameters.Add(new SqlParameter("@id", id));
            int number = command.ExecuteNonQuery();
            Console.WriteLine("Films deleted: {0}", number);
            connect.Close();
        }

        public void Update()
        {
            ConnectionBD connect = new ConnectionBD();
            SqlCommand command = new SqlCommand("UPDATE Film SET FilmName=@FilmName WHERE id=@id", connect.OpenDB());
            Console.WriteLine("Choose id to update film: ");
            string id = Console.ReadLine();
            Console.WriteLine("Choose new name for film: ");
            string filmname = Console.ReadLine();
            command.Parameters.Add(new SqlParameter("@id", id));
            command.Parameters.Add(new SqlParameter("@FilmName", filmname));
            int number = command.ExecuteNonQuery();
            Console.WriteLine("Films updated: {0}", number);
            connect.Close();
        }
    }
}
