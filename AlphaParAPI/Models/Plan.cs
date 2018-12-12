using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
