using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace satgge
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void جلبملفExeclToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 zz = new Form3();
            zz.Show();
        }

        private void إضافةوتعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 tt = new Form4();
            tt.Show();
        }

        private void حدفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 kk = new Form5();
            kk.Show();
        }

        private void تسجيلالخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void تدبيرالمقاعدToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 ll = new Form8();
            ll.Show();
        }

        private void الممنوحينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 lll = new Form9();
            lll.Show();
        }

        private void البياناتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form10 lh = new Form10();
            lh.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form11 hhh = new Form11();
            hhh.Show();
        }

        private void تدبيرالمقاعدالإناتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 aa = new Form12();
            aa.Show();
        }
    }
}
