using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cezium.SmartHome.OpenHabDb.Models.OpenHabItemsDbClient
{
    public class OpenHabDbItem
    {
        private readonly string _name;
        private readonly int _id;
        private readonly string _connectionString;

        public string Name { get { return _name; } }
        public int Id { get { return _id; } }

        private List<OpenHabDbItemValue> readValues(string query)
        {
            List<OpenHabDbItemValue> result = new List<OpenHabDbItemValue>();

            DataSet itemsDataSet = new DataSet();
            MySqlConnection conn = new MySqlConnection(_connectionString);

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
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
                        result.Add(new OpenHabDbItemValue()
                        {
                            DateTime = DateTime.Parse(row[0].ToString()),
                            Value = row[1].ToString()
                        });
                    }
                }
            }
            catch (MySqlException ex)
            {
                try
                {
                    conn.Close();
                }
                catch { }

                throw ex;
            }

            return result;
        }

        public OpenHabDbItem(int id, string name, string connectionString)
        {
            if (String.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("необходимо указать ConnectionString");

            _id = id;
            _name = name;
            _connectionString = connectionString;
        }

        public List<OpenHabDbItemValue> GetValues()
        {
            return readValues("SELECT * FROM item" + _id.ToString() + " ORDER BY Time DESC");
        }


        public List<OpenHabDbItemValue> GetValues(int count)
        {
            return readValues("SELECT * FROM item" + _id.ToString() + " ORDER BY Time DESC LIMIT " + count.ToString());
        }

        public List<OpenHabDbItemValue> GetValues(TimeSpan periodFromNow)
        {
            DateTime stopDate = DateTime.Now;
            DateTime startDate = stopDate - periodFromNow;

            return GetValues(startDate, stopDate);
        }

        public List<OpenHabDbItemValue> GetValues(DateTime startDate, DateTime stopDate)
        {
            string query = String.Format(
                @"SELECT * FROM item{0} WHERE Time >= '{1} 00:00:00' AND Time <= '{2} 23:59:59' ORDER BY Time DESC",
                _id.ToString(),
                startDate.ToString("yyyy-MM-dd"),
                stopDate.ToString("yyyy-MM-dd")
            );

            return readValues(query);
        }
    }
}