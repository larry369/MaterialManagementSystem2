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
    class SupplierUtility
    {
        public static string cnStr = ConfigurationManager.ConnectionStrings["MMSconnectionstring1"].ConnectionString;
        /// <summary>
        /// 修改廠商資料
        /// </summary>
        /// <param name="sp"></param>
        public static void EditSupplier(Supplier sp)
        {
            SqlConnection cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand("Update Suppliers Set  CompanyName=@CompanyName, Address=@Address, Contact=@Contact, DirectTelephone=@DirectTelephone, Email=@Email Where SupplierID=@SupplierID", cn);
            cmd.Parameters.AddWithValue("@SupplierID", sp.SupplierID);
            cmd.Parameters.AddWithValue("@CompanyName", sp.CompanyName);
            cmd.Parameters.AddWithValue("@Address", sp.Address);
            cmd.Parameters.AddWithValue("@Contact", sp.Contact);
            cmd.Parameters.AddWithValue("@DirectTelephone", sp.DirectTelephone);
            cmd.Parameters.AddWithValue("@Email", sp.Email);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

        }
        public static void DeleteSupplier(int supid)
        {
            SqlConnection cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand("delete From Suppliers Where SupplierID=@SupplierID",cn);
            SqlCommand cmd2 = new SqlCommand("delete From SupplierElements Where SupplierID=@SupplierID",cn);
            cmd.Parameters.AddWithValue("@SupplierID", supid);
            cmd2.Parameters.AddWithValue("@SupplierID", supid);
            cn.Open();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            cn.Close();
        }
        /// <summary>
        /// 取得所有供應商名單
        /// </summary>
        /// <returns></returns>
        public static List<Supplier> GetAllSuppliers()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Suppliers",cnStr);
            DataTable dt = new DataTable();
            da.Fill(dt);
            var query = from row in dt.AsEnumerable()
                        select new Supplier() {
                            SupplierID = Convert.ToInt32(row["SupplierID"]),
                            CompanyName = row["CompanyName"].ToString(),
                        };


            return query.ToList();
        }
        /// <summary>
        /// 依公司id 新增供應料件
        /// </summary>
        /// <param name="supelmt"></param>
        public static void SupplierElementsnew(SupplierElements supelmt)
        {
            SqlConnection cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand("Insert Into SupplierElements(SupplierID, Product)Values(@SupplierID, @Product)", cn);
            cmd.Parameters.AddWithValue("@SupplierID", supelmt.SupplierID);
            cmd.Parameters.AddWithValue("@Product", supelmt.Product);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static void DeleteSupplierElement(int sid, string prod)
        {
            SqlConnection cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand("Delete From SupplierElements Where SupplierID=@SupplierID and Product=@Product", cn);
            cmd.Parameters.AddWithValue("@SupplierID", sid);
            cmd.Parameters.AddWithValue("@Product", prod);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
