using BusinessLayer.e_commerce;
using Modele.e_commerce.Modele.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEcommerce.Controllers
{
    public class ProduitController : Controller
    {
        // GET: Produit
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListProduit()
        {
            List<Produit> p = BusinessManager.Instance.GetAllProduit();
            return View("ListProduit",p);
        }

        public ActionResult GetProduit(int id)
        {
            Produit p = BusinessManager.Instance.GetProduit(id);
            return View("DetailsProduit", p);
        }

        public ActionResult EditProduit(int id)
        {
            Produit p = BusinessManager.Instance.GetProduit(id);
            return View("EditProduit", p);
        }
    }
}