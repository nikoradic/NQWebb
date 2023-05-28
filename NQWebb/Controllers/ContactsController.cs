using Microsoft.AspNetCore.Mvc;
using NQWebb.Helpers.Repositories;
using NQWebb.Models.ViewModels;

namespace NQWebb.Controllers
{
    public class ContactsController : Controller
    {


        private readonly ContactFormRepo _contactFormRepo;

        public ContactsController(ContactFormRepo contactFormRepo)
        {
            _contactFormRepo = contactFormRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormVM vM)
        {

            if (ModelState.IsValid)
            {
                await _contactFormRepo.AddAsync(new Models.Entites.ContactFormEntity
                {
                    Name = vM.Name,
                    Email = vM.Email

                });

                return RedirectToAction("Index");



            }
            return View(vM);
        }
    }
}
