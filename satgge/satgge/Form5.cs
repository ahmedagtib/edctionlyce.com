using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace satgge
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public bool exite()
        {
            bool e = false;
            Program.cn.Open();
            Program.cmd = new SqlCommand("select * from eleve where codeEleve='" + textBox1.Text + "'", Program.cn);
            Program.dr = Program.cmd.ExecuteReader();
            if (Program.dr.HasRows == true)
            {
                e = true;

            }
            Program.dr.Close();
            Program.cn.Close();
            return e;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 zz = new Form2();
            zz.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (exite() == true)
            {
                Program.cn.Open();
                Program.cmd = new SqlCommand("delete eleve where codeEleve='" + textBox1.Text + "'", Program.cn);
                Program.cmd.ExecuteNonQuery();
                Program.cn.Close();
                MessageBox.Show(" تم الحدف");

            }
            else
            {
                MessageBox.Show("لا يوجد في قاعدة البيانات");
            }
        }
    }
}
