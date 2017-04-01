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
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
namespace satgge
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();

        private void button1_Click(object sender, EventArgs e)
        {
            dt.Clear();
            Program.cn.Open();
            Program.cmd = new SqlCommand("select codeEleve as'رمز التلميد',nomEleve as'الإسم العائلي',prenomEleve as'الإسم الشخصي',nomElevefr as 'Nom',prenomElevefr as 'Prenom',GenreAr as 'الجنس',Moyenne as'معدل ',nom_ly as'المؤسسة'from bourse order by Moyenne desc", Program.cn);
            // Program.cmd.Connection = Program.cn;
            Program.cmd.CommandType = CommandType.Text;
            SqlDataReader dr1 = Program.cmd.ExecuteReader();

            dt.Load(dr1);

            dataGridView1.DataSource = dt;
            dr1.Close();
            Program.cn.Close();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            Program.cn.Open();
            Program.cmd = new SqlCommand("select nom_ly  from lyce", Program.cn);

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
            dt.Clear();
            Program.cn.Open();
            Program.cmd.CommandText = ("select  codeEleve as'رمز التلميد',nomEleve as'الإسم العائلي',prenomEleve as'الإسم الشخصي',nomElevefr as 'Nom',prenomElevefr as 'Prenom',GenreAr as 'الجنس',Moyenne as'معدل 'from bourse where   nom_ly='" + comboBox1.Text + "' order by Moyenne desc");
            Program.cmd.Connection = Program.cn;
            SqlDataReader dr1 = Program.cmd.ExecuteReader();
            dt.Load(dr1);
            dataGridView1.DataSource = dt;

            dr1.Close();
            Program.cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = "c:";
            saveFileDialog1.Title = "fille";
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Excel  Files(2007)|*.xlsx";

            if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application a = new Microsoft.Office.Interop.Excel.Application();
                a.Application.Workbooks.Add(Type.Missing);
                a.Columns.ColumnWidth = 20;
                for (int i = 1; i < dataGridView1.Rows.Count + 1; i++)
                {
                    a.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        a.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }

                }
                a.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                a.ActiveWorkbook.Saved = true;
                a.Quit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 tt = new Form2();
            tt.Show();
        }
    }
}
