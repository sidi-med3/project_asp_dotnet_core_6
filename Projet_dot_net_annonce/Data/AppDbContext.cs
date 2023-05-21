using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projet_dot_net_annonce.Models;

namespace Projet_dot_net_annonce.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { 
        }
        public DbSet<Annonce> Annonces { get; set; }
        public DbSet<Categorie> Categories { get; set; }
       
    }
}
