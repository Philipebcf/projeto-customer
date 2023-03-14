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

            var listCustomer = _managerCustomer.ListAllCustomer();

            try
            {
                
                if (customer != null)
                {
                    var result = await _managerCustomer.UpdateCustomer(customer);

                    if (result)
                    {

                        TempData["MessageSuccessUpdate"] = "Alterado com sucesso";

                        return RedirectToAction("Index", "AlterarCadastro");
                    }
                    
                }


            }
            catch (Exception)
            {
                TempData["MessageErrorUpdate"] = "Erro ao editar o cadastro!";
            }
            ViewBag.ListaCustomer = listCustomer;
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatusCustomer(string emailInativar)
        {
            var listCustomer = _managerCustomer.ListAllCustomer();

            try
            {
                if (!string.IsNullOrEmpty(emailInativar))
                {
                    var result = await _managerCustomer.UpdateCustomerStatusRegister(emailInativar);

                    if (result)
                    {

                        TempData["MessageSuccessUpdate"] = "Cadastro Inativado com sucesso!";
                        return RedirectToAction("Index", "AlterarCadastro");

                    }

                }
            }
            catch (Exception)
            {
                TempData["MessageErrorUpdate"] = "Erro ao Inativar o cadastro!";
                
            }
            ViewBag.ListaCustomer = listCustomer;
            return View("Index");

        }

    }
}
