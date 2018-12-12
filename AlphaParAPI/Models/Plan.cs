using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaParAPI.Models
{
    public class Plan : BaseEntity
    {
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        
        public string IdPiece { get; set; }
        [ForeignKey("IdPiece")]
        public Piece Piece { get; set; }

    }
}
