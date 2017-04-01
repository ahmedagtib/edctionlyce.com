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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        DataTable dt=new DataTable();
        private void button1_Click(object sender, EventArgs e)
        { 

            Program.cn.Open();
            Program.cmd = new SqlCommand("select el.codeEleve as'رمز التلميد',el.nomEleve as'الإسم العائلي',el.prenomEleve as'الإسم الشخصي',el.nomElevefr as 'Nom',el.prenomElevefr as 'Prenom',el.GenreAr as 'الجنس',el.Moyenne as'معدل ',ec.nom_colg as'المؤسسة'from eleve el,cercle ce,colg ec where  el.code_colg=ec.code_colg  and ec.idcer=ce.idcer order by el.Moyenne desc  ", Program.cn);
            // Program.cmd.Connection = Program.cn;
            Program.cmd.CommandType = CommandType.Text;
            SqlDataReader dr1 = Program.cmd.ExecuteReader();

            dt.Load(dr1);

            dataGridView1.DataSource = dt;
            dr1.Close();
            Program.cn.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
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
            this.dt = new DataTable();
            Program.cn.Open();
            Program.cmd.CommandText = (" select el.codeEleve as'رمز التلميد',el.nomEleve as'الإسم العائلي',el.prenomEleve as'الإسم الشخصي',el.nomElevefr as 'Nom',el.prenomElevefr as 'Prenom',el.GenreAr as 'الجنس',el.Moyenne as'معدل ',ec.nom_colg as'المؤسسة'from eleve el,cercle ce,colg ec where  el.code_colg=ec.code_colg  and ec.idcer=ce.idcer and ce.nomcer='" + comboBox1.Text + "' order by el.Moyenne desc");
            Program.cmd.Connection = Program.cn;
            SqlDataReader dr1 = Program.cmd.ExecuteReader();

            dt.Load(dr1);
            dataGridView1.DataSource = dt;
            dr1.Close();
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
            this.dt = new DataTable();
            Program.cn.Open();
            Program.cmd.CommandText = (" select el.codeEleve as'رمز التلميد',el.nomEleve as'الإسم العائلي',el.prenomEleve as'الإسم الشخصي',el.nomElevefr as 'Nom',el.prenomElevefr as 'Prenom',el.GenreAr as 'الجنس',el.Moyenne as'معدل 'from eleve el,cercle ce,colg ec where  el.code_colg=ec.code_colg and  ec.idcer=ce.idcer and ec.nom_colg='" + comboBox2.Text + "' order by el.Moyenne desc");
            Program.cmd.Connection = Program.cn;
            SqlDataReader dr1 = Program.cmd.ExecuteReader();
            dt.Load(dr1);
            dataGridView1.DataSource = dt;

            dr1.Close();
            Program.cn.Close();
            comboBox2.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 mm = new Form2();
            mm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            this.Refresh();
        }
    }
}
