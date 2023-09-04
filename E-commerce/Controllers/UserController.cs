using E_commerce.Data;
using E_commerce.Data.Static;
using E_commerce.Data.ViewModels;
using E_commerce.Models;
using E_commerce.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace E_commerce.Controllers
{
    public class UserController : Controller
    {
        
        EcommerceCountext db = new EcommerceCountext();
     
        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }



    }
}