using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaParAPI.Models
{
    public class Piece : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public List<PieceProductionChain> PieceProductionChains { get; set; }
    }
}
