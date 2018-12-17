using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaParWindows.Models
{
    public class Plan : BaseEntity
    {
        public string Name { get; set; }
        public TimeSpan Time { get; set; }

        public string IdPiece { get; set; }
        public Piece Piece { get; set; }

    }
}
