﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MarsApp.Controllers
{   
    //Controller for obtaining the different SOL's on Mars using the MarsWeather class.
    public class MarsWeatherController : Controller
    {
        // GET: MarsWeather
        public ActionResult Index()
        {
            Apod apod = new Apod("https://api.nasa.gov/planetary/apod?api_key=NcKMjeHHC1KUE9P03JuNaJA5vphTjexO9KzCcPh4");


            // API call through the Mars weather class.  
            MarsWeather weather = new MarsWeather("https://api.nasa.gov/insight_weather/?api_key=NcKMjeHHC1KUE9P03JuNaJA5vphTjexO9KzCcPh4&feedtype=json&ver=1.0");
            // Dictionary stores each individual SOL and its corresponding attributes.
            Dictionary<string, dynamic> solDictionary = weather.solDictionary;
            //Assigns the image URL to a viewbag.
            ViewBag.apod = apod.apodDictionary.Keys.ElementAt(0);


            // Each ViewBag below contains the specified attrubte pulled from the api call in solDictionary.  Ex: ViewBag.MartianDay contains the sol that the weather was recorded.
            // All of these variables are displayed under the Mars weather view, inside of the index file.  This information will eventually be stored as objects in the database upon 
            // completion.  As for the messy variable assignments, this is just to show that data has been retrieved.  As mentioned earlier, the objects stored in the database can be used along with sql statements
            // to display any relevant information based on the UI, which is up to another team member.
            string solDay1 = 
            //Day 1
            ViewBag.MartianDay = " " + solDictionary.Keys.ElementAt(0);
            ViewBag.EarthDay = " " + solDictionary.ElementAt(0).Value.First_UTC;//Time of first datum, of any sensor, for the Sol 
            ViewBag.AverageTemperature = " " + solDictionary.ElementAt(0).Value.AT.av + " \x00B0F"; //Temperature average
            ViewBag.Low = " " + solDictionary.ElementAt(0).Value.AT.mn + " \x00B0F"; //Temperature minimum
            ViewBag.High = " " + solDictionary.ElementAt(0).Value.AT.mx + " \x00B0F"; //Temperature Max
            ViewBag.Pressure = " " + solDictionary.ElementAt(0).Value.PRE.av + " Pa"; //Average barometric pressure
            ViewBag.LowPressure = " " + solDictionary.ElementAt(0).Value.PRE.mn + " Pa";//Min pressure
            ViewBag.HighPressure = " " + solDictionary.ElementAt(0).Value.PRE.mx + " Pa";//Max pressure
            ViewBag.Season = " " + solDictionary.ElementAt(0).Value.Season;//Current season
            ViewBag.WindDirection = " " + solDictionary.ElementAt(0).Value.WD.most_common.compass_point;//Most common wind direction
            //Day 2
            ViewBag.MartianDay1 = " " + solDictionary.Keys.ElementAt(1);
            ViewBag.EarthDay1 = " " + solDictionary.ElementAt(1).Value.First_UTC;//Each sol field is accessed in the same order as day 1
            ViewBag.AverageTemperature1 = " " + solDictionary.ElementAt(1).Value.AT.av + " \x00B0F";
            ViewBag.Low1 = " " + solDictionary.ElementAt(1).Value.AT.mn + " \x00B0F";
            ViewBag.High1 = " " + solDictionary.ElementAt(1).Value.AT.mx + " \x00B0F";
            ViewBag.Pressure1 = " " + solDictionary.ElementAt(1).Value.PRE.av + " Pa";
            ViewBag.LowPressure1 = " " + solDictionary.ElementAt(1).Value.PRE.mn + " Pa";
            ViewBag.HighPressure1 = " " + solDictionary.ElementAt(1).Value.PRE.mx + " Pa";
            ViewBag.Season1 = " " + solDictionary.ElementAt(1).Value.Season;
            ViewBag.WindDirection1 = " " + solDictionary.ElementAt(1).Value.WD.most_common.compass_point;
            //Day 3
            ViewBag.MartianDay2 = " " + solDictionary.Keys.ElementAt(2);
            ViewBag.EarthDay2 = " " + solDictionary.ElementAt(2).Value.First_UTC;//Each sol field is accessed in the same order as day 1
            ViewBag.AverageTemperature2 = " " + solDictionary.ElementAt(2).Value.AT.av + " \x00B0F";
            ViewBag.Low2 = " " + solDictionary.ElementAt(2).Value.AT.mn + " \x00B0F";
            ViewBag.High2 = " " + solDictionary.ElementAt(2).Value.AT.mx + " \x00B0F";
            ViewBag.Pressure2 = " " + solDictionary.ElementAt(2).Value.PRE.av + " Pa";
            ViewBag.LowPressure2 = " " + solDictionary.ElementAt(2).Value.PRE.mn + " Pa";
            ViewBag.HighPressure2 = " " + solDictionary.ElementAt(2).Value.PRE.mx + " Pa";
            ViewBag.Season2 = " " + solDictionary.ElementAt(2).Value.Season;
            ViewBag.WindDirection2 = " " + solDictionary.ElementAt(2).Value.WD.most_common.compass_point;
            //Day 4
            ViewBag.MartianDay3 = " " + solDictionary.Keys.ElementAt(3);
            ViewBag.EarthDay3 = " " + solDictionary.ElementAt(3).Value.First_UTC;//Each sol field is accessed in the same order as day 1
            ViewBag.AverageTemperature3 = " " + solDictionary.ElementAt(3).Value.AT.av + " \x00B0F";
            ViewBag.Low3 = " " + solDictionary.ElementAt(3).Value.AT.mn + " \x00B0F";
            ViewBag.High3 = " " + solDictionary.ElementAt(3).Value.AT.mx + " \x00B0F";
            ViewBag.Pressure3 = " " + solDictionary.ElementAt(3).Value.PRE.av + " Pa";
            ViewBag.LowPressure3 = " " + solDictionary.ElementAt(3).Value.PRE.mn + " Pa";
            ViewBag.HighPressure3 = " " + solDictionary.ElementAt(3).Value.PRE.mx + " Pa";
            ViewBag.Season3 = " " + solDictionary.ElementAt(3).Value.Season;
            ViewBag.WindDirection3 = " " + solDictionary.ElementAt(3).Value.WD.most_common.compass_point;
            //Day 5
            ViewBag.MartianDay4 = " " + solDictionary.Keys.ElementAt(4);
            ViewBag.EarthDay4 = " " + solDictionary.ElementAt(4).Value.First_UTC;//Each sol field is accessed in the same order as day 1
            ViewBag.AverageTemperature4 = " " + solDictionary.ElementAt(4).Value.AT.av + " \x00B0F";
            ViewBag.Low4 = " " + solDictionary.ElementAt(4).Value.AT.mn + " \x00B0F";
            ViewBag.High4 = " " + solDictionary.ElementAt(4).Value.AT.mx + " \x00B0F";
            ViewBag.Pressure4 = " " + solDictionary.ElementAt(4).Value.PRE.av + " Pa";
            ViewBag.LowPressure4 = " " + solDictionary.ElementAt(4).Value.PRE.mn + " Pa";
            ViewBag.HighPressure4 = " " + solDictionary.ElementAt(4).Value.PRE.mx + " Pa";
            ViewBag.Season4 = " " + solDictionary.ElementAt(4).Value.Season;
            ViewBag.WindDirection4 = " " + solDictionary.ElementAt(4).Value.WD.most_common.compass_point;
            //Day 6
            ViewBag.MartianDay5 = " " + solDictionary.Keys.ElementAt(5);
            ViewBag.EarthDay5 = " " + solDictionary.ElementAt(5).Value.First_UTC;//Each sol field is accessed in the same order as day 1 
            ViewBag.AverageTemperature5 = " " + solDictionary.ElementAt(5).Value.AT.av + " \x00B0F";
            ViewBag.Low5 = " " + solDictionary.ElementAt(5).Value.AT.mn + " \x00B0F";
            ViewBag.High5 = " " + solDictionary.ElementAt(5).Value.AT.mx + " \x00B0F";
            ViewBag.Pressure5 = " " + solDictionary.ElementAt(5).Value.PRE.av + " Pa";
            ViewBag.LowPressure5 = " " + solDictionary.ElementAt(5).Value.PRE.mn + " Pa";
            ViewBag.HighPressure5 = " " + solDictionary.ElementAt(5).Value.PRE.mx + " Pa";
            ViewBag.Season5 = " " + solDictionary.ElementAt(5).Value.Season;
            ViewBag.WindDirection5 = " " + solDictionary.ElementAt(5).Value.WD.most_common.compass_point;
            //Day 7
            ViewBag.MartianDay6 = " " + solDictionary.Keys.ElementAt(6);
            ViewBag.EarthDay6 = " " + solDictionary.ElementAt(6).Value.First_UTC;//Each sol field is accessed in the same order as day 1
            ViewBag.AverageTemperature6 = " " + solDictionary.ElementAt(6).Value.AT.av + " \x00B0F";
            ViewBag.Low6 = " " + solDictionary.ElementAt(6).Value.AT.mn + " \x00B0F";
            ViewBag.High6 = " " + solDictionary.ElementAt(6).Value.AT.mx + " \x00B0F";
            ViewBag.Pressure6 = " " + solDictionary.ElementAt(6).Value.PRE.av + " Pa";
            ViewBag.LowPressure6 = " " + solDictionary.ElementAt(6).Value.PRE.mn + " Pa";
            ViewBag.HighPressure6 = " " + solDictionary.ElementAt(6).Value.PRE.mx + " Pa";
            ViewBag.Season6 = " " + solDictionary.ElementAt(6).Value.Season;
            ViewBag.WindDirection6 = " " + solDictionary.ElementAt(6).Value.WD.most_common.compass_point;
            return View();
        }
    }
}