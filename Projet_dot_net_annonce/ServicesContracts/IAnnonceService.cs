using Projet_dot_net_annonce.Models;

namespace Projet_dot_net_annonce.ServicesContracts
{
    public interface IAnnonceService
    {
        Task<IEnumerable<Annonce>> GetAll();
        Task<Annonce> GetByIdAsync(int id);
        Task<IEnumerable<Annonce>> GetAnnonceByCat(int categorieid);
        Task<bool> Add(Annonce annonce);
        Task<bool> Edite(Annonce annonce);
        bool Delete(Annonce annonce);
        bool Save();
    }
}
