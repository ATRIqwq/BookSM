using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BookMS
{
    internal class linksql
    {
        SqlConnection sc;
        public SqlConnection connect()
        {
            string str = @"Data Source=LAPTOP-GM1U5OB4;Initial Catalog=BookMs;Integrated Security=True";//数据库连接字符串
            sc = new SqlConnection(str);//创建数据库连接对象
            sc.Open();//打开数据库
            return sc;//返回数据库对象
        }

        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;
        }

        public int Execute(string sql)//更新
        {
            return command(sql).ExecuteNonQuery();
        }

        public SqlDataReader read(string sql)//读取
        {
            return command(sql).ExecuteReader();
        }

        public void linkClose()
        {
            sc.Close();
        }
    }
}
