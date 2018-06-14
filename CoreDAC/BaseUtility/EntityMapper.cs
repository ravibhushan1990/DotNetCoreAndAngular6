using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDAC.BaseUtility
{
    public class EntityMapper<T> : IEntityMapper<T>
    {
        public List<T> GetSafeResult(DataTable dataTable, Func<DataRow, T> EntityResult)
        {
            List<T> lst = new List<T>();
            T resultEntity;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                resultEntity = EntityResult(dataRow);
                lst.Add(resultEntity);
            }
            return lst;
        }
    }
}
