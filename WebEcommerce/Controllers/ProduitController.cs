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

        [ActionName("list")]
        public ActionResult ListProduit()
        {
            List<Produit> p = BusinessManager.Instance.GetAllProduit();
            return View("ListProduit",p);
        }

        [ActionName("get")]
        public ActionResult GetProduit(int id)
        {
            Produit p = BusinessManager.Instance.GetProduit(id);
            return View("DetailsProduit", p);
        }

        [ActionName("edit")]
        public ActionResult EditProduit(int id)
        {
            Produit p = BusinessManager.Instance.GetProduit(id);
            return View("EditProduit", p);
        }

        [HttpPost][ActionName("editionProduit")]
        public ActionResult ChangeProduit(Produit model)
        {
            if(ModelState.IsValid)
            {
                BusinessLayer.e_commerce.BusinessManager.Instance.ModifierProduit(model);
            }
            return View("DetailsProduit", model);
        }
    }
}