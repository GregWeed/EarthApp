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
      
        //Makes an api call to nasas astronomy pickture of the day.     
        public Apod(string apiURL)
        {
            this.apiURL = apiURL;
            //Generates the json string
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(apiURL);
            }
            generateApodObjects();
        }

        //Creates an apod object, which all we are currently concerned with is the URL so that we can get the image.  When the project has progressed further, we can consider integrating image information
        //into the user interface.  
        private void generateApodObjects()
        {
            var jsonString = new JavaScriptSerializer().Deserialize<dynamic>(json);
            Console.WriteLine(jsonString);
            // Gets url from the called json
            string apodString = jsonString["hdurl"] + "";
            //Removes unnecessary information from the jsonString(commas and brackets)
            apodString = apodString.Replace("[", "");
            apodString = apodString.Replace("]", "");
            apodString = apodString.Replace("\"", "");
            //Splits the APOD json
            //sol object from the jsonString
            this.apodArray = apodString.Split(',');
            //Adds the object to the dictionary.
            apodDictionary.Add(apodArray[0], 0);
        }
    }
}
