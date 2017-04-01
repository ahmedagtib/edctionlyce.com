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
    public partial class Form4 : Form
    {
        public Form4()
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
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            this.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.cn.Open();
            Program.cmd = new SqlCommand("select c.nom_colg from colg c,cercle cl where cl.idcer=c.idcer and cl.nomcer='" + comboBox1.Text + "'", Program.cn);

            Program.dr = Program.cmd.ExecuteReader();
            while (Program.dr.Read())
            {
                comboBox2.Items.Add(Program.dr[0]);

            }
            Program.dr.Close();
            Program.cn.Close();

        }

        private void Form4_Load(object sender, EventArgs e)
        {

            comboBox4.Items.Add("ذكر");
            comboBox4.Items.Add("أنثى");
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.cn.Open();
            Program.cmd = new SqlCommand("select code_colg from colg where nom_colg='" + comboBox2.Text + "'", Program.cn);

            Program.dr = Program.cmd.ExecuteReader();
            while (Program.dr.Read())
            {
                comboBox3.Items.Add(Program.dr[0]);

            }
            Program.dr.Close();
            Program.cn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 zz = new Form2();
            zz.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            { MessageBox.Show("تحقق من ملئ البيانات"); }
            else
            {
                if (exite() == true) { MessageBox.Show("هدا التلميد يوجد في قاعدة البيانات"); }
                else
                {
                    Program.cn.Open();
                    Program.cmd = new SqlCommand("insert into eleve values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox4.Text + "'," + textBox6.Text + ",'" + comboBox3.Text + "')", Program.cn);

                    Program.cmd.ExecuteNonQuery();

                    MessageBox.Show("تمة الإضافة");
                    Program.cn.Close();
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("قم إدخال رمز التلميد"); }
            else
            {
                if (exite() == false)
                {
                    MessageBox.Show("لا يوجد");
                }
                else
                {
                    Program.cn.Open();
                    Program.cmd = new SqlCommand("select nomEleve,prenomEleve,nomElevefr,prenomElevefr,Moyenne from eleve where codeEleve='" + textBox1.Text + "'", Program.cn);
                    Program.dr = Program.cmd.ExecuteReader();
                    if (Program.dr.Read())
                    {

                        textBox2.Text = Program.dr[0].ToString();
                        textBox3.Text = Program.dr[1].ToString();
                        textBox4.Text = Program.dr[2].ToString();
                        textBox5.Text = Program.dr[3].ToString();
                        textBox6.Text = Program.dr[4].ToString();

                    }

                    Program.dr.Close();
                    Program.cn.Close();

                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            { MessageBox.Show("تحقق من ملئ البيانات"); }
            else
            {
                if (exite() == false) { MessageBox.Show(" لايوجد هدا التلميد"); }
                else
                {
                    Program.cn.Open();
                    Program.cmd = new SqlCommand("update eleve set nomEleve='" + textBox2.Text + "',prenomEleve='" + textBox3.Text + "',nomElevefr='" + textBox4.Text + "',prenomElevefr='" + textBox5.Text + "',GenreAr='" + comboBox4.Text + "',code_colg='" + comboBox3.Text + "' where codeEleve='" + textBox1.Text + "'", Program.cn);

                    Program.cmd.ExecuteNonQuery();

                    MessageBox.Show("  تم التعديل");
                    Program.cn.Close();
                }
            }
        }
    }
}
