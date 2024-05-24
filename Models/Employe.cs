using System.ComponentModel.DataAnnotations;
namespace atelier1.Models
{
    public class Employe
    {
        public int Id {  get; set; }
        [Required,StringLength (10,ErrorMessage ="Taille max 10 characters")] /// haja t5rjhlik ki bch t3mr formulaire
        public string Name { get; set; }
        [Required]
        public string Departement { get; set; }
        [Range(200, 5000)]
        public int Sallery { get; set; }
       
    }
}
