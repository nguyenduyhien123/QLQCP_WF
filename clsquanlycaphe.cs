//thu vien kett noi database
using System.Data;
using System.Data.SqlClient;
namespace _9_12_QuanLyQuanCaPhe
{
    internal class clsquanlycaphe
    {
        SqlConnection con = new SqlConnection();

        void ketnoi()
        {
            con.ConnectionString = @"Data source=TANTAI;Initial Catalog=QUANLYQUANCAPHE; integrated Security=True";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        void dongketnoi()
        {
            con.Close();
        }

        public clsquanlycaphe()
        {
            ketnoi();
        }
        //dataset chứa nhiều bảng
        public DataSet LayDuLieu(string sql)
        {
            DataSet dataset = new DataSet();
            //để kết nối db đưa vào dataset dùng SqlDataAdapter 
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(dataset);
            return dataset;
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
