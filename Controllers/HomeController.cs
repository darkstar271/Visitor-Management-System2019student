﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Visitor_Management_System2019student.Models;
using Microsoft.AspNetCore.Hosting;
using Visitor_Management_System2019student.Services;
namespace Visitor_Management_System2019student.Controllers
{
    public class HomeController : Controller
    {
        private ITextFileOperations _textFileOperations;

        public HomeController(ITextFileOperations textFileOperations)
        {
            _textFileOperations = textFileOperations;
        }
        public IActionResult Index()
        {



            ViewBag.Welcome = "Welcome to visitor C# party house";
            ViewData["darren"] = "Another C# welcome";



            ViewBag.NewVisitor = new Visitors()
            {
                FirstName = "Howard",
                LastName = "Jones"
            };



            //======= Conditions of Acceptance
            //Gets or sets the absolute path to the directory that contains the web-servable application content files.

            ViewData["Conditions"] = _textFileOperations.LoadConditionsForAcceptanceText();



            return View();
        }
        public IActionResult StaffNamesAPI()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Contact()
        {
            return View();
        }

    }
}
