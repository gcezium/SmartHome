using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cezium.SmartHome.OpenHabDb.Models.OpenHabItemsDbClient
{
    public class OpenHabItemsDbClient
    {
        private string _connectionString = "";
        private List<OpenHabDbItem> _items = new List<OpenHabDbItem>();

        public List<OpenHabDbItem> Items { get { return _items; } }

        public OpenHabItemsDbClient()
        {
        }


        public void Connect(string connectionString)
        {
            if (String.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("необходимо указать ConnectionString");

            _connectionString = connectionString;

            try
            {
                DataSet itemsDataSet = new DataSet();

                MySqlConnection conn = new MySqlConnection(_connectionString);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM ITEMS", conn);
                cmd.CommandType = System.Data.CommandType.Text;

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(itemsDataSet);

                conn.Close();

                if (itemsDataSet.Tables.Count > 0 && itemsDataSet.Tables[0].Rows.Count > 0)
                {
                    var table = itemsDataSet.Tables[0];
                    int columnsCount = table.Columns.Count;

                    foreach (DataRow row in table.Rows)
                    {
                        _items.Add(new OpenHabDbItem(Convert.ToInt32(row[0].ToString()), row[1].ToString(), _connectionString));
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

        }
    }
}
