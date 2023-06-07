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
    public partial class admin3 : Form
    {
        public admin3()
        {
            InitializeComponent();
        }
        //从数据库中读取数据并显示在表格控件中
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            string sql = $"select * from T_User";
            linksql link = new linksql();
            IDataReader dc = link.read(sql);
            string a0, a1, a2, a3;
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                a3 = dc[3].ToString();
               
                string[] table = { a0, a1, a2, a3};
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            link.linkClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin31useradd a = new admin31useradd();
            a.ShowDialog();
            Table();
        }

        //根据ID显示数据
        public void TableID()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            string sql = $"select * from T_User where ID='{textBox1.Text}'";
            linksql link = new linksql();
            IDataReader dc = link.read(sql);
            string a0, a1, a2, a3;//保存读到的数据
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                a3 = dc[3].ToString();
              
                string[] table = { a0, a1, a2, a3};
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            link.linkClose();
        }
        //根据姓名显示数据
        public void TableName()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            string sql = $"select * from T_User where Name like '%{textBox2.Text}%'";
            linksql link = new linksql();
            IDataReader dc = link.read(sql);
            string a0, a1, a2, a3;//保存读到的数据
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                a3 = dc[3].ToString();

                string[] table = { a0, a1, a2, a3 };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            link.linkClose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TableID();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TableName();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Table();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//捕获用户选中的值保存在字符串中
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string sex = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string password= dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                
                admin32changeuser admin = new admin32changeuser(id, name,sex , password);
                admin.ShowDialog();
                Table();//刷新

            }
            catch
            {
                MessageBox.Show("error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取ID，防止选空
                label2.Text = id + "  " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult dr = MessageBox.Show("确认删除吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from T_User where ID='{id}'";
                    linksql link = new linksql();
                    if (link.Execute(sql) > 0)
                    {
                        MessageBox.Show("删除成功");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("删除失败" + sql);
                    }
                    link.linkClose();
                }


            }
            catch
            {
                MessageBox.Show("请现在表格中选中要删除的用户！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
