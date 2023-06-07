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
    public partial class admin22 : Form
    {
        string ID = "";//公共变量做主键ID值的保存
        public admin22()
        {
            InitializeComponent();
        }
        public admin22(string id,string name,string author, string press ,string number)
        {
            InitializeComponent();
            ID=textBox1.Text=id;    
            textBox2.Text=name;
            textBox3.Text=author;
            textBox4.Text=press;
            textBox5.Text=number;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update T_Book set ID='{textBox1.Text}',[Name]='{textBox2.Text}',Author='{textBox3.Text}',Press='{textBox4.Text}',Number={textBox5.Text} where ID='{ID}'";
            linksql link=new linksql();
            if(link.Execute(sql)>0)
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
        }
    }
}
