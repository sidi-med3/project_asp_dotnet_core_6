using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projet_dot_net_annonce.Data;
using Projet_dot_net_annonce.Models;
using Projet_dot_net_annonce.Services;
using Projet_dot_net_annonce.ServicesContracts;
using static System.Net.Mime.MediaTypeNames;

namespace Projet_dot_net_annonce.Controllers
{
    public class AnnonceController : Controller
    {
        private readonly IAnnonceService _annonceService;

        private readonly AppDbContext _context;
        public AnnonceController(IAnnonceService annonceService, AppDbContext context)
        {
            _annonceService = annonceService;
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Annonce> annonces = await _annonceService.GetAll();
            return View(annonces);
        }
        public async Task<IActionResult> Annonces_non_publiées()
        {
            IEnumerable<Annonce> annonces = await _annonceService.GetAll();
            return View(annonces);
        }

       
        public async Task<IActionResult> Detail(int id)
        {
            Annonce annonce = await _annonceService.GetByIdAsync(id);
            return View(annonce);

        }
       
        public async Task<IActionResult> Publier(int id)
        {
            Annonce annonce = await _annonceService.GetByIdAsync(id);
            annonce.Etat = true;

            await _annonceService.Edite(annonce);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> AffichageParCat(int CatId)
        {


            IEnumerable<Annonce> annonces = await _annonceService.GetAnnonceByCat(CatId);
            return View(annonces);
        }
        public  IActionResult Create()
        {
            var cats = _context.Categories.ToList();
            ViewBag.Categories = cats.Select(cats =>
            new SelectListItem()
            {
                Text = cats.Name,
                Value = cats.Id.ToString()

            });
            return View();

        }
        [HttpPost]
        public async  Task<IActionResult> Create(Annonce annonce)
        {
            if (!ModelState.IsValid)
            {
                List<Categorie> cats = _context.Categories.ToList();
                //   var categories = await _categorieService.GetAll();

                ViewBag.Categories =  cats.Select(cats =>
               new SelectListItem()
               {
                   Text = cats.Name,
                   Value = cats.Id.ToString()

               });

                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                //return View(annonce);
            }



            await _annonceService.Add(annonce);
            return   RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(int id)
        {
            var cats =  _context.Categories.ToList();
            ViewBag.Categories = cats.Select(cats =>
            new SelectListItem()
            {
                Text = cats.Name,
                Value = cats.Id.ToString()

            });
            var annonce = await _annonceService.GetByIdAsync(id);
            if (annonce == null) return View("Error");
            var newannonce = new Annonce
            {
                Titre = annonce.Titre,
                Description = annonce.Description,
                Etat = annonce.Etat,
                Image = annonce.Image,
                Prix = annonce.Prix,
                DateAnnonce = annonce.DateAnnonce,
                email = annonce.email,
                Categorie = annonce.Categorie



            };
            return View(newannonce);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Annonce annonce)
        {
            if (!ModelState.IsValid)
            {
                List<Categorie> cats =  _context.Categories.ToList();


                ViewBag.Categories = cats.Select(cats =>
               new SelectListItem()
               {
                   Text = cats.Name,
                   Value = cats.Id.ToString()

               });
                ModelState.AddModelError("", "Erreur de Modification d'Annonce");
                return View("Edit", annonce);
            }
            var newannonce = new Annonce
            {
                Id = id,
                Titre = annonce.Titre,
                Description = annonce.Description,
                Etat = annonce.Etat,
                Image = annonce.Image,
                Prix = annonce.Prix,
                DateAnnonce = annonce.DateAnnonce,
                email = annonce.email,
                CategorieId = annonce.CategorieId,
                Categorie = annonce.Categorie

            };

           await   _annonceService.Edite(newannonce);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delet(int id)
        {
            var annonce = await _annonceService.GetByIdAsync(id);
            _annonceService.Delete(annonce);
                
            return RedirectToAction("Index");

        }

    }
}
