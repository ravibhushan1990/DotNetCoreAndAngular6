using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDAC.BaseUtility
{
    public interface IEntityMapper<T>
    {
        List<T> GetSafeResult(DataTable dataTable, Func<DataRow, T> entityResult);
    }
}
