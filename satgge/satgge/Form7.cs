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
    public partial class Form7 : Form
    {
        public Form7()
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("قم بإدخال رمز التلميد"); }
            else
            {
                if (exite() == false)
                {
                    MessageBox.Show("لا يوجد في قاعدة البيانات");
                }
                else
                {
                    Program.cn.Open();
                    Program.cmd = new SqlCommand("select  el.codeEleve as'رمز التلميد',el.nomEleve as'الإسم العائلي',el.prenomEleve as'الإسم الشخصي',el.nomElevefr as 'Nom',el.prenomElevefr as 'Prenom',el.GenreAr as 'الجنس',el.Moyenne as'معدل ',ec.nom_colg as'المؤسسة'from eleve el,colg ec where  el.code_colg=ec.code_colg and  el.codeEleve='" + textBox1.Text + "'", Program.cn);
                    Program.dr = Program.cmd.ExecuteReader();
                    DataTable t = new DataTable();
                    t.Load(Program.dr);
                    dataGridView1.DataSource = t;
                    Program.dr.Close();
                    Program.cn.Close();

                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 kl = new Form2();
            kl.Show();
        }
    }
}
