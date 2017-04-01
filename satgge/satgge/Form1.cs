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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool login = false;

        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                
                Program.cn.Open();
                Program.cmd.CommandText = ("select * from utl where id_admin='" + textBox1.Text + "' and passe_admin='" + textBox2.Text + "'");
                Program.cmd.Connection = Program.cn;
                Program.dr = Program.cmd.ExecuteReader();
                if (Program.dr.Read())
                {
                    login = true;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {

                Program.cn.Close();
                Program.dr.Close();
                            
            }

            if (login == true)
            {
                this.Hide();

                Form2 f1 = new Form2();
                f1.Show();

            }
            else { MessageBox.Show("كلمة المرور غير صحيحة"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        }
    }


