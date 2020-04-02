using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
namespace MarsApp.Controllers
{
    public class Apod
    {
        string apiURL;
        //stores json string from nasa API
        string json = "";
        //Stores one week of Sol object keys
       
        string[] apodArray;
        public Dictionary<string, dynamic> apodDictionary = new Dictionary<string, dynamic>();
        //Key = Sol Key, Value = dynamic Sol Object based on the corresponding key
     


        public Apod(string apiURL)
        {
            this.apiURL = apiURL;
            //Generates the json string and stores it in the json class variable
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(apiURL);
            }
            generateApodObjects();
        }


        private void generateApodObjects()
        {
            var jsonString = new JavaScriptSerializer().Deserialize<dynamic>(json);
            Console.WriteLine(jsonString);
            // Gets sol keys segment of the json data
            string apodString = jsonString["hdurl"] + "";
            //Removes unnecessary information from the solstring(commas and brackets)
            apodString = apodString.Replace("[", "");
            apodString = apodString.Replace("]", "");
            apodString = apodString.Replace("\"", "");
            //Splits the solString into an array of solDates.  These are used to access individual sol objects from jsonString. ex: jsonString[solArray[0]] returns a 
            //sol object from the jsonString
            this.apodArray = apodString.Split(',');

            apodDictionary.Add(apodArray[0], 0);
        }
    }
}
