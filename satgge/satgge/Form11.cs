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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Program.cn.Open();
                Program.cmd = new SqlCommand("delete  bourse", Program.cn);
                Program.cmd.ExecuteNonQuery();
                Program.cn.Close();
                MessageBox.Show("bien fait");
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
            Program.cn.Open();
            Program.cmd = new SqlCommand("delete  eleve", Program.cn);
            Program.cmd.ExecuteNonQuery();
            Program.cn.Close();
            MessageBox.Show("bien fait");
        }
        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        }
    }


