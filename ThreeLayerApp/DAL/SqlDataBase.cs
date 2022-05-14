using System.Data.SqlClient;

namespace ThreeLayerApp.DAL
{
    public class SqlDataBase
    {
        private SqlConnection sqlConnection = new SqlConnection(
            @"Data Source=DESKTOP-6NGP1C2;" +
            "Initial Catalog=three_layer_app;" +
            "Integrated Security=True");

        public void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetConnection() => sqlConnection;
    }
}
