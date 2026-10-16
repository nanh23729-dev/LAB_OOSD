using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Data
{
    /// <summary>Truy cập dữ liệu. Tham số truyền theo cặp: "@ten", giaTri, "@ten2", giaTri2...</summary>
    public static class Db
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["QuanLyBenhAnDB"].ConnectionString; }
        }

        public static SqlConnection OpenConnection()
        {
            var cn = new SqlConnection(ConnectionString);
            cn.Open();
            return cn;
        }

        public static SqlCommand Cmd(SqlConnection cn, SqlTransaction tx, string sql, params object[] kv)
        {
            var c = new SqlCommand(sql, cn, tx);
            for (int i = 0; i + 1 < kv.Length; i += 2)
                c.Parameters.AddWithValue((string)kv[i], kv[i + 1] ?? DBNull.Value);
            return c;
        }

        public static DataTable Query(string sql, params object[] kv)
        {
            using (var cn = OpenConnection())
            using (var cmd = Cmd(cn, null, sql, kv))
            using (var da = new SqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static int Execute(string sql, params object[] kv)
        {
            using (var cn = OpenConnection())
            using (var cmd = Cmd(cn, null, sql, kv))
                return cmd.ExecuteNonQuery();
        }

        public static object Scalar(string sql, params object[] kv)
        {
            using (var cn = OpenConnection())
            using (var cmd = Cmd(cn, null, sql, kv))
                return cmd.ExecuteScalar();
        }

        /// <summary>Sinh mã kế tiếp dạng PREFIX + số (vd HS00001). Khóa bảng trong transaction để không trùng.</summary>
        public static string NextCode(SqlConnection cn, SqlTransaction tx, string table, string col, string prefix, int width)
        {
            string sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(" + col + "," + (prefix.Length + 1) + ",20) AS int)),0)+1 FROM "
                       + table + " WITH (UPDLOCK,HOLDLOCK) WHERE " + col + " LIKE @p";
            using (var c = Cmd(cn, tx, sql, "@p", prefix + "[0-9]%"))
                return prefix + Convert.ToInt32(c.ExecuteScalar()).ToString("D" + width);
        }

        /// <summary>Hồ sơ đã đóng lệ phí cho năm này chưa?</summary>
        public static bool CoLePhiNam(SqlConnection cn, SqlTransaction tx, string maHoSo, int nam)
        {
            using (var c = Cmd(cn, tx, "SELECT COUNT(*) FROM LePhiNam WHERE MaHoSo=@h AND Nam=@n", "@h", maHoSo, "@n", nam))
                return Convert.ToInt32(c.ExecuteScalar()) > 0;
        }

        /// <summary>Chạy một nghiệp vụ trong transaction: Ok -> commit, Fail/lỗi -> rollback.</summary>
        public static KetQuaXuLy InTx(Func<SqlConnection, SqlTransaction, KetQuaXuLy> work)
        {
            using (var cn = OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var r = work(cn, tx);
                    if (r.ThanhCong) tx.Commit(); else tx.Rollback();
                    return r;
                }
                catch (SqlException ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Fail(DichLoi(ex));
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Fail(ex.Message);
                }
            }
        }

        static string DichLoi(SqlException ex)
        {
            if (ex.Number == 2627 || ex.Number == 2601) return "Dữ liệu bị trùng (mã hoặc ràng buộc duy nhất).";
            if (ex.Number == 547) return "Vi phạm ràng buộc dữ liệu (khóa ngoại hoặc điều kiện hợp lệ).";
            return ex.Message;
        }
    }
}
