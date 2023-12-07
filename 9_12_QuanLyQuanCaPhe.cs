using System.Data;
using System.Data.SqlClient;
namespace _9_12_QuanLyQuanCaPhe
{
    internal class _9_12_QuanLyQuanCaPhe
    {
        public string account = "";
        SqlConnection con = new SqlConnection();
        void KetNoi()
        {
            con.ConnectionString = @"Data source=TANTAI;Initial Catalog=QUANLYQUANCAPHE;integrated Security=True";
            if (con.State == ConnectionState.Closed)
                con.Open();
        }
        void DongKetNoi()
        {
            if (con.State == ConnectionState.Open)
            {
                //con.Close();
            }
        }
        public _9_12_QuanLyQuanCaPhe()
        {
            KetNoi();
        }
        ~_9_12_QuanLyQuanCaPhe()
        {
            DongKetNoi();
        }
        public DataSet LayDuLieu(string sql)
        {
            DataSet dataset = new DataSet();
            //để kết nối db đưa vào dataset dùng SqlDataAdapter 
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dataset);
            return dataset;
        }
        public int CapNhatDuLieu(string sql)
        {
            //con.Open();
            // Tạo SqlCommand và thực hiện truy vấn UPDATE
            SqlCommand command = new SqlCommand(sql, con);
            int affectedRows = command.ExecuteNonQuery(); // Số bản ghi bị ảnh hưởng bởi truy vấn
            //con.Close();
            return affectedRows;
        }
        public int capnhatdulieu(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            return cmd.ExecuteNonQuery();
        }
    }

}
