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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//添加用户即注册用户
        {

            if(textBox1.Text!=""&& textBox2.Text != ""&& textBox3.Text != ""&& textBox4.Text != "")
            { 
                linksql link=new linksql();
                string sql = $"insert into T_User values('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}')";
                int n=link.Execute(sql);//执行sql语句
                if(n>0)
                {
                    MessageBox.Show("注册成功");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("注册失败");
                }
            }
            else
            {
                MessageBox.Show("输入不能为空");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
              this.Close();
        }
    }
}
