using MySql.Data.MySqlClient;
using System.Data;

namespace _CA_inlämmning1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("Välj ett av följande alternativ mella  1-6");
                Console.WriteLine("\n1 Hur många olika länder finns representerade? " +
                    "\n2 Är alla username och password unika? " +
                    "\n3 Hur många är från Norden respektive Skandinavien? " +
                    "\n4 Vilket är det vanligaste landet? " +
                    "\n5 Lista de 10 första användarna vars efternamn börjar på bokstaven L" +
                    "\n6 Visa alla användare vars för - och efternamn har samma begynnelse bokstav\n\n\n");
                
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        {
                            Connect connect = new Connect();
                            var cnn = connect.Conn();
                            var sql = @"SELECT DISTINCT Country FROM CASQLAssignment1";
                            var cmd = new MySqlCommand(sql, cnn);
                            var adt = new MySqlDataAdapter(cmd);
                            var dt = new DataTable();
                            adt.Fill(dt);
                            Console.WriteLine("\n Det finns: " + dt.Rows.Count + " " + "olika länder");
                        }
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        {
                            Connect connect = new Connect();
                            var cnn = connect.Conn();
                            var sql = @"SELECT DISTINCT password FROM CASQLAssignment1";
                            var sql2 = @"SELECT DISTINCT username FROM CASQLAssignment1";
                            var cmd = new MySqlCommand(sql, cnn);
                            var cmd2 = new MySqlCommand(sql2, cnn);
                            var adt = new MySqlDataAdapter(cmd);
                            var adt2 = new MySqlDataAdapter(cmd2);
                            var dt = new DataTable();
                            var dt2 = new DataTable();  
                            adt.Fill(dt);
                            adt2.Fill(dt2);
                            if (dt.Rows.Count == dt2.Rows.Count)
                            {
                                Console.WriteLine("\nAlla username och password är unika");
                            }
                            else
                            {
                                Console.WriteLine("\nAlla username och password är inte unika");
                            }
                          
                        }
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        {
                            Connect connect = new Connect();
                            var cnn = connect.Conn();
                            var sql = @"SELECT Country FROM CASQLAssignment1 WHERE Country='Sweden'OR 'Norway' OR 'Finland' OR ' Denmark' OR 'Iceland' OR 'The Faroe Islands' OR 'Greenland'";
                            var cmd = new MySqlCommand(sql, cnn);
                            var adt = new MySqlDataAdapter(cmd);
                            var dt = new DataTable();
                            adt.Fill(dt);
                            Console.WriteLine(" \nThere are: " + dt.Rows.Count + " " + "differents Conutries");
                        }
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        {
                            Connect connect = new Connect();
                            var cnn = connect.Conn();
                            var sql = @"SELECT Country, COUNT(*) AS 'Count' FROM CASQLAssignment1 GROUP BY Country ORDER BY COUNT(*) DESC LIMIT 1";
                            var cmd = new MySqlCommand(sql, cnn);
                            var adt = new MySqlDataAdapter(cmd);
                            var dt = new DataTable();
                            adt.Fill(dt);
                            Console.WriteLine("");
                            foreach (DataRow row in dt.Rows)
                            {
                                Console.WriteLine(row["Country"]);
                            }
                        }
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        {
                            Connect connect = new Connect();
                            var cnn = connect.Conn();
                            var sql = @"SELECT last_name FROM CASQLAssignment1 WHERE last_name LIKE 'L%' LIMIT 10";
                            var cmd = new MySqlCommand(sql, cnn);
                            var adt = new MySqlDataAdapter(cmd);
                            var dt = new DataTable();
                            adt.Fill(dt);
                            Console.WriteLine("");
                            foreach (DataRow row in dt.Rows)
                            {
                                Console.WriteLine(row["last_name"]);
                            }
                            
                        }
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        {

                            Connect connect = new Connect();
                            var cnn = connect.Conn();
                            var sql = @"SELECT * FROM ERSQLAssignment1 WHERE LEFT(first_name, 1) = LEFT(last_name, 1) ORDER BY first_name ASC;";
                            var cmd = new MySqlCommand(sql, cnn);
                            var adt = new MySqlDataAdapter(cmd);
                            var dt = new DataTable();
                            adt.Fill(dt);
                            Console.WriteLine();
                            foreach (DataRow row in dt.Rows)
                            {
                                Console.WriteLine($"{row["first_name"]}    {row["last_name"]}");
                            }
                            
                        }
                        break;
                }

            }
        }
    }
}