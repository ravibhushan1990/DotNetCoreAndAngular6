using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDAC.BaseUtility
{
    public interface IDal
    {
        DataTable GetDataTable(string sqlStoredProcedure, SqlParameter[] sqlParamaterArray, bool isStoredProcedure);
        DataSet GetDataSet(string sqlStoredProcedure, SqlParameter[] sqlParamaterArray, bool isStoredProcedure);
        bool UpdateTable(string sqlStoredProcedure, SqlParameter[] sqlParamaterArray, bool isStoredProcedure);
    }
}
