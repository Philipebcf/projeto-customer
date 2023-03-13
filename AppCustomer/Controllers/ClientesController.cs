using AppCustomer.Models;
using AppCustomer.ServiceCustomer;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AppCustomer.Controllers
{
    public class ClientesController : Controller
    {
        private ManagerCustomer _managerCustomer;
        public ClientesController(ManagerCustomer managerCustomer)
        {
            _managerCustomer = managerCustomer;
        }
        public IActionResult Index(string searchCustomer, string exportarCSV)
        {
            var listaCustomer = _managerCustomer.ListAllCustomer();

            if (!string.IsNullOrEmpty(searchCustomer) && listaCustomer != null)
            {
                listaCustomer = listaCustomer.Where(x =>
                x.NameCustomer.Contains(searchCustomer) ||
                x.EmailCustomer.Contains(searchCustomer)).ToList();
            }

            if (!string.IsNullOrEmpty(exportarCSV) && listaCustomer != null)
            {
                var builderListCustomer = _managerCustomer.ListCustomerBuilder(listaCustomer);

                if (builderListCustomer != null)
                {
                    return File(Encoding.UTF8.GetBytes(builderListCustomer.ToString()), "txt/csv", "listaClientes.csv");
                }

            }

            ViewBag.ListaCustomer = listaCustomer;

            return View();
        }

    }
}
