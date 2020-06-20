using Domain.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //solution("Ascdsfsd");
            FilmDao dao = new FilmDao();

            //dao.GetFilInfo("");
            dao.UpdateData();
            string url = "https://swapi.dev/api/films/";
            WebRequest request= WebRequest.Create(url);
            WebResponse response = null;

            try
            {
                response = request.GetResponse();
                string json = string.Empty;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    json = reader.ReadToEnd();
                }

               // return json;
            }
            catch (WebException ex)
            {
                //// TODO: Check status when there are no Internet connection. 
               // return null;
            }
            //https://swapi.dev/api/films/
        }
        public void solution(String s)
        {
            var strOne = "rather";
            var strTwo = "harder";
            //var strOne = "apple";
            //var strTwo = "pear";



            //var strOne = "a";
            //var strTwo = "p";
            var kkd = strTwo.ToList();
            var kk = strOne.ToList();

            int result = 0;

            foreach(char c in kk)
            {
                kkd.Remove(c);
            }
            result = kkd.Count();
            kkd = strTwo.ToList();
            foreach (char c in kkd)
            {
                kk.Remove(c);
            }
            result += kk.Count();

            int dif1,dif2;
            var intersect1 = strOne.Intersect(strTwo).Count();
            var except = strOne.Except(strTwo).Count();
            var intersect2 = strTwo.Intersect(strOne).Count();
            var except2 = strTwo.Except(strOne).Count();

            if (intersect1 + except == strOne.Length)
            {
                dif1 = except;
            }
            else
            {
                dif1 = strOne.Length - intersect1;
            }

            if (intersect2 + except2 == strTwo.Length)
            {
                dif2 = except2;
            }
            else
            {
                dif2 = strTwo.Length - intersect2;
            }



            //var intersect2 = strTwo.Intersect(strOne);
            //var except2 = strTwo.Except(strOne);

            //var Difference = (strOne.Length == strTwo.Length) ?
            //        (strOne.Length - intersect1.Count() - except.Count()) + (strTwo.Length - intersect1.Count() - except2.Count()) :
            //        ((strOne.Length - intersect1.Count()) + (strTwo.Length - intersect1.Count()));

            //var Result = (strOne.Length - intersect1.Count()- except.Count()) + (strTwo.Length - intersect1.Count()- except2.Count());
            //var Result2 = except.Count() + except2.Count();
            //var k = Math.Min(Result, Result2);

            //var except = strOne.Except(strTwo);

            //var arrayOne = strOne.ToCharArray().OrderBy(c=>c);
            //var arrayTwo = strTwo.ToCharArray().OrderBy(c => c);

            //var differentChars = arrayOne.Except(arrayTwo);
            //var differentChars2 = arrayTwo.Except(arrayOne);
        }

        private void Test(int j)
        {
            int previousVal = 0;
            var k = j.ToString();
            int starindex = j >= 0 ?0 : 1;
            for (int i = starindex; i <= k.Length; i++)
            {
                var r = k.Insert(i, "5").ToString();
                if (previousVal == 0) { previousVal = int.Parse(r); }
                if (int.Parse(r) > previousVal)
                {
                    previousVal = int.Parse(r);
                }
            }
            this.listBox1.Items.Add(previousVal);

        }
    }
}
