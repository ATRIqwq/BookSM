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
    public partial class user3 : Form
    {
        public user3()
        {
            InitializeComponent();
            Table();
        }

        private void user3_Load(object sender, EventArgs e)
        {

        }
        //从数据库中读取数据并显示在表格控件中
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            linksql link = new linksql();
            string sql = $"select [NO],[BID],[Datetime] from T_lend where [UID]='{Data.UID}'";
            
            IDataReader dc = link.read(sql);
            string a0, a1, a2;
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
               
                string[] table = { a0, a1, a2};
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            link.linkClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string no=dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string id = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string sql = $"delete from T_lend where [NO]={no};update T_Book set Number=Number+1 where ID='{id}'";
            linksql link = new linksql();
            if(link.Execute(sql)>1)
            {
                MessageBox.Show("归还成功");
                Table();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
