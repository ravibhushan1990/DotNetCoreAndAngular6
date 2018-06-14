using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDAC.BaseUtility
{
    public class Dal : IDal
    {
        private readonly SqlConnection con;

        #region Constructor
        public Dal()
        {
            con = new SqlConnection("");
        }

        public Dal(SqlConnection connection)
        {
            con = connection;
        }

        public Dal(string sqlConnectionString)
        {
            con = new SqlConnection(sqlConnectionString);
        }
        #endregion

        public DataSet GetDataSet(string sqlStoredProcedure, SqlParameter[] sqlParamaterArray, bool isStoredProcedure)
        {
            DataSet dataSet = new DataSet();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataAdapter adp = new SqlDataAdapter())
            {
                cmd.CommandText = sqlStoredProcedure;
                SetCommandType(isStoredProcedure, cmd);
                cmd.Connection = con;
                if (sqlParamaterArray != null)
                {
                    cmd.Parameters.AddRange(sqlParamaterArray.ToArray());
                }

                adp.SelectCommand = cmd;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                adp.Fill(dataSet);
            }
            return dataSet;
        }

        private static void SetCommandType(bool isStoredProcedure, SqlCommand cmd)
        {
            if (isStoredProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                cmd.CommandType = CommandType.Text;
            }
        }

        public DataTable GetDataTable(string sqlStoredProcedure, SqlParameter[] sqlParamaterArray, bool isStoredProcedure)
        {
            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand();
            using (SqlDataAdapter adp = new SqlDataAdapter())
            {
                cmd.CommandText = sqlStoredProcedure;
                SetCommandType(isStoredProcedure, cmd);
                cmd.Connection = con;
                cmd.Parameters.AddRange(sqlParamaterArray.ToArray());
                adp.SelectCommand = cmd;
                adp.Fill(dataTable);
            }
            return dataTable;
        }

        public bool UpdateTable(string sqlStoredProcedure, SqlParameter[] sqlParamaterArray, bool isStoredProcedure)
        {
            throw new NotImplementedException();
        }

        //connected By Data reader
        private void ReadOrderData(string sqlQuery)
        {
            string queryString = sqlQuery;
            SqlCommand command = new SqlCommand(queryString, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            // Call Read before accessing data.
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
            }

            // Call Close when done reading.
            reader.Close();

        }

        #region Testing purpose
        public DataSet getDataFromDB()
        {
            DataSet ds = new DataSet();
            SqlConnection nwindConn = new SqlConnection("Data Source = RAVI; Initial Catalog = AdventureWorks2016CTP3; Integrated Security = True");
            SqlCommand selectCMD = new SqlCommand("select p.PersonID,p.FirstName,p.LastName,p.MiddleName,p.EmailPromotion  from [Person].[Person_json] p;", nwindConn);
            selectCMD.CommandTimeout = 30;
            SqlDataAdapter customerDA = new SqlDataAdapter();
            customerDA.SelectCommand = selectCMD;
            nwindConn.Open();
            selectCMD.ExecuteNonQuery();
            customerDA.Fill(ds);
            nwindConn.Close();
            return ds;
        }
        public void testConnected()
        {

            string connectionString = "Data Source = RAVI; Initial Catalog = AdventureWorks2016CTP3; Integrated Security = True";
            string queryString = "select * from [HumanResources].[Employee];";
            int paramValue = 5;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricePoint", paramValue);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                }
                Console.ReadLine();
            }
        }
        public void testDisconnected()
        {
            string connectionString = "Data Source = RAVI; Initial Catalog = AdventureWorks2016CTP3; Integrated Security = True";

            string queryString = "select p.PersonID,p.FirstName,p.LastName,p.MiddleName,p.EmailPromotion  from [Person].[Person_json] p;";
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connectionString);

            DataSet customers = new DataSet();
            adapter.Fill(customers, "Customers");
        }
        #endregion
    }
}

