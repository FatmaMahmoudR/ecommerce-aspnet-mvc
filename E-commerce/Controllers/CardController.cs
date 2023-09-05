using E_commerce.Models;
using E_commerce.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace E_commerce.Controllers
{
    public class CardController : Controller
    {
        EcommerceCountext db = new EcommerceCountext();

        private readonly IHttpContextAccessor _contxt;

        public CardController(IHttpContextAccessor c)
        {
            _contxt = c;
        }

        public IActionResult Index(int id)
        {
            CardJoinProduct vm = new CardJoinProduct();
            
            Card? c = db.Cards.Where(s=>s.active == true && s.BuyerId == id).FirstOrDefault();

            vm.card = c;
            vm.card.OrderedProducts = db.OrderedProducts.Where(x=>x.BuyerID == id && x.CardID==c.Id).ToList();
           
            vm.products= db.Products.ToList();
            return View(vm);
        }
        public IActionResult Delete(int id)
        {
            OrderedProduct op = db.OrderedProducts.Find(id);
            int? Bid = op.BuyerID;
            db.Remove(op);
            db.SaveChanges();
            return RedirectToAction("index", new {id = Bid } );
        }
        
            public IActionResult PlaceOrder(int id)
        {

            //deactivate current card
            Card OldC = db.Cards.Find(id);
            OldC.active = false;
            db.SaveChanges();

           
            //create new card for the user
            Card BCard = new Card();
            var BId = OldC.BuyerId;

            BCard.BuyerId = BId;
            BCard.active= true;
            db.Cards.Add(BCard);
            db.SaveChanges();

            //update card value in the Http Session 

            _contxt.HttpContext.Session.SetInt32("card", 0);


            return RedirectToAction("Index","Product");
        }

    }
}
