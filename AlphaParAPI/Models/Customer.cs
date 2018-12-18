
using System.ComponentModel.DataAnnotations;

namespace AlphaParAPI.Models
{
    public class Customer : BaseEntity
    {
        [StringLength(30, ErrorMessage = "Le nom n'a pas la bonne synthaxe ou est trop long (plus de 30 caractères)")]
        public string Name { get; set; }

        [StringLength(14, MinimumLength = 14, ErrorMessage = "Le numéro Siret n'a pas la bonne synthaxe")]
        public string Siret { get; set; }
        [Phone(ErrorMessage = "Le numéro de téléphone n'a pas la bonne synthaxe")]
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage = "L'adresse email n'a pas la bonne synthaxe")]
        public string Email { get; set; }
    }
}
