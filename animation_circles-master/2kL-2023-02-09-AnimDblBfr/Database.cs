using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2kL_2023_02_09_AnimDblBfr
{
    public class Database
    {
        private NpgsqlConnection? conn = null;
        public Rect? r;
        public Database(

            string Host,
            string user,
            string password,
            string database,
            //int Port
            bool clean_table
            )
        {
            var connString = $"Host={Host};Username=postgres;Password=ПАРОЛЬ;Database=db_circles";
            conn = new NpgsqlConnection(connString);
            conn.Open();
            if ( clean_table )
            table_clean();


        }
        public void table_clean()
        {
            using (var cmd = new NpgsqlCommand("DELETE FROM rectangle_score", conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public void add_rect(int id)
        {
            using (var cmd = new NpgsqlCommand($"INSERT INTO rectangle_score (rectangle_id) VALUES ({id})", conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        public void update_score(int id)
        {
            using (var cmd = new NpgsqlCommand($"Update  rectangle_score SET score = score + 1 WHERE rectangle_id = ({id})", conn))
            {
                cmd.ExecuteNonQuery();
            }
        }


    }
}
