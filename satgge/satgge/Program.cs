using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace satgge
{
    static class Program
    {
        public static SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ahmed"].ConnectionString);
        public static    SqlCommand cmd = new SqlCommand();
          public static  SqlDataReader dr;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
           
        
        }
    }
}
