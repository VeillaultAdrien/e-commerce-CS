using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.e_commerce;
using Modele.e_commerce.Modele.Entities;
using WebEcommerce.Models;

namespace WebEcommerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Produit> produits = BusinessManager.Instance.MostSoldProduits();
            List<Commande> commandes = BusinessManager.Instance.LastCommandes();

            HomeViewModel homeViewModel = new HomeViewModel() {ListeCommandes = commandes, ListeProduits = produits};

            return View(homeViewModel);
        }
    }
}