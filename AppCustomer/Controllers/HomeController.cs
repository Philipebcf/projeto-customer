using AppCustomer.ServiceCustomer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AppCustomer.Controllers
{
    public class HomeController : Controller
    {
        private ManagerCustomer _managerCustomer;
        public HomeController(ManagerCustomer managerCustomer)
        {
            _managerCustomer = managerCustomer;
        }

        public IActionResult Index()
        {
            var customers = _managerCustomer.ListAllCustomer();

            if (customers != null)
            {
                var totalJovens = _managerCustomer.FaixaEtaria(customers, "jovens");
                var totalAdultos = _managerCustomer.FaixaEtaria(customers, "adultos");
                var totalVelhos = _managerCustomer.FaixaEtaria(customers, "velhos");

                var totalEmails = customers.Where(email => email.EmailCustomer != null).Count();
                var totalCellPhone = customers.Where(cell => cell.CellPhoneCustomer != null).Count();

                var totalAtivos = customers.Where(t => t.Status_Register == 1).Count();
                var totalInativos = customers.Where(t => t.Status_Register == 0).Count();

                ViewBag.TotalClientes = customers.Count();
                ViewBag.TotalEmails = totalEmails;
                ViewBag.TotalCellPhones = totalCellPhone;
                ViewBag.TotalJovens = totalJovens;
                ViewBag.TotalAdultos = totalAdultos;
                ViewBag.TotalVelhos = totalVelhos;

                ViewBag.TotalAtivos = totalAtivos;
                ViewBag.TotalInativos = totalInativos;

                return View();
            }
            ViewBag.TotalClientes = 0;
            ViewBag.TotalEmails = 0;
            ViewBag.TotalCellPhones = 0;

            ViewBag.TotalJovens = 0;
            ViewBag.TotalAdultos = 0;
            ViewBag.TotalVelhos = 0;

            ViewBag.TotalAtivos = 0;
            ViewBag.TotalInativos = 0;

            return View();
        }

    }
}