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
    public partial class admin2 : Form
    {
        public admin2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Table();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void admin2_Load(object sender, EventArgs e)
        {
            Table();
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() +"  " +dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
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

        //根据书号显示数据
        public void TableID()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            string sql = $"select * from T_Book where ID='{textBox1.Text}'";
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

        //根据书名显示数据 模糊查询
        public void TableName()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            string sql = $"select * from T_Book where Name like '%{textBox2.Text}%' ";
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
            admin21 a = new admin21();
            a.ShowDialog();
            Table();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取书号
                label2.Text = id + "  " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult dr = MessageBox.Show("确认删除吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from T_Book where ID='{id}'";
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
                MessageBox.Show("请现在表格中选中要删除的图书记录！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "  " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try//捕获用户的操作
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//创建字符串来保存用户的修改信息
                string name= dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string author= dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string press= dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string number= dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                admin22 admin = new admin22(id,name,author,press,number);
                admin.ShowDialog();
                Table();//刷新
            }
            catch//异常
            {
                MessageBox.Show("error");
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            TableID();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TableName();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
