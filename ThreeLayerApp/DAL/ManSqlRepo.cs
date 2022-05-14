using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ThreeLayerApp.Entities;

namespace ThreeLayerApp.DAL
{
    public class ManSqlRepo : IRepo<Man>
    {
        private SqlDataBase dataBase = new SqlDataBase();

        public Man Add(Man man) 
        {
            if (man.Name.Length > 50)
            {
                throw new ArgumentOutOfRangeException(nameof(man.Name), "Man's name must be less than 50 letters");
            }

            string queryString = "insert into men_db(first_name, age, weigth, height) " +
                $"values ('{man.Name}', '{man.Age}', '{man.Weigth}', '{man.Height}');";

            var command = new SqlCommand(queryString, dataBase.GetConnection());

            dataBase.OpenConnection();

            if (!(command.ExecuteNonQuery() == 1))
            {
                dataBase.CloseConnection();
                throw new InvalidOperationException("Man has not been added to the database");
            }

            dataBase.CloseConnection();

            return man;
        }

        public IEnumerable<Man> GetAll()
        {
            var adapter = new SqlDataAdapter();
            var resultQuery = new DataTable();

            string queryString = $"select [first_name] ,[age] ,[weigth] ,[height]";

            var command = new SqlCommand(queryString, dataBase.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(resultQuery);

            foreach (DataRow row in resultQuery.Rows)
            {
                yield return new Man((string)row["first_name"], (int)row["age"], (float)row["weigth"], (float)row["height"]);
            }
        }

        public bool TryDelete(int index)
        {
            throw new System.NotImplementedException();
        }

        public Man Update(int index, Man man)
        {
            throw new System.NotImplementedException();
        }
    }
}
