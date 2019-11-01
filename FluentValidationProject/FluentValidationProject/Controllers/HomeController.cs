using System;
using System.Collections;
using System.Collections.Generic;
using FluentValidationProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using FluentValidation;
using FluentValidation.Results;
using FluentValidationProject.Validators;

namespace FluentValidationProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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

        [HttpPost]
        public IActionResult Create(EmployeeModel employee)
        {

            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                var validator = new EmployeeValidator();
                ValidationResult results = validator.Validate(employee);
                var errors = new List<string>();
                if (!results.IsValid)
                {
                    foreach (var failure in results.Errors)
                    {
                        var error = $"Property {failure.PropertyName} failed validation. Error was: {failure.ErrorMessage}";
                        errors.Add(error);
                    }
                }

                return View("Index", employee);
            }

      
            return RedirectToAction("Index");

        }
    }

    public interface IValidatorInterceptor
    {
        ValidationContext BeforeMvcValidation(ControllerContext controllerContext, ValidationContext validationContext);
        ValidationResult AfterMvcValidation(ControllerContext controllerContext, ValidationContext validationContext, ValidationResult result);
    }

}
