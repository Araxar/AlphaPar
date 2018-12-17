using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaParWindows.Models
{
    public class Piece : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public string IdProductionChain { get; set; }
        public ProductionChain ProductionChain { get; set; }
    }
}
