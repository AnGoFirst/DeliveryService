﻿using Delivery.DataBase;
using Delivery.DataBase.Models;
using Delivery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Delivery.Controllers
{
    public class UserController : Controller
    {
        private DbRepository dbRepository;
        public static string UserName = string.Empty;
        public UserController()
        {
            dbRepository = new DbRepository();
        }
        public IActionResult Index()
        {
            return View(dbRepository.GetProducts().Result);
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Buy()
        {
            return View();
        }
        public IActionResult Validate(LogginModel user)
        {
            UserName = user.Name;
            var status = dbRepository.GetUserStatus(user);
            if (status == 0)
                return RedirectToAction("Register", "User");
            else if (status == 1)
                return RedirectToAction("Index", "Admin");
            else if (status == 2)
                return RedirectToAction("Index", "Courier");
            else
                return RedirectToAction("Index", "User");
        }

        public IActionResult CreateAccount(LogginModel user)
        {
            dbRepository.AddUser(new UserModel
            {
                Name = user.Name,
                Balance = 100,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            }).Wait();
            return RedirectToAction("Login", "User"); ;
        }

        public IActionResult UserProducts()
        {
            return View(dbRepository.GetUserProducts(UserName).Result);
        }
        public IActionResult BuyProduct(BuyModel model)
        {
            model.UserName = UserName;
            dbRepository.BuyProduct(model).Wait();
            return RedirectToAction("UserProduct", "User");
        }

        [Route("balance")]
        [HttpPut]
        public IActionResult EditBalance([FromBody] User user)
        {
            dbRepository.EditBalance(user).Wait();
            return Ok();
        }
    }
}
