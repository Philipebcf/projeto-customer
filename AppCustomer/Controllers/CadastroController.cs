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

            if (ModelState.IsValid)
            {
                if (customer != null)
                {
                    string queryCustomer = customer.EmailCustomer;

                    var resultEmail = await _managerCustomer.QueryCustomer(queryCustomer);

                    if (queryCustomer == resultEmail.EmailCustomer)
                    {
                        //TempData["MessageError"] = "Email já está em uso!";
                        TempData["MessageError"] = "Email em uso!";
                        return View("Index", customer);

                    }
                    var result = await _managerCustomer.CreateCustomerAsync(customer);

                    if (result)
                    {
                        TempData["MessageSuccess"] = "Cadastro efetuado !";
                        return RedirectToAction("Index", "Cadastro");

                    }
                    else
                    {
                        TempData["MessageError"] = "Erro ao cadastrar!";
                        return View("Index", customer);
                    }

                }
            }

            TempData["MessageError"] = "Erro, Preencher todos os campos!";
            return View("Index", customer);
        }

    }
}
