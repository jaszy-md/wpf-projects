using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3.Classes
{
    class DBpartijstandpunt
    {
        MySqlConnection _connection = new MySqlConnection("Server=localhost;Database=verkiezingenprj3;Uid=root;Pwd=;");

        public DataTable Partijstandpunt()
        {
            DataTable result = new DataTable();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand(); //SELECT partij_standpunt.partij_id, `naam`, partij_standpunt.standpunt_id, `standpunt`,partij_standpunt.mening FROM `partij_standpunt` INNER JOIN partij ON partij_standpunt.partij_id = partij.partij_id INNER JOIN standpunt ON partij_standpunt.standpunt_id = standpunt.standpunt_id;
                command.CommandText = "SELECT partij_standpunt.partij_id, `naam`, partij_standpunt.standpunt_id, `standpunt`,partij_standpunt.mening FROM `partij_standpunt` INNER JOIN partij ON partij_standpunt.partij_id = partij.partij_id INNER JOIN standpunt ON partij_standpunt.standpunt_id = standpunt.standpunt_id; ";
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
