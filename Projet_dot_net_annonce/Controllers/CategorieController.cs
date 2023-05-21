using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projet_dot_net_annonce.Models;
using Projet_dot_net_annonce.Services;
using Projet_dot_net_annonce.ServicesContracts;

namespace Projet_dot_net_annonce.Controllers
{
    public class CategorieController : Controller
    {
        private readonly ICategorieService _categorieService;
        public CategorieController(ICategorieService categorieService)
        {
            _categorieService = categorieService;

        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Categorie> categories = await _categorieService.GetAll();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categorie categorie)

        {
            if (!ModelState.IsValid)
            {

                return View(categorie);
            }

            await _categorieService.Add(categorie);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Edit(int id)
        {

            var categorie = await _categorieService.GetByIdAsync(id);
            if (categorie == null) return View("Error");
            var newcategorie = new Categorie
            {

                Name = categorie.Name


            };
            return View(categorie);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Categorie categorie)
        {
            if ( !ModelState.IsValid)
            {
                ModelState.AddModelError("", "Erreur de Modification d'Annonce");
                return View("Edit", categorie);
            }
            var newcategorie = new Categorie
            {
                Id = id,
                Name = categorie.Name
            };
            _categorieService.Edite(newcategorie);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delet(int id)
        {
            var categorie = await _categorieService.GetByIdAsync(id);
            _categorieService.Delete(categorie);
            return RedirectToAction("Index");

        }
    }
}
