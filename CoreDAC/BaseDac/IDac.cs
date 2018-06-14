using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CoreDAC.BaseDac
{
    public interface IDac
    {
        DataTable GetDataTable(string sqlStoredProcedure,SqlParameter[] sqlParamaterArray,bool isStoredProcedure);
        DataSet GetDataSet(string sqlStoredProcedure, SqlParameter[] sqlParamaterArray, bool isStoredProcedure);
        bool UpdateTable(string sqlStoredProcedure, SqlParameter[] sqlParamaterArray, bool isStoredProcedure);
    }
}
