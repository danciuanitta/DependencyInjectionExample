using DependencyInjectionSample.DAL;
using DependencyInjectionSample.DISampleClasses;
using DependencyInjectionSample.Models;
using DependencyInjectionSample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IOperationService _operationService;
        private readonly IOperationTransient _transientOperation;
        private readonly IOperationScoped _scopedOperation;
        private readonly IOperationSingleton _singletonOperation;
        private readonly IOperationSingletonInstance _singletonInstanceOperation;

        private readonly IExampleService _someService1;
        private readonly IAnotherService _someService2;

        private readonly IExampleRepository _repo;

        public HomeController(ILogger<HomeController> logger, IOperationService operationService,
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            IOperationSingletonInstance singletonInstanceOperation,
            IExampleService service1,
            IAnotherService service2,
            IExampleRepository repo)
        {
            _logger = logger;
            _operationService = operationService;
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
            _singletonInstanceOperation = singletonInstanceOperation;

            //use breakpoints in each constructor to see the hierarchy and IoC
            _someService1 = service1;
            _someService2 = service2;
            _repo = repo;
        }

        public IActionResult Index()
        {
            ViewBag.Transient = _transientOperation;
            ViewBag.Scoped = _scopedOperation;
            ViewBag.Singleton = _singletonOperation;
            ViewBag.SingletonInstance = _singletonInstanceOperation;

            // Operation service has its own requested services
            ViewBag.Service = _operationService;

            var number1 = _someService1.GetNumber();
            var number2 = _someService2.GetSomeNumber();
            
            var number3 = _repo.GetNumber();

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
    }
}
