using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialManagementSystem
{
    class EmployeeUtility
    {
        public static string cnStr = ConfigurationManager.ConnectionStrings["MMSconnectionstring1"].ConnectionString;
        public static List<Employee> GetAllEmployees()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Employees", cnStr);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var query = from rows in dt.AsEnumerable()
                        select new Employee() {
                            EmployeeID = Convert.ToInt32(rows["EmployeeID"]),
                            Name = rows["Name"].ToString(),
                            Authority = rows["Authority"].ToString()

                        };

            return query.ToList();
        }
        /// <summary>
        /// For 管理者修改 看不到員工的密碼
        /// </summary>
        /// <param name="emp"></param>
        public static void EmployeeEdit(Employee emp)
        {
            SqlConnection cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand("Update Employees Set Name=@Name, Authority=@Authority Where EmployeeID=@EmployeeID",cn);
            cmd.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Authority", emp.Authority);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static void DeleteEmployee(int empid)
        {
            SqlConnection cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand("Delete From Employees Where EmployeeID=@EmployeeID", cn);
            cmd.Parameters.AddWithValue("@EmployeeID", empid);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static void EmployeeAdd(Employee emp)
        {
            SqlConnection cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand("Insert Into Employees(Name, Authority, Password) Values(@Name, @Authority, @Password)", cn);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Authority", emp.Authority);
            cmd.Parameters.AddWithValue("@Password", emp.Password);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static Employee FindEmployeeByIDandPassword(int empid, string emppassword)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Employees Where EmployeeID=@EmployeeID And Password=@Password",cnStr);
            da.SelectCommand.Parameters.AddWithValue("@EmployeeID", empid);
            da.SelectCommand.Parameters.AddWithValue("@Password", emppassword);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count==0)
            {
                return null;
            }
            DataRow row = dt.Rows[0];
            Employee emp = new Employee() {
                EmployeeID = Convert.ToInt32(row["EmployeeID"]),
                Name = row["Name"].ToString(),
                Authority = row["Authority"].ToString(),
                Password=row["Password"].ToString()
            };
            return emp;
        }
    }
    public static class LoginInfo
    {
        public static int EmpID;
        public static string Name;
        public static string Authority;
    }
}
