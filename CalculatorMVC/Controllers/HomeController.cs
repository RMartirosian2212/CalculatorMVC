using CalculatorMVC_DataAccess.Data;
using CalculatorMVC.Models;
using CalculatorMVC_DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CalculatorMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Calculator, int> _calculatorRepository;
        public HomeController(IRepository<Calculator, int> calculatorRepository)
        {
            _calculatorRepository = calculatorRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string mathExpression)
        {
            try
            {
                Calculator calculator = new Calculator()
                {
                    mathExpression = mathExpression,
                };
                _calculatorRepository.Insert(calculator);
                _calculatorRepository.Save();
            }
            catch (Exception ex)
            {
                SendError(ex);
            }
            
            return View();
        }

        public IActionResult GetHistory()
        {
            var history = _calculatorRepository.GetAll();
            return Json(history);
        }
        private void SendError(Exception exception)
        {
            Console.WriteLine($"Error: {exception.Message}");
        }
    }
}