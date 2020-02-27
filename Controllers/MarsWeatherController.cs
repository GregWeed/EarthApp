using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarsApp.Controllers
{
    public class MarsWeatherController : Controller
    {
        // GET: MarsWeather
        public ActionResult Index()
        {
            MarsWeather weather = new MarsWeather("https://api.nasa.gov/insight_weather/?api_key=NcKMjeHHC1KUE9P03JuNaJA5vphTjexO9KzCcPh4&feedtype=json&ver=1.0");
            Dictionary<string, dynamic> solDictionary = weather.solDictionary;

            string solDay1 = 



            ViewBag.MartianDay = " " + solDictionary.Keys.ElementAt(0);
            ViewBag.EarthDay = " " + solDictionary.ElementAt(0).Value.First_UTC;//Time of first datum, of any sensor, for the Sol 
            ViewBag.AverageTemperature = " " + solDictionary.ElementAt(0).Value.AT.av + " \x00B0F";
            ViewBag.Low = " " + solDictionary.ElementAt(0).Value.AT.mn + " \x00B0F";
            ViewBag.High = " " + solDictionary.ElementAt(0).Value.AT.mx + " \x00B0F";
            ViewBag.Pressure = " " + solDictionary.ElementAt(0).Value.PRE.av + " Pa";
            ViewBag.LowPressure = " " + solDictionary.ElementAt(0).Value.PRE.mn + " Pa";
            ViewBag.HighPressure = " " + solDictionary.ElementAt(0).Value.PRE.mx + " Pa";
            ViewBag.Season = " " + solDictionary.ElementAt(0).Value.Season;
            ViewBag.WindDirection = " " + solDictionary.ElementAt(0).Value.WD.most_common.compass_point;

            return View();
        }

        // GET: MarsWeather/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MarsWeather/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarsWeather/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MarsWeather/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MarsWeather/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MarsWeather/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MarsWeather/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}