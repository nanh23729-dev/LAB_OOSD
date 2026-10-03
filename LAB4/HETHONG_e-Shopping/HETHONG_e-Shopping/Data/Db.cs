using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EShopping.Data
{
    public class Db
    {
        // Đọc chuỗi kết nối từ App.config, tên phải trùng với name="eShoppingDb"
        private static string connStr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["eShoppingDb"].ConnectionString;
            }
        }

        // Truy vấn trả về bảng
        public static DataTable ExecuteQuery(string sql, params SqlParameter[] ps)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddRange(ps);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // Thêm, sửa, xóa
        public static int ExecuteNonQuery(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddRange(ps);
                cn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Trả về 1 giá trị (đếm, mã vừa phát sinh...)
        public static object ExecuteScalar(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddRange(ps);
                cn.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}