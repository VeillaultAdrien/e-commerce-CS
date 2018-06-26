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
        [AcceptVerbs("POST", "GET")]
        public ActionResult ListProduit()
        {
            List<Produit> p = BusinessManager.Instance.GetAllProduit();
            if (HttpContext.Request.RequestType == "POST")
            {
                String nom = Request.Params.Get("NomProduit");
               
                //Parce que la console c'est la vie pour débugger :p
                System.Diagnostics.Debug.WriteLine("Nom du produit" + nom);
                p = BusinessManager.Instance.SearchProduit(nom);
                return View("ListProduit", p);
            }
            
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

        [ActionName("ajout")]
        public ActionResult AjouterProduit()
        {
           return View("AjouterProduit");
        }

        [HttpPost]
        [ActionName("ajouterProduit")]
        public ActionResult AjoutProduit(Produit model)
        {

            BusinessManager.Instance.AjouterProduit(model);

            return View("DetailsProduit", model);
        }

        [HttpPost][ActionName("editionProduit")]
        public ActionResult ChangeProduit(Produit model)
        {

            BusinessManager.Instance.ModifierProduit(model);
            
            return View("DetailsProduit", model);
        }

        [HttpGet]
        [ActionName("supp")]
        public ActionResult SupprimerProduit(int id)
        {
                BusinessLayer.e_commerce.BusinessManager.Instance.SupprimerProduit(id);
                return ListProduit();
        }
    }
}