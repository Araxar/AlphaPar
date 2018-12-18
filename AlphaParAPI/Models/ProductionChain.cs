using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlphaParAPI.Models
{
    public class ProductionChain : BaseEntity
    {
        [StringLength(30, ErrorMessage = "Le nom n'a pas la bonne synthaxe ou est trop long (plus de 30 caractères)")]
        public string Name { get; set; }
    }
}
