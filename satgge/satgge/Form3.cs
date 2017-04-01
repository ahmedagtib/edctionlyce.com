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
using Excel;
using System.Data.OleDb;

namespace satgge
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox1.Text = f.FileName;
            }
        }
        DataTable t = new DataTable();
        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection p = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + ";Extended Properties=\"Excel 12.0 Xml; HDR=YES \";");
            p.Open();

            OleDbCommand cmd1 = new OleDbCommand("select * from [" + textBox2.Text + "$]", p);
            OleDbDataReader dr = cmd1.ExecuteReader();
            t.Load(dr);
            dataGridView1.DataSource = t;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.cn.Open();
            SqlBulkCopy copy = new SqlBulkCopy(Program.cn);
            copy.DestinationTableName = "eleve";
            copy.WriteToServer(t);
            Program.cn.Close();
            MessageBox.Show("تم الإضافة");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
