using System.Collections.Generic;

namespace AlphaParAPI.Models
{
    public class ProductionChain : BaseEntity
    {
        public string Name { get; set; }
        public List<PieceProductionChain> PieceProductionChains { get; set; }
    }
}
