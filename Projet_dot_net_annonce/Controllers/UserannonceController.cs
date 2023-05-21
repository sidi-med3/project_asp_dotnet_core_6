using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projet_dot_net_annonce.Data;
using Projet_dot_net_annonce.Models;
using Projet_dot_net_annonce.ServicesContracts;

namespace Projet_dot_net_annonce.Controllers
{
    public class UserannonceController : Controller
    {
        private readonly IAnnonceService _annonceService;

        private readonly AppDbContext _context;
        public UserannonceController(IAnnonceService annonceService, AppDbContext context)
        {
            _annonceService = annonceService;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Annonce> annonces = await _annonceService.GetAll();
            return View(annonces);
        }
        public async Task<IActionResult> Detail(int id)
        {
            Annonce annonce = await _annonceService.GetByIdAsync(id);
            return View(annonce);

        }

        public async Task<IActionResult> AffichageParCat(int CatId)
        {


            IEnumerable<Annonce> annonces = await _annonceService.GetAnnonceByCat(CatId);
            return View(annonces);
        }
        public IActionResult Create()
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
        public async Task<IActionResult> Create(Annonce annonce)
        {
            if (!ModelState.IsValid)
            {
                List<Categorie> cats = _context.Categories.ToList();
                //   var categories = await _categorieService.GetAll();

                ViewBag.Categories = cats.Select(cats =>
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
            return RedirectToAction("Index");

        }
    }
}
