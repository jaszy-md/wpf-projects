using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3.Classes
{
    class DBverkiezingenpartijen
    {
        MySqlConnection _connection = new MySqlConnection("Server=localhost;Database=verkiezingenprj3;Uid=root;Pwd=;");

        public DataTable SelectVpartijen()
        {
            DataTable result = new DataTable();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand();
                command.CommandText = "SELECT partij_verkiezing.partij_id, partij_verkiezing.verkiezingID, `naam`, `verkiezingsoort` FROM `partij_verkiezing` INNER JOIN partij ON partij_verkiezing.partij_id = partij.partij_id INNER JOIN verkiezingsoort ON partij_verkiezing.verkiezingID = verkiezingsoort.verkiezingsoort_id; ";
                MySqlDataReader reader = command.ExecuteReader();
                result.Load(reader);
            }
            catch (Exception)
            {
                //Problem with the database
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
    }
}
