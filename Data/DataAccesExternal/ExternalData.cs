using Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataAccesExternal
{
    public class ExternalData
    {
        public bool CheckLastUpdate()
        {
            using (StarWarsEntities1 ent = new StarWarsEntities1())
            {
                var Check = ent.Film.OrderBy(x => x.edited).Select(x => x.edited).FirstOrDefault();
                if (Check == null)
                    return true;
                return DateTime.Parse(Check.Value.ToShortDateString()) < DateTime.Parse(DateTime.UtcNow.ToShortDateString());
            }
        }
        public string GetData()
        {

            string url = "https://swapi.dev/api/films/";
            WebRequest request = WebRequest.Create(url);
            WebResponse response = null;
            try
            {
                response = request.GetResponse();
                string json = string.Empty;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    json = reader.ReadToEnd();
                }
                return json;
            }
            catch (WebException ex)
            {
                //// TODO: Check status when there are no Internet connection. 
                return null;
            }
            //https://swapi.dev/api/films/
        }

    }
}
