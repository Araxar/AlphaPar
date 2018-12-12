using System.Collections.Generic;

namespace AlphaParAPI.Models
{
    public class Piece : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public List<PieceProductionChain> PieceProductionChains { get; set; }
    }
}
