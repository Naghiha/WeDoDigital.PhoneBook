using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WeDoDigital.PhoneBook.DTO;
using WeDoDigital.PhoneBook.Interface;
using WeDoDigital.PhoneBook.Presentation.Models;

namespace WeDoDigital.PhoneBook.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IContacts _contacts;

        public HomeController(ILogger<HomeController> logger, IContacts contacts)
        {
            _logger = logger;
            _contacts = contacts;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> contact(int? Id)
        {
            if (Id != null && Id > 0)
            {
                return View(await _contacts.Get(Id.Value));
            }
            return View();
        }

        public async Task<IActionResult> ContactList()
        {
            return PartialView("ContactList", await _contacts.Get());
        }

        public async Task<IActionResult> Delete(int Id)
        {
            if(await _contacts.Delete(Id))
            {
                return Ok();
            }
            return Error();

        }
        public async Task<IActionResult> update(PhoneBookDTO contact)
        {
            if (await _contacts.Update(contact))
            {
                return Ok();
            }
            return Error();
        }
        public async Task<IActionResult> Insert(PhoneBookDTO contact)
        {
            if (await _contacts.Insert(contact))
            {
                return Ok();
            }
            return Error();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
