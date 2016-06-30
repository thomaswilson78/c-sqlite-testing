using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace sqlite_testing
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection.CreateFile("test.sqlite");
            
            SQLiteConnection test = new SQLiteConnection("Data Source=test.sqlite;Version=3;");
            test.Open();

            SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE test (id int(11));", test);
            
            cmd.ExecuteNonQuery();
            cmd = new SQLiteCommand("INSERT INTO test VALUES (1);",test);
            cmd.ExecuteNonQuery();
            cmd = new SQLiteCommand("INSERT INTO test VALUES (2);", test);
            cmd.ExecuteNonQuery();
            cmd = new SQLiteCommand("SELECT * FROM test;",test);
            SQLiteDataReader read = cmd.ExecuteReader();
            while(read.Read())
            {
                Console.WriteLine(read["id"]);
            }
            Console.ReadKey();
        }
    }
}
