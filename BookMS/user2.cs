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
    public partial class user2 : Form
    {
        public user2()
        {
            InitializeComponent();
            Table();
        }

        private void user2_Load(object sender, EventArgs e)
        {

        }
        //从数据库中读取数据并显示在表格控件中
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            string sql = "select * from T_Book";
            linksql link = new linksql();
            IDataReader dc = link.read(sql);
            string a0, a1, a2, a3, a4;
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                a3 = dc[3].ToString();
                a4 = dc[4].ToString();
                string[] table = { a0, a1, a2, a3, a4 };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            link.linkClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id=dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取书号
            int number= int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());//库存
            if(number<1)
            {
                MessageBox.Show("该图书库存不足，请联系管理员购入");
            }
            else
            {
                string sql = $"insert into T_lend([UID],[BID],[Datetime]) values('{Data.UID}','{id}',GETDATE());update T_Book set Number=Number-1 where ID='{id}'";
                linksql link = new linksql();
                if(link.Execute(sql)>1)//执行两条sql,大于1才是都成功了
                {
                    MessageBox.Show($"用户{Data.UName}借出了图书{id}!");
                    Table();
                }
            }
        }
    }
}
