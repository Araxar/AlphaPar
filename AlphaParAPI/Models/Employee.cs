using System.ComponentModel.DataAnnotations;

namespace AlphaParAPI.Models
{
    public class Employee : BaseEntity
    {
        [StringLength(30, ErrorMessage = "Le nom n'a pas la bonne synthaxe ou est trop long (plus de 30 caractères)")]
        public string Name { get; set; }
        [StringLength(30, ErrorMessage = "Le prénom n'a pas la bonne synthaxe ou est trop long (plus de 30 caractères)")]
        public string Surname { get; set; }
        [StringLength(10, ErrorMessage = "La date de naissance n'a pas la bonne synthaxe ")]
        public string DateOfBirth { get; set; }
        [Phone(ErrorMessage = "Le numéro de téléphone n'a pas la bonne synthaxe")]
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage = "L'adresse email n'a pas la bonne synthaxe")]
        public string Email { get; set; }
    }
}
