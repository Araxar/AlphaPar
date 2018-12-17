using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlphaParAPI.Models
{
    public class Piece : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public string IdProductionChain { get; set; }
        [ForeignKey("IdProductionChain")]
        public ProductionChain ProductionChain { get; set; }
    }
}
