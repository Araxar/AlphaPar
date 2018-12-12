using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaParAPI.Models
{
    public class PieceProductionChain
    {
        public string IdPiece { get; set; }
        public Piece Piece { get; set; }
        public string IdProductionChain { get; set; }
        public ProductionChain ProductionChain { get; set; }
    }
}
