﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.directory1 = "Multishop";
            ViewBag.directory2 = "İletişim";
            ViewBag.directory3 = "Bize Ulaşın";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto request)
        {
            request.IsRead = false;
            request.SendDate = DateTime.Now;
            await _contactService.CreateContactAsync(request);
            return RedirectToAction("Index", "Contact");
        }
    }
}
