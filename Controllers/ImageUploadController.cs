﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarsApp.Controllers
{
    
    public class ImageUploadController : Controller
    {

        public ActionResult Index()
        {
           if(ViewBag.AverageTemperature >= 0)
            {
                ViewBag.image = "/upload/sun.png";
            }
           else if(ViewBag.AverageTemperature <= 0 && ViewBag.AverageTemperature >= -15)
            {
                ViewBag.image = "/upload/RainDrop.png";
            }
           else if (ViewBag.AverageTemperature < -15 && ViewBag.AverageTemperature >= 30)
            {
                ViewBag.image = "/upload/StormCloud.png";
            }
            else
                ViewBag.image = "/upload/Snowflake.png";






            return View();


        }
        //Provides information about the web hosting environment
        public static IWebHostEnvironment _environment;

        public ImageUploadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public class FileUploadAPI
        {
            //Represents a file sent with the HttpRequest.
            public IFormFile files { get; set; }
        }

        //Post Request
        [HttpPost]
        public async Task<string> Post(FileUploadAPI objFile)
        {
            try
            {
                if(objFile.files.Length > 0)
                {
                    if(!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                        RedirectToAction(nameof(Index));
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\Upload\\" + objFile.files.FileName;
                    }
                }
                else
                {
                    return "Failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }
    }


}
