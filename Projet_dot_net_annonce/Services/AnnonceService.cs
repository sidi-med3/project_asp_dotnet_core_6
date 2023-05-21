using Microsoft.EntityFrameworkCore;
using Projet_dot_net_annonce.Data;
using Projet_dot_net_annonce.Models;
using Projet_dot_net_annonce.ServicesContracts;

namespace Projet_dot_net_annonce.Services
{
    public class AnnonceService : IAnnonceService
    {
        private readonly AppDbContext _context;
        public AnnonceService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Annonce annonce)
        {
            _context.Add(annonce);
            return Save();
        }

        public bool Delete(Annonce annonce)
        {
            _context.Remove(annonce);
            return Save();
        }

        public async Task<bool> Edite(Annonce annonce)
        {
            _context.Update(annonce);
            return Save();

        }

        public async Task<IEnumerable<Annonce>> GetAll()
        {
            return await _context.Annonces.ToListAsync();
            
        }

        public async Task<IEnumerable<Annonce>> GetAnnonceByCat(int categorieid)
        {
            return await _context.Annonces.Where(a => a.CategorieId == categorieid).ToListAsync();
           // return await  _context.Annonces.Where(a =>a.Categorie.Name.Contains(name)).ToListAsync();
        }

        public async Task<Annonce> GetByIdAsync(int id)
        {
            return await _context.Annonces.Include(i => i.Categorie).FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ?true: false;
        }

        
    }
}
