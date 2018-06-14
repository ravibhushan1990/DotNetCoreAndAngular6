
using CoreDAC.BaseUtility;
using CoreDAC.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CoreDAC.EmployeeDal
{
    public class EmployeeDal
    {
        private Dal dal;

        public EmployeeDal()
        {
            dal = new Dal(new SqlConnection("Data Source=RAVI;Initial Catalog=AdventureWorks2016CTP3;Integrated Security=True"));
        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> listEmp = new List<Employee>();
            DataSet dataSet = new DataSet();
            dataSet = dal.GetDataSet("select p.PersonID,p.FirstName,p.LastName,p.MiddleName,p.EmailPromotion  from [Person].[Person_json] p;", null, false);
            EntityMapper<Employee> empMap = new EntityMapper<Employee>();
            listEmp = empMap.GetSafeResult(dataSet.Tables[0], EmployeeMapper);
            return listEmp;
        }

        public Employee EmployeeMapper(DataRow dr)
        {
            Employee emp = new Employee();
            emp.EmpId = Convert.ToInt32(dr["PersonID"]);
            emp.FirstName = Convert.ToString(dr["FirstName"]);
            emp.LastName = Convert.ToString(dr["LastName"]);
            emp.MiddleName = Convert.ToString(dr["MiddleName"]);
            emp.EmailPromotion = Convert.ToString(dr["EmailPromotion"]);
            return emp;

        }
    }
}
