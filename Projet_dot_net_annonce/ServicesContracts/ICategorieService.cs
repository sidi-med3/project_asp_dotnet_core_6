using Projet_dot_net_annonce.Models;

namespace Projet_dot_net_annonce.ServicesContracts
{
    public interface ICategorieService
    {
        Task<IEnumerable<Categorie>> GetAll();
        Task<bool> Add(Categorie categorie);
        bool Edite(Categorie categorie);
        bool Delete(Categorie categorie);
        Task<Categorie> GetByIdAsync(int id);
        bool Save();
    }
}
