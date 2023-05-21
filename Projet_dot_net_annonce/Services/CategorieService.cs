using Microsoft.EntityFrameworkCore;
using Projet_dot_net_annonce.Data;
using Projet_dot_net_annonce.Models;
using Projet_dot_net_annonce.ServicesContracts;

namespace Projet_dot_net_annonce.Services
{
    public class CategorieService : ICategorieService
    {
        private readonly AppDbContext _context;

        public CategorieService(AppDbContext context)
        {
            _context = context;
        }
        public async  Task<bool> Add(Categorie categorie)
        {
             _context.Add(categorie);
            return Save();
        }

        public bool Delete(Categorie categorie)
        {
            _context.Remove(categorie);
            return Save();
        }

        public bool Edite(Categorie categorie)
        {
            _context.Update(categorie);
            return Save();
        }

        public async Task<IEnumerable<Categorie>> GetAll()
        {
             return await _context.Categories.ToListAsync();
        }

        public async Task<Categorie> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;

        }
    }
}
