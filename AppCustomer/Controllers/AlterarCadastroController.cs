using AppCustomer.Models;
using AppCustomer.ServiceCustomer;
using Microsoft.AspNetCore.Mvc;

namespace AppCustomer.Controllers
{
    public class AlterarCadastroController : Controller
    {
        private ManagerCustomer _managerCustomer;

        public AlterarCadastroController(ManagerCustomer managerCustomer)
        {
            _managerCustomer = managerCustomer;
        }
        public IActionResult Index(string searchCustomer)
        {

            var listCustomer = _managerCustomer.ListAllCustomer();

            if (listCustomer != null)
            {
                ViewBag.ListaCustomer = listCustomer;

            }

            if (!string.IsNullOrEmpty(searchCustomer) && listCustomer != null)
            {
                listCustomer = listCustomer
                    .Where(customer => customer.NameCustomer == searchCustomer ||
                    customer.EmailCustomer == searchCustomer).ToList();
            }

            ViewBag.ListaCustomer = listCustomer;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {

            if (customer != null)
            {
                var result = await _managerCustomer.UpdateCustomer(customer);

                if (result)
                {
                    var newListCustomer = _managerCustomer.ListAllCustomer();

                    ViewBag.ListaCustomer = newListCustomer;

                    TempData["MessageSuccessUpdate"] = "Alterado com sucesso";

                    return RedirectToAction("Index","AlterarCadastro");
                }
                TempData["MessageErrorUpdate"] = "Erro ao editar o cadastro!";

            }


            var listCustomer = _managerCustomer.ListAllCustomer();
            ViewBag.ListaCustomer = listCustomer;

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatusCustomer(string idInativar)
        {

            if (!string.IsNullOrEmpty(idInativar))
            {
                var result = await _managerCustomer.UpdateCustomerStatusRegister(idInativar);

                if (result)
                {
                    var newListCustomer = _managerCustomer.ListAllCustomer();

                    ViewBag.ListaCustomer = newListCustomer;

                    TempData["MessageSuccessUpdate"] = "Cadastro Inativado com sucesso!";

                    return RedirectToAction("Index", "AlterarCadastro");
                }
                TempData["MessageErrorUpdate"] = "Erro ao Inativar o cadastro!";

                return RedirectToAction("Index", "AlterarCadastro");


            }
            var listCustomer = _managerCustomer.ListAllCustomer();
            ViewBag.ListaCustomer = listCustomer;

            return View("Index");
        }

    }
}
