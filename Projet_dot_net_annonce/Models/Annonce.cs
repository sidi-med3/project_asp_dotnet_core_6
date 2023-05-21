using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_dot_net_annonce.Models
{
    public class Annonce
    {
       public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public bool Etat { get; set; }
        
        public String Image { get; set; }
        public float Prix { get; set; }
        public string email { get; set; }
        [ForeignKey("Categorie")]
        public int CategorieId { get; set; }
        public Categorie? Categorie{ get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAnnonce { get; set; }
    }
}
