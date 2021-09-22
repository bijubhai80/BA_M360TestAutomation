using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Configuration;

namespace M360TestAutomation.ExcelReader
{
    public class SQLReader
    {
        
        string ConString = string.Format("Data Source={0}; User Id={1}; Password={2}", ConfigurationManager.AppSettings.Get("env"), ConfigurationManager.AppSettings.Get("user"), ConfigurationManager.AppSettings.Get("SQLPassword"));

        public List<string> ReadDatabase(string query)
        {
            try
            {
                using (var connection = new OracleConnection(ConString))
                {
                    connection.Open();
                    // Creating the command object
                    OracleCommand cmd = new OracleCommand(query, connection);
                    // Opening Connection                      
                    // Executing the SQL query  
                    OracleDataReader reader = cmd.ExecuteReader();
                    //Looping through each record
                    string result = "";
                    List<string> results = new List<string>();
                    var fieldCount = reader.FieldCount;
                    while (reader.Read())
                    {
                        for (var i = 0; i < fieldCount; i++)
                        {
                            result += !reader.IsDBNull(i) ? reader[i].ToString() + "," : ",";                                                            
                        }
                        results.Add(result+";");
                    }
                    connection.Close();
                    return results;
                }
            }
            catch(Exception e)
            {
                Log.Log.Message("DB read failed with exception: " +  e);
                return null;
            }
        }
    }
}
