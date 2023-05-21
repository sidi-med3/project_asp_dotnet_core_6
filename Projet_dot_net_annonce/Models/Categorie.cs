using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_dot_net_annonce.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Annonce> ? Annonces { get; set; }

    }
}
