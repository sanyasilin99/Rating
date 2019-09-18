using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rating_sotr
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew;
            new Mutex(false, " ", out createdNew);
            if (!createdNew)
            {
                MessageBox.Show(@"Программа уже запущена.", @"Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Log_Form());
        }

        public static string Name;  
        public static string Dolj;
        public static string server = "Raiting";
        
    }
}
