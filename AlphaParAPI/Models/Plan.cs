using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaParAPI.Models
{
    public class Plan : BaseEntity
    {
        [StringLength(30, ErrorMessage = "Le nom n'a pas la bonne synthaxe ou est trop long (plus de 30 caractères)")]
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        [StringLength(36, MinimumLength = 36, ErrorMessage = "L'Id de la pièce n'a pas la bonne synthaxe")]
        public string IdPiece { get; set; }
        [ForeignKey("IdPiece")]
        public Piece Piece { get; set; }

    }
}
