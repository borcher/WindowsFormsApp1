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
        DateTime startTime = DateTime.Now;

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
            timer.Enabled = true;
            timer.Interval = 3600000;
            timer.Elapsed += ChekcUpdate;
            timer.Start();
            
            Console.ReadLine();
        }
        private void ChekcUpdate(object sender, ElapsedEventArgs e)
        {
            if (startTime.Day < DateTime.Now.Day)
            {
                FilmDao dao = new FilmDao();
                startTime = DateTime.Now;
                timer.Stop();
                dao.UpdateData();
                timer.Start();
            }
                
        }
    }
}
