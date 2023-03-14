using AppCustomer.Models;
using AppCustomer.ServiceCustomer;
using Microsoft.AspNetCore.Mvc;

namespace AppCustomer.Controllers
{

    public class CadastroController : Controller
    {
        private ManagerCustomer _managerCustomer;

        public CadastroController(ManagerCustomer managerCustomer)
        {
            _managerCustomer = managerCustomer;
        }

        public IActionResult Index(Customer customer)
        {
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            if (ModelState.IsValid || customer == null)
            {
                var result = await _managerCustomer.QueryCustomer(customer.EmailCustomer);

                if (customer.EmailCustomer == result.EmailCustomer)
                {

                    TempData["MessageError"] = "Email em uso!";
                    return View("Index", customer);

                }
                if (await _managerCustomer.CreateCustomerAsync(customer))
                {
                    TempData["MessageSuccess"] = "Cadastro efetuado !";
                    return RedirectToAction("Index", "Cadastro");

                }

            }
            TempData["MessageError"] = "falha ao cadastrar!";
            return View("Index", customer);
        }

    }
}
