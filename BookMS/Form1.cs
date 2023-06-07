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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="" &&textBox2.Text!="")
            {
                login();
            }
            else
            {
                MessageBox.Show("输入项有空项，请重新输入");
            }
        }

        //登录方法，验证是否允许登录，允许返回真
        public void login()
        {
            //用户
            if(radioUser.Checked==true)
            {
                linksql link=new linksql();
                string sql = $"select * from T_User where ID='{textBox1.Text}' and Password='{textBox2.Text}'";
                IDataReader dc=link.read(sql);
                if(dc.Read())
                {
                    Data.UID=dc["ID"].ToString();
                    Data.UName=dc["Name"].ToString();
                    MessageBox.Show("登录成功");
                    user1 use=new user1();
                    this.Hide();
                    use.ShowDialog();
                    this.Show();
                   
                }
                else
                {
                    MessageBox.Show("登录失败");
                    
                }
                link.linkClose();
            }
            //管理员
            if(radioAdmin.Checked==true)
            {
                linksql link = new linksql();
                string sql = $"select * from T_admin where ID='{textBox1.Text}' and Password='{textBox2.Text}'";
                IDataReader dc = link.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("登录成功");
                    admin1 a=new admin1();
                    this.Hide();
                    a.ShowDialog();
                    this.Show();

                    
                }
                else
                {
                    MessageBox.Show("登录失败");
                    
                }
                link.linkClose();
            }
            
           
        }

        private void radioUser_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(radioUser.Checked==true)
            {
                Form2 form = new Form2();
                form.ShowDialog();
            }
        }
    }
}
