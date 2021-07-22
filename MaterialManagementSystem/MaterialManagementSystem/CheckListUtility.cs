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
    class CheckListUtility
    {
        public static string cnStr = ConfigurationManager.ConnectionStrings["MMSconnectionstring1"].ConnectionString;
        public static int SentNewCheckIDBack()
        {
            int ckid;
            ckid = 0;
            SqlConnection cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand("Select CheckID From CheckList",cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ckid = Convert.ToInt32(dr[0]);
            }
            return ckid+1;

        }

        public static List<SupplierElements> GetProductBycomboID(int supid)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select SupplierID, Product From SupplierElements Where SupplierID=@SupplierID",cnStr);
            da.SelectCommand.Parameters.AddWithValue("@SupplierID", supid);
            DataTable dt = new DataTable();
            da.Fill(dt);

            var query = from row in dt.AsEnumerable()
                        select new SupplierElements() {
                            SupplierID=Convert.ToInt32(row["SupplierID"]),
                            Product = row["Product"].ToString(),
                        };

            return query.ToList();
        }
        public static void CheckListAdd(CheckList chklist)
        {
            SqlConnection cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand("Insert Into CheckList( MS_ID, Component, Supplier, Config, Description, Picture, Qty, CheckResult, EmployeeName, SentCheckTime, Price)Values( @MS_ID, @Component, @Supplier, @Config, @Description, @Picture, @Qty, @CheckResult, @EmployeeName, @SentCheckTime, @Price)", cn);
            cmd.Parameters.AddWithValue("@MS_ID", chklist.MS_ID);
            cmd.Parameters.AddWithValue("@Component", chklist.Component);
            cmd.Parameters.AddWithValue("@Supplier", chklist.Supplier);
            cmd.Parameters.AddWithValue("@Config", chklist.Config);
            cmd.Parameters.AddWithValue("@Description", chklist.Description);
            cmd.Parameters.AddWithValue("@Picture", chklist.Picture);
            cmd.Parameters.AddWithValue("@Qty", chklist.Qty);
            cmd.Parameters.AddWithValue("@CheckResult", chklist.CheckResult);
            cmd.Parameters.AddWithValue("@EmployeeName", chklist.EmployeeName);
            cmd.Parameters.AddWithValue("@SentCheckTime", chklist.SentCheckTime);
            cmd.Parameters.AddWithValue("@Price", chklist.Price);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static List<CheckList> GetAllCheckList()
        {
            string cnStr = ConfigurationManager.ConnectionStrings["MMSconnectionstring1"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter("Select * From CheckList ", cnStr);

            DataTable dt = new DataTable();
            da.Fill(dt);
            var query = from row in dt.AsEnumerable()
                        select new CheckList()
                        {
                            CheckID=Convert.ToInt32(row["CheckID"]),
                            EmployeeName=row["EmployeeName"].ToString(),
                            Component = row["Component"].ToString(),
                            Supplier = row["Supplier"].ToString(),
                            CheckResult=row["CheckResult"].ToString(),
                            Qty = Convert.ToInt32(row["Qty"]),
                            SentCheckTime=Convert.ToDateTime(row["SentCheckTime"]),
                            Price=Convert.ToInt32(row["Price"])
                        };

            return query.ToList();
        }
        public static void EditCheckList(CheckList chklist)
        {
            SqlConnection cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand("Update CheckList Set MS_ID=@MS_ID, Component=@Component, Supplier=@Supplier, Config=@Config, Description=@Description, Picture=@Picture, Qty=@Qty, CheckResult=@CheckResult, EmployeeName=@EmployeeName, Price=@Price Where MS_ID=@MS_ID", cn);
            cmd.Parameters.AddWithValue("@MS_ID", chklist.MS_ID);
            cmd.Parameters.AddWithValue("@Component", chklist.Component);
            cmd.Parameters.AddWithValue("@Supplier", chklist.Supplier);
            cmd.Parameters.AddWithValue("@Config", chklist.Config);
            cmd.Parameters.AddWithValue("@Description", chklist.Description);
            cmd.Parameters.AddWithValue("@Picture", chklist.Picture);
            cmd.Parameters.AddWithValue("@Qty", chklist.Qty);
            cmd.Parameters.AddWithValue("@CheckResult", chklist.CheckResult);
            cmd.Parameters.AddWithValue("@EmployeeName", chklist.EmployeeName);
            cmd.Parameters.AddWithValue("@Price", chklist.Price);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static void CheckListUpdateElements(Element elmt)
        {
            SqlConnection cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand("Update Elements Set Component=@Component, Supplier=@Supplier, Config=@Config, Description=@Description, Picture=@Picture, Qty=@Qty, Lasteditdate=@Lasteditdate Where MS_ID=@MS_ID", cn);
            cmd.Parameters.AddWithValue("@MS_ID", elmt.MS_ID);
            cmd.Parameters.AddWithValue("@Component", elmt.Component);
            cmd.Parameters.AddWithValue("@Supplier", elmt.Supplier);
            cmd.Parameters.AddWithValue("@Config", elmt.Config);
            cmd.Parameters.AddWithValue("@Description", elmt.Description);
            cmd.Parameters.AddWithValue("@Picture", elmt.Picture);
            cmd.Parameters.AddWithValue("@Qty", elmt.Qty);
            cmd.Parameters.AddWithValue("@Lasteditdate", elmt.Lasteditdate);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static void CheckListInsertElements(Element elmt)
        {
            SqlConnection cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand("Insert Into Elements(Component, Supplier, Config, Description, Picture, Qty, Purchase_date, Lasteditdate)Values(@Component, @Supplier, @Config, @Description, @Picture, @Qty, @Purchase_date, @Lasteditdate)", cn);
            cmd.Parameters.AddWithValue("@Component", elmt.Component);
            cmd.Parameters.AddWithValue("@Supplier", elmt.Supplier);
            cmd.Parameters.AddWithValue("@Config", elmt.Config);
            cmd.Parameters.AddWithValue("@Description", elmt.Description);
            cmd.Parameters.AddWithValue("@Picture", elmt.Picture);
            cmd.Parameters.AddWithValue("@Qty", elmt.Qty);
            cmd.Parameters.AddWithValue("@Purchase_date", elmt.Purchase_date);
            cmd.Parameters.AddWithValue("@Lasteditdate", elmt.Lasteditdate);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static void DeleteCheckList(int ckid)
        {
            SqlConnection cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand("Delete From CheckList Where CheckID=@CheckID", cn);
            cmd.Parameters.AddWithValue("@CheckID", ckid);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
