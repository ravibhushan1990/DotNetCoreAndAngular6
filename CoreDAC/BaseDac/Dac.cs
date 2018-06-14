using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CoreDAC.BaseDac
{
    public class Dac : IDac
    {
        private readonly SqlConnection con;
        public Dac()
        {
            con = new SqlConnection("");
        }
        public Dac(SqlConnection connection)
        {
            con = connection;
        }
        public Dac(string sqlConnectionString)
        {
            con = new SqlConnection(sqlConnectionString);
        }

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

        public DataSet getDataFromDB()
        {
            SqlConnection nwindConn = new SqlConnection("Data Source = RAVI; Initial Catalog = AdventureWorks2016CTP3; Integrated Security = True");
            SqlCommand selectCMD = new SqlCommand("select p.PersonID,p.FirstName,p.LastName,p.MiddleName,p.EmailPromotion  from [Person].[Person_json] p;", nwindConn);
            selectCMD.CommandTimeout = 30;
            SqlDataAdapter customerDA = new SqlDataAdapter();
            customerDA.SelectCommand = selectCMD;
            nwindConn.Open();
            DataSet ds = new DataSet();
            customerDA.Fill(ds, "Customers");
            nwindConn.Close();
            return ds;
        }
    }
}
