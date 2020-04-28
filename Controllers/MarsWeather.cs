using Nancy.Json;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;


namespace MarsApp.Controllers
{
   //This class makes a call to nasa's Mars weather API.  
    public class MarsWeather
    {
        string apiURL;
        //stores json string from nasa API
        string json = "";
        //Stores one week of Sol object keys
        string[] solNumberArray;
        //Key = Sol Key, Value = dynamic Sol Object based on the corresponding key
        public Dictionary<string, dynamic> solDictionary = new Dictionary<string, dynamic>();

        public MarsWeather(string apiURL){
            this.apiURL = apiURL;
            //Generates the json string and stores it in the json class variable
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(apiURL);
            }
            generateSolObjects();
        }
        //This function generates the SOL objects for each SOL on Mars.  Thes will need to be stored in the database upon completion, as there are only seven sols that are returned from the api call at aby given time.
        private void generateSolObjects()
        {
            var jsonString = new JavaScriptSerializer().Deserialize<dynamic>(json);
            // Gets sol keys segment of the json data
            string solString = jsonString["sol_keys"] + "";
            //Removes unnecessary information from the solstring(commas and brackets)
            solString = solString.Replace("[", "");
            solString = solString.Replace("]", "");
            solString = solString.Replace("\"", "");
            //Splits the solString into an array of solDates.  These are used to access individual sol objects from jsonString. ex: jsonString[solArray[0]] returns a 
            //sol object from the jsonString
            this.solNumberArray = solString.Split(',');

            for (int i = 0; i < 7; i++)
            {
                string jsonSolObj = jsonString[solNumberArray[i]] + "";
                dynamic solWeatherObject = JsonConvert.DeserializeObject<dynamic>(jsonSolObj);
                //Dictionary holds each sol object
                solDictionary.Add(solNumberArray[i], solWeatherObject);
            }
        }
    }
}
