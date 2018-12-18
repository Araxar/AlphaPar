using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaParAPI.Models
{
    public class Piece : BaseEntity
    {
        [StringLength(30, ErrorMessage = "Le nom n'a pas la bonne synthaxe ou est trop long (plus de 30 caractères)")]
        public string Name { get; set; }
        public int Stock { get; set; }
        [StringLength(36, MinimumLength = 36, ErrorMessage = "L'Id de la chaine de production n'a pas la bonne synthaxe")]
        public string IdProductionChain { get; set; }
        [ForeignKey("IdProductionChain")]
        public ProductionChain ProductionChain { get; set; }
    }
}
