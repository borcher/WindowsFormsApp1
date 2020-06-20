using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Domain;
using Domain.Dao;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        private Timer timer = new Timer();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static void Main(string[] args)
        {
            IntPtr h = Process.GetCurrentProcess().MainWindowHandle;
            ShowWindow(h, 0);
            Program pr = new Program();
            pr.start(); 
        }

       
        private void start()
        {
            FilmDao dao = new FilmDao();
            dao.UpdateData();

            timer.Enabled = true;
            timer.Interval = 3600000;
            timer.Elapsed += ChekcUpdate;
            timer.Start();
            
            Console.ReadLine();
        }
        private void ChekcUpdate(object sender, ElapsedEventArgs e)
        {

            FilmDao dao = new FilmDao();
            timer.Stop();
            dao.UpdateData();
            timer.Start();

        }
    }
}
