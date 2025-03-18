﻿using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Project_3.Classes;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3
{
    class DBpartijen
    {
        MySqlConnection _connection = new MySqlConnection("Server=localhost;Database=verkiezingenprj3;Uid=root;Pwd=;");

        public DataTable SelectPartijen()
        {
            DataTable result = new DataTable();
            try
            {
                _connection.Open();
                MySqlCommand command = _connection.CreateCommand(); // "SELECT * FROM partij;";
                command.CommandText = "SELECT * FROM partij;";
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


