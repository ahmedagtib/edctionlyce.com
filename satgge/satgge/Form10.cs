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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.cn.Open();
            Program.cmd = new SqlCommand("select count(*) from eleve where GenreAr='ذكر'", Program.cn);
            label5.Text = Program.cmd.ExecuteScalar().ToString();

            Program.cmd = new SqlCommand("select count(*) from eleve where GenreAr='أنثى'", Program.cn);
            label6.Text = Program.cmd.ExecuteScalar().ToString();
            Program.cn.Close();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            Program.cn.Open();
            Program.cmd = new SqlCommand("select nomcer from cercle", Program.cn);

            Program.dr = Program.cmd.ExecuteReader();
            while (Program.dr.Read())
            {
                comboBox1.Items.Add(Program.dr[0]);

            }

            Program.dr.Close();
            Program.cn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.cn.Open();
            Program.cmd = new SqlCommand("select count(*) from  eleve el,cercle ce,colg ec where  el.code_colg=ec.code_colg  and ec.idcer=ce.idcer  and ce.nomcer='" + comboBox1.Text + "' and el.GenreAr='ذكر'", Program.cn);
            label5.Text = Program.cmd.ExecuteScalar().ToString();

            Program.cmd = new SqlCommand("select count(*) from  eleve el,cercle ce,colg ec where  el.code_colg=ec.code_colg  and ec.idcer=ce.idcer  and ce.nomcer='" + comboBox1.Text + "' and el.GenreAr='أنثى'", Program.cn);
            label6.Text = Program.cmd.ExecuteScalar().ToString();
            Program.cn.Close();

            Program.cn.Open();
            Program.cmd = new SqlCommand("select c.nom_colg from colg c , cercle cu where c.idcer=cu.idcer and nomcer='" + comboBox1.Text + "'", Program.cn);

            Program.dr = Program.cmd.ExecuteReader();
            while (Program.dr.Read())
            {
                comboBox2.Items.Add(Program.dr[0]);

            }
            Program.dr.Close();
            Program.cn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.cn.Open();
            Program.cmd = new SqlCommand("select count(*) from eleve el,cercle ce,colg ec where  el.code_colg=ec.code_colg  and ec.idcer=ce.idcer and ec.nom_colg='" + comboBox2.Text + "' and el.GenreAr='ذكر'", Program.cn);
            label5.Text = Program.cmd.ExecuteScalar().ToString();

            Program.cmd = new SqlCommand("select count(*) from eleve el,cercle ce,colg ec where  el.code_colg=ec.code_colg  and ec.idcer=ce.idcer and ec.nom_colg='" + comboBox2.Text + "'  and el.GenreAr='أنثى'", Program.cn);
            label6.Text = Program.cmd.ExecuteScalar().ToString();
            Program.cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 hh = new Form2();
            hh.Show();
        }
    }
}
