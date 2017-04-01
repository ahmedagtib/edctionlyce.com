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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
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
          
            Program.cn.Open();
            Program.cmd = new SqlCommand("select nomcer from cercle", Program.cn);

            Program.dr = Program.cmd.ExecuteReader();
            while (Program.dr.Read())
            {
                comboBox3.Items.Add(Program.dr[0]);

            }

            Program.dr.Close();
            Program.cn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           DataTable dt = new DataTable();
            Program.cn.Open();
            Program.cmd.CommandText = (" select el.codeEleve as'رمز التلميد',el.nomEleve as'الإسم العائلي',el.prenomEleve as'الإسم الشخصي',el.nomElevefr as 'Nom',el.prenomElevefr as 'Prenom',el.GenreAr as 'الجنس',el.Moyenne as'معدل ',ec.nom_colg as'المؤسسة'from eleve el,cercle ce,colg ec where  el.code_colg=ec.code_colg  and ec.idcer=ce.idcer and el.GenreAr='ذكر' and ce.nomcer='" + comboBox1.Text + "' order by el.Moyenne desc");
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
            if (textBox1.Text == "") { MessageBox.Show("إدخال عدد المقاعد"); }
            else
            {
                DataTable dt = new DataTable();
                Program.cn.Open();
                Program.cmd.CommandText = ("select top " + textBox1.Text + " el.codeEleve as'رمز التلميد',el.nomEleve as'الإسم العائلي',el.prenomEleve as'الإسم الشخصي',el.nomElevefr as 'Nom',el.prenomElevefr as 'Prenom',el.GenreAr as 'الجنس',el.Moyenne as'معدل 'from eleve el,cercle ce,colg ec where  el.code_colg=ec.code_colg and el.GenreAr='ذكر' and  ec.idcer=ce.idcer and ec.nom_colg='" + comboBox2.Text + "' order by el.Moyenne desc ");
                Program.cmd.Connection = Program.cn;
                SqlDataReader dr1 = Program.cmd.ExecuteReader();
                dt.Load(dr1);
                dataGridView1.DataSource = dt;

                dr1.Close();
                Program.cn.Close();

            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.cn.Open();
            Program.cmd = new SqlCommand("select c.nom_ly from lyce c , cercle cu where c.idcer =cu.idcer  and cu.nomcer ='" + comboBox3.Text + "'", Program.cn);

            Program.dr = Program.cmd.ExecuteReader();
            while (Program.dr.Read())
            {
                comboBox4.Items.Add(Program.dr[0]);

            }
            Program.dr.Close();
            Program.cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int j = 0;
                Program.cmd.CommandType = CommandType.Text;
                Program.cmd.Connection = Program.cn;
                Program.cn.Open();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    Program.cmd.CommandText = "insert into bourse(codeEleve,nomEleve,prenomEleve,nomElevefr,prenomElevefr,GenreAr,Moyenne,nom_ly)values('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "','" + dataGridView1.Rows[i].Cells[4].Value + "','" + dataGridView1.Rows[i].Cells[5].Value + "','" + dataGridView1.Rows[i].Cells[6].Value + "','" + comboBox4.Text + "')";
                    j = Program.cmd.ExecuteNonQuery();
                }
                if (j != 0) { MessageBox.Show("تمة العملية بنجاح"); }
            }
            catch (Exception ex) { MessageBox.Show(" " + ex.Message); }
            finally
            {
                Program.cn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 oo = new Form2();
            oo.Show();
        }
    }
}
