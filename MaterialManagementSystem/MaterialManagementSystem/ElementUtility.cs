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
    class ElementUtility
    {
        public static string cnStr = ConfigurationManager.ConnectionStrings["MMSconnectionstring1"].ConnectionString;
        public static void EditElement(Element elmt)
        {
            string cnStr = ConfigurationManager.ConnectionStrings["MMSconnectionstring1"].ConnectionString;
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
        public static List<Element> GetAllElement()
        {
            string cnStr = ConfigurationManager.ConnectionStrings["MMSconnectionstring1"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter("Select * From Elements ",cnStr);

            DataTable dt = new DataTable();
            da.Fill(dt);
            var query = from row in dt.AsEnumerable()
                        select new Element() {
                            MS_ID = Convert.ToInt32(row["MS_ID"]),
                            Component = row["Component"].ToString(),
                            Config = row["Config"].ToString(),
                            Supplier=row["Supplier"].ToString(),
                            Qty=Convert.ToInt32(row["Qty"]),
                            Lasteditdate=Convert.ToDateTime(row["Lasteditdate"])
                        };

            return query.ToList();
        }
        public static void DeleteElementByID(int msid)
        {
            SqlConnection cn = new SqlConnection(cnStr);
            SqlCommand cmd = new SqlCommand("Delete From Elements Where MS_ID=@MS_ID ",cn);
            cmd.Parameters.AddWithValue("@MS_ID", msid);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public static List<Element> SearchElementsByKW(string keyword)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Elements Where Component Like '%'+@Component+'%'", cnStr);
            da.SelectCommand.Parameters.AddWithValue("@Component", keyword);

            DataTable dt = new DataTable();
            da.Fill(dt);
            var query = from row in dt.AsEnumerable()
                        select new Element() {
                            MS_ID = Convert.ToInt32(row["MS_ID"]),
                            Component = row["Component"].ToString(),
                            Config = row["Config"].ToString(),
                            Supplier = row["Supplier"].ToString(),
                            Qty = Convert.ToInt32(row["Qty"]),
                            Lasteditdate = Convert.ToDateTime(row["Lasteditdate"])
                        };
            return query.ToList();
        }
    }
}
