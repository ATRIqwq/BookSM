using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookMS
{
    public partial class user11show : Form
    {
        public user11show()
        {
            InitializeComponent();
            Table();
        }
        public void Table()//用于初始化学生信息
        {
            textBox1.Text = Data.UID;//传入登录id
            linksql link=new linksql();
            string sql = $"select * from T_User where ID='{Data.UID}'";//在学生表中查找登录id为 ...id 的学生
            IDataReader dc = link.read(sql);
            while (dc.Read())
            {
                textBox2.Text = dc[1].ToString();
                textBox3.Text = dc[2].ToString();
                textBox4.Text = dc[3].ToString();
            }
        }


        private void user11show_Load(object sender, EventArgs e)
        {

        }
    }
}
