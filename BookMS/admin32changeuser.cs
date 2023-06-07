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
    public partial class admin32changeuser : Form
    {
        string ID = "";
        public admin32changeuser()
        {
            InitializeComponent();
        }

        public admin32changeuser(string id,string name,string sex,string password)
        {
            InitializeComponent();
            ID = textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = sex;
            textBox4.Text = password;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update T_User set ID='{textBox1.Text}',Name='{textBox2.Text}',Sex='{textBox3.Text}',Password='{textBox4.Text}' where ID='{ID}'";
            linksql link = new linksql();
            if (link.Execute(sql) > 0)
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
        }
    }
}
