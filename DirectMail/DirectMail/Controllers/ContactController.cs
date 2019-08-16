using System.Threading.Tasks;
using DirectMail.Helpers;
using DirectMail.Models;
using Microsoft.AspNetCore.Mvc;

namespace DirectMail.Controllers
{
    public class ContactController : Controller
    {
        private readonly EmailHelper emailHelper;

        public ContactController(EmailHelper emailHelper)
        {
            this.emailHelper = emailHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(Message model)
        {
            if (ModelState.IsValid)
            {
                var task = Task.Factory.StartNew(async () => await emailHelper.SendMail(model));
                Task.WaitAll(task);
            }
            return RedirectToAction("Index");
        }
    }
}